using System;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Maps;
using App.BaseGameEditor.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services
{
    public class TeamDomainModelExportService
    {
        private readonly TeamService _domainService;
        private readonly DataService _dataService;
        private readonly TeamDataEntityFactory _teamDataEntityFactory;
        private readonly ChassisHandlingDataEntityFactory _chassisHandlingDataEntityFactory;
        private readonly CarNumberDataEntityFactory _carNumberDataEntityFactory;
        private readonly IMapperService _mapperService;
        private readonly CarNumbersObjectToCarNumberDataEntitiesMapper _carNumbersMapper;

        public TeamDomainModelExportService(
            TeamService domainService,
            DataService dataService,
            TeamDataEntityFactory teamDataEntityFactory,
            ChassisHandlingDataEntityFactory chassisHandlingDataEntityFactory,
            CarNumberDataEntityFactory carNumberDataEntityFactory,
            IMapperService mapperService,
            CarNumbersObjectToCarNumberDataEntitiesMapper carNumbersMapper)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _teamDataEntityFactory = teamDataEntityFactory ?? throw new ArgumentNullException(nameof(teamDataEntityFactory));
            _chassisHandlingDataEntityFactory = chassisHandlingDataEntityFactory ?? throw new ArgumentNullException(nameof(chassisHandlingDataEntityFactory));
            _carNumberDataEntityFactory = carNumberDataEntityFactory ?? throw new ArgumentNullException(nameof(carNumberDataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
            _carNumbersMapper = carNumbersMapper ?? throw new ArgumentNullException(nameof(carNumbersMapper));
        }

        public void Export()
        {
            var teams = _domainService.GetTeams();
            foreach (var team in teams)
            {
                // Map one into three
                var teamDataEntity = _teamDataEntityFactory.Create(team.Id);
                _mapperService.Map(team, teamDataEntity);

                var chassisHandlingDataEntity = _chassisHandlingDataEntityFactory.Create(team.Id);
                _mapperService.Map(team, chassisHandlingDataEntity);

                // TODO: This doesnt seem right, should be mapping from Team -> Object -> DataEntities, currently missing middle step
                // TODO: team = _mapperService.Map(_carNumbersMapper.Map(team), carNumberDataEntities); ???
                var carNumberDataEntities = _carNumbersMapper.Map(team);

                _dataService.Teams.SetById(teamDataEntity);
                _dataService.ChassisHandlings.SetById(chassisHandlingDataEntity);
                foreach (var item in carNumberDataEntities)
                {
                    _dataService.CarNumbers.SetById(item);
                }
            }
        }
    }
}