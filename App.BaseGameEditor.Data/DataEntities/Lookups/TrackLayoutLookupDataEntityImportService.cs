using System;
using App.BaseGameEditor.Data.DataLocators.Lookups;
using App.Core.Factories;
using App.Shared.Data.Calculators;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities.Lookups
{
    public class TrackLayoutLookupDataEntityImportService : IDataEntityImportService<TrackLayoutLookupDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<TrackLayoutLookupDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<TrackLayoutLookupDataLocator> _dataLocatorFactory;
        private readonly IdentityCalculator _identityCalculator;

        public TrackLayoutLookupDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<TrackLayoutLookupDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<TrackLayoutLookupDataLocator> dataLocatorFactory,
            IdentityCalculator identityCalculator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
            _identityCalculator = identityCalculator ?? throw new ArgumentNullException(nameof(identityCalculator));
        }

        public TrackLayoutLookupDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Value = _identityCalculator.GetTrackLayoutNameId(result.Id);
            result.Description = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Description).Value;

            return result;
        }
    }
}