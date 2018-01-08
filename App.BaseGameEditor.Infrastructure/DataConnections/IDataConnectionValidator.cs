using Common.Editor.Data.DataConnections;

namespace App.BaseGameEditor.Infrastructure.DataConnections
{
    public interface IDataConnectionValidator<in TDataConnection>
        where TDataConnection : class, IDataConnection
    {
        bool Validate(TDataConnection dataConnection);
    }
}