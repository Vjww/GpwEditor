using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class TeamDataEntityExporter : IDataEntityExporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IDataLocatorFactory<TeamDataLocator> _dataLocatorFactory;

        public TeamDataEntityExporter(
            DataEndpoint dataEndpoint,
            IDataLocatorFactory<TeamDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(IDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is TeamDataEntity teamDataEntity)) throw new ArgumentNullException(nameof(teamDataEntity));

            var dataLocator = _dataLocatorFactory.Create();
            dataLocator.Initialise(teamDataEntity.Id);

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, teamDataEntity.Name.English);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, teamDataEntity.Name.French);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, teamDataEntity.Name.German);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LastPosition, teamDataEntity.LastPosition);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LastPoints, teamDataEntity.LastPoints);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.FirstGpTrack, teamDataEntity.FirstGpTrack);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.FirstGpYear, teamDataEntity.FirstGpYear);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Wins, teamDataEntity.Wins);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.YearlyBudget, teamDataEntity.YearlyBudget);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.UnknownA, teamDataEntity.UnknownA);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.CountryMapId, teamDataEntity.CountryMapId);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LocationPointerX, teamDataEntity.LocationPointerX);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LocationPointerY, teamDataEntity.LocationPointerY);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.TyreSupplierId, teamDataEntity.TyreSupplierId);
        }
    }
}