using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

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

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, fuelDataEntity.Name.English);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, fuelDataEntity.Name.French);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, fuelDataEntity.Name.German);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Performance, fuelDataEntity.Performance);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Tolerance, fuelDataEntity.Tolerance);
        }
    }
}