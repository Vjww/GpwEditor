using System;
using System.Collections.Generic;
using System.Windows.Forms;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Entities.Lookups;
using App.BaseGameEditor.Infrastructure.Services;
using App.WindowsForms.Models;
using App.WindowsForms.Models.Lookups;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public class ApplicationController
    {
        private readonly ApplicationService _applicationService;
        private readonly IMapperService _mapperService;
        private readonly GameExecutableEditorForm _view;

        public ApplicationController(
            ApplicationService applicationService,
            IMapperService mapperService,
            GameExecutableEditorForm view)
        {
            _applicationService = applicationService ?? throw new ArgumentNullException(nameof(applicationService));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
            _view = view ?? throw new ArgumentNullException(nameof(view));

            _view.SetController(this);
        }

        public void Run()
        {
            Application.Run(_view);
        }

        public void Import()
        {
            _applicationService.Import(
                _view.GameFolderPath,
                _view.GameExecutableFilePath,
                _view.EnglishLanguageFilePath,
                _view.FrenchLanguageFilePath,
                _view.GermanLanguageFilePath,
                _view.EnglishCommentaryFilePath,
                _view.FrenchCommentaryFilePath,
                _view.GermanCommentaryFilePath);

            UpdateModelsFromService();
        }

        public void Export()
        {
            _applicationService.Export(
                _view.GameFolderPath,
                _view.GameExecutableFilePath,
                _view.EnglishLanguageFilePath,
                _view.FrenchLanguageFilePath,
                _view.GermanLanguageFilePath,
                _view.EnglishCommentaryFilePath,
                _view.FrenchCommentaryFilePath,
                _view.GermanCommentaryFilePath);

            UpdateServiceFromModels();
        }

        private void UpdateModelsFromService()
        {
            _view.ChiefDriverLoyaltyLookups = UpdateModelFromService<IEnumerable<ChiefDriverLoyaltyLookupEntity>, IEnumerable<ChiefDriverLoyaltyLookupModel>>(_applicationService.DomainModel.Lookups.GetChiefDriverLoyaltyLookups);
            _view.DriverNationalityLookups = UpdateModelFromService<IEnumerable<DriverNationalityLookupEntity>, IEnumerable<DriverNationalityLookupModel>>(_applicationService.DomainModel.Lookups.GetDriverNationalityLookups);
            _view.DriverRoleLookups = UpdateModelFromService<IEnumerable<DriverRoleLookupEntity>, IEnumerable<DriverRoleLookupModel>>(_applicationService.DomainModel.Lookups.GetDriverRoleLookups);
            _view.TeamDebutGrandPrixLookups = UpdateModelFromService<IEnumerable<TeamDebutGrandPrixLookupEntity>, IEnumerable<TeamDebutGrandPrixLookupModel>>(_applicationService.DomainModel.Lookups.GetTeamDebutGrandPrixLookups);
            _view.TrackDriverLookups = UpdateModelFromService<IEnumerable<TrackDriverLookupEntity>, IEnumerable<TrackDriverLookupModel>>(_applicationService.DomainModel.Lookups.GetTrackDriverLookups);
            _view.TrackLayoutLookups = UpdateModelFromService<IEnumerable<TrackLayoutLookupEntity>, IEnumerable<TrackLayoutLookupModel>>(_applicationService.DomainModel.Lookups.GetTrackLayoutLookups);
            _view.TrackTeamLookups = UpdateModelFromService<IEnumerable<TrackTeamLookupEntity>, IEnumerable<TrackTeamLookupModel>>(_applicationService.DomainModel.Lookups.GetTrackTeamLookups);
            _view.TyreSupplierLookups = UpdateModelFromService<IEnumerable<TyreSupplierLookupEntity>, IEnumerable<TyreSupplierLookupModel>>(_applicationService.DomainModel.Lookups.GetTyreSupplierLookups);

            _view.Teams = UpdateModelFromService<IEnumerable<TeamEntity>, IEnumerable<TeamModel>>(_applicationService.DomainModel.Teams.GetTeams);
            _view.F1ChiefCommercials = UpdateModelFromService<IEnumerable<F1ChiefCommercialEntity>, IEnumerable<F1ChiefCommercialModel>>(_applicationService.DomainModel.Persons.GetF1ChiefCommercials);
            _view.F1ChiefDesigners = UpdateModelFromService<IEnumerable<F1ChiefDesignerEntity>, IEnumerable<F1ChiefDesignerModel>>(_applicationService.DomainModel.Persons.GetF1ChiefDesigners);
            _view.F1ChiefEngineers = UpdateModelFromService<IEnumerable<F1ChiefEngineerEntity>, IEnumerable<F1ChiefEngineerModel>>(_applicationService.DomainModel.Persons.GetF1ChiefEngineers);
            _view.F1ChiefMechanics = UpdateModelFromService<IEnumerable<F1ChiefMechanicEntity>, IEnumerable<F1ChiefMechanicModel>>(_applicationService.DomainModel.Persons.GetF1ChiefMechanics);
            _view.NonF1ChiefCommercials = UpdateModelFromService<IEnumerable<NonF1ChiefCommercialEntity>, IEnumerable<NonF1ChiefCommercialModel>>(_applicationService.DomainModel.Persons.GetNonF1ChiefCommercials);
            _view.NonF1ChiefDesigners = UpdateModelFromService<IEnumerable<NonF1ChiefDesignerEntity>, IEnumerable<NonF1ChiefDesignerModel>>(_applicationService.DomainModel.Persons.GetNonF1ChiefDesigners);
            _view.NonF1ChiefEngineers = UpdateModelFromService<IEnumerable<NonF1ChiefEngineerEntity>, IEnumerable<NonF1ChiefEngineerModel>>(_applicationService.DomainModel.Persons.GetNonF1ChiefEngineers);
            _view.NonF1ChiefMechanics = UpdateModelFromService<IEnumerable<NonF1ChiefMechanicEntity>, IEnumerable<NonF1ChiefMechanicModel>>(_applicationService.DomainModel.Persons.GetNonF1ChiefMechanics);
            _view.F1Drivers = UpdateModelFromService<IEnumerable<F1DriverEntity>, IEnumerable<F1DriverModel>>(_applicationService.DomainModel.Persons.GetF1Drivers);
            _view.NonF1Drivers = UpdateModelFromService<IEnumerable<NonF1DriverEntity>, IEnumerable<NonF1DriverModel>>(_applicationService.DomainModel.Persons.GetNonF1Drivers);
            _view.Engines = UpdateModelFromService<IEnumerable<EngineEntity>, IEnumerable<EngineModel>>(_applicationService.DomainModel.Suppliers.GetEngines);
            _view.Tyres = UpdateModelFromService<IEnumerable<TyreEntity>, IEnumerable<TyreModel>>(_applicationService.DomainModel.Suppliers.GetTyres);
            _view.Fuels = UpdateModelFromService<IEnumerable<FuelEntity>, IEnumerable<FuelModel>>(_applicationService.DomainModel.Suppliers.GetFuels);
            _view.Tracks = UpdateModelFromService<IEnumerable<TrackEntity>, IEnumerable<TrackModel>>(_applicationService.DomainModel.Tracks.GetTracks);
        }

        private void UpdateServiceFromModels()
        {
            UpdateServiceFromModel<IEnumerable<TeamModel>, IEnumerable<TeamEntity>>(_applicationService.DomainModel.Teams.SetTeams, _view.Teams);
            UpdateServiceFromModel<IEnumerable<F1ChiefCommercialModel>, IEnumerable<F1ChiefCommercialEntity>>(_applicationService.DomainModel.Persons.SetF1ChiefCommercials, _view.F1ChiefCommercials);
            UpdateServiceFromModel<IEnumerable<F1ChiefDesignerModel>, IEnumerable<F1ChiefDesignerEntity>>(_applicationService.DomainModel.Persons.SetF1ChiefDesigners, _view.F1ChiefDesigners);
            UpdateServiceFromModel<IEnumerable<F1ChiefEngineerModel>, IEnumerable<F1ChiefEngineerEntity>>(_applicationService.DomainModel.Persons.SetF1ChiefEngineers, _view.F1ChiefEngineers);
            UpdateServiceFromModel<IEnumerable<F1ChiefMechanicModel>, IEnumerable<F1ChiefMechanicEntity>>(_applicationService.DomainModel.Persons.SetF1ChiefMechanics, _view.F1ChiefMechanics);
            UpdateServiceFromModel<IEnumerable<NonF1ChiefCommercialModel>, IEnumerable<NonF1ChiefCommercialEntity>>(_applicationService.DomainModel.Persons.SetNonF1ChiefCommercials, _view.NonF1ChiefCommercials);
            UpdateServiceFromModel<IEnumerable<NonF1ChiefDesignerModel>, IEnumerable<NonF1ChiefDesignerEntity>>(_applicationService.DomainModel.Persons.SetNonF1ChiefDesigners, _view.NonF1ChiefDesigners);
            UpdateServiceFromModel<IEnumerable<NonF1ChiefEngineerModel>, IEnumerable<NonF1ChiefEngineerEntity>>(_applicationService.DomainModel.Persons.SetNonF1ChiefEngineers, _view.NonF1ChiefEngineers);
            UpdateServiceFromModel<IEnumerable<NonF1ChiefMechanicModel>, IEnumerable<NonF1ChiefMechanicEntity>>(_applicationService.DomainModel.Persons.SetNonF1ChiefMechanics, _view.NonF1ChiefMechanics);
            UpdateServiceFromModel<IEnumerable<F1DriverModel>, IEnumerable<F1DriverEntity>>(_applicationService.DomainModel.Persons.SetF1Drivers, _view.F1Drivers);
            UpdateServiceFromModel<IEnumerable<NonF1DriverModel>, IEnumerable<NonF1DriverEntity>>(_applicationService.DomainModel.Persons.SetNonF1Drivers, _view.NonF1Drivers);
            UpdateServiceFromModel<IEnumerable<EngineModel>, IEnumerable<EngineEntity>>(_applicationService.DomainModel.Suppliers.SetEngines, _view.Engines);
            UpdateServiceFromModel<IEnumerable<TyreModel>, IEnumerable<TyreEntity>>(_applicationService.DomainModel.Suppliers.SetTyres, _view.Tyres);
            UpdateServiceFromModel<IEnumerable<FuelModel>, IEnumerable<FuelEntity>>(_applicationService.DomainModel.Suppliers.SetFuels, _view.Fuels);
            UpdateServiceFromModel<IEnumerable<TrackModel>, IEnumerable<TrackEntity>>(_applicationService.DomainModel.Tracks.SetTracks, _view.Tracks);
        }

        private TU UpdateModelFromService<T, TU>(Func<T> service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));

            var entities = service.Invoke();
            return _mapperService.Map<T, TU>(entities);
        }

        private void UpdateServiceFromModel<T, TU>(Action<TU> service, T model)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entities = _mapperService.Map<T, TU>(model);
            service.Invoke(entities);
        }

        /* TODO: Remove
        private void UpdateChiefDriverLoyaltyLookupsFromService()
        {
            var entities = _applicationService.DomainModel.Lookups.GetChiefDriverLoyaltyLookups();
            var model = _mapperService.Map<IEnumerable<ChiefDriverLoyaltyLookupEntity>, IEnumerable<ChiefDriverLoyaltyLookupModel>>(entities);
            _view.ChiefDriverLoyaltyLookups = model;
        }

        private void UpdateDriverNationalityLookupsFromService()
        {
            var entities = _applicationService.DomainModel.Lookups.GetDriverNationalityLookups();
            var model = _mapperService.Map<IEnumerable<DriverNationalityLookupEntity>, IEnumerable<DriverNationalityLookupModel>>(entities);
            _view.DriverNationalityLookups = model;
        }

        private void UpdateTeamDebutGrandPrixLookupsFromService()
        {
            var entities = _applicationService.DomainModel.Lookups.GetTeamDebutGrandPrixLookups();
            var model = _mapperService.Map<IEnumerable<TeamDebutGrandPrixLookupEntity>, IEnumerable<TeamDebutGrandPrixLookupModel>>(entities);
            _view.TeamDebutGrandPrixLookups = model;
        }

        private void UpdateTrackFastestLapDriverLookupsFromService()
        {
            var entities = _applicationService.DomainModel.Lookups.GetTrackDriverLookups();
            var model = _mapperService.Map<IEnumerable<TrackDriverLookupEntity>, IEnumerable<TrackDriverLookupModel>>(entities);
            _view.TrackDriverLookups = model;
        }

        private void UpdateTrackLayoutLookupsFromService()
        {
            var entities = _applicationService.DomainModel.Lookups.GetTrackLayoutLookups();
            var model = _mapperService.Map<IEnumerable<TrackLayoutLookupEntity>, IEnumerable<TrackLayoutLookupModel>>(entities);
            _view.TrackLayoutLookups = model;
        }

        private void UpdateTyreSupplierLookupsFromService()
        {
            var entities = _applicationService.DomainModel.Lookups.GetTyreSupplierLookups();
            var model = _mapperService.Map<IEnumerable<TyreSupplierLookupEntity>, IEnumerable<TyreSupplierLookupModel>>(entities);
            _view.TyreSupplierLookups = model;
        }
        */

        /* TODO: Remove
        private void UpdateTeamsFromModel()
        {
            var model = _view.Teams;
            var entities = _mapperService.Map<IEnumerable<TeamModel>, IEnumerable<TeamEntity>>(model);
            _applicationService.DomainModel.Teams.SetTeams(entities);
        }

        private void UpdateF1ChiefCommercialsFromModel()
        {
            var model = _view.F1ChiefCommercials;
            var entities = _mapperService.Map<IEnumerable<F1ChiefCommercialModel>, IEnumerable<F1ChiefCommercialEntity>>(model);
            _applicationService.DomainModel.Persons.SetF1ChiefCommercials(entities);
        }

        private void UpdateF1ChiefDesignersFromModel()
        {
            var model = _view.F1ChiefDesigners;
            var entities = _mapperService.Map<IEnumerable<F1ChiefDesignerModel>, IEnumerable<F1ChiefDesignerEntity>>(model);
            _applicationService.DomainModel.Persons.SetF1ChiefDesigners(entities);
        }

        private void UpdateF1ChiefEngineersFromModel()
        {
            var model = _view.F1ChiefEngineers;
            var entities = _mapperService.Map<IEnumerable<F1ChiefEngineerModel>, IEnumerable<F1ChiefEngineerEntity>>(model);
            _applicationService.DomainModel.Persons.SetF1ChiefEngineers(entities);
        }

        private void UpdateF1ChiefMechanicsFromModel()
        {
            var model = _view.F1ChiefMechanics;
            var entities = _mapperService.Map<IEnumerable<F1ChiefMechanicModel>, IEnumerable<F1ChiefMechanicEntity>>(model);
            _applicationService.DomainModel.Persons.SetF1ChiefMechanics(entities);
        }

        private void UpdateNonF1ChiefCommercialsFromModel()
        {
            var model = _view.NonF1ChiefCommercials;
            var entities = _mapperService.Map<IEnumerable<NonF1ChiefCommercialModel>, IEnumerable<NonF1ChiefCommercialEntity>>(model);
            _applicationService.DomainModel.Persons.SetNonF1ChiefCommercials(entities);
        }

        private void UpdateNonF1ChiefDesignersFromModel()
        {
            var model = _view.NonF1ChiefDesigners;
            var entities = _mapperService.Map<IEnumerable<NonF1ChiefDesignerModel>, IEnumerable<NonF1ChiefDesignerEntity>>(model);
            _applicationService.DomainModel.Persons.SetNonF1ChiefDesigners(entities);
        }

        private void UpdateNonF1ChiefEngineersFromModel()
        {
            var model = _view.NonF1ChiefEngineers;
            var entities = _mapperService.Map<IEnumerable<NonF1ChiefEngineerModel>, IEnumerable<NonF1ChiefEngineerEntity>>(model);
            _applicationService.DomainModel.Persons.SetNonF1ChiefEngineers(entities);
        }

        private void UpdateNonF1ChiefMechanicsFromModel()
        {
            var model = _view.NonF1ChiefMechanics;
            var entities = _mapperService.Map<IEnumerable<NonF1ChiefMechanicModel>, IEnumerable<NonF1ChiefMechanicEntity>>(model);
            _applicationService.DomainModel.Persons.SetNonF1ChiefMechanics(entities);
        }

        private void UpdateF1DriversFromModel()
        {
            var model = _view.F1Drivers;
            var entities = _mapperService.Map<IEnumerable<F1DriverModel>, IEnumerable<F1DriverEntity>>(model);
            _applicationService.DomainModel.Persons.SetF1Drivers(entities);
        }

        private void UpdateNonF1DriversFromModel()
        {
            var model = _view.NonF1Drivers;
            var entities = _mapperService.Map<IEnumerable<NonF1DriverModel>, IEnumerable<NonF1DriverEntity>>(model);
            _applicationService.DomainModel.Persons.SetNonF1Drivers(entities);
        }

        private void UpdateSuppliersEnginesFromModel()
        {
            var model = _view.Engines;
            var entities = _mapperService.Map<IEnumerable<EngineModel>, IEnumerable<EngineEntity>>(model);
            _applicationService.DomainModel.Suppliers.SetEngines(entities);
        }

        private void UpdateSuppliersTyresFromModel()
        {
            var model = _view.Tyres;
            var entities = _mapperService.Map<IEnumerable<TyreModel>, IEnumerable<TyreEntity>>(model);
            _applicationService.DomainModel.Suppliers.SetTyres(entities);
        }

        private void UpdateSuppliersFuelsFromModel()
        {
            var model = _view.Fuels;
            var entities = _mapperService.Map<IEnumerable<FuelModel>, IEnumerable<FuelEntity>>(model);
            _applicationService.DomainModel.Suppliers.SetFuels(entities);
        }

        private void UpdateTracksFromModel()
        {
            var model = _view.Tracks;
            var entities = _mapperService.Map<IEnumerable<TrackModel>, IEnumerable<TrackEntity>>(model);
            _applicationService.DomainModel.Tracks.SetTracks(entities);
        }
        */

        /* TODO: Remove
        private void UpdateTeamsFromService()
        {
            var entities = _applicationService.DomainModel.Teams.GetTeams();
            var model = _mapperService.Map<IEnumerable<TeamEntity>, IEnumerable<TeamModel>>(entities);
            _view.Teams = model;
        }

        private void UpdateF1ChiefCommercialsFromService()
        {
            var entities = _applicationService.DomainModel.Persons.GetF1ChiefCommercials();
            var model = _mapperService.Map<IEnumerable<F1ChiefCommercialEntity>, IEnumerable<F1ChiefCommercialModel>>(entities);
            _view.F1ChiefCommercials = model;
        }

        private void UpdateF1ChiefDesignersFromService()
        {
            var entities = _applicationService.DomainModel.Persons.GetF1ChiefDesigners();
            var model = _mapperService.Map<IEnumerable<F1ChiefDesignerEntity>, IEnumerable<F1ChiefDesignerModel>>(entities);
            _view.F1ChiefDesigners = model;
        }

        private void UpdateF1ChiefEngineersFromService()
        {
            var entities = _applicationService.DomainModel.Persons.GetF1ChiefEngineers();
            var model = _mapperService.Map<IEnumerable<F1ChiefEngineerEntity>, IEnumerable<F1ChiefEngineerModel>>(entities);
            _view.F1ChiefEngineers = model;
        }

        private void UpdateF1ChiefMechanicsFromService()
        {
            var entities = _applicationService.DomainModel.Persons.GetF1ChiefMechanics();
            var model = _mapperService.Map<IEnumerable<F1ChiefMechanicEntity>, IEnumerable<F1ChiefMechanicModel>>(entities);
            _view.F1ChiefMechanics = model;
        }

        private void UpdateNonF1ChiefCommercialsFromService()
        {
            var entities = _applicationService.DomainModel.Persons.GetNonF1ChiefCommercials();
            var model = _mapperService.Map<IEnumerable<NonF1ChiefCommercialEntity>, IEnumerable<NonF1ChiefCommercialModel>>(entities);
            _view.NonF1ChiefCommercials = model;
        }

        private void UpdateNonF1ChiefDesignersFromService()
        {
            var entities = _applicationService.DomainModel.Persons.GetNonF1ChiefDesigners();
            var model = _mapperService.Map<IEnumerable<NonF1ChiefDesignerEntity>, IEnumerable<NonF1ChiefDesignerModel>>(entities);
            _view.NonF1ChiefDesigners = model;
        }

        private void UpdateNonF1ChiefEngineersFromService()
        {
            var entities = _applicationService.DomainModel.Persons.GetNonF1ChiefEngineers();
            var model = _mapperService.Map<IEnumerable<NonF1ChiefEngineerEntity>, IEnumerable<NonF1ChiefEngineerModel>>(entities);
            _view.NonF1ChiefEngineers = model;
        }

        private void UpdateNonF1ChiefMechanicsFromService()
        {
            var entities = _applicationService.DomainModel.Persons.GetNonF1ChiefMechanics();
            var model = _mapperService.Map<IEnumerable<NonF1ChiefMechanicEntity>, IEnumerable<NonF1ChiefMechanicModel>>(entities);
            _view.NonF1ChiefMechanics = model;
        }

        private void UpdateF1DriversFromService()
        {
            var entities = _applicationService.DomainModel.Persons.GetF1Drivers();
            var model = _mapperService.Map<IEnumerable<F1DriverEntity>, IEnumerable<F1DriverModel>>(entities);
            _view.F1Drivers = model;
        }

        private void UpdateNonF1DriversFromService()
        {
            var entities = _applicationService.DomainModel.Persons.GetNonF1Drivers();
            var model = _mapperService.Map<IEnumerable<NonF1DriverEntity>, IEnumerable<NonF1DriverModel>>(entities);
            _view.NonF1Drivers = model;
        }

        private void UpdateSuppliersEnginesFromService()
        {
            var entities = _applicationService.DomainModel.Suppliers.GetEngines();
            var model = _mapperService.Map<IEnumerable<EngineEntity>, IEnumerable<EngineModel>>(entities);
            _view.Engines = model;
        }

        private void UpdateSuppliersTyresFromService()
        {
            var entities = _applicationService.DomainModel.Suppliers.GetTyres();
            var model = _mapperService.Map<IEnumerable<TyreEntity>, IEnumerable<TyreModel>>(entities);
            _view.Tyres = model;
        }

        private void UpdateSuppliersFuelsFromService()
        {
            var entities = _applicationService.DomainModel.Suppliers.GetFuels();
            var model = _mapperService.Map<IEnumerable<FuelEntity>, IEnumerable<FuelModel>>(entities);
            _view.Fuels = model;
        }

        private void UpdateTracksFromService()
        {
            var entities = _applicationService.DomainModel.Tracks.GetTracks();
            var model = _mapperService.Map<IEnumerable<TrackEntity>, IEnumerable<TrackModel>>(entities);
            _view.Tracks = model;
        }
        */
    }
}