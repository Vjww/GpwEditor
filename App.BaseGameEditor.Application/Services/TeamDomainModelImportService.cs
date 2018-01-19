using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Maps;
using App.BaseGameEditor.Infrastructure.Services;
using TeamEntity = App.BaseGameEditor.Domain.Entities.TeamEntity;

namespace App.BaseGameEditor.Application.Services
{
    public class TeamDomainModelImportService
    {
        private const int ItemCount = 11;

        private readonly TeamService _service;
        private readonly DataService _dataService;
        private readonly IMapperService _mapperService;
        private readonly CarNumberEntitiesToCarNumbersObjectMapper _carNumbersMapper;

        public TeamDomainModelImportService(
            TeamService service,
            DataService dataService,
            IMapperService mapperService,
            CarNumberEntitiesToCarNumbersObjectMapper carNumbersMapper)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
            _carNumbersMapper = carNumbersMapper ?? throw new ArgumentNullException(nameof(carNumbersMapper));
        }

        public void Import()
        {
            var teams = new List<TeamEntity>();
            for (var i = 0; i < ItemCount; i++)
            {
                var id = i;

                var teamData = _dataService.Teams.Get(x => x.Id == id).Single();
                var chassisHandlingData = _dataService.ChassisHandlings.Get(x => x.TeamId == id).Single();
                var carNumberData = _dataService.CarNumbers.Get(x => x.TeamId == id);

                // Map three into one
                // TODO: Should I create domain entity from factory here?
                // TODO: e.g. var team = _factory.Create(id);
                // TODO: e.g. team = _mapperService.Map<Data.Entities.TeamEntity, TeamEntity>(teamData, team);
                var team = _mapperService.Map<Data.Entities.TeamEntity, TeamEntity>(teamData);
                team = _mapperService.Map(chassisHandlingData, team);
                team = _mapperService.Map(_carNumbersMapper.Map(carNumberData), team);

                teams.Add(team);
            }
            _service.SetTeams(teams);
        }
    }
}