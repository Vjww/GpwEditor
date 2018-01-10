using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Entities;
using Common.Editor.Data.Entities;

namespace App.BaseGameEditor.Data.EntityExporters
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

            _dataLocator.Initialise(carNumberEntity.Id);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.ValueA, carNumberEntity.ValueA);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.ValueB, carNumberEntity.ValueB);
        }
    }
}