using System;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class TrackDataEntityImportService : IDataEntityImportService<TrackDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<TrackDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<TrackDataLocator> _dataLocatorFactory;

        public TrackDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<TrackDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<TrackDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public TrackDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);
            result.Laps = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Laps);
            result.Layout = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Layout);
            result.LapRecordDriver = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LapRecordDriver);
            result.LapRecordTeam = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LapRecordTeam);
            result.LapRecordTime = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LapRecordTime);
            result.LapRecordMph = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LapRecordMph);
            result.LapRecordYear = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LapRecordYear);
            result.LastRaceDriver = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LastRaceDriver);
            result.LastRaceTeam = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LastRaceTeam);
            result.LastRaceYear = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LastRaceYear);
            result.LastRaceTime = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.LastRaceTime);
            result.Hospitality = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Hospitality);
            result.Speed = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Speed);
            result.Grip = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Grip);
            result.Surface = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Surface);
            result.Tarmac = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Tarmac);
            result.Dust = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Dust);
            result.Overtaking = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Overtaking);
            result.Braking = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Braking);
            result.Rain = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Rain);
            result.Heat = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Heat);
            result.Wind = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.Wind);

            return result;
        }
    }
}