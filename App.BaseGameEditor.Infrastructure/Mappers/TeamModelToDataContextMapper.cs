using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Models;
using GpwEditor.Infrastructure.DataContexts;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace App.BaseGameEditor.Infrastructure.Mappers
{
    public class TeamModelToDataContextMapper : IModelToDataContextMapper<TeamModel>
    {
        private readonly BaseGameDataContext _dataContext;

        public TeamModelToDataContextMapper(BaseGameDataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public void Map(TeamModel model)
        {
            var teamEntity = (TeamEntity)_dataContext.Teams.Get(x => x.Id == model.Id).Single();
            teamEntity.Name.All = model.Name;
            teamEntity.LastPosition = model.LastPosition;
            teamEntity.LastPoints = model.LastPoints;
            teamEntity.FirstGpTrack = model.FirstGpTrack;
            teamEntity.FirstGpYear = model.FirstGpYear;
            teamEntity.Wins = model.Wins;
            teamEntity.YearlyBudget = model.YearlyBudget;
            teamEntity.CountryMapId = model.CountryMapId;
            teamEntity.LocationPointerX = model.LocationPointerX;
            teamEntity.LocationPointerY = model.LocationPointerY;
            teamEntity.TyreSupplierId = model.TyreSupplierId;
            _dataContext.Teams.SetById(teamEntity);

            var chassisHandlingEntities = (IEnumerable<ChassisHandlingEntity>)_dataContext.ChassisHandlings.Get();
            var chassisHandlingEntity = chassisHandlingEntities.Single(x => x.TeamId == model.Id);
            chassisHandlingEntity.Value = model.ChassisHandling;
            _dataContext.ChassisHandlings.SetById(chassisHandlingEntity);

            var carNumberEntities = ((IEnumerable<CarNumberEntity>)_dataContext.CarNumbers.Get()).Where(x => x.TeamId == model.Id).ToList();
            foreach (var item in carNumberEntities)
            {
                item.ValueA = item.PositionId == 0 ? model.CarNumberDriver1 : model.CarNumberDriver2;
                item.ValueB = item.PositionId == 0 ? model.CarNumberDriver1 : model.CarNumberDriver2;
                _dataContext.CarNumbers.SetById(item);
            }
        }
    }
}