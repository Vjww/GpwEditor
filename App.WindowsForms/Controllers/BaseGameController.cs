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
    public class BaseGameController : ControllerBase
    {
        private BaseGameEditorForm _view;

        private readonly BaseGameApplicationService _baseGameApplicationService;
        private readonly IMapperService _mapperService;
        private readonly FormFactory _formFactory;

        public BaseGameController(
            BaseGameApplicationService baseGameApplicationService,
            IMapperService mapperService,
            FormFactory formFactory)
        {
            _baseGameApplicationService = baseGameApplicationService ?? throw new ArgumentNullException(nameof(baseGameApplicationService));
            _mapperService = mapperService ?? throw new ArgumentNullException(nameof(mapperService));
            _formFactory = formFactory ?? throw new ArgumentNullException(nameof(formFactory));
        }

        public void Run(Form parentView)
        {
            _view = _formFactory.Create<BaseGameEditorForm>();
            _view.SetController(this);
            ShowView(parentView, _view);
        }

        public void Import()
        {
            _baseGameApplicationService.Import(
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
            _baseGameApplicationService.Export(
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

        public void UpdateTeamsModelWithChassisHandlingValuesFromOriginalValues()
        {
            var teamEntities = _mapperService.Map<IEnumerable<TeamModel>, IEnumerable<TeamEntity>>(_view.Teams);

            var modifiedTeamEntities = _baseGameApplicationService.DomainModel.Teams.GetChassisHandlingValuesFromOriginalValues(teamEntities);

            var model = _mapperService.Map<IEnumerable<TeamEntity>, IEnumerable<TeamModel>>(modifiedTeamEntities);
            _view.UpdateTeamsModelWithUpdatedChassisHandlingValues(model);
        }

        public void UpdateTeamsModelWithChassisHandlingValuesFromRandomisedModifiedDesignCalculation()
        {
            var teamEntities = _mapperService.Map<IEnumerable<TeamModel>, IEnumerable<TeamEntity>>(_view.Teams);
            var chiefDesignerEntities = _mapperService.Map<IEnumerable<F1ChiefDesignerModel>, IEnumerable<F1ChiefDesignerEntity>>(_view.F1ChiefDesigners);
            var chiefEngineerEntities = _mapperService.Map<IEnumerable<F1ChiefEngineerModel>, IEnumerable<F1ChiefEngineerEntity>>(_view.F1ChiefEngineers);

            var modifiedTeamEntities = _baseGameApplicationService.DomainModel.Teams.GetChassisHandlingValuesFromRandomisedModifiedDesignCalculation(
                teamEntities, chiefDesignerEntities, chiefEngineerEntities);

            var model = _mapperService.Map<IEnumerable<TeamEntity>, IEnumerable<TeamModel>>(modifiedTeamEntities);
            _view.UpdateTeamsModelWithUpdatedChassisHandlingValues(model);
        }

        public void UpdateTeamsModelWithChassisHandlingValuesFromRecommendedValues()
        {
            var teamEntities = _mapperService.Map<IEnumerable<TeamModel>, IEnumerable<TeamEntity>>(_view.Teams);

            var modifiedTeamEntities = _baseGameApplicationService.DomainModel.Teams.GetChassisHandlingValuesFromRecommendedValues(teamEntities);

            var model = _mapperService.Map<IEnumerable<TeamEntity>, IEnumerable<TeamModel>>(modifiedTeamEntities);
            _view.UpdateTeamsModelWithUpdatedChassisHandlingValues(model);
        }

        private void UpdateModelsFromService()
        {
            _view.ChiefDriverLoyaltyLookups = UpdateModelFromService<IEnumerable<ChiefDriverLoyaltyLookupEntity>, IEnumerable<ChiefDriverLoyaltyLookupModel>>(_baseGameApplicationService.DomainModel.Lookups.GetChiefDriverLoyaltyLookups);
            _view.DriverNationalityLookups = UpdateModelFromService<IEnumerable<DriverNationalityLookupEntity>, IEnumerable<DriverNationalityLookupModel>>(_baseGameApplicationService.DomainModel.Lookups.GetDriverNationalityLookups);
            _view.DriverRoleLookups = UpdateModelFromService<IEnumerable<DriverRoleLookupEntity>, IEnumerable<DriverRoleLookupModel>>(_baseGameApplicationService.DomainModel.Lookups.GetDriverRoleLookups);
            _view.TeamDebutGrandPrixLookups = UpdateModelFromService<IEnumerable<TeamDebutGrandPrixLookupEntity>, IEnumerable<TeamDebutGrandPrixLookupModel>>(_baseGameApplicationService.DomainModel.Lookups.GetTeamDebutGrandPrixLookups);
            _view.TeamLocationLookups = UpdateTeamLocationLookupModel();
            _view.TrackDriverLookups = UpdateModelFromService<IEnumerable<TrackDriverLookupEntity>, IEnumerable<TrackDriverLookupModel>>(_baseGameApplicationService.DomainModel.Lookups.GetTrackDriverLookups);
            _view.TrackLayoutLookups = UpdateModelFromService<IEnumerable<TrackLayoutLookupEntity>, IEnumerable<TrackLayoutLookupModel>>(_baseGameApplicationService.DomainModel.Lookups.GetTrackLayoutLookups);
            _view.TrackTeamLookups = UpdateModelFromService<IEnumerable<TrackTeamLookupEntity>, IEnumerable<TrackTeamLookupModel>>(_baseGameApplicationService.DomainModel.Lookups.GetTrackTeamLookups);
            _view.TyreSupplierLookups = UpdateModelFromService<IEnumerable<TyreSupplierLookupEntity>, IEnumerable<TyreSupplierLookupModel>>(_baseGameApplicationService.DomainModel.Lookups.GetTyreSupplierLookups);

            _view.Teams = UpdateModelFromService<IEnumerable<TeamEntity>, IEnumerable<TeamModel>>(_baseGameApplicationService.DomainModel.Teams.GetTeams);
            _view.F1ChiefCommercials = UpdateModelFromService<IEnumerable<F1ChiefCommercialEntity>, IEnumerable<F1ChiefCommercialModel>>(_baseGameApplicationService.DomainModel.Persons.GetF1ChiefCommercials);
            _view.F1ChiefDesigners = UpdateModelFromService<IEnumerable<F1ChiefDesignerEntity>, IEnumerable<F1ChiefDesignerModel>>(_baseGameApplicationService.DomainModel.Persons.GetF1ChiefDesigners);
            _view.F1ChiefEngineers = UpdateModelFromService<IEnumerable<F1ChiefEngineerEntity>, IEnumerable<F1ChiefEngineerModel>>(_baseGameApplicationService.DomainModel.Persons.GetF1ChiefEngineers);
            _view.F1ChiefMechanics = UpdateModelFromService<IEnumerable<F1ChiefMechanicEntity>, IEnumerable<F1ChiefMechanicModel>>(_baseGameApplicationService.DomainModel.Persons.GetF1ChiefMechanics);
            _view.NonF1ChiefCommercials = UpdateModelFromService<IEnumerable<NonF1ChiefCommercialEntity>, IEnumerable<NonF1ChiefCommercialModel>>(_baseGameApplicationService.DomainModel.Persons.GetNonF1ChiefCommercials);
            _view.NonF1ChiefDesigners = UpdateModelFromService<IEnumerable<NonF1ChiefDesignerEntity>, IEnumerable<NonF1ChiefDesignerModel>>(_baseGameApplicationService.DomainModel.Persons.GetNonF1ChiefDesigners);
            _view.NonF1ChiefEngineers = UpdateModelFromService<IEnumerable<NonF1ChiefEngineerEntity>, IEnumerable<NonF1ChiefEngineerModel>>(_baseGameApplicationService.DomainModel.Persons.GetNonF1ChiefEngineers);
            _view.NonF1ChiefMechanics = UpdateModelFromService<IEnumerable<NonF1ChiefMechanicEntity>, IEnumerable<NonF1ChiefMechanicModel>>(_baseGameApplicationService.DomainModel.Persons.GetNonF1ChiefMechanics);
            _view.F1Drivers = UpdateModelFromService<IEnumerable<F1DriverEntity>, IEnumerable<F1DriverModel>>(_baseGameApplicationService.DomainModel.Persons.GetF1Drivers);
            _view.NonF1Drivers = UpdateModelFromService<IEnumerable<NonF1DriverEntity>, IEnumerable<NonF1DriverModel>>(_baseGameApplicationService.DomainModel.Persons.GetNonF1Drivers);
            _view.Engines = UpdateModelFromService<IEnumerable<EngineEntity>, IEnumerable<EngineModel>>(_baseGameApplicationService.DomainModel.Suppliers.GetEngines);
            _view.Tyres = UpdateModelFromService<IEnumerable<TyreEntity>, IEnumerable<TyreModel>>(_baseGameApplicationService.DomainModel.Suppliers.GetTyres);
            _view.Fuels = UpdateModelFromService<IEnumerable<FuelEntity>, IEnumerable<FuelModel>>(_baseGameApplicationService.DomainModel.Suppliers.GetFuels);
            _view.Tracks = UpdateModelFromService<IEnumerable<TrackEntity>, IEnumerable<TrackModel>>(_baseGameApplicationService.DomainModel.Tracks.GetTracks);

            // TODO:
            //_view.RunningCosts = UpdateModelFromService<IEnumerable<RunningCostEntity>, IEnumerable<RunningCostModel>>(_baseGameApplicationService.DomainModel.Misc.GetRunningCosts);
            //_view.ExpansionCosts = UpdateModelFromService<IEnumerable<ExpansionCostEntity>, IEnumerable<ExpansionCostModel>>(_baseGameApplicationService.DomainModel.Misc.GetExpansionCosts);
            //_view.StaffEfforts = UpdateModelFromService<IEnumerable<StaffEffortEntity>, IEnumerable<StaffEffortModel>>(_baseGameApplicationService.DomainModel.Misc.GetStaffEfforts);
            //_view.StaffSalaries = UpdateModelFromService<IEnumerable<StaffSalaryEntity>, IEnumerable<StaffSalaryModel>>(_baseGameApplicationService.DomainModel.Misc.GetStaffSalaries);
            //_view.TestingMiles = UpdateModelFromService<IEnumerable<TestingMileEntity>, IEnumerable<TestingMileModel>>(_baseGameApplicationService.DomainModel.Misc.GetTestingMiles);
            //_view.EngineeringCosts = UpdateModelFromService<IEnumerable<EngineeringCostEntity>, IEnumerable<EngineeringCostModel>>(_baseGameApplicationService.DomainModel.Misc.GetEngineeringCosts);
            //_view.UnknownA = UpdateModelFromService<IEnumerable<UnknownAEntity>, IEnumerable<UnknownAModel>>(_baseGameApplicationService.DomainModel.Misc.GetUnknownAs);
            //_view.UnknownB = UpdateModelFromService<IEnumerable<UnknownBEntity>, IEnumerable<UnknownBModel>>(_baseGameApplicationService.DomainModel.Misc.GetUnknownBs);
        }

        private void UpdateServiceFromModels()
        {
            UpdateServiceFromModel<IEnumerable<TeamModel>, IEnumerable<TeamEntity>>(_baseGameApplicationService.DomainModel.Teams.SetTeams, _view.Teams);
            UpdateServiceFromModel<IEnumerable<F1ChiefCommercialModel>, IEnumerable<F1ChiefCommercialEntity>>(_baseGameApplicationService.DomainModel.Persons.SetF1ChiefCommercials, _view.F1ChiefCommercials);
            UpdateServiceFromModel<IEnumerable<F1ChiefDesignerModel>, IEnumerable<F1ChiefDesignerEntity>>(_baseGameApplicationService.DomainModel.Persons.SetF1ChiefDesigners, _view.F1ChiefDesigners);
            UpdateServiceFromModel<IEnumerable<F1ChiefEngineerModel>, IEnumerable<F1ChiefEngineerEntity>>(_baseGameApplicationService.DomainModel.Persons.SetF1ChiefEngineers, _view.F1ChiefEngineers);
            UpdateServiceFromModel<IEnumerable<F1ChiefMechanicModel>, IEnumerable<F1ChiefMechanicEntity>>(_baseGameApplicationService.DomainModel.Persons.SetF1ChiefMechanics, _view.F1ChiefMechanics);
            UpdateServiceFromModel<IEnumerable<NonF1ChiefCommercialModel>, IEnumerable<NonF1ChiefCommercialEntity>>(_baseGameApplicationService.DomainModel.Persons.SetNonF1ChiefCommercials, _view.NonF1ChiefCommercials);
            UpdateServiceFromModel<IEnumerable<NonF1ChiefDesignerModel>, IEnumerable<NonF1ChiefDesignerEntity>>(_baseGameApplicationService.DomainModel.Persons.SetNonF1ChiefDesigners, _view.NonF1ChiefDesigners);
            UpdateServiceFromModel<IEnumerable<NonF1ChiefEngineerModel>, IEnumerable<NonF1ChiefEngineerEntity>>(_baseGameApplicationService.DomainModel.Persons.SetNonF1ChiefEngineers, _view.NonF1ChiefEngineers);
            UpdateServiceFromModel<IEnumerable<NonF1ChiefMechanicModel>, IEnumerable<NonF1ChiefMechanicEntity>>(_baseGameApplicationService.DomainModel.Persons.SetNonF1ChiefMechanics, _view.NonF1ChiefMechanics);
            UpdateServiceFromModel<IEnumerable<F1DriverModel>, IEnumerable<F1DriverEntity>>(_baseGameApplicationService.DomainModel.Persons.SetF1Drivers, _view.F1Drivers);
            UpdateServiceFromModel<IEnumerable<NonF1DriverModel>, IEnumerable<NonF1DriverEntity>>(_baseGameApplicationService.DomainModel.Persons.SetNonF1Drivers, _view.NonF1Drivers);
            UpdateServiceFromModel<IEnumerable<EngineModel>, IEnumerable<EngineEntity>>(_baseGameApplicationService.DomainModel.Suppliers.SetEngines, _view.Engines);
            UpdateServiceFromModel<IEnumerable<TyreModel>, IEnumerable<TyreEntity>>(_baseGameApplicationService.DomainModel.Suppliers.SetTyres, _view.Tyres);
            UpdateServiceFromModel<IEnumerable<FuelModel>, IEnumerable<FuelEntity>>(_baseGameApplicationService.DomainModel.Suppliers.SetFuels, _view.Fuels);
            UpdateServiceFromModel<IEnumerable<TrackModel>, IEnumerable<TrackEntity>>(_baseGameApplicationService.DomainModel.Tracks.SetTracks, _view.Tracks);

            // TODO:
            //UpdateServiceFromModel<IEnumerable<RunningCostModel>, IEnumerable<RunningCostEntity>>(_baseGameApplicationService.DomainModel.Misc.GetRunningCosts, _view.RunningCosts);
            //UpdateServiceFromModel<IEnumerable<ExpansionCostModel>, IEnumerable<ExpansionCostEntity>>(_baseGameApplicationService.DomainModel.Misc.GetExpansionCosts, _view.ExpansionCosts);
            //UpdateServiceFromModel<IEnumerable<StaffEffortModel>, IEnumerable<StaffEffortEntity>>(_baseGameApplicationService.DomainModel.Misc.GetStaffEfforts, _view.StaffEfforts);
            //UpdateServiceFromModel<IEnumerable<StaffSalaryModel>, IEnumerable<StaffSalaryEntity>>(_baseGameApplicationService.DomainModel.Misc.GetStaffSalaries, _view.StaffSalaries);
            //UpdateServiceFromModel<IEnumerable<TestingMileModel>, IEnumerable<TestingMileEntity>>(_baseGameApplicationService.DomainModel.Misc.GetTestingMiles, _view.TestingMiles);
            //UpdateServiceFromModel<IEnumerable<EngineeringCostModel>, IEnumerable<EngineeringCostEntity>>(_baseGameApplicationService.DomainModel.Misc.GetEngineeringCosts, _view.EngineeringCosts);
            //UpdateServiceFromModel<IEnumerable<UnknownAModel>, IEnumerable<UnknownAEntity>>(_baseGameApplicationService.DomainModel.Misc.GetUnknownAs, _view.UnknownAs);
            //UpdateServiceFromModel<IEnumerable<UnknownBModel>, IEnumerable<UnknownBEntity>>(_baseGameApplicationService.DomainModel.Misc.GetUnknownBs, _view.UnknownBs);
        }

        private static IEnumerable<TeamLocationLookupModel> UpdateTeamLocationLookupModel()
        {
            return new List<TeamLocationLookupModel>
            {
                new TeamLocationLookupModel {Id = 0, Description = "France", Value = 0},
                new TeamLocationLookupModel {Id = 1, Description = "Great Britain", Value = 1},
                new TeamLocationLookupModel {Id = 2, Description = "Italy", Value = 2},
                new TeamLocationLookupModel {Id = 3, Description = "Switzerland", Value = 3}
            };
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
            var entities = _baseGameApplicationService.DomainModel.Lookups.GetChiefDriverLoyaltyLookups();
            var model = _mapperService.Map<IEnumerable<ChiefDriverLoyaltyLookupEntity>, IEnumerable<ChiefDriverLoyaltyLookupModel>>(entities);
            _view.ChiefDriverLoyaltyLookups = model;
        }

        private void UpdateDriverNationalityLookupsFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Lookups.GetDriverNationalityLookups();
            var model = _mapperService.Map<IEnumerable<DriverNationalityLookupEntity>, IEnumerable<DriverNationalityLookupModel>>(entities);
            _view.DriverNationalityLookups = model;
        }

        private void UpdateTeamDebutGrandPrixLookupsFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Lookups.GetTeamDebutGrandPrixLookups();
            var model = _mapperService.Map<IEnumerable<TeamDebutGrandPrixLookupEntity>, IEnumerable<TeamDebutGrandPrixLookupModel>>(entities);
            _view.TeamDebutGrandPrixLookups = model;
        }

        private void UpdateTrackFastestLapDriverLookupsFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Lookups.GetTrackDriverLookups();
            var model = _mapperService.Map<IEnumerable<TrackDriverLookupEntity>, IEnumerable<TrackDriverLookupModel>>(entities);
            _view.TrackDriverLookups = model;
        }

        private void UpdateTrackLayoutLookupsFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Lookups.GetTrackLayoutLookups();
            var model = _mapperService.Map<IEnumerable<TrackLayoutLookupEntity>, IEnumerable<TrackLayoutLookupModel>>(entities);
            _view.TrackLayoutLookups = model;
        }

        private void UpdateTyreSupplierLookupsFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Lookups.GetTyreSupplierLookups();
            var model = _mapperService.Map<IEnumerable<TyreSupplierLookupEntity>, IEnumerable<TyreSupplierLookupModel>>(entities);
            _view.TyreSupplierLookups = model;
        }
        */

        /* TODO: Remove
        private void UpdateTeamsFromModel()
        {
            var model = _view.Teams;
            var entities = _mapperService.Map<IEnumerable<TeamModel>, IEnumerable<TeamEntity>>(model);
            _baseGameApplicationService.DomainModel.Teams.SetTeams(entities);
        }

        private void UpdateF1ChiefCommercialsFromModel()
        {
            var model = _view.F1ChiefCommercials;
            var entities = _mapperService.Map<IEnumerable<F1ChiefCommercialModel>, IEnumerable<F1ChiefCommercialEntity>>(model);
            _baseGameApplicationService.DomainModel.Persons.SetF1ChiefCommercials(entities);
        }

        private void UpdateF1ChiefDesignersFromModel()
        {
            var model = _view.F1ChiefDesigners;
            var entities = _mapperService.Map<IEnumerable<F1ChiefDesignerModel>, IEnumerable<F1ChiefDesignerEntity>>(model);
            _baseGameApplicationService.DomainModel.Persons.SetF1ChiefDesigners(entities);
        }

        private void UpdateF1ChiefEngineersFromModel()
        {
            var model = _view.F1ChiefEngineers;
            var entities = _mapperService.Map<IEnumerable<F1ChiefEngineerModel>, IEnumerable<F1ChiefEngineerEntity>>(model);
            _baseGameApplicationService.DomainModel.Persons.SetF1ChiefEngineers(entities);
        }

        private void UpdateF1ChiefMechanicsFromModel()
        {
            var model = _view.F1ChiefMechanics;
            var entities = _mapperService.Map<IEnumerable<F1ChiefMechanicModel>, IEnumerable<F1ChiefMechanicEntity>>(model);
            _baseGameApplicationService.DomainModel.Persons.SetF1ChiefMechanics(entities);
        }

        private void UpdateNonF1ChiefCommercialsFromModel()
        {
            var model = _view.NonF1ChiefCommercials;
            var entities = _mapperService.Map<IEnumerable<NonF1ChiefCommercialModel>, IEnumerable<NonF1ChiefCommercialEntity>>(model);
            _baseGameApplicationService.DomainModel.Persons.SetNonF1ChiefCommercials(entities);
        }

        private void UpdateNonF1ChiefDesignersFromModel()
        {
            var model = _view.NonF1ChiefDesigners;
            var entities = _mapperService.Map<IEnumerable<NonF1ChiefDesignerModel>, IEnumerable<NonF1ChiefDesignerEntity>>(model);
            _baseGameApplicationService.DomainModel.Persons.SetNonF1ChiefDesigners(entities);
        }

        private void UpdateNonF1ChiefEngineersFromModel()
        {
            var model = _view.NonF1ChiefEngineers;
            var entities = _mapperService.Map<IEnumerable<NonF1ChiefEngineerModel>, IEnumerable<NonF1ChiefEngineerEntity>>(model);
            _baseGameApplicationService.DomainModel.Persons.SetNonF1ChiefEngineers(entities);
        }

        private void UpdateNonF1ChiefMechanicsFromModel()
        {
            var model = _view.NonF1ChiefMechanics;
            var entities = _mapperService.Map<IEnumerable<NonF1ChiefMechanicModel>, IEnumerable<NonF1ChiefMechanicEntity>>(model);
            _baseGameApplicationService.DomainModel.Persons.SetNonF1ChiefMechanics(entities);
        }

        private void UpdateF1DriversFromModel()
        {
            var model = _view.F1Drivers;
            var entities = _mapperService.Map<IEnumerable<F1DriverModel>, IEnumerable<F1DriverEntity>>(model);
            _baseGameApplicationService.DomainModel.Persons.SetF1Drivers(entities);
        }

        private void UpdateNonF1DriversFromModel()
        {
            var model = _view.NonF1Drivers;
            var entities = _mapperService.Map<IEnumerable<NonF1DriverModel>, IEnumerable<NonF1DriverEntity>>(model);
            _baseGameApplicationService.DomainModel.Persons.SetNonF1Drivers(entities);
        }

        private void UpdateSuppliersEnginesFromModel()
        {
            var model = _view.Engines;
            var entities = _mapperService.Map<IEnumerable<EngineModel>, IEnumerable<EngineEntity>>(model);
            _baseGameApplicationService.DomainModel.Suppliers.SetEngines(entities);
        }

        private void UpdateSuppliersTyresFromModel()
        {
            var model = _view.Tyres;
            var entities = _mapperService.Map<IEnumerable<TyreModel>, IEnumerable<TyreEntity>>(model);
            _baseGameApplicationService.DomainModel.Suppliers.SetTyres(entities);
        }

        private void UpdateSuppliersFuelsFromModel()
        {
            var model = _view.Fuels;
            var entities = _mapperService.Map<IEnumerable<FuelModel>, IEnumerable<FuelEntity>>(model);
            _baseGameApplicationService.DomainModel.Suppliers.SetFuels(entities);
        }

        private void UpdateTracksFromModel()
        {
            var model = _view.Tracks;
            var entities = _mapperService.Map<IEnumerable<TrackModel>, IEnumerable<TrackEntity>>(model);
            _baseGameApplicationService.DomainModel.Tracks.SetTracks(entities);
        }
        */

        /* TODO: Remove
        private void UpdateTeamsFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Teams.GetTeams();
            var model = _mapperService.Map<IEnumerable<TeamEntity>, IEnumerable<TeamModel>>(entities);
            _view.Teams = model;
        }

        private void UpdateF1ChiefCommercialsFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Persons.GetF1ChiefCommercials();
            var model = _mapperService.Map<IEnumerable<F1ChiefCommercialEntity>, IEnumerable<F1ChiefCommercialModel>>(entities);
            _view.F1ChiefCommercials = model;
        }

        private void UpdateF1ChiefDesignersFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Persons.GetF1ChiefDesigners();
            var model = _mapperService.Map<IEnumerable<F1ChiefDesignerEntity>, IEnumerable<F1ChiefDesignerModel>>(entities);
            _view.F1ChiefDesigners = model;
        }

        private void UpdateF1ChiefEngineersFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Persons.GetF1ChiefEngineers();
            var model = _mapperService.Map<IEnumerable<F1ChiefEngineerEntity>, IEnumerable<F1ChiefEngineerModel>>(entities);
            _view.F1ChiefEngineers = model;
        }

        private void UpdateF1ChiefMechanicsFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Persons.GetF1ChiefMechanics();
            var model = _mapperService.Map<IEnumerable<F1ChiefMechanicEntity>, IEnumerable<F1ChiefMechanicModel>>(entities);
            _view.F1ChiefMechanics = model;
        }

        private void UpdateNonF1ChiefCommercialsFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Persons.GetNonF1ChiefCommercials();
            var model = _mapperService.Map<IEnumerable<NonF1ChiefCommercialEntity>, IEnumerable<NonF1ChiefCommercialModel>>(entities);
            _view.NonF1ChiefCommercials = model;
        }

        private void UpdateNonF1ChiefDesignersFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Persons.GetNonF1ChiefDesigners();
            var model = _mapperService.Map<IEnumerable<NonF1ChiefDesignerEntity>, IEnumerable<NonF1ChiefDesignerModel>>(entities);
            _view.NonF1ChiefDesigners = model;
        }

        private void UpdateNonF1ChiefEngineersFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Persons.GetNonF1ChiefEngineers();
            var model = _mapperService.Map<IEnumerable<NonF1ChiefEngineerEntity>, IEnumerable<NonF1ChiefEngineerModel>>(entities);
            _view.NonF1ChiefEngineers = model;
        }

        private void UpdateNonF1ChiefMechanicsFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Persons.GetNonF1ChiefMechanics();
            var model = _mapperService.Map<IEnumerable<NonF1ChiefMechanicEntity>, IEnumerable<NonF1ChiefMechanicModel>>(entities);
            _view.NonF1ChiefMechanics = model;
        }

        private void UpdateF1DriversFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Persons.GetF1Drivers();
            var model = _mapperService.Map<IEnumerable<F1DriverEntity>, IEnumerable<F1DriverModel>>(entities);
            _view.F1Drivers = model;
        }

        private void UpdateNonF1DriversFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Persons.GetNonF1Drivers();
            var model = _mapperService.Map<IEnumerable<NonF1DriverEntity>, IEnumerable<NonF1DriverModel>>(entities);
            _view.NonF1Drivers = model;
        }

        private void UpdateSuppliersEnginesFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Suppliers.GetEngines();
            var model = _mapperService.Map<IEnumerable<EngineEntity>, IEnumerable<EngineModel>>(entities);
            _view.Engines = model;
        }

        private void UpdateSuppliersTyresFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Suppliers.GetTyres();
            var model = _mapperService.Map<IEnumerable<TyreEntity>, IEnumerable<TyreModel>>(entities);
            _view.Tyres = model;
        }

        private void UpdateSuppliersFuelsFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Suppliers.GetFuels();
            var model = _mapperService.Map<IEnumerable<FuelEntity>, IEnumerable<FuelModel>>(entities);
            _view.Fuels = model;
        }

        private void UpdateTracksFromService()
        {
            var entities = _baseGameApplicationService.DomainModel.Tracks.GetTracks();
            var model = _mapperService.Map<IEnumerable<TrackEntity>, IEnumerable<TrackModel>>(entities);
            _view.Tracks = model;
        }
        */
    }
}