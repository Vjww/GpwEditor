namespace Data.ValueMapping.Executable.Team
{
    public class NonF1Chief : INonF1Chief
    {
        private const int NameIndex = 5795; // "None"

        private const int BaseOffset = 452724;
        private const int LocalOffset = 60;
        private const int SalaryOffset = 0;
        private const int RaceBonusOffset = 30;
        private const int ChampionshipBonusOffset = 40;
        private const int RoyaltyOffset = 20;
        private const int AgeOffset = 50;
        private const int AbilityOffset = 10;

        public int Name { get; set; }
        public int Salary { get; set; }
        public int RaceBonus { get; set; }
        public int ChampionshipBonus { get; set; }
        public int Royalty { get; set; }
        public int Age { get; set; }
        public int Ability { get; set; }

        public NonF1Chief(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);

            var stepOffset = LocalOffset * id;

            Salary = BaseOffset + stepOffset + SalaryOffset;
            RaceBonus = BaseOffset + stepOffset + RaceBonusOffset;
            ChampionshipBonus = BaseOffset + stepOffset + ChampionshipBonusOffset;
            Royalty = BaseOffset + stepOffset + RoyaltyOffset;
            Age = BaseOffset + stepOffset + AgeOffset;
            Ability = BaseOffset + stepOffset + AbilityOffset;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
            {
                89, 90, 91, 92, 93, 94, 95, 96, 97, 98,
                99, 100, 101, 102, 103, 104, 105, 106, 107, 108,
                109, 110, 111, 112, 113, 114, 115, 116, 117, 118,
                119, 120, 121, 122, 123, 124, 125, 126, 127, 128
            };

            return idToResourceIdMap[id];
        }
    }
}
