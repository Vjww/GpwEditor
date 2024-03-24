namespace App.BaseGameEditor.Domain.Services
{
    public class ConfigurationDomainService
    {
        public bool DisableGameCd { get; set; }
        public bool DisableColourMode { get; set; }
        public bool DisableSampleApp { get; set; }
        public bool DisableMemoryResetForRaceSounds { get; set; }
        // public bool DisablePitExitPriority { get; set; } // TODO: Not yet implemented

        public bool DisableYellowFlagPenalties { get; set; }
        public bool EnableCarHandlingDesignCalculation { get; set; }
        public bool EnableCarPerformanceRaceCalcuation { get; set; }

        public int GameYear { get; set; }

        public bool PointsScoringSystemDefault { get; set; }
        public bool PointsScoringSystemOption1 { get; set; }
        public bool PointsScoringSystemOption2 { get; set; }
        public bool PointsScoringSystemOption3 { get; set; }

        public bool EnableTrackEditor { get; set; }
    }
}