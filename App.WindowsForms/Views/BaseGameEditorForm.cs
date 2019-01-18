using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using App.WindowsForms.Controllers;
using App.WindowsForms.Models;
using App.WindowsForms.Models.Lookups;
using App.WindowsForms.Views.Extensions;

namespace App.WindowsForms.Views
{
    public partial class BaseGameEditorForm : EditorForm
    {
        private BaseGameEditorController _controller;

        #region ToolTip Declarations
        private const string ReadOnlyToolTipText = " This field is read only.";

        private const string TeamsIdToolTipText = "The id of the team record.";
        private const string TeamsTeamIdToolTipText = "The id of the team.";
        private const string TeamsNameToolTipText = "The name of the team." + ReadOnlyToolTipText;
        private const string TeamsLastPositionToolTipText = "The finishing position of the team in last year's constructors' championship (e.g. 1997 when playing the 1998 season).";
        private const string TeamsLastPointsToolTipText = "The number of points scored by the team in last year's constructors' championship (e.g. 1997 when playing the 1998 season).";
        private const string TeamsDebutGrandPrixToolTipText = "The Grand Prix where the team made their debut.";
        private const string TeamsDebutYearToolTipText = "The year when the team made their Grand Prix debut.";
        private const string TeamsWinsToolTipText = "The number of wins scored by the team.";
        private const string TeamsYearlyBudgetToolTipText = "An estimation of the team's budget for this year's championship (e.g. 1998 when playing the 1998 season).";
        private const string TeamsUnknownAToolTipText = "An unknown value for the team.";
        private const string TeamsLocationToolTipText = "The country where the team's factory is located and represents the country map to display in the game.";
        private const string TeamsLocationXToolTipText = "The X co-ordinate of the pointer where the team's factory is located on the country map in the game.";
        private const string TeamsLocationYToolTipText = "The Y co-ordinate of the pointer where the team's factory is located on the country map in the game.";
        private const string TeamsTyreSupplierToolTipText = "The tyre manufacturer supplying the team for this year's championship (e.g. 1998 when playing the 1998 season). Unknown usage but suspect this may be used to determine the tyre sidewalls to display.";
        private const string TeamsChassisHandlingToolTipText = "The handling rating of the chassis at the start of the game.";
        private const string TeamsCarNumberDriver1ToolTipText = "The car number used by the team for driver 1.";
        private const string TeamsCarNumberDriver2ToolTipText = "The car number used by the team for driver 2.";

        private const string ChiefsIdToolTipText = "The id of the chief record.";
        private const string ChiefsTeamIdToolTipText = "The id of the team the chief is contracted to.";
        private const string ChiefsNameToolTipText = "The name of the chief." + ReadOnlyToolTipText;
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
        private const string DriversNameToolTipText = "The name of the driver." + ReadOnlyToolTipText;
        private const string DriversSalaryToolTipText = "The salary paid to the driver. Pay drivers will have a negative salary amount (e.g. -3500000).";
        private const string DriversRaceBonusToolTipText = "The race bonus awarded to the driver.";
        private const string DriversChampionshipBonusToolTipText = "The championship bonus awarded to the driver.";
        private const string DriversLastChampionshipPositionToolTipText = "The finishing position of the driver in last year's drivers' championship (e.g. 1997 when playing the 1998 season).";
        private const string DriversRoleToolTipText = "The role of the driver in the team, as agreed in the driver's contract.";
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

        private const string SponsorshipTeamsIdToolTipText = "The id of the team sponsor record.";
        private const string SponsorshipTeamsNameToolTipText = "The name of the team sponsor." + ReadOnlyToolTipText;
        private const string SponsorshipTeamsCashRatingToolTipText = "The cash rating of the team sponsor.";

        private const string SponsorshipEnginesIdToolTipText = "The id of the engine supplier record.";
        private const string SponsorshipEnginesNameToolTipText = "The name of the engine supplier." + ReadOnlyToolTipText;
        private const string SponsorshipEnginesCashRatingToolTipText = "The cash rating of the engine supplier.";
        private const string SponsorshipEnginesRadRatingToolTipText = "The research and design rating of the engine supplier.";
        private const string SponsorshipEnginesFuelToolTipText = "The fuel rating of the engine.";
        private const string SponsorshipEnginesHeatToolTipText = "The heat rating of the engine.";
        private const string SponsorshipEnginesPowerToolTipText = "The power rating of the engine.";
        private const string SponsorshipEnginesReliabilityToolTipText = "The reliability rating of the engine.";
        private const string SponsorshipEnginesResponseToolTipText = "The response rating of the engine.";
        private const string SponsorshipEnginesRigidityToolTipText = "The rigidity rating of the engine.";
        private const string SponsorshipEnginesWeightToolTipText = "The weight rating of the engine.";

        private const string SponsorshipTyresIdToolTipText = "The id of the tyre supplier record.";
        private const string SponsorshipTyresNameToolTipText = "The name of the tyre supplier." + ReadOnlyToolTipText;
        private const string SponsorshipTyresCashRatingToolTipText = "The cash rating of the tyre supplier.";
        private const string SponsorshipTyresRadRatingToolTipText = "The research and design rating of the tyre supplier.";
        private const string SponsorshipTyresDryHardGripToolTipText = "The grip rating of the dry hard tyre.";
        private const string SponsorshipTyresDryHardResilienceToolTipText = "The resilience rating of the dry hard tyre.";
        private const string SponsorshipTyresDryHardStiffnessToolTipText = "The stiffness rating of the dry hard tyre.";
        private const string SponsorshipTyresDryHardTemperatureToolTipText = "The temperature rating of the dry hard tyre.";
        private const string SponsorshipTyresDrySoftGripToolTipText = "The grip rating of the dry soft tyre.";
        private const string SponsorshipTyresDrySoftResilienceToolTipText = "The resilience rating of the dry soft tyre.";
        private const string SponsorshipTyresDrySoftStiffnessToolTipText = "The stiffness rating of the dry soft tyre.";
        private const string SponsorshipTyresDrySoftTemperatureToolTipText = "The temperature rating of the dry soft tyre.";
        private const string SponsorshipTyresIntermediateGripToolTipText = "The grip rating of the intermediate tyre.";
        private const string SponsorshipTyresIntermediateResilienceToolTipText = "The resilience rating of the intermediate tyre.";
        private const string SponsorshipTyresIntermediateStiffnessToolTipText = "The stiffness rating of the intermediate tyre.";
        private const string SponsorshipTyresIntermediateTemperatureToolTipText = "The temperature rating of the intermediate tyre.";
        private const string SponsorshipTyresWetWeatherGripToolTipText = "The grip rating of the wet weather tyre.";
        private const string SponsorshipTyresWetWeatherResilienceToolTipText = "The resilience rating of the wet weather tyre.";
        private const string SponsorshipTyresWetWeatherStiffnessToolTipText = "The stiffness rating of the wet weather tyre.";
        private const string SponsorshipTyresWetWeatherTemperatureToolTipText = "The temperature rating of the wet weather tyre.";

        private const string SponsorshipFuelsIdToolTipText = "The id of the fuel supplier record.";
        private const string SponsorshipFuelsNameToolTipText = "The name of the fuel supplier." + ReadOnlyToolTipText;
        private const string SponsorshipFuelsCashRatingToolTipText = "The cash rating of the fuel supplier.";
        private const string SponsorshipFuelsRadRatingToolTipText = "The research and design rating of the fuel supplier.";
        private const string SponsorshipFuelsPerformanceToolTipText = "The performance rating of the fuel.";
        private const string SponsorshipFuelsToleranceToolTipText = "The tolerance rating of the fuel.";

        private const string SponsorshipCashsIdToolTipText = "The id of the cash sponsor record.";
        private const string SponsorshipCashsNameToolTipText = "The name of the cash sponsor." + ReadOnlyToolTipText;
        private const string SponsorshipCashsCashRatingToolTipText = "The cash rating of the cash sponsor.";

        private const string SponsorshipContractsIdToolTipText = "The id of the sponsor contract record.";
        // TODO: private const string SponsorshipContractsNameToolTipText = "The name of the sponsor." + ReadOnlyToolTipText;

        private const string TracksIdToolTipText = "The id of the track record.";
        private const string TracksNameToolTipText = "The name of the track." + ReadOnlyToolTipText;
        private const string TracksLapsToolTipText = "The number of racing laps in a Grand Prix.";
        private const string TracksLayoutToolTipText = "The layout of the track.";
        private const string TracksLapRecordDriverToolTipText = "The name of the driver that set the fastest lap record at the track.";
        private const string TracksLapRecordTeamToolTipText = "The name of the team that set the fastest lap record at the track.";
        private const string TracksLapRecordTimeToolTipText = "The laptime that set the fastest lap record at the track."; // TODO: Should describe number format
        private const string TracksLapRecordMphToolTipText = "The average speed (MPH) that set the fastest lap record at the track.";
        private const string TracksLapRecordYearToolTipText = "The year when the fastest lap record was set at the track.";
        private const string TracksLastRaceDriverToolTipText = "The name of the driver that won the last Grand Prix held at the track.";
        private const string TracksLastRaceTeamToolTipText = "The name of the team that won the last Grand Prix held at the track.";
        private const string TracksLastRaceYearToolTipText = "The year the last Grand Prix was held at the track.";
        private const string TracksLastRaceTimeToolTipText = "The duration of the race when the last Grand Prix was held at the track."; // TODO: Should describe number format
        private const string TracksHospitalityToolTipText = "The hospitality rating of the track.";
        private const string TracksSpeedToolTipText = "The speed rating of the track.";
        private const string TracksGripToolTipText = "The grip rating of the track.";
        private const string TracksSurfaceToolTipText = "The surface rating of the track.";
        private const string TracksTarmacToolTipText = "The tarmac rating of the track.";
        private const string TracksDustToolTipText = "The dust rating of the track.";
        private const string TracksOvertakingToolTipText = "The overtaking rating of the track.";
        private const string TracksBrakingToolTipText = "The braking rating of the track.";
        private const string TracksRainToolTipText = "The rain rating of the track.";
        private const string TracksHeatToolTipText = "The heat rating of the track.";
        private const string TracksWindToolTipText = "The wind rating of the track.";
        #endregion

        public string GameFolderPath { get => GameFolderPathTextBox.Text; set => GameFolderPathTextBox.Text = value; }
        public string GameExecutableFilePath { get => GameExecutablePathTextBox.Text; set => GameExecutablePathTextBox.Text = value; }
        public string EnglishLanguageFilePath { get => EnglishLanguageFilePathTextBox.Text; set => EnglishLanguageFilePathTextBox.Text = value; }
        public string FrenchLanguageFilePath { get => FrenchLanguageFilePathTextBox.Text; set => FrenchLanguageFilePathTextBox.Text = value; }
        public string GermanLanguageFilePath { get => GermanLanguageFilePathTextBox.Text; set => GermanLanguageFilePathTextBox.Text = value; }
        public string EnglishCommentaryFilePath { get => EnglishCommentaryFilePathTextBox.Text; set => EnglishCommentaryFilePathTextBox.Text = value; }
        public string FrenchCommentaryFilePath { get => FrenchCommentaryFilePathTextBox.Text; set => FrenchCommentaryFilePathTextBox.Text = value; }
        public string GermanCommentaryFilePath { get => GermanCommentaryFilePathTextBox.Text; set => GermanCommentaryFilePathTextBox.Text = value; }

        public IEnumerable<ChiefDriverLoyaltyLookupModel> ChiefDriverLoyaltyLookups { get; set; }
        public IEnumerable<DriverNationalityLookupModel> DriverNationalityLookups { get; set; }
        public IEnumerable<DriverRoleLookupModel> DriverRoleLookups { get; set; }
        public IEnumerable<TeamDebutGrandPrixLookupModel> TeamDebutGrandPrixLookups { get; set; }
        public IEnumerable<TeamLocationLookupModel> TeamLocationLookups { get; set; }
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

        public IEnumerable<SponsorModel> SponsorTeams
        {
            get => (IEnumerable<SponsorModel>)SponsorshipTeamDataGridView.DataSource;
            set => BuildSponsorTeamDataGridView(value);
        }

        public IEnumerable<SponsorModel> SponsorEngines
        {
            get => (IEnumerable<SponsorModel>)SponsorshipEngineDataGridView.DataSource;
            set => BuildSponsorEngineDataGridView(value);
        }

        public IEnumerable<SponsorModel> SponsorTyres
        {
            get => (IEnumerable<SponsorModel>)SponsorshipTyreDataGridView.DataSource;
            set => BuildSponsorTyreDataGridView(value);
        }

        public IEnumerable<SponsorModel> SponsorFuels
        {
            get => (IEnumerable<SponsorModel>)SponsorshipFuelDataGridView.DataSource;
            set => BuildSponsorFuelDataGridView(value);
        }

        public IEnumerable<SponsorModel> SponsorCashs
        {
            get => (IEnumerable<SponsorModel>)SponsorshipCashDataGridView.DataSource;
            set => BuildSponsorCashDataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam01
        {
            get => (IEnumerable<SponsorContractModel>)SponsorshipContractsTeam01DataGridView.DataSource;
            set => BuildSponsorshipContractsTeam01DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam02
        {
            get => (IEnumerable<SponsorContractModel>)SponsorshipContractsTeam02DataGridView.DataSource;
            set => BuildSponsorshipContractsTeam02DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam03
        {
            get => (IEnumerable<SponsorContractModel>)SponsorshipContractsTeam03DataGridView.DataSource;
            set => BuildSponsorshipContractsTeam03DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam04
        {
            get => (IEnumerable<SponsorContractModel>)SponsorshipContractsTeam04DataGridView.DataSource;
            set => BuildSponsorshipContractsTeam04DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam05
        {
            get => (IEnumerable<SponsorContractModel>)SponsorshipContractsTeam05DataGridView.DataSource;
            set => BuildSponsorshipContractsTeam05DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam06
        {
            get => (IEnumerable<SponsorContractModel>)SponsorshipContractsTeam06DataGridView.DataSource;
            set => BuildSponsorshipContractsTeam06DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam07
        {
            get => (IEnumerable<SponsorContractModel>)SponsorshipContractsTeam07DataGridView.DataSource;
            set => BuildSponsorshipContractsTeam07DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam08
        {
            get => (IEnumerable<SponsorContractModel>)SponsorshipContractsTeam08DataGridView.DataSource;
            set => BuildSponsorshipContractsTeam08DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam09
        {
            get => (IEnumerable<SponsorContractModel>)SponsorshipContractsTeam09DataGridView.DataSource;
            set => BuildSponsorshipContractsTeam09DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam10
        {
            get => (IEnumerable<SponsorContractModel>)SponsorshipContractsTeam10DataGridView.DataSource;
            set => BuildSponsorshipContractsTeam10DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam11
        {
            get => (IEnumerable<SponsorContractModel>)SponsorshipContractsTeam11DataGridView.DataSource;
            set => BuildSponsorshipContractsTeam11DataGridView(value);
        }

        public IEnumerable<TrackModel> Tracks
        {
            get => (IEnumerable<TrackModel>)TracksDataGridView.DataSource;
            set => BuildTracksDataGridView(value);
        }

        public BaseGameEditorForm()
        {
            InitializeComponent();
        }

        public void SetController(BaseGameEditorController controller)
        {
            _controller = controller;
        }

        private void BuildTeamDataGridView(IEnumerable<TeamModel> dataSource)
        {
            ResetDataGridView(TeamsDataGridView);

            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", TeamsIdToolTipText, false));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("TeamId", "TeamId", TeamsTeamIdToolTipText, false));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", TeamsNameToolTipText, true, true));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("LastPosition", "Last Year's Championship Position", TeamsLastPositionToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("LastPoints", "Last Year's Championship Points", TeamsLastPointsToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewComboBoxColumn("DebutGrandPrix", "Debut Grand Prix", TeamsDebutGrandPrixToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("DebutYear", "Debut Year", TeamsDebutYearToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("Wins", "Wins", TeamsWinsToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("YearlyBudget", "This Year's Budget", TeamsYearlyBudgetToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("UnknownA", "UnknownA", TeamsUnknownAToolTipText, false));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewComboBoxColumn("Location", "Location", TeamsLocationToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("LocationX", "Location X", TeamsLocationXToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("LocationY", "Location Y", TeamsLocationYToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewComboBoxColumn("TyreSupplier", "This Year's Tyre Supplier", TeamsTyreSupplierToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("ChassisHandling", "Chassis Handling Rating", TeamsChassisHandlingToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("CarNumberDriver1", "Car Number Driver 1", TeamsCarNumberDriver1ToolTipText));
            AddColumnToDataGridView(TeamsDataGridView, CreateDataGridViewTextBoxColumn("CarNumberDriver2", "Car Number Driver 2", TeamsCarNumberDriver2ToolTipText));

            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TeamsDataGridView.Columns["DebutGrandPrix"], TeamDebutGrandPrixLookups);
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TeamsDataGridView.Columns["Location"], TeamLocationLookups);
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TeamsDataGridView.Columns["TyreSupplier"], TyreSupplierLookups);
            BindDataGridViewToDataSource(TeamsDataGridView, dataSource);

            ConfigureDataGridView(TeamsDataGridView, "Name");
        }

        private void BuildChiefsF1CommerceDataGridView(IEnumerable<F1ChiefCommercialModel> dataSource)
        {
            ResetDataGridView(ChiefsF1CommerceDataGridView);

            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", ChiefsIdToolTipText, false));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("TeamId", "TeamId", ChiefsTeamIdToolTipText, false));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", ChiefsNameToolTipText, true, true));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Ability", "Ability", ChiefsAbilityToolTipText));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", ChiefsAgeToolTipText));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", ChiefsSalaryToolTipText));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Royalty", "Royalty", ChiefsRoyaltyToolTipText));
            AddColumnToDataGridView(ChiefsF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Morale", "Morale", ChiefsMoraleToolTipText));

            BindDataGridViewToDataSource(ChiefsF1CommerceDataGridView, dataSource);

            ConfigureDataGridView(ChiefsF1CommerceDataGridView, "Name");
        }

        private void BuildChiefsF1DesignerDataGridView(IEnumerable<F1ChiefDesignerModel> dataSource)
        {
            ResetDataGridView(ChiefsF1DesignerDataGridView);

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

            ConfigureDataGridView(ChiefsF1DesignerDataGridView, "Name");
        }

        private void BuildChiefsF1EngineerDataGridView(IEnumerable<F1ChiefEngineerModel> dataSource)
        {
            ResetDataGridView(ChiefsF1EngineerDataGridView);

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

            ConfigureDataGridView(ChiefsF1EngineerDataGridView, "Name");
        }

        private void BuildChiefsF1MechanicDataGridView(IEnumerable<F1ChiefMechanicModel> dataSource)
        {
            ResetDataGridView(ChiefsF1MechanicDataGridView);

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

            ConfigureDataGridView(ChiefsF1MechanicDataGridView, "Name");
        }

        private void BuildChiefsNonF1CommerceDataGridView(IEnumerable<NonF1ChiefCommercialModel> dataSource)
        {
            ResetDataGridView(ChiefsNonF1CommerceDataGridView);

            AddColumnToDataGridView(ChiefsNonF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", ChiefsIdToolTipText, false));
            AddColumnToDataGridView(ChiefsNonF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", ChiefsNameToolTipText, true, true));
            AddColumnToDataGridView(ChiefsNonF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Ability", "Ability", ChiefsAbilityToolTipText));
            AddColumnToDataGridView(ChiefsNonF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", ChiefsAgeToolTipText));
            AddColumnToDataGridView(ChiefsNonF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", ChiefsSalaryToolTipText));
            AddColumnToDataGridView(ChiefsNonF1CommerceDataGridView, CreateDataGridViewTextBoxColumn("Royalty", "Royalty", ChiefsRoyaltyToolTipText));

            BindDataGridViewToDataSource(ChiefsNonF1CommerceDataGridView, dataSource);

            ConfigureDataGridView(ChiefsNonF1CommerceDataGridView, "Name");
        }

        private void BuildChiefsNonF1DesignerDataGridView(IEnumerable<NonF1ChiefDesignerModel> dataSource)
        {
            ResetDataGridView(ChiefsNonF1DesignerDataGridView);

            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", ChiefsIdToolTipText, false));
            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", ChiefsNameToolTipText, true, true));
            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Ability", "Ability", ChiefsAbilityToolTipText));
            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", ChiefsAgeToolTipText));
            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", ChiefsSalaryToolTipText));
            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("RaceBonus", "Race Bonus", ChiefsRaceBonusToolTipText));
            AddColumnToDataGridView(ChiefsNonF1DesignerDataGridView, CreateDataGridViewTextBoxColumn("ChampionshipBonus", "Championship Bonus", ChiefsChampionshipBonusToolTipText));

            BindDataGridViewToDataSource(ChiefsNonF1DesignerDataGridView, dataSource);

            ConfigureDataGridView(ChiefsNonF1DesignerDataGridView, "Name");
        }

        private void BuildChiefsNonF1EngineerDataGridView(IEnumerable<NonF1ChiefEngineerModel> dataSource)
        {
            ResetDataGridView(ChiefsNonF1EngineerDataGridView);

            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", ChiefsIdToolTipText, false));
            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", ChiefsNameToolTipText, true, true));
            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Ability", "Ability", ChiefsAbilityToolTipText));
            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", ChiefsAgeToolTipText));
            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", ChiefsSalaryToolTipText));
            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("RaceBonus", "Race Bonus", ChiefsRaceBonusToolTipText));
            AddColumnToDataGridView(ChiefsNonF1EngineerDataGridView, CreateDataGridViewTextBoxColumn("ChampionshipBonus", "Championship Bonus", ChiefsChampionshipBonusToolTipText));

            BindDataGridViewToDataSource(ChiefsNonF1EngineerDataGridView, dataSource);

            ConfigureDataGridView(ChiefsNonF1EngineerDataGridView, "Name");
        }

        private void BuildChiefsNonF1MechanicDataGridView(IEnumerable<NonF1ChiefMechanicModel> dataSource)
        {
            ResetDataGridView(ChiefsNonF1MechanicDataGridView);

            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", ChiefsIdToolTipText, false));
            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", ChiefsNameToolTipText, true, true));
            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Ability", "Ability", ChiefsAbilityToolTipText));
            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Age", "Age", ChiefsAgeToolTipText));
            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", ChiefsSalaryToolTipText));
            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("RaceBonus", "Race Bonus", ChiefsRaceBonusToolTipText));
            AddColumnToDataGridView(ChiefsNonF1MechanicDataGridView, CreateDataGridViewTextBoxColumn("ChampionshipBonus", "Championship Bonus", ChiefsChampionshipBonusToolTipText));

            BindDataGridViewToDataSource(ChiefsNonF1MechanicDataGridView, dataSource);

            ConfigureDataGridView(ChiefsNonF1MechanicDataGridView, "Name");
        }

        private void BuildDriversF1DataGridView(IEnumerable<F1DriverModel> dataSource)
        {
            ResetDataGridView(DriversF1DataGridView);

            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", DriversIdToolTipText, false));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("TeamId", "TeamId", DriversTeamIdToolTipText, false));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", DriversNameToolTipText, true, true));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("Salary", "Salary", DriversSalaryToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("RaceBonus", "Race Bonus", DriversRaceBonusToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("ChampionshipBonus", "Championship Bonus", DriversChampionshipBonusToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewTextBoxColumn("LastChampionshipPosition", "Last Year's Championship Position", DriversLastChampionshipPositionToolTipText));
            AddColumnToDataGridView(DriversF1DataGridView, CreateDataGridViewComboBoxColumn("Role", "Role", DriversRoleToolTipText));
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

            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)DriversF1DataGridView.Columns["Role"], DriverRoleLookups);
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)DriversF1DataGridView.Columns["Nationality"], DriverNationalityLookups);
            BindDataGridViewToDataSource(DriversF1DataGridView, dataSource);

            ConfigureDataGridView(DriversF1DataGridView, "Name");
        }

        private void BuildDriversNonF1DataGridView(IEnumerable<NonF1DriverModel> dataSource)
        {
            ResetDataGridView(DriversNonF1DataGridView);

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

            ConfigureDataGridView(DriversNonF1DataGridView, "Name");
        }

        private void BuildSponsorTeamDataGridView(IEnumerable<SponsorModel> dataSource)
        {
            ResetDataGridView(SponsorshipTeamDataGridView);

            AddColumnToDataGridView(SponsorshipTeamDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SponsorshipTeamsIdToolTipText, false));
            AddColumnToDataGridView(SponsorshipTeamDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SponsorshipTeamsNameToolTipText, true, true));
            AddColumnToDataGridView(SponsorshipTeamDataGridView, CreateDataGridViewTextBoxColumn("SponsorId", "Sponsor Id", ""));
            AddColumnToDataGridView(SponsorshipTeamDataGridView, CreateDataGridViewTextBoxColumn("SponsorTypeId", "Sponsor Type", ""));
            AddColumnToDataGridView(SponsorshipTeamDataGridView, CreateDataGridViewTextBoxColumn("EntityType", "Entity Type", ""));
            AddColumnToDataGridView(SponsorshipTeamDataGridView, CreateDataGridViewTextBoxColumn("EntityResource", "Entity Resource", ""));
            AddColumnToDataGridView(SponsorshipTeamDataGridView, CreateDataGridViewTextBoxColumn("EntityData", "Entity Data", ""));
            AddColumnToDataGridView(SponsorshipTeamDataGridView, CreateDataGridViewTextBoxColumn("CashRating", "Cash Rating", SponsorshipTeamsCashRatingToolTipText));

            BindDataGridViewToDataSource(SponsorshipTeamDataGridView, dataSource);

            ConfigureDataGridView(SponsorshipTeamDataGridView, "Name");
        }

        private void BuildSponsorEngineDataGridView(IEnumerable<SponsorModel> dataSource)
        {
            ResetDataGridView(SponsorshipEngineDataGridView);

            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SponsorshipEnginesIdToolTipText, false));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SponsorshipEnginesNameToolTipText, true, true));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("SponsorId", "Sponsor Id", ""));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("SponsorTypeId", "Sponsor Type", ""));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("EntityType", "Entity Type", ""));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("EntityResource", "Entity Resource", ""));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("EntityData", "Entity Data", ""));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("CashRating", "Cash Rating", SponsorshipEnginesCashRatingToolTipText));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewCheckBoxColumn("CashRatingRandom", "Random Cash Rating", ""));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("RadRating", "R&D Rating", SponsorshipEnginesRadRatingToolTipText));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewCheckBoxColumn("RadRatingRandom", "Random R&D Rating", ""));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewCheckBoxColumn("Inactive", "Inactive", ""));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("Fuel", "Fuel", SponsorshipEnginesFuelToolTipText));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("Heat", "Heat", SponsorshipEnginesHeatToolTipText));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("Power", "Power", SponsorshipEnginesPowerToolTipText));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("Reliability", "Reliability", SponsorshipEnginesReliabilityToolTipText));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("Response", "Response", SponsorshipEnginesResponseToolTipText));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("Rigidity", "Rigidity", SponsorshipEnginesRigidityToolTipText));
            AddColumnToDataGridView(SponsorshipEngineDataGridView, CreateDataGridViewTextBoxColumn("Weight", "Weight", SponsorshipEnginesWeightToolTipText));

            BindDataGridViewToDataSource(SponsorshipEngineDataGridView, dataSource);

            ConfigureDataGridView(SponsorshipEngineDataGridView, "Name");
        }

        private void BuildSponsorTyreDataGridView(IEnumerable<SponsorModel> dataSource)
        {
            ResetDataGridView(SponsorshipTyreDataGridView);

            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SponsorshipTyresIdToolTipText, false));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SponsorshipTyresNameToolTipText, true, true));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("SponsorId", "Sponsor Id", ""));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("SponsorTypeId", "Sponsor Type", ""));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("EntityType", "Entity Type", ""));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("EntityResource", "Entity Resource", ""));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("EntityData", "Entity Data", ""));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("CashRating", "Cash Rating", SponsorshipTyresCashRatingToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewCheckBoxColumn("CashRatingRandom", "Random Cash Rating", ""));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("RadRating", "R&D Rating", SponsorshipTyresRadRatingToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewCheckBoxColumn("RadRatingRandom", "Random R&D Rating", ""));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewCheckBoxColumn("Inactive", "Inactive", ""));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("DryHardGrip", "Dry Hard Grip", SponsorshipTyresDryHardGripToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("DryHardResilience", "Dry Hard Resilience", SponsorshipTyresDryHardResilienceToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("DryHardStiffness", "Dry Hard Stiffness", SponsorshipTyresDryHardStiffnessToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("DryHardTemperature", "Dry Hard Temperature", SponsorshipTyresDryHardTemperatureToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("DrySoftGrip", "Dry Soft Grip", SponsorshipTyresDrySoftGripToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("DrySoftResilience", "Dry Soft Resilience", SponsorshipTyresDrySoftResilienceToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("DrySoftStiffness", "Dry Soft Stiffness", SponsorshipTyresDrySoftStiffnessToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("DrySoftTemperature", "Dry Soft Temperature", SponsorshipTyresDrySoftTemperatureToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("IntermediateGrip", "Intermediate Grip", SponsorshipTyresIntermediateGripToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("IntermediateResilience", "Intermediate Resilience", SponsorshipTyresIntermediateResilienceToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("IntermediateStiffness", "Intermediate Stiffness", SponsorshipTyresIntermediateStiffnessToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("IntermediateTemperature", "Intermediate Temperature", SponsorshipTyresIntermediateTemperatureToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("WetWeatherGrip", "Wet Weather Grip", SponsorshipTyresWetWeatherGripToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("WetWeatherResilience", "Wet Weather Resilience", SponsorshipTyresWetWeatherResilienceToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("WetWeatherStiffness", "Wet Weather Stiffness", SponsorshipTyresWetWeatherStiffnessToolTipText));
            AddColumnToDataGridView(SponsorshipTyreDataGridView, CreateDataGridViewTextBoxColumn("WetWeatherTemperature", "Wet Weather Temperature", SponsorshipTyresWetWeatherTemperatureToolTipText));

            BindDataGridViewToDataSource(SponsorshipTyreDataGridView, dataSource);

            ConfigureDataGridView(SponsorshipTyreDataGridView, "Name");
        }

        private void BuildSponsorFuelDataGridView(IEnumerable<SponsorModel> dataSource)
        {
            ResetDataGridView(SponsorshipFuelDataGridView);

            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SponsorshipFuelsIdToolTipText, false));
            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SponsorshipFuelsNameToolTipText, true, true));
            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewTextBoxColumn("SponsorId", "Sponsor Id", ""));
            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewTextBoxColumn("SponsorTypeId", "Sponsor Type", ""));
            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewTextBoxColumn("EntityType", "Entity Type", ""));
            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewTextBoxColumn("EntityResource", "Entity Resource", ""));
            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewTextBoxColumn("EntityData", "Entity Data", ""));
            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewTextBoxColumn("CashRating", "Cash Rating", SponsorshipFuelsCashRatingToolTipText));
            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewCheckBoxColumn("CashRatingRandom", "Random Cash Rating", ""));
            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewTextBoxColumn("RadRating", "R&D Rating", SponsorshipFuelsRadRatingToolTipText));
            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewCheckBoxColumn("RadRatingRandom", "Random R&D Rating", ""));
            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewCheckBoxColumn("Inactive", "Inactive", ""));
            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewTextBoxColumn("Performance", "Performance", SponsorshipFuelsPerformanceToolTipText));
            AddColumnToDataGridView(SponsorshipFuelDataGridView, CreateDataGridViewTextBoxColumn("Tolerance", "Tolerance", SponsorshipFuelsToleranceToolTipText));

            BindDataGridViewToDataSource(SponsorshipFuelDataGridView, dataSource);

            ConfigureDataGridView(SponsorshipFuelDataGridView, "Name");
        }

        private void BuildSponsorCashDataGridView(IEnumerable<SponsorModel> dataSource)
        {
            ResetDataGridView(SponsorshipCashDataGridView);

            AddColumnToDataGridView(SponsorshipCashDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SponsorshipCashsIdToolTipText, false));
            AddColumnToDataGridView(SponsorshipCashDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SponsorshipCashsNameToolTipText, true, true));
            AddColumnToDataGridView(SponsorshipCashDataGridView, CreateDataGridViewTextBoxColumn("SponsorId", "Sponsor Id", ""));
            AddColumnToDataGridView(SponsorshipCashDataGridView, CreateDataGridViewTextBoxColumn("SponsorTypeId", "Sponsor Type", ""));
            AddColumnToDataGridView(SponsorshipCashDataGridView, CreateDataGridViewTextBoxColumn("EntityType", "Entity Type", ""));
            AddColumnToDataGridView(SponsorshipCashDataGridView, CreateDataGridViewTextBoxColumn("EntityResource", "Entity Resource", ""));
            AddColumnToDataGridView(SponsorshipCashDataGridView, CreateDataGridViewTextBoxColumn("EntityData", "Entity Data", ""));
            AddColumnToDataGridView(SponsorshipCashDataGridView, CreateDataGridViewTextBoxColumn("CashRating", "Cash Rating", SponsorshipCashsCashRatingToolTipText));

            BindDataGridViewToDataSource(SponsorshipCashDataGridView, dataSource);

            ConfigureDataGridView(SponsorshipCashDataGridView, "Name");
        }

        private static void BuildSponsorContractsDataGridView(DataGridView dataGridView, IEnumerable<SponsorContractModel> dataSource)
        {
            ResetDataGridView(dataGridView);

            AddColumnToDataGridView(dataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SponsorshipContractsIdToolTipText, false));
            AddColumnToDataGridView(dataGridView, CreateDataGridViewTextBoxColumn("TeamId", "TeamId", "")); // TODO: temporary
            AddColumnToDataGridView(dataGridView, CreateDataGridViewTextBoxColumn("SlotId", "SlotId", "")); // TODO: temporary
            AddColumnToDataGridView(dataGridView, CreateDataGridViewTextBoxColumn("SlotTypeId", "SlotTypeId", "")); // TODO: tooltip
            AddColumnToDataGridView(dataGridView, CreateDataGridViewTextBoxColumn("SponsorId", "SponsorId", "")); // TODO: tooltip
            AddColumnToDataGridView(dataGridView, CreateDataGridViewTextBoxColumn("Cash", "Cash", "")); // TODO: tooltip
            AddColumnToDataGridView(dataGridView, CreateDataGridViewTextBoxColumn("DealId", "DealId", "")); // TODO: tooltip
            AddColumnToDataGridView(dataGridView, CreateDataGridViewTextBoxColumn("TermsId", "TermsId", "")); // TODO: tooltip

            BindDataGridViewToDataSource(dataGridView, dataSource);

            ConfigureDataGridView(dataGridView, "SlotId");
        }

        private void BuildSponsorshipContractsTeam01DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorContractsDataGridView(SponsorshipContractsTeam01DataGridView, dataSource);
        }

        private void BuildSponsorshipContractsTeam02DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorContractsDataGridView(SponsorshipContractsTeam02DataGridView, dataSource);
        }

        private void BuildSponsorshipContractsTeam03DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorContractsDataGridView(SponsorshipContractsTeam03DataGridView, dataSource);
        }

        private void BuildSponsorshipContractsTeam04DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorContractsDataGridView(SponsorshipContractsTeam04DataGridView, dataSource);
        }

        private void BuildSponsorshipContractsTeam05DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorContractsDataGridView(SponsorshipContractsTeam05DataGridView, dataSource);
        }

        private void BuildSponsorshipContractsTeam06DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorContractsDataGridView(SponsorshipContractsTeam06DataGridView, dataSource);
        }

        private void BuildSponsorshipContractsTeam07DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorContractsDataGridView(SponsorshipContractsTeam07DataGridView, dataSource);
        }

        private void BuildSponsorshipContractsTeam08DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorContractsDataGridView(SponsorshipContractsTeam08DataGridView, dataSource);
        }

        private void BuildSponsorshipContractsTeam09DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorContractsDataGridView(SponsorshipContractsTeam09DataGridView, dataSource);
        }

        private void BuildSponsorshipContractsTeam10DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorContractsDataGridView(SponsorshipContractsTeam10DataGridView, dataSource);
        }

        private void BuildSponsorshipContractsTeam11DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorContractsDataGridView(SponsorshipContractsTeam11DataGridView, dataSource);
        }

        private void BuildTracksDataGridView(IEnumerable<TrackModel> dataSource)
        {
            ResetDataGridView(TracksDataGridView);

            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", TracksIdToolTipText, false));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", TracksNameToolTipText, true, true));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewTextBoxColumn("Laps", "Laps", TracksLapsToolTipText));
            AddColumnToDataGridView(TracksDataGridView, CreateDataGridViewComboBoxColumn("Layout", "Layout", TracksLayoutToolTipText));
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

            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TracksDataGridView.Columns["Layout"], TrackLayoutLookups);
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TracksDataGridView.Columns["LapRecordDriver"], TrackDriverLookups);
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TracksDataGridView.Columns["LapRecordTeam"], TrackTeamLookups);
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TracksDataGridView.Columns["LastRaceDriver"], TrackDriverLookups);
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)TracksDataGridView.Columns["LastRaceTeam"], TrackTeamLookups);
            BindDataGridViewToDataSource(TracksDataGridView, dataSource);

            ConfigureDataGridView(TracksDataGridView, "Name");
        }

        private void GameExecutableEditorForm_Load(object sender, EventArgs e)
        {
            _controller.LoadView();
        }

        private void GameExecutableEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_controller.CloseForm(); // Abort event if returns false
        }

        private void BaseGameEditorTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !_controller.ChangeTab(); // Abort event if returns false
        }

        private void GameFolderPathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeGameFolder();
        }

        private void GameExecutablePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeGameExecutable();
        }

        private void EnglishLanguageFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeEnglishLanguageFile();
        }

        private void FrenchLanguageFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeFrenchLanguageFile();
        }

        private void GermanLanguageFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeGermanLanguageFile();
        }

        private void EnglishCommentaryFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeEnglishCommentaryFile();
        }

        private void FrenchCommentaryFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeFrenchCommentaryFile();
        }

        private void GermanCommentaryFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeGermanCommentaryFile();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            _controller.Import();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            _controller.Export();
        }

        // TODO: Review
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

        // TODO: Review
        private static void GenericDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        // TODO: Review
        private void GenericDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //_isFailedValidationForSwitchingContext = false; // Reset

            //// Get the type used in the collection that is assigned to the datasource of the datagridview
            //// And invoke the named generic method, passing the required parameters to the generic method
            //// http://stackoverflow.com/a/325161
            //var dataGridView = (DataGridView)sender;
            //var listItemType = ListBindingHelper.GetListItemType(dataGridView.DataSource);
            //var methodInfo = typeof(BaseGameEditorForm).GetMethod("ValidateDataGridViewCell", BindingFlags.NonPublic | BindingFlags.Instance);
            //var genericMethod = methodInfo.MakeGenericMethod(listItemType);
            //genericMethod.Invoke(this, new[] { sender, e });
        }

        // TODO: Review
        private static void GenericDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //// Handle error that occurs after viewing the datagridview with imported data, having previously viewed the datagridview with no data
            //// https://refactoringself.com/2012/09/26/datagridview-formattingexception-dataerror-and-preferredsize-auto-sizing-issue/

            //if (e.Context == (DataGridViewDataErrorContexts.Formatting | DataGridViewDataErrorContexts.PreferredSize))
            //{
            //    e.Cancel = true;
            //}
        }

        // TODO: Review
        /* TODO: A dead method now as datasources are assigned by controller instead, could use code as reference
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
        */

        // TODO: Review
        /* TODO: A dead method now as datasources are assigned by controller instead, could use code as reference
            //private void PopulateControls(ExecutableDatabase database)
            //{
            //    // Move data from database into controls
            //    LanguageDataGridView.DataSource = database.LanguageResources;
            //}
        */

        // TODO: Review
        /* TODO: A dead method now as view properties returns data instead, could use code as reference
        //private void PopulateRecords(ExecutableDatabase database)
        //{
        //    // Move data from controls into database
        //    database.LanguageResources = (IdentityCollection)LanguageDataGridView.DataSource;
        //}
        */

        // TODO: Review
        public void SubscribeDataGridViewControlsToGenericEvents()
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

        private void TeamsChassisHandlingOriginalValuesButton_Click(object sender, EventArgs e)
        {
            _controller.UpdateTeamsModelWithChassisHandlingValuesFromOriginalValues();
        }

        private void TeamsChassisHandlingRecommendedValuesButton_Click(object sender, EventArgs e)
        {
            _controller.UpdateTeamsModelWithChassisHandlingValuesFromRecommendedValues();
        }

        private void TeamsChassisHandlingCalculatedValuesButton_Click(object sender, EventArgs e)
        {
            _controller.UpdateTeamsModelWithChassisHandlingValuesFromRandomisedModifiedDesignCalculation();
        }

        // TODO: Review
        // TODO: Should be moved to common form
        // TODO: May now be redundant as values are retreived via dataSource rather than cells.
        private static int GetDataGridCellValue(DataGridView dataGridView, string columnName, int rowIndex)
        {
            int tryParseResult;
            if (!int.TryParse(dataGridView.Rows[rowIndex].Cells[columnName].Value.ToString(), out tryParseResult))
            {
                throw new Exception("Unable to parse value to the required type.");
            }
            return tryParseResult;
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

        public string[] GetRichTextBoxLines()
        {
            return OverviewRichTextBox.Lines;
        }

        public void SetRichTextBoxRichText(string text)
        {
            OverviewRichTextBox.Rtf = text;
        }

        public void UpdateTeamsModelWithUpdatedChassisHandlingValues(IEnumerable<TeamModel> teams)
        {
            if (teams == null) throw new ArgumentNullException(nameof(teams));

            var teamModel = teams.ToList();
            var values = new int[teamModel.Count()];

            for (var i = 0; i < teamModel.Count; i++)
            {
                values[i] = teamModel.Single(x => x.Id == i).ChassisHandling;
            }

            UpdateValuesInDataGridViewColumn(TeamsDataGridView, "ChassisHandling", values);
        }
    }
}