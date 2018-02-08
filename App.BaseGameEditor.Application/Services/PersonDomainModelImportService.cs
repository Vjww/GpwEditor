using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Services;
using App.Core.Factories;
using App.ObjectMapping.Services;

namespace App.BaseGameEditor.Application.Services
{
    public class PersonDomainModelImportService
    {
        private const int F1ChiefItemCount = 11;
        private const int F1DriverItemCount = 33;

        private readonly PersonDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<F1ChiefCommercialEntity> _f1ChiefCommercialEntityFactory;
        private readonly IIntegerIdentityFactory<F1ChiefDesignerEntity> _f1ChiefDesignerEntityFactory;
        private readonly IIntegerIdentityFactory<F1ChiefEngineerEntity> _f1ChiefEngineerEntityFactory;
        private readonly IIntegerIdentityFactory<F1ChiefMechanicEntity> _f1ChiefMechanicEntityFactory;
        private readonly IIntegerIdentityFactory<F1DriverEntity> _f1DriverEntityFactory;
        private readonly IMapperService _mapperService;

        public PersonDomainModelImportService(
            PersonDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<F1ChiefCommercialEntity> f1ChiefCommercialEntityFactory,
            IIntegerIdentityFactory<F1ChiefDesignerEntity> f1ChiefDesignerEntityFactory,
            IIntegerIdentityFactory<F1ChiefEngineerEntity> f1ChiefEngineerEntityFactory,
            IIntegerIdentityFactory<F1ChiefMechanicEntity> f1ChiefMechanicEntityFactory,
            IIntegerIdentityFactory<F1DriverEntity> f1DriverEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _f1ChiefCommercialEntityFactory = f1ChiefCommercialEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefCommercialEntityFactory));
            _f1ChiefDesignerEntityFactory = f1ChiefDesignerEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefDesignerEntityFactory));
            _f1ChiefEngineerEntityFactory = f1ChiefEngineerEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefEngineerEntityFactory));
            _f1ChiefMechanicEntityFactory = f1ChiefMechanicEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefMechanicEntityFactory));
            _f1DriverEntityFactory = f1DriverEntityFactory ?? throw new ArgumentNullException(nameof(f1DriverEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            ImportF1ChiefCommercials();
            ImportF1ChiefDesigners();
            ImportF1ChiefEngineers();
            ImportF1ChiefMechanics();
            ImportF1Drivers();
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
    }
}