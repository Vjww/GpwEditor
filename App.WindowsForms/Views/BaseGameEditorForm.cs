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

        private const string SponsorsFiaIdToolTipText = "The id of the FIA sponsor record.";
        private const string SponsorsFiaNameToolTipText = "The name of the team receiving the sponsorship." + ReadOnlyToolTipText;
        private const string SponsorsFiaCashToolTipText = "The cash value of the sponsorship.";

        private const string SponsorsTeamIdToolTipText = "The id of the team sponsor record.";
        private const string SponsorsTeamNameToolTipText = "The name of the team sponsor." + ReadOnlyToolTipText;
        private const string SponsorsTeamCashRatingToolTipText = "The cash rating of the team sponsor.";

        private const string SponsorsEngineIdToolTipText = "The id of the engine supplier record.";
        private const string SponsorsEngineNameToolTipText = "The name of the engine supplier." + ReadOnlyToolTipText;
        private const string SponsorsEngineCashRatingToolTipText = "The cash rating of the engine supplier.";
        private const string SponsorsEngineRadRatingToolTipText = "The research and design rating of the engine supplier.";
        private const string SponsorsEngineFuelToolTipText = "The fuel rating of the engine.";
        private const string SponsorsEngineHeatToolTipText = "The heat rating of the engine.";
        private const string SponsorsEnginePowerToolTipText = "The power rating of the engine.";
        private const string SponsorsEngineReliabilityToolTipText = "The reliability rating of the engine.";
        private const string SponsorsEngineResponseToolTipText = "The response rating of the engine.";
        private const string SponsorsEngineRigidityToolTipText = "The rigidity rating of the engine.";
        private const string SponsorsEngineWeightToolTipText = "The weight rating of the engine.";

        private const string SponsorsTyreIdToolTipText = "The id of the tyre supplier record.";
        private const string SponsorsTyreNameToolTipText = "The name of the tyre supplier." + ReadOnlyToolTipText;
        private const string SponsorsTyreCashRatingToolTipText = "The cash rating of the tyre supplier.";
        private const string SponsorsTyreRadRatingToolTipText = "The research and design rating of the tyre supplier.";
        private const string SponsorsTyreDryHardGripToolTipText = "The grip rating of the dry hard tyre.";
        private const string SponsorsTyreDryHardResilienceToolTipText = "The resilience rating of the dry hard tyre.";
        private const string SponsorsTyreDryHardStiffnessToolTipText = "The stiffness rating of the dry hard tyre.";
        private const string SponsorsTyreDryHardTemperatureToolTipText = "The temperature rating of the dry hard tyre.";
        private const string SponsorsTyreDrySoftGripToolTipText = "The grip rating of the dry soft tyre.";
        private const string SponsorsTyreDrySoftResilienceToolTipText = "The resilience rating of the dry soft tyre.";
        private const string SponsorsTyreDrySoftStiffnessToolTipText = "The stiffness rating of the dry soft tyre.";
        private const string SponsorsTyreDrySoftTemperatureToolTipText = "The temperature rating of the dry soft tyre.";
        private const string SponsorsTyreIntermediateGripToolTipText = "The grip rating of the intermediate tyre.";
        private const string SponsorsTyreIntermediateResilienceToolTipText = "The resilience rating of the intermediate tyre.";
        private const string SponsorsTyreIntermediateStiffnessToolTipText = "The stiffness rating of the intermediate tyre.";
        private const string SponsorsTyreIntermediateTemperatureToolTipText = "The temperature rating of the intermediate tyre.";
        private const string SponsorsTyreWetWeatherGripToolTipText = "The grip rating of the wet weather tyre.";
        private const string SponsorsTyreWetWeatherResilienceToolTipText = "The resilience rating of the wet weather tyre.";
        private const string SponsorsTyreWetWeatherStiffnessToolTipText = "The stiffness rating of the wet weather tyre.";
        private const string SponsorsTyreWetWeatherTemperatureToolTipText = "The temperature rating of the wet weather tyre.";

        private const string SponsorsFuelIdToolTipText = "The id of the fuel supplier record.";
        private const string SponsorsFuelNameToolTipText = "The name of the fuel supplier." + ReadOnlyToolTipText;
        private const string SponsorsFuelCashRatingToolTipText = "The cash rating of the fuel supplier.";
        private const string SponsorsFuelRadRatingToolTipText = "The research and design rating of the fuel supplier.";
        private const string SponsorsFuelPerformanceToolTipText = "The performance rating of the fuel.";
        private const string SponsorsFuelToleranceToolTipText = "The tolerance rating of the fuel.";

        private const string SponsorsCashIdToolTipText = "The id of the cash sponsor record.";
        private const string SponsorsCashNameToolTipText = "The name of the cash sponsor." + ReadOnlyToolTipText;
        private const string SponsorsCashCashRatingToolTipText = "The cash rating of the cash sponsor.";

        private const string SponsorsContractIdToolTipText = "The id of the sponsor contract record.";
        private const string SponsorsContractSlotTypeIdToolTipText = "The id of the type of sponsorship offered." + ReadOnlyToolTipText;
        private const string SponsorsContractSlotDescriptionToolTipText = "The type of sponsorship offered." + ReadOnlyToolTipText;
        private const string SponsorsContractSponsorIdToolTipText = "The name of the sponsor/supplier that holds the contract.";
        private const string SponsorsContractCashToolTipText = "The cash value of the contract. Suppliers can have a positive or negative cash value.";
        private const string SponsorsContractDealIdToolTipText = "The agreed deal of the supplier contract.";
        private const string SponsorsContractTermsIdToolTipText = "The agreed terms of the supplier contract.";

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
        public IEnumerable<SponsorNameLookupModel> SponsorNameLookups { get; set; }
        public IEnumerable<SponsorDealLookupModel> SponsorDealLookups { get; set; }
        public IEnumerable<SponsorTermsLookupModel> SponsorTermsLookups { get; set; }
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

        public IEnumerable<SponsorFiaModel> SponsorFias
        {
            get => (IEnumerable<SponsorFiaModel>)SponsorsFiaDataGridView.DataSource;
            set => BuildSponsorsFiaDataGridView(value);
        }

        public IEnumerable<SponsorModel> SponsorTeams
        {
            get => (IEnumerable<SponsorModel>)SponsorsTeamDataGridView.DataSource;
            set => BuildSponsorsTeamDataGridView(value);
        }

        public IEnumerable<SponsorModel> SponsorEngines
        {
            get => (IEnumerable<SponsorModel>)SponsorsEngineDataGridView.DataSource;
            set => BuildSponsorsEngineDataGridView(value);
        }

        public IEnumerable<SponsorModel> SponsorTyres
        {
            get => (IEnumerable<SponsorModel>)SponsorsTyreDataGridView.DataSource;
            set => BuildSponsorsTyreDataGridView(value);
        }

        public IEnumerable<SponsorModel> SponsorFuels
        {
            get => (IEnumerable<SponsorModel>)SponsorsFuelDataGridView.DataSource;
            set => BuildSponsorsFuelDataGridView(value);
        }

        public IEnumerable<SponsorModel> SponsorCashs
        {
            get => (IEnumerable<SponsorModel>)SponsorsCashDataGridView.DataSource;
            set => BuildSponsorsCashDataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam01
        {
            get => (IEnumerable<SponsorContractModel>)SponsorsContractTeam01DataGridView.DataSource;
            set => BuildSponsorsContractTeam01DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam02
        {
            get => (IEnumerable<SponsorContractModel>)SponsorsContractTeam02DataGridView.DataSource;
            set => BuildSponsorsContractTeam02DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam03
        {
            get => (IEnumerable<SponsorContractModel>)SponsorsContractTeam03DataGridView.DataSource;
            set => BuildSponsorsContractTeam03DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam04
        {
            get => (IEnumerable<SponsorContractModel>)SponsorsContractTeam04DataGridView.DataSource;
            set => BuildSponsorsContractTeam04DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam05
        {
            get => (IEnumerable<SponsorContractModel>)SponsorsContractTeam05DataGridView.DataSource;
            set => BuildSponsorsContractTeam05DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam06
        {
            get => (IEnumerable<SponsorContractModel>)SponsorsContractTeam06DataGridView.DataSource;
            set => BuildSponsorsContractTeam06DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam07
        {
            get => (IEnumerable<SponsorContractModel>)SponsorsContractTeam07DataGridView.DataSource;
            set => BuildSponsorsContractTeam07DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam08
        {
            get => (IEnumerable<SponsorContractModel>)SponsorsContractTeam08DataGridView.DataSource;
            set => BuildSponsorsContractTeam08DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam09
        {
            get => (IEnumerable<SponsorContractModel>)SponsorsContractTeam09DataGridView.DataSource;
            set => BuildSponsorsContractTeam09DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam10
        {
            get => (IEnumerable<SponsorContractModel>)SponsorsContractTeam10DataGridView.DataSource;
            set => BuildSponsorsContractTeam10DataGridView(value);
        }

        public IEnumerable<SponsorContractModel> SponsorContractsTeam11
        {
            get => (IEnumerable<SponsorContractModel>)SponsorsContractTeam11DataGridView.DataSource;
            set => BuildSponsorsContractTeam11DataGridView(value);
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

        private void BuildSponsorsFiaDataGridView(IEnumerable<SponsorFiaModel> dataSource)
        {
            ResetDataGridView(SponsorsFiaDataGridView);

            AddColumnToDataGridView(SponsorsFiaDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SponsorsFiaIdToolTipText, false));
            AddColumnToDataGridView(SponsorsFiaDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SponsorsFiaNameToolTipText, true, true));
            AddColumnToDataGridView(SponsorsFiaDataGridView, CreateDataGridViewTextBoxColumn("Cash", "Cash", SponsorsFiaCashToolTipText));

            BindDataGridViewToDataSource(SponsorsFiaDataGridView, dataSource);

            ConfigureDataGridView(SponsorsFiaDataGridView, "Name");
        }

        private void BuildSponsorsTeamDataGridView(IEnumerable<SponsorModel> dataSource)
        {
            ResetDataGridView(SponsorsTeamDataGridView);

            AddColumnToDataGridView(SponsorsTeamDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SponsorsTeamIdToolTipText, false));
            AddColumnToDataGridView(SponsorsTeamDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SponsorsTeamNameToolTipText, true, true));
            AddColumnToDataGridView(SponsorsTeamDataGridView, CreateDataGridViewTextBoxColumn("SponsorId", "Sponsor Id", ""));
            AddColumnToDataGridView(SponsorsTeamDataGridView, CreateDataGridViewTextBoxColumn("SponsorTypeId", "Sponsor Type", ""));
            AddColumnToDataGridView(SponsorsTeamDataGridView, CreateDataGridViewTextBoxColumn("EntityTypeId", "Entity Type", ""));
            AddColumnToDataGridView(SponsorsTeamDataGridView, CreateDataGridViewTextBoxColumn("EntityResource", "Entity Resource", ""));
            AddColumnToDataGridView(SponsorsTeamDataGridView, CreateDataGridViewTextBoxColumn("EntityData", "Entity Data", ""));
            AddColumnToDataGridView(SponsorsTeamDataGridView, CreateDataGridViewTextBoxColumn("CashRating", "Cash Rating", SponsorsTeamCashRatingToolTipText));

            BindDataGridViewToDataSource(SponsorsTeamDataGridView, dataSource);

            ConfigureDataGridView(SponsorsTeamDataGridView, "Name");
        }

        private void BuildSponsorsEngineDataGridView(IEnumerable<SponsorModel> dataSource)
        {
            ResetDataGridView(SponsorsEngineDataGridView);

            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SponsorsEngineIdToolTipText, false));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SponsorsEngineNameToolTipText, true, true));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("SponsorId", "Sponsor Id", ""));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("SponsorTypeId", "Sponsor Type", ""));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("EntityTypeId", "Entity Type", ""));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("EntityResource", "Entity Resource", ""));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("EntityData", "Entity Data", ""));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("CashRating", "Cash Rating", SponsorsEngineCashRatingToolTipText));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewCheckBoxColumn("CashRatingRandom", "Random Cash Rating", ""));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("RadRating", "R&D Rating", SponsorsEngineRadRatingToolTipText));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewCheckBoxColumn("RadRatingRandom", "Random R&D Rating", ""));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewCheckBoxColumn("Inactive", "Inactive", ""));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("Fuel", "Fuel", SponsorsEngineFuelToolTipText));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("Heat", "Heat", SponsorsEngineHeatToolTipText));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("Power", "Power", SponsorsEnginePowerToolTipText));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("Reliability", "Reliability", SponsorsEngineReliabilityToolTipText));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("Response", "Response", SponsorsEngineResponseToolTipText));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("Rigidity", "Rigidity", SponsorsEngineRigidityToolTipText));
            AddColumnToDataGridView(SponsorsEngineDataGridView, CreateDataGridViewTextBoxColumn("Weight", "Weight", SponsorsEngineWeightToolTipText));

            BindDataGridViewToDataSource(SponsorsEngineDataGridView, dataSource);

            ConfigureDataGridView(SponsorsEngineDataGridView, "Name");
        }

        private void BuildSponsorsTyreDataGridView(IEnumerable<SponsorModel> dataSource)
        {
            ResetDataGridView(SponsorsTyreDataGridView);

            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SponsorsTyreIdToolTipText, false));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SponsorsTyreNameToolTipText, true, true));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("SponsorId", "Sponsor Id", ""));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("SponsorTypeId", "Sponsor Type", ""));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("EntityTypeId", "Entity Type", ""));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("EntityResource", "Entity Resource", ""));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("EntityData", "Entity Data", ""));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("CashRating", "Cash Rating", SponsorsTyreCashRatingToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewCheckBoxColumn("CashRatingRandom", "Random Cash Rating", ""));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("RadRating", "R&D Rating", SponsorsTyreRadRatingToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewCheckBoxColumn("RadRatingRandom", "Random R&D Rating", ""));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewCheckBoxColumn("Inactive", "Inactive", ""));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("DryHardGrip", "Dry Hard Grip", SponsorsTyreDryHardGripToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("DryHardResilience", "Dry Hard Resilience", SponsorsTyreDryHardResilienceToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("DryHardStiffness", "Dry Hard Stiffness", SponsorsTyreDryHardStiffnessToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("DryHardTemperature", "Dry Hard Temperature", SponsorsTyreDryHardTemperatureToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("DrySoftGrip", "Dry Soft Grip", SponsorsTyreDrySoftGripToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("DrySoftResilience", "Dry Soft Resilience", SponsorsTyreDrySoftResilienceToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("DrySoftStiffness", "Dry Soft Stiffness", SponsorsTyreDrySoftStiffnessToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("DrySoftTemperature", "Dry Soft Temperature", SponsorsTyreDrySoftTemperatureToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("IntermediateGrip", "Intermediate Grip", SponsorsTyreIntermediateGripToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("IntermediateResilience", "Intermediate Resilience", SponsorsTyreIntermediateResilienceToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("IntermediateStiffness", "Intermediate Stiffness", SponsorsTyreIntermediateStiffnessToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("IntermediateTemperature", "Intermediate Temperature", SponsorsTyreIntermediateTemperatureToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("WetWeatherGrip", "Wet Weather Grip", SponsorsTyreWetWeatherGripToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("WetWeatherResilience", "Wet Weather Resilience", SponsorsTyreWetWeatherResilienceToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("WetWeatherStiffness", "Wet Weather Stiffness", SponsorsTyreWetWeatherStiffnessToolTipText));
            AddColumnToDataGridView(SponsorsTyreDataGridView, CreateDataGridViewTextBoxColumn("WetWeatherTemperature", "Wet Weather Temperature", SponsorsTyreWetWeatherTemperatureToolTipText));

            BindDataGridViewToDataSource(SponsorsTyreDataGridView, dataSource);

            ConfigureDataGridView(SponsorsTyreDataGridView, "Name");
        }

        private void BuildSponsorsFuelDataGridView(IEnumerable<SponsorModel> dataSource)
        {
            ResetDataGridView(SponsorsFuelDataGridView);

            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SponsorsFuelIdToolTipText, false));
            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SponsorsFuelNameToolTipText, true, true));
            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewTextBoxColumn("SponsorId", "Sponsor Id", ""));
            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewTextBoxColumn("SponsorTypeId", "Sponsor Type", ""));
            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewTextBoxColumn("EntityTypeId", "Entity Type", ""));
            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewTextBoxColumn("EntityResource", "Entity Resource", ""));
            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewTextBoxColumn("EntityData", "Entity Data", ""));
            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewTextBoxColumn("CashRating", "Cash Rating", SponsorsFuelCashRatingToolTipText));
            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewCheckBoxColumn("CashRatingRandom", "Random Cash Rating", ""));
            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewTextBoxColumn("RadRating", "R&D Rating", SponsorsFuelRadRatingToolTipText));
            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewCheckBoxColumn("RadRatingRandom", "Random R&D Rating", ""));
            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewCheckBoxColumn("Inactive", "Inactive", ""));
            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewTextBoxColumn("Performance", "Performance", SponsorsFuelPerformanceToolTipText));
            AddColumnToDataGridView(SponsorsFuelDataGridView, CreateDataGridViewTextBoxColumn("Tolerance", "Tolerance", SponsorsFuelToleranceToolTipText));

            BindDataGridViewToDataSource(SponsorsFuelDataGridView, dataSource);

            ConfigureDataGridView(SponsorsFuelDataGridView, "Name");
        }

        private void BuildSponsorsCashDataGridView(IEnumerable<SponsorModel> dataSource)
        {
            ResetDataGridView(SponsorsCashDataGridView);

            AddColumnToDataGridView(SponsorsCashDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SponsorsCashIdToolTipText, false));
            AddColumnToDataGridView(SponsorsCashDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", SponsorsCashNameToolTipText, true, true));
            AddColumnToDataGridView(SponsorsCashDataGridView, CreateDataGridViewTextBoxColumn("SponsorId", "Sponsor Id", ""));
            AddColumnToDataGridView(SponsorsCashDataGridView, CreateDataGridViewTextBoxColumn("SponsorTypeId", "Sponsor Type", ""));
            AddColumnToDataGridView(SponsorsCashDataGridView, CreateDataGridViewTextBoxColumn("EntityTypeId", "Entity Type", ""));
            AddColumnToDataGridView(SponsorsCashDataGridView, CreateDataGridViewTextBoxColumn("EntityResource", "Entity Resource", ""));
            AddColumnToDataGridView(SponsorsCashDataGridView, CreateDataGridViewTextBoxColumn("EntityData", "Entity Data", ""));
            AddColumnToDataGridView(SponsorsCashDataGridView, CreateDataGridViewTextBoxColumn("CashRating", "Cash Rating", SponsorsCashCashRatingToolTipText));

            BindDataGridViewToDataSource(SponsorsCashDataGridView, dataSource);

            ConfigureDataGridView(SponsorsCashDataGridView, "Name");
        }

        private void BuildSponsorsContractTeam01DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorsContractDataGridView(SponsorsContractTeam01DataGridView, dataSource);
        }

        private void BuildSponsorsContractTeam02DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorsContractDataGridView(SponsorsContractTeam02DataGridView, dataSource);
        }

        private void BuildSponsorsContractTeam03DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorsContractDataGridView(SponsorsContractTeam03DataGridView, dataSource);
        }

        private void BuildSponsorsContractTeam04DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorsContractDataGridView(SponsorsContractTeam04DataGridView, dataSource);
        }

        private void BuildSponsorsContractTeam05DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorsContractDataGridView(SponsorsContractTeam05DataGridView, dataSource);
        }

        private void BuildSponsorsContractTeam06DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorsContractDataGridView(SponsorsContractTeam06DataGridView, dataSource);
        }

        private void BuildSponsorsContractTeam07DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorsContractDataGridView(SponsorsContractTeam07DataGridView, dataSource);
        }

        private void BuildSponsorsContractTeam08DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorsContractDataGridView(SponsorsContractTeam08DataGridView, dataSource);
        }

        private void BuildSponsorsContractTeam09DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorsContractDataGridView(SponsorsContractTeam09DataGridView, dataSource);
        }

        private void BuildSponsorsContractTeam10DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorsContractDataGridView(SponsorsContractTeam10DataGridView, dataSource);
        }

        private void BuildSponsorsContractTeam11DataGridView(IEnumerable<SponsorContractModel> dataSource)
        {
            BuildSponsorsContractDataGridView(SponsorsContractTeam11DataGridView, dataSource);
        }

        private void BuildSponsorsContractDataGridView(DataGridView dataGridView, IEnumerable<SponsorContractModel> dataSource)
        {
            ResetDataGridView(dataGridView);

            AddColumnToDataGridView(dataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", SponsorsContractIdToolTipText, false));
            AddColumnToDataGridView(dataGridView, CreateDataGridViewTextBoxColumn("SlotTypeId", "SlotTypeId", SponsorsContractSlotTypeIdToolTipText, false, true));
            AddColumnToDataGridView(dataGridView, CreateDataGridViewTextBoxColumn("SlotDescription", "Slot", SponsorsContractSlotDescriptionToolTipText, true, true));
            AddColumnToDataGridView(dataGridView, CreateDataGridViewComboBoxColumn("SponsorId", "Sponsor", SponsorsContractSponsorIdToolTipText));
            AddColumnToDataGridView(dataGridView, CreateDataGridViewTextBoxColumn("Cash", "Cash", SponsorsContractCashToolTipText));
            AddColumnToDataGridView(dataGridView, CreateDataGridViewComboBoxColumn("DealId", "Deal", SponsorsContractDealIdToolTipText));
            AddColumnToDataGridView(dataGridView, CreateDataGridViewComboBoxColumn("TermsId", "Terms", SponsorsContractTermsIdToolTipText));

            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)dataGridView.Columns["SponsorId"], SponsorNameLookups);
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)dataGridView.Columns["DealId"], SponsorDealLookups);
            BindDataGridViewComboBoxColumnToDataSource((DataGridViewComboBoxColumn)dataGridView.Columns["TermsId"], SponsorTermsLookups);
            BindDataGridViewToDataSource(dataGridView, dataSource);

            ConfigureDataGridView(dataGridView, "SlotDescription");
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
            UpdateSponsorContractTabsWithTeamNames();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            _controller.Export();
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
                // If combobox cell
                if (dataGridView[e.ColumnIndex, e.RowIndex] is DataGridViewComboBoxCell)
                {
                    // Drop down the drop down
                    dataGridView.BeginEdit(true);
                    ((ComboBox)dataGridView.EditingControl).DroppedDown = true;
                }
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

        private void UpdateSponsorContractTabsWithTeamNames()
        {
            SponsorsContractTeam01TabPage.Text = Teams.SingleOrDefault(x => x.Id == 0)?.Name;
            SponsorsContractTeam02TabPage.Text = Teams.SingleOrDefault(x => x.Id == 1)?.Name;
            SponsorsContractTeam03TabPage.Text = Teams.SingleOrDefault(x => x.Id == 2)?.Name;
            SponsorsContractTeam04TabPage.Text = Teams.SingleOrDefault(x => x.Id == 3)?.Name;
            SponsorsContractTeam05TabPage.Text = Teams.SingleOrDefault(x => x.Id == 4)?.Name;
            SponsorsContractTeam06TabPage.Text = Teams.SingleOrDefault(x => x.Id == 5)?.Name;
            SponsorsContractTeam07TabPage.Text = Teams.SingleOrDefault(x => x.Id == 6)?.Name;
            SponsorsContractTeam08TabPage.Text = Teams.SingleOrDefault(x => x.Id == 7)?.Name;
            SponsorsContractTeam09TabPage.Text = Teams.SingleOrDefault(x => x.Id == 8)?.Name;
            SponsorsContractTeam10TabPage.Text = Teams.SingleOrDefault(x => x.Id == 9)?.Name;
            SponsorsContractTeam11TabPage.Text = Teams.SingleOrDefault(x => x.Id == 10)?.Name;

            SponsorsContractTeam01GroupBox.Text = $"{SponsorsContractTeam01TabPage.Text} - Options";
            SponsorsContractTeam02GroupBox.Text = $"{SponsorsContractTeam02TabPage.Text} - Options";
            SponsorsContractTeam03GroupBox.Text = $"{SponsorsContractTeam03TabPage.Text} - Options";
            SponsorsContractTeam04GroupBox.Text = $"{SponsorsContractTeam04TabPage.Text} - Options";
            SponsorsContractTeam05GroupBox.Text = $"{SponsorsContractTeam05TabPage.Text} - Options";
            SponsorsContractTeam06GroupBox.Text = $"{SponsorsContractTeam06TabPage.Text} - Options";
            SponsorsContractTeam07GroupBox.Text = $"{SponsorsContractTeam07TabPage.Text} - Options";
            SponsorsContractTeam08GroupBox.Text = $"{SponsorsContractTeam08TabPage.Text} - Options";
            SponsorsContractTeam09GroupBox.Text = $"{SponsorsContractTeam09TabPage.Text} - Options";
            SponsorsContractTeam10GroupBox.Text = $"{SponsorsContractTeam10TabPage.Text} - Options";
            SponsorsContractTeam11GroupBox.Text = $"{SponsorsContractTeam11TabPage.Text} - Options";
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

        private void SponsorsContractDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (!(sender is DataGridView dataGridView)) return;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // If row is for a non-supplier
                var slotTypeId = (int)row.Cells["SlotTypeId"].Value;
                if (slotTypeId != 2 && slotTypeId != 3 && slotTypeId != 4)
                {
                    // Change DealId cell from ComboBoxCell to TextBoxCell and set to readonly
                    row.Cells["DealId"] = new DataGridViewTextBoxCell();
                    row.Cells["DealId"].ReadOnly = true;

                    // Change TermsId cell from ComboBoxCell to TextBoxCell and set to readonly
                    row.Cells["TermsId"] = new DataGridViewTextBoxCell();
                    row.Cells["TermsId"].ReadOnly = true;
                }
            }
        }

        private void SponsorsContractDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (!(sender is DataGridView dataGridView)) return;

            // If cell is in the DealId or TermsId columns
            if (dataGridView.Columns["DealId"] != null && e.ColumnIndex == dataGridView.Columns["DealId"].Index ||
               dataGridView.Columns["TermsId"] != null && e.ColumnIndex == dataGridView.Columns["TermsId"].Index)
            {
                // If row is for a non-supplier
                var slotTypeId = (int)dataGridView["SlotTypeId", e.RowIndex].Value;
                if (slotTypeId != 2 && slotTypeId != 3 && slotTypeId != 4)
                {
                    // Format cell to not show data
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}