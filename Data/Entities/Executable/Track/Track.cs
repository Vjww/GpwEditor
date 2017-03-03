using Common.Extensions;
using Data.Collections.Language;
using Data.Entities.Language;
using Data.FileConnection;
using Data.Helpers;
using System.ComponentModel.DataAnnotations;
using TrackMapping = Data.ValueMapping.Executable.Track;

namespace Data.Entities.Executable.Track
{
    public class Track : ITrack, IIdentity, IDataConnection
    {
        private readonly TrackMapping.Track _valueMapping;

        [Display(Name = "Id", Description = "The id of the record.")]
        public int Id { get; set; }
        [Display(Name = "Local Resource Id", Description = "The id of the resource string, relative to the base resource string in the language file.")]
        public int LocalResourceId { get; set; }
        [Display(Name = "Resource Id", Description = "The resource id of the resource string in the language file.")]
        public string ResourceId { get; set; }
        [Display(Name = "Track Name", Description = "The name of the track, as specified in the language file.")]
        public string ResourceText { get; set; }

        [Display(Name = "Laps", Description = "The number of racing laps in a Grand Prix.")]
        [Range(1, 99, ErrorMessage = "Value for {0} must be between {1} and {2}.")] // TODO check range
        public int Laps { get; set; }
        [Display(Name = "Design", Description = "The design direction of the track.")]
        [Range(1, 3, ErrorMessage = "Value for {0} must be between {1} and {2}.")] // TODO check range
        public int Design { get; set; }
        [Display(Name = "Lap Record Driver", Description = "The name of the driver that set the fastest lap record at the track.")]
        [Range(1, 203, ErrorMessage = "Value for {0} must be between {1} and {2}.")] // TODO check for specific values?
        public int LapRecordDriver { get; set; }
        [Display(Name = "Lap Record Team", Description = "The name of the team that set the fastest lap record at the track.")]
        [Range(1, 11, ErrorMessage = "Value for {0} must be between {1} and {2}.")] // TODO check range
        public int LapRecordTeam { get; set; }
        [Display(Name = "Lap Record Time", Description = "The laptime that set the fastest lap record at the track.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int LapRecordTime { get; set; }
        [Display(Name = "Lap Record MPH", Description = "The average speed (MPH) that set the fastest lap record at the track.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int LapRecordMph { get; set; }
        [Display(Name = "Lap Record Year", Description = "The year when the fastest lap record was set at the track.")]
        [Range(1900, 2100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int LapRecordYear { get; set; }
        [Display(Name = "Last Winning Driver", Description = "The name of the driver that won the last Grand Prix held at the track.")]
        [Range(1, 99, ErrorMessage = "Value for {0} must be between {1} and {2}.")] // TODO check range
        public int LastRaceDriver { get; set; }
        [Display(Name = "Last Winning Team", Description = "The name of the team that won the last Grand Prix held at the track.")]
        [Range(1, 11, ErrorMessage = "Value for {0} must be between {1} and {2}.")] // TODO check range
        public int LastRaceTeam { get; set; }
        [Display(Name = "Last Race Year", Description = "The year the last Grand Prix was held at the track.")]
        [Range(1900, 2100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int LastRaceYear { get; set; }
        [Display(Name = "Last Race Duration", Description = "The duration of the race when the last Grand Prix was held at the track.")]
        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int LastRaceTime { get; set; }

        [Display(Name = "Hospitality", Description = "The hospitality rating of the track.")]
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Hospitality { get; set; }
        [Display(Name = "Speed", Description = "The speed rating of the track.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Speed { get; set; }
        [Display(Name = "Grip", Description = "The grip rating of the track.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Grip { get; set; }
        [Display(Name = "Surface", Description = "The surface rating of the track.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Surface { get; set; }
        [Display(Name = "Tarmac", Description = "The tarmac rating of the track.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Tarmac { get; set; }
        [Display(Name = "Dust", Description = "The dust rating of the track.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Dust { get; set; }
        [Display(Name = "Overtaking", Description = "The overtaking rating of the track.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Overtaking { get; set; }
        [Display(Name = "Braking", Description = "The braking rating of the track.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Braking { get; set; }
        [Display(Name = "Rain", Description = "The rain rating of the track.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Rain { get; set; }
        [Display(Name = "Heat", Description = "The heat rating of the track.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Heat { get; set; }
        [Display(Name = "Wind", Description = "The wind rating of the track.")]
        [Range(1, 10, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Wind { get; set; }

        public Track(TrackMapping.Track valueMapping, int id)
        {
            _valueMapping = valueMapping;

            Id = id;
            LocalResourceId = TrackMapping.Track.GetLocalResourceId(Id);
            ResourceId = _valueMapping.Name.BuildResourceId();
        }

        public void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceHelper.SetResourceText(identityCollection, ResourceId, ResourceText);
            executableConnection.WriteInteger(_valueMapping.Laps, Laps);
            executableConnection.WriteInteger(_valueMapping.Design, Design);
            executableConnection.WriteInteger(_valueMapping.LapRecordDriver, LapRecordDriver);
            executableConnection.WriteInteger(_valueMapping.LapRecordTeam, LapRecordTeam);
            executableConnection.WriteInteger(_valueMapping.LapRecordTime, LapRecordTime);
            executableConnection.WriteInteger(_valueMapping.LapRecordMph, LapRecordMph);
            executableConnection.WriteInteger(_valueMapping.LapRecordYear, LapRecordYear);
            executableConnection.WriteInteger(_valueMapping.LastRaceDriver, LastRaceDriver);
            executableConnection.WriteInteger(_valueMapping.LastRaceTeam, LastRaceTeam);
            executableConnection.WriteInteger(_valueMapping.LastRaceYear, LastRaceYear);
            executableConnection.WriteInteger(_valueMapping.LastRaceTime, LastRaceTime);
            executableConnection.WriteInteger(_valueMapping.Hospitality, Hospitality);
            executableConnection.WriteInteger(_valueMapping.Speed, Speed);
            executableConnection.WriteInteger(_valueMapping.Grip, Grip);
            executableConnection.WriteInteger(_valueMapping.Surface, Surface);
            executableConnection.WriteInteger(_valueMapping.Tarmac, Tarmac);
            executableConnection.WriteInteger(_valueMapping.Dust, Dust);
            executableConnection.WriteInteger(_valueMapping.Overtaking, Overtaking);
            executableConnection.WriteInteger(_valueMapping.Braking, Braking);
            executableConnection.WriteInteger(_valueMapping.Rain, Rain);
            executableConnection.WriteInteger(_valueMapping.Heat, Heat);
            executableConnection.WriteInteger(_valueMapping.Wind, Wind);
        }

        public void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection)
        {
            ResourceText = ResourceHelper.GetResourceText(identityCollection, ResourceId);
            Laps = executableConnection.ReadInteger(_valueMapping.Laps);
            Design = executableConnection.ReadInteger(_valueMapping.Design);
            LapRecordDriver = executableConnection.ReadInteger(_valueMapping.LapRecordDriver);
            LapRecordTeam = executableConnection.ReadInteger(_valueMapping.LapRecordTeam);
            LapRecordTime = executableConnection.ReadInteger(_valueMapping.LapRecordTime);
            LapRecordMph = executableConnection.ReadInteger(_valueMapping.LapRecordMph);
            LapRecordYear = executableConnection.ReadInteger(_valueMapping.LapRecordYear);
            LastRaceDriver = executableConnection.ReadInteger(_valueMapping.LastRaceDriver);
            LastRaceTeam = executableConnection.ReadInteger(_valueMapping.LastRaceTeam);
            LastRaceYear = executableConnection.ReadInteger(_valueMapping.LastRaceYear);
            LastRaceTime = executableConnection.ReadInteger(_valueMapping.LastRaceTime);
            Hospitality = executableConnection.ReadInteger(_valueMapping.Hospitality);
            Speed = executableConnection.ReadInteger(_valueMapping.Speed);
            Grip = executableConnection.ReadInteger(_valueMapping.Grip);
            Surface = executableConnection.ReadInteger(_valueMapping.Surface);
            Tarmac = executableConnection.ReadInteger(_valueMapping.Tarmac);
            Dust = executableConnection.ReadInteger(_valueMapping.Dust);
            Overtaking = executableConnection.ReadInteger(_valueMapping.Overtaking);
            Braking = executableConnection.ReadInteger(_valueMapping.Braking);
            Rain = executableConnection.ReadInteger(_valueMapping.Rain);
            Heat = executableConnection.ReadInteger(_valueMapping.Heat);
            Wind = executableConnection.ReadInteger(_valueMapping.Wind);
        }
    }
}
