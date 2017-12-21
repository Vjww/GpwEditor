using System;
using Common.Editor.Data.Entities;
using GpwEditor.Infrastructure.DataEndpoints;
using GpwEditor.Infrastructure.DataLocators;
using GpwEditor.Infrastructure.Factories.Entities.BaseGame;

namespace GpwEditor.Infrastructure.EntityImporters.BaseGame
{
    public class TeamEntityImporter : IEntityImporter<IEntity>
    {
        private readonly BaseGameDataEndpoint _dataEndpoint;
        private readonly TeamDataLocator _dataLocator;
        private readonly TeamEntityFactory _entityFactory;

        public TeamEntityImporter(
            BaseGameDataEndpoint dataEndpoint,
            TeamDataLocator dataLocator,
            TeamEntityFactory entityFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
            _entityFactory = entityFactory ?? throw new ArgumentNullException(nameof(entityFactory));
        }

        public IEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var entity = _entityFactory.Create(id);

            entity.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(_dataLocator.Name);
            entity.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(_dataLocator.Name);
            entity.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(_dataLocator.Name);
            entity.LastPosition = _dataEndpoint.GameExecutableResource.ReadInteger(_dataLocator.LastPosition);
            entity.LastPoints = _dataEndpoint.GameExecutableResource.ReadInteger(_dataLocator.LastPoints);
            entity.FirstGpTrack = _dataEndpoint.GameExecutableResource.ReadInteger(_dataLocator.FirstGpTrack);
            entity.FirstGpYear = _dataEndpoint.GameExecutableResource.ReadInteger(_dataLocator.FirstGpYear);
            entity.Wins = _dataEndpoint.GameExecutableResource.ReadInteger(_dataLocator.Wins);
            entity.YearlyBudget = _dataEndpoint.GameExecutableResource.ReadInteger(_dataLocator.YearlyBudget);
            entity.UnknownA = _dataEndpoint.GameExecutableResource.ReadInteger(_dataLocator.UnknownA);
            entity.CountryMapId = _dataEndpoint.GameExecutableResource.ReadInteger(_dataLocator.CountryMapId);
            entity.LocationPointerX = _dataEndpoint.GameExecutableResource.ReadInteger(_dataLocator.LocationPointerX);
            entity.LocationPointerY = _dataEndpoint.GameExecutableResource.ReadInteger(_dataLocator.LocationPointerY);
            entity.TyreSupplierId = _dataEndpoint.GameExecutableResource.ReadInteger(_dataLocator.TyreSupplierId);

            return entity;
        }
    }
}