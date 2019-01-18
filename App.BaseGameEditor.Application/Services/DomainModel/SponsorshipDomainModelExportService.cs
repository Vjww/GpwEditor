using System;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.Core.Factories;
using App.Shared.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class SponsorshipDomainModelExportService
    {
        private readonly SponsorDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<SponsorDataEntity> _sponsorDataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorContractDataEntity> _sponsorContractDataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipTeamDataEntity> _sponsorshipTeamDataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipEngineDataEntity> _sponsorshipEngineDataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipTyreDataEntity> _sponsorshipTyreDataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipFuelDataEntity> _sponsorshipFuelDataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipCashDataEntity> _sponsorshipCashDataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam01DataEntity> _sponsorshipContractTeam01DataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam02DataEntity> _sponsorshipContractTeam02DataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam03DataEntity> _sponsorshipContractTeam03DataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam04DataEntity> _sponsorshipContractTeam04DataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam05DataEntity> _sponsorshipContractTeam05DataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam06DataEntity> _sponsorshipContractTeam06DataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam07DataEntity> _sponsorshipContractTeam07DataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam08DataEntity> _sponsorshipContractTeam08DataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam09DataEntity> _sponsorshipContractTeam09DataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam10DataEntity> _sponsorshipContractTeam10DataEntityFactory;
        // TODO: private readonly IIntegerIdentityFactory<SponsorshipContractTeam11DataEntity> _sponsorshipContractTeam11DataEntityFactory;
        private readonly IMapperService _mapperService;

        public SponsorshipDomainModelExportService(
            SponsorDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<SponsorDataEntity> sponsorDataEntityFactory,
            IIntegerIdentityFactory<SponsorContractDataEntity> sponsorContractDataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipTeamDataEntity> sponsorshipTeamDataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipEngineDataEntity> sponsorshipEngineDataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipTyreDataEntity> sponsorshipTyreDataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipFuelDataEntity> sponsorshipFuelDataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipCashDataEntity> sponsorshipCashDataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam01DataEntity> sponsorshipContractTeam01DataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam02DataEntity> sponsorshipContractTeam02DataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam03DataEntity> sponsorshipContractTeam03DataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam04DataEntity> sponsorshipContractTeam04DataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam05DataEntity> sponsorshipContractTeam05DataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam06DataEntity> sponsorshipContractTeam06DataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam07DataEntity> sponsorshipContractTeam07DataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam08DataEntity> sponsorshipContractTeam08DataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam09DataEntity> sponsorshipContractTeam09DataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam10DataEntity> sponsorshipContractTeam10DataEntityFactory,
            // TODO: IIntegerIdentityFactory<SponsorshipContractTeam11DataEntity> sponsorshipContractTeam11DataEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _sponsorDataEntityFactory = sponsorDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorDataEntityFactory));
            _sponsorContractDataEntityFactory = sponsorContractDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorContractDataEntityFactory));
            // TODO: _sponsorshipTeamDataEntityFactory = sponsorshipTeamDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipTeamDataEntityFactory));
            // TODO: _sponsorshipEngineDataEntityFactory = sponsorshipEngineDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipEngineDataEntityFactory));
            // TODO: _sponsorshipTyreDataEntityFactory = sponsorshipTyreDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipTyreDataEntityFactory));
            // TODO: _sponsorshipFuelDataEntityFactory = sponsorshipFuelDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipFuelDataEntityFactory));
            // TODO: _sponsorshipCashDataEntityFactory = sponsorshipCashDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipCashDataEntityFactory));
            // TODO: _sponsorshipContractTeam01DataEntityFactory = sponsorshipContractTeam01DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam01DataEntityFactory));
            // TODO: _sponsorshipContractTeam02DataEntityFactory = sponsorshipContractTeam02DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam02DataEntityFactory));
            // TODO: _sponsorshipContractTeam03DataEntityFactory = sponsorshipContractTeam03DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam03DataEntityFactory));
            // TODO: _sponsorshipContractTeam04DataEntityFactory = sponsorshipContractTeam04DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam04DataEntityFactory));
            // TODO: _sponsorshipContractTeam05DataEntityFactory = sponsorshipContractTeam05DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam05DataEntityFactory));
            // TODO: _sponsorshipContractTeam06DataEntityFactory = sponsorshipContractTeam06DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam06DataEntityFactory));
            // TODO: _sponsorshipContractTeam07DataEntityFactory = sponsorshipContractTeam07DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam07DataEntityFactory));
            // TODO: _sponsorshipContractTeam08DataEntityFactory = sponsorshipContractTeam08DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam08DataEntityFactory));
            // TODO: _sponsorshipContractTeam09DataEntityFactory = sponsorshipContractTeam09DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam09DataEntityFactory));
            // TODO: _sponsorshipContractTeam10DataEntityFactory = sponsorshipContractTeam10DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam10DataEntityFactory));
            // TODO: _sponsorshipContractTeam11DataEntityFactory = sponsorshipContractTeam11DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam11DataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Export()
        {
            BlendDataBeforeExport();

            ExportSponsors();
            ExportSponsorContracts();

            // TODO: ExportSponsorshipTeams();
            // TODO: ExportSponsorshipEngines();
            // TODO: ExportSponsorshipFuels();
            // TODO: ExportSponsorshipTyres();
            // TODO: ExportSponsorshipCashs();
            // TODO: ExportSponsorshipContractsTeam01();
            // TODO: ExportSponsorshipContractsTeam02();
            // TODO: ExportSponsorshipContractsTeam03();
            // TODO: ExportSponsorshipContractsTeam04();
            // TODO: ExportSponsorshipContractsTeam05();
            // TODO: ExportSponsorshipContractsTeam06();
            // TODO: ExportSponsorshipContractsTeam07();
            // TODO: ExportSponsorshipContractsTeam08();
            // TODO: ExportSponsorshipContractsTeam09();
            // TODO: ExportSponsorshipContractsTeam10();
            // TODO: ExportSponsorshipContractsTeam11();
        }

        private void BlendDataBeforeExport()
        {
            // TODO: Need to verify if reversing the logic was correct, depending on how the UI is updating the domain.

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
                            sponsorContract.Cash = contract.Cash; // TODO: I have reversed this assignment, so need to check this is correct
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
                            contract.DealId = sponsorContract.DealId; // TODO: I have reversed this assignment, so need to check this is correct
                            contract.TermsId = sponsorContract.TermsId; // TODO: I have reversed this assignment, so need to check this is correct
                        }
                    }
                }
            }
            _domainService.SetSponsorContracts(sponsorContracts);
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

        /* TODO:
        private void ExportSponsorshipTeams()
        {
            var entities = _domainService.GetSponsorshipTeams();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipTeamDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipTeams.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipEngines()
        {
            var entities = _domainService.GetSponsorshipEngines();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipEngineDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipEngines.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipTyres()
        {
            var entities = _domainService.GetSponsorshipTyres();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipTyreDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipTyres.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipFuels()
        {
            var entities = _domainService.GetSponsorshipFuels();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipFuelDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipFuels.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipCashs()
        {
            var entities = _domainService.GetSponsorshipCashs();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipCashDataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipCashs.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipContractsTeam01()
        {
            var entities = _domainService.GetSponsorshipContractsTeam01();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipContractTeam01DataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipContractsTeam01.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipContractsTeam02()
        {
            var entities = _domainService.GetSponsorshipContractsTeam02();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipContractTeam02DataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipContractsTeam02.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipContractsTeam03()
        {
            var entities = _domainService.GetSponsorshipContractsTeam03();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipContractTeam03DataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipContractsTeam03.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipContractsTeam04()
        {
            var entities = _domainService.GetSponsorshipContractsTeam04();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipContractTeam04DataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipContractsTeam04.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipContractsTeam05()
        {
            var entities = _domainService.GetSponsorshipContractsTeam05();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipContractTeam05DataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipContractsTeam05.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipContractsTeam06()
        {
            var entities = _domainService.GetSponsorshipContractsTeam06();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipContractTeam06DataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipContractsTeam06.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipContractsTeam07()
        {
            var entities = _domainService.GetSponsorshipContractsTeam07();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipContractTeam07DataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipContractsTeam07.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipContractsTeam08()
        {
            var entities = _domainService.GetSponsorshipContractsTeam08();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipContractTeam08DataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipContractsTeam08.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipContractsTeam09()
        {
            var entities = _domainService.GetSponsorshipContractsTeam09();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipContractTeam09DataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipContractsTeam09.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipContractsTeam10()
        {
            var entities = _domainService.GetSponsorshipContractsTeam10();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipContractTeam10DataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipContractsTeam10.SetById(dataEntity);
            }
        }

        private void ExportSponsorshipContractsTeam11()
        {
            var entities = _domainService.GetSponsorshipContractsTeam11();
            foreach (var item in entities)
            {
                var dataEntity = _sponsorshipContractTeam11DataEntityFactory.Create(item.Id);
                _mapperService.Map(item, dataEntity);

                _dataService.SponsorshipContractsTeam11.SetById(dataEntity);
            }
        }
        */
    }
}