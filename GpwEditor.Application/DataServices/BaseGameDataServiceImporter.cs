using System;
using GpwEditor.Application.DataConnections;
using GpwEditor.Infrastructure.DataConnections;
using GpwEditor.Infrastructure.DataContexts;
using GpwEditor.Infrastructure.DataEndpoints;

namespace GpwEditor.Application.DataServices
{
    public class BaseGameDataServiceImporter : IDataServiceImporter<BaseGameDataConnection>
    {
        private readonly BaseGameDataConnectionValidator _dataConnectionValidator;
        private readonly BaseGameDataContext _dataContext;
        private readonly BaseGameDataEndpoint _dataEndpoint;

        public BaseGameDataServiceImporter(
            BaseGameDataConnectionValidator dataConnectionValidator,
            BaseGameDataContext dataContext,
            BaseGameDataEndpoint dataEndpoint)
        {
            _dataConnectionValidator = dataConnectionValidator ?? throw new ArgumentNullException(nameof(dataConnectionValidator));
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
        }

        public void Import(BaseGameDataConnection dataConnection)
        {
            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

            if (!_dataConnectionValidator.Validate(dataConnection))
            {
                throw new Exception("Failed to validate data connection.");
            }
            _dataEndpoint.Import(dataConnection);
            _dataContext.Import();
        }
    }
}