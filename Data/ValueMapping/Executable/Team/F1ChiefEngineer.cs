namespace Data.ValueMapping.Executable.Team
{
    public class F1ChiefEngineer
    {
        private const int NameIndex = 5795; // "None"

        private const int BaseOffset = 463180;
        private const int LocalOffset = 260;
        private const int AbilityOffset = 0;
        private const int AgeOffset = 20;
        private const int SalaryOffset = 10;
        private const int RaceBonusOffset = 30;
        private const int ChampionshipBonusOffset = 40;
        private const int DriverLoyaltyOffset = 60;
        private const int MoraleOffset = 50;

        public int Name { get; set; }
        public int Ability { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int RaceBonus { get; set; }
        public int ChampionshipBonus { get; set; }
        public int DriverLoyalty { get; set; }
        public int Morale { get; set; }

        public F1ChiefEngineer(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);

            var stepOffset = LocalOffset * id;

            Ability = BaseOffset + stepOffset + AbilityOffset;
            Age = BaseOffset + stepOffset + AgeOffset;
            Salary = BaseOffset + stepOffset + SalaryOffset;
            RaceBonus = BaseOffset + stepOffset + RaceBonusOffset;
            ChampionshipBonus = BaseOffset + stepOffset + ChampionshipBonusOffset;
            DriverLoyalty = BaseOffset + stepOffset + DriverLoyaltyOffset;
            Morale = BaseOffset + stepOffset + MoraleOffset;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
            {
                4, 12, 20, 28, 36, 44, 52, 60, 68, 76, 84
            };

            return idToResourceIdMap[id];
        }
    }
}