using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class PersonDomainModelExportService
    {
        private readonly PersonDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<F1ChiefCommercialDataEntity> _f1ChiefCommercialDataEntityFactory;
        private readonly IIntegerIdentityFactory<F1ChiefDesignerDataEntity> _f1ChiefDesignerDataEntityFactory;
        private readonly IIntegerIdentityFactory<F1ChiefEngineerDataEntity> _f1ChiefEngineerDataEntityFactory;
        private readonly IIntegerIdentityFactory<F1ChiefMechanicDataEntity> _f1ChiefMechanicDataEntityFactory;
        private readonly IIntegerIdentityFactory<F1DriverDataEntity> _f1DriverDataEntityFactory;
        private readonly IIntegerIdentityFactory<NonF1ChiefCommercialDataEntity> _nonF1ChiefCommercialDataEntityFactory;
        private readonly IIntegerIdentityFactory<NonF1ChiefDesignerDataEntity> _nonF1ChiefDesignerDataEntityFactory;
        private readonly IIntegerIdentityFactory<NonF1ChiefEngineerDataEntity> _nonF1ChiefEngineerDataEntityFactory;
        private readonly IIntegerIdentityFactory<NonF1ChiefMechanicDataEntity> _nonF1ChiefMechanicDataEntityFactory;
        private readonly IIntegerIdentityFactory<NonF1DriverDataEntity> _nonF1DriverDataEntityFactory;
        private readonly IMapperService _mapperService;

        public PersonDomainModelExportService(
            PersonDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<F1ChiefCommercialDataEntity> f1ChiefCommercialDataEntityFactory,
            IIntegerIdentityFactory<F1ChiefDesignerDataEntity> f1ChiefDesignerDataEntityFactory,
            IIntegerIdentityFactory<F1ChiefEngineerDataEntity> f1ChiefEngineerDataEntityFactory,
            IIntegerIdentityFactory<F1ChiefMechanicDataEntity> f1ChiefMechanicDataEntityFactory,
            IIntegerIdentityFactory<F1DriverDataEntity> f1DriverDataEntityFactory,
            IIntegerIdentityFactory<NonF1ChiefCommercialDataEntity> nonF1ChiefCommercialDataEntityFactory,
            IIntegerIdentityFactory<NonF1ChiefDesignerDataEntity> nonF1ChiefDesignerDataEntityFactory,
            IIntegerIdentityFactory<NonF1ChiefEngineerDataEntity> nonF1ChiefEngineerDataEntityFactory,
            IIntegerIdentityFactory<NonF1ChiefMechanicDataEntity> nonF1ChiefMechanicDataEntityFactory,
            IIntegerIdentityFactory<NonF1DriverDataEntity> nonF1DriverDataEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _f1ChiefCommercialDataEntityFactory = f1ChiefCommercialDataEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefCommercialDataEntityFactory));
            _f1ChiefDesignerDataEntityFactory = f1ChiefDesignerDataEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefDesignerDataEntityFactory));
            _f1ChiefEngineerDataEntityFactory = f1ChiefEngineerDataEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefEngineerDataEntityFactory));
            _f1ChiefMechanicDataEntityFactory = f1ChiefMechanicDataEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefMechanicDataEntityFactory));
            _f1DriverDataEntityFactory = f1DriverDataEntityFactory ?? throw new ArgumentNullException(nameof(f1DriverDataEntityFactory));
            _nonF1ChiefCommercialDataEntityFactory = nonF1ChiefCommercialDataEntityFactory ?? throw new ArgumentNullException(nameof(nonF1ChiefCommercialDataEntityFactory));
            _nonF1ChiefDesignerDataEntityFactory = nonF1ChiefDesignerDataEntityFactory ?? throw new ArgumentNullException(nameof(nonF1ChiefDesignerDataEntityFactory));
            _nonF1ChiefEngineerDataEntityFactory = nonF1ChiefEngineerDataEntityFactory ?? throw new ArgumentNullException(nameof(nonF1ChiefEngineerDataEntityFactory));
            _nonF1ChiefMechanicDataEntityFactory = nonF1ChiefMechanicDataEntityFactory ?? throw new ArgumentNullException(nameof(nonF1ChiefMechanicDataEntityFactory));
            _nonF1DriverDataEntityFactory = nonF1DriverDataEntityFactory ?? throw new ArgumentNullException(nameof(nonF1DriverDataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Export()
        {
            ExportF1ChiefCommercials();
            ExportF1ChiefDesigners();
            ExportF1ChiefEngineers();
            ExportF1ChiefMechanics();
            ExportF1Drivers();
            ExportNonF1ChiefCommercials();
            ExportNonF1ChiefDesigners();
            ExportNonF1ChiefEngineers();
            ExportNonF1ChiefMechanics();
            ExportNonF1Drivers();
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

        private void ExportNonF1ChiefCommercials()
        {
            var entities = _domainService.GetNonF1ChiefCommercials();
            foreach (var item in entities)
            {
                var dataEntity = _nonF1ChiefCommercialDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.NonF1ChiefCommercials.SetById(dataEntity);
            }
        }

        private void ExportNonF1ChiefDesigners()
        {
            var entities = _domainService.GetNonF1ChiefDesigners();
            foreach (var item in entities)
            {
                var dataEntity = _nonF1ChiefDesignerDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.NonF1ChiefDesigners.SetById(dataEntity);
            }
        }

        private void ExportNonF1ChiefEngineers()
        {
            var entities = _domainService.GetNonF1ChiefEngineers();
            foreach (var item in entities)
            {
                var dataEntity = _nonF1ChiefEngineerDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.NonF1ChiefEngineers.SetById(dataEntity);
            }
        }

        private void ExportNonF1ChiefMechanics()
        {
            var entities = _domainService.GetNonF1ChiefMechanics();
            foreach (var item in entities)
            {
                var dataEntity = _nonF1ChiefMechanicDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.NonF1ChiefMechanics.SetById(dataEntity);
            }
        }

        private void ExportNonF1Drivers()
        {
            var entities = _domainService.GetNonF1Drivers();
            foreach (var item in entities)
            {
                var dataEntity = _nonF1DriverDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.NonF1Drivers.SetById(dataEntity);
            }
        }
    }
}