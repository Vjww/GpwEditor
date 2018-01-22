using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.EntityImporters
{
    public class TeamDataEntityImporter : IDataEntityImporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly TeamDataLocator _dataLocator;
        private readonly TeamDataEntityFactory _factory;

        public TeamDataEntityImporter(
            DataEndpoint dataEndpoint,
            TeamDataLocator dataLocator,
            TeamDataEntityFactory factory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            _dataLocator.Initialise(id);

            var result = _factory.Create(id);
            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(_dataLocator.Name);
            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(_dataLocator.Name);
            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(_dataLocator.Name);
            result.LastPosition = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.LastPosition);
            result.LastPoints = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.LastPoints);
            result.FirstGpTrack = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.FirstGpTrack);
            result.FirstGpYear = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.FirstGpYear);
            result.Wins = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.Wins);
            result.YearlyBudget = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.YearlyBudget);
            result.UnknownA = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.UnknownA);
            result.CountryMapId = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.CountryMapId);
            result.LocationPointerX = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.LocationPointerX);
            result.LocationPointerY = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.LocationPointerY);
            result.TyreSupplierId = _dataEndpoint.GameExecutableFileResource.ReadInteger(_dataLocator.TyreSupplierId);

            return result;
        }
    }
}