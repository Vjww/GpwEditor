namespace Data.ValueMapping.Executable.Team
{
    public class NonF1ChiefMechanic
    {
        private const int NameIndex = 5795; // "None"

        private const int BaseOffset = 454524;
        private const int LocalOffset = 60;
        private const int AbilityOffset = 10;
        private const int AgeOffset = 50;
        private const int SalaryOffset = 0;
        private const int RaceBonusOffset = 30;
        private const int ChampionshipBonusOffset = 40;

        public int Name { get; set; }
        public int Ability { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int RaceBonus { get; set; }
        public int ChampionshipBonus { get; set; }

        public NonF1ChiefMechanic(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);

            var stepOffset = LocalOffset * id;

            Ability = BaseOffset + stepOffset + AbilityOffset;
            Age = BaseOffset + stepOffset + AgeOffset;
            Salary = BaseOffset + stepOffset + SalaryOffset;
            RaceBonus = BaseOffset + stepOffset + RaceBonusOffset;
            ChampionshipBonus = BaseOffset + stepOffset + ChampionshipBonusOffset;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
            {
                119, 120, 121, 122, 123, 124, 125, 126, 127, 128
            };

            return idToResourceIdMap[id];
        }
    }
}