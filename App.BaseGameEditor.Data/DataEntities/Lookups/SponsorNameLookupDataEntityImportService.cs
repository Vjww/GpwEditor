using System;
using App.BaseGameEditor.Data.DataLocators.Lookups;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities.Lookups
{
    public class SponsorNameLookupDataEntityImportService : IDataEntityImportService<SponsorNameLookupDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorNameLookupDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorNameLookupDataLocator> _dataLocatorFactory;

        public SponsorNameLookupDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorNameLookupDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<SponsorNameLookupDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public SponsorNameLookupDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Value = id; // TODO: Could use identity calculator and do for loop 0-98
            result.Description = result.Value == 0 ? "None" : _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Description).Value;

            return result;
        }
    }
}