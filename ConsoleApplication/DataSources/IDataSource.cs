using ConsoleApplication.Services;

namespace ConsoleApplication.DataSources
{
    public interface IDataSource
    {
        IMemoryStreamService GameExecutable { get; }
        IMemoryStreamService EnglishLanguageResource { get; }
        IMemoryStreamService FrenchLanguageResource { get; }
        IMemoryStreamService GermanLanguageResource { get; }
        IMemoryStreamService EnglishCommentaryResource { get; }
        IMemoryStreamService FrenchCommentaryResource { get; }
        IMemoryStreamService GermanCommentaryResource { get; }
    }
}