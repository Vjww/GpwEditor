using System;
using System.Collections.Generic;
using System.IO;
using GpwEditor.Application.Managers.BaseGame;
using GpwEditor.Application.Models.BaseGame;
using GpwEditor.Domain.Objects.BaseGame;
using GpwEditor.Domain.Validators.BaseGame;
using GpwEditor.Infrastructure.Connections;
using GpwEditor.Infrastructure.Databases;
using GpwEditor.Infrastructure.DataSources;
using GpwEditor.Infrastructure.Services;

namespace GpwEditor.Application.Services
{
    public class BaseGameService
    {
        private readonly BaseGameDataContext _gameDataSource;
        private readonly BaseGameDatabase _gameDatabase;

        private readonly TeamManager _teamManager;

        public BaseGameService()
        {
            _gameDatabase = new BaseGameDatabase();

            _gameDataSource = new BaseGameDataContext(
                new StreamService<MemoryStream>(new MemoryStream()),
                new LanguageResourceService(LanguageType.English),
                new LanguageResourceService(LanguageType.French),
                new LanguageResourceService(LanguageType.German),
                new CommentaryResourceService(LanguageType.English),
                new CommentaryResourceService(LanguageType.French),
                new CommentaryResourceService(LanguageType.German));

            _teamManager = new TeamManager(
                _gameDatabase,
                new TeamValidator());
        }

        public IEnumerable<ITeamObject> GetTeams()
        {
            return _teamManager.GetTeams();
        }

        public void Load(
            string gameFolder,
            string gameExecutable,
            string englishLanguageResource,
            string frenchLanguageResource,
            string germanLanguageResource,
            string englishCommentaryResource,
            string frenchCommentaryResource,
            string germanCommentaryResource)
        {
            var connectionStrings = new BaseGameConnection
            {
                GameFolder = gameFolder,
                GameExecutable = gameExecutable,
                EnglishLanguageResource = englishLanguageResource,
                FrenchLanguageResource = frenchLanguageResource,
                GermanLanguageResource = germanLanguageResource,
                EnglishCommentaryResource = englishCommentaryResource,
                FrenchCommentaryResource = frenchCommentaryResource,
                GermanCommentaryResource = germanCommentaryResource
            };

            if (!ValidateConnectionStrings(connectionStrings))
            {
                throw new Exception("One or more connection strings are invalid.");
            }
            _gameDataSource.Load(connectionStrings);
            _gameDatabase.Import(_gameDataSource);
        }

        public void Save(
            string gameFolder,
            string gameExecutable,
            string englishLanguageResource,
            string frenchLanguageResource,
            string germanLanguageResource,
            string englishCommentaryResource,
            string frenchCommentaryResource,
            string germanCommentaryResource)
        {
            var connectionStrings = new BaseGameConnection
            {
                GameFolder = gameFolder,
                GameExecutable = gameExecutable,
                EnglishLanguageResource = englishLanguageResource,
                FrenchLanguageResource = frenchLanguageResource,
                GermanLanguageResource = germanLanguageResource,
                EnglishCommentaryResource = englishCommentaryResource,
                FrenchCommentaryResource = frenchCommentaryResource,
                GermanCommentaryResource = germanCommentaryResource
            };

            if (!ValidateConnectionStrings(connectionStrings))
            {
                throw new Exception("One or more connection strings are invalid.");
            }
            _gameDataSource.Save(connectionStrings);
            _gameDatabase.Export(_gameDataSource);
        }

        public void SetTeams(IEnumerable<TeamModel> teams)
        {
            _teamManager.SetTeams(teams);
        }

        private static bool ValidateConnectionStrings(BaseGameConnection connectionStrings)
        {
            if (string.IsNullOrWhiteSpace(connectionStrings.GameFolder)) return false;
            if (string.IsNullOrWhiteSpace(connectionStrings.GameExecutable)) return false;
            if (string.IsNullOrWhiteSpace(connectionStrings.EnglishLanguageResource)) return false;
            if (string.IsNullOrWhiteSpace(connectionStrings.FrenchLanguageResource)) return false;
            if (string.IsNullOrWhiteSpace(connectionStrings.GermanLanguageResource)) return false;
            if (string.IsNullOrWhiteSpace(connectionStrings.EnglishCommentaryResource)) return false;
            if (string.IsNullOrWhiteSpace(connectionStrings.FrenchCommentaryResource)) return false;
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (string.IsNullOrWhiteSpace(connectionStrings.GermanCommentaryResource)) return false;
            return true;
        }
    }
}