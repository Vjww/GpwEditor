using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Services;
using App.Core.Factories;
using App.Shared.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class SupplierDomainModelImportService
    {
        private const int EngineItemCount = 8;
        private const int TyreItemCount = 3;
        private const int FuelItemCount = 9;

        private readonly SupplierDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<EngineEntity> _engineEntityFactory;
        private readonly IIntegerIdentityFactory<TyreEntity> _tyreEntityFactory;
        private readonly IIntegerIdentityFactory<FuelEntity> _fuelEntityFactory;
        private readonly IMapperService _mapperService;

        public SupplierDomainModelImportService(
            SupplierDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<EngineEntity> engineEntityFactory,
            IIntegerIdentityFactory<TyreEntity> tyreEntityFactory,
            IIntegerIdentityFactory<FuelEntity> fuelEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _engineEntityFactory = engineEntityFactory ?? throw new ArgumentNullException(nameof(engineEntityFactory));
            _tyreEntityFactory = tyreEntityFactory ?? throw new ArgumentNullException(nameof(tyreEntityFactory));
            _fuelEntityFactory = fuelEntityFactory ?? throw new ArgumentNullException(nameof(fuelEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            ImportEngines();
            ImportTyres();
            ImportFuels();
        }

        private void ImportEngines()
        {
            var entities = new List<EngineEntity>();
            for (var i = 0; i < EngineItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.Engines.Get(x => x.Id == id).Single();

                var entity = _engineEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetEngines(entities);
        }

        private void ImportTyres()
        {
            var entities = new List<TyreEntity>();
            for (var i = 0; i < TyreItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.Tyres.Get(x => x.Id == id).Single();

                var entity = _tyreEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetTyres(entities);
        }

        private void ImportFuels()
        {
            var entities = new List<FuelEntity>();
            for (var i = 0; i < FuelItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.Fuels.Get(x => x.Id == id).Single();

                var entity = _fuelEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetFuels(entities);
        }
    }
}