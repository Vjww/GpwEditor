namespace GpwEditor.Infrastructure.Catalogues.Commentary
{
    public class GermanLanguagePhrases : ILanguagePhrases
    {
        public LanguageEnum Language { get; } = LanguageEnum.German;
        public string DriverInPitsSuffix { get; } = "an der Box.";
        public string DriverP1Suffix { get; } = "Platz 1";
        public string DriverP2Suffix { get; } = "Platz 2";
        public string DriverP3Suffix { get; } = "Platz 3";
        public string DriverOutSuffix { get; } = "ist raus.";
        public string TeamOutSuffix { get; } = "ist raus.";
    }
}