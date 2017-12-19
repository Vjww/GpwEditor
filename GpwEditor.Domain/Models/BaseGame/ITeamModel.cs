namespace GpwEditor.Domain.Models.BaseGame
{
    public interface ITeamModel : IModel
    {
        int TeamId { get; set; }
        string Name { get; set; }
        int LastPosition { get; set; }
        int LastPoints { get; set; }
        int FirstGpTrack { get; set; }
        int FirstGpYear { get; set; }
        int Wins { get; set; }
        int YearlyBudget { get; set; }
        int CountryMapId { get; set; }
        int LocationPointerX { get; set; }
        int LocationPointerY { get; set; }
        int TyreSupplierId { get; set; }
        int ChassisHandling { get; set; }
        int CarNumberDriver1 { get; set; }
        int CarNumberDriver2 { get; set; }
    }
}