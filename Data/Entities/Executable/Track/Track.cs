using System.ComponentModel.DataAnnotations;
using Data.Entities.Language;

namespace Data.Entities.Executable.Track
{
    public interface ITrack
    {
        int Laps { get; set; }
        int Design { get; set; }
        int LapRecordDriver { get; set; }
        int LapRecordTeam { get; set; }
        int LapRecordTime { get; set; }
        int LapRecordMph { get; set; }
        int LapRecordYear { get; set; }
        int LastRaceDriver { get; set; }
        int LastRaceTeam { get; set; }
        int LastRaceYear { get; set; }
        int LastRaceTime { get; set; }
        int Speed { get; set; }
        int Grip { get; set; }
        int Surface { get; set; }
        int Tarmac { get; set; }
        int Dust { get; set; }
        int Overtaking { get; set; }
        int Braking { get; set; }
        int Rain { get; set; }
        int Heat { get; set; }
        int Wind { get; set; }
    }

    public class Track : ITrack, IIdentity
    {
        public int Id { get; set; }
        public int LocalResourceId { get; set; }
        public string ResourceId { get; set; }
        [Display(Name = "Track Name", Description = "The name of the track, as specified in the language file.")]
        public string ResourceText { get; set; }

        // TODO Annotate
        public int Laps { get; set; }
        // TODO Annotate
        public int Design { get; set; }

        // TODO Annotate
        public int LapRecordDriver { get; set; }
        // TODO Annotate
        public int LapRecordTeam { get; set; }
        // TODO Annotate
        public int LapRecordTime { get; set; }
        // TODO Annotate
        public int LapRecordMph { get; set; }
        // TODO Annotate
        public int LapRecordYear { get; set; }

        [Display(Name = "Last Winning Driver", Description = "The name of the driver that won the last Grand Prix held at this track.")]
        public int LastRaceDriver { get; set; }
        [Display(Name = "Last Winning Team", Description = "The name of the team that won the last Grand Prix held at this track.")]
        public int LastRaceTeam { get; set; }
        [Display(Name = "Last Race Year", Description = "The year the last Grand Prix was held at this track.")]
        public int LastRaceYear { get; set; }
        [Display(Name = "Last Race Duration", Description = "The duration of the race when the last Grand Prix was held at this track.")]
        public int LastRaceTime { get; set; }

        [Display(Name = "Speed", Description = "The track's Speed attribute rating.")]
        public int Speed { get; set; }
        [Display(Name = "Grip", Description = "The track's Grip attribute rating.")]
        public int Grip { get; set; }
        [Display(Name = "Surface", Description = "The track's Surface attribute rating.")]
        public int Surface { get; set; }
        [Display(Name = "Tarmac", Description = "The track's Tarmac attribute rating.")]
        public int Tarmac { get; set; }
        [Display(Name = "Dust", Description = "The track's Dust attribute rating.")]
        public int Dust { get; set; }
        [Display(Name = "Overtaking", Description = "The track's Overtaking attribute rating.")]
        public int Overtaking { get; set; }
        [Display(Name = "Braking", Description = "The track's Braking attribute rating.")]
        public int Braking { get; set; }
        [Display(Name = "Rain", Description = "The track's Rain attribute rating.")]
        public int Rain { get; set; }
        [Display(Name = "Heat", Description = "The track's Heat attribute rating.")]
        public int Heat { get; set; }
        [Display(Name = "Wind", Description = "The track's Wind attribute rating.")]
        public int Wind { get; set; }
    }
}
