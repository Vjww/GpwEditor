using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.Calculators;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorshipCashDataEntityImportService : IDataEntityImportService<SponsorshipCashDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorshipCashDataEntity> _dataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipCashDataLocator> _dataLocatorFactory;
        private readonly IdentityCalculator _identityCalculator;

        public SponsorshipCashDataEntityImportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorshipCashDataEntity> dataEntityFactory,
            IIntegerIdentityFactory<SponsorshipCashDataLocator> dataLocatorFactory,
            IdentityCalculator identityCalculator)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
            _identityCalculator = identityCalculator ?? throw new ArgumentNullException(nameof(identityCalculator));
        }

        public SponsorshipCashDataEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var dataLocator = _dataLocatorFactory.Create(id);
            dataLocator.Initialise();

            var result = _dataEntityFactory.Create(id);
            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name).Value;
            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name).Value;

            // TODO: Remove temporary entity fields below, as are used in aid of module development
            result.EntityType = _dataEndpoint.GameExecutableFileResource.ReadByte(dataLocator.EntityTypeValue);
            result.EntityResource = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.EntityResourceValue);
            result.EntityData = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.EntityDataValue);
            result.SponsorId = id + 1 + 27;
            result.SponsorType = _identityCalculator.GetSponsorType(id + 27);

            result.CashRating = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CashRatingValue);

            return result;
        }
    }
}