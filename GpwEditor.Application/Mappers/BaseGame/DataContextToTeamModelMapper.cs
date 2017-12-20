using System;
using System.Linq;
using Common.Editor.Data.Repositories;
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

            var teamRepository = (IRepository<TeamEntity>)_dataContext.Teams;
            var teamEntity = teamRepository.Get(x => x.Id == id).Single();
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

            var chassisHandlingRepository = (IRepository<ChassisHandlingEntity>)_dataContext.ChassisHandlings;
            var chassisHandlingEntity = chassisHandlingRepository.Get(x => x.TeamId == id).Single();
            result.ChassisHandling = chassisHandlingEntity.Value;

            var carNumberRepository = (IRepository<CarNumberEntity>)_dataContext.CarNumbers;
            var carNumberEntities = carNumberRepository.Get(x => x.TeamId == id).ToList();
            result.CarNumberDriver1 = carNumberEntities.Single(x => x.PositionId == 0).ValueA;
            result.CarNumberDriver2 = carNumberEntities.Single(x => x.PositionId == 1).ValueA;

            return result;
        }
    }
}