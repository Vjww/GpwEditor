using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Factories;
using App.BaseGameEditor.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services
{
    public class PersonDomainModelImportService
    {
        private const int F1ChiefItemCount = 11;

        private readonly PersonService _domainService;
        private readonly DataService _dataService;
        private readonly EntityFactory<F1ChiefCommercialEntity> _f1ChiefCommercialEntityFactory;
        private readonly IMapperService _mapperService;

        public PersonDomainModelImportService(
            PersonService domainService,
            DataService dataService,
            EntityFactory<F1ChiefCommercialEntity> f1ChiefCommercialEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _f1ChiefCommercialEntityFactory = f1ChiefCommercialEntityFactory ?? throw new ArgumentNullException(nameof(f1ChiefCommercialEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            ImportF1ChiefCommercials();
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
    }
}