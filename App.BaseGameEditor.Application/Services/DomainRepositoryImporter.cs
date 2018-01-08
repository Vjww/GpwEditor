using System;
using App.BaseGameEditor.Domain.Repositories;
using App.BaseGameEditor.Infrastructure.Mappers;

namespace App.BaseGameEditor.Application.Services
{
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