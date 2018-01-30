using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataEntityExporters
{
    public class ChassisHandlingDataEntityExporter : IDataEntityExporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly ChassisHandlingDataLocator _dataLocator;

        public ChassisHandlingDataEntityExporter(DataEndpoint dataEndpoint, ChassisHandlingDataLocator dataLocator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
        }

        public void Export(IDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is ChassisHandlingDataEntity chassisHandlingDataEntity)) throw new ArgumentNullException(nameof(chassisHandlingDataEntity));

            _dataLocator.Initialise(chassisHandlingDataEntity.Id);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.Value, chassisHandlingDataEntity.Value);
        }
    }
}