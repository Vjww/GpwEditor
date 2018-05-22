using System;
using App.BaseGameEditor.Data.Calculators;
using App.BaseGameEditor.Data.DataEndpoints;
using App.BaseGameEditor.Data.DataLocators.Lookups;
using App.BaseGameEditor.Data.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Data.DataEntities.Lookups
{
    public class DriverNationalityLookupDataEntityImportService : IDataEntityImportService<DriverNationalityLookupDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<DriverNationalityLookupDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<DriverNationalityLookupDataLocator> _dataLocatorFactory;
        private readonly IdentityCalculator _identityCalculator;

        public DriverNationalityLookupDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<DriverNationalityLookupDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<DriverNationalityLookupDataLocator> dataLocatorFactory,
            IdentityCalculator identityCalculator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
            _identityCalculator = identityCalculator ?? throw new ArgumentNullException(nameof(identityCalculator));
        }

        public DriverNationalityLookupDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Value = _identityCalculator.GetDriverNationalityNameId(result.Id);
            result.Description = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Description).Value;

            return result;
        }
    }
}