
namespace Core.Entities.Executable.Team
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

    public class Team : ITeam, IIdentity
    {
        public int Id { get; set; }
        public int LocalResourceId { get; set; }
        public string ResourceId { get; set; }
        public string ResourceText { get; set; }

        public int LastPosition { get; set; }
        public int LastPoints { get; set; }
        public int FirstGpTrack { get; set; }
        public int FirstGpYear { get; set; }
        public int Wins { get; set; }
        public int YearlyBudget { get; set; }
        public int Unknown { get; set; }
        public int CountryMapId { get; set; }
        public int TyreSupplierId { get; set; }
    }
}
