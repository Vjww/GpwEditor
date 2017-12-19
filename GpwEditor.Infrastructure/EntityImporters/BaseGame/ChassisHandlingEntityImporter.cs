using System;
using Common.Editor.Data.Entities;
using GpwEditor.Infrastructure.DataEndpoints;
using GpwEditor.Infrastructure.DataLocators;
using GpwEditor.Infrastructure.Factories.BaseGame;

namespace GpwEditor.Infrastructure.EntityImporters.BaseGame
{
    public class ChassisHandlingEntityImporter : IEntityImporter
    {
        private readonly BaseGameDataEndpoint _dataEndpoint;
        private readonly ChassisHandlingDataLocator _dataLocator;
        private readonly ChassisHandlingEntityFactory _entityFactory;

        public ChassisHandlingEntityImporter(
            BaseGameDataEndpoint dataEndpoint,
            ChassisHandlingDataLocator dataLocator,
            ChassisHandlingEntityFactory entityFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
            _entityFactory = entityFactory ?? throw new ArgumentNullException(nameof(entityFactory));
        }

        public IEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var entity = _entityFactory.Create(id);

            entity.TeamId = entity.Id;
            entity.Value = _dataEndpoint.GameExecutableResource.ReadInteger(_dataLocator.Value);

            return entity;
        }
    }
}