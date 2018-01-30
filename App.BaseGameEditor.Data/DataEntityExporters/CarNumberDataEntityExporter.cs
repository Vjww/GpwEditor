using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataEntityExporters
{
    public class CarNumberDataEntityExporter : IDataEntityExporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly CarNumberDataLocator _dataLocator;

        public CarNumberDataEntityExporter(DataEndpoint dataEndpoint, CarNumberDataLocator dataLocator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
        }

        public void Export(IDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is CarNumberDataEntity carNumberDataEntity)) throw new ArgumentNullException(nameof(carNumberDataEntity));

            _dataLocator.Initialise(carNumberDataEntity.Id);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.ValueA, carNumberDataEntity.ValueA);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.ValueB, carNumberDataEntity.ValueB);
        }
    }
}