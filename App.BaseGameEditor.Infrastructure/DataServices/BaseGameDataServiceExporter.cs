using System;
using App.BaseGameEditor.Data.DataConnections;
using App.BaseGameEditor.Data.DataContexts;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Infrastructure.DataConnections;

namespace App.BaseGameEditor.Infrastructure.DataServices
{
    public class BaseGameDataServiceExporter : IDataServiceExporter<DataConnection>
    {
        private readonly BaseGameDataConnectionValidator _dataConnectionValidator;
        private readonly BaseGameDataContext _dataContext;
        private readonly BaseGameDataEndpoint _dataEndpoint;

        public BaseGameDataServiceExporter(
            BaseGameDataConnectionValidator dataConnectionValidator,
            BaseGameDataContext dataContext,
            BaseGameDataEndpoint dataEndpoint)
        {
            _dataConnectionValidator = dataConnectionValidator ?? throw new ArgumentNullException(nameof(dataConnectionValidator));
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
        }

        public void Export(DataConnection dataConnection)
        {
            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

            if (!_dataConnectionValidator.Validate(dataConnection))
            {
                throw new Exception("Failed to validate data connection.");
            }
            _dataContext.Export();
            _dataEndpoint.Export(dataConnection);
        }
    }
}