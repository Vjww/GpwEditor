using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class LanguageDataEntityImportService : IDataEntityImportService<LanguageDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<LanguageDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<LanguageDataLocator> _dataLocatorFactory;

        public LanguageDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<LanguageDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<LanguageDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public LanguageDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Index = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Id).Key;
            result.EnglishValue = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Id).Value;
            result.FrenchValue = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Id).Value;
            result.GermanValue = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Id).Value;

            return result;
        }
    }
}