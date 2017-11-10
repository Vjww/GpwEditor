using System.Linq;
using GpwEditor.Domain.Objects.BaseGame;
using GpwEditor.Infrastructure.Databases;

namespace GpwEditor.Application.ObjectReaders.BaseGame
{
    public class TeamObjectReader : ObjectReaderBase<ITeamObject>
    {
        public TeamObjectReader(BaseGameDatabase database) : base(database)
        {
        }

        public override ITeamObject Read(ITeamObject @object)
        {
            var teamEntity = Database.TeamRepository.Get(x => x.Id == @object.Id).ToList().Single();
            @object.TeamId = teamEntity.Id + 1;
            @object.Name = teamEntity.Name.All;
            @object.LastPosition = teamEntity.LastPosition;
            @object.LastPoints = teamEntity.LastPoints;
            @object.FirstGpTrack = teamEntity.FirstGpTrack;
            @object.FirstGpYear = teamEntity.FirstGpYear;
            @object.Wins = teamEntity.Wins;
            @object.YearlyBudget = teamEntity.YearlyBudget;
            @object.CountryMapId = teamEntity.CountryMapId;
            @object.LocationPointerX = teamEntity.LocationPointerX;
            @object.LocationPointerY = teamEntity.LocationPointerY;
            @object.TyreSupplierId = teamEntity.TyreSupplierId;

            var chassisHandlingEntity = Database.ChassisHandlingRepository.Get(x => x.TeamId == @object.Id).ToList().Single();
            @object.ChassisHandling = chassisHandlingEntity.Value;

            var carNumberEntities = Database.CarNumberRepository.Get(x => x.TeamId == @object.Id).ToList();
            @object.CarNumberDriver1 = carNumberEntities.Single(x => x.PositionId == 0).ValueA;
            @object.CarNumberDriver2 = carNumberEntities.Single(x => x.PositionId == 1).ValueA;

            return @object;
        }
    }
}