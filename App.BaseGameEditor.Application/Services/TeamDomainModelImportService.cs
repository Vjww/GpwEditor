using System;
using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Mappers;

namespace App.BaseGameEditor.Application.Services
{
    public class TeamDomainModelImportService
    {
        private const int ItemCount = 11;

        private readonly TeamService _service;
        private readonly DataServiceToTeamEntityMapper _mapper;

        public TeamDomainModelImportService(
            TeamService service,
            DataServiceToTeamEntityMapper mapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Import()
        {
            var teams = new List<TeamEntity>();
            for (var i = 0; i < ItemCount; i++)
            {
                var team = _mapper.Map(i);
                teams.Add(team);
            }
            _service.SetTeams(teams);
        }
    }
}