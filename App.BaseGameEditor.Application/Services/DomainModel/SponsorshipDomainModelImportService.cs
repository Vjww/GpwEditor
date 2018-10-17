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
    public class SponsorshipDomainModelImportService
    {
        private const int TeamItemCount = 7;
        private const int EngineItemCount = 8;
        private const int TyreItemCount = 3;
        private const int FuelItemCount = 9;
        private const int CashItemCount = 71;

        private readonly SponsorshipDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<SponsorshipTeamEntity> _teamEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipEngineEntity> _engineEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipTyreEntity> _tyreEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipFuelEntity> _fuelEntityFactory;
        private readonly IIntegerIdentityFactory<SponsorshipCashEntity> _cashEntityFactory;
        private readonly IMapperService _mapperService;

        public SponsorshipDomainModelImportService(
            SponsorshipDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<SponsorshipTeamEntity> teamEntityFactory,
            IIntegerIdentityFactory<SponsorshipEngineEntity> engineEntityFactory,
            IIntegerIdentityFactory<SponsorshipTyreEntity> tyreEntityFactory,
            IIntegerIdentityFactory<SponsorshipFuelEntity> fuelEntityFactory,
            IIntegerIdentityFactory<SponsorshipCashEntity> cashEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _teamEntityFactory = teamEntityFactory ?? throw new ArgumentNullException(nameof(teamEntityFactory));
            _engineEntityFactory = engineEntityFactory ?? throw new ArgumentNullException(nameof(engineEntityFactory));
            _tyreEntityFactory = tyreEntityFactory ?? throw new ArgumentNullException(nameof(tyreEntityFactory));
            _fuelEntityFactory = fuelEntityFactory ?? throw new ArgumentNullException(nameof(fuelEntityFactory));
            _cashEntityFactory = cashEntityFactory ?? throw new ArgumentNullException(nameof(cashEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            ImportTeams();
            ImportEngines();
            ImportTyres();
            ImportFuels();
            ImportCashs();
        }

        private void ImportTeams()
        {
            var entities = new List<SponsorshipTeamEntity>();
            for (var i = 0; i < TeamItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipTeams.Get(x => x.Id == id).Single();

                var entity = _teamEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipTeams(entities);
        }

        private void ImportEngines()
        {
            var entities = new List<SponsorshipEngineEntity>();
            for (var i = 0; i < EngineItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipEngines.Get(x => x.Id == id).Single();

                var entity = _engineEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipEngines(entities);
        }

        private void ImportTyres()
        {
            var entities = new List<SponsorshipTyreEntity>();
            for (var i = 0; i < TyreItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipTyres.Get(x => x.Id == id).Single();

                var entity = _tyreEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipTyres(entities);
        }

        private void ImportFuels()
        {
            var entities = new List<SponsorshipFuelEntity>();
            for (var i = 0; i < FuelItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipFuels.Get(x => x.Id == id).Single();

                var entity = _fuelEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipFuels(entities);
        }

        private void ImportCashs()
        {
            var entities = new List<SponsorshipCashEntity>();
            for (var i = 0; i < CashItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.SponsorshipCashs.Get(x => x.Id == id).Single();

                var entity = _cashEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetSponsorshipCashs(entities);
        }
    }
}