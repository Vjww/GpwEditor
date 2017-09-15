namespace GpwEditor.Infrastructure.ConnectionStrings
{
    public class BaseGameConnectionStrings : IConnectionStrings
    {
        public string GameFolder { get; set; }
        public string GameExecutable { get; set; }
        public string EnglishLanguageResource { get; set; }
        public string FrenchLanguageResource { get; set; }
        public string GermanLanguageResource { get; set; }
        public string EnglishCommentaryResource { get; set; }
        public string FrenchCommentaryResource { get; set; }
        public string GermanCommentaryResource { get; set; }
    }
}