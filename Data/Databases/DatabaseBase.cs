using System;
using Data.Collections.Language;
using Data.FileConnection;

namespace Data.Databases
{
    public class DatabaseBase
    {
        public IdentityCollection LanguageResources { get; set; }

        protected void ExportLanguageResources(string filePath)
        {
            using (var connection = new LanguageResourceConnection(filePath))
            {
                connection.Save(LanguageResources);
            }
        }

        protected void ImportLanguageResources(string filePath)
        {
            using (var connection = new LanguageResourceConnection(filePath))
            {
                LanguageResources = connection.Load();
            }
        }

        protected static void ValidateGameFolder(string gameFolderPath, string resolutionMessage)
        {
            string verificationMessage;
            var isValid = new GameFolderVerification().IsFolderSupported(gameFolderPath, out verificationMessage);

            if (isValid) return;
            throw new Exception($"{resolutionMessage}{Environment.NewLine}{Environment.NewLine}{verificationMessage}");
        }

        protected static void ValidateGameExecutable(string gameExecutablePath, string resolutionMessage)
        {
            string verificationMessage;
            var isValid = new GameExecutableVerification().IsFileSupported(gameExecutablePath, out verificationMessage);

            if (isValid) return;
            throw new Exception($"{resolutionMessage}{Environment.NewLine}{Environment.NewLine}{verificationMessage}");
        }

        protected static void ValidateLanguageFile(string languageFilePath, string resolutionMessage)
        {
            string verificationMessage;
            var isValid = new LanguageFileVerification().IsFileSupported(languageFilePath, out verificationMessage);

            if (isValid) return;
            throw new Exception($"{resolutionMessage}{Environment.NewLine}{Environment.NewLine}{verificationMessage}");
        }
    }
}