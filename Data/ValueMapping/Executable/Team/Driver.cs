namespace Data.ValueMapping.Executable.Team
{
    public class Driver : IDriver
    {
        private const int NameIndex = 5795; // "None"

        private const int BaseOffset = 464687;
        private const int LocalOffset = 260;
        private const int SalaryOffset = 0;
        private const int RaceBonusOffset = 10;
        private const int ChampionshipBonusOffset = 20;
        private const int PayRatingOffset = 90;
        private const int PositiveSalaryOffset = 100;
        private const int LastChampionshipPositionOffset = 70;
        private const int DriverRoleOffset = 60;
        private const int CarNumberOffset = 240;
        private const int AgeOffset = 80;
        private const int NationalityOffset = 30;
        private const int CareerChampionshipsOffset = 40;
        private const int CareerRacesOffset = 110;
        private const int CareerWinsOffset = 120;
        private const int CareerPointsOffset = 230;
        private const int CareerFastestLapsOffset = 140;
        private const int CareerPointsFinishesOffset = 50;
        private const int CareerPolePositionsOffset = 130;
        private const int SpeedOffset = 150;
        private const int SkillOffset = 160;
        private const int OvertakingOffset = 170;
        private const int WetWeatherOffset = 180;
        private const int ConcentrationOffset = 190;
        private const int ExperienceOffset = 200;
        private const int StaminaOffset = 210;
        private const int MoraleOffset = 220;

        public int Name { get; set; }
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

        public Driver(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);

            var stepOffset = LocalOffset * id;

            Salary = BaseOffset + stepOffset + SalaryOffset;
            RaceBonus = BaseOffset + stepOffset + RaceBonusOffset;
            ChampionshipBonus = BaseOffset + stepOffset + ChampionshipBonusOffset;
            PayRating = BaseOffset + stepOffset + PayRatingOffset;
            PositiveSalary = BaseOffset + stepOffset + PositiveSalaryOffset;
            LastChampionshipPosition = BaseOffset + stepOffset + LastChampionshipPositionOffset;
            DriverRole = BaseOffset + stepOffset + DriverRoleOffset;
            CarNumber = BaseOffset + stepOffset + CarNumberOffset;
            Age = BaseOffset + stepOffset + AgeOffset;
            Nationality = BaseOffset + stepOffset + NationalityOffset;
            CareerChampionships = BaseOffset + stepOffset + CareerChampionshipsOffset;
            CareerRaces = BaseOffset + stepOffset + CareerRacesOffset;
            CareerWins = BaseOffset + stepOffset + CareerWinsOffset;
            CareerPoints = BaseOffset + stepOffset + CareerPointsOffset;
            CareerFastestLaps = BaseOffset + stepOffset + CareerFastestLapsOffset;
            CareerPointsFinishes = BaseOffset + stepOffset + CareerPointsFinishesOffset;
            CareerPolePositions = BaseOffset + stepOffset + CareerPolePositionsOffset;
            Speed = BaseOffset + stepOffset + SpeedOffset;
            Skill = BaseOffset + stepOffset + SkillOffset;
            Overtaking = BaseOffset + stepOffset + OvertakingOffset;
            WetWeather = BaseOffset + stepOffset + WetWeatherOffset;
            Concentration = BaseOffset + stepOffset + ConcentrationOffset;
            Experience = BaseOffset + stepOffset + ExperienceOffset;
            Stamina = BaseOffset + stepOffset + StaminaOffset;
            Morale = BaseOffset + stepOffset + MoraleOffset;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
            {
                6, 7, 8, 14, 15, 16, 22, 23, 24, 30, 31, 32, 38, 39, 40, 46, 47, 48, 54, 55, 56, 62, 63, 64, 70, 71, 72,
                78, 79, 80, 86, 87, 88, 129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139, 200, 201, 202, 203
            };

            return idToResourceIdMap[id];
        }
    }
}
