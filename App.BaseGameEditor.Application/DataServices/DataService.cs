using System;
using App.BaseGameEditor.Application.DataServiceExporters;
using App.BaseGameEditor.Application.DataServiceImporters;
using App.BaseGameEditor.Data.DataConnections;
using App.BaseGameEditor.Infrastructure.DataServices;

namespace App.BaseGameEditor.Application.DataServices
{
    public class DataService
    {
        private readonly BaseGameDataConnection _dataConnection;
        private readonly BaseGameDataServiceExporter _baseGameDataServiceExporter;
        private readonly BaseGameDataServiceImporter _baseGameDataServiceImporter;
        private readonly TeamDataServiceExporter _teamDataServiceExporter;
        private readonly TeamDataServiceImporter _teamDataServiceImporter;

        public TeamDataService Teams { get; }

        public DataService(
            BaseGameDataConnection dataConnection,
            BaseGameDataServiceExporter baseGameDataServiceExporter,
            BaseGameDataServiceImporter baseGameDataServiceImporter,
            TeamDataService teamDataService,
            TeamDataServiceExporter teamDataServiceExporter,
            TeamDataServiceImporter teamDataServiceImporter)
        {
            _dataConnection = dataConnection ?? throw new ArgumentNullException(nameof(dataConnection));
            _baseGameDataServiceExporter = baseGameDataServiceExporter ?? throw new ArgumentNullException(nameof(baseGameDataServiceExporter));
            _baseGameDataServiceImporter = baseGameDataServiceImporter ?? throw new ArgumentNullException(nameof(baseGameDataServiceImporter));
            _teamDataServiceExporter = teamDataServiceExporter ?? throw new ArgumentNullException(nameof(teamDataServiceExporter));
            _teamDataServiceImporter = teamDataServiceImporter ?? throw new ArgumentNullException(nameof(teamDataServiceImporter));

            Teams = teamDataService ?? throw new ArgumentNullException(nameof(teamDataService));
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
            _teamDataServiceExporter.Export();
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
            _teamDataServiceImporter.Import();
        }
    }
}