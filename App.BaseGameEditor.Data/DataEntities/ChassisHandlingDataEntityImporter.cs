using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class ChassisHandlingDataEntityImporter : IDataEntityImporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly ChassisHandlingDataLocator _dataLocator;
        private readonly DataEntityFactory<ChassisHandlingDataEntity> _factory;

        public ChassisHandlingDataEntityImporter(
            DataEndpoint dataEndpoint,
            ChassisHandlingDataLocator dataLocator,
            DataEntityFactory<ChassisHandlingDataEntity> factory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            _dataLocator.Initialise(id);

            var result = _factory.Create(id);
            result.TeamId = result.Id;
            result.Value = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.Value);

            return result;
        }
    }
}