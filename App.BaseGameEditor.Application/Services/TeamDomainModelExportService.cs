using System;
using App.BaseGameEditor.Application.Maps.Manual;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Factories;
using App.BaseGameEditor.Infrastructure.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Application.Services
{
    public class TeamDomainModelExportService
    {
        private readonly TeamDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<TeamDataEntity> _teamDataEntityFactory;
        private readonly IIntegerIdentityFactory<ChassisHandlingDataEntity> _chassisHandlingDataEntityFactory;
        private readonly CarNumbersObjectFactory _carNumbersObjectFactory;
        private readonly IMapperService _mapperService;
        private readonly CarNumbersObjectToCarNumberDataEntitiesMapper _carNumbersMapper;

        public TeamDomainModelExportService(
            TeamDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<TeamDataEntity> teamDataEntityFactory,
            IIntegerIdentityFactory<ChassisHandlingDataEntity> chassisHandlingDataEntityFactory,
            CarNumbersObjectFactory carNumbersObjectFactory,
            IMapperService mapperService,
            CarNumbersObjectToCarNumberDataEntitiesMapper carNumbersMapper)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _teamDataEntityFactory = teamDataEntityFactory ?? throw new ArgumentNullException(nameof(teamDataEntityFactory));
            _chassisHandlingDataEntityFactory = chassisHandlingDataEntityFactory ?? throw new ArgumentNullException(nameof(chassisHandlingDataEntityFactory));
            _carNumbersObjectFactory = carNumbersObjectFactory ?? throw new ArgumentNullException(nameof(carNumbersObjectFactory));
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

                var carNumbersObject = _carNumbersObjectFactory.Create(team.Id);
                var carNumberDataEntities = _carNumbersMapper.Map(_mapperService.Map(team, carNumbersObject));

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