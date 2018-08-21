using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class F1ChiefCommercialDataEntityExportService : IDataEntityExportService<F1ChiefCommercialDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<F1ChiefCommercialDataLocator> _dataLocatorFactory;

        public F1ChiefCommercialDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<F1ChiefCommercialDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(F1ChiefCommercialDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is F1ChiefCommercialDataEntity f1ChiefCommercialDataEntity)) throw new ArgumentNullException(nameof(f1ChiefCommercialDataEntity));

            var dataLocator = _dataLocatorFactory.Create(f1ChiefCommercialDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);

            englishCatalogueItem.Value = f1ChiefCommercialDataEntity.Name.English;
            frenchCatalogueItem.Value = f1ChiefCommercialDataEntity.Name.French;
            germanCatalogueItem.Value = f1ChiefCommercialDataEntity.Name.German;

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, englishCatalogueItem);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, frenchCatalogueItem);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, germanCatalogueItem);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Ability, f1ChiefCommercialDataEntity.Ability);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Age, f1ChiefCommercialDataEntity.Age);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Salary, f1ChiefCommercialDataEntity.Salary);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Royalty, f1ChiefCommercialDataEntity.Royalty);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Morale, f1ChiefCommercialDataEntity.Morale);
        }
    }
}