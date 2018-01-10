using System;
using App.BaseGameEditor.Data.DataConnections;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.Services;

namespace App.BaseGameEditor.Application.Services
{
    public class DataExportService// TODO: remove interface : IDataExportService<DataConnection>
    {
        private readonly DataService _dataService;
        private readonly BaseGameDataEndpoint _dataEndpoint;

        public DataExportService(
            DataService dataService,
            BaseGameDataEndpoint dataEndpoint)
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