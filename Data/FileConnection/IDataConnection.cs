using Data.Collections.Language;

namespace Data.FileConnection
{
    public interface IDataConnection
    {
        void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection);
        void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection);
    }
}
