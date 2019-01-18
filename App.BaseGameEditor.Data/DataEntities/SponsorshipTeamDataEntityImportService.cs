// TODO: Is this redundant? Superseded by SponsorDataEntity?

//using System;
//using App.BaseGameEditor.Data.DataLocators;
//using App.Core.Factories;
//using App.Shared.Data.Calculators;
//using App.Shared.Data.DataEndpoints;
//using App.Shared.Data.Services;

//namespace App.BaseGameEditor.Data.DataEntities
//{
//    public class SponsorshipTeamDataEntityImportService : IDataEntityImportService<SponsorshipTeamDataEntity>
//    {
//        private readonly DataEndpoint _dataEndpoint;
//        private readonly IIntegerIdentityFactory<SponsorshipTeamDataEntity> _dataEntityFactory;
//        private readonly IIntegerIdentityFactory<SponsorshipTeamDataLocator> _dataLocatorFactory;
//        private readonly IdentityCalculator _identityCalculator;

//        public SponsorshipTeamDataEntityImportService(
//            DataEndpoint dataEndpoint,
//            IIntegerIdentityFactory<SponsorshipTeamDataEntity> dataEntityFactory,
//            IIntegerIdentityFactory<SponsorshipTeamDataLocator> dataLocatorFactory,
//            IdentityCalculator identityCalculator)
//        {
//            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
//            _dataEntityFactory = dataEntityFactory ?? throw new ArgumentNullException(nameof(dataEntityFactory));
//            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
//            _identityCalculator = identityCalculator ?? throw new ArgumentNullException(nameof(identityCalculator));
//        }

//        public SponsorshipTeamDataEntity Import(int id)
//        {
//            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

//            var dataLocator = _dataLocatorFactory.Create(id);
//            dataLocator.Initialise();

//            var result = _dataEntityFactory.Create(id);
//            result.Name.English = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name).Value;
//            result.Name.French = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name).Value;
//            result.Name.German = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name).Value;

//            result.SponsorId = id + 1;
//            result.SponsorType = _identityCalculator.GetSponsorTypeId(id);
//            result.EntityType = _dataEndpoint.GameExecutableFileResource.ReadByte(dataLocator.EntityTypeValue);
//            result.EntityResource = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.EntityResourceValue);
//            result.EntityData = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.EntityDataValue);

//            result.CashRating = _dataEndpoint.GameExecutableFileResource.ReadInteger(dataLocator.CashRatingValue);

//            return result;
//        }
//    }
//}