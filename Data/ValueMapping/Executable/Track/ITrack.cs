namespace Data.ValueMapping.Executable.Track
{
    public interface ITrack
    {
        int Name { get; set; }
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
        int Hospitality { get; set; }
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
}
