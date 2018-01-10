using App.Shared.Data.Enums;

namespace App.Shared.Data.Catalogues.Commentary
{
    public interface ILanguagePhrases
    {
        LanguageType Language { get; }
        string DriverInPitsSuffix { get; }
        string DriverP1Suffix { get; }
        string DriverP2Suffix { get; }
        string DriverP3Suffix { get; }
        string DriverOutSuffix { get; }
        string TeamOutSuffix { get; }
    }
}