using System;
using System.Linq;
using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Infrastructure.Factories;
using TeamEntity = App.BaseGameEditor.Domain.Entities.TeamEntity;

namespace App.BaseGameEditor.Infrastructure.Mappers
{
    public class DataServiceToTeamEntityMapper
    {
        private readonly DataService _dataService;
        private readonly EntityFactory<TeamEntity> _factory;

        public DataServiceToTeamEntityMapper(
            DataService dataService,
            EntityFactory<TeamEntity> factory)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public TeamEntity Map(int id)
        {
            var result = _factory.Create(id);

            var teamEntity = (Data.Entities.TeamEntity)_dataService.Teams.Get(x => x.Id == id).Single();
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

            foreach (var item in _dataService.ChassisHandlings.Get())
            {
                if (!(item is ChassisHandlingEntity entity) || entity.TeamId != id) continue;
                result.ChassisHandling = entity.Value;
                break;
            }

            foreach (var item in _dataService.CarNumbers.Get())
            {
                if (!(item is CarNumberEntity entity) || entity.TeamId != id) continue;
                switch (entity.PositionId)
                {
                    case 0:
                        result.CarNumberDriver1 = entity.ValueA;
                        break;
                    case 1:
                        result.CarNumberDriver2 = entity.ValueA;
                        break;
                }
            }

            return result;
        }
    }
}