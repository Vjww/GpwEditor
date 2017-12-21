using System;
using Common.Editor.Data.Entities;
using GpwEditor.Infrastructure.DataEndpoints;
using GpwEditor.Infrastructure.DataLocators;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Infrastructure.EntityExporters.BaseGame
{
    public class ChassisHandlingEntityExporter : IEntityExporter<IEntity>
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

            _dataLocator.Map(chassisHandlingEntity.Id);

            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.Value, chassisHandlingEntity.Value);
        }
    }
}