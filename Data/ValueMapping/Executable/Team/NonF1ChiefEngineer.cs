namespace Data.ValueMapping.Executable.Team
{
    public class NonF1ChiefEngineer
    {
        private const int NameIndex = 5795; // "None"

        private const int BaseOffset = 453924;
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

        public NonF1ChiefEngineer(int id)
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
                109, 110, 111, 112, 113, 114, 115, 116, 117, 118
            };

            return idToResourceIdMap[id];
        }
    }
}