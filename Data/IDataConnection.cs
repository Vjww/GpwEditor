using Data.Collections.Language;
using Data.FileConnection;

namespace Data
{
    public interface IDataConnection
    {
        void ExportData(ExecutableConnection executableConnection, IdentityCollection identityCollection);
        void ImportData(ExecutableConnection executableConnection, IdentityCollection identityCollection);
    }
}
