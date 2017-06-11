namespace Data.ValueMapping.Executable.Team
{
    public class NonF1ChiefCommercial
    {
        private const int NameIndex = 5795; // "None"

        private const int BaseOffset = 452724;
        private const int LocalOffset = 60;
        private const int AbilityOffset = 10;
        private const int AgeOffset = 50;
        private const int SalaryOffset = 0;
        private const int RoyaltyOffset = 20;

        public int Name { get; set; }
        public int Ability { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int Royalty { get; set; }

        public NonF1ChiefCommercial(int id)
        {
            Name = NameIndex + GetLocalResourceId(id);

            var stepOffset = LocalOffset * id;

            Ability = BaseOffset + stepOffset + AbilityOffset;
            Age = BaseOffset + stepOffset + AgeOffset;
            Salary = BaseOffset + stepOffset + SalaryOffset;
            Royalty = BaseOffset + stepOffset + RoyaltyOffset;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
            {
                89, 90, 91, 92, 93, 94, 95, 96, 97, 98
            };

            return idToResourceIdMap[id];
        }
    }
}