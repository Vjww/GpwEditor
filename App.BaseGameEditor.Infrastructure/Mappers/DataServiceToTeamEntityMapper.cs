using System;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Infrastructure.Factories;
using TeamDomainEntity = App.BaseGameEditor.Domain.Entities.TeamEntity;

namespace App.BaseGameEditor.Infrastructure.Mappers
{
    public class DataServiceToTeamEntityMapper
    {
        private readonly DataService _dataService;
        private readonly EntityFactory<TeamDomainEntity> _factory;

        public DataServiceToTeamEntityMapper(
            DataService dataService,
            EntityFactory<TeamDomainEntity> factory)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public TeamDomainEntity Map(int id)
        {
            var result = _factory.Create(id);

            var teamEntity = _dataService.Teams.Get(x => x.Id == id).Single();
            result.TeamId = teamEntity.Id + 1;
            result.Name = teamEntity.Name.All;
            result.LastPosition = teamEntity.LastPosition;
            result.LastPoints = teamEntity.LastPoints;
            result.FirstGpTrack = teamEntity.FirstGpTrack;
            result.FirstGpYear = teamEntity.FirstGpYear;
            result.Wins = teamEntity.Wins;
            result.YearlyBudget = teamEntity.YearlyBudget;
            result.CountryMapId = teamEntity.CountryMapId;
            result.LocationPointerX = teamEntity.LocationPointerX;
            result.LocationPointerY = teamEntity.LocationPointerY;
            result.TyreSupplierId = teamEntity.TyreSupplierId;

            var chassisHandlingEntities = _dataService.ChassisHandlings.Get();
            var chassisHandlingEntity = chassisHandlingEntities.Single(x => x.TeamId == id);
            result.ChassisHandling = chassisHandlingEntity.Value;

            var carNumberEntities = _dataService.CarNumbers.Get().Where(x => x.TeamId == id).ToList();
            result.CarNumberDriver1 = carNumberEntities.Single(x => x.PositionId == 0).ValueA;
            result.CarNumberDriver2 = carNumberEntities.Single(x => x.PositionId == 1).ValueA;

            return result;
        }
    }
}