using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.EntityImporters
{
    public class TeamEntityImporter : IEntityImporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly TeamDataLocator _dataLocator;
        private readonly TeamEntityFactory _entityFactory;

        public TeamEntityImporter(
            DataEndpoint dataEndpoint,
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

            _dataLocator.Initialise(id);

            var entity = _entityFactory.Create(id);

            entity.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(_dataLocator.Name);
            entity.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(_dataLocator.Name);
            entity.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(_dataLocator.Name);
            entity.LastPosition = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.LastPosition);
            entity.LastPoints = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.LastPoints);
            entity.FirstGpTrack = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.FirstGpTrack);
            entity.FirstGpYear = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.FirstGpYear);
            entity.Wins = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.Wins);
            entity.YearlyBudget = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.YearlyBudget);
            entity.UnknownA = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.UnknownA);
            entity.CountryMapId = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.CountryMapId);
            entity.LocationPointerX = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.LocationPointerX);
            entity.LocationPointerY = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.LocationPointerY);
            entity.TyreSupplierId = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.TyreSupplierId);

            return entity;
        }
    }
}