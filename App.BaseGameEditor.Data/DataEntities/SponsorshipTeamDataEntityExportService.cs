using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorshipTeamDataEntityExportService : IDataEntityExportService<SponsorshipTeamDataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorshipTeamDataLocator> _dataLocatorFactory;

        public SponsorshipTeamDataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorshipTeamDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(SponsorshipTeamDataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is SponsorshipTeamDataEntity sponsorshipTeamDataEntity)) throw new ArgumentNullException(nameof(sponsorshipTeamDataEntity));

            var dataLocator = _dataLocatorFactory.Create(sponsorshipTeamDataEntity.Id);
            dataLocator.Initialise();

            var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);

            englishCatalogueItem.Value = sponsorshipTeamDataEntity.Name.English;
            frenchCatalogueItem.Value = sponsorshipTeamDataEntity.Name.French;
            germanCatalogueItem.Value = sponsorshipTeamDataEntity.Name.German;

            _dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, englishCatalogueItem);
            _dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, frenchCatalogueItem);
            _dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, germanCatalogueItem);

            _dataEndpoint.GameExecutableFileResource.WriteBytes(dataLocator.CashRatingValue, BitConverter.GetBytes(dataEntity.CashRating));
        }
    }
}