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
    public class LanguageDomainModelImportService
    {
        private const int LanguageItemCount = 7173;

        private readonly LanguageDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<LanguageEntity> _languageEntityFactory;
        private readonly IMapperService _mapperService;

        public LanguageDomainModelImportService(
            LanguageDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<LanguageEntity> languageEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _languageEntityFactory = languageEntityFactory ?? throw new ArgumentNullException(nameof(languageEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            var entities = new List<LanguageEntity>();
            for (var i = 0; i < LanguageItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.Languages.Get(x => x.Id == id).Single();

                var entity = _languageEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetLanguages(entities);
        }
    }
}