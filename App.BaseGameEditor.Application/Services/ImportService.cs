using System;
using App.BaseGameEditor.Infrastructure.DataServices;
using App.BaseGameEditor.Data.DataConnections;

namespace App.BaseGameEditor.Application.Services
{
    public class ImportService
    {
        private readonly BaseGameDataConnection _dataConnection;
        private readonly BaseGameDataServiceImporter _importer;
        private readonly DomainRepositoryImporter _repositoryImporter;

        public ImportService(
            BaseGameDataConnection dataConnection,
            BaseGameDataServiceImporter importer,
            DomainRepositoryImporter repositoryImporter)
        {
            _dataConnection = dataConnection ?? throw new ArgumentNullException(nameof(dataConnection));
            _importer = importer ?? throw new ArgumentNullException(nameof(importer));
            _repositoryImporter = repositoryImporter ?? throw new ArgumentNullException(nameof(repositoryImporter));
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

            _importer.Import(_dataConnection);

            // TODO: I think here we need to load domain repositories
            _repositoryImporter.Import();
        }
    }
}