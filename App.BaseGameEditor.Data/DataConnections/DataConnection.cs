using System;

namespace App.BaseGameEditor.Data.DataConnections
{
    public class DataConnection
    {
        public string GameFolderPath { get; private set; }
        public string GameExecutableFilePath { get; private set; }
        public string EnglishLanguageFilePath { get; private set; }
        public string FrenchLanguageFilePath { get; private set; }
        public string GermanLanguageFilePath { get; private set; }
        public string EnglishCommentaryFilePath { get; private set; }
        public string FrenchCommentaryFilePath { get; private set; }
        public string GermanCommentaryFilePath { get; private set; }

        public void Initialise(
            string gameFolderPath,
            string gameExecutableFilePath,
            string englishLanguageFilePath,
            string frenchLanguageFilePath,
            string germanLanguageFilePath,
            string englishCommentaryFilePath,
            string frenchCommentaryFilePath,
            string germanCommentaryFilePath)
        {
            if (string.IsNullOrWhiteSpace(gameFolderPath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(gameFolderPath));
            if (string.IsNullOrWhiteSpace(gameExecutableFilePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(gameExecutableFilePath));
            if (string.IsNullOrWhiteSpace(englishLanguageFilePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(englishLanguageFilePath));
            if (string.IsNullOrWhiteSpace(frenchLanguageFilePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(frenchLanguageFilePath));
            if (string.IsNullOrWhiteSpace(germanLanguageFilePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(germanLanguageFilePath));
            if (string.IsNullOrWhiteSpace(englishCommentaryFilePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(englishCommentaryFilePath));
            if (string.IsNullOrWhiteSpace(frenchCommentaryFilePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(frenchCommentaryFilePath));
            if (string.IsNullOrWhiteSpace(germanCommentaryFilePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(germanCommentaryFilePath));

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