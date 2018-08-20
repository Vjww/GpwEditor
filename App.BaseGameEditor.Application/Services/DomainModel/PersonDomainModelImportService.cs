using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class PersonDomainModelImportService
    {
        private const int F1ChiefItemCount = 11;
        private const int F1DriverItemCount = 33;
        private const int NonF1ChiefItemCount = 10;
        private const int NonF1DriverItemCount = 11;

        private readonly PersonDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<F1ChiefCommercialEntity> _f1ChiefCommercialEntityFactory;
        private readonly IIntegerIdentityFactory<F1ChiefDesignerEntity> _f1ChiefDesignerEntityFactory;
        private readonly IIntegerIdentityFactory<F1ChiefEngineerEntity> _f1ChiefEngineerEntityFactory;
        private readonly IIntegerIdentityFactory<F1ChiefMechanicEntity> _f1ChiefMechanicEntityFactory;
        private readonly IIntegerIdentityFactory<F1DriverEntity> _f1DriverEntityFactory;
        private readonly IIntegerIdentityFactory<NonF1ChiefCommercialEntity> _nonF1ChiefCommercialEntityFactory;
        private readonly IIntegerIdentityFactory<NonF1ChiefDesignerEntity> _nonF1ChiefDesignerEntityFactory;
        private readonly IIntegerIdentityFactory<NonF1ChiefEngineerEntity> _nonF1ChiefEngineerEntityFactory;
        private readonly IIntegerIdentityFactory<NonF1ChiefMechanicEntity> _nonF1ChiefMechanicEntityFactory;
        private readonly IIntegerIdentityFactory<NonF1DriverEntity> _nonF1DriverEntityFactory;
        private readonly IMapperService _mapperService;

        public PersonDomainModelImportService(
            PersonDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<F1ChiefCommercialEntity> f1ChiefCommercialEntityFactory,
            IIntegerIdentityFactory<F1ChiefDesignerEntity> f1ChiefDesignerEntityFactory,
            IIntegerIdentityFactory<F1ChiefEngineerEntity> f1ChiefEngineerEntityFactory,
            IIntegerIdentityFactory<F1ChiefMechanicEntity> f1ChiefMechanicEntityFactory,
            IIntegerIdentityFactory<F1DriverEntity> f1DriverEntityFactory,
            IIntegerIdentityFactory<NonF1ChiefCommercialEntity> nonF1ChiefCommercialEntityFactory,
            IIntegerIdentityFactory<NonF1ChiefDesignerEntity> nonF1ChiefDesignerEntityFactory,
            IIntegerIdentityFactory<NonF1ChiefEngineerEntity> nonF1ChiefEngineerEntityFactory,
            IIntegerIdentityFactory<NonF1ChiefMechanicEntity> nonF1ChiefMechanicEntityFactory,
            IIntegerIdentityFactory<NonF1DriverEntity> nonF1DriverEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _f1ChiefCommercialEntityFactory = f1ChiefCommercialEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefCommercialEntityFactory));
            _f1ChiefDesignerEntityFactory = f1ChiefDesignerEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefDesignerEntityFactory));
            _f1ChiefEngineerEntityFactory = f1ChiefEngineerEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefEngineerEntityFactory));
            _f1ChiefMechanicEntityFactory = f1ChiefMechanicEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefMechanicEntityFactory));
            _f1DriverEntityFactory = f1DriverEntityFactory ?? throw new ArgumentNullException(nameof(f1DriverEntityFactory));
            _nonF1ChiefCommercialEntityFactory = nonF1ChiefCommercialEntityFactory ?? throw new ArgumentNullException(nameof(nonF1ChiefCommercialEntityFactory));
            _nonF1ChiefDesignerEntityFactory = nonF1ChiefDesignerEntityFactory ?? throw new ArgumentNullException(nameof(nonF1ChiefDesignerEntityFactory));
            _nonF1ChiefEngineerEntityFactory = nonF1ChiefEngineerEntityFactory ?? throw new ArgumentNullException(nameof(nonF1ChiefEngineerEntityFactory));
            _nonF1ChiefMechanicEntityFactory = nonF1ChiefMechanicEntityFactory ?? throw new ArgumentNullException(nameof(nonF1ChiefMechanicEntityFactory));
            _nonF1DriverEntityFactory = nonF1DriverEntityFactory ?? throw new ArgumentNullException(nameof(nonF1DriverEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            ImportF1ChiefCommercials();
            ImportF1ChiefDesigners();
            ImportF1ChiefEngineers();
            ImportF1ChiefMechanics();
            ImportF1Drivers();
            ImportNonF1ChiefCommercials();
            ImportNonF1ChiefDesigners();
            ImportNonF1ChiefEngineers();
            ImportNonF1ChiefMechanics();
            ImportNonF1Drivers();
        }

        private void ImportF1ChiefCommercials()
        {
            var entities = new List<F1ChiefCommercialEntity>();
            for (var i = 0; i < F1ChiefItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.F1ChiefCommercials.Get(x => x.Id == id).Single();

                var entity = _f1ChiefCommercialEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetF1ChiefCommercials(entities);
        }

        private void ImportF1ChiefDesigners()
        {
            var entities = new List<F1ChiefDesignerEntity>();
            for (var i = 0; i < F1ChiefItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.F1ChiefDesigners.Get(x => x.Id == id).Single();

                var entity = _f1ChiefDesignerEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetF1ChiefDesigners(entities);
        }

        private void ImportF1ChiefEngineers()
        {
            var entities = new List<F1ChiefEngineerEntity>();
            for (var i = 0; i < F1ChiefItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.F1ChiefEngineers.Get(x => x.Id == id).Single();

                var entity = _f1ChiefEngineerEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetF1ChiefEngineers(entities);
        }

        private void ImportF1ChiefMechanics()
        {
            var entities = new List<F1ChiefMechanicEntity>();
            for (var i = 0; i < F1ChiefItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.F1ChiefMechanics.Get(x => x.Id == id).Single();

                var entity = _f1ChiefMechanicEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetF1ChiefMechanics(entities);
        }

        private void ImportF1Drivers()
        {
            var entities = new List<F1DriverEntity>();
            for (var i = 0; i < F1DriverItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.F1Drivers.Get(x => x.Id == id).Single();

                var entity = _f1DriverEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetF1Drivers(entities);
        }

        private void ImportNonF1ChiefCommercials()
        {
            var entities = new List<NonF1ChiefCommercialEntity>();
            for (var i = 0; i < NonF1ChiefItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.NonF1ChiefCommercials.Get(x => x.Id == id).Single();

                var entity = _nonF1ChiefCommercialEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetNonF1ChiefCommercials(entities);
        }

        private void ImportNonF1ChiefDesigners()
        {
            var entities = new List<NonF1ChiefDesignerEntity>();
            for (var i = 0; i < NonF1ChiefItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.NonF1ChiefDesigners.Get(x => x.Id == id).Single();

                var entity = _nonF1ChiefDesignerEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetNonF1ChiefDesigners(entities);
        }

        private void ImportNonF1ChiefEngineers()
        {
            var entities = new List<NonF1ChiefEngineerEntity>();
            for (var i = 0; i < NonF1ChiefItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.NonF1ChiefEngineers.Get(x => x.Id == id).Single();

                var entity = _nonF1ChiefEngineerEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetNonF1ChiefEngineers(entities);
        }

        private void ImportNonF1ChiefMechanics()
        {
            var entities = new List<NonF1ChiefMechanicEntity>();
            for (var i = 0; i < NonF1ChiefItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.NonF1ChiefMechanics.Get(x => x.Id == id).Single();

                var entity = _nonF1ChiefMechanicEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetNonF1ChiefMechanics(entities);
        }

        private void ImportNonF1Drivers()
        {
            var entities = new List<NonF1DriverEntity>();
            for (var i = 0; i < NonF1DriverItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.NonF1Drivers.Get(x => x.Id == id).Single();

                var entity = _nonF1DriverEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetNonF1Drivers(entities);
        }
    }
}