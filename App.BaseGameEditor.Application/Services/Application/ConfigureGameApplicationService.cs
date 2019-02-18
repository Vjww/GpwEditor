using System;
using System.Linq;
using App.BaseGameEditor.Domain.Services;
using App.Shared.Data.DataConnections;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Application.Services.Application
{
    public class ConfigureGameApplicationService
    {
        private readonly DataConnection _dataConnection;
        private readonly DataConnectionValidationService _dataConnectionValidationService;
        private readonly DataExportService _dataExportService;
        private readonly DataImportService _dataImportService;
        private readonly DomainModelExportService _domainModelExportService;
        private readonly DomainModelImportService _domainModelImportService;
        private readonly GameExecutableCodePatcher _gameExecutableCodePatcher;

        public DomainModelService DomainModel { get; }

        public ConfigureGameApplicationService(
            DataConnection dataConnection,
            DataConnectionValidationService dataConnectionValidationService,
            DataExportService dataExportService,
            DataImportService dataImportService,
            DomainModelService domainModelService,
            DomainModelExportService domainModelExportService,
            DomainModelImportService domainModelImportService,
            GameExecutableCodePatcher gameExecutableCodePatcher)
        {
            _dataConnection = dataConnection ?? throw new ArgumentNullException(nameof(dataConnection));
            _dataConnectionValidationService = dataConnectionValidationService ?? throw new ArgumentNullException(nameof(dataConnectionValidationService));
            _dataExportService = dataExportService ?? throw new ArgumentNullException(nameof(dataExportService));
            _dataImportService = dataImportService ?? throw new ArgumentNullException(nameof(dataImportService));
            _domainModelExportService = domainModelExportService ?? throw new ArgumentNullException(nameof(domainModelExportService));
            _domainModelImportService = domainModelImportService ?? throw new ArgumentNullException(nameof(domainModelImportService));
            _gameExecutableCodePatcher = gameExecutableCodePatcher ?? throw new ArgumentNullException(nameof(gameExecutableCodePatcher));

            DomainModel = domainModelService ?? throw new ArgumentNullException(nameof(domainModelService));
        }

        public void Export(
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

            // Export configuration changes to game executable
            _gameExecutableCodePatcher.ExportConfiguration(DomainModel, gameExecutableFilePath);
        }

        public void Import(
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

            // Import configuration changes from game executable
            _gameExecutableCodePatcher.ImportConfiguration(DomainModel, gameExecutableFilePath);
        }
    }
}