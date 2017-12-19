using System;
using Common.Editor.Data.Entities;
using GpwEditor.Infrastructure.DataEndpoints;
using GpwEditor.Infrastructure.DataLocators;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Infrastructure.EntityExporters.BaseGame
{
    public class CarNumberEntityExporter : IEntityExporter
    {
        private readonly BaseGameDataEndpoint _dataEndpoint;
        private readonly CarNumberDataLocator _dataLocator;

        public CarNumberEntityExporter(BaseGameDataEndpoint dataEndpoint, CarNumberDataLocator dataLocator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
        }

        public void Export(IEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (!(entity is CarNumberEntity carNumberEntity)) throw new ArgumentNullException(nameof(carNumberEntity));

            _dataLocator.Map(carNumberEntity.Id);

            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.ValueA, carNumberEntity.ValueA);
            _dataEndpoint.GameExecutableResource.WriteInteger(_dataLocator.ValueB, carNumberEntity.ValueB);
        }
    }
}