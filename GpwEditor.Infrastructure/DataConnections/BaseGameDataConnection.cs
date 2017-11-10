using Common.Editor.Infrastructure.DataConnections;

namespace GpwEditor.Infrastructure.DataConnections
{
    public class BaseGameDataConnection : IDataConnection
    {
        public string GameFolderPath { get; }
        public string GameExecutableFilePath { get; }
        public string EnglishLanguageFilePath { get; }
        public string FrenchLanguageFilePath { get; }
        public string GermanLanguageFilePath { get; }
        public string EnglishCommentaryFilePath { get; }
        public string FrenchCommentaryFilePath { get; }
        public string GermanCommentaryFilePath { get; }

        public BaseGameDataConnection(
            string gameFolderPath,
            string gameExecutableFilePath,
            string englishLanguageFilePath,
            string frenchLanguageFilePath,
            string germanLanguageFilePath,
            string englishCommentaryFilePath,
            string frenchCommentaryFilePath,
            string germanCommentaryFilePath)
        {
            GameFolderPath = gameFolderPath;
            GameExecutableFilePath = gameExecutableFilePath;
            EnglishLanguageFilePath = englishLanguageFilePath;
            FrenchLanguageFilePath = frenchLanguageFilePath;
            GermanLanguageFilePath = germanLanguageFilePath;
            EnglishCommentaryFilePath = englishCommentaryFilePath;
            FrenchCommentaryFilePath = frenchCommentaryFilePath;
            GermanCommentaryFilePath = germanCommentaryFilePath;
        }
    }
}