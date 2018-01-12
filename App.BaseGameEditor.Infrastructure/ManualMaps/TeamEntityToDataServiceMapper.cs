using System;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using TeamEntity = App.BaseGameEditor.Domain.Entities.TeamEntity;

namespace App.BaseGameEditor.Infrastructure.ManualMaps
{
    public class TeamEntityToDataServiceMapper
    {
        private readonly DataService _dataService;

        public TeamEntityToDataServiceMapper(DataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        public void Map(TeamEntity entity)
        {
            var teamEntity = _dataService.Teams.Get(x => x.Id == entity.Id).Single();
            teamEntity.Name.All = entity.Name;
            teamEntity.LastPosition = entity.LastPosition;
            teamEntity.LastPoints = entity.LastPoints;
            teamEntity.FirstGpTrack = entity.FirstGpTrack;
            teamEntity.FirstGpYear = entity.FirstGpYear;
            teamEntity.Wins = entity.Wins;
            teamEntity.YearlyBudget = entity.YearlyBudget;
            teamEntity.CountryMapId = entity.CountryMapId;
            teamEntity.LocationPointerX = entity.LocationPointerX;
            teamEntity.LocationPointerY = entity.LocationPointerY;
            teamEntity.TyreSupplierId = entity.TyreSupplierId;
            _dataService.Teams.SetById(teamEntity);

            var chassisHandlingEntity = _dataService.ChassisHandlings.Get(x => x.TeamId == entity.Id).Single();
            chassisHandlingEntity.Value = entity.ChassisHandling;
            _dataService.ChassisHandlings.SetById(chassisHandlingEntity);

            var carNumberEntities = _dataService.CarNumbers.Get(x => x.TeamId == entity.Id).ToList();
            if (carNumberEntities.Count != 2) throw new ArgumentOutOfRangeException();
            foreach (var item in carNumberEntities)
            {
                item.ValueA = item.PositionId == 0 ? entity.CarNumberDriver1 : entity.CarNumberDriver2;
                item.ValueB = item.PositionId == 0 ? entity.CarNumberDriver1 : entity.CarNumberDriver2;
            }
            _dataService.CarNumbers.SetById(carNumberEntities.Single(x => x.PositionId == 0));
            _dataService.CarNumbers.SetById(carNumberEntities.Single(x => x.PositionId == 1));
        }
    }
}