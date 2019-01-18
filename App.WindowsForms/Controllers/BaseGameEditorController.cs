using System;
using System.Collections.Generic;
using System.Windows.Forms;
using App.BaseGameEditor.Application.Services.Application;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Entities.Lookups;
using App.Shared.Infrastructure.Services;
using App.WindowsForms.Factories;
using App.WindowsForms.Models;
using App.WindowsForms.Models.Lookups;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public class BaseGameEditorController : ControllerBase
    {
        private BaseGameEditorForm _view;
        private bool _isImportOccurred;
        private bool _isModified;

        private readonly BaseGameEditorApplicationService _baseGameEditorApplicationService;
        private readonly FormFactory _formFactory;

        public BaseGameEditorController(
            BaseGameEditorApplicationService baseGameEditorApplicationService,
            IMapperService mapperService,
            FormFactory formFactory)
            : base(mapperService)
        {
            _baseGameEditorApplicationService = baseGameEditorApplicationService ?? throw new ArgumentNullException(nameof(baseGameEditorApplicationService));
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
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _baseGameEditorApplicationService.Import(
                    _view.GameFolderPath,
                    _view.GameExecutableFilePath,
                    _view.EnglishLanguageFilePath,
                    _view.FrenchLanguageFilePath,
                    _view.GermanLanguageFilePath,
                    _view.EnglishCommentaryFilePath,
                    _view.FrenchCommentaryFilePath,
                    _view.GermanCommentaryFilePath);

                UpdateModelsFromService();

                _isImportOccurred = true;
                _isModified = false;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                _view.ShowErrorBox(ex.Message);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            _view.ShowMessageBox("Import complete!");
        }

        public void Export()
        {
            if (!_isImportOccurred)
            {
                _view.ShowMessageBox("Unable to export until a successful import has occurred.", MessageBoxIcon.Error);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                UpdateServiceFromModels();

                // TODO: Implement field validation
                //if (!_baseGameEditorApplicationService.DomainModel.IsValid)
                //{
                //    UpdateValidationModels();
                //    DisplayValidationMessages();

                //    throw new Exception("Your changes have failed validation. Please review the validation messages and try again.");
                //}

                _baseGameEditorApplicationService.Export(
                    _view.GameFolderPath,
                    _view.GameExecutableFilePath,
                    _view.EnglishLanguageFilePath,
                    _view.FrenchLanguageFilePath,
                    _view.GermanLanguageFilePath,
                    _view.EnglishCommentaryFilePath,
                    _view.FrenchCommentaryFilePath,
                    _view.GermanCommentaryFilePath);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                _view.ShowErrorBox(ex.Message);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            _view.ShowMessageBox("Export complete!");
        }

        public void LoadView()
        {
            _view.SetFormIcon(GetFormIcon());
            _view.SetFormText($"{GetApplicationName()} - Game Executable Editor");
            _view.SetRichTextBoxRichText(ConvertStringArrayToRichText(_view.GetRichTextBoxLines()));

            // Populate paths with most recently used (MRU) or default
            _view.GameFolderPath = GetGameFolderMruOrDefault();
            _view.GameExecutableFilePath = GetGameExecutableMruOrDefault();
            _view.EnglishLanguageFilePath = GetEnglishLanguageFileMruOrDefault();
            _view.FrenchLanguageFilePath = GetFrenchLanguageFileMruOrDefault();
            _view.GermanLanguageFilePath = GetGermanLanguageFileMruOrDefault();
            _view.EnglishCommentaryFilePath = GetEnglishCommentaryFileMruOrDefault();
            _view.FrenchCommentaryFilePath = GetFrenchCommentaryFileMruOrDefault();
            _view.GermanCommentaryFilePath = GetGermanCommentaryFileMruOrDefault();

            // ConfigureControls(); // TODO: Suspect no longer needed
            _view.SubscribeDataGridViewControlsToGenericEvents(); // TODO: What's this for, I think it is still needed in the rewrite... for comboboxes
        }

        public bool CloseForm()
        {
            // TODO: Reconsider for validation rewrite, may now be redundant due to removal of validation when exiting a cell.
            //if (_isFailedValidationForSwitchingContext) 
            //{
            //    e.Cancel = true; // Abort event
            //    _isFailedValidationForSwitchingContext = false; // Reset
            //    return;
            //}

            if (CloseFormConfirmation(_view, _isModified, $"Are you sure you wish to close this window?{Environment.NewLine}{Environment.NewLine}Any changes not exported will be lost."))
            {
                return true;
            }

            return false;
        }

        public bool ChangeTab()
        {
            // TODO: Reconsider for validation rewrite, may now be redundant due to removal of validation when exiting a cell.
            //if (_isFailedValidationForSwitchingContext)
            //{
            //    e.Cancel = true; // Abort event
            //    _isFailedValidationForSwitchingContext = false; // Reset
            //}

            if (_isImportOccurred)
            {
                _isModified = true;
                return true;
            }

            _view.ShowMessageBox("Unable to switch tabs until a successful import has occurred.", MessageBoxIcon.Error);
            return false;
        }

        public void ChangeGameFolder()
        {
            try
            {
                var result = GetGameFolderPathFromFolderBrowserDialog(_view);
                _view.GameFolderPath = string.IsNullOrEmpty(result) ? _view.GameFolderPath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeGameExecutable()
        {
            try
            {
                var result = GetGameExecutablePathFromOpenFileDialog(_view);
                _view.GameExecutableFilePath = string.IsNullOrEmpty(result) ? _view.GameExecutableFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeEnglishLanguageFile()
        {
            try
            {
                var result = GetEnglishLanguageFilePathFromOpenFileDialog(_view);
                _view.EnglishLanguageFilePath = string.IsNullOrEmpty(result) ? _view.EnglishLanguageFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeFrenchLanguageFile()
        {
            try
            {
                var result = GetFrenchLanguageFilePathFromOpenFileDialog(_view);
                _view.FrenchLanguageFilePath = string.IsNullOrEmpty(result) ? _view.FrenchLanguageFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeGermanLanguageFile()
        {
            try
            {
                var result = GetGermanLanguageFilePathFromOpenFileDialog(_view);
                _view.GermanLanguageFilePath = string.IsNullOrEmpty(result) ? _view.GermanLanguageFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeEnglishCommentaryFile()
        {
            try
            {
                var result = GetEnglishCommentaryFilePathFromOpenFileDialog(_view);
                _view.EnglishCommentaryFilePath = string.IsNullOrEmpty(result) ? _view.EnglishCommentaryFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeFrenchCommentaryFile()
        {
            try
            {
                var result = GetFrenchCommentaryFilePathFromOpenFileDialog(_view);
                _view.FrenchCommentaryFilePath = string.IsNullOrEmpty(result) ? _view.FrenchCommentaryFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeGermanCommentaryFile()
        {
            try
            {
                var result = GetGermanCommentaryFilePathFromOpenFileDialog(_view);
                _view.GermanCommentaryFilePath = string.IsNullOrEmpty(result) ? _view.GermanCommentaryFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void UpdateTeamsModelWithChassisHandlingValuesFromOriginalValues()
        {
            try
            {
                var entities = MapperService.Map<IEnumerable<TeamModel>, IEnumerable<TeamEntity>>(_view.Teams);

                var modifiedEntities = _baseGameEditorApplicationService.DomainModel.Teams.GetChassisHandlingValuesFromOriginalValues(entities);

                var model = MapperService.Map<IEnumerable<TeamEntity>, IEnumerable<TeamModel>>(modifiedEntities);
                _view.UpdateTeamsModelWithUpdatedChassisHandlingValues(model);
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void UpdateTeamsModelWithChassisHandlingValuesFromRandomisedModifiedDesignCalculation()
        {
            try
            {
                var teamEntities = MapperService.Map<IEnumerable<TeamModel>, IEnumerable<TeamEntity>>(_view.Teams);
                var chiefDesignerEntities = MapperService.Map<IEnumerable<F1ChiefDesignerModel>, IEnumerable<F1ChiefDesignerEntity>>(_view.F1ChiefDesigners);
                var chiefEngineerEntities = MapperService.Map<IEnumerable<F1ChiefEngineerModel>, IEnumerable<F1ChiefEngineerEntity>>(_view.F1ChiefEngineers);

                var modifiedTeamEntities = _baseGameEditorApplicationService.DomainModel.Teams.GetChassisHandlingValuesFromRandomisedModifiedDesignCalculation(
                    teamEntities, chiefDesignerEntities, chiefEngineerEntities);

                var model = MapperService.Map<IEnumerable<TeamEntity>, IEnumerable<TeamModel>>(modifiedTeamEntities);
                _view.UpdateTeamsModelWithUpdatedChassisHandlingValues(model);
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void UpdateTeamsModelWithChassisHandlingValuesFromRecommendedValues()
        {
            try
            {
                var entities = MapperService.Map<IEnumerable<TeamModel>, IEnumerable<TeamEntity>>(_view.Teams);

                var modifiedEntities = _baseGameEditorApplicationService.DomainModel.Teams.GetChassisHandlingValuesFromRecommendedValues(entities);

                var model = MapperService.Map<IEnumerable<TeamEntity>, IEnumerable<TeamModel>>(modifiedEntities);
                _view.UpdateTeamsModelWithUpdatedChassisHandlingValues(model);
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        private void DisplayValidationMessages()
        {
            // TODO: Update view to display messages from validation viewmodels
        }

        private void UpdateModelsFromService()
        {
            _view.ChiefDriverLoyaltyLookups = UpdateModelFromService<IEnumerable<ChiefDriverLoyaltyLookupEntity>, IEnumerable<ChiefDriverLoyaltyLookupModel>>(_baseGameEditorApplicationService.DomainModel.Lookups.GetChiefDriverLoyaltyLookups);
            _view.DriverNationalityLookups = UpdateModelFromService<IEnumerable<DriverNationalityLookupEntity>, IEnumerable<DriverNationalityLookupModel>>(_baseGameEditorApplicationService.DomainModel.Lookups.GetDriverNationalityLookups);
            _view.DriverRoleLookups = UpdateModelFromService<IEnumerable<DriverRoleLookupEntity>, IEnumerable<DriverRoleLookupModel>>(_baseGameEditorApplicationService.DomainModel.Lookups.GetDriverRoleLookups);
            _view.TeamDebutGrandPrixLookups = UpdateModelFromService<IEnumerable<TeamDebutGrandPrixLookupEntity>, IEnumerable<TeamDebutGrandPrixLookupModel>>(_baseGameEditorApplicationService.DomainModel.Lookups.GetTeamDebutGrandPrixLookups);
            _view.TeamLocationLookups = UpdateTeamLocationLookupModel();
            _view.TrackDriverLookups = UpdateModelFromService<IEnumerable<TrackDriverLookupEntity>, IEnumerable<TrackDriverLookupModel>>(_baseGameEditorApplicationService.DomainModel.Lookups.GetTrackDriverLookups);
            _view.TrackLayoutLookups = UpdateModelFromService<IEnumerable<TrackLayoutLookupEntity>, IEnumerable<TrackLayoutLookupModel>>(_baseGameEditorApplicationService.DomainModel.Lookups.GetTrackLayoutLookups);
            _view.TrackTeamLookups = UpdateModelFromService<IEnumerable<TrackTeamLookupEntity>, IEnumerable<TrackTeamLookupModel>>(_baseGameEditorApplicationService.DomainModel.Lookups.GetTrackTeamLookups);
            _view.TyreSupplierLookups = UpdateModelFromService<IEnumerable<TyreSupplierLookupEntity>, IEnumerable<TyreSupplierLookupModel>>(_baseGameEditorApplicationService.DomainModel.Lookups.GetTyreSupplierLookups);

            _view.Teams = UpdateModelFromService<IEnumerable<TeamEntity>, IEnumerable<TeamModel>>(_baseGameEditorApplicationService.DomainModel.Teams.GetTeams);
            _view.F1ChiefCommercials = UpdateModelFromService<IEnumerable<F1ChiefCommercialEntity>, IEnumerable<F1ChiefCommercialModel>>(_baseGameEditorApplicationService.DomainModel.Persons.GetF1ChiefCommercials);
            _view.F1ChiefDesigners = UpdateModelFromService<IEnumerable<F1ChiefDesignerEntity>, IEnumerable<F1ChiefDesignerModel>>(_baseGameEditorApplicationService.DomainModel.Persons.GetF1ChiefDesigners);
            _view.F1ChiefEngineers = UpdateModelFromService<IEnumerable<F1ChiefEngineerEntity>, IEnumerable<F1ChiefEngineerModel>>(_baseGameEditorApplicationService.DomainModel.Persons.GetF1ChiefEngineers);
            _view.F1ChiefMechanics = UpdateModelFromService<IEnumerable<F1ChiefMechanicEntity>, IEnumerable<F1ChiefMechanicModel>>(_baseGameEditorApplicationService.DomainModel.Persons.GetF1ChiefMechanics);
            _view.NonF1ChiefCommercials = UpdateModelFromService<IEnumerable<NonF1ChiefCommercialEntity>, IEnumerable<NonF1ChiefCommercialModel>>(_baseGameEditorApplicationService.DomainModel.Persons.GetNonF1ChiefCommercials);
            _view.NonF1ChiefDesigners = UpdateModelFromService<IEnumerable<NonF1ChiefDesignerEntity>, IEnumerable<NonF1ChiefDesignerModel>>(_baseGameEditorApplicationService.DomainModel.Persons.GetNonF1ChiefDesigners);
            _view.NonF1ChiefEngineers = UpdateModelFromService<IEnumerable<NonF1ChiefEngineerEntity>, IEnumerable<NonF1ChiefEngineerModel>>(_baseGameEditorApplicationService.DomainModel.Persons.GetNonF1ChiefEngineers);
            _view.NonF1ChiefMechanics = UpdateModelFromService<IEnumerable<NonF1ChiefMechanicEntity>, IEnumerable<NonF1ChiefMechanicModel>>(_baseGameEditorApplicationService.DomainModel.Persons.GetNonF1ChiefMechanics);
            _view.F1Drivers = UpdateModelFromService<IEnumerable<F1DriverEntity>, IEnumerable<F1DriverModel>>(_baseGameEditorApplicationService.DomainModel.Persons.GetF1Drivers);
            _view.NonF1Drivers = UpdateModelFromService<IEnumerable<NonF1DriverEntity>, IEnumerable<NonF1DriverModel>>(_baseGameEditorApplicationService.DomainModel.Persons.GetNonF1Drivers);
            _view.SponsorTeams = UpdateModelFromService<IEnumerable<SponsorEntity>, IEnumerable<SponsorModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorTeams);
            _view.SponsorEngines = UpdateModelFromService<IEnumerable<SponsorEntity>, IEnumerable<SponsorModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorEngines);
            _view.SponsorTyres = UpdateModelFromService<IEnumerable<SponsorEntity>, IEnumerable<SponsorModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorTyres);
            _view.SponsorFuels = UpdateModelFromService<IEnumerable<SponsorEntity>, IEnumerable<SponsorModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorFuels);
            _view.SponsorCashs = UpdateModelFromService<IEnumerable<SponsorEntity>, IEnumerable<SponsorModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorCashs);
            _view.SponsorContractsTeam01 = UpdateModelFromService<IEnumerable<SponsorContractEntity>, IEnumerable<SponsorContractModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorContractsTeam01);
            _view.SponsorContractsTeam02 = UpdateModelFromService<IEnumerable<SponsorContractEntity>, IEnumerable<SponsorContractModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorContractsTeam02);
            _view.SponsorContractsTeam03 = UpdateModelFromService<IEnumerable<SponsorContractEntity>, IEnumerable<SponsorContractModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorContractsTeam03);
            _view.SponsorContractsTeam04 = UpdateModelFromService<IEnumerable<SponsorContractEntity>, IEnumerable<SponsorContractModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorContractsTeam04);
            _view.SponsorContractsTeam05 = UpdateModelFromService<IEnumerable<SponsorContractEntity>, IEnumerable<SponsorContractModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorContractsTeam05);
            _view.SponsorContractsTeam06 = UpdateModelFromService<IEnumerable<SponsorContractEntity>, IEnumerable<SponsorContractModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorContractsTeam06);
            _view.SponsorContractsTeam07 = UpdateModelFromService<IEnumerable<SponsorContractEntity>, IEnumerable<SponsorContractModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorContractsTeam07);
            _view.SponsorContractsTeam08 = UpdateModelFromService<IEnumerable<SponsorContractEntity>, IEnumerable<SponsorContractModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorContractsTeam08);
            _view.SponsorContractsTeam09 = UpdateModelFromService<IEnumerable<SponsorContractEntity>, IEnumerable<SponsorContractModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorContractsTeam09);
            _view.SponsorContractsTeam10 = UpdateModelFromService<IEnumerable<SponsorContractEntity>, IEnumerable<SponsorContractModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorContractsTeam10);
            _view.SponsorContractsTeam11 = UpdateModelFromService<IEnumerable<SponsorContractEntity>, IEnumerable<SponsorContractModel>>(_baseGameEditorApplicationService.DomainModel.Sponsors.GetSponsorContractsTeam11);
            _view.Tracks = UpdateModelFromService<IEnumerable<TrackEntity>, IEnumerable<TrackModel>>(_baseGameEditorApplicationService.DomainModel.Tracks.GetTracks);

            // TODO:
            //_view.RunningCosts = UpdateModelFromService<IEnumerable<RunningCostEntity>, IEnumerable<RunningCostModel>>(_baseGameEditorApplicationService.DomainModel.Misc.GetRunningCosts);
            //_view.ExpansionCosts = UpdateModelFromService<IEnumerable<ExpansionCostEntity>, IEnumerable<ExpansionCostModel>>(_baseGameEditorApplicationService.DomainModel.Misc.GetExpansionCosts);
            //_view.StaffEfforts = UpdateModelFromService<IEnumerable<StaffEffortEntity>, IEnumerable<StaffEffortModel>>(_baseGameEditorApplicationService.DomainModel.Misc.GetStaffEfforts);
            //_view.StaffSalaries = UpdateModelFromService<IEnumerable<StaffSalaryEntity>, IEnumerable<StaffSalaryModel>>(_baseGameEditorApplicationService.DomainModel.Misc.GetStaffSalaries);
            //_view.TestingMiles = UpdateModelFromService<IEnumerable<TestingMileEntity>, IEnumerable<TestingMileModel>>(_baseGameEditorApplicationService.DomainModel.Misc.GetTestingMiles);
            //_view.EngineeringCosts = UpdateModelFromService<IEnumerable<EngineeringCostEntity>, IEnumerable<EngineeringCostModel>>(_baseGameEditorApplicationService.DomainModel.Misc.GetEngineeringCosts);
            //_view.UnknownA = UpdateModelFromService<IEnumerable<UnknownAEntity>, IEnumerable<UnknownAModel>>(_baseGameEditorApplicationService.DomainModel.Misc.GetUnknownAs);
            //_view.UnknownB = UpdateModelFromService<IEnumerable<UnknownBEntity>, IEnumerable<UnknownBModel>>(_baseGameEditorApplicationService.DomainModel.Misc.GetUnknownBs);
        }

        private void UpdateServiceFromModels()
        {
            UpdateServiceFromModel<IEnumerable<TeamModel>, IEnumerable<TeamEntity>>(_baseGameEditorApplicationService.DomainModel.Teams.SetTeams, _view.Teams);
            UpdateServiceFromModel<IEnumerable<F1ChiefCommercialModel>, IEnumerable<F1ChiefCommercialEntity>>(_baseGameEditorApplicationService.DomainModel.Persons.SetF1ChiefCommercials, _view.F1ChiefCommercials);
            UpdateServiceFromModel<IEnumerable<F1ChiefDesignerModel>, IEnumerable<F1ChiefDesignerEntity>>(_baseGameEditorApplicationService.DomainModel.Persons.SetF1ChiefDesigners, _view.F1ChiefDesigners);
            UpdateServiceFromModel<IEnumerable<F1ChiefEngineerModel>, IEnumerable<F1ChiefEngineerEntity>>(_baseGameEditorApplicationService.DomainModel.Persons.SetF1ChiefEngineers, _view.F1ChiefEngineers);
            UpdateServiceFromModel<IEnumerable<F1ChiefMechanicModel>, IEnumerable<F1ChiefMechanicEntity>>(_baseGameEditorApplicationService.DomainModel.Persons.SetF1ChiefMechanics, _view.F1ChiefMechanics);
            UpdateServiceFromModel<IEnumerable<NonF1ChiefCommercialModel>, IEnumerable<NonF1ChiefCommercialEntity>>(_baseGameEditorApplicationService.DomainModel.Persons.SetNonF1ChiefCommercials, _view.NonF1ChiefCommercials);
            UpdateServiceFromModel<IEnumerable<NonF1ChiefDesignerModel>, IEnumerable<NonF1ChiefDesignerEntity>>(_baseGameEditorApplicationService.DomainModel.Persons.SetNonF1ChiefDesigners, _view.NonF1ChiefDesigners);
            UpdateServiceFromModel<IEnumerable<NonF1ChiefEngineerModel>, IEnumerable<NonF1ChiefEngineerEntity>>(_baseGameEditorApplicationService.DomainModel.Persons.SetNonF1ChiefEngineers, _view.NonF1ChiefEngineers);
            UpdateServiceFromModel<IEnumerable<NonF1ChiefMechanicModel>, IEnumerable<NonF1ChiefMechanicEntity>>(_baseGameEditorApplicationService.DomainModel.Persons.SetNonF1ChiefMechanics, _view.NonF1ChiefMechanics);
            UpdateServiceFromModel<IEnumerable<F1DriverModel>, IEnumerable<F1DriverEntity>>(_baseGameEditorApplicationService.DomainModel.Persons.SetF1Drivers, _view.F1Drivers);
            UpdateServiceFromModel<IEnumerable<NonF1DriverModel>, IEnumerable<NonF1DriverEntity>>(_baseGameEditorApplicationService.DomainModel.Persons.SetNonF1Drivers, _view.NonF1Drivers);
            UpdateServiceFromModel<IEnumerable<SponsorModel>, IEnumerable<SponsorEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorTeams, _view.SponsorTeams);
            UpdateServiceFromModel<IEnumerable<SponsorModel>, IEnumerable<SponsorEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorEngines, _view.SponsorEngines);
            UpdateServiceFromModel<IEnumerable<SponsorModel>, IEnumerable<SponsorEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorTyres, _view.SponsorTyres);
            UpdateServiceFromModel<IEnumerable<SponsorModel>, IEnumerable<SponsorEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorFuels, _view.SponsorFuels);
            UpdateServiceFromModel<IEnumerable<SponsorModel>, IEnumerable<SponsorEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorCashs, _view.SponsorCashs);
            UpdateServiceFromModel<IEnumerable<SponsorContractModel>, IEnumerable<SponsorContractEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorContractsTeam01, _view.SponsorContractsTeam01);
            UpdateServiceFromModel<IEnumerable<SponsorContractModel>, IEnumerable<SponsorContractEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorContractsTeam02, _view.SponsorContractsTeam02);
            UpdateServiceFromModel<IEnumerable<SponsorContractModel>, IEnumerable<SponsorContractEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorContractsTeam03, _view.SponsorContractsTeam03);
            UpdateServiceFromModel<IEnumerable<SponsorContractModel>, IEnumerable<SponsorContractEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorContractsTeam04, _view.SponsorContractsTeam04);
            UpdateServiceFromModel<IEnumerable<SponsorContractModel>, IEnumerable<SponsorContractEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorContractsTeam05, _view.SponsorContractsTeam05);
            UpdateServiceFromModel<IEnumerable<SponsorContractModel>, IEnumerable<SponsorContractEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorContractsTeam06, _view.SponsorContractsTeam06);
            UpdateServiceFromModel<IEnumerable<SponsorContractModel>, IEnumerable<SponsorContractEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorContractsTeam07, _view.SponsorContractsTeam07);
            UpdateServiceFromModel<IEnumerable<SponsorContractModel>, IEnumerable<SponsorContractEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorContractsTeam08, _view.SponsorContractsTeam08);
            UpdateServiceFromModel<IEnumerable<SponsorContractModel>, IEnumerable<SponsorContractEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorContractsTeam09, _view.SponsorContractsTeam09);
            UpdateServiceFromModel<IEnumerable<SponsorContractModel>, IEnumerable<SponsorContractEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorContractsTeam10, _view.SponsorContractsTeam10);
            UpdateServiceFromModel<IEnumerable<SponsorContractModel>, IEnumerable<SponsorContractEntity>>(_baseGameEditorApplicationService.DomainModel.Sponsors.SetSponsorContractsTeam11, _view.SponsorContractsTeam11);
            UpdateServiceFromModel<IEnumerable<TrackModel>, IEnumerable<TrackEntity>>(_baseGameEditorApplicationService.DomainModel.Tracks.SetTracks, _view.Tracks);

            // TODO:
            //UpdateServiceFromModel<IEnumerable<RunningCostModel>, IEnumerable<RunningCostEntity>>(_baseGameEditorApplicationService.DomainModel.Misc.GetRunningCosts, _view.RunningCosts);
            //UpdateServiceFromModel<IEnumerable<ExpansionCostModel>, IEnumerable<ExpansionCostEntity>>(_baseGameEditorApplicationService.DomainModel.Misc.GetExpansionCosts, _view.ExpansionCosts);
            //UpdateServiceFromModel<IEnumerable<StaffEffortModel>, IEnumerable<StaffEffortEntity>>(_baseGameEditorApplicationService.DomainModel.Misc.GetStaffEfforts, _view.StaffEfforts);
            //UpdateServiceFromModel<IEnumerable<StaffSalaryModel>, IEnumerable<StaffSalaryEntity>>(_baseGameEditorApplicationService.DomainModel.Misc.GetStaffSalaries, _view.StaffSalaries);
            //UpdateServiceFromModel<IEnumerable<TestingMileModel>, IEnumerable<TestingMileEntity>>(_baseGameEditorApplicationService.DomainModel.Misc.GetTestingMiles, _view.TestingMiles);
            //UpdateServiceFromModel<IEnumerable<EngineeringCostModel>, IEnumerable<EngineeringCostEntity>>(_baseGameEditorApplicationService.DomainModel.Misc.GetEngineeringCosts, _view.EngineeringCosts);
            //UpdateServiceFromModel<IEnumerable<UnknownAModel>, IEnumerable<UnknownAEntity>>(_baseGameEditorApplicationService.DomainModel.Misc.GetUnknownAs, _view.UnknownAs);
            //UpdateServiceFromModel<IEnumerable<UnknownBModel>, IEnumerable<UnknownBEntity>>(_baseGameEditorApplicationService.DomainModel.Misc.GetUnknownBs, _view.UnknownBs);
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

        private void UpdateValidationModels()
        {
            // TODO: Update validation view models with validation messages from domain entities
        }
    }
}