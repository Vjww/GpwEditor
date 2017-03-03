namespace Data.ValueMapping.Executable.Supplier
{
    public interface ITyre
    {
        int Name { get; set; }
        int DryHardGripSupplier { get; set; }
        int DryHardResilienceSupplier { get; set; }
        int DryHardStiffnessSupplier { get; set; }
        int DryHardTemperatureSupplier { get; set; }
        int DrySoftGripSupplier { get; set; }
        int DrySoftResilienceSupplier { get; set; }
        int DrySoftStiffnessSupplier { get; set; }
        int DrySoftTemperatureSupplier { get; set; }
        int IntermediateGripSupplier { get; set; }
        int IntermediateResilienceSupplier { get; set; }
        int IntermediateStiffnessSupplier { get; set; }
        int IntermediateTemperatureSupplier { get; set; }
        int WetWeatherGripSupplier { get; set; }
        int WetWeatherResilienceSupplier { get; set; }
        int WetWeatherStiffnessSupplier { get; set; }
        int WetWeatherTemperatureSupplier { get; set; }

        int DryHardGripTeam { get; set; }
        int DryHardResilienceTeam { get; set; }
        int DryHardStiffnessTeam { get; set; }
        int DryHardTemperatureTeam { get; set; }
        int DrySoftGripTeam { get; set; }
        int DrySoftResilienceTeam { get; set; }
        int DrySoftStiffnessTeam { get; set; }
        int DrySoftTemperatureTeam { get; set; }
        int IntermediateGripTeam { get; set; }
        int IntermediateResilienceTeam { get; set; }
        int IntermediateStiffnessTeam { get; set; }
        int IntermediateTemperatureTeam { get; set; }
        int WetWeatherGripTeam { get; set; }
        int WetWeatherResilienceTeam { get; set; }
        int WetWeatherStiffnessTeam { get; set; }
        int WetWeatherTemperatureTeam { get; set; }
    }
}
