using System;
using App.Shared.Data.DataEndpoints;
using App.LanguageFileEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.Services;

namespace App.LanguageFileEditor.Data.DataEntities
{
    public class LanguageDataEntityExportService : IDataEntityExportService<LanguageDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<LanguageDataLocator> _dataLocatorFactory;

        public LanguageDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<LanguageDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(LanguageDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is LanguageDataEntity languageTeamDataEntity)) throw new ArgumentNullException(nameof(languageTeamDataEntity));

            var dataLocator = _dataLocatorFactory.Create(languageTeamDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Id);
            var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Id);
            var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Id);

            englishCatalogueItem.Value = languageTeamDataEntity.EnglishValue;
            frenchCatalogueItem.Value = languageTeamDataEntity.FrenchValue;
            germanCatalogueItem.Value = languageTeamDataEntity.GermanValue;

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Id, englishCatalogueItem);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Id, frenchCatalogueItem);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Id, germanCatalogueItem);
        }
    }
}