using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class FuelDataEntityExportService : IDataEntityExportService<FuelDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<FuelDataLocator> _dataLocatorFactory;

        public FuelDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<FuelDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(FuelDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is FuelDataEntity fuelDataEntity)) throw new ArgumentNullException(nameof(fuelDataEntity));

            var dataLocator = _dataLocatorFactory.Create(fuelDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);

            englishCatalogueItem.Value = fuelDataEntity.Name.English;
            frenchCatalogueItem.Value = fuelDataEntity.Name.French;
            germanCatalogueItem.Value = fuelDataEntity.Name.German;

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, englishCatalogueItem);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, frenchCatalogueItem);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, germanCatalogueItem);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Performance, fuelDataEntity.Performance);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Tolerance, fuelDataEntity.Tolerance);
        }
    }
}