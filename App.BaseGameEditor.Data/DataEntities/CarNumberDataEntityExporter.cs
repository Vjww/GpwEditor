using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CarNumberDataEntityExporter : IDataEntityExporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IDataLocatorFactory<CarNumberDataLocator> _dataLocatorFactory;

        public CarNumberDataEntityExporter(
            DataEndpoint dataEndpoint,
            IDataLocatorFactory<CarNumberDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(IDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is CarNumberDataEntity carNumberDataEntity)) throw new ArgumentNullException(nameof(carNumberDataEntity));

            var dataLocator = _dataLocatorFactory.Create();
            dataLocator.Initialise(carNumberDataEntity.Id);

            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.ValueA, carNumberDataEntity.ValueA);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.ValueB, carNumberDataEntity.ValueB);
        }
    }
}