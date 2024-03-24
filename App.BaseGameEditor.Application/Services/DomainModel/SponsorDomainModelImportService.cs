using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Services;
using App.Core.Factories;
using App.Shared.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class SponsorDomainModelImportService
    {
        private const int SponsorItemCount = 98;
        private const int SponsorContractItemCount = 110;
        private const int SponsorFiaItemCount = 11;

        private readonly SponsorDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<SponsorEntity> _sponsorEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorContractEntity> _sponsorContractEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorFiaEntity> _sponsorFiaEntityFactory;
        private readonly IMapperService _mapperService;

        public SponsorDomainModelImportService(
            SponsorDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<SponsorEntity> sponsorEntityFactory,
            IIntegerIdentityFactory<SponsorContractEntity> sponsorContractEntityFactory,
            IIntegerIdentityFactory<SponsorFiaEntity> sponsorFiaEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _sponsorEntityFactory = sponsorEntityFactory ?? throw new ArgumentNullException(nameof(sponsorEntityFactory));
            _sponsorContractEntityFactory = sponsorContractEntityFactory ?? throw new ArgumentNullException(nameof(sponsorContractEntityFactory));
            _sponsorFiaEntityFactory = sponsorFiaEntityFactory ?? throw new ArgumentNullException(nameof(sponsorFiaEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            ImportSponsors();
            ImportSponsorContracts();
            ImportSponsorFias();

            BlendDataAfterImport();
        }

        private void BlendDataAfterImport()
        {
            var sponsors = _domainService.GetSponsors().ToList();
            var sponsorContracts = _domainService.GetSponsorContracts().ToList();

            // Move values from SponsorContracts to Sponsor.Contracts
            foreach (var sponsor in sponsors)
            {
                foreach (var contract in sponsor.Contracts)
                {
                    foreach (var sponsorContract in sponsorContracts)
                    {
                        if (sponsorContract.SlotTypeId == contract.SponsorTypeId && sponsorContract.TeamId == contract.TeamId)
                        {
                            contract.Cash = sponsorContract.Cash;
                        }
                    }
                }
            }
            _domainService.SetSponsors(sponsors);

            // Move values from Sponsor.Contracts to SponsorContracts
            foreach (var sponsorContract in sponsorContracts)
            {
                foreach (var sponsor in sponsors)
                {
                    foreach (var contract in sponsor.Contracts)
                    {
                        if (contract.SponsorTypeId == sponsorContract.SlotTypeId && contract.TeamId == sponsorContract.TeamId)
                        {
                            sponsorContract.DealId = contract.DealId;
                            sponsorContract.TermsId = contract.TermsId;
                        }
                    }
                }
            }
            _domainService.SetSponsorContracts(sponsorContracts);
        }

        private void ImportSponsors()
        {
            var entities = new List<SponsorEntity>();
            for (var i = 0; i < SponsorItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.Sponsors.Get(x => x.Id == id).Single();

                var entity = _sponsorEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsors(entities);
        }

        private void ImportSponsorContracts()
        {
            var entities = new List<SponsorContractEntity>();
            for (var i = 0; i < SponsorContractItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorContracts.Get(x => x.Id == id).Single();

                var entity = _sponsorContractEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorContracts(entities);
        }

        private void ImportSponsorFias()
        {
            var entities = new List<SponsorFiaEntity>();
            for (var i = 0; i < SponsorFiaItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorFias.Get(x => x.Id == id).Single();

                var entity = _sponsorFiaEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorFias(entities);
        }
    }
}