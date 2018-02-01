using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class TeamDataEntityExporter : IDataEntityExporter
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly TeamDataLocator _dataLocator;

        public TeamDataEntityExporter(DataEndpoint dataEndpoint, TeamDataLocator dataLocator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocator = dataLocator ?? throw new ArgumentNullException(nameof(dataLocator));
        }

        public void Export(IDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is TeamDataEntity teamDataEntity)) throw new ArgumentNullException(nameof(teamDataEntity));

            _dataLocator.Initialise(teamDataEntity.Id);

            _dataEndpoint.EnglishLanguageCatalogue.Write(_dataLocator.Name, teamDataEntity.Name.English);
            _dataEndpoint.FrenchLanguageCatalogue.Write(_dataLocator.Name, teamDataEntity.Name.French);
            _dataEndpoint.GermanLanguageCatalogue.Write(_dataLocator.Name, teamDataEntity.Name.German);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.LastPosition, teamDataEntity.LastPosition);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.LastPoints, teamDataEntity.LastPoints);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.FirstGpTrack, teamDataEntity.FirstGpTrack);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.FirstGpYear, teamDataEntity.FirstGpYear);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.Wins, teamDataEntity.Wins);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.YearlyBudget, teamDataEntity.YearlyBudget);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.UnknownA, teamDataEntity.UnknownA);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.CountryMapId, teamDataEntity.CountryMapId);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.LocationPointerX, teamDataEntity.LocationPointerX);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.LocationPointerY, teamDataEntity.LocationPointerY);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(_dataLocator.TyreSupplierId, teamDataEntity.TyreSupplierId);
        }
    }
}