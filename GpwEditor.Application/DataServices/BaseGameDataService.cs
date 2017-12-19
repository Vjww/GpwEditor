using System;
using System.Collections.Generic;
using GpwEditor.Application.Managers.BaseGame;
using GpwEditor.Domain.Models.BaseGame;
using GpwEditor.Infrastructure.DataConnections;

namespace GpwEditor.Application.DataServices
{
    public class BaseGameDataService
    {
        private readonly BaseGameDataConnection _dataConnection;
        private readonly BaseGameDataServiceExporter _dataServiceExporter;
        private readonly BaseGameDataServiceImporter _dataServiceImporter;
        private readonly TeamManager _teamManager;

        public BaseGameDataService(
            BaseGameDataConnection dataConnection,
            BaseGameDataServiceExporter dataServiceExporter,
            BaseGameDataServiceImporter dataServiceImporter,
            TeamManager teamManager)
        {
            _dataConnection = dataConnection ?? throw new ArgumentNullException(nameof(dataConnection));
            _dataServiceExporter = dataServiceExporter ?? throw new ArgumentNullException(nameof(dataServiceExporter));
            _dataServiceImporter = dataServiceImporter ?? throw new ArgumentNullException(nameof(dataServiceImporter));
            _teamManager = teamManager ?? throw new ArgumentNullException(nameof(teamManager));
        }

        public IEnumerable<ITeamModel> GetTeams()
        {
            return _teamManager.GetTeams();
        }

        public void Load(
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

            _dataServiceExporter.Export(_dataConnection);
        }

        public void Save(
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

            _dataServiceImporter.Import(_dataConnection);
        }

        public void SetTeams(IEnumerable<ITeamModel> teams)
        {
            _teamManager.SetTeams(teams);
        }
    }
}