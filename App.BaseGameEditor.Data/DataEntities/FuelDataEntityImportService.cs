using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class FuelDataEntityImportService : IDataEntityImportService<FuelDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<FuelDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<FuelDataLocator> _dataLocatorFactory;

        public FuelDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<FuelDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<FuelDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public FuelDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Performance = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Performance);
            result.Tolerance = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Tolerance);

            return result;
        }
    }
}