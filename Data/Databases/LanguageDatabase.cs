namespace Data.Databases
{
    public class LanguageDatabase : DatabaseBase
    {
        public void ImportDataFromFile(string gameExecutablePath, string languageFilePath)
        {
            // TODO: ValidateGameFolder(gameFolderPath, "Please ensure the selected folder contains the game folders and files to import successfully.");
            ValidateGameExecutable(gameExecutablePath, "Please ensure the selected file is a compatible v1.01b game executable to import successfully.");
            ValidateLanguageFile(languageFilePath, "Please ensure the selected file is a compatible v1.01b language file to import successfully.");

            ImportLanguageResources(languageFilePath);
        }

        public void ExportDataToFile(string gameExecutablePath, string languageFilePath)
        {
            // TODO: ValidateGameFolder(gameFolderPath, "Please ensure the selected folder contains the game folders and files to export successfully.");
            ValidateGameExecutable(gameExecutablePath, "Please ensure the selected file is a compatible v1.01b game executable to export successfully.");
            ValidateLanguageFile(languageFilePath, "Please ensure the selected file is a compatible v1.01b language file to export successfully.");

            ExportLanguageResources(languageFilePath);
        }
    }
}