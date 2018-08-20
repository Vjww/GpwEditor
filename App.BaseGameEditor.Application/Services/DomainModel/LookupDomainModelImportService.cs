using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities.Lookups;
using App.BaseGameEditor.Domain.Services;
using App.BaseGameEditor.Infrastructure.Services;
using App.Core.Factories;

namespace App.BaseGameEditor.Application.Services.DomainModel
{
    public class LookupDomainModelImportService
    {
        private const int ChiefDriverLoyaltyLookupItemCount = 45;
        private const int DriverNationalityLookupItemCount = 14;
        private const int DriverRoleLookupItemCount = 4;
        private const int TeamDebutGrandPrixLookupItemCount = 19;
        private const int TrackDriverLookupItemCount = 48;
        private const int TrackLayoutLookupItemCount = 3;
        private const int TrackTeamLookupItemCount = 11;
        private const int TyreSupplierLookupItemCount = 3;

        private readonly LookupDomainService _domainService;
        private readonly DataService _dataService;
        private readonly IIntegerIdentityFactory<ChiefDriverLoyaltyLookupEntity> _chiefDriverLoyaltyLookupEntityFactory;
        private readonly IIntegerIdentityFactory<DriverNationalityLookupEntity> _driverNationalityLookupEntityFactory;
        private readonly IIntegerIdentityFactory<DriverRoleLookupEntity> _driverRoleLookupEntityFactory;
        private readonly IIntegerIdentityFactory<TeamDebutGrandPrixLookupEntity> _teamDebutGrandPrixLookupEntityFactory;
        private readonly IIntegerIdentityFactory<TrackDriverLookupEntity> _trackDriverLookupEntityFactory;
        private readonly IIntegerIdentityFactory<TrackLayoutLookupEntity> _trackLayoutLookupEntityFactory;
        private readonly IIntegerIdentityFactory<TrackTeamLookupEntity> _trackTeamLookupEntityFactory;
        private readonly IIntegerIdentityFactory<TyreSupplierLookupEntity> _tyreSupplierLookupEntityFactory;
        private readonly IMapperService _mapperService;

        public LookupDomainModelImportService(
            LookupDomainService domainService,
            DataService dataService,
            IIntegerIdentityFactory<ChiefDriverLoyaltyLookupEntity> chiefDriverLoyaltyLookupEntityFactory,
            IIntegerIdentityFactory<DriverNationalityLookupEntity> driverNationalityLookupEntityFactory,
            IIntegerIdentityFactory<DriverRoleLookupEntity> driverRoleLookupEntityFactory,
            IIntegerIdentityFactory<TeamDebutGrandPrixLookupEntity> teamDebutGrandPrixLookupEntityFactory,
            IIntegerIdentityFactory<TrackDriverLookupEntity> trackDriverLookupEntityFactory,
            IIntegerIdentityFactory<TrackLayoutLookupEntity> trackLayoutLookupEntityFactory,
            IIntegerIdentityFactory<TrackTeamLookupEntity> trackTeamLookupEntityFactory,
            IIntegerIdentityFactory<TyreSupplierLookupEntity> tyreSupplierLookupEntityFactory,
            IMapperService mapperService)
        {
            _domainService = domainService ?? throw new ArgumentNullException(nameof(domainService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _chiefDriverLoyaltyLookupEntityFactory = chiefDriverLoyaltyLookupEntityFactory ?? throw new ArgumentNullException(nameof(chiefDriverLoyaltyLookupEntityFactory));
            _driverNationalityLookupEntityFactory = driverNationalityLookupEntityFactory ?? throw new ArgumentNullException(nameof(driverNationalityLookupEntityFactory));
            _driverRoleLookupEntityFactory = driverRoleLookupEntityFactory ?? throw new ArgumentNullException(nameof(driverRoleLookupEntityFactory));
            _teamDebutGrandPrixLookupEntityFactory = teamDebutGrandPrixLookupEntityFactory ?? throw new ArgumentNullException(nameof(teamDebutGrandPrixLookupEntityFactory));
            _trackDriverLookupEntityFactory = trackDriverLookupEntityFactory ?? throw new ArgumentNullException(nameof(trackDriverLookupEntityFactory));
            _trackLayoutLookupEntityFactory = trackLayoutLookupEntityFactory ?? throw new ArgumentNullException(nameof(trackLayoutLookupEntityFactory));
            _trackTeamLookupEntityFactory = trackTeamLookupEntityFactory ?? throw new ArgumentNullException(nameof(trackTeamLookupEntityFactory));
            _tyreSupplierLookupEntityFactory = tyreSupplierLookupEntityFactory ?? throw new ArgumentNullException(nameof(tyreSupplierLookupEntityFactory));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
        }

        public void Import()
        {
            ImportChiefDriverLoyaltyLookups();
            ImportDriverNationalityLookups();
            ImportDriverRoleLookups();
            ImportTeamDebutGrandPrixLookups();
            ImportTrackDriverLookups();
            ImportTrackLayoutLookups();
            ImportTrackTeamLookups();
            ImportTyreSupplierLookups();
        }

        private void ImportChiefDriverLoyaltyLookups()
        {
            var entities = new List<ChiefDriverLoyaltyLookupEntity>();
            for (var i = 0; i < ChiefDriverLoyaltyLookupItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.ChiefDriverLoyaltyLookups.Get(x => x.Id == id).Single();

                var entity = _chiefDriverLoyaltyLookupEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetChiefDriverLoyaltyLookups(entities);
        }

        private void ImportDriverNationalityLookups()
        {
            var entities = new List<DriverNationalityLookupEntity>();
            for (var i = 0; i < DriverNationalityLookupItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.DriverNationalityLookups.Get(x => x.Id == id).Single();

                var entity = _driverNationalityLookupEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetDriverNationalityLookups(entities);
        }

        private void ImportDriverRoleLookups()
        {
            var entities = new List<DriverRoleLookupEntity>();
            for (var i = 0; i < DriverRoleLookupItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.DriverRoleLookups.Get(x => x.Id == id).Single();

                var entity = _driverRoleLookupEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetDriverRoleLookups(entities);
        }

        private void ImportTeamDebutGrandPrixLookups()
        {
            var entities = new List<TeamDebutGrandPrixLookupEntity>();
            for (var i = 0; i < TeamDebutGrandPrixLookupItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.TeamDebutGrandPrixLookups.Get(x => x.Id == id).Single();

                var entity = _teamDebutGrandPrixLookupEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetTeamDebutGrandPrixLookups(entities);
        }

        private void ImportTrackDriverLookups()
        {
            var entities = new List<TrackDriverLookupEntity>();
            for (var i = 0; i < TrackDriverLookupItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.TrackDriverLookups.Get(x => x.Id == id).Single();

                var entity = _trackDriverLookupEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetTrackDriverLookups(entities);
        }

        private void ImportTrackLayoutLookups()
        {
            var entities = new List<TrackLayoutLookupEntity>();
            for (var i = 0; i < TrackLayoutLookupItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.TrackLayoutLookups.Get(x => x.Id == id).Single();

                var entity = _trackLayoutLookupEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetTrackLayoutLookups(entities);
        }

        private void ImportTrackTeamLookups()
        {
            var entities = new List<TrackTeamLookupEntity>();
            for (var i = 0; i < TrackTeamLookupItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.TrackTeamLookups.Get(x => x.Id == id).Single();

                var entity = _trackTeamLookupEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetTrackTeamLookups(entities);
        }

        private void ImportTyreSupplierLookups()
        {
            var entities = new List<TyreSupplierLookupEntity>();
            for (var i = 0; i < TyreSupplierLookupItemCount; i++)
            {
                var id = i;

                var dataEntity = _dataService.TyreSupplierLookups.Get(x => x.Id == id).Single();

                var entity = _tyreSupplierLookupEntityFactory.Create(id);
                entity = _mapperService.Map(dataEntity, entity);

                entities.Add(entity);
            }
            _domainService.SetTyreSupplierLookups(entities);
        }
    }
}