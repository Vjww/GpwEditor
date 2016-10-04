namespace Data.Entities.Executable.Track
{
    public interface ITrackLapRecord
    {
        int Driver { get; set; }
        int Team { get; set; }
        int Time { get; set; }
        int Year { get; set; }
    }

    public class TrackLapRecord : ITrackLapRecord
    {
        public int Driver { get; set; }
        public int Team { get; set; }
        public int Time { get; set; }
        public int Year { get; set; }
    }
}
