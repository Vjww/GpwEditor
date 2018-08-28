using System;
using App.Core.Factories;
using App.LanguageFileEditor.Data.DataEntities;
using App.LanguageFileEditor.Data.Services;
using App.LanguageFileEditor.Domain.Services;
using App.Shared.Infrastructure.Services;

namespace App.LanguageFileEditor.Application.Services.DomainModel
{
    public class LanguageDomainModelExportService
    {
        private readonly LanguageDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<LanguageDataEntity> _languageDataEntityFactory;
        private readonly IMapperService _mapperService;

        public LanguageDomainModelExportService(
            LanguageDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<LanguageDataEntity> languageDataEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _languageDataEntityFactory = languageDataEntityFactory ?? throw new ArgumentNullException(nameof(languageDataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Export()
        {
            var entities = _domainService.GetLanguages();
            foreach (var item in entities)
            {
                var dataEntity = _languageDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.Languages.SetById(dataEntity);
            }
        }
    }
}