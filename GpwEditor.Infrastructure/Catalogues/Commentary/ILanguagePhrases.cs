namespace GpwEditor.Infrastructure.Catalogues.Commentary
{
    public interface ILanguagePhrases
    {
        LanguageEnum Language { get; }
        string DriverInPitsSuffix { get; }
        string DriverP1Suffix { get; }
        string DriverP2Suffix { get; }
        string DriverP3Suffix { get; }
        string DriverOutSuffix { get; }
        string TeamOutSuffix { get; }
    }
}