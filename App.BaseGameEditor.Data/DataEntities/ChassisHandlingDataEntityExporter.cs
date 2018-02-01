using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class ChassisHandlingDataEntityExporter : IDataEntityExporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly DataLocatorFactory<ChassisHandlingDataLocator> _dataLocatorFactory;

        public ChassisHandlingDataEntityExporter(
            DataEndpoint dataEndpoint,
            DataLocatorFactory<ChassisHandlingDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(IDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is ChassisHandlingDataEntity chassisHandlingDataEntity)) throw new ArgumentNullException(nameof(chassisHandlingDataEntity));

            var dataLocator = _dataLocatorFactory.Create();
            dataLocator.Initialise(chassisHandlingDataEntity.Id);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Value, chassisHandlingDataEntity.Value);
        }
    }
}