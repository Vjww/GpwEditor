using System;
using System.Linq;
using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.AutoMapperMaps;
using AutoMapper;

namespace App.BaseGameEditor.Application.Services
{
    public class TeamDomainModelExportService
    {
        private readonly TeamService _service;
        private readonly DataService _dataService;
        private readonly CarNumbersObjectToCarNumberEntitiesMapper _carNumbersMapper;

        public TeamDomainModelExportService(
            TeamService service,
            DataService dataService,
            CarNumbersObjectToCarNumberEntitiesMapper carNumbersMapper)
        {
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
                var teamEntity = Mapper.Map<TeamEntity>(team);
                var chassisHandlingEntity = Mapper.Map<ChassisHandlingEntity>(team);
                var carNumberEntities = _carNumbersMapper.Map(team).ToList();
                var carNumberEntity1 = Mapper.Map<CarNumberEntity>(carNumberEntities.Single(x => x.PositionId == 0));
                var carNumberEntity2 = Mapper.Map<CarNumberEntity>(carNumberEntities.Single(x => x.PositionId == 1));

                _dataService.Teams.SetById(teamEntity);
                _dataService.ChassisHandlings.SetById(chassisHandlingEntity);
                _dataService.CarNumbers.SetById(carNumberEntity1);
                _dataService.CarNumbers.SetById(carNumberEntity2);
            }
        }
    }
}