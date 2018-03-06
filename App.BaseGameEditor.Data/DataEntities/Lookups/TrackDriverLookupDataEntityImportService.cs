using System;
using App.BaseGameEditor.Data.Calculators;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators.Lookups;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities.Lookups
{
    public class TrackDriverLookupDataEntityImportService : IDataEntityImportService<TrackDriverLookupDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<TrackDriverLookupDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<TrackDriverLookupDataLocator> _dataLocatorFactory;
        private readonly IdentityCalculator _identityCalculator;

        public TrackDriverLookupDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<TrackDriverLookupDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<TrackDriverLookupDataLocator> dataLocatorFactory,
            IdentityCalculator identityCalculator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
            _identityCalculator = identityCalculator ?? throw new ArgumentNullException(nameof(identityCalculator));
        }

        public TrackDriverLookupDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Value = _identityCalculator.GetTrackDriverNameId(result.Id);
            result.Description = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Description);

            return result;
        }
    }
}