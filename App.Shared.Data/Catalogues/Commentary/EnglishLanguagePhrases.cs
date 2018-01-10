using App.Shared.Data.Enums;

namespace App.Shared.Data.Catalogues.Commentary
{
    public class EnglishLanguagePhrases : ILanguagePhrases
    {
        public LanguageType Language { get; } = LanguageType.English;
        public string DriverInPitsSuffix { get; } = "in pits.";
        public string DriverP1Suffix { get; } = "P1";
        public string DriverP2Suffix { get; } = "P2";
        public string DriverP3Suffix { get; } = "P3";
        public string DriverOutSuffix { get; } = "out.";
        public string TeamOutSuffix { get; } = "out.";
    }
}