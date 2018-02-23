using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Catalogues.Commentary
{
    public class FrenchLanguagePhrases : ILanguagePhrases
    {
        public LanguageType Language { get; } = LanguageType.French;
        public string DriverInPitsSuffix { get; } = "aux stands.";
        public string DriverP1Suffix { get; } = "1er";
        public string DriverP2Suffix { get; } = "2ème";
        public string DriverP3Suffix { get; } = "3ème";
        public string DriverOutSuffix { get; } = "hors course.";
        public string TeamOutSuffix { get; } = "hors course.";
    }
}