using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class SupplierDomainModelExportService
    {
        private readonly SupplierDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<EngineDataEntity> _engineDataEntityFactory;
        private readonly IIntegerIdentityFactory<TyreDataEntity> _tyreDataEntityFactory;
        private readonly IIntegerIdentityFactory<FuelDataEntity> _fuelDataEntityFactory;
        private readonly IMapperService _mapperService;

        public SupplierDomainModelExportService(
            SupplierDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<EngineDataEntity> engineDataEntityFactory,
            IIntegerIdentityFactory<TyreDataEntity> tyreDataEntityFactory,
            IIntegerIdentityFactory<FuelDataEntity> fuelDataEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _engineDataEntityFactory = engineDataEntityFactory ?? throw new ArgumentNullException(nameof(engineDataEntityFactory));
            _tyreDataEntityFactory = tyreDataEntityFactory ?? throw new ArgumentNullException(nameof(tyreDataEntityFactory));
            _fuelDataEntityFactory = fuelDataEntityFactory ?? throw new ArgumentNullException(nameof(fuelDataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Export()
        {
            ExportEngines();
            ExportFuels();
            ExportTyres();
        }

        private void ExportEngines()
        {
            var entities = _domainService.GetEngines();
            foreach (var item in entities)
            {
                var dataEntity = _engineDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.Engines.SetById(dataEntity);
            }
        }

        private void ExportTyres()
        {
            var entities = _domainService.GetTyres();
            foreach (var item in entities)
            {
                var dataEntity = _tyreDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.Tyres.SetById(dataEntity);
            }
        }

        private void ExportFuels()
        {
            var entities = _domainService.GetFuels();
            foreach (var item in entities)
            {
                var dataEntity = _fuelDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.Fuels.SetById(dataEntity);
            }
        }
    }
}