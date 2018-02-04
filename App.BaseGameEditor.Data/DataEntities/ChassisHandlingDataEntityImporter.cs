using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class ChassisHandlingDataEntityImporter : IDataEntityImporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IDataEntityFactory<ChassisHandlingDataEntity> _dataEntityFactory;
        private readonly IDataLocatorFactory<ChassisHandlingDataLocator> _dataLocatorFactory;

        public ChassisHandlingDataEntityImporter(
            DataEndpoint dataEndpoint,
            IDataEntityFactory<ChassisHandlingDataEntity> dataEntityFactory,
            IDataLocatorFactory<ChassisHandlingDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public IDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create();
            dataLocator.Initialise(id);

            var result = _dataEntityFactory.Create(id);
            result.TeamId = result.Id;
            result.Value = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Value);

            return result;
        }
    }
}