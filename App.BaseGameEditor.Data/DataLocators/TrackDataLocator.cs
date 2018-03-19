using App.Core.Identities;

namespace App.BaseGameEditor.Data.DataLocators
{
    public class TrackDataLocator : IntegerIdentityBase, IDataLocator
    {
        private const int NameOffset = 6043 + 1; // "No Circuit" -> "Melbourne"

        private const int BaseOffset = 1058252;
        private const int LocalOffset = 210;
        private const int LapsOffset = 0;
        private const int LayoutOffset = 10;
        private const int LapRecordDriverOffset = 20;
        private const int LapRecordTeamOffset = 30;
        private const int LapRecordTimeOffset = 40;
        private const int LapRecordMphOffset = 50;
        private const int LapRecordYearOffset = 60;
        private const int LastRaceDriverOffset = 70;
        private const int LastRaceTeamOffset = 80;
        private const int LastRaceYearOffset = 90;
        private const int LastRaceTimeOffset = 100;
        private const int SpeedOffset = 110;
        private const int GripOffset = 120;
        private const int SurfaceOffset = 130;
        private const int TarmacOffset = 140;
        private const int DustOffset = 150;
        private const int OvertakingOffset = 160;
        private const int BrakingOffset = 170;
        private const int RainOffset = 180;
        private const int HeatOffset = 190;
        private const int WindOffset = 200;

        private const int HospitalityBaseOffset = 2772636;
        private const int HospitalityLocalOffset = 4;

        public int Name { get; set; }
        public int Laps { get; set; }
        public int Layout { get; set; }
        public int LapRecordDriver { get; set; }
        public int LapRecordTeam { get; set; }
        public int LapRecordTime { get; set; }
        public int LapRecordMph { get; set; }
        public int LapRecordYear { get; set; }
        public int LastRaceDriver { get; set; }
        public int LastRaceTeam { get; set; }
        public int LastRaceYear { get; set; }
        public int LastRaceTime { get; set; }
        public int Hospitality { get; set; }
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

        public void Initialise()
        {
            Name = NameOffset + Id;

            var stepOffset = LocalOffset * Id;

            Laps = BaseOffset + stepOffset + LapsOffset;
            Layout = BaseOffset + stepOffset + LayoutOffset;
            LapRecordDriver = BaseOffset + stepOffset + LapRecordDriverOffset;
            LapRecordTeam = BaseOffset + stepOffset + LapRecordTeamOffset;
            LapRecordTime = BaseOffset + stepOffset + LapRecordTimeOffset;
            LapRecordMph = BaseOffset + stepOffset + LapRecordMphOffset;
            LapRecordYear = BaseOffset + stepOffset + LapRecordYearOffset;
            LastRaceDriver = BaseOffset + stepOffset + LastRaceDriverOffset;
            LastRaceTeam = BaseOffset + stepOffset + LastRaceTeamOffset;
            LastRaceYear = BaseOffset + stepOffset + LastRaceYearOffset;
            LastRaceTime = BaseOffset + stepOffset + LastRaceTimeOffset;
            Hospitality = HospitalityBaseOffset + HospitalityLocalOffset * Id;
            Speed = BaseOffset + stepOffset + SpeedOffset;
            Grip = BaseOffset + stepOffset + GripOffset;
            Surface = BaseOffset + stepOffset + SurfaceOffset;
            Tarmac = BaseOffset + stepOffset + TarmacOffset;
            Dust = BaseOffset + stepOffset + DustOffset;
            Overtaking = BaseOffset + stepOffset + OvertakingOffset;
            Braking = BaseOffset + stepOffset + BrakingOffset;
            Rain = BaseOffset + stepOffset + RainOffset;
            Heat = BaseOffset + stepOffset + HeatOffset;
            Wind = BaseOffset + stepOffset + WindOffset;
        }
    }
}