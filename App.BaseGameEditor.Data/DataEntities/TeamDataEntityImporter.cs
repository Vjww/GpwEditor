using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class TeamDataEntityImporter : IDataEntityImporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly DataEntityFactory<TeamDataEntity> _dataEntityFactory;
        private readonly DataLocatorFactory<TeamDataLocator> _dataLocatorFactory;

        public TeamDataEntityImporter(
            DataEndpoint dataEndpoint,
            DataEntityFactory<TeamDataEntity> dataEntityFactory,
            DataLocatorFactory<TeamDataLocator> dataLocatorFactory)
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
            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);
            result.LastPosition = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LastPosition);
            result.LastPoints = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LastPoints);
            result.FirstGpTrack = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.FirstGpTrack);
            result.FirstGpYear = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.FirstGpYear);
            result.Wins = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Wins);
            result.YearlyBudget = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.YearlyBudget);
            result.UnknownA = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.UnknownA);
            result.CountryMapId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CountryMapId);
            result.LocationPointerX = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LocationPointerX);
            result.LocationPointerY = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LocationPointerY);
            result.TyreSupplierId = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.TyreSupplierId);

            return result;
        }
    }
}