﻿using System;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.Core.Factories;
using App.Shared.Data.Objects;
using App.Shared.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class SponsorDomainModelExportService
    {
        private readonly SponsorDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<SponsorDataEntity> _sponsorDataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorContractDataEntity> _sponsorContractDataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorFiaDataEntity> _sponsorFiaDataEntityFactory;
        private readonly IMapperService _mapperService;

        public SponsorDomainModelExportService(
            SponsorDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<SponsorDataEntity> sponsorDataEntityFactory,
            IIntegerIdentityFactory<SponsorContractDataEntity> sponsorContractDataEntityFactory,
            IIntegerIdentityFactory<SponsorFiaDataEntity> sponsorFiaDataEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _sponsorDataEntityFactory = sponsorDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorDataEntityFactory));
            _sponsorContractDataEntityFactory = sponsorContractDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorContractDataEntityFactory));
            _sponsorFiaDataEntityFactory = sponsorFiaDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorFiaDataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Export()
        {
            BlendDataBeforeExport();

            ExportSponsors();
            ExportSponsorContracts();
            ExportSponsorFias();
        }

        private void BlendDataBeforeExport()
        {
            var sponsors = _domainService.GetSponsors().ToList();
            var sponsorContracts = _domainService.GetSponsorContracts().ToList();

            // Move values from SponsorContracts to Sponsor.Contracts by generating new contracts from existing data
            foreach (var sponsor in sponsors)
            {
                // Get contracts matching current sponsor/supplier
                int rebasedSponsorId; // Temporary index rebased on all available sponsors (e.g. 1-98)
                switch (sponsor.SponsorTypeId)
                {
                    case 1: // Team Supplier
                        rebasedSponsorId = sponsor.SponsorId + 0; // 1-7
                        break;
                    case 3: // Tyre Supplier
                        rebasedSponsorId = sponsor.SponsorId + 7; // 8-10
                        break;
                    case 2: // Engine Supplier
                        rebasedSponsorId = sponsor.SponsorId + 10; // 11-18
                        break;
                    case 4: // Fuel Supplier
                        rebasedSponsorId = sponsor.SponsorId + 18; // 19-27
                        break;
                    case 5: // Cash Supplier
                        rebasedSponsorId = sponsor.SponsorId + 27; // 28-98
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(sponsor.SponsorTypeId));
                }
                var contracts = sponsorContracts.Where(x => x.SponsorId == rebasedSponsorId).OrderBy(x => x.TeamId);

                // Clear residual contracts as we will recreate them
                sponsor.Contracts.Clear();

                // Generate new contracts from existing data
                foreach (var contract in contracts)
                {
                    sponsor.Contracts.Add(new SponsorContractObject
                    {
                        SponsorId = sponsor.SponsorId, // Uses non-rebased index (e.g. 1-7, 1-3, 1-8, 1-9, 1-71)
                        SponsorTypeId = contract.SlotTypeId,
                        TeamId = contract.TeamId,
                        Cash = contract.Cash,
                        DealId = contract.DealId,
                        TermsId = contract.TermsId
                    });
                }
            }

            _domainService.SetSponsors(sponsors);
        }

        private void ExportSponsors()
        {
            var entities = _domainService.GetSponsors();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.Sponsors.SetById(dataEntity);
            }
        }

        private void ExportSponsorContracts()
        {
            var entities = _domainService.GetSponsorContracts();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorContractDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorContracts.SetById(dataEntity);
            }
        }

        private void ExportSponsorFias()
        {
            var entities = _domainService.GetSponsorFias();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorFiaDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorFias.SetById(dataEntity);
            }
        }
    }
}