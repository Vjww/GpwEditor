using Data.Collections.Language;
using Data.FileConnection;

namespace Data.Databases
{
    public class LanguageDatabase
    {
        public IdentityCollection LanguageStrings { get; set; }

        public void ImportDataFromFile(string gameExecutablePath, string languageFilePath)
        {
            ImportLanguageStrings(languageFilePath);
        }

        public void ExportDataToFile(string gameExecutablePath, string languageFilePath)
        {
            ExportLanguageStrings(languageFilePath);
        }

        private void ImportLanguageStrings(string languageFilePath)
        {
            using (var languageConnection = new LanguageResourceConnection(languageFilePath))
            {
                LanguageStrings = languageConnection.Load();
            }
        }

        private void ExportLanguageStrings(string languageFilePath)
        {
            using (var languageConnection = new LanguageResourceConnection(languageFilePath))
            {
                languageConnection.Save(LanguageStrings);
            }
        }
    }
}