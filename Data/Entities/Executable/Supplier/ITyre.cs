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
}
