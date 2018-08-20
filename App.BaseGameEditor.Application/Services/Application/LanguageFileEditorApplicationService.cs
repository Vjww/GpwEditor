using System;
using System.Linq;
using App.BaseGameEditor.Data.DataConnections;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;

namespace App.BaseGameEditor.Application.Services.Application
{
    public class LanguageFileEditorApplicationService
    {
        private readonly DataConnection _dataConnection;
        private readonly DataConnectionValidationService _dataConnectionValidationService;
        private readonly DataExportService _dataExportService;
        private readonly DataImportService _dataImportService;
        private readonly DomainModelExportService _domainModelExportService;
        private readonly DomainModelImportService _domainModelImportService;

        public DomainModelService DomainModel { get; }

        public LanguageFileEditorApplicationService(
            DataConnection dataConnection,
            DataConnectionValidationService dataConnectionValidationService,
            DataExportService dataExportService,
            DataImportService dataImportService,
            DomainModelService domainModelService,
            DomainModelExportService domainModelExportService,
            DomainModelImportService domainModelImportService)
        {
            _dataConnection = dataConnection ?? throw new ArgumentNullException(nameof(dataConnection));
            _dataConnectionValidationService = dataConnectionValidationService ?? throw new ArgumentNullException(nameof(dataConnectionValidationService));
            _dataExportService = dataExportService ?? throw new ArgumentNullException(nameof(dataExportService));
            _dataImportService = dataImportService ?? throw new ArgumentNullException(nameof(dataImportService));
            _domainModelExportService = domainModelExportService ?? throw new ArgumentNullException(nameof(domainModelExportService));
            _domainModelImportService = domainModelImportService ?? throw new ArgumentNullException(nameof(domainModelImportService));

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
        }
    }
}