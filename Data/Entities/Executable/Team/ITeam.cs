namespace Data.Entities.Executable.Team
{
    public interface ITeam
    {
        int LastPosition { get; set; }
        int LastPoints { get; set; }
        int FirstGpTrack { get; set; }
        int FirstGpYear { get; set; }
        int Wins { get; set; }
        int YearlyBudget { get; set; }
        int Unknown { get; set; }
        int CountryMapId { get; set; }
        int TyreSupplierId { get; set; }
    }
}
