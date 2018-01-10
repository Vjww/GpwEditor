using System;
using App.BaseGameEditor.Data.DataConnections;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Infrastructure.DataConnections;

namespace App.BaseGameEditor.Application.Services
{
    public class DataExportService// TODO: remove interface : IDataExportService<DataConnection>
    {
        private readonly DataConnectionValidator _dataConnectionValidator;
        private readonly DataService _dataService;
        private readonly BaseGameDataEndpoint _dataEndpoint;

        public DataExportService(
            DataConnectionValidator dataConnectionValidator,
            DataService dataService,
            BaseGameDataEndpoint dataEndpoint)
        {
            _dataConnectionValidator = dataConnectionValidator ?? throw new ArgumentNullException(nameof(dataConnectionValidator));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
        }

        public void Export(DataConnection dataConnection)
        {
            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

            if (!_dataConnectionValidator.Validate(dataConnection))
            {
                throw new Exception("Failed to validate data connection.");
            }
            _dataService.Export();
            _dataEndpoint.Export(dataConnection);
        }
    }
}