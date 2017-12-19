using Common.Editor.Data.DataConnections;

namespace GpwEditor.Application.DataServices
{
    public interface IDataServiceImporter<in TDataConnection>
        where TDataConnection : class, IDataConnection
    {
        void Import(TDataConnection dataConnection);
    }
}