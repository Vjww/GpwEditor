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
            using (var languageConnection = new LanguageConnection(languageFileFilePath))
            {
                LanguageStrings = languageConnection.Load();
            }
        }

        private void ExportLanguageStrings(string languageFileFilePath)
        {
            using (var languageConnection = new LanguageConnection(languageFileFilePath))
            {
                languageConnection.Save(LanguageStrings);
            }
        }
    }
}
