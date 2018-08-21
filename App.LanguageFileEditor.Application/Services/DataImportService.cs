using System;
using App.BaseGameEditor.Data.DataConnections;
using App.BaseGameEditor.Data.DataEndpoints;
using App.LanguageFileEditor.Data.Services;

namespace App.LanguageFileEditor.Application.Services
{
    public class DataImportService
    {
        private readonly DataService _dataService;
        private readonly DataEndpoint _dataEndpoint;

        public DataImportService(
            DataService dataService,
            DataEndpoint dataEndpoint)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
        }

        public void Import(DataConnection dataConnection)
        {
            if (dataConnection == null) throw new ArgumentNullException(nameof(dataConnection));

            _dataEndpoint.Import(dataConnection);
            _dataService.Import();
        }
    }
}