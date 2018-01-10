using App.BaseGameEditor.Data.DataConnections;

namespace App.BaseGameEditor.Infrastructure.DataServices
{
    public interface IDataImportService<in TDataConnection>
        where TDataConnection : class, IDataConnection
    {
        void Import(TDataConnection dataConnection);
    }
}