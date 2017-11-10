using System.Linq;
using GpwEditor.Domain.Objects.BaseGame;
using GpwEditor.Infrastructure.Connections;
using GpwEditor.Infrastructure.Databases;
using GpwEditor.Infrastructure.DataSources;

namespace GpwEditor.Application.Models.BaseGame
{
    public class TeamModel : ModelBase<BaseGameDatabase, BaseGameDataContext, BaseGameConnection>, ITeamObject
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int LastPosition { get; set; }
        public int LastPoints { get; set; }
        public int FirstGpTrack { get; set; }
        public int FirstGpYear { get; set; }
        public int Wins { get; set; }
        public int YearlyBudget { get; set; }
        public int CountryMapId { get; set; }
        public int LocationPointerX { get; set; }
        public int LocationPointerY { get; set; }
        public int TyreSupplierId { get; set; }
        public int ChassisHandling { get; set; }
        public int CarNumberDriver1 { get; set; }
        public int CarNumberDriver2 { get; set; }

        public TeamModel(BaseGameDatabase database, int id) : base(database, id)
        {
        }

        public override void Get()
        {
            var teamEntity = Database.TeamRepository.Get(x => x.Id == Id).ToList().Single();
            TeamId = teamEntity.Id + 1;
            Name = teamEntity.Name.All;
            LastPosition = teamEntity.LastPosition;
            LastPoints = teamEntity.LastPoints;
            FirstGpTrack = teamEntity.FirstGpTrack;
            FirstGpYear = teamEntity.FirstGpYear;
            Wins = teamEntity.Wins;
            YearlyBudget = teamEntity.YearlyBudget;
            CountryMapId = teamEntity.CountryMapId;
            LocationPointerX = teamEntity.LocationPointerX;
            LocationPointerY = teamEntity.LocationPointerY;
            TyreSupplierId = teamEntity.TyreSupplierId;

            var chassisHandlingEntity = Database.ChassisHandlingRepository.Get(x => x.TeamId == Id).ToList().Single();
            ChassisHandling = chassisHandlingEntity.Value;

            var carNumberEntities = Database.CarNumberRepository.Get(x => x.TeamId == Id).ToList();
            CarNumberDriver1 = carNumberEntities.Single(x => x.PositionId == 0).ValueA;
            CarNumberDriver2 = carNumberEntities.Single(x => x.PositionId == 1).ValueA;
        }

        public override void Set()
        {
            var teamEntity = Database.TeamRepository.Get(x => x.Id == Id).ToList().Single();
            teamEntity.Name.All = Name;
            teamEntity.LastPosition = LastPosition;
            teamEntity.LastPoints = LastPoints;
            teamEntity.FirstGpTrack = FirstGpTrack;
            teamEntity.FirstGpYear = FirstGpYear;
            teamEntity.Wins = Wins;
            teamEntity.YearlyBudget = YearlyBudget;
            teamEntity.CountryMapId = CountryMapId;
            teamEntity.LocationPointerX = LocationPointerX;
            teamEntity.LocationPointerY = LocationPointerY;
            teamEntity.TyreSupplierId = TyreSupplierId;
            Database.TeamRepository.SetById(teamEntity);

            var chassisHandlingEntity = Database.ChassisHandlingRepository.Get(x => x.TeamId == Id).ToList().Single();
            chassisHandlingEntity.Value = ChassisHandling;
            Database.ChassisHandlingRepository.SetById(chassisHandlingEntity);

            var carNumberEntities = Database.CarNumberRepository.Get(x => x.TeamId == Id).ToList();
            foreach (var item in carNumberEntities)
            {
                item.ValueA = item.PositionId == 0 ? CarNumberDriver1 : CarNumberDriver2;
                item.ValueB = item.PositionId == 0 ? CarNumberDriver1 : CarNumberDriver2;
                Database.CarNumberRepository.SetById(item);
            }
        }
    }
}