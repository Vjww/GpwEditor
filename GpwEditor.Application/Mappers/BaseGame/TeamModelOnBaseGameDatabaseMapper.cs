using System.Linq;
using GpwEditor.Application.Models.BaseGame;
using GpwEditor.Infrastructure.Databases;

namespace GpwEditor.Application.Mappers.BaseGame
{
    public class TeamModelOnBaseGameDatabaseMapper : IModelOnDatabaseMapper<TeamModel, BaseGameDatabase>
    {
        public void Map(BaseGameDatabase from, TeamModel to)
        {
            var teamEntity = from.TeamRepository.Get(x => x.Id == to.Id).ToList().Single();
            to.TeamId = teamEntity.Id + 1;
            to.Name = teamEntity.Name.All;
            to.LastPosition = teamEntity.LastPosition;
            to.LastPoints = teamEntity.LastPoints;
            to.FirstGpTrack = teamEntity.FirstGpTrack;
            to.FirstGpYear = teamEntity.FirstGpYear;
            to.Wins = teamEntity.Wins;
            to.YearlyBudget = teamEntity.YearlyBudget;
            to.CountryMapId = teamEntity.CountryMapId;
            to.LocationPointerX = teamEntity.LocationPointerX;
            to.LocationPointerY = teamEntity.LocationPointerY;
            to.TyreSupplierId = teamEntity.TyreSupplierId;

            var chassisHandlingEntity = from.ChassisHandlingRepository.Get(x => x.TeamId == to.Id).ToList().Single();
            to.ChassisHandling = chassisHandlingEntity.Value;

            var carNumberEntities = from.CarNumberRepository.Get(x => x.TeamId == to.Id).ToList();
            to.CarNumberDriver1 = carNumberEntities.Single(x => x.PositionId == 0).ValueA;
            to.CarNumberDriver2 = carNumberEntities.Single(x => x.PositionId == 1).ValueA;
        }

        public void Map(TeamModel from, BaseGameDatabase to)
        {
            var teamEntity = to.TeamRepository.Get(x => x.Id == from.Id).ToList().Single();
            teamEntity.Name.All = from.Name;
            teamEntity.LastPosition = from.LastPosition;
            teamEntity.LastPoints = from.LastPoints;
            teamEntity.FirstGpTrack = from.FirstGpTrack;
            teamEntity.FirstGpYear = from.FirstGpYear;
            teamEntity.Wins = from.Wins;
            teamEntity.YearlyBudget = from.YearlyBudget;
            teamEntity.CountryMapId = from.CountryMapId;
            teamEntity.LocationPointerX = from.LocationPointerX;
            teamEntity.LocationPointerY = from.LocationPointerY;
            teamEntity.TyreSupplierId = from.TyreSupplierId;
            to.TeamRepository.SetById(teamEntity);

            var chassisHandlingEntity = to.ChassisHandlingRepository.Get(x => x.TeamId == from.Id).ToList().Single();
            chassisHandlingEntity.Value = from.ChassisHandling;
            to.ChassisHandlingRepository.SetById(chassisHandlingEntity);

            var carNumberEntities = to.CarNumberRepository.Get(x => x.TeamId == from.Id).ToList();
            foreach (var item in carNumberEntities)
            {
                item.ValueA = item.PositionId == 0 ? from.CarNumberDriver1 : from.CarNumberDriver2;
                item.ValueB = item.PositionId == 0 ? from.CarNumberDriver1 : from.CarNumberDriver2;
                to.CarNumberRepository.SetById(item);
            }
        }
    }
}