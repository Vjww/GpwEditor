using System;
using App.BaseGameEditor.Infrastructure.DataServices;
using GpwEditor.Infrastructure.DataConnections;

namespace App.BaseGameEditor.Application.Services
{
    public class ExportService
    {
        private readonly BaseGameDataConnection _dataConnection;
        private readonly BaseGameDataServiceExporter _exporter;

        public ExportService(
            BaseGameDataConnection dataConnection,
            BaseGameDataServiceExporter exporter)
        {
            _dataConnection = dataConnection ?? throw new ArgumentNullException(nameof(dataConnection));
            _exporter = exporter ?? throw new ArgumentNullException(nameof(exporter));
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

            _exporter.Export(_dataConnection);
        }
    }
}