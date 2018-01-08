using Common.Editor.Data.DataConnections;

namespace App.BaseGameEditor.Infrastructure.DataServices
{
    public interface IDataServiceExporter<in TDataConnection>
        where TDataConnection : class, IDataConnection
    {
        void Export(TDataConnection dataConnection);
    }
}