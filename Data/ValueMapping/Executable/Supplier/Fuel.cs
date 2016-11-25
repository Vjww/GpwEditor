using Data.Entities.Executable.Supplier;

namespace Data.ValueMapping.Executable.Supplier
{
    public class Fuel : IFuel
    {
        // Offset values
        private const int BaseOffset = 2756384;
        private const int LocalOffset = 8;
        private const int PerformanceOffset = 0;
        private const int ToleranceOffset = 4;

        public int Performance { get; set; }
        public int Tolerance { get; set; }

        public Fuel(int id)
        {
            // Calculate step offset from zero based index
            var stepOffset = LocalOffset * id;

            Performance = BaseOffset + stepOffset + PerformanceOffset;
            Tolerance = BaseOffset + stepOffset + ToleranceOffset;
        }
    }
}
