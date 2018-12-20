using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Services;
using App.Core.Factories;
using App.Shared.Infrastructure.Services;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class SponsorshipDomainModelExportService
    {
        private readonly SponsorshipDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<SponsorshipTeamDataEntity> _sponsorshipTeamDataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipEngineDataEntity> _sponsorshipEngineDataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipTyreDataEntity> _sponsorshipTyreDataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipFuelDataEntity> _sponsorshipFuelDataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipCashDataEntity> _sponsorshipCashDataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam01DataEntity> _sponsorshipContractTeam01DataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam02DataEntity> _sponsorshipContractTeam02DataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam03DataEntity> _sponsorshipContractTeam03DataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam04DataEntity> _sponsorshipContractTeam04DataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam05DataEntity> _sponsorshipContractTeam05DataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam06DataEntity> _sponsorshipContractTeam06DataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam07DataEntity> _sponsorshipContractTeam07DataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam08DataEntity> _sponsorshipContractTeam08DataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam09DataEntity> _sponsorshipContractTeam09DataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam10DataEntity> _sponsorshipContractTeam10DataEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipContractTeam11DataEntity> _sponsorshipContractTeam11DataEntityFactory;
        private readonly IMapperService _mapperService;

        public SponsorshipDomainModelExportService(
            SponsorshipDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<SponsorshipTeamDataEntity> sponsorshipTeamDataEntityFactory,
            IIntegerIdentityFactory<SponsorshipEngineDataEntity> sponsorshipEngineDataEntityFactory,
            IIntegerIdentityFactory<SponsorshipTyreDataEntity> sponsorshipTyreDataEntityFactory,
            IIntegerIdentityFactory<SponsorshipFuelDataEntity> sponsorshipFuelDataEntityFactory,
            IIntegerIdentityFactory<SponsorshipCashDataEntity> sponsorshipCashDataEntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam01DataEntity> sponsorshipContractTeam01DataEntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam02DataEntity> sponsorshipContractTeam02DataEntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam03DataEntity> sponsorshipContractTeam03DataEntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam04DataEntity> sponsorshipContractTeam04DataEntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam05DataEntity> sponsorshipContractTeam05DataEntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam06DataEntity> sponsorshipContractTeam06DataEntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam07DataEntity> sponsorshipContractTeam07DataEntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam08DataEntity> sponsorshipContractTeam08DataEntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam09DataEntity> sponsorshipContractTeam09DataEntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam10DataEntity> sponsorshipContractTeam10DataEntityFactory,
            IIntegerIdentityFactory<SponsorshipContractTeam11DataEntity> sponsorshipContractTeam11DataEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _sponsorshipTeamDataEntityFactory = sponsorshipTeamDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipTeamDataEntityFactory));
            _sponsorshipEngineDataEntityFactory = sponsorshipEngineDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipEngineDataEntityFactory));
            _sponsorshipTyreDataEntityFactory = sponsorshipTyreDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipTyreDataEntityFactory));
            _sponsorshipFuelDataEntityFactory = sponsorshipFuelDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipFuelDataEntityFactory));
            _sponsorshipCashDataEntityFactory = sponsorshipCashDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipCashDataEntityFactory));
            _sponsorshipContractTeam01DataEntityFactory = sponsorshipContractTeam01DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam01DataEntityFactory));
            _sponsorshipContractTeam02DataEntityFactory = sponsorshipContractTeam02DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam02DataEntityFactory));
            _sponsorshipContractTeam03DataEntityFactory = sponsorshipContractTeam03DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam03DataEntityFactory));
            _sponsorshipContractTeam04DataEntityFactory = sponsorshipContractTeam04DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam04DataEntityFactory));
            _sponsorshipContractTeam05DataEntityFactory = sponsorshipContractTeam05DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam05DataEntityFactory));
            _sponsorshipContractTeam06DataEntityFactory = sponsorshipContractTeam06DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam06DataEntityFactory));
            _sponsorshipContractTeam07DataEntityFactory = sponsorshipContractTeam07DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam07DataEntityFactory));
            _sponsorshipContractTeam08DataEntityFactory = sponsorshipContractTeam08DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam08DataEntityFactory));
            _sponsorshipContractTeam09DataEntityFactory = sponsorshipContractTeam09DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam09DataEntityFactory));
            _sponsorshipContractTeam10DataEntityFactory = sponsorshipContractTeam10DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam10DataEntityFactory));
            _sponsorshipContractTeam11DataEntityFactory = sponsorshipContractTeam11DataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipContractTeam11DataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Export()
        {
            ExportSponsorshipTeams();
            ExportSponsorshipEngines();
            ExportSponsorshipFuels();
            ExportSponsorshipTyres();
            ExportSponsorshipCashs();
            ExportSponsorshipContractsTeam01();
            ExportSponsorshipContractsTeam02();
            ExportSponsorshipContractsTeam03();
            ExportSponsorshipContractsTeam04();
            ExportSponsorshipContractsTeam05();
            ExportSponsorshipContractsTeam06();
            ExportSponsorshipContractsTeam07();
            ExportSponsorshipContractsTeam08();
            ExportSponsorshipContractsTeam09();
            ExportSponsorshipContractsTeam10();
            ExportSponsorshipContractsTeam11();
        }

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
    }
}