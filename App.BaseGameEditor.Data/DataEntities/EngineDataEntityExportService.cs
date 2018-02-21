using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class EngineDataEntityExportService : IDataEntityExportService<EngineDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<EngineDataLocator> _dataLocatorFactory;

        public EngineDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<EngineDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(EngineDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is EngineDataEntity engineDataEntity)) throw new ArgumentNullException(nameof(engineDataEntity));

            var dataLocator = _dataLocatorFactory.Create(engineDataEntity.Id);
            dataLocator.Initialise();

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, engineDataEntity.Name.English);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, engineDataEntity.Name.French);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, engineDataEntity.Name.German);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Fuel, engineDataEntity.Fuel);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Heat, engineDataEntity.Heat);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Power, engineDataEntity.Power);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Reliability, engineDataEntity.Reliability);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Response, engineDataEntity.Response);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Rigidity, engineDataEntity.Rigidity);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Weight, engineDataEntity.Weight);
        }
    }
}