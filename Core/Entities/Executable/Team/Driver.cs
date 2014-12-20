
namespace Core.Entities.Executable.Team
{
    public interface IDriver
    {
        int Salary { get; set; }
        int RaceBonus { get; set; }
        int ChampionshipBonus { get; set; }
        int PayRating { get; set; }
        int PositiveSalary { get; set; }
        int LastChampionshipPosition { get; set; }
        int DriverRole { get; set; }
        int CarNumber { get; set; }
        int Age { get; set; }
        int Nationality { get; set; }
        int CareerChampionships { get; set; }
        int CareerRaces { get; set; }
        int CareerWins { get; set; }
        int CareerPoints { get; set; }
        int CareerFastestLaps { get; set; }
        int CareerPointsFinishes { get; set; }
        int CareerPolePositions { get; set; }
        int Speed { get; set; }
        int Skill { get; set; }
        int Overtaking { get; set; }
        int WetWeather { get; set; }
        int Concentration { get; set; }
        int Experience { get; set; }
        int Stamina { get; set; }
        int Morale { get; set; }
    }

    public class Driver : IDriver, IIdentity
    {
        public int Id { get; set; }
        public int LocalResourceId { get; set; }
        public string ResourceId { get; set; }
        public string ResourceText { get; set; }

        public int Salary { get; set; }
        public int RaceBonus { get; set; }
        public int ChampionshipBonus { get; set; }
        public int PayRating { get; set; }
        public int PositiveSalary { get; set; }
        public int LastChampionshipPosition { get; set; }
        public int DriverRole { get; set; }
        public int CarNumber { get; set; }
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
