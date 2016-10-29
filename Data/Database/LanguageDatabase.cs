using Common.Enums;
using Data.Collections.Language;
using Data.FileConnection;

namespace Data.Database
{
    public class LanguageDatabase
    {
        public IdentityCollection LanguageStrings { get; set; }

        public void ExportDataToFile(string languageFileFilePath)
        {
            ExportLanguageStrings(languageFileFilePath);
        }

        public void ImportDataFromFile(string languageFileFilePath)
        {
            ImportLanguageStrings(languageFileFilePath);
        }

        private void ExportLanguageStrings(string languageFileFilePath)
        {
            LanguageConnection languageConnection = null;
            try
            {
                languageConnection = new LanguageConnection();
                languageConnection.Open(languageFileFilePath, StreamDirectionType.Write);
                languageConnection.Save(LanguageStrings);
            }
            finally
            {
                languageConnection?.Close();
            }
        }

        private void ImportLanguageStrings(string languageFileFilePath)
        {
            LanguageConnection languageConnection = null;
            try
            {
                languageConnection = new LanguageConnection();
                languageConnection.Open(languageFileFilePath, StreamDirectionType.Read);
                LanguageStrings = languageConnection.Load();
            }
            finally
            {
                languageConnection?.Close();
            }
        }
    }
}
