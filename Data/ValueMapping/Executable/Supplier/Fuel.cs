namespace Data.ValueMapping.Executable.Supplier
{
    public class Fuel : IFuel
    {
        private const int NameIndex = 4894; // "FuelA"

        private const int BaseOffset = 2756384;
        private const int LocalOffset = 8;
        private const int PerformanceOffset = 0;
        private const int ToleranceOffset = 4;

        public int Name { get; set; }
        public int Performance { get; set; }
        public int Tolerance { get; set; }

        public Fuel(int id)
        {
            Name = NameIndex + GetLocalResourceId(id) - 1;

            var stepOffset = LocalOffset * id;

            Performance = BaseOffset + stepOffset + PerformanceOffset;
            Tolerance = BaseOffset + stepOffset + ToleranceOffset;
        }

        public static int GetLocalResourceId(int id)
        {
            var idToResourceIdMap = new[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9
                };

            return idToResourceIdMap[id];
        }
    }
}
