//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Reflection;
//using System.Windows.Forms;
//using Common.Extensions;
//using Data.Collections.Language;
//using Data.Databases;
//using Data.Entities.Executable.Race;
//using Data.Entities.Executable.Supplier;
//using Data.Entities.Executable.Team;
//using Data.Entities.Executable.Track;
//using Data.Entities.Language;
//using GpwEditor.Properties;
//using Cursor = System.Windows.Forms.Cursor;

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using App.WindowsForms.Controllers;
using App.WindowsForms.Models;
using App.WindowsForms.Models.Lookups;
using App.WindowsForms.Properties;

namespace App.WindowsForms.Views
{
    public partial class GameExecutableEditorForm : EditorForm
    {
        private ApplicationController _controller;

        #region ToolTip Declarations
        private const string TeamsIdToolTipText = "The id of the team record.";
        private const string TeamsTeamIdToolTipText = "The id of the team.";
        private const string TeamsNameToolTipText = "The name of the team.";
        private const string TeamsLastPositionToolTipText = "The finishing position of the team in last year's constructors' championship (e.g. 1997 when playing the 1998 season).";
        private const string TeamsLastPointsToolTipText = "The number of points scored by the team in last year's constructors' championship (e.g. 1997 when playing the 1998 season).";
        private const string TeamsDebutGrandPrixToolTipText = "The Grand Prix where the team made their debut.";
        private const string TeamsDebutYearToolTipText = "The year when the team made their Grand Prix debut.";
        private const string TeamsWinsToolTipText = "The number of wins scored by the team.";
        private const string TeamsYearlyBudgetToolTipText = "An estimation of the team's budget for this year's championship (e.g. 1998 when playing the 1998 season).";
        private const string TeamsLocationToolTipText = "The index of the country where the team's factory is located and represents the country map to display in the game.";
        private const string TeamsLocationXToolTipText = "The X co-ordinate of the pointer where the team's factory is located on the country map in the game.";
        private const string TeamsLocationYToolTipText = "The Y co-ordinate of the pointer where the team's factory is located on the country map in the game.";
        private const string TeamsTyreSupplierIdToolTipText = "The tyre manufacturer supplying the team for this year's championship (e.g. 1998 when playing the 1998 season). Unknown usage but suspect this may be used to determine the tyre sidewalls to display.";
        private const string TeamsChassisHandlingToolTipText = "The handling rating of the chassis at the start of the game.";
        private const string TeamsCarNumberDriver1ToolTipText = "The car number used by the team for driver 1.";
        private const string TeamsCarNumberDriver2ToolTipText = "The car number used by the team for driver 2.";

        private const string ChiefsIdToolTipText = "The id of the chief record.";
        private const string ChiefsTeamIdToolTipText = "The id of the team the chief is contracted to.";
        private const string ChiefsNameToolTipText = "The name of the chief.";
        private const string ChiefsAbilityToolTipText = "The ability rating of the chief.";
        private const string ChiefsAgeToolTipText = "The age of the chief at the start of the year.";
        private const string ChiefsSalaryToolTipText = "The salary paid to the chief.";
        private const string ChiefsRoyaltyToolTipText = "The royalty percentage paid to the chief.";
        private const string ChiefsRaceBonusToolTipText = "The race bonus awarded to the chief.";
        private const string ChiefsChampionshipBonusToolTipText = "The championship bonus awarded to the chief.";
        private const string ChiefsDriverLoyaltyToolTipText = "The driver the chief has loyalty towards.";
        private const string ChiefsMoraleToolTipText = "The morale level of the chief.";

        private const string DriversIdToolTipText = "The id of the driver record.";
        private const string DriversTeamIdToolTipText = "The id of the team the driver is contracted to.";
        private const string DriversNameToolTipText = "The name of the driver.";
        private const string DriversSalaryToolTipText = "The salary paid to the driver. Pay drivers will have a negative salary amount (e.g. -3500000).";
        private const string DriversRaceBonusToolTipText = "The race bonus awarded to the driver.";
        private const string DriversChampionshipBonusToolTipText = "The championship bonus awarded to the driver.";
        private const string DriversLastChampionshipPositionToolTipText = "The finishing position of the driver in last year's drivers' championship (e.g. 1997 when playing the 1998 season).";
        private const string DriversDriverRoleToolTipText = "The role of the driver in the team, as agreed in the driver's contract.";
        private const string DriversAgeToolTipText = "The age of the driver at the start of the year.";
        private const string DriversNationalityToolTipText = "The nationality of the driver.";
        private const string DriversUnknownAToolTipText = "An unknown value for the driver.";
        private const string DriversCareerChampionshipsToolTipText = "The number of championships the driver has won.";
        private const string DriversCareerRacesToolTipText = "The number of races the driver has entered/started.";
        private const string DriversCareerWinsToolTipText = "The number of wins scored by the driver.";
        private const string DriversCareerPointsToolTipText = "The number of points scored by the driver.";
        private const string DriversCareerFastestLapsToolTipText = "The number of fastest laps claimed by the driver.";
        private const string DriversCareerPointsFinishesToolTipText = "The number of points finishes scored by the driver.";
        private const string DriversCareerPolePositionsToolTipText = "The number of pole positions claimed by the driver.";
        private const string DriversSpeedToolTipText = "The speed rating of the driver.";
        private const string DriversSkillToolTipText = "The skill rating of the driver.";
        private const string DriversOvertakingToolTipText = "The overtaking rating of the driver.";
        private const string DriversWetWeatherToolTipText = "The wet weather rating of the driver.";
        private const string DriversConcentrationToolTipText = "The concentration rating of the driver.";
        private const string DriversExperienceToolTipText = "The experience rating of the driver.";
        private const string DriversStaminaToolTipText = "The stamina rating of the driver.";
        private const string DriversMoraleToolTipText = "The morale level of the driver.";

        // TODO: Populate
        private const string SuppliersEngineIdToolTipText = "";
        private const string SuppliersEngineNameToolTipText = "";
        private const string SuppliersEngineFuelToolTipText = "";
        private const string SuppliersEngineHeatToolTipText = "";
        private const string SuppliersEnginePowerToolTipText = "";
        private const string SuppliersEngineReliabilityToolTipText = "";
        private const string SuppliersEngineResponseToolTipText = "";
        private const string SuppliersEngineRigidityToolTipText = "";
        private const string SuppliersEngineWeightToolTipText = "";

        // TODO: Populate
        private const string SuppliersTyreIdToolTipText = "";
        private const string SuppliersTyreNameToolTipText = "";
        private const string SuppliersTyreDryHardGripToolTipText = "";
        private const string SuppliersTyreDryHardResilienceToolTipText = "";
        private const string SuppliersTyreDryHardStiffnessToolTipText = "";
        private const string SuppliersTyreDryHardTemperatureToolTipText = "";
        private const string SuppliersTyreDrySoftGripToolTipText = "";
        private const string SuppliersTyreDrySoftResilienceToolTipText = "";
        private const string SuppliersTyreDrySoftStiffnessToolTipText = "";
        private const string SuppliersTyreDrySoftTemperatureToolTipText = "";
        private const string SuppliersTyreIntermediateGripToolTipText = "";
        private const string SuppliersTyreIntermediateResilienceToolTipText = "";
        private const string SuppliersTyreIntermediateStiffnessToolTipText = "";
        private const string SuppliersTyreIntermediateTemperatureToolTipText = "";
        private const string SuppliersTyreWetWeatherGripToolTipText = "";
        private const string SuppliersTyreWetWeatherResilienceToolTipText = "";
        private const string SuppliersTyreWetWeatherStiffnessToolTipText = "";
        private const string SuppliersTyreWetWeatherTemperatureToolTipText = "";

        // TODO: Populate
        private const string SuppliersFuelIdToolTipText = "";
        private const string SuppliersFuelNameToolTipText = "";
        private const string SuppliersFuelPerformanceToolTipText = "";
        private const string SuppliersFuelToleranceToolTipText = "";

        // TODO: Populate
        private const string TracksIdToolTipText = "";
        private const string TracksNameToolTipText = "";
        private const string TracksLapsToolTipText = "";
        private const string TracksDesignToolTipText = "";
        private const string TracksLapRecordDriverToolTipText = "";
        private const string TracksLapRecordTeamToolTipText = "";
        private const string TracksLapRecordTimeToolTipText = "";
        private const string TracksLapRecordMphToolTipText = "";
        private const string TracksLapRecordYearToolTipText = "";
        private const string TracksLastRaceDriverToolTipText = "";
        private const string TracksLastRaceTeamToolTipText = "";
        private const string TracksLastRaceYearToolTipText = "";
        private const string TracksLastRaceTimeToolTipText = "";
        private const string TracksHospitalityToolTipText = "";
        private const string TracksSpeedToolTipText = "";
        private const string TracksGripToolTipText = "";
        private const string TracksSurfaceToolTipText = "";
        private const string TracksTarmacToolTipText = "";
        private const string TracksDustToolTipText = "";
        private const string TracksOvertakingToolTipText = "";
        private const string TracksBrakingToolTipText = "";
        private const string TracksRainToolTipText = "";
        private const string TracksHeatToolTipText = "";
        private const string TracksWindToolTipText = "";
        #endregion

        public string GameFolderPath { get; set; }             // TODO: Perhaps should get/set from ExampleTextBox
        public string GameExecutableFilePath { get => GameExecutablePathTextBox.Text; set => GameExecutablePathTextBox.Text = value; }
        public string EnglishLanguageFilePath { get => LanguageFilePathTextBox.Text; set => LanguageFilePathTextBox.Text = value; } // TODO: Use English TextBox once implmented
        public string FrenchLanguageFilePath { get; set; }     // TODO: Perhaps should get/set from ExampleTextBox
        public string GermanLanguageFilePath { get; set; }     // TODO: Perhaps should get/set from ExampleTextBox
        public string EnglishCommentaryFilePath { get; set; }  // TODO: Perhaps should get/set from ExampleTextBox
        public string FrenchCommentaryFilePath { get; set; }   // TODO: Perhaps should get/set from ExampleTextBox
        public string GermanCommentaryFilePath { get; set; }   // TODO: Perhaps should get/set from ExampleTextBox

        private bool _isFailedValidationForSwitchingContext;
        private bool _isImportOccurred;

        public GameExecutableEditorForm()
        {
            InitializeComponent();

            // TODO: Temporary measure to pre-populate fields before TextBox fields are introduced. These are just debug folder/file paths
            const string gameFolder = @"C:\gpw";
            GameFolderPath = $@"{gameFolder}";
            GameExecutableFilePath = $@"{gameFolder}\gpw.exe";
            EnglishLanguageFilePath = $@"{gameFolder}\english.txt";
            FrenchLanguageFilePath = $@"{gameFolder}\french.txt";
            GermanLanguageFilePath = $@"{gameFolder}\german.txt";
            EnglishCommentaryFilePath = $@"{gameFolder}\text\comme.txt";
            FrenchCommentaryFilePath = $@"{gameFolder}\textf\commf.txt";
            GermanCommentaryFilePath = $@"{gameFolder}\textg\commg.txt";
        }

        public IEnumerable<ChiefDriverLoyaltyLookupModel> ChiefDriverLoyaltyLookups { get; set; }
        public IEnumerable<DriverNationalityLookupModel> DriverNationalityLookups { get; set; }
        public IEnumerable<DriverRoleLookupModel> DriverRoleLookups { get; set; }
        public IEnumerable<TeamDebutGrandPrixLookupModel> TeamDebutGrandPrixLookups { get; set; }
        public IEnumerable<TrackDriverLookupModel> TrackDriverLookups { get; set; }
        public IEnumerable<TrackLayoutLookupModel> TrackLayoutLookups { get; set; }
        public IEnumerable<TrackTeamLookupModel> TrackTeamLookups { get; set; }
        public IEnumerable<TyreSupplierLookupModel> TyreSupplierLookups { get; set; }

        public IEnumerable<TeamModel> Teams
        {
            get => (IEnumerable<TeamModel>)TeamsDataGridView.DataSource;
            set => BuildTeamDataGridView(value);
        }

        public IEnumerable<F1ChiefCommercialModel> F1ChiefCommercials
        {
            get => (IEnumerable<F1ChiefCommercialModel>)ChiefsF1CommerceDataGridView.DataSource;
            set => BuildChiefsF1CommerceDataGridView(value);
        }

        public IEnumerable<F1ChiefDesignerModel> F1ChiefDesigners
        {
            get => (IEnumerable<F1ChiefDesignerModel>)ChiefsF1DesignerDataGridView.DataSource;
            set => BuildChiefsF1DesignerDataGridView(value);
        }

        public IEnumerable<F1ChiefEngineerModel> F1ChiefEngineers
        {
            get => (IEnumerable<F1ChiefEngineerModel>)ChiefsF1EngineerDataGridView.DataSource;
            set => BuildChiefsF1EngineerDataGridView(value);
        }

        public IEnumerable<F1ChiefMechanicModel> F1ChiefMechanics
        {
            get => (IEnumerable<F1ChiefMechanicModel>)ChiefsF1MechanicDataGridView.DataSource;
            set => BuildChiefsF1MechanicDataGridView(value);
        }

        public IEnumerable<NonF1ChiefCommercialModel> NonF1ChiefCommercials
        {
            get => (IEnumerable<NonF1ChiefCommercialModel>)ChiefsNonF1CommerceDataGridView.DataSource;
            set => BuildChiefsNonF1CommerceDataGridView(value);
        }

        public IEnumerable<NonF1ChiefDesignerModel> NonF1ChiefDesigners
        {
            get => (IEnumerable<NonF1ChiefDesignerModel>)ChiefsNonF1DesignerDataGridView.DataSource;
            set => BuildChiefsNonF1DesignerDataGridView(value);
        }

        public IEnumerable<NonF1ChiefEngineerModel> NonF1ChiefEngineers
        {
            get => (IEnumerable<NonF1ChiefEngineerModel>)ChiefsNonF1EngineerDataGridView.DataSource;
            set => BuildChiefsNonF1EngineerDataGridView(value);
        }

        public IEnumerable<NonF1ChiefMechanicModel> NonF1ChiefMechanics
        {
            get => (IEnumerable<NonF1ChiefMechanicModel>)ChiefsNonF1MechanicDataGridView.DataSource;
            set => BuildChiefsNonF1MechanicDataGridView(value);
        }

        public IEnumerable<F1DriverModel> F1Drivers
        {
            get => (IEnumerable<F1DriverModel>)DriversF1DataGridView.DataSource;
            set => BuildDriversF1DataGridView(value);
        }

        public IEnumerable<NonF1DriverModel> NonF1Drivers
        {
            get => (IEnumerable<NonF1DriverModel>)DriversNonF1DataGridView.DataSource;
            set => BuildDriversNonF1DataGridView(value);
        }

        public IEnumerable<EngineModel> Engines
        {
            get => (IEnumerable<EngineModel>)SuppliersEngineDataGridView.DataSource;
            set => BuildSuppliersEngineDataGridView(value);
        }

        public IEnumerable<TyreModel> Tyres
        {
            get => (IEnumerable<TyreModel>)SuppliersTyreDataGridView.DataSource;
            set => BuildSuppliersTyreDataGridView(value);
        }

        public IEnumerable<FuelModel> Fuels
        {
            get => (IEnumerable<FuelModel>)SuppliersFuelDataGridView.DataSource;
            set => BuildSuppliersFuelDataGridView(value);
        }

        public IEnumerable<TrackModel> Tracks
        {
            get => (IEnumerable<TrackModel>)TracksDataGridView.DataSource;
            set => BuildTracksDataGridView(value);
        }

        // TODO: Decide how this will work
        //public IEnumerable<PerformanceCurveModel> PerformanceCurveValues
        //{
        //    get;
        //    set => BuildPerformanceCurveGraph(value);
        //}

        public void SetController(ApplicationController controller)
        {
            _controller = controller;
        }

        private void BuildTeamDataGridView(IEnumerable<TeamModel> dataSource)
        {
            ClearDataGridView(TeamsDataGridView);

            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", TeamsIdToolTipText, false));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("TeamId", "TeamId", TeamsTeamIdToolTipText, false));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", TeamsNameToolTipText, true, true));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("LastPosition", "Last Year's Championship Position", TeamsLastPositionToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("LastPoints", "Last Year's Championship Points", TeamsLastPointsToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewComboBoxColumn("FirstGpTrack", "Debut Grand Prix", TeamsDebutGrandPrixToolTipText));            // TODO: Rename property to DebutGrandPrix
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("FirstGpYear", "Debut Year", TeamsDebutYearToolTipText));                         // TODO: Rename property to DebutYear
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("Wins", "Wins", TeamsWinsToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("YearlyBudget", "This Year's Budget", TeamsYearlyBudgetToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("CountryMapId", "Location", TeamsLocationToolTipText));                           // TODO: Rename property to Location
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("LocationPointerX", "Location X", TeamsLocationXToolTipText));                    // TODO: Rename property to LocationX
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("LocationPointerY", "Location Y", TeamsLocationYToolTipText));                    // TODO: Rename property to LocationY
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewComboBoxColumn("TyreSupplierId", "This Year's Tyre Supplier", TeamsTyreSupplierIdToolTipText)); // TODO: Rename property to TyreSupplier
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("ChassisHandling", "Chassis Handling Rating", TeamsChassisHandlingToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("CarNumberDriver1", "Car Number Driver 1", TeamsCarNumberDriver1ToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("CarNumberDriver2", "Car Number Driver 2", TeamsCarNumberDriver2ToolTipText));

            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TeamsDataGridView.Columns["FirstGpTrack"], TeamDebutGrandPrixLookups);                // TODO: Rename property to DebutGrandPrix
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TeamsDataGridView.Columns["TyreSupplierId"], TyreSupplierLookups);                    // TODO: Rename property to TyreSupplier
            BindDataGridViewToDataSource(TeamsDataGridView, dataSource);
        }

        private void BuildChiefsF1CommerceDataGridView(IEnumerable<F1ChiefCommercialModel> dataSource)
        {
            ClearDataGridView(ChiefsF1CommerceDataGridView);

            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", ChiefsIdToolTipText, false));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("TeamId", "TeamId", ChiefsTeamIdToolTipText, false));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", ChiefsNameToolTipText, true, true));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Ability", "Ability", ChiefsAbilityToolTipText));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", ChiefsAgeToolTipText));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", ChiefsSalaryToolTipText));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Royalty", "Royalty", ChiefsRoyaltyToolTipText));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Morale", "Morale", ChiefsMoraleToolTipText));

            BindDataGridViewToDataSource(ChiefsF1CommerceDataGridView, dataSource);
        }

        private void BuildChiefsF1DesignerDataGridView(IEnumerable<F1ChiefDesignerModel> dataSource)
        {
            ClearDataGridView(ChiefsF1DesignerDataGridView);

            AddColumnToDataGridView(ChiefsF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", ChiefsIdToolTipText, false));
            AddColumnToDataGridView(ChiefsF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("TeamId", "TeamId", ChiefsTeamIdToolTipText, false));
            AddColumnToDataGridView(ChiefsF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", ChiefsNameToolTipText, true, true));
            AddColumnToDataGridView(ChiefsF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Ability", "Ability", ChiefsAbilityToolTipText));
            AddColumnToDataGridView(ChiefsF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", ChiefsAgeToolTipText));
            AddColumnToDataGridView(ChiefsF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", ChiefsSalaryToolTipText));
            AddColumnToDataGridView(ChiefsF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("RaceBonus", "Race Bonus", ChiefsRaceBonusToolTipText));
            AddColumnToDataGridView(ChiefsF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("ChampionshipBonus", "Championship Bonus", ChiefsChampionshipBonusToolTipText));
            AddColumnToDataGridView(ChiefsF1DesignerDataGridView, CreateDataGridViewComboBoxColumn("DriverLoyalty", "Driver Loyalty", ChiefsDriverLoyaltyToolTipText));
            AddColumnToDataGridView(ChiefsF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Morale", "Morale", ChiefsMoraleToolTipText));

            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)ChiefsF1DesignerDataGridView.Columns["DriverLoyalty"], ChiefDriverLoyaltyLookups);
            BindDataGridViewToDataSource(ChiefsF1DesignerDataGridView, dataSource);
        }

        private void BuildChiefsF1EngineerDataGridView(IEnumerable<F1ChiefEngineerModel> dataSource)
        {
            ClearDataGridView(ChiefsF1EngineerDataGridView);

            AddColumnToDataGridView(ChiefsF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", ChiefsIdToolTipText, false));
            AddColumnToDataGridView(ChiefsF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("TeamId", "TeamId", ChiefsTeamIdToolTipText, false));
            AddColumnToDataGridView(ChiefsF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", ChiefsNameToolTipText, true, true));
            AddColumnToDataGridView(ChiefsF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Ability", "Ability", ChiefsAbilityToolTipText));
            AddColumnToDataGridView(ChiefsF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", ChiefsAgeToolTipText));
            AddColumnToDataGridView(ChiefsF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", ChiefsSalaryToolTipText));
            AddColumnToDataGridView(ChiefsF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("RaceBonus", "Race Bonus", ChiefsRaceBonusToolTipText));
            AddColumnToDataGridView(ChiefsF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("ChampionshipBonus", "Championship Bonus", ChiefsChampionshipBonusToolTipText));
            AddColumnToDataGridView(ChiefsF1EngineerDataGridView, CreateDataGridViewComboBoxColumn("DriverLoyalty", "Driver Loyalty", ChiefsDriverLoyaltyToolTipText));
            AddColumnToDataGridView(ChiefsF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Morale", "Morale", ChiefsMoraleToolTipText));

            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)ChiefsF1EngineerDataGridView.Columns["DriverLoyalty"], ChiefDriverLoyaltyLookups);
            BindDataGridViewToDataSource(ChiefsF1EngineerDataGridView, dataSource);
        }

        private void BuildChiefsF1MechanicDataGridView(IEnumerable<F1ChiefMechanicModel> dataSource)
        {
            ClearDataGridView(ChiefsF1MechanicDataGridView);

            AddColumnToDataGridView(ChiefsF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", ChiefsIdToolTipText, false));
            AddColumnToDataGridView(ChiefsF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("TeamId", "TeamId", ChiefsTeamIdToolTipText, false));
            AddColumnToDataGridView(ChiefsF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", ChiefsNameToolTipText, true, true));
            AddColumnToDataGridView(ChiefsF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Ability", "Ability", ChiefsAbilityToolTipText));
            AddColumnToDataGridView(ChiefsF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", ChiefsAgeToolTipText));
            AddColumnToDataGridView(ChiefsF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", ChiefsSalaryToolTipText));
            AddColumnToDataGridView(ChiefsF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("RaceBonus", "Race Bonus", ChiefsRaceBonusToolTipText));
            AddColumnToDataGridView(ChiefsF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("ChampionshipBonus", "Championship Bonus", ChiefsChampionshipBonusToolTipText));
            AddColumnToDataGridView(ChiefsF1MechanicDataGridView, CreateDataGridViewComboBoxColumn("DriverLoyalty", "Driver Loyalty", ChiefsDriverLoyaltyToolTipText));
            AddColumnToDataGridView(ChiefsF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Morale", "Morale", ChiefsMoraleToolTipText));

            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)ChiefsF1MechanicDataGridView.Columns["DriverLoyalty"], ChiefDriverLoyaltyLookups);
            BindDataGridViewToDataSource(ChiefsF1MechanicDataGridView, dataSource);
        }

        private void BuildChiefsNonF1CommerceDataGridView(IEnumerable<NonF1ChiefCommercialModel> dataSource)
        {
            ClearDataGridView(ChiefsNonF1CommerceDataGridView);

            AddColumnToDataGridView(ChiefsNonF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", ChiefsIdToolTipText, false));
            AddColumnToDataGridView(ChiefsNonF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", ChiefsNameToolTipText, true, true));
            AddColumnToDataGridView(ChiefsNonF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Ability", "Ability", ChiefsAbilityToolTipText));
            AddColumnToDataGridView(ChiefsNonF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", ChiefsAgeToolTipText));
            AddColumnToDataGridView(ChiefsNonF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", ChiefsSalaryToolTipText));
            AddColumnToDataGridView(ChiefsNonF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Royalty", "Royalty", ChiefsRoyaltyToolTipText));

            BindDataGridViewToDataSource(ChiefsNonF1CommerceDataGridView, dataSource);
        }

        private void BuildChiefsNonF1DesignerDataGridView(IEnumerable<NonF1ChiefDesignerModel> dataSource)
        {
            ClearDataGridView(ChiefsNonF1DesignerDataGridView);

            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", ChiefsIdToolTipText, false));
            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", ChiefsNameToolTipText, true, true));
            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Ability", "Ability", ChiefsAbilityToolTipText));
            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", ChiefsAgeToolTipText));
            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", ChiefsSalaryToolTipText));
            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("RaceBonus", "Race Bonus", ChiefsRaceBonusToolTipText));
            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("ChampionshipBonus", "Championship Bonus", ChiefsChampionshipBonusToolTipText));

            BindDataGridViewToDataSource(ChiefsNonF1DesignerDataGridView, dataSource);
        }

        private void BuildChiefsNonF1EngineerDataGridView(IEnumerable<NonF1ChiefEngineerModel> dataSource)
        {
            ClearDataGridView(ChiefsNonF1EngineerDataGridView);

            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", ChiefsIdToolTipText, false));
            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", ChiefsNameToolTipText, true, true));
            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Ability", "Ability", ChiefsAbilityToolTipText));
            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", ChiefsAgeToolTipText));
            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", ChiefsSalaryToolTipText));
            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("RaceBonus", "Race Bonus", ChiefsRaceBonusToolTipText));
            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("ChampionshipBonus", "Championship Bonus", ChiefsChampionshipBonusToolTipText));

            BindDataGridViewToDataSource(ChiefsNonF1EngineerDataGridView, dataSource);
        }

        private void BuildChiefsNonF1MechanicDataGridView(IEnumerable<NonF1ChiefMechanicModel> dataSource)
        {
            ClearDataGridView(ChiefsNonF1MechanicDataGridView);

            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", ChiefsIdToolTipText, false));
            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", ChiefsNameToolTipText, true, true));
            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Ability", "Ability", ChiefsAbilityToolTipText));
            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", ChiefsAgeToolTipText));
            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", ChiefsSalaryToolTipText));
            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("RaceBonus", "Race Bonus", ChiefsRaceBonusToolTipText));
            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("ChampionshipBonus", "Championship Bonus", ChiefsChampionshipBonusToolTipText));

            BindDataGridViewToDataSource(ChiefsNonF1MechanicDataGridView, dataSource);
        }

        private void BuildDriversF1DataGridView(IEnumerable<F1DriverModel> dataSource)
        {
            ClearDataGridView(DriversF1DataGridView);

            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", DriversIdToolTipText, false));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("TeamId", "TeamId", DriversTeamIdToolTipText, false));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", DriversNameToolTipText, true, true));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", DriversSalaryToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("RaceBonus", "Race Bonus", DriversRaceBonusToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("ChampionshipBonus", "Championship Bonus", DriversChampionshipBonusToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("LastChampionshipPosition", "Last Year's Championship Position", DriversLastChampionshipPositionToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewComboBoxColumn("DriverRole", "Driver Role", DriversDriverRoleToolTipText)); // TODO: Rename property to Role
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", DriversAgeToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewComboBoxColumn("Nationality", "Nationality", DriversNationalityToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("CareerChampionships", "Championships", DriversCareerChampionshipsToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("CareerRaces", "Races", DriversCareerRacesToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("CareerWins", "Wins", DriversCareerWinsToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("CareerPoints", "Points", DriversCareerPointsToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("CareerFastestLaps", "Fastest Laps", DriversCareerFastestLapsToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("CareerPointsFinishes", "Points Finishes", DriversCareerPointsFinishesToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("CareerPolePositions", "Pole Positions", DriversCareerPolePositionsToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Speed", "Speed", DriversSpeedToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Skill", "Skill", DriversSkillToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Overtaking", "Overtaking", DriversOvertakingToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("WetWeather", "Wet Weather", DriversWetWeatherToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Concentration", "Concentration", DriversConcentrationToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Experience", "Experience", DriversExperienceToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Stamina", "Stamina", DriversStaminaToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Morale", "Morale", DriversMoraleToolTipText));

            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)DriversF1DataGridView.Columns["DriverRole"], DriverRoleLookups); // TODO: Rename property to Role
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)DriversF1DataGridView.Columns["Nationality"], DriverNationalityLookups);
            BindDataGridViewToDataSource(DriversF1DataGridView, dataSource);
        }

        private void BuildDriversNonF1DataGridView(IEnumerable<NonF1DriverModel> dataSource)
        {
            ClearDataGridView(DriversNonF1DataGridView);

            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", DriversIdToolTipText, false));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("TeamId", "TeamId", DriversTeamIdToolTipText, false));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", DriversNameToolTipText, true, true));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", DriversSalaryToolTipText));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("RaceBonus", "Race Bonus", DriversRaceBonusToolTipText));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("ChampionshipBonus", "Championship Bonus", DriversChampionshipBonusToolTipText));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", DriversAgeToolTipText));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewComboBoxColumn("Nationality", "Nationality", DriversNationalityToolTipText));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("UnknownA", "UnknownA", DriversUnknownAToolTipText, false));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("Speed", "Speed", DriversSpeedToolTipText));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("Skill", "Skill", DriversSkillToolTipText));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("Overtaking", "Overtaking", DriversOvertakingToolTipText));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("WetWeather", "Wet Weather", DriversWetWeatherToolTipText));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("Concentration", "Concentration", DriversConcentrationToolTipText));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("Experience", "Experience", DriversExperienceToolTipText));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("Stamina", "Stamina", DriversStaminaToolTipText));
            AddColumnToDataGridView(DriversNonF1DataGridView, CreateDataGridViewTextBoxColumn("Morale", "Morale", DriversMoraleToolTipText));

            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)DriversNonF1DataGridView.Columns["Nationality"], DriverNationalityLookups);
            BindDataGridViewToDataSource(DriversNonF1DataGridView, dataSource);
        }

        private void BuildSuppliersEngineDataGridView(IEnumerable<EngineModel> dataSource)
        {
            ClearDataGridView(SuppliersEngineDataGridView);

            AddColumnToDataGridView(SuppliersEngineDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SuppliersEngineIdToolTipText, false));
            AddColumnToDataGridView(SuppliersEngineDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SuppliersEngineNameToolTipText, true, true));
            AddColumnToDataGridView(SuppliersEngineDataGridView, CreateDataGridViewTextBoxColumn("Fuel", "Fuel", SuppliersEngineFuelToolTipText));
            AddColumnToDataGridView(SuppliersEngineDataGridView, CreateDataGridViewTextBoxColumn("Heat", "Heat", SuppliersEngineHeatToolTipText));
            AddColumnToDataGridView(SuppliersEngineDataGridView, CreateDataGridViewTextBoxColumn("Power", "Power", SuppliersEnginePowerToolTipText));
            AddColumnToDataGridView(SuppliersEngineDataGridView, CreateDataGridViewTextBoxColumn("Reliability", "Reliability", SuppliersEngineReliabilityToolTipText));
            AddColumnToDataGridView(SuppliersEngineDataGridView, CreateDataGridViewTextBoxColumn("Response", "Response", SuppliersEngineResponseToolTipText));
            AddColumnToDataGridView(SuppliersEngineDataGridView, CreateDataGridViewTextBoxColumn("Rigidity", "Rigidity", SuppliersEngineRigidityToolTipText));
            AddColumnToDataGridView(SuppliersEngineDataGridView, CreateDataGridViewTextBoxColumn("Weight", "Weight", SuppliersEngineWeightToolTipText));

            BindDataGridViewToDataSource(SuppliersEngineDataGridView, dataSource);
        }

        private void BuildSuppliersTyreDataGridView(IEnumerable<TyreModel> dataSource)
        {
            ClearDataGridView(SuppliersTyreDataGridView);

            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SuppliersTyreIdToolTipText, false));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SuppliersTyreNameToolTipText, true, true));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("DryHardGrip", "Dry Hard Grip", SuppliersTyreDryHardGripToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("DryHardResilience", "Dry Hard Resilience", SuppliersTyreDryHardResilienceToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("DryHardStiffness", "Dry Hard Stiffness", SuppliersTyreDryHardStiffnessToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("DryHardTemperature", "Dry Hard Temperature", SuppliersTyreDryHardTemperatureToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("DrySoftGrip", "Dry Soft Grip", SuppliersTyreDrySoftGripToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("DrySoftResilience", "Dry Soft Resilience", SuppliersTyreDrySoftResilienceToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("DrySoftStiffness", "Dry Soft Stiffness", SuppliersTyreDrySoftStiffnessToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("DrySoftTemperature", "Dry Soft Temperature", SuppliersTyreDrySoftTemperatureToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("IntermediateGrip", "Intermediate Grip", SuppliersTyreIntermediateGripToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("IntermediateResilience", "Intermediate Resilience", SuppliersTyreIntermediateResilienceToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("IntermediateStiffness", "Intermediate Stiffness", SuppliersTyreIntermediateStiffnessToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("IntermediateTemperature", "Intermediate Temperature", SuppliersTyreIntermediateTemperatureToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("WetWeatherGrip", "Wet Weather Grip", SuppliersTyreWetWeatherGripToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("WetWeatherResilience", "Wet Weather Resilience", SuppliersTyreWetWeatherResilienceToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("WetWeatherStiffness", "Wet Weather Stiffness", SuppliersTyreWetWeatherStiffnessToolTipText));
            AddColumnToDataGridView(SuppliersTyreDataGridView, CreateDataGridViewTextBoxColumn("WetWeatherTemperature", "Wet Weather Temperature", SuppliersTyreWetWeatherTemperatureToolTipText));

            BindDataGridViewToDataSource(SuppliersTyreDataGridView, dataSource);
        }

        private void BuildSuppliersFuelDataGridView(IEnumerable<FuelModel> dataSource)
        {
            ClearDataGridView(SuppliersFuelDataGridView);

            AddColumnToDataGridView(SuppliersFuelDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SuppliersFuelIdToolTipText, false));
            AddColumnToDataGridView(SuppliersFuelDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SuppliersFuelNameToolTipText, true, true));
            AddColumnToDataGridView(SuppliersFuelDataGridView, CreateDataGridViewTextBoxColumn("Performance", "Performance", SuppliersFuelPerformanceToolTipText));
            AddColumnToDataGridView(SuppliersFuelDataGridView, CreateDataGridViewTextBoxColumn("Tolerance", "Tolerance", SuppliersFuelToleranceToolTipText));

            BindDataGridViewToDataSource(SuppliersFuelDataGridView, dataSource);
        }

        private void BuildTracksDataGridView(IEnumerable<TrackModel> dataSource)
        {
            ClearDataGridView(TracksDataGridView);

            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", TracksIdToolTipText, false));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", TracksNameToolTipText, true, true));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Laps", "Laps", TracksLapsToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewComboBoxColumn("Design", "Design", TracksDesignToolTipText)); // TODO: Rename property to Layout
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewComboBoxColumn("LapRecordDriver", "Lap Record Driver", TracksLapRecordDriverToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewComboBoxColumn("LapRecordTeam", "Lap Record Team", TracksLapRecordTeamToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("LapRecordTime", "Lap Record Time", TracksLapRecordTimeToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("LapRecordMph", "Lap Record MPH", TracksLapRecordMphToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("LapRecordYear", "Lap Record Year", TracksLapRecordYearToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewComboBoxColumn("LastRaceDriver", "Last Race Driver", TracksLastRaceDriverToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewComboBoxColumn("LastRaceTeam", "Last Race Team", TracksLastRaceTeamToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("LastRaceYear", "Last Race Year", TracksLastRaceYearToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("LastRaceTime", "Last Race Time", TracksLastRaceTimeToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Hospitality", "Hospitality", TracksHospitalityToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Speed", "Speed", TracksSpeedToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Grip", "Grip", TracksGripToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Surface", "Surface", TracksSurfaceToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Tarmac", "Tarmac", TracksTarmacToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Dust", "Dust", TracksDustToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Overtaking", "Overtaking", TracksOvertakingToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Braking", "Braking", TracksBrakingToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Rain", "Rain", TracksRainToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Heat", "Heat", TracksHeatToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Wind", "Wind", TracksWindToolTipText));

            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TracksDataGridView.Columns["Design"], TrackLayoutLookups); // TODO: Rename property to Layout
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TracksDataGridView.Columns["LapRecordDriver"], TrackDriverLookups);
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TracksDataGridView.Columns["LapRecordTeam"], TrackTeamLookups);
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TracksDataGridView.Columns["LastRaceDriver"], TrackDriverLookups);
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TracksDataGridView.Columns["LastRaceTeam"], TrackTeamLookups);
            BindDataGridViewToDataSource(TracksDataGridView, dataSource);
        }

        private void GameExecutableEditorForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.icon1;
            Text = $"{Settings.Default.ApplicationName} - Game Executable Editor";
            ConvertLinesToRtf(OverviewRichTextBox);

            // TODO:
            // Populate with most recently used (MRU) or default
            // GameExecutablePathTextBox.Text = GetGameExecutableMruOrDefault(); // TODO: Add the rest once implemented
            // LanguageFilePathTextBox.Text = GetLanguageFileMruOrDefault();     // TODO: Add the rest once implemented

            // ConfigureControls(); // TODO: Suspect no longer needed
            SubscribeDataGridViewControlsToGenericEvents();
        }

        private void GameExecutableEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isFailedValidationForSwitchingContext)
            {
                e.Cancel = true; // Abort event
                _isFailedValidationForSwitchingContext = false; // Reset
                return;
            }

            if (CloseFormConfirmation(true, $"Are you sure you wish to close the game executable editor?{Environment.NewLine}{Environment.NewLine}Any changes not exported will be lost.")
            )
            {
                return;
            }

            e.Cancel = true; // Abort event
        }

        private void MainTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_isImportOccurred)
            {
                e.Cancel = true; // Abort event
                ShowMessageBox("Unable to switch tabs until a successful import has occurred.", MessageBoxIcon.Error);
            }

            if (_isFailedValidationForSwitchingContext)
            {
                e.Cancel = true; // Abort event
                _isFailedValidationForSwitchingContext = false; // Reset
            }
        }

        private void BrowseGameExecutableButton_Click(object sender, EventArgs e)
        {
            // TODO: Activate
            //var result = GetGameExecutablePathFromOpenFileDialog();
            //GameExecutablePathTextBox.Text = string.IsNullOrEmpty(result) ? GameExecutablePathTextBox.Text : result;
        }

        private void BrowseLanguageFileButton_Click(object sender, EventArgs e)
        {
            // TODO: Activate
            //var result = GetLanguageFilePathFromOpenFileDialog();
            //LanguageFilePathTextBox.Text = string.IsNullOrEmpty(result) ? LanguageFilePathTextBox.Text : result;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            //if (!_isImportOccurred)
            //{
            //    ShowMessageBox("Unable to export until a successful import has occurred.", MessageBoxIcon.Error);
            //    return;
            //}

            //Export(GameExecutablePathTextBox.Text, LanguageFilePathTextBox.Text);
        }

        private static void GenericDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;

            // If column header
            if (e.RowIndex < 0)
            {
                return;
            }

            // If combobox column
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                // Drop down the drop down
                dataGridView.BeginEdit(true);
                ((ComboBox)dataGridView.EditingControl).DroppedDown = true;
            }
        }

        private static void GenericDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void GenericDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //_isFailedValidationForSwitchingContext = false; // Reset

            //// Get the type used in the collection that is assigned to the datasource of the datagridview
            //// And invoke the named generic method, passing the required parameters to the generic method
            //// http://stackoverflow.com/a/325161
            //var dataGridView = (DataGridView)sender;
            //var listItemType = ListBindingHelper.GetListItemType(dataGridView.DataSource);
            //var methodInfo = typeof(GameExecutableEditorForm).GetMethod("ValidateDataGridViewCell", BindingFlags.NonPublic | BindingFlags.Instance);
            //var genericMethod = methodInfo.MakeGenericMethod(listItemType);
            //genericMethod.Invoke(this, new[] { sender, e });
        }

        private static void GenericDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //// Handle error that occurs after viewing the datagridview with imported data, having previously viewed the datagridview with no data
            //// https://refactoringself.com/2012/09/26/datagridview-formattingexception-dataerror-and-preferredsize-auto-sizing-issue/

            //if (e.Context == (DataGridViewDataErrorContexts.Formatting | DataGridViewDataErrorContexts.PreferredSize))
            //{
            //    e.Cancel = true;
            //}
        }

        private static void BindDataGridViewComboBoxColumn(DataGridView dataGridView, string dataGridViewComboBoxColumnName, object dataSource)
        {
            //var dataGridViewComboBoxColumn = (DataGridViewComboBoxColumn)dataGridView.Columns[dataGridViewComboBoxColumnName];
            //dataGridViewComboBoxColumn.DataSource = dataSource;
            //dataGridViewComboBoxColumn.DisplayMember = "ResourceText";
            //dataGridViewComboBoxColumn.ValueMember = "LocalResourceId";
            //dataGridViewComboBoxColumn.ValueType = typeof(int);
        }

        //private void ConfigureControls()
        //{
        //    // Configure data grid view controls
        //    ConfigureDataGridViewControl<Team>(TeamsDataGridView, 1);
        //    ConfigureDataGridViewControl<F1ChiefCommercial>(ChiefsF1CommerceDataGridView, 2);
        //    ConfigureDataGridViewControl<F1ChiefDesigner>(ChiefsF1DesignerDataGridView, 3);
        //    ConfigureDataGridViewControl<F1ChiefEngineer>(ChiefsF1EngineerDataGridView, 4);
        //    ConfigureDataGridViewControl<F1ChiefMechanic>(ChiefsF1MechanicDataGridView, 5);
        //    ConfigureDataGridViewControl<NonF1ChiefCommercial>(ChiefsNonF1CommerceDataGridView, 6);
        //    ConfigureDataGridViewControl<NonF1ChiefDesigner>(ChiefsNonF1DesignerDataGridView, 7);
        //    ConfigureDataGridViewControl<NonF1ChiefEngineer>(ChiefsNonF1EngineerDataGridView, 8);
        //    ConfigureDataGridViewControl<NonF1ChiefMechanic>(ChiefsNonF1MechanicDataGridView, 9);
        //    ConfigureDataGridViewControl<F1Driver>(DriversF1DataGridView, 10);
        //    DriversF1DataGridView.Columns[7].Visible = false; // Hide pay driver columns
        //    DriversF1DataGridView.Columns[8].Visible = false; // Hide pay driver columns
        //    ConfigureDataGridViewControl<NonF1Driver>(DriversNonF1DataGridView, 11);
        //    ConfigureDataGridViewControl<Engine>(SuppliersEnginesDataGridView, 12);
        //    ConfigureDataGridViewControl<Tyre>(SuppliersTyresDataGridView, 13);
        //    ConfigureDataGridViewControl<Fuel>(SuppliersFuelsDataGridView, 14);
        //    ConfigureDataGridViewControl<Track>(TracksDataGridView, 15);
        //    ConfigureDataGridViewControl<ChassisHandling>(ChassisHandlingDataGridView, 16);
        //    //TODO ConfigureDataGridViewControl<FiveValueBase>(FactoryRunningCostsDataGridView, 0, "Running Costs", true);
        //    //TODO ConfigureDataGridViewControl<FiveRatingBase>(FactoryExpansionCostsDataGridView, 0, "Expansion Costs", true);
        //    //TODO ConfigureDataGridViewControl<FiveRatingBase>(StaffEffortsDataGridView, 0, "Staff Efforts", true);
        //    //TODO ConfigureDataGridViewControl<FiveRatingBase>(StaffSalariesDataGridView, 0, "Staff Salaries", true);
        //    //TODO ConfigureDataGridViewControl<TenValueBase>(TestingMilesDataGridView, 0, "Testing Miles", true);
        //    //TODO ConfigureDataGridViewControl<TenValueBase>(EngineeringCostsDataGridView, 0, "Engineering Costs", true);
        //    //TODO ConfigureDataGridViewControl<SingleValueBase>(UnknownADataGridView, 0, "UnknownA", true);
        //    //TODO ConfigureDataGridViewControl<SingleValueBase>(UnknownBDataGridView, 0, "UnknownB", true);
        //}

        private void Export()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                /* TODO: This block is all old code that can likely be removed
                    // TODO: FolderExists(gameFolderPath);
                    FileExists(gameExecutablePath);
                    FileExists(languageFilePath);

                    // Fill database with data from controls and export to file
                    var database = new ExecutableDatabase();
                    PopulateRecords(database);
                    database.ExportDataToFile(gameExecutablePath, languageFilePath);
                */

                _controller.Export();
            }
            catch (Exception ex)
            {
                ShowMessageBox(
                    $"An error has occured. Process aborted.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
                    MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            MessageBox.Show("Export complete!", Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Import()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                /* TODO: This block is all old code that can likely be removed
                    // TODO: FolderExists(gameFolderPath);
                    FileExists(gameExecutablePath);
                    FileExists(languageFilePath);

                    // Import from file to database and fill controls with data
                    var database = new ExecutableDatabase();
                    database.ImportDataFromFile(gameExecutablePath, languageFilePath);
                    PopulateControls(database);
                */

                _controller.Import();
                _isImportOccurred = true;
            }
            catch (Exception ex)
            {
                ShowMessageBox(
                    $"An error has occured. Process aborted.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
                    MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            ShowMessageBox("Import complete!");
        }

        /* TODO: A dead method now as datasources are assigned by controller instead, could use code as reference
            //private void PopulateControls(ExecutableDatabase database)
            //{
            //    // Move data from database into controls
            //    LanguageDataGridView.DataSource = database.LanguageResources;
            //    TeamsDataGridView.DataSource = database.Teams;
            //    ChiefsF1CommerceDataGridView.DataSource = database.F1ChiefCommercials;
            //    ChiefsF1DesignerDataGridView.DataSource = database.F1ChiefDesigners;
            //    ChiefsF1EngineerDataGridView.DataSource = database.F1ChiefEngineers;
            //    ChiefsF1MechanicDataGridView.DataSource = database.F1ChiefMechanics;
            //    ChiefsNonF1CommerceDataGridView.DataSource = database.NonF1ChiefCommercials;
            //    ChiefsNonF1DesignerDataGridView.DataSource = database.NonF1ChiefDesigners;
            //    ChiefsNonF1EngineerDataGridView.DataSource = database.NonF1ChiefEngineers;
            //    ChiefsNonF1MechanicDataGridView.DataSource = database.NonF1ChiefMechanics;
            //    DriversF1DataGridView.DataSource = database.F1Drivers;
            //    DriversNonF1DataGridView.DataSource = database.NonF1Drivers;
            //    SuppliersEnginesDataGridView.DataSource = database.Engines;
            //    SuppliersTyresDataGridView.DataSource = database.Tyres;
            //    SuppliersFuelsDataGridView.DataSource = database.Fuels;
            //    TracksDataGridView.DataSource = database.Tracks;
            //    ChassisHandlingDataGridView.DataSource = database.ChassisHandlings;
            //    //TODO FactoryRunningCostsDataGridView.DataSource = database.FactoryRunningCosts;
            //    //TODO FactoryExpansionCostsDataGridView.DataSource = database.FactoryExpansionCosts;
            //    //TODO StaffSalariesDataGridView.DataSource = database.StaffSalaries;
            //    //TODO StaffEffortsDataGridView.DataSource = database.StaffEfforts;
            //    //TODO TestingMilesDataGridView.DataSource = database.TestingMiles;
            //    //TODO EngineeringCostsDataGridView.DataSource = database.EngineeringCosts;
            //    //TODO UnknownADataGridView.DataSource = database.UnknownAEfforts;
            //    //TODO UnknownBDataGridView.DataSource = database.UnknownBEfforts;

            //    // Bind comboboxes to data
            //    // Hint: Requires the column type to be set at design time to ComboBoxColumn via DataGridView Tasks Wizard > Edit Columns... > ColumnType
            //    //       Requires a rename at design time of the column's Name property. Change the suffix TextBoxColumn to ComboBoxColumn to reflect the ColumnType.
            //    BindDataGridViewComboBoxColumn(TeamsDataGridView, "firstGpTrackDataGridViewComboBoxColumn", database.FirstGpTrackLookups);
            //    BindDataGridViewComboBoxColumn(TeamsDataGridView, "tyreSupplierIdDataGridViewComboBoxColumn", database.TyreSupplierIdAsSupplierIdLookups);
            //    BindDataGridViewComboBoxColumn(ChiefsF1DesignerDataGridView, "driverLoyaltyDataGridViewComboBoxColumn", database.DriverLoyaltyDriverIdAsStaffIdLookups);
            //    BindDataGridViewComboBoxColumn(ChiefsF1EngineerDataGridView, "driverLoyaltyDataGridViewComboBoxColumn1", database.DriverLoyaltyDriverIdAsStaffIdLookups);
            //    BindDataGridViewComboBoxColumn(ChiefsF1MechanicDataGridView, "driverLoyaltyDataGridViewComboBoxColumn2", database.DriverLoyaltyDriverIdAsStaffIdLookups);
            //    BindDataGridViewComboBoxColumn(DriversF1DataGridView, "nationalityDataGridViewComboBoxColumn", database.DriverNationalityLookups);
            //    BindDataGridViewComboBoxColumn(DriversNonF1DataGridView, "nationalityDataGridViewComboBoxColumn1", database.DriverNationalityLookups);
            //    BindDataGridViewComboBoxColumn(TracksDataGridView, "designDataGridViewComboBoxColumn", database.TrackDesignLookups);
            //    BindDataGridViewComboBoxColumn(TracksDataGridView, "lapRecordDriverDataGridViewComboBoxColumn", database.FastestLapDriverIdAsStaffIdLookups);
            //    BindDataGridViewComboBoxColumn(TracksDataGridView, "lapRecordTeamDataGridViewComboBoxColumn", database.Teams);
            //    BindDataGridViewComboBoxColumn(TracksDataGridView, "lastRaceDriverDataGridViewComboBoxColumn", database.FastestLapDriverIdAsStaffIdLookups);
            //    BindDataGridViewComboBoxColumn(TracksDataGridView, "lastRaceTeamDataGridViewComboBoxColumn", database.Teams);
            //}
        */

        /* TODO: A dead method now as view properties returns data instead, could use code as reference
        //private void PopulateRecords(ExecutableDatabase database)
        //{
        //    // Move data from controls into database
        //    database.LanguageResources = (IdentityCollection)LanguageDataGridView.DataSource;
        //    database.Teams = (Collection<Team>)TeamsDataGridView.DataSource;
        //    database.F1ChiefCommercials = (Collection<F1ChiefCommercial>)ChiefsF1CommerceDataGridView.DataSource;
        //    database.F1ChiefDesigners = (Collection<F1ChiefDesigner>)ChiefsF1DesignerDataGridView.DataSource;
        //    database.F1ChiefEngineers = (Collection<F1ChiefEngineer>)ChiefsF1EngineerDataGridView.DataSource;
        //    database.F1ChiefMechanics = (Collection<F1ChiefMechanic>)ChiefsF1MechanicDataGridView.DataSource;
        //    database.NonF1ChiefCommercials = (Collection<NonF1ChiefCommercial>)ChiefsNonF1CommerceDataGridView.DataSource;
        //    database.NonF1ChiefDesigners = (Collection<NonF1ChiefDesigner>)ChiefsNonF1DesignerDataGridView.DataSource;
        //    database.NonF1ChiefEngineers = (Collection<NonF1ChiefEngineer>)ChiefsNonF1EngineerDataGridView.DataSource;
        //    database.NonF1ChiefMechanics = (Collection<NonF1ChiefMechanic>)ChiefsNonF1MechanicDataGridView.DataSource;
        //    database.F1Drivers = (Collection<F1Driver>)DriversF1DataGridView.DataSource;
        //    database.NonF1Drivers = (Collection<NonF1Driver>)DriversNonF1DataGridView.DataSource;
        //    database.Engines = (Collection<Engine>)SuppliersEnginesDataGridView.DataSource;
        //    database.Tyres = (Collection<Tyre>)SuppliersTyresDataGridView.DataSource;
        //    database.Fuels = (Collection<Fuel>)SuppliersFuelsDataGridView.DataSource;
        //    database.Tracks = (Collection<Track>)TracksDataGridView.DataSource;
        //    database.ChassisHandlings = (Collection<ChassisHandling>)ChassisHandlingDataGridView.DataSource;
        //    // TODO database.StaffEfforts = (FiveRatingCollection)StaffEffortsDataGridView.DataSource;
        //    // TODO database.StaffSalaries = (FiveRatingCollection)StaffSalariesDataGridView.DataSource;
        //    // TODO database.FactoryRunningCosts = (FiveValueCollection)FactoryRunningCostsDataGridView.DataSource;
        //    // TODO database.FactoryExpansionCosts = (FiveRatingCollection)FactoryExpansionCostsDataGridView.DataSource;
        //    // TODO database.TestingMiles = (TenValueCollection)TestingMilesDataGridView.DataSource;
        //    // TODO database.EngineeringCosts = (TenValueCollection)EngineeringCostsDataGridView.DataSource;
        //    // TODO database.UnknownAEfforts = (SingleValueCollection)UnknownADataGridView.DataSource;
        //    // TODO database.UnknownBEfforts = (SingleValueCollection)UnknownBDataGridView.DataSource;
        //}
        */

        private void SubscribeDataGridViewControlsToGenericEvents()
        {
            // Find all datagridview controls on form and subscribe them to their generic events
            foreach (var control in this.GetAllControlsOfType(typeof(DataGridView)))
            {
                //((DataGridView)control).DataError += GenericDataGridView_DataError;           // TODO: Verify requirement
                ((DataGridView)control).CellEnter += GenericDataGridView_CellEnter;             // TODO: Verify requirement
                //((DataGridView)control).CellLeave += GenericDataGridView_CellLeave;           // TODO: Verify requirement
                //((DataGridView)control).CellValidating += GenericDataGridView_CellValidating; // TODO: Verify requirement
            }
        }

        //// ReSharper disable once UnusedMember.Local
        //private void ValidateDataGridViewCell<T>(DataGridView dataGridView, DataGridViewCellValidatingEventArgs e) where T : IIdentity
        //{
        //    // Ignore validation on hidden columns
        //    if (e.ColumnIndex < 4)
        //    {
        //        return;
        //    }

        //    // Validate user editable columns
        //    var row = dataGridView.Rows[e.RowIndex];
        //    var column = dataGridView.Columns[e.ColumnIndex];
        //    var cell = row.Cells[e.ColumnIndex];
        //    var newValue = e.FormattedValue;
        //    var oldValue = cell.FormattedValue.ToString();

        //    var properties = typeof(T).GetProperties();
        //    var property = properties.Single(x => x.Name == column.DataPropertyName);
        //    var attributes = property.GetCustomAttributes(true);

        //    // If validating an integer field
        //    if (property.PropertyType == typeof(int))
        //    {
        //        // If combobox column, get value of selected item
        //        if (column is DataGridViewComboBoxColumn)
        //        {
        //            foreach (var item in (column as DataGridViewComboBoxColumn).Items)
        //            {
        //                if (((IIdentity)item).ResourceText == newValue.ToString())
        //                {
        //                    newValue = ((IIdentity)item).LocalResourceId;
        //                    break;
        //                }
        //            }
        //        }

        //        // Validate type
        //        int intValue;
        //        if (!int.TryParse(newValue.ToString(), out intValue))
        //        {
        //            e.Cancel = true;
        //            dataGridView.CancelEdit();
        //            dataGridView.EndEdit();
        //            _isFailedValidationForSwitchingContext = true;
        //            ShowMessageBox($"Value for {column.HeaderText} must be a whole number.", MessageBoxIcon.Error);
        //            return;
        //        }

        //        // Process attributes
        //        foreach (var attribute in attributes)
        //        {
        //            // Validate range
        //            var rangeAttribute = attribute as RangeAttribute;
        //            if (rangeAttribute != null)
        //            {
        //                if ((intValue < (int)rangeAttribute.Minimum) || (intValue > (int)rangeAttribute.Maximum))
        //                {
        //                    e.Cancel = true;
        //                    dataGridView.CancelEdit();
        //                    dataGridView.EndEdit();
        //                    _isFailedValidationForSwitchingContext = true;
        //                    ShowMessageBox(rangeAttribute.FormatErrorMessage(column.HeaderText), MessageBoxIcon.Error);
        //                    return;
        //                }
        //            }
        //        }

        //        // If combobox column, commit and end edit now that validation has been cleared
        //        if (column is DataGridViewComboBoxColumn)
        //        {
        //            dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //            dataGridView.EndEdit();
        //        }
        //    }
        //}

        private void ChassisHandlingOriginalValuesButton_Click(object sender, EventArgs e)
        {
            //var values = new[]
            //{
            //    75,
            //    80,
            //    70,
            //    90,
            //    55,
            //    30,
            //    45,
            //    50,
            //    40,
            //    25,
            //    20
            //};

            //UpdateValuesInDataGridViewColumn(ChassisHandlingDataGridView, 4, values);
        }

        private void ChassisHandlingRecommendedValuesButton_Click(object sender, EventArgs e)
        {
            //var values = new[]
            //{
            //    44,
            //    50,
            //    45,
            //    66,
            //    37,
            //    26,
            //    34,
            //    23,
            //    22,
            //    13,
            //    13
            //};

            //UpdateValuesInDataGridViewColumn(ChassisHandlingDataGridView, 4, values);
        }

        private void ChassisHandlingCalculatedValuesButton_Click(object sender, EventArgs e)
        {
            //var values = new[]
            //{
            //    CalculateChassisHandling(0),
            //    CalculateChassisHandling(1),
            //    CalculateChassisHandling(2),
            //    CalculateChassisHandling(3),
            //    CalculateChassisHandling(4),
            //    CalculateChassisHandling(5),
            //    CalculateChassisHandling(6),
            //    CalculateChassisHandling(7),
            //    CalculateChassisHandling(8),
            //    CalculateChassisHandling(9),
            //    CalculateChassisHandling(10)
            //};

            //UpdateValuesInDataGridViewColumn(ChassisHandlingDataGridView, 4, values);
        }

        //private int CalculateChassisHandling(int id)
        //{
        //    var championshipPosition = GetDataGridCellValue(TeamsDataGridView, 4, id);
        //    var designerAbility = GetDataGridCellValue(ChiefsF1DesignerDataGridView, 4, id);
        //    var engineerAbility = GetDataGridCellValue(ChiefsF1EngineerDataGridView, 4, id);
        //    const int designerFactor = 5;
        //    const int engineerFactor = 15;
        //    var randomFactor = new Random().Next(0, 21); // 0..20
        //    return designerFactor * (designerAbility - 1) + engineerFactor * (engineerAbility - 1) +
        //                      (31 - championshipPosition - randomFactor);
        //}

        //private static int GetDataGridCellValue(DataGridView dataGridView, int columnIndex, int rowIndex)
        //{
        //    int tryParseResult;
        //    if (!int.TryParse(dataGridView.Rows[rowIndex].Cells[columnIndex].Value.ToString(), out tryParseResult))
        //    {
        //        throw new Exception("Unable to parse value to the required type.");
        //    }
        //    return tryParseResult;
        //}
    }
}