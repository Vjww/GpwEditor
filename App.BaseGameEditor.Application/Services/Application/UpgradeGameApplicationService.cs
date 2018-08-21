using System;
using System.Linq;
using App.BaseGameEditor.Application.Validators;
using App.BaseGameEditor.Domain.Services;
using App.Shared.Data.DataConnections;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Application.Services.Application
{
    public class UpgradeGameApplicationService
    {
        private readonly DataConnection _dataConnection;
        private readonly DataConnectionValidationService _dataConnectionValidationService;
        private readonly DataExportService _dataExportService;
        private readonly DataImportService _dataImportService;
        private readonly DomainModelExportService _domainModelExportService;
        private readonly DomainModelImportService _domainModelImportService;
        private readonly GameFolderValidator _gameFolderValidator;
        private readonly GameExecutableValidator _gameExecutableValidator;
        private readonly LanguageFileValidator _languageFileValidator;
        private readonly CommentaryFileValidator _commentaryFileValidator;
        private readonly EmbeddedResourceDeployer _embeddedResourceDeployer;
        private readonly GameExecutableCodePatcher _gameExecutableCodePatcher;

        public DomainModelService DomainModel { get; }

        public UpgradeGameApplicationService(
            DataConnection dataConnection,
            DataConnectionValidationService dataConnectionValidationService,
            DataExportService dataExportService,
            DataImportService dataImportService,
            DomainModelService domainModelService,
            DomainModelExportService domainModelExportService,
            DomainModelImportService domainModelImportService,
            GameFolderValidator gameFolderValidator,
            GameExecutableValidator gameExecutableValidator,
            LanguageFileValidator languageFileValidator,
            CommentaryFileValidator commentaryFileValidator,
            EmbeddedResourceDeployer embeddedResourceDeployer,
            GameExecutableCodePatcher gameExecutableCodePatcher)
        {
            _dataConnection = dataConnection ?? throw new ArgumentNullException(nameof(dataConnection));
            _dataConnectionValidationService = dataConnectionValidationService ?? throw new ArgumentNullException(nameof(dataConnectionValidationService));
            _dataExportService = dataExportService ?? throw new ArgumentNullException(nameof(dataExportService));
            _dataImportService = dataImportService ?? throw new ArgumentNullException(nameof(dataImportService));
            _domainModelExportService = domainModelExportService ?? throw new ArgumentNullException(nameof(domainModelExportService));
            _domainModelImportService = domainModelImportService ?? throw new ArgumentNullException(nameof(domainModelImportService));
            _gameFolderValidator = gameFolderValidator ?? throw new ArgumentNullException(nameof(gameFolderValidator));
            _gameExecutableValidator = gameExecutableValidator ?? throw new ArgumentNullException(nameof(gameExecutableValidator));
            _languageFileValidator = languageFileValidator ?? throw new ArgumentNullException(nameof(languageFileValidator));
            _commentaryFileValidator = commentaryFileValidator ?? throw new ArgumentNullException(nameof(commentaryFileValidator));
            _embeddedResourceDeployer = embeddedResourceDeployer ?? throw new ArgumentNullException(nameof(embeddedResourceDeployer));
            _gameExecutableCodePatcher = gameExecutableCodePatcher ?? throw new ArgumentNullException(nameof(gameExecutableCodePatcher));

            DomainModel = domainModelService ?? throw new ArgumentNullException(nameof(domainModelService));
        }

        public void Upgrade(
            string gameFolderPath,
            string gameExecutableFilePath,
            string englishLanguageFilePath,
            string frenchLanguageFilePath,
            string germanLanguageFilePath,
            string englishCommentaryFilePath,
            string frenchCommentaryFilePath,
            string germanCommentaryFilePath)
        {
            const string folderValidationMessageFormat = "The upgrader was unable to recognise the {0} as a valid path to upgrade. Please ensure the selected folder contains the required game folders and files, re-run this program as an administrator and try upgrading again.";
            const string fileValidationMessageFormat = "The upgrader was unable to recognise the {0} as a valid file to upgrade. Please ensure the file is not currently in use, re-run this program as an administrator and try upgrading again.";

            _gameFolderValidator.Validate(gameFolderPath, string.Format(folderValidationMessageFormat, "selected game folder"));

            // Deploy game executable
            _embeddedResourceDeployer.DeployExecutableResourcesToGameFolder(gameExecutableFilePath);
            _gameExecutableValidator.Validate(gameExecutableFilePath, string.Format(fileValidationMessageFormat, "game executable (gpw.exe)"));

            // Deploy language files
            _embeddedResourceDeployer.DeployLanguageResourcesToGameFolder(englishLanguageFilePath, frenchLanguageFilePath, germanLanguageFilePath);
            _languageFileValidator.Validate(englishLanguageFilePath, string.Format(fileValidationMessageFormat, "English language file (english.txt)"));
            _languageFileValidator.Validate(frenchLanguageFilePath, string.Format(fileValidationMessageFormat, "French language file (french.txt)"));
            _languageFileValidator.Validate(germanLanguageFilePath, string.Format(fileValidationMessageFormat, "German language file (german.txt)"));

            // Deploy commentary files
            _embeddedResourceDeployer.DeployCommentaryResourcesToGameFolder(gameFolderPath, englishCommentaryFilePath, frenchCommentaryFilePath, germanCommentaryFilePath);
            _commentaryFileValidator.Validate(englishCommentaryFilePath, string.Format(fileValidationMessageFormat, @"English commentary file (text\COMME.txt)"));
            _commentaryFileValidator.Validate(frenchCommentaryFilePath, string.Format(fileValidationMessageFormat, @"French commentary file (textf\COMMF.txt)"));
            _commentaryFileValidator.Validate(germanCommentaryFilePath, string.Format(fileValidationMessageFormat, @"German commentary file (textg\COMMG.txt)"));

            // Deploy driver changes
            _embeddedResourceDeployer.DeployDriverResourcesToGameFolder(gameFolderPath);

            // Apply code changes to game executable
            _gameExecutableCodePatcher.Upgrade(gameExecutableFilePath);

            Import(
                gameFolderPath,
                gameExecutableFilePath,
                englishLanguageFilePath,
                frenchLanguageFilePath,
                germanLanguageFilePath,
                englishCommentaryFilePath,
                frenchCommentaryFilePath,
                germanCommentaryFilePath);

            // Apply changes to the domain
            UpgradeDriverNames();
            UpgradeDriverFileNamePrefixes();
            UpgradeDriverCommentaryIndices();
            UpgradeTeamCommentaryIndices();

            Export(
                gameFolderPath,
                gameExecutableFilePath,
                englishLanguageFilePath,
                frenchLanguageFilePath,
                germanLanguageFilePath,
                englishCommentaryFilePath,
                frenchCommentaryFilePath,
                germanCommentaryFilePath);
        }

        private void UpgradeDriverNames()
        {
            // Update the domain to update the names in the language file(s)
            var f1Drivers = DomainModel.Persons.GetF1Drivers().ToList();

            f1Drivers.Single(x => x.Id == 0).Name = "Jacques Villeneuve"; // Replaces "John Newhouse" (Williams)
            f1Drivers.Single(x => x.Id == 8).Name = "Jason Watt";         // Replaces "Driver Unknown" (Benetton)
            f1Drivers.Single(x => x.Id == 14).Name = "Juichi Wakisaka";   // Replaces "Driver Unknown" (Jordan)
            f1Drivers.Single(x => x.Id == 26).Name = "Mário Haberfeld";   // Replaces "Driver Unknown" (Stewart)

            DomainModel.Persons.SetF1Drivers(f1Drivers);

            // Update the domain so each commentary line affected by a change in driver name is updated
            var commentaryDrivers = DomainModel.Commentaries.GetCommentaryDrivers().ToList();

            commentaryDrivers.Single(x => x.Id == 0).Name = f1Drivers.Single(x => x.Id == 0).Name;   // Name as defined above
            commentaryDrivers.Single(x => x.Id == 8).Name = f1Drivers.Single(x => x.Id == 8).Name;   // Name as defined above
            commentaryDrivers.Single(x => x.Id == 14).Name = f1Drivers.Single(x => x.Id == 14).Name; // Name as defined above
            commentaryDrivers.Single(x => x.Id == 26).Name = f1Drivers.Single(x => x.Id == 26).Name; // Name as defined above 

            DomainModel.Commentaries.SetCommentaryDrivers(commentaryDrivers);
        }

        private void UpgradeDriverFileNamePrefixes()
        {
            // Update the domain to update the file name prefix in the commentary file(s)
            var commentaryPrefixDrivers = DomainModel.Commentaries.GetCommentaryPrefixDrivers().ToList();

            commentaryPrefixDrivers.Single(x => x.Id == 0).FileNamePrefix = "ANON";  // Replaces "NEWH"
            commentaryPrefixDrivers.Single(x => x.Id == 8).FileNamePrefix = "ANON";  // Confirms "ANON"
            commentaryPrefixDrivers.Single(x => x.Id == 14).FileNamePrefix = "ANON"; // Confirms "ANON"
            commentaryPrefixDrivers.Single(x => x.Id == 26).FileNamePrefix = "ANON"; // Confirms "ANON"

            DomainModel.Commentaries.SetCommentaryPrefixDrivers(commentaryPrefixDrivers);

            // Update the domain so each commentary line affected by a change in file name prefix is updated
            var commentaryDrivers = DomainModel.Commentaries.GetCommentaryDrivers().ToList();

            commentaryDrivers.Single(x => x.Id == 0).FileNamePrefix = commentaryPrefixDrivers.Single(x => x.Id == 0).FileNamePrefix;   // FileNamePrefix as defined above
            commentaryDrivers.Single(x => x.Id == 8).FileNamePrefix = commentaryPrefixDrivers.Single(x => x.Id == 8).FileNamePrefix;   // FileNamePrefix as defined above
            commentaryDrivers.Single(x => x.Id == 14).FileNamePrefix = commentaryPrefixDrivers.Single(x => x.Id == 14).FileNamePrefix; // FileNamePrefix as defined above
            commentaryDrivers.Single(x => x.Id == 26).FileNamePrefix = commentaryPrefixDrivers.Single(x => x.Id == 26).FileNamePrefix; // FileNamePrefix as defined above

            DomainModel.Commentaries.SetCommentaryDrivers(commentaryDrivers);
        }

        private void UpgradeDriverCommentaryIndices()
        {
            var commentaryIndexDrivers = DomainModel.Commentaries.GetCommentaryIndexDrivers().ToList();
            commentaryIndexDrivers.Single(x => x.Id == 0).CommentaryIndex = 67;
            commentaryIndexDrivers.Single(x => x.Id == 1).CommentaryIndex = 68;
            commentaryIndexDrivers.Single(x => x.Id == 2).CommentaryIndex = 69;
            commentaryIndexDrivers.Single(x => x.Id == 3).CommentaryIndex = 70;
            commentaryIndexDrivers.Single(x => x.Id == 4).CommentaryIndex = 71;
            commentaryIndexDrivers.Single(x => x.Id == 5).CommentaryIndex = 72;
            commentaryIndexDrivers.Single(x => x.Id == 6).CommentaryIndex = 73;
            commentaryIndexDrivers.Single(x => x.Id == 7).CommentaryIndex = 74;
            commentaryIndexDrivers.Single(x => x.Id == 8).CommentaryIndex = 75;
            commentaryIndexDrivers.Single(x => x.Id == 9).CommentaryIndex = 76;
            commentaryIndexDrivers.Single(x => x.Id == 10).CommentaryIndex = 77;
            commentaryIndexDrivers.Single(x => x.Id == 11).CommentaryIndex = 78;
            commentaryIndexDrivers.Single(x => x.Id == 12).CommentaryIndex = 79;
            commentaryIndexDrivers.Single(x => x.Id == 13).CommentaryIndex = 80;
            commentaryIndexDrivers.Single(x => x.Id == 14).CommentaryIndex = 81;
            commentaryIndexDrivers.Single(x => x.Id == 15).CommentaryIndex = 82;
            commentaryIndexDrivers.Single(x => x.Id == 16).CommentaryIndex = 83;
            commentaryIndexDrivers.Single(x => x.Id == 17).CommentaryIndex = 84;
            commentaryIndexDrivers.Single(x => x.Id == 18).CommentaryIndex = 85;
            commentaryIndexDrivers.Single(x => x.Id == 19).CommentaryIndex = 86;
            commentaryIndexDrivers.Single(x => x.Id == 20).CommentaryIndex = 87;
            commentaryIndexDrivers.Single(x => x.Id == 21).CommentaryIndex = 88;
            commentaryIndexDrivers.Single(x => x.Id == 22).CommentaryIndex = 89;
            commentaryIndexDrivers.Single(x => x.Id == 23).CommentaryIndex = 90;
            commentaryIndexDrivers.Single(x => x.Id == 24).CommentaryIndex = 91;
            commentaryIndexDrivers.Single(x => x.Id == 25).CommentaryIndex = 92;
            commentaryIndexDrivers.Single(x => x.Id == 26).CommentaryIndex = 93;
            commentaryIndexDrivers.Single(x => x.Id == 27).CommentaryIndex = 94;
            commentaryIndexDrivers.Single(x => x.Id == 28).CommentaryIndex = 95;
            commentaryIndexDrivers.Single(x => x.Id == 29).CommentaryIndex = 96;
            commentaryIndexDrivers.Single(x => x.Id == 30).CommentaryIndex = 97;
            commentaryIndexDrivers.Single(x => x.Id == 31).CommentaryIndex = 98;
            commentaryIndexDrivers.Single(x => x.Id == 32).CommentaryIndex = 99;
            commentaryIndexDrivers.Single(x => x.Id == 33).CommentaryIndex = 100;
            commentaryIndexDrivers.Single(x => x.Id == 34).CommentaryIndex = 101;
            commentaryIndexDrivers.Single(x => x.Id == 35).CommentaryIndex = 102;
            commentaryIndexDrivers.Single(x => x.Id == 36).CommentaryIndex = 103;
            commentaryIndexDrivers.Single(x => x.Id == 37).CommentaryIndex = 104;
            commentaryIndexDrivers.Single(x => x.Id == 38).CommentaryIndex = 105;
            commentaryIndexDrivers.Single(x => x.Id == 39).CommentaryIndex = 106;
            commentaryIndexDrivers.Single(x => x.Id == 40).CommentaryIndex = 107; // Shared
            commentaryIndexDrivers.Single(x => x.Id == 41).CommentaryIndex = 107; // Shared
            commentaryIndexDrivers.Single(x => x.Id == 42).CommentaryIndex = 107; // Shared
            commentaryIndexDrivers.Single(x => x.Id == 43).CommentaryIndex = 107; // Shared
            DomainModel.Commentaries.SetCommentaryIndexDrivers(commentaryIndexDrivers);
        }

        private void UpgradeTeamCommentaryIndices()
        {
            var commentaryIndexTeams = DomainModel.Commentaries.GetCommentaryIndexTeams().ToList();
            commentaryIndexTeams.Single(x => x.Id == 0).CommentaryIndex = 231;
            commentaryIndexTeams.Single(x => x.Id == 1).CommentaryIndex = 232;
            commentaryIndexTeams.Single(x => x.Id == 2).CommentaryIndex = 233;
            commentaryIndexTeams.Single(x => x.Id == 3).CommentaryIndex = 234;
            commentaryIndexTeams.Single(x => x.Id == 4).CommentaryIndex = 235;
            commentaryIndexTeams.Single(x => x.Id == 5).CommentaryIndex = 236;
            commentaryIndexTeams.Single(x => x.Id == 6).CommentaryIndex = 237;
            commentaryIndexTeams.Single(x => x.Id == 7).CommentaryIndex = 238;
            commentaryIndexTeams.Single(x => x.Id == 8).CommentaryIndex = 239;
            commentaryIndexTeams.Single(x => x.Id == 9).CommentaryIndex = 240;
            commentaryIndexTeams.Single(x => x.Id == 10).CommentaryIndex = 241;
            DomainModel.Commentaries.SetCommentaryIndexTeams(commentaryIndexTeams);
        }

        private void Export(
            string gameFolderPath,
            string gameExecutableFilePath,
            string englishLanguageFilePath,
            string frenchLanguageFilePath,
            string germanLanguageFilePath,
            string englishCommentaryFilePath,
            string frenchCommentaryFilePath,
            string germanCommentaryFilePath)
        {
            _dataConnection.Initialise(
                gameFolderPath,
                gameExecutableFilePath,
                englishLanguageFilePath,
                frenchLanguageFilePath,
                germanLanguageFilePath,
                englishCommentaryFilePath,
                frenchCommentaryFilePath,
                germanCommentaryFilePath);

            // Validate connection prior to export
            var validationMessages = _dataConnectionValidationService.Validate(_dataConnection);
            if (validationMessages.Any())
            {
                throw new Exception("Failed to validate data connection."); // TODO: Include validation messages in exception details
            }

            // Export from domain layer into data layer
            _domainModelExportService.Export();

            // Export from data layer into files
            _dataExportService.Export(_dataConnection);
        }

        private void Import(
            string gameFolderPath,
            string gameExecutableFilePath,
            string englishLanguageFilePath,
            string frenchLanguageFilePath,
            string germanLanguageFilePath,
            string englishCommentaryFilePath,
            string frenchCommentaryFilePath,
            string germanCommentaryFilePath)
        {
            _dataConnection.Initialise(
                gameFolderPath,
                gameExecutableFilePath,
                englishLanguageFilePath,
                frenchLanguageFilePath,
                germanLanguageFilePath,
                englishCommentaryFilePath,
                frenchCommentaryFilePath,
                germanCommentaryFilePath);

            // Validate connection prior to import
            var validationMessages = _dataConnectionValidationService.Validate(_dataConnection);
            if (validationMessages.Any())
            {
                throw new Exception("Failed to validate data connection."); // TODO: Include validation messages in exception details
            }

            // Import from files into data layer
            _dataImportService.Import(_dataConnection);

            // Import from data layer into domain layer
            _domainModelImportService.Import();
        }
    }
}