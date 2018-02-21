using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class EngineDataEntityImportService : IDataEntityImportService<EngineDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<EngineDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<EngineDataLocator> _dataLocatorFactory;

        public EngineDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<EngineDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<EngineDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public EngineDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);
            result.Fuel = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Fuel);
            result.Heat = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Heat);
            result.Power = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Power);
            result.Reliability = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Reliability);
            result.Response = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Response);
            result.Rigidity = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Rigidity);
            result.Weight = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Weight);

            return result;
        }
    }
}