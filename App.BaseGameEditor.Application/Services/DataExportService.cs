using System;
using App.BaseGameEditor.Data.Services;
using App.Shared.Data.DataConnections;
using App.Shared.Data.DataEndpoints;

namespace App.BaseGameEditor.Application.Services
{
    public class DataExportService
    {
        private readonly DataService _dataService;
        private readonly DataEndpoint _dataEndpoint;

        public DataExportService(
            DataService dataService,
            DataEndpoint dataEndpoint)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
        }

        public void Export(DataConnection dataConnection)
        {
            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

            _dataService.Export();
            _dataEndpoint.Export(dataConnection);
        }
    }
}