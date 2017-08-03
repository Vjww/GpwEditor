namespace GpwEditor.Helpers
{
    public class GpwRegistryKeys
    {
        public const string InstallKey = "INSTALL";
        public const string LanguageKey = "LANGUAGE";
        public const string PathKey = "PATH";
        public const string ValidKey = "VALID";

        public string InstallValue { get; set; }
        public int LanguageValue { get; set; }
        public string PathValue { get; set; }
        public int ValidValue { get; set; }
    }
}