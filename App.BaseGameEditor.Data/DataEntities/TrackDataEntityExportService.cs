using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class TrackDataEntityExportService : IDataEntityExportService<TrackDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<TrackDataLocator> _dataLocatorFactory;

        public TrackDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<TrackDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(TrackDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is TrackDataEntity trackDataEntity)) throw new ArgumentNullException(nameof(trackDataEntity));

            var dataLocator = _dataLocatorFactory.Create(trackDataEntity.Id);
            dataLocator.Initialise();

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, trackDataEntity.Name.English);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, trackDataEntity.Name.French);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, trackDataEntity.Name.German);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Laps, trackDataEntity.Laps);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Layout, trackDataEntity.Layout);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LapRecordDriver, trackDataEntity.LapRecordDriver);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LapRecordTeam, trackDataEntity.LapRecordTeam);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LapRecordTime, trackDataEntity.LapRecordTime);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LapRecordMph, trackDataEntity.LapRecordMph);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LapRecordYear, trackDataEntity.LapRecordYear);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LastRaceDriver, trackDataEntity.LastRaceDriver);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LastRaceTeam, trackDataEntity.LastRaceTeam);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LastRaceYear, trackDataEntity.LastRaceYear);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.LastRaceTime, trackDataEntity.LastRaceTime);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Hospitality, trackDataEntity.Hospitality);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Speed, trackDataEntity.Speed);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Grip, trackDataEntity.Grip);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Surface, trackDataEntity.Surface);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Tarmac, trackDataEntity.Tarmac);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Dust, trackDataEntity.Dust);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Overtaking, trackDataEntity.Overtaking);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Braking, trackDataEntity.Braking);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Rain, trackDataEntity.Rain);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Heat, trackDataEntity.Heat);
            _dataEndpoint.GameExecutableFileResource.WriteInteger(dataLocator.Wind, trackDataEntity.Wind);
        }
    }
}