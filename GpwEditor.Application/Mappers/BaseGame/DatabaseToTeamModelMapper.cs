using System.Linq;
using GpwEditor.Application.Models.BaseGame;
using GpwEditor.Infrastructure.Databases;

namespace GpwEditor.Application.Mappers.BaseGame
{
    public class DatabaseToTeamModelMapper : IThingy<TeamModel>
    {
        private readonly BaseGameDatabase _database;
        private readonly int _id;

        public DatabaseToTeamModelMapper(BaseGameDatabase database, int id)
        {
            _database = database;
            _id = id;
        }

        public TeamModel Map()
        {
            var result = new TeamModel(_database, 0);

            var teamEntity = _database.TeamRepository.Get(x => x.Id == _id).ToList().Single();
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

            var chassisHandlingEntity = _database.ChassisHandlingRepository.Get(x => x.TeamId == _id).ToList().Single();
            result.ChassisHandling = chassisHandlingEntity.Value;

            var carNumberEntities = _database.CarNumberRepository.Get(x => x.TeamId == _id).ToList();
            result.CarNumberDriver1 = carNumberEntities.Single(x => x.PositionId == 0).ValueA;
            result.CarNumberDriver2 = carNumberEntities.Single(x => x.PositionId == 1).ValueA;

            return result;
        }
    }
}