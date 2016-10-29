using Data.Entities.Language;

namespace Data.Entities.Executable.Supplier
{
    public interface ITyre
    {
        int DryHardGrip { get; set; }
        int DryHardResilience { get; set; }
        int DryHardStiffness { get; set; }
        int DryHardTemperature { get; set; }
        int DrySoftGrip { get; set; }
        int DrySoftResilience { get; set; }
        int DrySoftStiffness { get; set; }
        int DrySoftTemperature { get; set; }
        int IntermediateGrip { get; set; }
        int IntermediateResilience { get; set; }
        int IntermediateStiffness { get; set; }
        int IntermediateTemperature { get; set; }
        int WetWeatherGrip { get; set; }
        int WetWeatherResilience { get; set; }
        int WetWeatherStiffness { get; set; }
        int WetWeatherTemperature { get; set; }
    }

    public class Tyre : ITyre, IIdentity
    {
        public int Id { get; set; }
        public int LocalResourceId { get; set; }
        public string ResourceId { get; set; }
        public string ResourceText { get; set; }

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
    }
}
