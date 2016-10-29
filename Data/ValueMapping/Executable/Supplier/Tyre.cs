using Data.Entities.Executable.Supplier;

namespace Data.ValueMapping.Executable.Supplier
{
    public class Tyre : ITyre
    {
        // Offset values
        private const int BaseOffset = 0; // TODO
        private const int LocalOffset = 0; // TODO
        private const int ExampleOffset = 0; // TODO

        public int DryHardGrip { get; set; }
        public int DryHardResilience { get; set; }
        public int DryHardStiffness { get; set; }
        public int DryHardTemperature { get; set; }
        public int DrySoftGrip { get; set; }
        public int DrySoftResilience { get; set; }
        public int DrySoftStiffness { get; set; }
        public int DrySoftTemperature { get; set; }
        public int IntermediateGrip { get; set; }
        public int IntermediateResilience { get; set; }
        public int IntermediateStiffness { get; set; }
        public int IntermediateTemperature { get; set; }
        public int WetWeatherGrip { get; set; }
        public int WetWeatherResilience { get; set; }
        public int WetWeatherStiffness { get; set; }
        public int WetWeatherTemperature { get; set; }

        public Tyre(int id)
        {
            // Calculate step offset from zero based index
            var stepOffset = LocalOffset * id;

            //Example = BaseOffset + stepOffset + ExampleOffset; // TODO
        }
    }
}
