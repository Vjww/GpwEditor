using System;
using App.BaseGameEditor.Application.DataServiceExporters;
using App.BaseGameEditor.Application.DataServiceImporters;
using App.BaseGameEditor.Data.DataConnections;
using App.BaseGameEditor.Domain;
using App.BaseGameEditor.Infrastructure.DataServices;

namespace App.BaseGameEditor.Application.DomainServices
{
    public class DomainService
    {
        private readonly DataConnection _dataConnection;
        private readonly BaseGameDataServiceExporter _baseGameDataServiceExporter;
        private readonly BaseGameDataServiceImporter _baseGameDataServiceImporter;
        private readonly TeamServiceExporter _teamServiceExporter;
        private readonly TeamServiceImporter _teamServiceImporter;

        public DomainModelService DomainModelService { get; }

        public DomainService(
            DataConnection dataConnection,
            BaseGameDataServiceExporter baseGameDataServiceExporter,
            BaseGameDataServiceImporter baseGameDataServiceImporter,
            DomainModelService domainModelService,
            TeamServiceExporter teamServiceExporter,
            TeamServiceImporter teamServiceImporter)
        {
            _dataConnection = dataConnection ?? throw new ArgumentNullException(nameof(dataConnection));
            _baseGameDataServiceExporter = baseGameDataServiceExporter ?? throw new ArgumentNullException(nameof(baseGameDataServiceExporter));
            _baseGameDataServiceImporter = baseGameDataServiceImporter ?? throw new ArgumentNullException(nameof(baseGameDataServiceImporter));
            _teamServiceExporter = teamServiceExporter ?? throw new ArgumentNullException(nameof(teamServiceExporter));
            _teamServiceImporter = teamServiceImporter ?? throw new ArgumentNullException(nameof(teamServiceImporter));

            DomainModelService = domainModelService ?? throw new ArgumentNullException(nameof(domainModelService));
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

            // TODO: We want to export everything from domain layer into data layer
            _baseGameDataServiceExporter.Export(_dataConnection);

            // TODO: and then export everything from data layer into file
            _teamServiceExporter.Export();
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

            // TODO: We want to import everything from file into data layer
            _baseGameDataServiceImporter.Import(_dataConnection);

            // TODO: and then import everything from data layer into domain layer.
            _teamServiceImporter.Import();
        }
    }
}