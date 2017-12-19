using System;
using System.Linq;
using GpwEditor.Domain.Models.BaseGame;
using GpwEditor.Infrastructure.DataContexts;

namespace GpwEditor.Application.Mappers.BaseGame
{
    public class TeamModelToDataContextMapper : IModelToDataContextMapper<ITeamModel>
    {
        private readonly BaseGameDataContext _dataContext;

        public TeamModelToDataContextMapper(BaseGameDataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public void Map(ITeamModel model)
        {
            var teamEntity = _dataContext.Teams.Get(x => x.Id == model.Id).Single();
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

            var chassisHandlingEntity = _dataContext.ChassisHandlings.Get(x => x.TeamId == model.Id).Single();
            chassisHandlingEntity.Value = model.ChassisHandling;
            _dataContext.ChassisHandlings.SetById(chassisHandlingEntity);

            var carNumberEntities = _dataContext.CarNumbers.Get(x => x.TeamId == model.Id).ToList();
            foreach (var item in carNumberEntities)
            {
                item.ValueA = item.PositionId == 0 ? model.CarNumberDriver1 : model.CarNumberDriver2;
                item.ValueB = item.PositionId == 0 ? model.CarNumberDriver1 : model.CarNumberDriver2;
                _dataContext.CarNumbers.SetById(item);
            }
        }
    }
}