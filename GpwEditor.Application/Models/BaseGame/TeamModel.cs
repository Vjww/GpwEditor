using System.Linq;
using GpwEditor.Domain.Objects.BaseGame;
using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.Databases;
using GpwEditor.Infrastructure.DataSources;

namespace GpwEditor.Application.Models.BaseGame
{
    public class TeamModel : ModelBase<BaseGameDatabase, BaseGameDataSource, BaseGameConnectionStrings>, ITeamObject
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int CarNumberDriver1 { get; set; }
        public int CarNumberDriver2 { get; set; }
        public int ChassisHandling { get; set; }

        public TeamModel(BaseGameDatabase database, int id) : base(database, id)
        {
        }

        public override void Get()
        {
            var teamEntity = Database.TeamRepository.Get(x => x.Id == Id).ToList().Single();
            TeamId = teamEntity.Id + 1;
            Name = teamEntity.Name;

            var carNumberEntities = Database.CarNumberRepository.Get(x => x.TeamId == Id).ToList();
            CarNumberDriver1 = carNumberEntities.Single(x => x.PositionId == 0).ValueA;
            CarNumberDriver2 = carNumberEntities.Single(x => x.PositionId == 1).ValueA;

            var chassisHandlingEntity = Database.ChassisHandlingRepository.Get(x => x.TeamId == Id).ToList().Single();
            ChassisHandling = chassisHandlingEntity.Value;
        }

        public override void Set()
        {
            var teamEntity = Database.TeamRepository.Get(x => x.Id == Id).ToList().Single();
            teamEntity.Name = Name;
            Database.TeamRepository.SetById(teamEntity);

            var carNumberEntities = Database.CarNumberRepository.Get(x => x.TeamId == Id).ToList();
            foreach (var item in carNumberEntities)
            {
                item.ValueA = item.PositionId == 0 ? CarNumberDriver1 : CarNumberDriver2;
                item.ValueB = item.PositionId == 0 ? CarNumberDriver1 : CarNumberDriver2;
                Database.CarNumberRepository.SetById(item);
            }

            var chassisHandlingEntity = Database.ChassisHandlingRepository.Get(x => x.TeamId == Id).ToList().Single();
            chassisHandlingEntity.Value = ChassisHandling;
            Database.ChassisHandlingRepository.SetById(chassisHandlingEntity);
        }
    }
}