namespace Data.ValueMapping.Executable.Team
{
    public class NonF1Driver
    {
        private const int NameIndex = 5795; // "None"

        private const int BaseOffset = 451280;
        private const int LocalOffset = 140;
        private const int SalaryOffset = 20;
        private const int RaceBonusOffset = 30;
        private const int ChampionshipBonusOffset = 40;
        private const int AgeOffset = 130;
        private const int NationalityOffset = 0;
        private const int UnknownOffset = 10;
        private const int SpeedOffset = 50;
        private const int SkillOffset = 60;
        private const int OvertakingOffset = 70;
        private const int WetWeatherOffset = 80;
        private const int ConcentrationOffset = 90;
        private const int ExperienceOffset = 100;
        private const int StaminaOffset = 110;
        private const int MoraleOffset = 120;

        public int Name { get; set; }
        public int Salary { get; set; }
        public int RaceBonus { get; set; }
        public int ChampionshipBonus { get; set; }
        public int Age { get; set; }
        public int Nationality { get; set; }
        public int Unknown { get; set; }
        public int Speed { get; set; }
        public int Skill { get; set; }
        public int Overtaking { get; set; }
        public int WetWeather { get; set; }
        public int Concentration { get; set; }
        public int Experience { get; set; }
        public int Stamina { get; set; }
        public int Morale { get; set; }

        public NonF1Driver(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);

            var stepOffset = LocalOffset * id;

            if (id < 8) // each attribute is 10 bytes long
            {
                Salary = BaseOffset + stepOffset + SalaryOffset;
                RaceBonus = BaseOffset + stepOffset + RaceBonusOffset;
                ChampionshipBonus = BaseOffset + stepOffset + ChampionshipBonusOffset;
                Age = BaseOffset + stepOffset + AgeOffset;
                Nationality = BaseOffset + stepOffset + NationalityOffset;
                Unknown = BaseOffset + stepOffset + UnknownOffset;
                Speed = BaseOffset + stepOffset + SpeedOffset;
                Skill = BaseOffset + stepOffset + SkillOffset;
                Overtaking = BaseOffset + stepOffset + OvertakingOffset;
                WetWeather = BaseOffset + stepOffset + WetWeatherOffset;
                Concentration = BaseOffset + stepOffset + ConcentrationOffset;
                Experience = BaseOffset + stepOffset + ExperienceOffset;
                Stamina = BaseOffset + stepOffset + StaminaOffset;
                Morale = BaseOffset + stepOffset + MoraleOffset;
            }
            else if (id == 8) // some attributes become 7 bytes long
            {
                Salary = BaseOffset + stepOffset + SalaryOffset;
                RaceBonus = BaseOffset + stepOffset + RaceBonusOffset;
                ChampionshipBonus = BaseOffset + stepOffset + ChampionshipBonusOffset;
                Age = BaseOffset + stepOffset + AgeOffset - 12;
                Nationality = BaseOffset + stepOffset + NationalityOffset;
                Unknown = BaseOffset + stepOffset + UnknownOffset;
                Speed = BaseOffset + stepOffset + SpeedOffset;
                Skill = BaseOffset + stepOffset + SkillOffset;
                Overtaking = BaseOffset + stepOffset + OvertakingOffset;
                WetWeather = BaseOffset + stepOffset + WetWeatherOffset;
                Concentration = BaseOffset + stepOffset + ConcentrationOffset;
                Experience = BaseOffset + stepOffset + ExperienceOffset - 3;
                Stamina = BaseOffset + stepOffset + StaminaOffset - 6;
                Morale = BaseOffset + stepOffset + MoraleOffset - 9;
            }
            else // each attribute is 7 bytes long
            {
                stepOffset = LocalOffset * 9 - 15 + LocalOffset / 10 * 7 * (id % 9);
                Salary = BaseOffset + stepOffset + SalaryOffset / 10 * 7;
                RaceBonus = BaseOffset + stepOffset + RaceBonusOffset / 10 * 7;
                ChampionshipBonus = BaseOffset + stepOffset + ChampionshipBonusOffset / 10 * 7;
                Age = BaseOffset + stepOffset + AgeOffset / 10 * 7;
                Nationality = BaseOffset + stepOffset + NationalityOffset / 10 * 7;
                Unknown = BaseOffset + stepOffset + UnknownOffset / 10 * 7;
                Speed = BaseOffset + stepOffset + SpeedOffset / 10 * 7;
                Skill = BaseOffset + stepOffset + SkillOffset / 10 * 7;
                Overtaking = BaseOffset + stepOffset + OvertakingOffset / 10 * 7;
                WetWeather = BaseOffset + stepOffset + WetWeatherOffset / 10 * 7;
                Concentration = BaseOffset + stepOffset + ConcentrationOffset / 10 * 7;
                Experience = BaseOffset + stepOffset + ExperienceOffset / 10 * 7;
                Stamina = BaseOffset + stepOffset + StaminaOffset / 10 * 7;
                Morale = BaseOffset + stepOffset + MoraleOffset / 10 * 7;
            }
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
            {
                129, 130, 131, 132, 133, 134, 135, 136, 137, 138, 139
            };

            return idToResourceIdMap[id];
        }
    }
}