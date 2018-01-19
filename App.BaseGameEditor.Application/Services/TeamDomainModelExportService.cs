using System;
using System.Linq;
using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Maps;
using App.BaseGameEditor.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services
{
    public class TeamDomainModelExportService
    {
        private readonly TeamService _service;
        private readonly DataService _dataService;
        private readonly IMapperService _mapperService;
        private readonly CarNumbersObjectToCarNumberEntitiesMapper _carNumbersMapper;

        public TeamDomainModelExportService(
            TeamService service,
            DataService dataService,
            IMapperService mapperService,
            CarNumbersObjectToCarNumberEntitiesMapper carNumbersMapper)
        {
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _carNumbersMapper = carNumbersMapper ?? throw new ArgumentNullException(nameof(carNumbersMapper));
        }

        public void Export()
        {
            var teams = _service.GetTeams();
            foreach (var team in teams)
            {
                // Map one into three
                var teamEntity = _mapperService.Map<Domain.Entities.TeamEntity, TeamEntity>(team);
                var chassisHandlingEntity = _mapperService.Map<Domain.Entities.TeamEntity, ChassisHandlingEntity>(team);
                var carNumberEntities = _carNumbersMapper.Map(team).ToList();            // TODO: WHERE IS CARNUMBERSOBJECT USED?
                var carNumberEntity1 = carNumberEntities.Single(x => x.PositionId == 0); // TODO: WHERE IS CARNUMBERSOBJECT USED?
                var carNumberEntity2 = carNumberEntities.Single(x => x.PositionId == 1); // TODO: WHERE IS CARNUMBERSOBJECT USED?

                _dataService.Teams.SetById(teamEntity);
                _dataService.ChassisHandlings.SetById(chassisHandlingEntity);
                _dataService.CarNumbers.SetById(carNumberEntity1);
                _dataService.CarNumbers.SetById(carNumberEntity2);
            }
        }
    }
}