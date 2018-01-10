using System;
using App.BaseGameEditor.Application.DataServiceExporters;
using App.BaseGameEditor.Application.DataServiceImporters;
using App.BaseGameEditor.Data.DataConnections;
using App.BaseGameEditor.Domain;
using App.BaseGameEditor.Infrastructure.DataServices;

namespace App.BaseGameEditor.Application.Services
{
    public class ApplicationService
    {
        private readonly DataConnection _dataConnection;
        private readonly BaseGameDataServiceExporter _baseGameDataServiceExporter;
        private readonly BaseGameDataServiceImporter _baseGameDataServiceImporter;
        private readonly DomainServiceExporter _domainServicesExporter;
        private readonly DomainServiceImporter _domainServiceImporter;

        public DomainModelService DomainModel { get; }

        public ApplicationService(
            DataConnection dataConnection,
            BaseGameDataServiceExporter baseGameDataServiceExporter,
            BaseGameDataServiceImporter baseGameDataServiceImporter,
            DomainModelService domainModelService,
            DomainServiceExporter domainServiceExporter,
            DomainServiceImporter domainServiceImporter)
        {
            _dataConnection = dataConnection ?? throw new ArgumentNullException(nameof(dataConnection));
            _baseGameDataServiceExporter = baseGameDataServiceExporter ?? throw new ArgumentNullException(nameof(baseGameDataServiceExporter));
            _baseGameDataServiceImporter = baseGameDataServiceImporter ?? throw new ArgumentNullException(nameof(baseGameDataServiceImporter));
            _domainServicesExporter = domainServiceExporter ?? throw new ArgumentNullException(nameof(domainServiceExporter));
            _domainServiceImporter = domainServiceImporter ?? throw new ArgumentNullException(nameof(domainServiceImporter));

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

            // TODO: Validation of file paths in application layer?

            // Export from domain layer into data layer
            _domainServicesExporter.Export();

            // Export from data layer into files
            _baseGameDataServiceExporter.Export(_dataConnection);
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

            // TODO: Validation of file paths in application layer?

            // Import from files into data layer
            _baseGameDataServiceImporter.Import(_dataConnection);

            // Import from data layer into domain layer
            _domainServiceImporter.Import();
        }
    }
}