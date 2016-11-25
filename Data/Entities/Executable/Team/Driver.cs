using System.ComponentModel.DataAnnotations;
using Data.Entities.Language;

namespace Data.Entities.Executable.Team
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
        [Display(Name = "Driver Name", Description = "The name of the driver, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Salary", Description = "The driver's Salary amount. Pay drivers will have a negative Salary amount (e.g. -3500000).")]
        public int Salary { get; set; }
        [Display(Name = "Race Bonus", Description = "The driver's Race Bonus amount.")]
        public int RaceBonus { get; set; }
        [Display(Name = "Championship Bonus", Description = "The driver's Championship Bonus amount.")]
        public int ChampionshipBonus { get; set; }
        [Display(Name = "Pay Driver Rating", Description = "The Rating of the funding amount the pay driver brings.")]
        public int PayRating { get; set; }
        [Display(Name = "Pay Driver Salary", Description = "The inverse (positive) value of the driver's Salary amount (for pay drivers only, e.g. 3500000).")]
        public int PositiveSalary { get; set; }
        [Display(Name = "Last Year's Championship Position", Description = "Unknown usage. May be intended to be used as an informational value.")]
        public int LastChampionshipPosition { get; set; }
        [Display(Name = "Driver Role", Description = "The Role of the driver in the team, as agreed in the driver's contract.")]
        public int DriverRole { get; set; }
        [Display(Name = "Car Number", Description = "The driver's Car Number for the season.")]
        public int CarNumber { get; set; }
        [Display(Name = "Age", Description = "The driver's Age at the start of the year.")]
        public int Age { get; set; }
        [Display(Name = "Nationality", Description = "The driver's Nationality.")]
        public int Nationality { get; set; }

        [Display(Name = "Championships", Description = "The number of Championships a driver has won during their career.")]
        public int CareerChampionships { get; set; }
        [Display(Name = "Races", Description = "The number of Races a driver has entered/started during their career.")]
        public int CareerRaces { get; set; }
        [Display(Name = "Wins", Description = "The number of race Wins a driver has achieved during their career.")]
        public int CareerWins { get; set; }
        [Display(Name = "Points", Description = "The number of Points a driver has scored during their career.")]
        public int CareerPoints { get; set; }
        [Display(Name = "Fastest Laps", Description = "The number of Fastest Laps a driver has achieved during their career.")]
        public int CareerFastestLaps { get; set; }
        [Display(Name = "Points Finishes", Description = "The number of Points Finishes a driver has achieved during their career.")]
        public int CareerPointsFinishes { get; set; }
        [Display(Name = "Pole Positions", Description = "The number of Pole Positions a driver has achieved during their career.")]
        public int CareerPolePositions { get; set; }

        [Display(Name = "Speed", Description = "The driver's Speed attribute rating.")]
        public int Speed { get; set; }
        [Display(Name = "Skill", Description = "The driver's Skill attribute rating.")]
        public int Skill { get; set; }
        [Display(Name = "Overtaking", Description = "The driver's Overtaking attribute rating.")]
        public int Overtaking { get; set; }
        [Display(Name = "Wet Weather", Description = "The driver's Wet Weather attribute rating.")]
        public int WetWeather { get; set; }
        [Display(Name = "Concentration", Description = "The driver's Concentration attribute rating.")]
        public int Concentration { get; set; }
        [Display(Name = "Experience", Description = "The driver's Experience attribute rating.")]
        public int Experience { get; set; }
        [Display(Name = "Stamina", Description = "The driver's Stamina attribute rating.")]
        public int Stamina { get; set; }
        [Display(Name = "Morale", Description = "The driver's Morale attribute rating.")]
        public int Morale { get; set; }
    }
}
