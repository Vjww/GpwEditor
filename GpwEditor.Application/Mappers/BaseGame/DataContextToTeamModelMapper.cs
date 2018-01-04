using System;
using System.Linq;
using GpwEditor.Application.Factories;
using GpwEditor.Domain.Models.BaseGame;
using GpwEditor.Infrastructure.DataContexts;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Application.Mappers.BaseGame
{
    public class DataContextToTeamModelMapper : IDataContextToModelMapper<ITeamModel>
    {
        private readonly BaseGameDataContext _dataContext;
        private readonly IModelFactory<ITeamModel> _factory;

        public DataContextToTeamModelMapper(
            BaseGameDataContext dataContext,
            IModelFactory<ITeamModel> factory)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public ITeamModel Map(int id)
        {
            var result = _factory.Create(id);

            var teamEntity = (TeamEntity)_dataContext.Teams.Get(x => x.Id == id).Single();
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

            foreach (var item in _dataContext.ChassisHandlings.Get())
            {
                if (!(item is ChassisHandlingEntity entity) || entity.TeamId != id) continue;
                result.ChassisHandling = entity.Value;
                break;
            }

            foreach (var item in _dataContext.CarNumbers.Get())
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