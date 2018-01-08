using System;
using App.BaseGameEditor.Domain.Repositories;
using App.BaseGameEditor.Infrastructure.DataServices;
using App.BaseGameEditor.Infrastructure.Mappers;
using GpwEditor.Infrastructure.DataConnections;

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

    public class DomainRepositoryImporter
    {
        private readonly DataContextToTeamModelMapper _mapper;
        private readonly TeamRepository _teamRepository;

        public DomainRepositoryImporter(
            DataContextToTeamModelMapper mapper,
            TeamRepository teamRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }

        public void Import()
        {
            for (var i = 0; i < 11; i++)
            {
                var model = _mapper.Map(i);
                _teamRepository.Add(model);
            }
        }
    }
}