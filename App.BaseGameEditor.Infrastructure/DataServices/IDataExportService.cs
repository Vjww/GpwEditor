using App.BaseGameEditor.Data.DataConnections;

namespace App.BaseGameEditor.Infrastructure.DataServices
{
    // TODO: Possibly redundant
    public interface IDataExportService<in TDataConnection>
        where TDataConnection : class, IDataConnection
    {
        void Export(TDataConnection dataConnection);
    }
}