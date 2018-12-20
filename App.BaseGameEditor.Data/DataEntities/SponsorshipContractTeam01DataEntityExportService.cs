using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorshipContractTeam01DataEntityExportService : IDataEntityExportService<SponsorshipContractTeam01DataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorshipContractDataLocator> _dataLocatorFactory;

        public SponsorshipContractTeam01DataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorshipContractDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(SponsorshipContractTeam01DataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is SponsorshipContractTeam01DataEntity sponsorshipContractDataEntity)) throw new ArgumentNullException(nameof(sponsorshipContractDataEntity));

            var dataLocator = _dataLocatorFactory.Create(sponsorshipContractDataEntity.Id);
            dataLocator.Initialise();

            //var englishCatalogueItem = _dataEndpoint.EnglishLanguageCatalogue.Read(dataLocator.Name);
            //var frenchCatalogueItem = _dataEndpoint.FrenchLanguageCatalogue.Read(dataLocator.Name);
            //var germanCatalogueItem = _dataEndpoint.GermanLanguageCatalogue.Read(dataLocator.Name);

            //englishCatalogueItem.Value = sponsorshipContractDataEntity.Name.English;
            //frenchCatalogueItem.Value = sponsorshipContractDataEntity.Name.French;
            //germanCatalogueItem.Value = sponsorshipContractDataEntity.Name.German;

            //_dataEndpoint.EnglishLanguageCatalogue.Write(dataLocator.Name, englishCatalogueItem);
            //_dataEndpoint.FrenchLanguageCatalogue.Write(dataLocator.Name, frenchCatalogueItem);
            //_dataEndpoint.GermanLanguageCatalogue.Write(dataLocator.Name, germanCatalogueItem);

            // TODO: Write each sponsor contract for sponsors assigned a slot in team with slot value
            //var offset = dataLocator.GetSponsorContract(sponsorshipContractDataEntity.TeamIdValue, sponsorshipContractDataEntity.SponsorIdValue);
            //_dataEndpoint.GameExecutableFileResource.WriteInteger(offset, sponsorshipContractDataEntity.SlotId);

            // TODO: Write an instruction for each populated slot
            // TODO: There should be room to write 11 teams x 10 slots x 10 instructions
        }
    }
}