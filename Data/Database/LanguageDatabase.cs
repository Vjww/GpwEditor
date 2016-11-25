using Common.Enums;
using Data.Collections.Language;
using Data.FileConnection;

namespace Data.Database
{
    public class LanguageDatabase
    {
        // Collections
        public IdentityCollection LanguageStrings { get; set; }

        public void ImportDataFromFile(string languageFileFilePath)
        {
            ImportLanguageStrings(languageFileFilePath);
        }

        public void ExportDataToFile(string languageFileFilePath)
        {
            ExportLanguageStrings(languageFileFilePath);
        }

        private void ImportLanguageStrings(string languageFileFilePath)
        {
            var languageConnection = new LanguageConnection();
            try
            {
                languageConnection.Open(languageFileFilePath, StreamDirectionType.Read);
                LanguageStrings = languageConnection.Load();
            }
            finally
            {
                languageConnection.Close();
            }
        }

        private void ExportLanguageStrings(string languageFileFilePath)
        {
            var languageConnection = new LanguageConnection();
            try
            {
                languageConnection.Open(languageFileFilePath, StreamDirectionType.Write);
                languageConnection.Save(LanguageStrings);
            }
            finally
            {
                languageConnection.Close();
            }
        }
    }
}
