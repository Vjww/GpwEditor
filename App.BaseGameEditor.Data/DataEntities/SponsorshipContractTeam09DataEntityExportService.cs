using System;
using App.BaseGameEditor.Data.DataLocators;
using App.Core.Factories;
using App.Shared.Data.DataEndpoints;
using App.Shared.Data.Services;

namespace App.BaseGameEditor.Data.DataEntities
{
    public class SponsorshipContractTeam09DataEntityExportService : IDataEntityExportService<SponsorshipContractTeam09DataEntity>
    {
        private readonly DataEndpoint _dataEndpoint;
        private readonly IIntegerIdentityFactory<SponsorshipContractDataLocator> _dataLocatorFactory;

        public SponsorshipContractTeam09DataEntityExportService(
            DataEndpoint dataEndpoint,
            IIntegerIdentityFactory<SponsorshipContractDataLocator> dataLocatorFactory)
        {
            _dataEndpoint = dataEndpoint ?? throw new ArgumentNullException(nameof(dataEndpoint));
            _dataLocatorFactory = dataLocatorFactory ?? throw new ArgumentNullException(nameof(dataLocatorFactory));
        }

        public void Export(SponsorshipContractTeam09DataEntity dataEntity)
        {
            if (dataEntity == null) throw new ArgumentNullException(nameof(dataEntity));
            if (!(dataEntity is SponsorshipContractTeam09DataEntity sponsorshipContractDataEntity)) throw new ArgumentNullException(nameof(sponsorshipContractDataEntity));

            var dataLocator = _dataLocatorFactory.Create(sponsorshipContractDataEntity.Id);
            dataLocator.Initialise();
        }
    }
}