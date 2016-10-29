using Data.Entities.Executable.Supplier;

namespace Data.ValueMapping.Executable.Supplier
{
    public class Fuel : IFuel
    {
        // Offset values
        private const int BaseOffset = 0; // TODO
        private const int LocalOffset = 0; // TODO
        private const int ExampleOffset = 0; // TODO

        public int Performance { get; set; }
        public int Tolerance { get; set; }

        public Fuel(int id)
        {
            // Calculate step offset from zero based index
            var stepOffset = LocalOffset * id;

            //Example = BaseOffset + stepOffset + ExampleOffset; // TODO
        }
    }
}
