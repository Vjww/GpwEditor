using Data.FileConnection;

namespace Data
{
    public interface IDataConnection
    {
        void ExportData(ExecutableConnection executableConnection, LanguageConnection languageConnection);
        void ImportData(ExecutableConnection executableConnection, LanguageConnection languageConnection);
    }
}
