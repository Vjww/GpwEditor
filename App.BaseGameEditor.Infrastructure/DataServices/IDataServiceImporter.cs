using Common.Editor.Data.DataConnections;

namespace App.BaseGameEditor.Infrastructure.DataServices
{
    public interface IDataServiceImporter<in TDataConnection>
        where TDataConnection : class, IDataConnection
    {
        void Import(TDataConnection dataConnection);
    }
}