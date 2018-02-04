using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CarNumberDataEntityExportService : IDataEntityExportService<CarNumberDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IDataLocatorFactory<CarNumberDataLocator> _dataLocatorFactory;

        public CarNumberDataEntityExportService(
            DataEndpoint dataEndpoint,
            IDataLocatorFactory<CarNumberDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(CarNumberDataEntity dataEntity)
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