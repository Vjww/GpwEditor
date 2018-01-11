using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Data.Factories.Entities;

namespace App.BaseGameEditor.Data.EntityImporters
{
    public class CarNumberEntityImporter : IEntityImporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly CarNumberDataLocator _dataLocator;
        private readonly CarNumberEntityFactory _entityFactory;

        public CarNumberEntityImporter(
            DataEndpoint dataEndpoint,
            CarNumberDataLocator dataLocator,
            CarNumberEntityFactory entityFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
            _entityFactory = entityFactory ?? throw new ArgumentNullException(nameof(entityFactory));
        }

        public IEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            _dataLocator.Initialise(id);

            var entity = _entityFactory.Create(id);

            entity.TeamId = entity.Id / 2;
            entity.PositionId = entity.Id % 2;
            entity.ValueA = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.ValueA);
            entity.ValueB = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.ValueB);

            return entity;
        }
    }
}