namespace Data.ValueMapping.Executable.Team
{
    public class F1ChiefCommercial
    {
        private const int NameIndex = 5795; // "None"

        private const int BaseOffset = 463060;
        private const int LocalOffset = 260;
        private const int AbilityOffset = 0;
        private const int AgeOffset = 20;
        private const int SalaryOffset = 10;
        private const int RoyaltyOffset = 40;
        private const int MoraleOffset = 30;

        public int Name { get; set; }
        public int Ability { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int Royalty { get; set; }
        public int Morale { get; set; }

        public F1ChiefCommercial(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);

            var stepOffset = LocalOffset * id;

            Ability = BaseOffset + stepOffset + AbilityOffset;
            Age = BaseOffset + stepOffset + AgeOffset;
            Salary = BaseOffset + stepOffset + SalaryOffset;
            Royalty = BaseOffset + stepOffset + RoyaltyOffset;
            Morale = BaseOffset + stepOffset + MoraleOffset;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
            {
                2, 10, 18, 26, 34, 42, 50, 58, 66, 74, 82
            };

            return idToResourceIdMap[id];
        }
    }
}