using Common.Editor.Data.DataConnections;

namespace GpwEditor.Application.DataServices
{
    public interface IDataServiceExporter<in TDataConnection>
        where TDataConnection : class, IDataConnection
    {
        void Export(TDataConnection dataConnection);
    }
}