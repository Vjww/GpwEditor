using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CarNumberDataEntityImporter : IDataEntityImporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly DataEntityFactory<CarNumberDataEntity> _dataEntityFactory;
        private readonly DataLocatorFactory<CarNumberDataLocator> _dataLocatorFactory;

        public CarNumberDataEntityImporter(
            DataEndpoint dataEndpoint,
            DataEntityFactory<CarNumberDataEntity> dataEntityFactory,
            DataLocatorFactory<CarNumberDataLocator> dataLocatorFactory)
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
            result.TeamId = result.Id / 2;
            result.PositionId = result.Id % 2;
            result.ValueA = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ValueA);
            result.ValueB = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ValueB);

            return result;
        }
    }
}