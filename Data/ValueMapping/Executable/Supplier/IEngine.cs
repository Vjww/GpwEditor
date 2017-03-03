namespace Data.ValueMapping.Executable.Supplier
{
    public interface IEngine
    {
        int Name { get; set; }
        int Fuel { get; set; }
        int Heat { get; set; }
        int Power { get; set; }
        int Reliability { get; set; }
        int Response { get; set; }
        int Rigidity { get; set; }
        int Weight { get; set; }
    }
}
