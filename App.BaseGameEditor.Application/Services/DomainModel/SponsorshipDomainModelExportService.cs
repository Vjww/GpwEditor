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
        private readonly IMapperService _mapperService;

        public SponsorshipDomainModelExportService(
            SponsorshipDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<SponsorshipTeamDataEntity> sponsorshipTeamDataEntityFactory,
            IIntegerIdentityFactory<SponsorshipEngineDataEntity> sponsorshipEngineDataEntityFactory,
            IIntegerIdentityFactory<SponsorshipTyreDataEntity> sponsorshipTyreDataEntityFactory,
            IIntegerIdentityFactory<SponsorshipFuelDataEntity> sponsorshipFuelDataEntityFactory,
            IIntegerIdentityFactory<SponsorshipCashDataEntity> sponsorshipCashDataEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _sponsorshipTeamDataEntityFactory = sponsorshipTeamDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipTeamDataEntityFactory));
            _sponsorshipEngineDataEntityFactory = sponsorshipEngineDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipEngineDataEntityFactory));
            _sponsorshipTyreDataEntityFactory = sponsorshipTyreDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipTyreDataEntityFactory));
            _sponsorshipFuelDataEntityFactory = sponsorshipFuelDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipFuelDataEntityFactory));
            _sponsorshipCashDataEntityFactory = sponsorshipCashDataEntityFactory ?? throw new ArgumentNullException(nameof(sponsorshipCashDataEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Export()
        {
            ExportSponsorshipTeams();
            ExportSponsorshipEngines();
            ExportSponsorshipFuels();
            ExportSponsorshipTyres();
            ExportSponsorshipCashs();
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
    }
}