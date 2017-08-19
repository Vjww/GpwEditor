using ConsoleApplication.Services;

namespace ConsoleApplication.DataSources
{
    public class DataSource : IDataSource
    {
        public IMemoryStreamService GameExecutable { get; }
        public IMemoryStreamService EnglishLanguageResource { get; }
        public IMemoryStreamService FrenchLanguageResource { get; }
        public IMemoryStreamService GermanLanguageResource { get; }
        public IMemoryStreamService EnglishCommentaryResource { get; }
        public IMemoryStreamService FrenchCommentaryResource { get; }
        public IMemoryStreamService GermanCommentaryResource { get; }

        public DataSource(IMemoryStreamService gameExecutable,
            IMemoryStreamService englishLanguageResource,
            IMemoryStreamService frenchLanguageResource,
            IMemoryStreamService germanLanguageResource,
            IMemoryStreamService englishCommentaryResource,
            IMemoryStreamService frenchCommentaryResource,
            IMemoryStreamService germanCommentaryResource)
        {
            GameExecutable = gameExecutable;
            EnglishLanguageResource = englishLanguageResource;
            FrenchLanguageResource = frenchLanguageResource;
            GermanLanguageResource = germanLanguageResource;
            EnglishCommentaryResource = englishCommentaryResource;
            FrenchCommentaryResource = frenchCommentaryResource;
            GermanCommentaryResource = germanCommentaryResource;
        }
    }
}