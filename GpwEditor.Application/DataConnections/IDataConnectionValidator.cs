using Common.Editor.Data.DataConnections;

namespace GpwEditor.Application.DataConnections
{
    public interface IDataConnectionValidator<in TDataConnection>
        where TDataConnection : class, IDataConnection
    {
        bool Validate(TDataConnection dataConnection);
    }
}