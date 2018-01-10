using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.DataContexts;
using App.BaseGameEditor.Data.Entities;
using TeamEntity = App.BaseGameEditor.Domain.Entities.TeamEntity;

namespace App.BaseGameEditor.Infrastructure.Mappers
{
    public class TeamEntityToDataContextMapper : IEntityToDataContextMapper<TeamEntity>
    {
        private readonly BaseGameDataContext _dataContext;

        public TeamEntityToDataContextMapper(BaseGameDataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public void Map(TeamEntity entity)
        {
            var teamEntity = (Data.Entities.TeamEntity)_dataContext.Teams.Get(x => x.Id == entity.Id).Single();
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
            _dataContext.Teams.SetById(teamEntity);

            // TODO: An exception throws here on export.
            var chassisHandlingEntities = (IEnumerable<ChassisHandlingEntity>)_dataContext.ChassisHandlings.Get();
            var chassisHandlingEntity = chassisHandlingEntities.Single(x => x.TeamId == entity.Id);
            chassisHandlingEntity.Value = entity.ChassisHandling;
            _dataContext.ChassisHandlings.SetById(chassisHandlingEntity);

            var carNumberEntities = ((IEnumerable<CarNumberEntity>)_dataContext.CarNumbers.Get()).Where(x => x.TeamId == entity.Id).ToList();
            foreach (var item in carNumberEntities)
            {
                item.ValueA = item.PositionId == 0 ? entity.CarNumberDriver1 : entity.CarNumberDriver2;
                item.ValueB = item.PositionId == 0 ? entity.CarNumberDriver1 : entity.CarNumberDriver2;
                _dataContext.CarNumbers.SetById(item);
            }
        }
    }
}