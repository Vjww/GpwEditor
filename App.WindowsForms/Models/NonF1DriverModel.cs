using App.Core.Entities;
using App.Core.Identities;

namespace App.WindowsForms.Models
{
    public class NonF1DriverModel : IntegerIdentityBase, IEntity
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public int RaceBonus { get; set; }
        public int ChampionshipBonus { get; set; }
        public int Age { get; set; }
        public int Nationality { get; set; }
        public int UnknownA { get; set; }

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