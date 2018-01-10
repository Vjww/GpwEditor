using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Entities;

namespace App.BaseGameEditor.Data.EntityExporters
{
    public class ChassisHandlingEntityExporter : IEntityExporter
    {
        private readonly BaseGameDataEndpoint _dataEndpoint;
        private readonly ChassisHandlingDataLocator _dataLocator;

        public ChassisHandlingEntityExporter(BaseGameDataEndpoint dataEndpoint, ChassisHandlingDataLocator dataLocator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
        }

        public void Export(IEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (!(entity is ChassisHandlingEntity chassisHandlingEntity)) throw new ArgumentNullException(nameof(chassisHandlingEntity));

            _dataLocator.Initialise(chassisHandlingEntity.Id);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.Value, chassisHandlingEntity.Value);
        }
    }
}