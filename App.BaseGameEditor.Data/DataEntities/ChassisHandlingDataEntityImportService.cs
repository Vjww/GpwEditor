using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class ChassisHandlingDataEntityImportService : IDataEntityImportService<ChassisHandlingDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IEntityFactory<ChassisHandlingDataEntity> _entityFactory;
        private readonly IDataLocatorFactory<ChassisHandlingDataLocator> _dataLocatorFactory;

        public ChassisHandlingDataEntityImportService(
            DataEndpoint dataEndpoint,
            IEntityFactory<ChassisHandlingDataEntity> entityFactory,
            IDataLocatorFactory<ChassisHandlingDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _entityFactory = entityFactory ?? throw new ArgumentNullException(nameof(entityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public ChassisHandlingDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create();
            dataLocator.Initialise(id);

            var result = _entityFactory.Create(id);
            result.TeamId = result.Id;
            result.Value = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Value);

            return result;
        }
    }
}