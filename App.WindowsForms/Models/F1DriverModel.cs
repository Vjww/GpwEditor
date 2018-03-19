using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class F1DriverModel : IntegerIdentityBase, IEntity
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int RaceBonus { get; set; }
        public int ChampionshipBonus { get; set; }
        public int LastChampionshipPosition { get; set; }
        public int Role { get; set; }
        public int Age { get; set; }
        public int Nationality { get; set; }

        public int CareerChampionships { get; set; }
        public int CareerRaces { get; set; }
        public int CareerWins { get; set; }
        public int CareerPoints { get; set; }
        public int CareerFastestLaps { get; set; }
        public int CareerPointsFinishes { get; set; }
        public int CareerPolePositions { get; set; }

        public int Speed { get; set; }
        public int Skill { get; set; }
        public int Overtaking { get; set; }
        public int WetWeather { get; set; }
        public int Concentration { get; set; }
        public int Experience { get; set; }
        public int Stamina { get; set; }
        public int Morale { get; set; }
    }
}