namespace GpwEditor.Domain.Objects.BaseGame
{
    public interface ITeamObject : IObject
    {
        int TeamId { get; set; }
        string Name { get; set; }
        int ChassisHandling { get; set; }
        int CarNumberDriver1 { get; set; }
        int CarNumberDriver2 { get; set; }
    }
}