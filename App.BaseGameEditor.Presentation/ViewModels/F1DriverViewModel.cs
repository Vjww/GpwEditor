namespace App.BaseGameEditor.Presentation.ViewModels
{
    public class F1DriverViewModel
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int RaceBonus { get; set; }
        public int ChampionshipBonus { get; set; }
        public int PayRating { get; set; }
        public int PositiveSalary { get; set; }
        public int LastChampionshipPosition { get; set; }
        public int DriverRole { get; set; }
        public int Age { get; set; }
        public int Nationality { get; set; }
        public int CommentaryIndex { get; set; } // TODO: Should this be moved to own entity?

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