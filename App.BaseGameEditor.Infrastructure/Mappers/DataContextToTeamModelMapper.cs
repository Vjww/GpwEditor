using System;
using System.Linq;
using App.BaseGameEditor.Data.DataContexts;
using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Factories;
using TeamEntity = App.BaseGameEditor.Domain.Entities.TeamEntity;

namespace App.BaseGameEditor.Infrastructure.Mappers
{
    // TODO: Rename from model to entity
    public class DataContextToTeamModelMapper : IDataContextToModelMapper<TeamEntity>
    {
        private readonly BaseGameDataContext _dataContext;
        private readonly IModelFactory<TeamEntity> _factory;

        public DataContextToTeamModelMapper(
            BaseGameDataContext dataContext,
            IModelFactory<TeamEntity> factory)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public TeamEntity Map(int id)
        {
            var result = _factory.Create(id);

            var teamEntity = (Data.Entities.TeamEntity)_dataContext.Teams.Get(x => x.Id == id).Single();
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