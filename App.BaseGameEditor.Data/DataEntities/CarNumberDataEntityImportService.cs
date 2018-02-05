using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class CarNumberDataEntityImportService : IDataEntityImportService<CarNumberDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IEntityFactory<CarNumberDataEntity> _entityFactory;
        private readonly IDataLocatorFactory<CarNumberDataLocator> _dataLocatorFactory;

        public CarNumberDataEntityImportService(
            DataEndpoint dataEndpoint,
            IEntityFactory<CarNumberDataEntity> entityFactory,
            IDataLocatorFactory<CarNumberDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _entityFactory = entityFactory ?? throw new ArgumentNullException(nameof(entityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public CarNumberDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create();
            dataLocator.Initialise(id);

            var result = _entityFactory.Create(id);
            result.TeamId = result.Id / 2;
            result.PositionId = result.Id % 2;
            result.ValueA = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ValueA);
            result.ValueB = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.ValueB);

            return result;
        }
    }
}