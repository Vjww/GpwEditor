namespace Data.ValueMapping.Executable.Team
{
    public interface IDriver
    {
        int Name { get; set; }
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
}
