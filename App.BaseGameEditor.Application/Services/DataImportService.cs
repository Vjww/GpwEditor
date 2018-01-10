using System;
using App.BaseGameEditor.Data.DataConnections;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Infrastructure.DataConnections;

namespace App.BaseGameEditor.Application.Services
{
    public class DataImportService// TODO: remove interface : IDataImportService<DataConnection>
    {
        private readonly DataConnectionValidator _dataConnectionValidator;
        private readonly DataService _dataService;
        private readonly BaseGameDataEndpoint _dataEndpoint;

        public DataImportService(
            DataConnectionValidator dataConnectionValidator,
            DataService dataService,
            BaseGameDataEndpoint dataEndpoint)
        {
            _dataConnectionValidator = dataConnectionValidator ?? throw new ArgumentNullException(nameof(dataConnectionValidator));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
        }

        public void Import(DataConnection dataConnection)
        {
            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

            if (!_dataConnectionValidator.Validate(dataConnection))
            {
                throw new Exception("Failed to validate data connection.");
            }
            _dataEndpoint.Import(dataConnection);
            _dataService.Import();
        }
    }
}