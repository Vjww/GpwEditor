using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services
{
    public class PersonDomainModelExportService
    {
        private readonly PersonService _domainService;
        private readonly DataService _dataService;
        private readonly DataEntityFactory<F1ChiefCommercialDataEntity> _f1ChiefCommercialDataEntityFactory;
        private readonly IMapperService _mapperService;

        public PersonDomainModelExportService(
            PersonService domainService,
            DataService dataService,
            DataEntityFactory<F1ChiefCommercialDataEntity> f1ChiefCommercialDataEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _f1ChiefCommercialDataEntityFactory = f1ChiefCommercialDataEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefCommercialDataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Export()
        {
            ExportF1ChiefCommercials();
        }

        private void ExportF1ChiefCommercials()
        {
            var entities = _domainService.GetF1ChiefCommercials();
            foreach (var item in entities)
            {
                var dataEntity = _f1ChiefCommercialDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.F1ChiefCommercials.SetById(dataEntity);
            }
        }
    }
}