using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Factories;
using App.BaseGameEditor.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services
{
    public class PersonDomainModelExportService
    {
        private readonly PersonService _domainService;
        private readonly DataService _dataService;
        private readonly EntityFactory<F1ChiefCommercialDataEntity> _f1ChiefCommercialDataEntityFactory;
        private readonly EntityFactory<F1ChiefDesignerDataEntity> _f1ChiefDesignerDataEntityFactory;
        private readonly EntityFactory<F1ChiefEngineerDataEntity> _f1ChiefEngineerDataEntityFactory;
        private readonly EntityFactory<F1ChiefMechanicDataEntity> _f1ChiefMechanicDataEntityFactory;
        private readonly EntityFactory<F1DriverDataEntity> _f1DriverDataEntityFactory;
        private readonly IMapperService _mapperService;

        public PersonDomainModelExportService(
            PersonService domainService,
            DataService dataService,
            EntityFactory<F1ChiefCommercialDataEntity> f1ChiefCommercialDataEntityFactory,
            EntityFactory<F1ChiefDesignerDataEntity> f1ChiefDesignerDataEntityFactory,
            EntityFactory<F1ChiefEngineerDataEntity> f1ChiefEngineerDataEntityFactory,
            EntityFactory<F1ChiefMechanicDataEntity> f1ChiefMechanicDataEntityFactory,
            EntityFactory<F1DriverDataEntity> f1DriverDataEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _f1ChiefCommercialDataEntityFactory = f1ChiefCommercialDataEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefCommercialDataEntityFactory));
            _f1ChiefDesignerDataEntityFactory = f1ChiefDesignerDataEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefDesignerDataEntityFactory));
            _f1ChiefEngineerDataEntityFactory = f1ChiefEngineerDataEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefEngineerDataEntityFactory));
            _f1ChiefMechanicDataEntityFactory = f1ChiefMechanicDataEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefMechanicDataEntityFactory));
            _f1DriverDataEntityFactory = f1DriverDataEntityFactory ?? throw new ArgumentNullException(nameof(f1DriverDataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Export()
        {
            ExportF1ChiefCommercials();
            ExportF1ChiefDesigners();
            ExportF1ChiefEngineers();
            ExportF1ChiefMechanics();
            ExportF1Drivers();
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

        private void ExportF1ChiefDesigners()
        {
            var entities = _domainService.GetF1ChiefDesigners();
            foreach (var item in entities)
            {
                var dataEntity = _f1ChiefDesignerDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.F1ChiefDesigners.SetById(dataEntity);
            }
        }

        private void ExportF1ChiefEngineers()
        {
            var entities = _domainService.GetF1ChiefEngineers();
            foreach (var item in entities)
            {
                var dataEntity = _f1ChiefEngineerDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.F1ChiefEngineers.SetById(dataEntity);
            }
        }

        private void ExportF1ChiefMechanics()
        {
            var entities = _domainService.GetF1ChiefMechanics();
            foreach (var item in entities)
            {
                var dataEntity = _f1ChiefMechanicDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.F1ChiefMechanics.SetById(dataEntity);
            }
        }

        private void ExportF1Drivers()
        {
            var entities = _domainService.GetF1Drivers();
            foreach (var item in entities)
            {
                var dataEntity = _f1DriverDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.F1Drivers.SetById(dataEntity);
            }
        }
    }
}