using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Data.Services;
using TeamEntity = App.BaseGameEditor.Domain.Entities.TeamEntity;

namespace App.BaseGameEditor.Infrastructure.Mappers
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
            var teamEntity = (Data.Entities.TeamEntity)_dataService.Teams.Get(x => x.Id == entity.Id).Single();
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

            // TODO: An exception throws here on export.
            var chassisHandlingEntities = (IEnumerable<ChassisHandlingEntity>)_dataService.ChassisHandlings.Get();
            var chassisHandlingEntity = chassisHandlingEntities.Single(x => x.TeamId == entity.Id);
            chassisHandlingEntity.Value = entity.ChassisHandling;
            _dataService.ChassisHandlings.SetById(chassisHandlingEntity);

            var carNumberEntities = ((IEnumerable<CarNumberEntity>)_dataService.CarNumbers.Get()).Where(x => x.TeamId == entity.Id).ToList();
            foreach (var item in carNumberEntities)
            {
                item.ValueA = item.PositionId == 0 ? entity.CarNumberDriver1 : entity.CarNumberDriver2;
                item.ValueB = item.PositionId == 0 ? entity.CarNumberDriver1 : entity.CarNumberDriver2;
                _dataService.CarNumbers.SetById(item);
            }
        }
    }
}