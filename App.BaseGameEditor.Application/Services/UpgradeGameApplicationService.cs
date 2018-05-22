using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using App.BaseGameEditor.Application.Validators;
using App.BaseGameEditor.Data.DataConnections;
using App.BaseGameEditor.Data.FileResources;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Factories;

namespace App.BaseGameEditor.Application.Services
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
            var drivers = DomainModel.Persons.GetF1Drivers().ToList();

            drivers.Single(x => x.Id == 0).Name = "Jacques Villeneuve"; // Replaces "John Newhouse" (Williams)
            drivers.Single(x => x.Id == 8).Name = "Jason Watt";         // Replaces "Driver Unknown" (Benetton)
            drivers.Single(x => x.Id == 14).Name = "Juichi Wakisaka";   // Replaces "Driver Unknown" (Jordan)
            drivers.Single(x => x.Id == 26).Name = "Mário Haberfeld";   // Replaces "Driver Unknown" (Stewart)

            DomainModel.Persons.SetF1Drivers(drivers);
        }

        private void UpgradeDriverCommentaryIndices()
        {
            var drivers = DomainModel.Commentaries.GetCommentaryIndexDrivers().ToList();
            drivers.Single(x => x.Id == 0).CommentaryIndex = 67;
            drivers.Single(x => x.Id == 1).CommentaryIndex = 68;
            drivers.Single(x => x.Id == 2).CommentaryIndex = 69;
            drivers.Single(x => x.Id == 3).CommentaryIndex = 70;
            drivers.Single(x => x.Id == 4).CommentaryIndex = 71;
            drivers.Single(x => x.Id == 5).CommentaryIndex = 72;
            drivers.Single(x => x.Id == 6).CommentaryIndex = 73;
            drivers.Single(x => x.Id == 7).CommentaryIndex = 74;
            drivers.Single(x => x.Id == 8).CommentaryIndex = 75;
            drivers.Single(x => x.Id == 9).CommentaryIndex = 76;
            drivers.Single(x => x.Id == 10).CommentaryIndex = 77;
            drivers.Single(x => x.Id == 11).CommentaryIndex = 78;
            drivers.Single(x => x.Id == 12).CommentaryIndex = 79;
            drivers.Single(x => x.Id == 13).CommentaryIndex = 80;
            drivers.Single(x => x.Id == 14).CommentaryIndex = 81;
            drivers.Single(x => x.Id == 15).CommentaryIndex = 82;
            drivers.Single(x => x.Id == 16).CommentaryIndex = 83;
            drivers.Single(x => x.Id == 17).CommentaryIndex = 84;
            drivers.Single(x => x.Id == 18).CommentaryIndex = 85;
            drivers.Single(x => x.Id == 19).CommentaryIndex = 86;
            drivers.Single(x => x.Id == 20).CommentaryIndex = 87;
            drivers.Single(x => x.Id == 21).CommentaryIndex = 88;
            drivers.Single(x => x.Id == 22).CommentaryIndex = 89;
            drivers.Single(x => x.Id == 23).CommentaryIndex = 90;
            drivers.Single(x => x.Id == 24).CommentaryIndex = 91;
            drivers.Single(x => x.Id == 25).CommentaryIndex = 92;
            drivers.Single(x => x.Id == 26).CommentaryIndex = 93;
            drivers.Single(x => x.Id == 27).CommentaryIndex = 94;
            drivers.Single(x => x.Id == 28).CommentaryIndex = 95;
            drivers.Single(x => x.Id == 29).CommentaryIndex = 96;
            drivers.Single(x => x.Id == 30).CommentaryIndex = 97;
            drivers.Single(x => x.Id == 31).CommentaryIndex = 98;
            drivers.Single(x => x.Id == 32).CommentaryIndex = 99;
            drivers.Single(x => x.Id == 33).CommentaryIndex = 100;
            drivers.Single(x => x.Id == 34).CommentaryIndex = 101;
            drivers.Single(x => x.Id == 35).CommentaryIndex = 102;
            drivers.Single(x => x.Id == 36).CommentaryIndex = 103;
            drivers.Single(x => x.Id == 37).CommentaryIndex = 104;
            drivers.Single(x => x.Id == 38).CommentaryIndex = 105;
            drivers.Single(x => x.Id == 39).CommentaryIndex = 106;
            drivers.Single(x => x.Id == 40).CommentaryIndex = 107; // Shared
            drivers.Single(x => x.Id == 41).CommentaryIndex = 107; // Shared
            drivers.Single(x => x.Id == 42).CommentaryIndex = 107; // Shared
            drivers.Single(x => x.Id == 43).CommentaryIndex = 107; // Shared
            DomainModel.Commentaries.SetCommentaryIndexDrivers(drivers);
        }

        private void UpgradeTeamCommentaryIndices()
        {
            var teams = DomainModel.Commentaries.GetCommentaryIndexTeams().ToList();
            teams.Single(x => x.Id == 0).CommentaryIndex = 231;
            teams.Single(x => x.Id == 1).CommentaryIndex = 232;
            teams.Single(x => x.Id == 2).CommentaryIndex = 233;
            teams.Single(x => x.Id == 3).CommentaryIndex = 234;
            teams.Single(x => x.Id == 4).CommentaryIndex = 235;
            teams.Single(x => x.Id == 5).CommentaryIndex = 236;
            teams.Single(x => x.Id == 6).CommentaryIndex = 237;
            teams.Single(x => x.Id == 7).CommentaryIndex = 238;
            teams.Single(x => x.Id == 8).CommentaryIndex = 239;
            teams.Single(x => x.Id == 9).CommentaryIndex = 240;
            teams.Single(x => x.Id == 10).CommentaryIndex = 241;
            DomainModel.Commentaries.SetCommentaryIndexTeams(teams);
        }

        // TODO: Possibly now redundant as we are using a stream of bytes? Rather than a text file
        //private static void CopyTextResourceToFile(string filePath, string resource)
        //{
        //    // https://stackoverflow.com/a/17269952
        //    File.WriteAllText(filePath, resource, Encoding.GetEncoding(1252)); // Western European (Windows)
        //}

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
                throw new Exception("Failed to validate data connection.");
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
                throw new Exception("Failed to validate data connection.");
            }

            // Import from files into data layer
            _dataImportService.Import(_dataConnection);

            // Import from data layer into domain layer
            _domainModelImportService.Import();
        }
    }
}