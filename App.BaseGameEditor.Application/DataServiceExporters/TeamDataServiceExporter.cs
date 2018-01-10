using System;
using App.BaseGameEditor.Application.DataServices;
using App.BaseGameEditor.Infrastructure.Mappers;

namespace App.BaseGameEditor.Application.DataServiceExporters
{
    public class TeamDataServiceExporter
    {
        private readonly TeamDataService _dataService;
        private readonly TeamModelToDataContextMapper _mapper;

        public TeamDataServiceExporter(
            TeamDataService dataService,
            TeamModelToDataContextMapper mapper)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void Export()
        {
            var items = _dataService.Get();
            foreach (var item in items)
            {
                _mapper.Map(item);
            }
        }
    }
}