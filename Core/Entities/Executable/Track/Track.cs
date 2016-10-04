using Core.Entities.Language;

namespace Core.Entities.Executable.Track
{
    public interface ITrack
    {
        int Laps { get; set; }
        int Design { get; set; }
        int Unknown1 { get; set; }
        int Unknown2 { get; set; }
        int Unknown3 { get; set; }
        int LastRaceYear { get; set; }
        int LastRaceTime { get; set; }
        int LapRecordDriver { get; set; }
        int LapRecordTeam { get; set; }
        int LapRecordTime { get; set; }
        int LapRecordYear { get; set; }
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
        public string ResourceText { get; set; }

        public int Laps { get; set; }
        public int Design { get; set; }
        public int Unknown1 { get; set; }
        public int Unknown2 { get; set; }
        public int Unknown3 { get; set; }
        public int LastRaceYear { get; set; }
        public int LastRaceTime { get; set; }
        public int LapRecordDriver { get; set; }
        public int LapRecordTeam { get; set; }
        public int LapRecordTime { get; set; }
        public int LapRecordYear { get; set; }
        public int Speed { get; set; }
        public int Grip { get; set; }
        public int Surface { get; set; }
        public int Tarmac { get; set; }
        public int Dust { get; set; }
        public int Overtaking { get; set; }
        public int Braking { get; set; }
        public int Rain { get; set; }
        public int Heat { get; set; }
        public int Wind { get; set; }
    }
}
