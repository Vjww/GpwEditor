using Data.Entities.Language;
using System.ComponentModel.DataAnnotations;

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

    public class Team : ITeam, IIdentity
    {
        public int Id { get; set; }
        public int LocalResourceId { get; set; }
        public string ResourceId { get; set; }
        [Display(Name = "Team Name", Description = "The name of the team, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name="Last Year's Championship Position", Description="Informational value used when player selects a team to play.")]
        public int LastPosition { get; set; }
        [Display(Name = "Last Year's Championship Points", Description = "Informational value used when player selects a team to play.")]
        public int LastPoints { get; set; }
        [Display(Name = "Debut Grand Prix", Description = "Informational value used when player selects a team to play.")]
        public int FirstGpTrack { get; set; }
        [Display(Name = "Debut Year", Description = "Informational value used when player selects a team to play.")]
        public int FirstGpYear { get; set; }
        [Display(Name = "Wins", Description = "Informational value used when player selects a team to play.")]
        public int Wins { get; set; }
        [Display(Name = "This Year's Budget", Description = "Informational value used when player selects a team to play.")]
        public int YearlyBudget { get; set; }
        [Display(Name = "Unknown", Description = "Unknown value. Unknown usage.")]
        public int Unknown { get; set; }
        [Display(Name = "Nationality", Description = "Index value of the country bitmap to display.")]
        public int CountryMapId { get; set; }
        [Display(Name = "This Year's Tyre Supplier", Description = "Unknown usage. May be intended to be used as an informational value.")]
        public int TyreSupplierId { get; set; }
    }
}
