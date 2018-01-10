using System.Collections.Generic;
using App.BaseGameEditor.Data.DataConnections;

namespace App.BaseGameEditor.Infrastructure.DataConnections
{
    public interface IDataConnectionValidationService<in TDataConnection>
        where TDataConnection : class, IDataConnection
    {
        IEnumerable<string> Validate(TDataConnection dataConnection);
    }
}