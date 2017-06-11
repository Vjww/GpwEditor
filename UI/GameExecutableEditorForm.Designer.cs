using Data.Collections.Executable.Supplier;
using Data.Collections.Executable.Team;
using Data.Collections.Generic;
using Data.Collections.Language;
using Data.Entities.Executable.Track;

namespace GpwEditor
{
    partial class GameExecutableEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.HomeTabPage = new System.Windows.Forms.TabPage();
            this.CloseButton = new System.Windows.Forms.Button();
            this.FilesGroupBox = new System.Windows.Forms.GroupBox();
            this.BrowseGameExecutableButton = new System.Windows.Forms.Button();
            this.BrowseLanguageFileButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.GameExecutablePathLabel = new System.Windows.Forms.Label();
            this.LanguageFilePathLabel = new System.Windows.Forms.Label();
            this.GameExecutablePathTextBox = new System.Windows.Forms.TextBox();
            this.LanguageFilePathTextBox = new System.Windows.Forms.TextBox();
            this.LanguageDataGridView = new System.Windows.Forms.DataGridView();
            this.TeamsTabPage = new System.Windows.Forms.TabPage();
            this.TeamsDataGridView = new System.Windows.Forms.DataGridView();
            this.DriversTabPage = new System.Windows.Forms.TabPage();
            this.DriversDataGridView = new System.Windows.Forms.DataGridView();
            this.EnginesTabPage = new System.Windows.Forms.TabPage();
            this.EnginesDataGridView = new System.Windows.Forms.DataGridView();
            this.TyresTabPage = new System.Windows.Forms.TabPage();
            this.TyresDataGridView = new System.Windows.Forms.DataGridView();
            this.FuelsTabPage = new System.Windows.Forms.TabPage();
            this.FuelsDataGridView = new System.Windows.Forms.DataGridView();
            this.TracksTabPage = new System.Windows.Forms.TabPage();
            this.TracksDataGridView = new System.Windows.Forms.DataGridView();
            this.RacePerformanceTabPage = new System.Windows.Forms.TabPage();
            this.RacePerformanceGroupBox = new System.Windows.Forms.GroupBox();
            this.RacePerformanceCopyRecommendedButton = new System.Windows.Forms.Button();
            this.RacePerformanceProposedCheckBox = new System.Windows.Forms.CheckBox();
            this.RacePerformanceChartBox000NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RacePerformanceCurrentCheckBox = new System.Windows.Forms.CheckBox();
            this.RacePerformanceDefaultCheckBox = new System.Windows.Forms.CheckBox();
            this.RacePerformanceEditButton = new System.Windows.Forms.Button();
            this.RacePerformanceCopyCurrentButton = new System.Windows.Forms.Button();
            this.RacePerformanceCopyDefaultButton = new System.Windows.Forms.Button();
            this.RacePerformanceChartBox120NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RacePerformanceSoftenCurveButton = new System.Windows.Forms.Button();
            this.RacePerformanceChartBox070NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RacePerformanceChartBox060NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RacePerformanceChartBox020NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RacePerformanceChartBox040NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RacePerformanceChartBox080NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RacePerformanceChartBox030NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RacePerformanceChartBox090NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RacePerformanceChartBox050NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RacePerformanceChartBox100NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RacePerformanceChartBox010NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RacePerformanceChartBox110NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RacePerformanceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MiscTabPage = new System.Windows.Forms.TabPage();
            this.TestingMilesDataGridView = new System.Windows.Forms.DataGridView();
            this.StaffSalariesDataGridView = new System.Windows.Forms.DataGridView();
            this.FactoryExpansionCostsDataGridView = new System.Windows.Forms.DataGridView();
            this.FactoryRunningCostsDataGridView = new System.Windows.Forms.DataGridView();
            this.EngineeringTabPage = new System.Windows.Forms.TabPage();
            this.UnknownBDataGridView = new System.Windows.Forms.DataGridView();
            this.UnknownADataGridView = new System.Windows.Forms.DataGridView();
            this.EngineeringCostsDataGridView = new System.Windows.Forms.DataGridView();
            this.StaffEffortsDataGridView = new System.Windows.Forms.DataGridView();
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ProgramOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.NonF1DriversDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identityCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastPositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastPointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstGpTrackDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.firstGpYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearlyBudgetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unknownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryMapIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationPointerXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationPointerYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tyreSupplierIdDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.teamCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raceBonusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.championshipBonusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payRatingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positiveSalaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastChampionshipPositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverRoleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nationalityDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.careerChampionshipsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.careerRacesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.careerWinsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.careerPointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.careerFastestLapsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.careerPointsFinishesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.careerPolePositionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skillDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overtakingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wetWeatherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concentrationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experienceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staminaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moraleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.powerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reliabilityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rigidityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.engineCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dryHardGripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dryHardResilienceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dryHardStiffnessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dryHardTemperatureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drySoftGripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drySoftResilienceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drySoftStiffnessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.drySoftTemperatureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intermediateGripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intermediateResilienceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intermediateStiffnessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intermediateTemperatureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wetWeatherGripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wetWeatherResilienceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wetWeatherStiffnessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wetWeatherTemperatureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tyreCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toleranceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuelCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lapsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lapRecordDriverDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lapRecordTeamDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lapRecordTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lapRecordMphDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lapRecordYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastRaceDriverDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lastRaceTeamDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lastRaceYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastRaceTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hospitalityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speedDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surfaceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarmacDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dustDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overtakingDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brakingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heatDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.windDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value01DataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value02DataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value03DataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value04DataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value05DataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value06DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value07DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value08DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value09DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value10DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenValueCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value01DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value02DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value03DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value04DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value05DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fiveRatingCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value01DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value02DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value03DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value04DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value05DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value01DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value02DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value03DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value04DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value05DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fiveValueCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.singleValueCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value01DataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value02DataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value03DataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value04DataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value05DataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value06DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value07DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value08DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value09DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value10DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value01DataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value02DataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value03DataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value04DataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value05DataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salaryDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raceBonusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.championshipBonusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nationalityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unknownDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speedDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skillDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.overtakingDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wetWeatherDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concentrationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experienceDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staminaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moraleDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nonF1DriverCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.NonF1ChiefsDataGridView = new System.Windows.Forms.DataGridView();
            this.nonF1ChiefCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salaryDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.raceBonusDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.championshipBonusDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.royaltyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ageDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abilityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainTabControl.SuspendLayout();
            this.HomeTabPage.SuspendLayout();
            this.FilesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LanguageDataGridView)).BeginInit();
            this.TeamsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamsDataGridView)).BeginInit();
            this.DriversTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DriversDataGridView)).BeginInit();
            this.EnginesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnginesDataGridView)).BeginInit();
            this.TyresTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TyresDataGridView)).BeginInit();
            this.FuelsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FuelsDataGridView)).BeginInit();
            this.TracksTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TracksDataGridView)).BeginInit();
            this.RacePerformanceTabPage.SuspendLayout();
            this.RacePerformanceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox000NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox120NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox070NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox060NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox020NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox040NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox080NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox030NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox090NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox050NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox100NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox010NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox110NumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChart)).BeginInit();
            this.MiscTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestingMilesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaffSalariesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactoryExpansionCostsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactoryRunningCostsDataGridView)).BeginInit();
            this.EngineeringTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnknownBDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnknownADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EngineeringCostsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaffEffortsDataGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NonF1DriversDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.identityCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tyreCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenValueCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiveRatingCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiveValueCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleValueCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonF1DriverCollectionBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NonF1ChiefsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonF1ChiefCollectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.HomeTabPage);
            this.MainTabControl.Controls.Add(this.TeamsTabPage);
            this.MainTabControl.Controls.Add(this.DriversTabPage);
            this.MainTabControl.Controls.Add(this.EnginesTabPage);
            this.MainTabControl.Controls.Add(this.TyresTabPage);
            this.MainTabControl.Controls.Add(this.FuelsTabPage);
            this.MainTabControl.Controls.Add(this.TracksTabPage);
            this.MainTabControl.Controls.Add(this.RacePerformanceTabPage);
            this.MainTabControl.Controls.Add(this.MiscTabPage);
            this.MainTabControl.Controls.Add(this.EngineeringTabPage);
            this.MainTabControl.Controls.Add(this.tabPage1);
            this.MainTabControl.Controls.Add(this.tabPage2);
            this.MainTabControl.Location = new System.Drawing.Point(8, 8);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(696, 496);
            this.MainTabControl.TabIndex = 1;
            this.MainTabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.MainTabControl_Selecting);
            // 
            // HomeTabPage
            // 
            this.HomeTabPage.Controls.Add(this.CloseButton);
            this.HomeTabPage.Controls.Add(this.FilesGroupBox);
            this.HomeTabPage.Controls.Add(this.LanguageDataGridView);
            this.HomeTabPage.Location = new System.Drawing.Point(4, 22);
            this.HomeTabPage.Name = "HomeTabPage";
            this.HomeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HomeTabPage.Size = new System.Drawing.Size(688, 470);
            this.HomeTabPage.TabIndex = 0;
            this.HomeTabPage.Text = "Home";
            this.HomeTabPage.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(607, 441);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // FilesGroupBox
            // 
            this.FilesGroupBox.Controls.Add(this.BrowseGameExecutableButton);
            this.FilesGroupBox.Controls.Add(this.BrowseLanguageFileButton);
            this.FilesGroupBox.Controls.Add(this.ExportButton);
            this.FilesGroupBox.Controls.Add(this.ImportButton);
            this.FilesGroupBox.Controls.Add(this.GameExecutablePathLabel);
            this.FilesGroupBox.Controls.Add(this.LanguageFilePathLabel);
            this.FilesGroupBox.Controls.Add(this.GameExecutablePathTextBox);
            this.FilesGroupBox.Controls.Add(this.LanguageFilePathTextBox);
            this.FilesGroupBox.Location = new System.Drawing.Point(6, 6);
            this.FilesGroupBox.Name = "FilesGroupBox";
            this.FilesGroupBox.Size = new System.Drawing.Size(676, 71);
            this.FilesGroupBox.TabIndex = 0;
            this.FilesGroupBox.TabStop = false;
            this.FilesGroupBox.Text = "Source/Target Files";
            // 
            // BrowseGameExecutableButton
            // 
            this.BrowseGameExecutableButton.Location = new System.Drawing.Point(514, 43);
            this.BrowseGameExecutableButton.Name = "BrowseGameExecutableButton";
            this.BrowseGameExecutableButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseGameExecutableButton.TabIndex = 3;
            this.BrowseGameExecutableButton.Text = "Browse...";
            this.BrowseGameExecutableButton.UseVisualStyleBackColor = true;
            this.BrowseGameExecutableButton.Click += new System.EventHandler(this.BrowseGameExecutableButton_Click);
            // 
            // BrowseLanguageFileButton
            // 
            this.BrowseLanguageFileButton.Location = new System.Drawing.Point(514, 17);
            this.BrowseLanguageFileButton.Name = "BrowseLanguageFileButton";
            this.BrowseLanguageFileButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseLanguageFileButton.TabIndex = 1;
            this.BrowseLanguageFileButton.Text = "Browse...";
            this.BrowseLanguageFileButton.UseVisualStyleBackColor = true;
            this.BrowseLanguageFileButton.Click += new System.EventHandler(this.BrowseLanguageFileButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(595, 43);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 5;
            this.ExportButton.Text = "Export...";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(595, 17);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(75, 23);
            this.ImportButton.TabIndex = 4;
            this.ImportButton.Text = "Import...";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // GameExecutablePathLabel
            // 
            this.GameExecutablePathLabel.AutoSize = true;
            this.GameExecutablePathLabel.Location = new System.Drawing.Point(6, 48);
            this.GameExecutablePathLabel.Name = "GameExecutablePathLabel";
            this.GameExecutablePathLabel.Size = new System.Drawing.Size(94, 13);
            this.GameExecutablePathLabel.TabIndex = 0;
            this.GameExecutablePathLabel.Text = "Game Executable:";
            // 
            // LanguageFilePathLabel
            // 
            this.LanguageFilePathLabel.AutoSize = true;
            this.LanguageFilePathLabel.Location = new System.Drawing.Point(23, 22);
            this.LanguageFilePathLabel.Name = "LanguageFilePathLabel";
            this.LanguageFilePathLabel.Size = new System.Drawing.Size(77, 13);
            this.LanguageFilePathLabel.TabIndex = 0;
            this.LanguageFilePathLabel.Text = "Language File:";
            // 
            // GameExecutablePathTextBox
            // 
            this.GameExecutablePathTextBox.Location = new System.Drawing.Point(106, 45);
            this.GameExecutablePathTextBox.Name = "GameExecutablePathTextBox";
            this.GameExecutablePathTextBox.ReadOnly = true;
            this.GameExecutablePathTextBox.Size = new System.Drawing.Size(402, 20);
            this.GameExecutablePathTextBox.TabIndex = 2;
            // 
            // LanguageFilePathTextBox
            // 
            this.LanguageFilePathTextBox.Location = new System.Drawing.Point(106, 19);
            this.LanguageFilePathTextBox.Name = "LanguageFilePathTextBox";
            this.LanguageFilePathTextBox.ReadOnly = true;
            this.LanguageFilePathTextBox.Size = new System.Drawing.Size(402, 20);
            this.LanguageFilePathTextBox.TabIndex = 0;
            // 
            // LanguageDataGridView
            // 
            this.LanguageDataGridView.AutoGenerateColumns = false;
            this.LanguageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LanguageDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.localResourceIdDataGridViewTextBoxColumn,
            this.resourceIdDataGridViewTextBoxColumn,
            this.resourceTextDataGridViewTextBoxColumn});
            this.LanguageDataGridView.DataSource = this.identityCollectionBindingSource;
            this.LanguageDataGridView.Location = new System.Drawing.Point(6, 388);
            this.LanguageDataGridView.Name = "LanguageDataGridView";
            this.LanguageDataGridView.Size = new System.Drawing.Size(676, 47);
            this.LanguageDataGridView.TabIndex = 0;
            this.LanguageDataGridView.TabStop = false;
            this.LanguageDataGridView.Visible = false;
            // 
            // TeamsTabPage
            // 
            this.TeamsTabPage.Controls.Add(this.TeamsDataGridView);
            this.TeamsTabPage.Location = new System.Drawing.Point(4, 22);
            this.TeamsTabPage.Name = "TeamsTabPage";
            this.TeamsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TeamsTabPage.Size = new System.Drawing.Size(688, 470);
            this.TeamsTabPage.TabIndex = 1;
            this.TeamsTabPage.Text = "Teams";
            this.TeamsTabPage.UseVisualStyleBackColor = true;
            // 
            // TeamsDataGridView
            // 
            this.TeamsDataGridView.AutoGenerateColumns = false;
            this.TeamsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeamsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.localResourceIdDataGridViewTextBoxColumn1,
            this.resourceIdDataGridViewTextBoxColumn1,
            this.resourceTextDataGridViewTextBoxColumn1,
            this.lastPositionDataGridViewTextBoxColumn,
            this.lastPointsDataGridViewTextBoxColumn,
            this.firstGpTrackDataGridViewComboBoxColumn,
            this.firstGpYearDataGridViewTextBoxColumn,
            this.winsDataGridViewTextBoxColumn,
            this.yearlyBudgetDataGridViewTextBoxColumn,
            this.unknownDataGridViewTextBoxColumn,
            this.countryMapIdDataGridViewTextBoxColumn,
            this.locationPointerXDataGridViewTextBoxColumn,
            this.locationPointerYDataGridViewTextBoxColumn,
            this.tyreSupplierIdDataGridViewComboBoxColumn});
            this.TeamsDataGridView.DataSource = this.teamCollectionBindingSource;
            this.TeamsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TeamsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.TeamsDataGridView.Name = "TeamsDataGridView";
            this.TeamsDataGridView.Size = new System.Drawing.Size(682, 464);
            this.TeamsDataGridView.TabIndex = 0;
            // 
            // DriversTabPage
            // 
            this.DriversTabPage.Controls.Add(this.DriversDataGridView);
            this.DriversTabPage.Location = new System.Drawing.Point(4, 22);
            this.DriversTabPage.Name = "DriversTabPage";
            this.DriversTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DriversTabPage.Size = new System.Drawing.Size(688, 470);
            this.DriversTabPage.TabIndex = 2;
            this.DriversTabPage.Text = "Drivers";
            this.DriversTabPage.UseVisualStyleBackColor = true;
            // 
            // DriversDataGridView
            // 
            this.DriversDataGridView.AutoGenerateColumns = false;
            this.DriversDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DriversDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn2,
            this.localResourceIdDataGridViewTextBoxColumn2,
            this.resourceIdDataGridViewTextBoxColumn2,
            this.resourceTextDataGridViewTextBoxColumn2,
            this.salaryDataGridViewTextBoxColumn,
            this.raceBonusDataGridViewTextBoxColumn,
            this.championshipBonusDataGridViewTextBoxColumn,
            this.payRatingDataGridViewTextBoxColumn,
            this.positiveSalaryDataGridViewTextBoxColumn,
            this.lastChampionshipPositionDataGridViewTextBoxColumn,
            this.driverRoleDataGridViewTextBoxColumn,
            this.carNumberDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn,
            this.nationalityDataGridViewComboBoxColumn,
            this.careerChampionshipsDataGridViewTextBoxColumn,
            this.careerRacesDataGridViewTextBoxColumn,
            this.careerWinsDataGridViewTextBoxColumn,
            this.careerPointsDataGridViewTextBoxColumn,
            this.careerFastestLapsDataGridViewTextBoxColumn,
            this.careerPointsFinishesDataGridViewTextBoxColumn,
            this.careerPolePositionsDataGridViewTextBoxColumn,
            this.speedDataGridViewTextBoxColumn,
            this.skillDataGridViewTextBoxColumn,
            this.overtakingDataGridViewTextBoxColumn,
            this.wetWeatherDataGridViewTextBoxColumn,
            this.concentrationDataGridViewTextBoxColumn,
            this.experienceDataGridViewTextBoxColumn,
            this.staminaDataGridViewTextBoxColumn,
            this.moraleDataGridViewTextBoxColumn});
            this.DriversDataGridView.DataSource = this.driverCollectionBindingSource;
            this.DriversDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DriversDataGridView.Location = new System.Drawing.Point(3, 3);
            this.DriversDataGridView.Name = "DriversDataGridView";
            this.DriversDataGridView.Size = new System.Drawing.Size(682, 464);
            this.DriversDataGridView.TabIndex = 0;
            // 
            // EnginesTabPage
            // 
            this.EnginesTabPage.Controls.Add(this.EnginesDataGridView);
            this.EnginesTabPage.Location = new System.Drawing.Point(4, 22);
            this.EnginesTabPage.Name = "EnginesTabPage";
            this.EnginesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.EnginesTabPage.Size = new System.Drawing.Size(688, 470);
            this.EnginesTabPage.TabIndex = 3;
            this.EnginesTabPage.Text = "Engines";
            this.EnginesTabPage.UseVisualStyleBackColor = true;
            // 
            // EnginesDataGridView
            // 
            this.EnginesDataGridView.AutoGenerateColumns = false;
            this.EnginesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EnginesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn3,
            this.localResourceIdDataGridViewTextBoxColumn3,
            this.resourceIdDataGridViewTextBoxColumn3,
            this.resourceTextDataGridViewTextBoxColumn3,
            this.fuelDataGridViewTextBoxColumn,
            this.heatDataGridViewTextBoxColumn,
            this.powerDataGridViewTextBoxColumn,
            this.reliabilityDataGridViewTextBoxColumn,
            this.responseDataGridViewTextBoxColumn,
            this.rigidityDataGridViewTextBoxColumn,
            this.weightDataGridViewTextBoxColumn});
            this.EnginesDataGridView.DataSource = this.engineCollectionBindingSource;
            this.EnginesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnginesDataGridView.Location = new System.Drawing.Point(3, 3);
            this.EnginesDataGridView.Name = "EnginesDataGridView";
            this.EnginesDataGridView.Size = new System.Drawing.Size(682, 464);
            this.EnginesDataGridView.TabIndex = 0;
            // 
            // TyresTabPage
            // 
            this.TyresTabPage.Controls.Add(this.TyresDataGridView);
            this.TyresTabPage.Location = new System.Drawing.Point(4, 22);
            this.TyresTabPage.Name = "TyresTabPage";
            this.TyresTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TyresTabPage.Size = new System.Drawing.Size(688, 470);
            this.TyresTabPage.TabIndex = 4;
            this.TyresTabPage.Text = "Tyres";
            this.TyresTabPage.UseVisualStyleBackColor = true;
            // 
            // TyresDataGridView
            // 
            this.TyresDataGridView.AutoGenerateColumns = false;
            this.TyresDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TyresDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn4,
            this.localResourceIdDataGridViewTextBoxColumn4,
            this.resourceIdDataGridViewTextBoxColumn4,
            this.resourceTextDataGridViewTextBoxColumn4,
            this.dryHardGripDataGridViewTextBoxColumn,
            this.dryHardResilienceDataGridViewTextBoxColumn,
            this.dryHardStiffnessDataGridViewTextBoxColumn,
            this.dryHardTemperatureDataGridViewTextBoxColumn,
            this.drySoftGripDataGridViewTextBoxColumn,
            this.drySoftResilienceDataGridViewTextBoxColumn,
            this.drySoftStiffnessDataGridViewTextBoxColumn,
            this.drySoftTemperatureDataGridViewTextBoxColumn,
            this.intermediateGripDataGridViewTextBoxColumn,
            this.intermediateResilienceDataGridViewTextBoxColumn,
            this.intermediateStiffnessDataGridViewTextBoxColumn,
            this.intermediateTemperatureDataGridViewTextBoxColumn,
            this.wetWeatherGripDataGridViewTextBoxColumn,
            this.wetWeatherResilienceDataGridViewTextBoxColumn,
            this.wetWeatherStiffnessDataGridViewTextBoxColumn,
            this.wetWeatherTemperatureDataGridViewTextBoxColumn});
            this.TyresDataGridView.DataSource = this.tyreCollectionBindingSource;
            this.TyresDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TyresDataGridView.Location = new System.Drawing.Point(3, 3);
            this.TyresDataGridView.Name = "TyresDataGridView";
            this.TyresDataGridView.Size = new System.Drawing.Size(682, 464);
            this.TyresDataGridView.TabIndex = 0;
            // 
            // FuelsTabPage
            // 
            this.FuelsTabPage.Controls.Add(this.FuelsDataGridView);
            this.FuelsTabPage.Location = new System.Drawing.Point(4, 22);
            this.FuelsTabPage.Name = "FuelsTabPage";
            this.FuelsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FuelsTabPage.Size = new System.Drawing.Size(688, 470);
            this.FuelsTabPage.TabIndex = 5;
            this.FuelsTabPage.Text = "Fuel";
            this.FuelsTabPage.UseVisualStyleBackColor = true;
            // 
            // FuelsDataGridView
            // 
            this.FuelsDataGridView.AutoGenerateColumns = false;
            this.FuelsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FuelsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn5,
            this.localResourceIdDataGridViewTextBoxColumn5,
            this.resourceIdDataGridViewTextBoxColumn5,
            this.resourceTextDataGridViewTextBoxColumn5,
            this.performanceDataGridViewTextBoxColumn,
            this.toleranceDataGridViewTextBoxColumn});
            this.FuelsDataGridView.DataSource = this.fuelCollectionBindingSource;
            this.FuelsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FuelsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.FuelsDataGridView.Name = "FuelsDataGridView";
            this.FuelsDataGridView.Size = new System.Drawing.Size(682, 464);
            this.FuelsDataGridView.TabIndex = 0;
            // 
            // TracksTabPage
            // 
            this.TracksTabPage.Controls.Add(this.TracksDataGridView);
            this.TracksTabPage.Location = new System.Drawing.Point(4, 22);
            this.TracksTabPage.Name = "TracksTabPage";
            this.TracksTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.TracksTabPage.Size = new System.Drawing.Size(688, 470);
            this.TracksTabPage.TabIndex = 6;
            this.TracksTabPage.Text = "Tracks";
            this.TracksTabPage.UseVisualStyleBackColor = true;
            // 
            // TracksDataGridView
            // 
            this.TracksDataGridView.AutoGenerateColumns = false;
            this.TracksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TracksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn6,
            this.localResourceIdDataGridViewTextBoxColumn6,
            this.resourceIdDataGridViewTextBoxColumn6,
            this.resourceTextDataGridViewTextBoxColumn6,
            this.lapsDataGridViewTextBoxColumn,
            this.designDataGridViewComboBoxColumn,
            this.lapRecordDriverDataGridViewComboBoxColumn,
            this.lapRecordTeamDataGridViewComboBoxColumn,
            this.lapRecordTimeDataGridViewTextBoxColumn,
            this.lapRecordMphDataGridViewTextBoxColumn,
            this.lapRecordYearDataGridViewTextBoxColumn,
            this.lastRaceDriverDataGridViewComboBoxColumn,
            this.lastRaceTeamDataGridViewComboBoxColumn,
            this.lastRaceYearDataGridViewTextBoxColumn,
            this.lastRaceTimeDataGridViewTextBoxColumn,
            this.hospitalityDataGridViewTextBoxColumn,
            this.speedDataGridViewTextBoxColumn1,
            this.gripDataGridViewTextBoxColumn,
            this.surfaceDataGridViewTextBoxColumn,
            this.tarmacDataGridViewTextBoxColumn,
            this.dustDataGridViewTextBoxColumn,
            this.overtakingDataGridViewTextBoxColumn1,
            this.brakingDataGridViewTextBoxColumn,
            this.rainDataGridViewTextBoxColumn,
            this.heatDataGridViewTextBoxColumn1,
            this.windDataGridViewTextBoxColumn});
            this.TracksDataGridView.DataSource = this.trackCollectionBindingSource;
            this.TracksDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TracksDataGridView.Location = new System.Drawing.Point(3, 3);
            this.TracksDataGridView.Name = "TracksDataGridView";
            this.TracksDataGridView.Size = new System.Drawing.Size(682, 464);
            this.TracksDataGridView.TabIndex = 0;
            // 
            // RacePerformanceTabPage
            // 
            this.RacePerformanceTabPage.Controls.Add(this.RacePerformanceGroupBox);
            this.RacePerformanceTabPage.Controls.Add(this.RacePerformanceChart);
            this.RacePerformanceTabPage.Location = new System.Drawing.Point(4, 22);
            this.RacePerformanceTabPage.Name = "RacePerformanceTabPage";
            this.RacePerformanceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.RacePerformanceTabPage.Size = new System.Drawing.Size(688, 470);
            this.RacePerformanceTabPage.TabIndex = 7;
            this.RacePerformanceTabPage.Text = "Race Performance";
            this.RacePerformanceTabPage.UseVisualStyleBackColor = true;
            // 
            // RacePerformanceGroupBox
            // 
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceCopyRecommendedButton);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceProposedCheckBox);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceChartBox000NumericUpDown);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceCurrentCheckBox);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceDefaultCheckBox);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceEditButton);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceCopyCurrentButton);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceCopyDefaultButton);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceChartBox120NumericUpDown);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceSoftenCurveButton);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceChartBox070NumericUpDown);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceChartBox060NumericUpDown);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceChartBox020NumericUpDown);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceChartBox040NumericUpDown);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceChartBox080NumericUpDown);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceChartBox030NumericUpDown);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceChartBox090NumericUpDown);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceChartBox050NumericUpDown);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceChartBox100NumericUpDown);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceChartBox010NumericUpDown);
            this.RacePerformanceGroupBox.Controls.Add(this.RacePerformanceChartBox110NumericUpDown);
            this.RacePerformanceGroupBox.Location = new System.Drawing.Point(6, 384);
            this.RacePerformanceGroupBox.Name = "RacePerformanceGroupBox";
            this.RacePerformanceGroupBox.Size = new System.Drawing.Size(676, 80);
            this.RacePerformanceGroupBox.TabIndex = 0;
            this.RacePerformanceGroupBox.TabStop = false;
            // 
            // RacePerformanceCopyRecommendedButton
            // 
            this.RacePerformanceCopyRecommendedButton.Location = new System.Drawing.Point(519, 51);
            this.RacePerformanceCopyRecommendedButton.Name = "RacePerformanceCopyRecommendedButton";
            this.RacePerformanceCopyRecommendedButton.Size = new System.Drawing.Size(151, 23);
            this.RacePerformanceCopyRecommendedButton.TabIndex = 7;
            this.RacePerformanceCopyRecommendedButton.Text = "Copy Recommended";
            this.RacePerformanceCopyRecommendedButton.UseVisualStyleBackColor = true;
            this.RacePerformanceCopyRecommendedButton.Click += new System.EventHandler(this.RacePerformanceCopyRecommendedButton_Click);
            // 
            // RacePerformanceProposedCheckBox
            // 
            this.RacePerformanceProposedCheckBox.AutoSize = true;
            this.RacePerformanceProposedCheckBox.Checked = true;
            this.RacePerformanceProposedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RacePerformanceProposedCheckBox.Location = new System.Drawing.Point(5, 57);
            this.RacePerformanceProposedCheckBox.Name = "RacePerformanceProposedCheckBox";
            this.RacePerformanceProposedCheckBox.Size = new System.Drawing.Size(71, 17);
            this.RacePerformanceProposedCheckBox.TabIndex = 2;
            this.RacePerformanceProposedCheckBox.Text = "Proposed";
            this.RacePerformanceProposedCheckBox.UseVisualStyleBackColor = true;
            this.RacePerformanceProposedCheckBox.CheckedChanged += new System.EventHandler(this.RacePerformanceProposedCheckBox_CheckedChanged);
            // 
            // RacePerformanceChartBox000NumericUpDown
            // 
            this.RacePerformanceChartBox000NumericUpDown.InterceptArrowKeys = false;
            this.RacePerformanceChartBox000NumericUpDown.Location = new System.Drawing.Point(94, 19);
            this.RacePerformanceChartBox000NumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RacePerformanceChartBox000NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.RacePerformanceChartBox000NumericUpDown.Name = "RacePerformanceChartBox000NumericUpDown";
            this.RacePerformanceChartBox000NumericUpDown.Size = new System.Drawing.Size(18, 20);
            this.RacePerformanceChartBox000NumericUpDown.TabIndex = 0;
            this.RacePerformanceChartBox000NumericUpDown.TabStop = false;
            this.RacePerformanceChartBox000NumericUpDown.Tag = "0";
            this.RacePerformanceChartBox000NumericUpDown.ValueChanged += new System.EventHandler(this.RacePerformanceNumericUpDown_ValueChanged);
            // 
            // RacePerformanceCurrentCheckBox
            // 
            this.RacePerformanceCurrentCheckBox.AutoSize = true;
            this.RacePerformanceCurrentCheckBox.Checked = true;
            this.RacePerformanceCurrentCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RacePerformanceCurrentCheckBox.Location = new System.Drawing.Point(5, 34);
            this.RacePerformanceCurrentCheckBox.Name = "RacePerformanceCurrentCheckBox";
            this.RacePerformanceCurrentCheckBox.Size = new System.Drawing.Size(60, 17);
            this.RacePerformanceCurrentCheckBox.TabIndex = 1;
            this.RacePerformanceCurrentCheckBox.Text = "Current";
            this.RacePerformanceCurrentCheckBox.UseVisualStyleBackColor = true;
            this.RacePerformanceCurrentCheckBox.CheckedChanged += new System.EventHandler(this.RacePerformanceCurrentCheckBox_CheckedChanged);
            // 
            // RacePerformanceDefaultCheckBox
            // 
            this.RacePerformanceDefaultCheckBox.AutoSize = true;
            this.RacePerformanceDefaultCheckBox.Checked = true;
            this.RacePerformanceDefaultCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RacePerformanceDefaultCheckBox.Location = new System.Drawing.Point(5, 11);
            this.RacePerformanceDefaultCheckBox.Name = "RacePerformanceDefaultCheckBox";
            this.RacePerformanceDefaultCheckBox.Size = new System.Drawing.Size(60, 17);
            this.RacePerformanceDefaultCheckBox.TabIndex = 0;
            this.RacePerformanceDefaultCheckBox.Text = "Default";
            this.RacePerformanceDefaultCheckBox.UseVisualStyleBackColor = true;
            this.RacePerformanceDefaultCheckBox.CheckedChanged += new System.EventHandler(this.RacePerformanceDefaultCheckBox_CheckedChanged);
            // 
            // RacePerformanceEditButton
            // 
            this.RacePerformanceEditButton.Location = new System.Drawing.Point(111, 51);
            this.RacePerformanceEditButton.Name = "RacePerformanceEditButton";
            this.RacePerformanceEditButton.Size = new System.Drawing.Size(63, 23);
            this.RacePerformanceEditButton.TabIndex = 3;
            this.RacePerformanceEditButton.Text = "Edit...";
            this.RacePerformanceEditButton.UseVisualStyleBackColor = true;
            this.RacePerformanceEditButton.Click += new System.EventHandler(this.RacePerformanceEditButton_Click);
            // 
            // RacePerformanceCopyCurrentButton
            // 
            this.RacePerformanceCopyCurrentButton.Location = new System.Drawing.Point(406, 51);
            this.RacePerformanceCopyCurrentButton.Name = "RacePerformanceCopyCurrentButton";
            this.RacePerformanceCopyCurrentButton.Size = new System.Drawing.Size(107, 23);
            this.RacePerformanceCopyCurrentButton.TabIndex = 6;
            this.RacePerformanceCopyCurrentButton.Text = "Copy Current";
            this.RacePerformanceCopyCurrentButton.UseVisualStyleBackColor = true;
            this.RacePerformanceCopyCurrentButton.Click += new System.EventHandler(this.RacePerformanceCopyCurrentButton_Click);
            // 
            // RacePerformanceCopyDefaultButton
            // 
            this.RacePerformanceCopyDefaultButton.Location = new System.Drawing.Point(293, 51);
            this.RacePerformanceCopyDefaultButton.Name = "RacePerformanceCopyDefaultButton";
            this.RacePerformanceCopyDefaultButton.Size = new System.Drawing.Size(107, 23);
            this.RacePerformanceCopyDefaultButton.TabIndex = 5;
            this.RacePerformanceCopyDefaultButton.Text = "Copy Default";
            this.RacePerformanceCopyDefaultButton.UseVisualStyleBackColor = true;
            this.RacePerformanceCopyDefaultButton.Click += new System.EventHandler(this.RacePerformanceCopyDefaultButton_Click);
            // 
            // RacePerformanceChartBox120NumericUpDown
            // 
            this.RacePerformanceChartBox120NumericUpDown.InterceptArrowKeys = false;
            this.RacePerformanceChartBox120NumericUpDown.Location = new System.Drawing.Point(628, 19);
            this.RacePerformanceChartBox120NumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RacePerformanceChartBox120NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.RacePerformanceChartBox120NumericUpDown.Name = "RacePerformanceChartBox120NumericUpDown";
            this.RacePerformanceChartBox120NumericUpDown.Size = new System.Drawing.Size(18, 20);
            this.RacePerformanceChartBox120NumericUpDown.TabIndex = 0;
            this.RacePerformanceChartBox120NumericUpDown.TabStop = false;
            this.RacePerformanceChartBox120NumericUpDown.Tag = "120";
            this.RacePerformanceChartBox120NumericUpDown.ValueChanged += new System.EventHandler(this.RacePerformanceNumericUpDown_ValueChanged);
            // 
            // RacePerformanceSoftenCurveButton
            // 
            this.RacePerformanceSoftenCurveButton.Location = new System.Drawing.Point(180, 51);
            this.RacePerformanceSoftenCurveButton.Name = "RacePerformanceSoftenCurveButton";
            this.RacePerformanceSoftenCurveButton.Size = new System.Drawing.Size(107, 23);
            this.RacePerformanceSoftenCurveButton.TabIndex = 4;
            this.RacePerformanceSoftenCurveButton.Text = "Soften Curve";
            this.RacePerformanceSoftenCurveButton.UseVisualStyleBackColor = true;
            this.RacePerformanceSoftenCurveButton.Click += new System.EventHandler(this.RacePerformanceSoftenCurveButton_Click);
            // 
            // RacePerformanceChartBox070NumericUpDown
            // 
            this.RacePerformanceChartBox070NumericUpDown.InterceptArrowKeys = false;
            this.RacePerformanceChartBox070NumericUpDown.Location = new System.Drawing.Point(406, 19);
            this.RacePerformanceChartBox070NumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RacePerformanceChartBox070NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.RacePerformanceChartBox070NumericUpDown.Name = "RacePerformanceChartBox070NumericUpDown";
            this.RacePerformanceChartBox070NumericUpDown.Size = new System.Drawing.Size(18, 20);
            this.RacePerformanceChartBox070NumericUpDown.TabIndex = 0;
            this.RacePerformanceChartBox070NumericUpDown.TabStop = false;
            this.RacePerformanceChartBox070NumericUpDown.Tag = "70";
            this.RacePerformanceChartBox070NumericUpDown.ValueChanged += new System.EventHandler(this.RacePerformanceNumericUpDown_ValueChanged);
            // 
            // RacePerformanceChartBox060NumericUpDown
            // 
            this.RacePerformanceChartBox060NumericUpDown.InterceptArrowKeys = false;
            this.RacePerformanceChartBox060NumericUpDown.Location = new System.Drawing.Point(361, 19);
            this.RacePerformanceChartBox060NumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RacePerformanceChartBox060NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.RacePerformanceChartBox060NumericUpDown.Name = "RacePerformanceChartBox060NumericUpDown";
            this.RacePerformanceChartBox060NumericUpDown.Size = new System.Drawing.Size(18, 20);
            this.RacePerformanceChartBox060NumericUpDown.TabIndex = 0;
            this.RacePerformanceChartBox060NumericUpDown.TabStop = false;
            this.RacePerformanceChartBox060NumericUpDown.Tag = "60";
            this.RacePerformanceChartBox060NumericUpDown.ValueChanged += new System.EventHandler(this.RacePerformanceNumericUpDown_ValueChanged);
            // 
            // RacePerformanceChartBox020NumericUpDown
            // 
            this.RacePerformanceChartBox020NumericUpDown.InterceptArrowKeys = false;
            this.RacePerformanceChartBox020NumericUpDown.Location = new System.Drawing.Point(183, 19);
            this.RacePerformanceChartBox020NumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RacePerformanceChartBox020NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.RacePerformanceChartBox020NumericUpDown.Name = "RacePerformanceChartBox020NumericUpDown";
            this.RacePerformanceChartBox020NumericUpDown.Size = new System.Drawing.Size(18, 20);
            this.RacePerformanceChartBox020NumericUpDown.TabIndex = 0;
            this.RacePerformanceChartBox020NumericUpDown.TabStop = false;
            this.RacePerformanceChartBox020NumericUpDown.Tag = "20";
            this.RacePerformanceChartBox020NumericUpDown.ValueChanged += new System.EventHandler(this.RacePerformanceNumericUpDown_ValueChanged);
            // 
            // RacePerformanceChartBox040NumericUpDown
            // 
            this.RacePerformanceChartBox040NumericUpDown.InterceptArrowKeys = false;
            this.RacePerformanceChartBox040NumericUpDown.Location = new System.Drawing.Point(272, 19);
            this.RacePerformanceChartBox040NumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RacePerformanceChartBox040NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.RacePerformanceChartBox040NumericUpDown.Name = "RacePerformanceChartBox040NumericUpDown";
            this.RacePerformanceChartBox040NumericUpDown.Size = new System.Drawing.Size(18, 20);
            this.RacePerformanceChartBox040NumericUpDown.TabIndex = 0;
            this.RacePerformanceChartBox040NumericUpDown.TabStop = false;
            this.RacePerformanceChartBox040NumericUpDown.Tag = "40";
            this.RacePerformanceChartBox040NumericUpDown.ValueChanged += new System.EventHandler(this.RacePerformanceNumericUpDown_ValueChanged);
            // 
            // RacePerformanceChartBox080NumericUpDown
            // 
            this.RacePerformanceChartBox080NumericUpDown.InterceptArrowKeys = false;
            this.RacePerformanceChartBox080NumericUpDown.Location = new System.Drawing.Point(450, 19);
            this.RacePerformanceChartBox080NumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RacePerformanceChartBox080NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.RacePerformanceChartBox080NumericUpDown.Name = "RacePerformanceChartBox080NumericUpDown";
            this.RacePerformanceChartBox080NumericUpDown.Size = new System.Drawing.Size(18, 20);
            this.RacePerformanceChartBox080NumericUpDown.TabIndex = 0;
            this.RacePerformanceChartBox080NumericUpDown.TabStop = false;
            this.RacePerformanceChartBox080NumericUpDown.Tag = "80";
            this.RacePerformanceChartBox080NumericUpDown.ValueChanged += new System.EventHandler(this.RacePerformanceNumericUpDown_ValueChanged);
            // 
            // RacePerformanceChartBox030NumericUpDown
            // 
            this.RacePerformanceChartBox030NumericUpDown.InterceptArrowKeys = false;
            this.RacePerformanceChartBox030NumericUpDown.Location = new System.Drawing.Point(228, 19);
            this.RacePerformanceChartBox030NumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RacePerformanceChartBox030NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.RacePerformanceChartBox030NumericUpDown.Name = "RacePerformanceChartBox030NumericUpDown";
            this.RacePerformanceChartBox030NumericUpDown.Size = new System.Drawing.Size(18, 20);
            this.RacePerformanceChartBox030NumericUpDown.TabIndex = 0;
            this.RacePerformanceChartBox030NumericUpDown.TabStop = false;
            this.RacePerformanceChartBox030NumericUpDown.Tag = "30";
            this.RacePerformanceChartBox030NumericUpDown.ValueChanged += new System.EventHandler(this.RacePerformanceNumericUpDown_ValueChanged);
            // 
            // RacePerformanceChartBox090NumericUpDown
            // 
            this.RacePerformanceChartBox090NumericUpDown.InterceptArrowKeys = false;
            this.RacePerformanceChartBox090NumericUpDown.Location = new System.Drawing.Point(495, 19);
            this.RacePerformanceChartBox090NumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RacePerformanceChartBox090NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.RacePerformanceChartBox090NumericUpDown.Name = "RacePerformanceChartBox090NumericUpDown";
            this.RacePerformanceChartBox090NumericUpDown.Size = new System.Drawing.Size(18, 20);
            this.RacePerformanceChartBox090NumericUpDown.TabIndex = 0;
            this.RacePerformanceChartBox090NumericUpDown.TabStop = false;
            this.RacePerformanceChartBox090NumericUpDown.Tag = "90";
            this.RacePerformanceChartBox090NumericUpDown.ValueChanged += new System.EventHandler(this.RacePerformanceNumericUpDown_ValueChanged);
            // 
            // RacePerformanceChartBox050NumericUpDown
            // 
            this.RacePerformanceChartBox050NumericUpDown.InterceptArrowKeys = false;
            this.RacePerformanceChartBox050NumericUpDown.Location = new System.Drawing.Point(317, 19);
            this.RacePerformanceChartBox050NumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RacePerformanceChartBox050NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.RacePerformanceChartBox050NumericUpDown.Name = "RacePerformanceChartBox050NumericUpDown";
            this.RacePerformanceChartBox050NumericUpDown.Size = new System.Drawing.Size(18, 20);
            this.RacePerformanceChartBox050NumericUpDown.TabIndex = 0;
            this.RacePerformanceChartBox050NumericUpDown.TabStop = false;
            this.RacePerformanceChartBox050NumericUpDown.Tag = "50";
            this.RacePerformanceChartBox050NumericUpDown.ValueChanged += new System.EventHandler(this.RacePerformanceNumericUpDown_ValueChanged);
            // 
            // RacePerformanceChartBox100NumericUpDown
            // 
            this.RacePerformanceChartBox100NumericUpDown.InterceptArrowKeys = false;
            this.RacePerformanceChartBox100NumericUpDown.Location = new System.Drawing.Point(539, 19);
            this.RacePerformanceChartBox100NumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RacePerformanceChartBox100NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.RacePerformanceChartBox100NumericUpDown.Name = "RacePerformanceChartBox100NumericUpDown";
            this.RacePerformanceChartBox100NumericUpDown.Size = new System.Drawing.Size(18, 20);
            this.RacePerformanceChartBox100NumericUpDown.TabIndex = 0;
            this.RacePerformanceChartBox100NumericUpDown.TabStop = false;
            this.RacePerformanceChartBox100NumericUpDown.Tag = "100";
            this.RacePerformanceChartBox100NumericUpDown.ValueChanged += new System.EventHandler(this.RacePerformanceNumericUpDown_ValueChanged);
            // 
            // RacePerformanceChartBox010NumericUpDown
            // 
            this.RacePerformanceChartBox010NumericUpDown.InterceptArrowKeys = false;
            this.RacePerformanceChartBox010NumericUpDown.Location = new System.Drawing.Point(139, 19);
            this.RacePerformanceChartBox010NumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RacePerformanceChartBox010NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.RacePerformanceChartBox010NumericUpDown.Name = "RacePerformanceChartBox010NumericUpDown";
            this.RacePerformanceChartBox010NumericUpDown.Size = new System.Drawing.Size(18, 20);
            this.RacePerformanceChartBox010NumericUpDown.TabIndex = 0;
            this.RacePerformanceChartBox010NumericUpDown.TabStop = false;
            this.RacePerformanceChartBox010NumericUpDown.Tag = "10";
            this.RacePerformanceChartBox010NumericUpDown.ValueChanged += new System.EventHandler(this.RacePerformanceNumericUpDown_ValueChanged);
            // 
            // RacePerformanceChartBox110NumericUpDown
            // 
            this.RacePerformanceChartBox110NumericUpDown.InterceptArrowKeys = false;
            this.RacePerformanceChartBox110NumericUpDown.Location = new System.Drawing.Point(584, 19);
            this.RacePerformanceChartBox110NumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RacePerformanceChartBox110NumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.RacePerformanceChartBox110NumericUpDown.Name = "RacePerformanceChartBox110NumericUpDown";
            this.RacePerformanceChartBox110NumericUpDown.Size = new System.Drawing.Size(18, 20);
            this.RacePerformanceChartBox110NumericUpDown.TabIndex = 0;
            this.RacePerformanceChartBox110NumericUpDown.TabStop = false;
            this.RacePerformanceChartBox110NumericUpDown.Tag = "110";
            this.RacePerformanceChartBox110NumericUpDown.ValueChanged += new System.EventHandler(this.RacePerformanceNumericUpDown_ValueChanged);
            // 
            // RacePerformanceChart
            // 
            chartArea1.Name = "ChartArea1";
            this.RacePerformanceChart.ChartAreas.Add(chartArea1);
            this.RacePerformanceChart.Location = new System.Drawing.Point(6, 6);
            this.RacePerformanceChart.Name = "RacePerformanceChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.RacePerformanceChart.Series.Add(series1);
            this.RacePerformanceChart.Size = new System.Drawing.Size(676, 372);
            this.RacePerformanceChart.TabIndex = 0;
            this.RacePerformanceChart.TabStop = false;
            title1.Name = "Title1";
            title1.Text = "Race Performance Curve";
            this.RacePerformanceChart.Titles.Add(title1);
            // 
            // MiscTabPage
            // 
            this.MiscTabPage.Controls.Add(this.TestingMilesDataGridView);
            this.MiscTabPage.Controls.Add(this.StaffSalariesDataGridView);
            this.MiscTabPage.Controls.Add(this.FactoryExpansionCostsDataGridView);
            this.MiscTabPage.Controls.Add(this.FactoryRunningCostsDataGridView);
            this.MiscTabPage.Location = new System.Drawing.Point(4, 22);
            this.MiscTabPage.Name = "MiscTabPage";
            this.MiscTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MiscTabPage.Size = new System.Drawing.Size(688, 470);
            this.MiscTabPage.TabIndex = 8;
            this.MiscTabPage.Text = "Misc";
            this.MiscTabPage.UseVisualStyleBackColor = true;
            // 
            // TestingMilesDataGridView
            // 
            this.TestingMilesDataGridView.AutoGenerateColumns = false;
            this.TestingMilesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestingMilesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn10,
            this.localResourceIdDataGridViewTextBoxColumn10,
            this.resourceIdDataGridViewTextBoxColumn10,
            this.resourceTextDataGridViewTextBoxColumn10,
            this.value01DataGridViewTextBoxColumn3,
            this.value02DataGridViewTextBoxColumn3,
            this.value03DataGridViewTextBoxColumn3,
            this.value04DataGridViewTextBoxColumn3,
            this.value05DataGridViewTextBoxColumn3,
            this.value06DataGridViewTextBoxColumn,
            this.value07DataGridViewTextBoxColumn,
            this.value08DataGridViewTextBoxColumn,
            this.value09DataGridViewTextBoxColumn,
            this.value10DataGridViewTextBoxColumn});
            this.TestingMilesDataGridView.DataSource = this.tenValueCollectionBindingSource;
            this.TestingMilesDataGridView.Location = new System.Drawing.Point(6, 389);
            this.TestingMilesDataGridView.Name = "TestingMilesDataGridView";
            this.TestingMilesDataGridView.Size = new System.Drawing.Size(676, 75);
            this.TestingMilesDataGridView.TabIndex = 3;
            // 
            // StaffSalariesDataGridView
            // 
            this.StaffSalariesDataGridView.AutoGenerateColumns = false;
            this.StaffSalariesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StaffSalariesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn9,
            this.localResourceIdDataGridViewTextBoxColumn9,
            this.resourceIdDataGridViewTextBoxColumn9,
            this.resourceTextDataGridViewTextBoxColumn9,
            this.value01DataGridViewTextBoxColumn2,
            this.value02DataGridViewTextBoxColumn2,
            this.value03DataGridViewTextBoxColumn2,
            this.value04DataGridViewTextBoxColumn2,
            this.value05DataGridViewTextBoxColumn2});
            this.StaffSalariesDataGridView.DataSource = this.fiveRatingCollectionBindingSource;
            this.StaffSalariesDataGridView.Location = new System.Drawing.Point(6, 265);
            this.StaffSalariesDataGridView.Name = "StaffSalariesDataGridView";
            this.StaffSalariesDataGridView.Size = new System.Drawing.Size(676, 118);
            this.StaffSalariesDataGridView.TabIndex = 2;
            // 
            // FactoryExpansionCostsDataGridView
            // 
            this.FactoryExpansionCostsDataGridView.AutoGenerateColumns = false;
            this.FactoryExpansionCostsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FactoryExpansionCostsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn8,
            this.localResourceIdDataGridViewTextBoxColumn8,
            this.resourceIdDataGridViewTextBoxColumn8,
            this.resourceTextDataGridViewTextBoxColumn8,
            this.value01DataGridViewTextBoxColumn1,
            this.value02DataGridViewTextBoxColumn1,
            this.value03DataGridViewTextBoxColumn1,
            this.value04DataGridViewTextBoxColumn1,
            this.value05DataGridViewTextBoxColumn1});
            this.FactoryExpansionCostsDataGridView.DataSource = this.fiveRatingCollectionBindingSource;
            this.FactoryExpansionCostsDataGridView.Location = new System.Drawing.Point(6, 79);
            this.FactoryExpansionCostsDataGridView.Name = "FactoryExpansionCostsDataGridView";
            this.FactoryExpansionCostsDataGridView.Size = new System.Drawing.Size(676, 180);
            this.FactoryExpansionCostsDataGridView.TabIndex = 1;
            // 
            // FactoryRunningCostsDataGridView
            // 
            this.FactoryRunningCostsDataGridView.AutoGenerateColumns = false;
            this.FactoryRunningCostsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FactoryRunningCostsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn7,
            this.localResourceIdDataGridViewTextBoxColumn7,
            this.resourceIdDataGridViewTextBoxColumn7,
            this.resourceTextDataGridViewTextBoxColumn7,
            this.value01DataGridViewTextBoxColumn,
            this.value02DataGridViewTextBoxColumn,
            this.value03DataGridViewTextBoxColumn,
            this.value04DataGridViewTextBoxColumn,
            this.value05DataGridViewTextBoxColumn});
            this.FactoryRunningCostsDataGridView.DataSource = this.fiveValueCollectionBindingSource;
            this.FactoryRunningCostsDataGridView.Location = new System.Drawing.Point(6, 6);
            this.FactoryRunningCostsDataGridView.Name = "FactoryRunningCostsDataGridView";
            this.FactoryRunningCostsDataGridView.Size = new System.Drawing.Size(676, 67);
            this.FactoryRunningCostsDataGridView.TabIndex = 0;
            // 
            // EngineeringTabPage
            // 
            this.EngineeringTabPage.Controls.Add(this.UnknownBDataGridView);
            this.EngineeringTabPage.Controls.Add(this.UnknownADataGridView);
            this.EngineeringTabPage.Controls.Add(this.EngineeringCostsDataGridView);
            this.EngineeringTabPage.Controls.Add(this.StaffEffortsDataGridView);
            this.EngineeringTabPage.Location = new System.Drawing.Point(4, 22);
            this.EngineeringTabPage.Name = "EngineeringTabPage";
            this.EngineeringTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.EngineeringTabPage.Size = new System.Drawing.Size(688, 470);
            this.EngineeringTabPage.TabIndex = 9;
            this.EngineeringTabPage.Text = "Engineering";
            this.EngineeringTabPage.UseVisualStyleBackColor = true;
            // 
            // UnknownBDataGridView
            // 
            this.UnknownBDataGridView.AutoGenerateColumns = false;
            this.UnknownBDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnknownBDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn14,
            this.localResourceIdDataGridViewTextBoxColumn14,
            this.resourceIdDataGridViewTextBoxColumn14,
            this.resourceTextDataGridViewTextBoxColumn14,
            this.valueDataGridViewTextBoxColumn1});
            this.UnknownBDataGridView.DataSource = this.singleValueCollectionBindingSource;
            this.UnknownBDataGridView.Location = new System.Drawing.Point(374, 323);
            this.UnknownBDataGridView.Name = "UnknownBDataGridView";
            this.UnknownBDataGridView.Size = new System.Drawing.Size(308, 141);
            this.UnknownBDataGridView.TabIndex = 2;
            // 
            // UnknownADataGridView
            // 
            this.UnknownADataGridView.AutoGenerateColumns = false;
            this.UnknownADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UnknownADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn13,
            this.localResourceIdDataGridViewTextBoxColumn13,
            this.resourceIdDataGridViewTextBoxColumn13,
            this.resourceTextDataGridViewTextBoxColumn13,
            this.valueDataGridViewTextBoxColumn});
            this.UnknownADataGridView.DataSource = this.singleValueCollectionBindingSource;
            this.UnknownADataGridView.Location = new System.Drawing.Point(7, 324);
            this.UnknownADataGridView.Name = "UnknownADataGridView";
            this.UnknownADataGridView.Size = new System.Drawing.Size(308, 140);
            this.UnknownADataGridView.TabIndex = 2;
            // 
            // EngineeringCostsDataGridView
            // 
            this.EngineeringCostsDataGridView.AutoGenerateColumns = false;
            this.EngineeringCostsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EngineeringCostsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn12,
            this.localResourceIdDataGridViewTextBoxColumn12,
            this.resourceIdDataGridViewTextBoxColumn12,
            this.resourceTextDataGridViewTextBoxColumn12,
            this.value01DataGridViewTextBoxColumn5,
            this.value02DataGridViewTextBoxColumn5,
            this.value03DataGridViewTextBoxColumn5,
            this.value04DataGridViewTextBoxColumn5,
            this.value05DataGridViewTextBoxColumn5,
            this.value06DataGridViewTextBoxColumn1,
            this.value07DataGridViewTextBoxColumn1,
            this.value08DataGridViewTextBoxColumn1,
            this.value09DataGridViewTextBoxColumn1,
            this.value10DataGridViewTextBoxColumn1});
            this.EngineeringCostsDataGridView.DataSource = this.tenValueCollectionBindingSource;
            this.EngineeringCostsDataGridView.Location = new System.Drawing.Point(6, 167);
            this.EngineeringCostsDataGridView.Name = "EngineeringCostsDataGridView";
            this.EngineeringCostsDataGridView.Size = new System.Drawing.Size(676, 150);
            this.EngineeringCostsDataGridView.TabIndex = 1;
            // 
            // StaffEffortsDataGridView
            // 
            this.StaffEffortsDataGridView.AutoGenerateColumns = false;
            this.StaffEffortsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StaffEffortsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn11,
            this.localResourceIdDataGridViewTextBoxColumn11,
            this.resourceIdDataGridViewTextBoxColumn11,
            this.resourceTextDataGridViewTextBoxColumn11,
            this.value01DataGridViewTextBoxColumn4,
            this.value02DataGridViewTextBoxColumn4,
            this.value03DataGridViewTextBoxColumn4,
            this.value04DataGridViewTextBoxColumn4,
            this.value05DataGridViewTextBoxColumn4});
            this.StaffEffortsDataGridView.DataSource = this.fiveRatingCollectionBindingSource;
            this.StaffEffortsDataGridView.Location = new System.Drawing.Point(6, 6);
            this.StaffEffortsDataGridView.Name = "StaffEffortsDataGridView";
            this.StaffEffortsDataGridView.Size = new System.Drawing.Size(676, 155);
            this.StaffEffortsDataGridView.TabIndex = 0;
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.NonF1DriversDataGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(688, 470);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // NonF1DriversDataGridView
            // 
            this.NonF1DriversDataGridView.AutoGenerateColumns = false;
            this.NonF1DriversDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NonF1DriversDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn15,
            this.localResourceIdDataGridViewTextBoxColumn15,
            this.resourceIdDataGridViewTextBoxColumn15,
            this.resourceTextDataGridViewTextBoxColumn15,
            this.salaryDataGridViewTextBoxColumn1,
            this.raceBonusDataGridViewTextBoxColumn1,
            this.championshipBonusDataGridViewTextBoxColumn1,
            this.ageDataGridViewTextBoxColumn1,
            this.nationalityDataGridViewTextBoxColumn,
            this.unknownDataGridViewTextBoxColumn1,
            this.speedDataGridViewTextBoxColumn2,
            this.skillDataGridViewTextBoxColumn1,
            this.overtakingDataGridViewTextBoxColumn2,
            this.wetWeatherDataGridViewTextBoxColumn1,
            this.concentrationDataGridViewTextBoxColumn1,
            this.experienceDataGridViewTextBoxColumn1,
            this.staminaDataGridViewTextBoxColumn1,
            this.moraleDataGridViewTextBoxColumn1});
            this.NonF1DriversDataGridView.DataSource = this.nonF1DriverCollectionBindingSource;
            this.NonF1DriversDataGridView.Location = new System.Drawing.Point(6, 6);
            this.NonF1DriversDataGridView.Name = "NonF1DriversDataGridView";
            this.NonF1DriversDataGridView.Size = new System.Drawing.Size(676, 458);
            this.NonF1DriversDataGridView.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // localResourceIdDataGridViewTextBoxColumn
            // 
            this.localResourceIdDataGridViewTextBoxColumn.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn.Name = "localResourceIdDataGridViewTextBoxColumn";
            // 
            // resourceIdDataGridViewTextBoxColumn
            // 
            this.resourceIdDataGridViewTextBoxColumn.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn.Name = "resourceIdDataGridViewTextBoxColumn";
            // 
            // resourceTextDataGridViewTextBoxColumn
            // 
            this.resourceTextDataGridViewTextBoxColumn.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn.Name = "resourceTextDataGridViewTextBoxColumn";
            // 
            // identityCollectionBindingSource
            // 
            this.identityCollectionBindingSource.DataSource = typeof(Data.Collections.Language.IdentityCollection);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // localResourceIdDataGridViewTextBoxColumn1
            // 
            this.localResourceIdDataGridViewTextBoxColumn1.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn1.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn1.Name = "localResourceIdDataGridViewTextBoxColumn1";
            // 
            // resourceIdDataGridViewTextBoxColumn1
            // 
            this.resourceIdDataGridViewTextBoxColumn1.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn1.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn1.Name = "resourceIdDataGridViewTextBoxColumn1";
            // 
            // resourceTextDataGridViewTextBoxColumn1
            // 
            this.resourceTextDataGridViewTextBoxColumn1.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn1.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn1.Name = "resourceTextDataGridViewTextBoxColumn1";
            // 
            // lastPositionDataGridViewTextBoxColumn
            // 
            this.lastPositionDataGridViewTextBoxColumn.DataPropertyName = "LastPosition";
            this.lastPositionDataGridViewTextBoxColumn.HeaderText = "LastPosition";
            this.lastPositionDataGridViewTextBoxColumn.Name = "lastPositionDataGridViewTextBoxColumn";
            // 
            // lastPointsDataGridViewTextBoxColumn
            // 
            this.lastPointsDataGridViewTextBoxColumn.DataPropertyName = "LastPoints";
            this.lastPointsDataGridViewTextBoxColumn.HeaderText = "LastPoints";
            this.lastPointsDataGridViewTextBoxColumn.Name = "lastPointsDataGridViewTextBoxColumn";
            // 
            // firstGpTrackDataGridViewComboBoxColumn
            // 
            this.firstGpTrackDataGridViewComboBoxColumn.DataPropertyName = "FirstGpTrack";
            this.firstGpTrackDataGridViewComboBoxColumn.HeaderText = "FirstGpTrack";
            this.firstGpTrackDataGridViewComboBoxColumn.Name = "firstGpTrackDataGridViewComboBoxColumn";
            this.firstGpTrackDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.firstGpTrackDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // firstGpYearDataGridViewTextBoxColumn
            // 
            this.firstGpYearDataGridViewTextBoxColumn.DataPropertyName = "FirstGpYear";
            this.firstGpYearDataGridViewTextBoxColumn.HeaderText = "FirstGpYear";
            this.firstGpYearDataGridViewTextBoxColumn.Name = "firstGpYearDataGridViewTextBoxColumn";
            // 
            // winsDataGridViewTextBoxColumn
            // 
            this.winsDataGridViewTextBoxColumn.DataPropertyName = "Wins";
            this.winsDataGridViewTextBoxColumn.HeaderText = "Wins";
            this.winsDataGridViewTextBoxColumn.Name = "winsDataGridViewTextBoxColumn";
            // 
            // yearlyBudgetDataGridViewTextBoxColumn
            // 
            this.yearlyBudgetDataGridViewTextBoxColumn.DataPropertyName = "YearlyBudget";
            this.yearlyBudgetDataGridViewTextBoxColumn.HeaderText = "YearlyBudget";
            this.yearlyBudgetDataGridViewTextBoxColumn.Name = "yearlyBudgetDataGridViewTextBoxColumn";
            // 
            // unknownDataGridViewTextBoxColumn
            // 
            this.unknownDataGridViewTextBoxColumn.DataPropertyName = "Unknown";
            this.unknownDataGridViewTextBoxColumn.HeaderText = "Unknown";
            this.unknownDataGridViewTextBoxColumn.Name = "unknownDataGridViewTextBoxColumn";
            // 
            // countryMapIdDataGridViewTextBoxColumn
            // 
            this.countryMapIdDataGridViewTextBoxColumn.DataPropertyName = "CountryMapId";
            this.countryMapIdDataGridViewTextBoxColumn.HeaderText = "CountryMapId";
            this.countryMapIdDataGridViewTextBoxColumn.Name = "countryMapIdDataGridViewTextBoxColumn";
            // 
            // locationPointerXDataGridViewTextBoxColumn
            // 
            this.locationPointerXDataGridViewTextBoxColumn.DataPropertyName = "LocationPointerX";
            this.locationPointerXDataGridViewTextBoxColumn.HeaderText = "LocationPointerX";
            this.locationPointerXDataGridViewTextBoxColumn.Name = "locationPointerXDataGridViewTextBoxColumn";
            // 
            // locationPointerYDataGridViewTextBoxColumn
            // 
            this.locationPointerYDataGridViewTextBoxColumn.DataPropertyName = "LocationPointerY";
            this.locationPointerYDataGridViewTextBoxColumn.HeaderText = "LocationPointerY";
            this.locationPointerYDataGridViewTextBoxColumn.Name = "locationPointerYDataGridViewTextBoxColumn";
            // 
            // tyreSupplierIdDataGridViewComboBoxColumn
            // 
            this.tyreSupplierIdDataGridViewComboBoxColumn.DataPropertyName = "TyreSupplierId";
            this.tyreSupplierIdDataGridViewComboBoxColumn.HeaderText = "TyreSupplierId";
            this.tyreSupplierIdDataGridViewComboBoxColumn.Name = "tyreSupplierIdDataGridViewComboBoxColumn";
            this.tyreSupplierIdDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tyreSupplierIdDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // teamCollectionBindingSource
            // 
            this.teamCollectionBindingSource.DataSource = typeof(Data.Collections.Executable.Team.TeamCollection);
            // 
            // idDataGridViewTextBoxColumn2
            // 
            this.idDataGridViewTextBoxColumn2.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn2.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn2.Name = "idDataGridViewTextBoxColumn2";
            // 
            // localResourceIdDataGridViewTextBoxColumn2
            // 
            this.localResourceIdDataGridViewTextBoxColumn2.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn2.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn2.Name = "localResourceIdDataGridViewTextBoxColumn2";
            // 
            // resourceIdDataGridViewTextBoxColumn2
            // 
            this.resourceIdDataGridViewTextBoxColumn2.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn2.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn2.Name = "resourceIdDataGridViewTextBoxColumn2";
            // 
            // resourceTextDataGridViewTextBoxColumn2
            // 
            this.resourceTextDataGridViewTextBoxColumn2.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn2.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn2.Name = "resourceTextDataGridViewTextBoxColumn2";
            // 
            // salaryDataGridViewTextBoxColumn
            // 
            this.salaryDataGridViewTextBoxColumn.DataPropertyName = "Salary";
            this.salaryDataGridViewTextBoxColumn.HeaderText = "Salary";
            this.salaryDataGridViewTextBoxColumn.Name = "salaryDataGridViewTextBoxColumn";
            // 
            // raceBonusDataGridViewTextBoxColumn
            // 
            this.raceBonusDataGridViewTextBoxColumn.DataPropertyName = "RaceBonus";
            this.raceBonusDataGridViewTextBoxColumn.HeaderText = "RaceBonus";
            this.raceBonusDataGridViewTextBoxColumn.Name = "raceBonusDataGridViewTextBoxColumn";
            // 
            // championshipBonusDataGridViewTextBoxColumn
            // 
            this.championshipBonusDataGridViewTextBoxColumn.DataPropertyName = "ChampionshipBonus";
            this.championshipBonusDataGridViewTextBoxColumn.HeaderText = "ChampionshipBonus";
            this.championshipBonusDataGridViewTextBoxColumn.Name = "championshipBonusDataGridViewTextBoxColumn";
            // 
            // payRatingDataGridViewTextBoxColumn
            // 
            this.payRatingDataGridViewTextBoxColumn.DataPropertyName = "PayRating";
            this.payRatingDataGridViewTextBoxColumn.HeaderText = "PayRating";
            this.payRatingDataGridViewTextBoxColumn.Name = "payRatingDataGridViewTextBoxColumn";
            // 
            // positiveSalaryDataGridViewTextBoxColumn
            // 
            this.positiveSalaryDataGridViewTextBoxColumn.DataPropertyName = "PositiveSalary";
            this.positiveSalaryDataGridViewTextBoxColumn.HeaderText = "PositiveSalary";
            this.positiveSalaryDataGridViewTextBoxColumn.Name = "positiveSalaryDataGridViewTextBoxColumn";
            // 
            // lastChampionshipPositionDataGridViewTextBoxColumn
            // 
            this.lastChampionshipPositionDataGridViewTextBoxColumn.DataPropertyName = "LastChampionshipPosition";
            this.lastChampionshipPositionDataGridViewTextBoxColumn.HeaderText = "LastChampionshipPosition";
            this.lastChampionshipPositionDataGridViewTextBoxColumn.Name = "lastChampionshipPositionDataGridViewTextBoxColumn";
            // 
            // driverRoleDataGridViewTextBoxColumn
            // 
            this.driverRoleDataGridViewTextBoxColumn.DataPropertyName = "DriverRole";
            this.driverRoleDataGridViewTextBoxColumn.HeaderText = "DriverRole";
            this.driverRoleDataGridViewTextBoxColumn.Name = "driverRoleDataGridViewTextBoxColumn";
            // 
            // carNumberDataGridViewTextBoxColumn
            // 
            this.carNumberDataGridViewTextBoxColumn.DataPropertyName = "CarNumber";
            this.carNumberDataGridViewTextBoxColumn.HeaderText = "CarNumber";
            this.carNumberDataGridViewTextBoxColumn.Name = "carNumberDataGridViewTextBoxColumn";
            // 
            // ageDataGridViewTextBoxColumn
            // 
            this.ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            // 
            // nationalityDataGridViewComboBoxColumn
            // 
            this.nationalityDataGridViewComboBoxColumn.DataPropertyName = "Nationality";
            this.nationalityDataGridViewComboBoxColumn.HeaderText = "Nationality";
            this.nationalityDataGridViewComboBoxColumn.Name = "nationalityDataGridViewComboBoxColumn";
            this.nationalityDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.nationalityDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // careerChampionshipsDataGridViewTextBoxColumn
            // 
            this.careerChampionshipsDataGridViewTextBoxColumn.DataPropertyName = "CareerChampionships";
            this.careerChampionshipsDataGridViewTextBoxColumn.HeaderText = "CareerChampionships";
            this.careerChampionshipsDataGridViewTextBoxColumn.Name = "careerChampionshipsDataGridViewTextBoxColumn";
            // 
            // careerRacesDataGridViewTextBoxColumn
            // 
            this.careerRacesDataGridViewTextBoxColumn.DataPropertyName = "CareerRaces";
            this.careerRacesDataGridViewTextBoxColumn.HeaderText = "CareerRaces";
            this.careerRacesDataGridViewTextBoxColumn.Name = "careerRacesDataGridViewTextBoxColumn";
            // 
            // careerWinsDataGridViewTextBoxColumn
            // 
            this.careerWinsDataGridViewTextBoxColumn.DataPropertyName = "CareerWins";
            this.careerWinsDataGridViewTextBoxColumn.HeaderText = "CareerWins";
            this.careerWinsDataGridViewTextBoxColumn.Name = "careerWinsDataGridViewTextBoxColumn";
            // 
            // careerPointsDataGridViewTextBoxColumn
            // 
            this.careerPointsDataGridViewTextBoxColumn.DataPropertyName = "CareerPoints";
            this.careerPointsDataGridViewTextBoxColumn.HeaderText = "CareerPoints";
            this.careerPointsDataGridViewTextBoxColumn.Name = "careerPointsDataGridViewTextBoxColumn";
            // 
            // careerFastestLapsDataGridViewTextBoxColumn
            // 
            this.careerFastestLapsDataGridViewTextBoxColumn.DataPropertyName = "CareerFastestLaps";
            this.careerFastestLapsDataGridViewTextBoxColumn.HeaderText = "CareerFastestLaps";
            this.careerFastestLapsDataGridViewTextBoxColumn.Name = "careerFastestLapsDataGridViewTextBoxColumn";
            // 
            // careerPointsFinishesDataGridViewTextBoxColumn
            // 
            this.careerPointsFinishesDataGridViewTextBoxColumn.DataPropertyName = "CareerPointsFinishes";
            this.careerPointsFinishesDataGridViewTextBoxColumn.HeaderText = "CareerPointsFinishes";
            this.careerPointsFinishesDataGridViewTextBoxColumn.Name = "careerPointsFinishesDataGridViewTextBoxColumn";
            // 
            // careerPolePositionsDataGridViewTextBoxColumn
            // 
            this.careerPolePositionsDataGridViewTextBoxColumn.DataPropertyName = "CareerPolePositions";
            this.careerPolePositionsDataGridViewTextBoxColumn.HeaderText = "CareerPolePositions";
            this.careerPolePositionsDataGridViewTextBoxColumn.Name = "careerPolePositionsDataGridViewTextBoxColumn";
            // 
            // speedDataGridViewTextBoxColumn
            // 
            this.speedDataGridViewTextBoxColumn.DataPropertyName = "Speed";
            this.speedDataGridViewTextBoxColumn.HeaderText = "Speed";
            this.speedDataGridViewTextBoxColumn.Name = "speedDataGridViewTextBoxColumn";
            // 
            // skillDataGridViewTextBoxColumn
            // 
            this.skillDataGridViewTextBoxColumn.DataPropertyName = "Skill";
            this.skillDataGridViewTextBoxColumn.HeaderText = "Skill";
            this.skillDataGridViewTextBoxColumn.Name = "skillDataGridViewTextBoxColumn";
            // 
            // overtakingDataGridViewTextBoxColumn
            // 
            this.overtakingDataGridViewTextBoxColumn.DataPropertyName = "Overtaking";
            this.overtakingDataGridViewTextBoxColumn.HeaderText = "Overtaking";
            this.overtakingDataGridViewTextBoxColumn.Name = "overtakingDataGridViewTextBoxColumn";
            // 
            // wetWeatherDataGridViewTextBoxColumn
            // 
            this.wetWeatherDataGridViewTextBoxColumn.DataPropertyName = "WetWeather";
            this.wetWeatherDataGridViewTextBoxColumn.HeaderText = "WetWeather";
            this.wetWeatherDataGridViewTextBoxColumn.Name = "wetWeatherDataGridViewTextBoxColumn";
            // 
            // concentrationDataGridViewTextBoxColumn
            // 
            this.concentrationDataGridViewTextBoxColumn.DataPropertyName = "Concentration";
            this.concentrationDataGridViewTextBoxColumn.HeaderText = "Concentration";
            this.concentrationDataGridViewTextBoxColumn.Name = "concentrationDataGridViewTextBoxColumn";
            // 
            // experienceDataGridViewTextBoxColumn
            // 
            this.experienceDataGridViewTextBoxColumn.DataPropertyName = "Experience";
            this.experienceDataGridViewTextBoxColumn.HeaderText = "Experience";
            this.experienceDataGridViewTextBoxColumn.Name = "experienceDataGridViewTextBoxColumn";
            // 
            // staminaDataGridViewTextBoxColumn
            // 
            this.staminaDataGridViewTextBoxColumn.DataPropertyName = "Stamina";
            this.staminaDataGridViewTextBoxColumn.HeaderText = "Stamina";
            this.staminaDataGridViewTextBoxColumn.Name = "staminaDataGridViewTextBoxColumn";
            // 
            // moraleDataGridViewTextBoxColumn
            // 
            this.moraleDataGridViewTextBoxColumn.DataPropertyName = "Morale";
            this.moraleDataGridViewTextBoxColumn.HeaderText = "Morale";
            this.moraleDataGridViewTextBoxColumn.Name = "moraleDataGridViewTextBoxColumn";
            // 
            // driverCollectionBindingSource
            // 
            this.driverCollectionBindingSource.DataSource = typeof(Data.Collections.Executable.Team.DriverCollection);
            // 
            // idDataGridViewTextBoxColumn3
            // 
            this.idDataGridViewTextBoxColumn3.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn3.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn3.Name = "idDataGridViewTextBoxColumn3";
            // 
            // localResourceIdDataGridViewTextBoxColumn3
            // 
            this.localResourceIdDataGridViewTextBoxColumn3.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn3.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn3.Name = "localResourceIdDataGridViewTextBoxColumn3";
            // 
            // resourceIdDataGridViewTextBoxColumn3
            // 
            this.resourceIdDataGridViewTextBoxColumn3.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn3.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn3.Name = "resourceIdDataGridViewTextBoxColumn3";
            // 
            // resourceTextDataGridViewTextBoxColumn3
            // 
            this.resourceTextDataGridViewTextBoxColumn3.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn3.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn3.Name = "resourceTextDataGridViewTextBoxColumn3";
            // 
            // fuelDataGridViewTextBoxColumn
            // 
            this.fuelDataGridViewTextBoxColumn.DataPropertyName = "Fuel";
            this.fuelDataGridViewTextBoxColumn.HeaderText = "Fuel";
            this.fuelDataGridViewTextBoxColumn.Name = "fuelDataGridViewTextBoxColumn";
            // 
            // heatDataGridViewTextBoxColumn
            // 
            this.heatDataGridViewTextBoxColumn.DataPropertyName = "Heat";
            this.heatDataGridViewTextBoxColumn.HeaderText = "Heat";
            this.heatDataGridViewTextBoxColumn.Name = "heatDataGridViewTextBoxColumn";
            // 
            // powerDataGridViewTextBoxColumn
            // 
            this.powerDataGridViewTextBoxColumn.DataPropertyName = "Power";
            this.powerDataGridViewTextBoxColumn.HeaderText = "Power";
            this.powerDataGridViewTextBoxColumn.Name = "powerDataGridViewTextBoxColumn";
            // 
            // reliabilityDataGridViewTextBoxColumn
            // 
            this.reliabilityDataGridViewTextBoxColumn.DataPropertyName = "Reliability";
            this.reliabilityDataGridViewTextBoxColumn.HeaderText = "Reliability";
            this.reliabilityDataGridViewTextBoxColumn.Name = "reliabilityDataGridViewTextBoxColumn";
            // 
            // responseDataGridViewTextBoxColumn
            // 
            this.responseDataGridViewTextBoxColumn.DataPropertyName = "Response";
            this.responseDataGridViewTextBoxColumn.HeaderText = "Response";
            this.responseDataGridViewTextBoxColumn.Name = "responseDataGridViewTextBoxColumn";
            // 
            // rigidityDataGridViewTextBoxColumn
            // 
            this.rigidityDataGridViewTextBoxColumn.DataPropertyName = "Rigidity";
            this.rigidityDataGridViewTextBoxColumn.HeaderText = "Rigidity";
            this.rigidityDataGridViewTextBoxColumn.Name = "rigidityDataGridViewTextBoxColumn";
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            this.weightDataGridViewTextBoxColumn.HeaderText = "Weight";
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            // 
            // engineCollectionBindingSource
            // 
            this.engineCollectionBindingSource.DataSource = typeof(Data.Collections.Executable.Supplier.EngineCollection);
            // 
            // idDataGridViewTextBoxColumn4
            // 
            this.idDataGridViewTextBoxColumn4.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn4.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn4.Name = "idDataGridViewTextBoxColumn4";
            // 
            // localResourceIdDataGridViewTextBoxColumn4
            // 
            this.localResourceIdDataGridViewTextBoxColumn4.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn4.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn4.Name = "localResourceIdDataGridViewTextBoxColumn4";
            // 
            // resourceIdDataGridViewTextBoxColumn4
            // 
            this.resourceIdDataGridViewTextBoxColumn4.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn4.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn4.Name = "resourceIdDataGridViewTextBoxColumn4";
            // 
            // resourceTextDataGridViewTextBoxColumn4
            // 
            this.resourceTextDataGridViewTextBoxColumn4.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn4.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn4.Name = "resourceTextDataGridViewTextBoxColumn4";
            // 
            // dryHardGripDataGridViewTextBoxColumn
            // 
            this.dryHardGripDataGridViewTextBoxColumn.DataPropertyName = "DryHardGrip";
            this.dryHardGripDataGridViewTextBoxColumn.HeaderText = "DryHardGrip";
            this.dryHardGripDataGridViewTextBoxColumn.Name = "dryHardGripDataGridViewTextBoxColumn";
            // 
            // dryHardResilienceDataGridViewTextBoxColumn
            // 
            this.dryHardResilienceDataGridViewTextBoxColumn.DataPropertyName = "DryHardResilience";
            this.dryHardResilienceDataGridViewTextBoxColumn.HeaderText = "DryHardResilience";
            this.dryHardResilienceDataGridViewTextBoxColumn.Name = "dryHardResilienceDataGridViewTextBoxColumn";
            // 
            // dryHardStiffnessDataGridViewTextBoxColumn
            // 
            this.dryHardStiffnessDataGridViewTextBoxColumn.DataPropertyName = "DryHardStiffness";
            this.dryHardStiffnessDataGridViewTextBoxColumn.HeaderText = "DryHardStiffness";
            this.dryHardStiffnessDataGridViewTextBoxColumn.Name = "dryHardStiffnessDataGridViewTextBoxColumn";
            // 
            // dryHardTemperatureDataGridViewTextBoxColumn
            // 
            this.dryHardTemperatureDataGridViewTextBoxColumn.DataPropertyName = "DryHardTemperature";
            this.dryHardTemperatureDataGridViewTextBoxColumn.HeaderText = "DryHardTemperature";
            this.dryHardTemperatureDataGridViewTextBoxColumn.Name = "dryHardTemperatureDataGridViewTextBoxColumn";
            // 
            // drySoftGripDataGridViewTextBoxColumn
            // 
            this.drySoftGripDataGridViewTextBoxColumn.DataPropertyName = "DrySoftGrip";
            this.drySoftGripDataGridViewTextBoxColumn.HeaderText = "DrySoftGrip";
            this.drySoftGripDataGridViewTextBoxColumn.Name = "drySoftGripDataGridViewTextBoxColumn";
            // 
            // drySoftResilienceDataGridViewTextBoxColumn
            // 
            this.drySoftResilienceDataGridViewTextBoxColumn.DataPropertyName = "DrySoftResilience";
            this.drySoftResilienceDataGridViewTextBoxColumn.HeaderText = "DrySoftResilience";
            this.drySoftResilienceDataGridViewTextBoxColumn.Name = "drySoftResilienceDataGridViewTextBoxColumn";
            // 
            // drySoftStiffnessDataGridViewTextBoxColumn
            // 
            this.drySoftStiffnessDataGridViewTextBoxColumn.DataPropertyName = "DrySoftStiffness";
            this.drySoftStiffnessDataGridViewTextBoxColumn.HeaderText = "DrySoftStiffness";
            this.drySoftStiffnessDataGridViewTextBoxColumn.Name = "drySoftStiffnessDataGridViewTextBoxColumn";
            // 
            // drySoftTemperatureDataGridViewTextBoxColumn
            // 
            this.drySoftTemperatureDataGridViewTextBoxColumn.DataPropertyName = "DrySoftTemperature";
            this.drySoftTemperatureDataGridViewTextBoxColumn.HeaderText = "DrySoftTemperature";
            this.drySoftTemperatureDataGridViewTextBoxColumn.Name = "drySoftTemperatureDataGridViewTextBoxColumn";
            // 
            // intermediateGripDataGridViewTextBoxColumn
            // 
            this.intermediateGripDataGridViewTextBoxColumn.DataPropertyName = "IntermediateGrip";
            this.intermediateGripDataGridViewTextBoxColumn.HeaderText = "IntermediateGrip";
            this.intermediateGripDataGridViewTextBoxColumn.Name = "intermediateGripDataGridViewTextBoxColumn";
            // 
            // intermediateResilienceDataGridViewTextBoxColumn
            // 
            this.intermediateResilienceDataGridViewTextBoxColumn.DataPropertyName = "IntermediateResilience";
            this.intermediateResilienceDataGridViewTextBoxColumn.HeaderText = "IntermediateResilience";
            this.intermediateResilienceDataGridViewTextBoxColumn.Name = "intermediateResilienceDataGridViewTextBoxColumn";
            // 
            // intermediateStiffnessDataGridViewTextBoxColumn
            // 
            this.intermediateStiffnessDataGridViewTextBoxColumn.DataPropertyName = "IntermediateStiffness";
            this.intermediateStiffnessDataGridViewTextBoxColumn.HeaderText = "IntermediateStiffness";
            this.intermediateStiffnessDataGridViewTextBoxColumn.Name = "intermediateStiffnessDataGridViewTextBoxColumn";
            // 
            // intermediateTemperatureDataGridViewTextBoxColumn
            // 
            this.intermediateTemperatureDataGridViewTextBoxColumn.DataPropertyName = "IntermediateTemperature";
            this.intermediateTemperatureDataGridViewTextBoxColumn.HeaderText = "IntermediateTemperature";
            this.intermediateTemperatureDataGridViewTextBoxColumn.Name = "intermediateTemperatureDataGridViewTextBoxColumn";
            // 
            // wetWeatherGripDataGridViewTextBoxColumn
            // 
            this.wetWeatherGripDataGridViewTextBoxColumn.DataPropertyName = "WetWeatherGrip";
            this.wetWeatherGripDataGridViewTextBoxColumn.HeaderText = "WetWeatherGrip";
            this.wetWeatherGripDataGridViewTextBoxColumn.Name = "wetWeatherGripDataGridViewTextBoxColumn";
            // 
            // wetWeatherResilienceDataGridViewTextBoxColumn
            // 
            this.wetWeatherResilienceDataGridViewTextBoxColumn.DataPropertyName = "WetWeatherResilience";
            this.wetWeatherResilienceDataGridViewTextBoxColumn.HeaderText = "WetWeatherResilience";
            this.wetWeatherResilienceDataGridViewTextBoxColumn.Name = "wetWeatherResilienceDataGridViewTextBoxColumn";
            // 
            // wetWeatherStiffnessDataGridViewTextBoxColumn
            // 
            this.wetWeatherStiffnessDataGridViewTextBoxColumn.DataPropertyName = "WetWeatherStiffness";
            this.wetWeatherStiffnessDataGridViewTextBoxColumn.HeaderText = "WetWeatherStiffness";
            this.wetWeatherStiffnessDataGridViewTextBoxColumn.Name = "wetWeatherStiffnessDataGridViewTextBoxColumn";
            // 
            // wetWeatherTemperatureDataGridViewTextBoxColumn
            // 
            this.wetWeatherTemperatureDataGridViewTextBoxColumn.DataPropertyName = "WetWeatherTemperature";
            this.wetWeatherTemperatureDataGridViewTextBoxColumn.HeaderText = "WetWeatherTemperature";
            this.wetWeatherTemperatureDataGridViewTextBoxColumn.Name = "wetWeatherTemperatureDataGridViewTextBoxColumn";
            // 
            // tyreCollectionBindingSource
            // 
            this.tyreCollectionBindingSource.DataSource = typeof(Data.Collections.Executable.Supplier.TyreCollection);
            // 
            // idDataGridViewTextBoxColumn5
            // 
            this.idDataGridViewTextBoxColumn5.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn5.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn5.Name = "idDataGridViewTextBoxColumn5";
            // 
            // localResourceIdDataGridViewTextBoxColumn5
            // 
            this.localResourceIdDataGridViewTextBoxColumn5.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn5.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn5.Name = "localResourceIdDataGridViewTextBoxColumn5";
            // 
            // resourceIdDataGridViewTextBoxColumn5
            // 
            this.resourceIdDataGridViewTextBoxColumn5.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn5.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn5.Name = "resourceIdDataGridViewTextBoxColumn5";
            // 
            // resourceTextDataGridViewTextBoxColumn5
            // 
            this.resourceTextDataGridViewTextBoxColumn5.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn5.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn5.Name = "resourceTextDataGridViewTextBoxColumn5";
            // 
            // performanceDataGridViewTextBoxColumn
            // 
            this.performanceDataGridViewTextBoxColumn.DataPropertyName = "Performance";
            this.performanceDataGridViewTextBoxColumn.HeaderText = "Performance";
            this.performanceDataGridViewTextBoxColumn.Name = "performanceDataGridViewTextBoxColumn";
            // 
            // toleranceDataGridViewTextBoxColumn
            // 
            this.toleranceDataGridViewTextBoxColumn.DataPropertyName = "Tolerance";
            this.toleranceDataGridViewTextBoxColumn.HeaderText = "Tolerance";
            this.toleranceDataGridViewTextBoxColumn.Name = "toleranceDataGridViewTextBoxColumn";
            // 
            // fuelCollectionBindingSource
            // 
            this.fuelCollectionBindingSource.DataSource = typeof(Data.Collections.Executable.Supplier.FuelCollection);
            // 
            // idDataGridViewTextBoxColumn6
            // 
            this.idDataGridViewTextBoxColumn6.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn6.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn6.Name = "idDataGridViewTextBoxColumn6";
            // 
            // localResourceIdDataGridViewTextBoxColumn6
            // 
            this.localResourceIdDataGridViewTextBoxColumn6.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn6.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn6.Name = "localResourceIdDataGridViewTextBoxColumn6";
            // 
            // resourceIdDataGridViewTextBoxColumn6
            // 
            this.resourceIdDataGridViewTextBoxColumn6.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn6.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn6.Name = "resourceIdDataGridViewTextBoxColumn6";
            // 
            // resourceTextDataGridViewTextBoxColumn6
            // 
            this.resourceTextDataGridViewTextBoxColumn6.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn6.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn6.Name = "resourceTextDataGridViewTextBoxColumn6";
            // 
            // lapsDataGridViewTextBoxColumn
            // 
            this.lapsDataGridViewTextBoxColumn.DataPropertyName = "Laps";
            this.lapsDataGridViewTextBoxColumn.HeaderText = "Laps";
            this.lapsDataGridViewTextBoxColumn.Name = "lapsDataGridViewTextBoxColumn";
            // 
            // designDataGridViewComboBoxColumn
            // 
            this.designDataGridViewComboBoxColumn.DataPropertyName = "Design";
            this.designDataGridViewComboBoxColumn.HeaderText = "Design";
            this.designDataGridViewComboBoxColumn.Name = "designDataGridViewComboBoxColumn";
            this.designDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.designDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lapRecordDriverDataGridViewComboBoxColumn
            // 
            this.lapRecordDriverDataGridViewComboBoxColumn.DataPropertyName = "LapRecordDriver";
            this.lapRecordDriverDataGridViewComboBoxColumn.HeaderText = "LapRecordDriver";
            this.lapRecordDriverDataGridViewComboBoxColumn.Name = "lapRecordDriverDataGridViewComboBoxColumn";
            this.lapRecordDriverDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lapRecordDriverDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lapRecordTeamDataGridViewComboBoxColumn
            // 
            this.lapRecordTeamDataGridViewComboBoxColumn.DataPropertyName = "LapRecordTeam";
            this.lapRecordTeamDataGridViewComboBoxColumn.HeaderText = "LapRecordTeam";
            this.lapRecordTeamDataGridViewComboBoxColumn.Name = "lapRecordTeamDataGridViewComboBoxColumn";
            this.lapRecordTeamDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lapRecordTeamDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lapRecordTimeDataGridViewTextBoxColumn
            // 
            this.lapRecordTimeDataGridViewTextBoxColumn.DataPropertyName = "LapRecordTime";
            this.lapRecordTimeDataGridViewTextBoxColumn.HeaderText = "LapRecordTime";
            this.lapRecordTimeDataGridViewTextBoxColumn.Name = "lapRecordTimeDataGridViewTextBoxColumn";
            // 
            // lapRecordMphDataGridViewTextBoxColumn
            // 
            this.lapRecordMphDataGridViewTextBoxColumn.DataPropertyName = "LapRecordMph";
            this.lapRecordMphDataGridViewTextBoxColumn.HeaderText = "LapRecordMph";
            this.lapRecordMphDataGridViewTextBoxColumn.Name = "lapRecordMphDataGridViewTextBoxColumn";
            // 
            // lapRecordYearDataGridViewTextBoxColumn
            // 
            this.lapRecordYearDataGridViewTextBoxColumn.DataPropertyName = "LapRecordYear";
            this.lapRecordYearDataGridViewTextBoxColumn.HeaderText = "LapRecordYear";
            this.lapRecordYearDataGridViewTextBoxColumn.Name = "lapRecordYearDataGridViewTextBoxColumn";
            // 
            // lastRaceDriverDataGridViewComboBoxColumn
            // 
            this.lastRaceDriverDataGridViewComboBoxColumn.DataPropertyName = "LastRaceDriver";
            this.lastRaceDriverDataGridViewComboBoxColumn.HeaderText = "LastRaceDriver";
            this.lastRaceDriverDataGridViewComboBoxColumn.Name = "lastRaceDriverDataGridViewComboBoxColumn";
            this.lastRaceDriverDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lastRaceDriverDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lastRaceTeamDataGridViewComboBoxColumn
            // 
            this.lastRaceTeamDataGridViewComboBoxColumn.DataPropertyName = "LastRaceTeam";
            this.lastRaceTeamDataGridViewComboBoxColumn.HeaderText = "LastRaceTeam";
            this.lastRaceTeamDataGridViewComboBoxColumn.Name = "lastRaceTeamDataGridViewComboBoxColumn";
            this.lastRaceTeamDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lastRaceTeamDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lastRaceYearDataGridViewTextBoxColumn
            // 
            this.lastRaceYearDataGridViewTextBoxColumn.DataPropertyName = "LastRaceYear";
            this.lastRaceYearDataGridViewTextBoxColumn.HeaderText = "LastRaceYear";
            this.lastRaceYearDataGridViewTextBoxColumn.Name = "lastRaceYearDataGridViewTextBoxColumn";
            // 
            // lastRaceTimeDataGridViewTextBoxColumn
            // 
            this.lastRaceTimeDataGridViewTextBoxColumn.DataPropertyName = "LastRaceTime";
            this.lastRaceTimeDataGridViewTextBoxColumn.HeaderText = "LastRaceTime";
            this.lastRaceTimeDataGridViewTextBoxColumn.Name = "lastRaceTimeDataGridViewTextBoxColumn";
            // 
            // hospitalityDataGridViewTextBoxColumn
            // 
            this.hospitalityDataGridViewTextBoxColumn.DataPropertyName = "Hospitality";
            this.hospitalityDataGridViewTextBoxColumn.HeaderText = "Hospitality";
            this.hospitalityDataGridViewTextBoxColumn.Name = "hospitalityDataGridViewTextBoxColumn";
            // 
            // speedDataGridViewTextBoxColumn1
            // 
            this.speedDataGridViewTextBoxColumn1.DataPropertyName = "Speed";
            this.speedDataGridViewTextBoxColumn1.HeaderText = "Speed";
            this.speedDataGridViewTextBoxColumn1.Name = "speedDataGridViewTextBoxColumn1";
            // 
            // gripDataGridViewTextBoxColumn
            // 
            this.gripDataGridViewTextBoxColumn.DataPropertyName = "Grip";
            this.gripDataGridViewTextBoxColumn.HeaderText = "Grip";
            this.gripDataGridViewTextBoxColumn.Name = "gripDataGridViewTextBoxColumn";
            // 
            // surfaceDataGridViewTextBoxColumn
            // 
            this.surfaceDataGridViewTextBoxColumn.DataPropertyName = "Surface";
            this.surfaceDataGridViewTextBoxColumn.HeaderText = "Surface";
            this.surfaceDataGridViewTextBoxColumn.Name = "surfaceDataGridViewTextBoxColumn";
            // 
            // tarmacDataGridViewTextBoxColumn
            // 
            this.tarmacDataGridViewTextBoxColumn.DataPropertyName = "Tarmac";
            this.tarmacDataGridViewTextBoxColumn.HeaderText = "Tarmac";
            this.tarmacDataGridViewTextBoxColumn.Name = "tarmacDataGridViewTextBoxColumn";
            // 
            // dustDataGridViewTextBoxColumn
            // 
            this.dustDataGridViewTextBoxColumn.DataPropertyName = "Dust";
            this.dustDataGridViewTextBoxColumn.HeaderText = "Dust";
            this.dustDataGridViewTextBoxColumn.Name = "dustDataGridViewTextBoxColumn";
            // 
            // overtakingDataGridViewTextBoxColumn1
            // 
            this.overtakingDataGridViewTextBoxColumn1.DataPropertyName = "Overtaking";
            this.overtakingDataGridViewTextBoxColumn1.HeaderText = "Overtaking";
            this.overtakingDataGridViewTextBoxColumn1.Name = "overtakingDataGridViewTextBoxColumn1";
            // 
            // brakingDataGridViewTextBoxColumn
            // 
            this.brakingDataGridViewTextBoxColumn.DataPropertyName = "Braking";
            this.brakingDataGridViewTextBoxColumn.HeaderText = "Braking";
            this.brakingDataGridViewTextBoxColumn.Name = "brakingDataGridViewTextBoxColumn";
            // 
            // rainDataGridViewTextBoxColumn
            // 
            this.rainDataGridViewTextBoxColumn.DataPropertyName = "Rain";
            this.rainDataGridViewTextBoxColumn.HeaderText = "Rain";
            this.rainDataGridViewTextBoxColumn.Name = "rainDataGridViewTextBoxColumn";
            // 
            // heatDataGridViewTextBoxColumn1
            // 
            this.heatDataGridViewTextBoxColumn1.DataPropertyName = "Heat";
            this.heatDataGridViewTextBoxColumn1.HeaderText = "Heat";
            this.heatDataGridViewTextBoxColumn1.Name = "heatDataGridViewTextBoxColumn1";
            // 
            // windDataGridViewTextBoxColumn
            // 
            this.windDataGridViewTextBoxColumn.DataPropertyName = "Wind";
            this.windDataGridViewTextBoxColumn.HeaderText = "Wind";
            this.windDataGridViewTextBoxColumn.Name = "windDataGridViewTextBoxColumn";
            // 
            // trackCollectionBindingSource
            // 
            this.trackCollectionBindingSource.DataSource = typeof(Data.Collections.Executable.Track.TrackCollection);
            // 
            // idDataGridViewTextBoxColumn10
            // 
            this.idDataGridViewTextBoxColumn10.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn10.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn10.Name = "idDataGridViewTextBoxColumn10";
            // 
            // localResourceIdDataGridViewTextBoxColumn10
            // 
            this.localResourceIdDataGridViewTextBoxColumn10.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn10.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn10.Name = "localResourceIdDataGridViewTextBoxColumn10";
            // 
            // resourceIdDataGridViewTextBoxColumn10
            // 
            this.resourceIdDataGridViewTextBoxColumn10.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn10.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn10.Name = "resourceIdDataGridViewTextBoxColumn10";
            // 
            // resourceTextDataGridViewTextBoxColumn10
            // 
            this.resourceTextDataGridViewTextBoxColumn10.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn10.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn10.Name = "resourceTextDataGridViewTextBoxColumn10";
            // 
            // value01DataGridViewTextBoxColumn3
            // 
            this.value01DataGridViewTextBoxColumn3.DataPropertyName = "Value01";
            this.value01DataGridViewTextBoxColumn3.HeaderText = "Value01";
            this.value01DataGridViewTextBoxColumn3.Name = "value01DataGridViewTextBoxColumn3";
            // 
            // value02DataGridViewTextBoxColumn3
            // 
            this.value02DataGridViewTextBoxColumn3.DataPropertyName = "Value02";
            this.value02DataGridViewTextBoxColumn3.HeaderText = "Value02";
            this.value02DataGridViewTextBoxColumn3.Name = "value02DataGridViewTextBoxColumn3";
            // 
            // value03DataGridViewTextBoxColumn3
            // 
            this.value03DataGridViewTextBoxColumn3.DataPropertyName = "Value03";
            this.value03DataGridViewTextBoxColumn3.HeaderText = "Value03";
            this.value03DataGridViewTextBoxColumn3.Name = "value03DataGridViewTextBoxColumn3";
            // 
            // value04DataGridViewTextBoxColumn3
            // 
            this.value04DataGridViewTextBoxColumn3.DataPropertyName = "Value04";
            this.value04DataGridViewTextBoxColumn3.HeaderText = "Value04";
            this.value04DataGridViewTextBoxColumn3.Name = "value04DataGridViewTextBoxColumn3";
            // 
            // value05DataGridViewTextBoxColumn3
            // 
            this.value05DataGridViewTextBoxColumn3.DataPropertyName = "Value05";
            this.value05DataGridViewTextBoxColumn3.HeaderText = "Value05";
            this.value05DataGridViewTextBoxColumn3.Name = "value05DataGridViewTextBoxColumn3";
            // 
            // value06DataGridViewTextBoxColumn
            // 
            this.value06DataGridViewTextBoxColumn.DataPropertyName = "Value06";
            this.value06DataGridViewTextBoxColumn.HeaderText = "Value06";
            this.value06DataGridViewTextBoxColumn.Name = "value06DataGridViewTextBoxColumn";
            // 
            // value07DataGridViewTextBoxColumn
            // 
            this.value07DataGridViewTextBoxColumn.DataPropertyName = "Value07";
            this.value07DataGridViewTextBoxColumn.HeaderText = "Value07";
            this.value07DataGridViewTextBoxColumn.Name = "value07DataGridViewTextBoxColumn";
            // 
            // value08DataGridViewTextBoxColumn
            // 
            this.value08DataGridViewTextBoxColumn.DataPropertyName = "Value08";
            this.value08DataGridViewTextBoxColumn.HeaderText = "Value08";
            this.value08DataGridViewTextBoxColumn.Name = "value08DataGridViewTextBoxColumn";
            // 
            // value09DataGridViewTextBoxColumn
            // 
            this.value09DataGridViewTextBoxColumn.DataPropertyName = "Value09";
            this.value09DataGridViewTextBoxColumn.HeaderText = "Value09";
            this.value09DataGridViewTextBoxColumn.Name = "value09DataGridViewTextBoxColumn";
            // 
            // value10DataGridViewTextBoxColumn
            // 
            this.value10DataGridViewTextBoxColumn.DataPropertyName = "Value10";
            this.value10DataGridViewTextBoxColumn.HeaderText = "Value10";
            this.value10DataGridViewTextBoxColumn.Name = "value10DataGridViewTextBoxColumn";
            // 
            // tenValueCollectionBindingSource
            // 
            this.tenValueCollectionBindingSource.DataSource = typeof(Data.Collections.Generic.TenValueCollection);
            // 
            // idDataGridViewTextBoxColumn9
            // 
            this.idDataGridViewTextBoxColumn9.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn9.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn9.Name = "idDataGridViewTextBoxColumn9";
            // 
            // localResourceIdDataGridViewTextBoxColumn9
            // 
            this.localResourceIdDataGridViewTextBoxColumn9.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn9.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn9.Name = "localResourceIdDataGridViewTextBoxColumn9";
            // 
            // resourceIdDataGridViewTextBoxColumn9
            // 
            this.resourceIdDataGridViewTextBoxColumn9.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn9.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn9.Name = "resourceIdDataGridViewTextBoxColumn9";
            // 
            // resourceTextDataGridViewTextBoxColumn9
            // 
            this.resourceTextDataGridViewTextBoxColumn9.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn9.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn9.Name = "resourceTextDataGridViewTextBoxColumn9";
            // 
            // value01DataGridViewTextBoxColumn2
            // 
            this.value01DataGridViewTextBoxColumn2.DataPropertyName = "Value01";
            this.value01DataGridViewTextBoxColumn2.HeaderText = "Value01";
            this.value01DataGridViewTextBoxColumn2.Name = "value01DataGridViewTextBoxColumn2";
            // 
            // value02DataGridViewTextBoxColumn2
            // 
            this.value02DataGridViewTextBoxColumn2.DataPropertyName = "Value02";
            this.value02DataGridViewTextBoxColumn2.HeaderText = "Value02";
            this.value02DataGridViewTextBoxColumn2.Name = "value02DataGridViewTextBoxColumn2";
            // 
            // value03DataGridViewTextBoxColumn2
            // 
            this.value03DataGridViewTextBoxColumn2.DataPropertyName = "Value03";
            this.value03DataGridViewTextBoxColumn2.HeaderText = "Value03";
            this.value03DataGridViewTextBoxColumn2.Name = "value03DataGridViewTextBoxColumn2";
            // 
            // value04DataGridViewTextBoxColumn2
            // 
            this.value04DataGridViewTextBoxColumn2.DataPropertyName = "Value04";
            this.value04DataGridViewTextBoxColumn2.HeaderText = "Value04";
            this.value04DataGridViewTextBoxColumn2.Name = "value04DataGridViewTextBoxColumn2";
            // 
            // value05DataGridViewTextBoxColumn2
            // 
            this.value05DataGridViewTextBoxColumn2.DataPropertyName = "Value05";
            this.value05DataGridViewTextBoxColumn2.HeaderText = "Value05";
            this.value05DataGridViewTextBoxColumn2.Name = "value05DataGridViewTextBoxColumn2";
            // 
            // fiveRatingCollectionBindingSource
            // 
            this.fiveRatingCollectionBindingSource.DataSource = typeof(Data.Collections.Generic.FiveRatingCollection);
            // 
            // idDataGridViewTextBoxColumn8
            // 
            this.idDataGridViewTextBoxColumn8.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn8.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn8.Name = "idDataGridViewTextBoxColumn8";
            // 
            // localResourceIdDataGridViewTextBoxColumn8
            // 
            this.localResourceIdDataGridViewTextBoxColumn8.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn8.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn8.Name = "localResourceIdDataGridViewTextBoxColumn8";
            // 
            // resourceIdDataGridViewTextBoxColumn8
            // 
            this.resourceIdDataGridViewTextBoxColumn8.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn8.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn8.Name = "resourceIdDataGridViewTextBoxColumn8";
            // 
            // resourceTextDataGridViewTextBoxColumn8
            // 
            this.resourceTextDataGridViewTextBoxColumn8.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn8.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn8.Name = "resourceTextDataGridViewTextBoxColumn8";
            // 
            // value01DataGridViewTextBoxColumn1
            // 
            this.value01DataGridViewTextBoxColumn1.DataPropertyName = "Value01";
            this.value01DataGridViewTextBoxColumn1.HeaderText = "Value01";
            this.value01DataGridViewTextBoxColumn1.Name = "value01DataGridViewTextBoxColumn1";
            // 
            // value02DataGridViewTextBoxColumn1
            // 
            this.value02DataGridViewTextBoxColumn1.DataPropertyName = "Value02";
            this.value02DataGridViewTextBoxColumn1.HeaderText = "Value02";
            this.value02DataGridViewTextBoxColumn1.Name = "value02DataGridViewTextBoxColumn1";
            // 
            // value03DataGridViewTextBoxColumn1
            // 
            this.value03DataGridViewTextBoxColumn1.DataPropertyName = "Value03";
            this.value03DataGridViewTextBoxColumn1.HeaderText = "Value03";
            this.value03DataGridViewTextBoxColumn1.Name = "value03DataGridViewTextBoxColumn1";
            // 
            // value04DataGridViewTextBoxColumn1
            // 
            this.value04DataGridViewTextBoxColumn1.DataPropertyName = "Value04";
            this.value04DataGridViewTextBoxColumn1.HeaderText = "Value04";
            this.value04DataGridViewTextBoxColumn1.Name = "value04DataGridViewTextBoxColumn1";
            // 
            // value05DataGridViewTextBoxColumn1
            // 
            this.value05DataGridViewTextBoxColumn1.DataPropertyName = "Value05";
            this.value05DataGridViewTextBoxColumn1.HeaderText = "Value05";
            this.value05DataGridViewTextBoxColumn1.Name = "value05DataGridViewTextBoxColumn1";
            // 
            // idDataGridViewTextBoxColumn7
            // 
            this.idDataGridViewTextBoxColumn7.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn7.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn7.Name = "idDataGridViewTextBoxColumn7";
            // 
            // localResourceIdDataGridViewTextBoxColumn7
            // 
            this.localResourceIdDataGridViewTextBoxColumn7.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn7.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn7.Name = "localResourceIdDataGridViewTextBoxColumn7";
            // 
            // resourceIdDataGridViewTextBoxColumn7
            // 
            this.resourceIdDataGridViewTextBoxColumn7.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn7.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn7.Name = "resourceIdDataGridViewTextBoxColumn7";
            // 
            // resourceTextDataGridViewTextBoxColumn7
            // 
            this.resourceTextDataGridViewTextBoxColumn7.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn7.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn7.Name = "resourceTextDataGridViewTextBoxColumn7";
            // 
            // value01DataGridViewTextBoxColumn
            // 
            this.value01DataGridViewTextBoxColumn.DataPropertyName = "Value01";
            this.value01DataGridViewTextBoxColumn.HeaderText = "Value01";
            this.value01DataGridViewTextBoxColumn.Name = "value01DataGridViewTextBoxColumn";
            // 
            // value02DataGridViewTextBoxColumn
            // 
            this.value02DataGridViewTextBoxColumn.DataPropertyName = "Value02";
            this.value02DataGridViewTextBoxColumn.HeaderText = "Value02";
            this.value02DataGridViewTextBoxColumn.Name = "value02DataGridViewTextBoxColumn";
            // 
            // value03DataGridViewTextBoxColumn
            // 
            this.value03DataGridViewTextBoxColumn.DataPropertyName = "Value03";
            this.value03DataGridViewTextBoxColumn.HeaderText = "Value03";
            this.value03DataGridViewTextBoxColumn.Name = "value03DataGridViewTextBoxColumn";
            // 
            // value04DataGridViewTextBoxColumn
            // 
            this.value04DataGridViewTextBoxColumn.DataPropertyName = "Value04";
            this.value04DataGridViewTextBoxColumn.HeaderText = "Value04";
            this.value04DataGridViewTextBoxColumn.Name = "value04DataGridViewTextBoxColumn";
            // 
            // value05DataGridViewTextBoxColumn
            // 
            this.value05DataGridViewTextBoxColumn.DataPropertyName = "Value05";
            this.value05DataGridViewTextBoxColumn.HeaderText = "Value05";
            this.value05DataGridViewTextBoxColumn.Name = "value05DataGridViewTextBoxColumn";
            // 
            // fiveValueCollectionBindingSource
            // 
            this.fiveValueCollectionBindingSource.DataSource = typeof(Data.Collections.Generic.FiveValueCollection);
            // 
            // idDataGridViewTextBoxColumn14
            // 
            this.idDataGridViewTextBoxColumn14.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn14.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn14.Name = "idDataGridViewTextBoxColumn14";
            // 
            // localResourceIdDataGridViewTextBoxColumn14
            // 
            this.localResourceIdDataGridViewTextBoxColumn14.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn14.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn14.Name = "localResourceIdDataGridViewTextBoxColumn14";
            // 
            // resourceIdDataGridViewTextBoxColumn14
            // 
            this.resourceIdDataGridViewTextBoxColumn14.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn14.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn14.Name = "resourceIdDataGridViewTextBoxColumn14";
            // 
            // resourceTextDataGridViewTextBoxColumn14
            // 
            this.resourceTextDataGridViewTextBoxColumn14.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn14.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn14.Name = "resourceTextDataGridViewTextBoxColumn14";
            // 
            // valueDataGridViewTextBoxColumn1
            // 
            this.valueDataGridViewTextBoxColumn1.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn1.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn1.Name = "valueDataGridViewTextBoxColumn1";
            // 
            // singleValueCollectionBindingSource
            // 
            this.singleValueCollectionBindingSource.DataSource = typeof(Data.Collections.Generic.SingleValueCollection);
            // 
            // idDataGridViewTextBoxColumn13
            // 
            this.idDataGridViewTextBoxColumn13.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn13.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn13.Name = "idDataGridViewTextBoxColumn13";
            // 
            // localResourceIdDataGridViewTextBoxColumn13
            // 
            this.localResourceIdDataGridViewTextBoxColumn13.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn13.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn13.Name = "localResourceIdDataGridViewTextBoxColumn13";
            // 
            // resourceIdDataGridViewTextBoxColumn13
            // 
            this.resourceIdDataGridViewTextBoxColumn13.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn13.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn13.Name = "resourceIdDataGridViewTextBoxColumn13";
            // 
            // resourceTextDataGridViewTextBoxColumn13
            // 
            this.resourceTextDataGridViewTextBoxColumn13.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn13.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn13.Name = "resourceTextDataGridViewTextBoxColumn13";
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // idDataGridViewTextBoxColumn12
            // 
            this.idDataGridViewTextBoxColumn12.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn12.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn12.Name = "idDataGridViewTextBoxColumn12";
            // 
            // localResourceIdDataGridViewTextBoxColumn12
            // 
            this.localResourceIdDataGridViewTextBoxColumn12.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn12.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn12.Name = "localResourceIdDataGridViewTextBoxColumn12";
            // 
            // resourceIdDataGridViewTextBoxColumn12
            // 
            this.resourceIdDataGridViewTextBoxColumn12.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn12.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn12.Name = "resourceIdDataGridViewTextBoxColumn12";
            // 
            // resourceTextDataGridViewTextBoxColumn12
            // 
            this.resourceTextDataGridViewTextBoxColumn12.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn12.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn12.Name = "resourceTextDataGridViewTextBoxColumn12";
            // 
            // value01DataGridViewTextBoxColumn5
            // 
            this.value01DataGridViewTextBoxColumn5.DataPropertyName = "Value01";
            this.value01DataGridViewTextBoxColumn5.HeaderText = "Value01";
            this.value01DataGridViewTextBoxColumn5.Name = "value01DataGridViewTextBoxColumn5";
            // 
            // value02DataGridViewTextBoxColumn5
            // 
            this.value02DataGridViewTextBoxColumn5.DataPropertyName = "Value02";
            this.value02DataGridViewTextBoxColumn5.HeaderText = "Value02";
            this.value02DataGridViewTextBoxColumn5.Name = "value02DataGridViewTextBoxColumn5";
            // 
            // value03DataGridViewTextBoxColumn5
            // 
            this.value03DataGridViewTextBoxColumn5.DataPropertyName = "Value03";
            this.value03DataGridViewTextBoxColumn5.HeaderText = "Value03";
            this.value03DataGridViewTextBoxColumn5.Name = "value03DataGridViewTextBoxColumn5";
            // 
            // value04DataGridViewTextBoxColumn5
            // 
            this.value04DataGridViewTextBoxColumn5.DataPropertyName = "Value04";
            this.value04DataGridViewTextBoxColumn5.HeaderText = "Value04";
            this.value04DataGridViewTextBoxColumn5.Name = "value04DataGridViewTextBoxColumn5";
            // 
            // value05DataGridViewTextBoxColumn5
            // 
            this.value05DataGridViewTextBoxColumn5.DataPropertyName = "Value05";
            this.value05DataGridViewTextBoxColumn5.HeaderText = "Value05";
            this.value05DataGridViewTextBoxColumn5.Name = "value05DataGridViewTextBoxColumn5";
            // 
            // value06DataGridViewTextBoxColumn1
            // 
            this.value06DataGridViewTextBoxColumn1.DataPropertyName = "Value06";
            this.value06DataGridViewTextBoxColumn1.HeaderText = "Value06";
            this.value06DataGridViewTextBoxColumn1.Name = "value06DataGridViewTextBoxColumn1";
            // 
            // value07DataGridViewTextBoxColumn1
            // 
            this.value07DataGridViewTextBoxColumn1.DataPropertyName = "Value07";
            this.value07DataGridViewTextBoxColumn1.HeaderText = "Value07";
            this.value07DataGridViewTextBoxColumn1.Name = "value07DataGridViewTextBoxColumn1";
            // 
            // value08DataGridViewTextBoxColumn1
            // 
            this.value08DataGridViewTextBoxColumn1.DataPropertyName = "Value08";
            this.value08DataGridViewTextBoxColumn1.HeaderText = "Value08";
            this.value08DataGridViewTextBoxColumn1.Name = "value08DataGridViewTextBoxColumn1";
            // 
            // value09DataGridViewTextBoxColumn1
            // 
            this.value09DataGridViewTextBoxColumn1.DataPropertyName = "Value09";
            this.value09DataGridViewTextBoxColumn1.HeaderText = "Value09";
            this.value09DataGridViewTextBoxColumn1.Name = "value09DataGridViewTextBoxColumn1";
            // 
            // value10DataGridViewTextBoxColumn1
            // 
            this.value10DataGridViewTextBoxColumn1.DataPropertyName = "Value10";
            this.value10DataGridViewTextBoxColumn1.HeaderText = "Value10";
            this.value10DataGridViewTextBoxColumn1.Name = "value10DataGridViewTextBoxColumn1";
            // 
            // idDataGridViewTextBoxColumn11
            // 
            this.idDataGridViewTextBoxColumn11.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn11.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn11.Name = "idDataGridViewTextBoxColumn11";
            // 
            // localResourceIdDataGridViewTextBoxColumn11
            // 
            this.localResourceIdDataGridViewTextBoxColumn11.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn11.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn11.Name = "localResourceIdDataGridViewTextBoxColumn11";
            // 
            // resourceIdDataGridViewTextBoxColumn11
            // 
            this.resourceIdDataGridViewTextBoxColumn11.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn11.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn11.Name = "resourceIdDataGridViewTextBoxColumn11";
            // 
            // resourceTextDataGridViewTextBoxColumn11
            // 
            this.resourceTextDataGridViewTextBoxColumn11.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn11.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn11.Name = "resourceTextDataGridViewTextBoxColumn11";
            // 
            // value01DataGridViewTextBoxColumn4
            // 
            this.value01DataGridViewTextBoxColumn4.DataPropertyName = "Value01";
            this.value01DataGridViewTextBoxColumn4.HeaderText = "Value01";
            this.value01DataGridViewTextBoxColumn4.Name = "value01DataGridViewTextBoxColumn4";
            // 
            // value02DataGridViewTextBoxColumn4
            // 
            this.value02DataGridViewTextBoxColumn4.DataPropertyName = "Value02";
            this.value02DataGridViewTextBoxColumn4.HeaderText = "Value02";
            this.value02DataGridViewTextBoxColumn4.Name = "value02DataGridViewTextBoxColumn4";
            // 
            // value03DataGridViewTextBoxColumn4
            // 
            this.value03DataGridViewTextBoxColumn4.DataPropertyName = "Value03";
            this.value03DataGridViewTextBoxColumn4.HeaderText = "Value03";
            this.value03DataGridViewTextBoxColumn4.Name = "value03DataGridViewTextBoxColumn4";
            // 
            // value04DataGridViewTextBoxColumn4
            // 
            this.value04DataGridViewTextBoxColumn4.DataPropertyName = "Value04";
            this.value04DataGridViewTextBoxColumn4.HeaderText = "Value04";
            this.value04DataGridViewTextBoxColumn4.Name = "value04DataGridViewTextBoxColumn4";
            // 
            // value05DataGridViewTextBoxColumn4
            // 
            this.value05DataGridViewTextBoxColumn4.DataPropertyName = "Value05";
            this.value05DataGridViewTextBoxColumn4.HeaderText = "Value05";
            this.value05DataGridViewTextBoxColumn4.Name = "value05DataGridViewTextBoxColumn4";
            // 
            // idDataGridViewTextBoxColumn15
            // 
            this.idDataGridViewTextBoxColumn15.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn15.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn15.Name = "idDataGridViewTextBoxColumn15";
            // 
            // localResourceIdDataGridViewTextBoxColumn15
            // 
            this.localResourceIdDataGridViewTextBoxColumn15.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn15.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn15.Name = "localResourceIdDataGridViewTextBoxColumn15";
            // 
            // resourceIdDataGridViewTextBoxColumn15
            // 
            this.resourceIdDataGridViewTextBoxColumn15.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn15.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn15.Name = "resourceIdDataGridViewTextBoxColumn15";
            // 
            // resourceTextDataGridViewTextBoxColumn15
            // 
            this.resourceTextDataGridViewTextBoxColumn15.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn15.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn15.Name = "resourceTextDataGridViewTextBoxColumn15";
            // 
            // salaryDataGridViewTextBoxColumn1
            // 
            this.salaryDataGridViewTextBoxColumn1.DataPropertyName = "Salary";
            this.salaryDataGridViewTextBoxColumn1.HeaderText = "Salary";
            this.salaryDataGridViewTextBoxColumn1.Name = "salaryDataGridViewTextBoxColumn1";
            // 
            // raceBonusDataGridViewTextBoxColumn1
            // 
            this.raceBonusDataGridViewTextBoxColumn1.DataPropertyName = "RaceBonus";
            this.raceBonusDataGridViewTextBoxColumn1.HeaderText = "RaceBonus";
            this.raceBonusDataGridViewTextBoxColumn1.Name = "raceBonusDataGridViewTextBoxColumn1";
            // 
            // championshipBonusDataGridViewTextBoxColumn1
            // 
            this.championshipBonusDataGridViewTextBoxColumn1.DataPropertyName = "ChampionshipBonus";
            this.championshipBonusDataGridViewTextBoxColumn1.HeaderText = "ChampionshipBonus";
            this.championshipBonusDataGridViewTextBoxColumn1.Name = "championshipBonusDataGridViewTextBoxColumn1";
            // 
            // ageDataGridViewTextBoxColumn1
            // 
            this.ageDataGridViewTextBoxColumn1.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn1.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn1.Name = "ageDataGridViewTextBoxColumn1";
            // 
            // nationalityDataGridViewTextBoxColumn
            // 
            this.nationalityDataGridViewTextBoxColumn.DataPropertyName = "Nationality";
            this.nationalityDataGridViewTextBoxColumn.HeaderText = "Nationality";
            this.nationalityDataGridViewTextBoxColumn.Name = "nationalityDataGridViewTextBoxColumn";
            // 
            // unknownDataGridViewTextBoxColumn1
            // 
            this.unknownDataGridViewTextBoxColumn1.DataPropertyName = "Unknown";
            this.unknownDataGridViewTextBoxColumn1.HeaderText = "Unknown";
            this.unknownDataGridViewTextBoxColumn1.Name = "unknownDataGridViewTextBoxColumn1";
            // 
            // speedDataGridViewTextBoxColumn2
            // 
            this.speedDataGridViewTextBoxColumn2.DataPropertyName = "Speed";
            this.speedDataGridViewTextBoxColumn2.HeaderText = "Speed";
            this.speedDataGridViewTextBoxColumn2.Name = "speedDataGridViewTextBoxColumn2";
            // 
            // skillDataGridViewTextBoxColumn1
            // 
            this.skillDataGridViewTextBoxColumn1.DataPropertyName = "Skill";
            this.skillDataGridViewTextBoxColumn1.HeaderText = "Skill";
            this.skillDataGridViewTextBoxColumn1.Name = "skillDataGridViewTextBoxColumn1";
            // 
            // overtakingDataGridViewTextBoxColumn2
            // 
            this.overtakingDataGridViewTextBoxColumn2.DataPropertyName = "Overtaking";
            this.overtakingDataGridViewTextBoxColumn2.HeaderText = "Overtaking";
            this.overtakingDataGridViewTextBoxColumn2.Name = "overtakingDataGridViewTextBoxColumn2";
            // 
            // wetWeatherDataGridViewTextBoxColumn1
            // 
            this.wetWeatherDataGridViewTextBoxColumn1.DataPropertyName = "WetWeather";
            this.wetWeatherDataGridViewTextBoxColumn1.HeaderText = "WetWeather";
            this.wetWeatherDataGridViewTextBoxColumn1.Name = "wetWeatherDataGridViewTextBoxColumn1";
            // 
            // concentrationDataGridViewTextBoxColumn1
            // 
            this.concentrationDataGridViewTextBoxColumn1.DataPropertyName = "Concentration";
            this.concentrationDataGridViewTextBoxColumn1.HeaderText = "Concentration";
            this.concentrationDataGridViewTextBoxColumn1.Name = "concentrationDataGridViewTextBoxColumn1";
            // 
            // experienceDataGridViewTextBoxColumn1
            // 
            this.experienceDataGridViewTextBoxColumn1.DataPropertyName = "Experience";
            this.experienceDataGridViewTextBoxColumn1.HeaderText = "Experience";
            this.experienceDataGridViewTextBoxColumn1.Name = "experienceDataGridViewTextBoxColumn1";
            // 
            // staminaDataGridViewTextBoxColumn1
            // 
            this.staminaDataGridViewTextBoxColumn1.DataPropertyName = "Stamina";
            this.staminaDataGridViewTextBoxColumn1.HeaderText = "Stamina";
            this.staminaDataGridViewTextBoxColumn1.Name = "staminaDataGridViewTextBoxColumn1";
            // 
            // moraleDataGridViewTextBoxColumn1
            // 
            this.moraleDataGridViewTextBoxColumn1.DataPropertyName = "Morale";
            this.moraleDataGridViewTextBoxColumn1.HeaderText = "Morale";
            this.moraleDataGridViewTextBoxColumn1.Name = "moraleDataGridViewTextBoxColumn1";
            // 
            // nonF1DriverCollectionBindingSource
            // 
            this.nonF1DriverCollectionBindingSource.DataSource = typeof(Data.Collections.Executable.Team.NonF1DriverCollection);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.NonF1ChiefsDataGridView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(688, 470);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // NonF1ChiefsDataGridView
            // 
            this.NonF1ChiefsDataGridView.AutoGenerateColumns = false;
            this.NonF1ChiefsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NonF1ChiefsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn16,
            this.localResourceIdDataGridViewTextBoxColumn16,
            this.resourceIdDataGridViewTextBoxColumn16,
            this.resourceTextDataGridViewTextBoxColumn16,
            this.salaryDataGridViewTextBoxColumn2,
            this.raceBonusDataGridViewTextBoxColumn2,
            this.championshipBonusDataGridViewTextBoxColumn2,
            this.royaltyDataGridViewTextBoxColumn,
            this.ageDataGridViewTextBoxColumn2,
            this.abilityDataGridViewTextBoxColumn});
            this.NonF1ChiefsDataGridView.DataSource = this.nonF1ChiefCollectionBindingSource;
            this.NonF1ChiefsDataGridView.Location = new System.Drawing.Point(6, 6);
            this.NonF1ChiefsDataGridView.Name = "NonF1ChiefsDataGridView";
            this.NonF1ChiefsDataGridView.Size = new System.Drawing.Size(676, 458);
            this.NonF1ChiefsDataGridView.TabIndex = 0;
            // 
            // nonF1ChiefCollectionBindingSource
            // 
            this.nonF1ChiefCollectionBindingSource.DataSource = typeof(Data.Collections.Executable.Team.NonF1ChiefCollection);
            // 
            // idDataGridViewTextBoxColumn16
            // 
            this.idDataGridViewTextBoxColumn16.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn16.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn16.Name = "idDataGridViewTextBoxColumn16";
            // 
            // localResourceIdDataGridViewTextBoxColumn16
            // 
            this.localResourceIdDataGridViewTextBoxColumn16.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn16.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn16.Name = "localResourceIdDataGridViewTextBoxColumn16";
            // 
            // resourceIdDataGridViewTextBoxColumn16
            // 
            this.resourceIdDataGridViewTextBoxColumn16.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn16.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn16.Name = "resourceIdDataGridViewTextBoxColumn16";
            // 
            // resourceTextDataGridViewTextBoxColumn16
            // 
            this.resourceTextDataGridViewTextBoxColumn16.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn16.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn16.Name = "resourceTextDataGridViewTextBoxColumn16";
            // 
            // salaryDataGridViewTextBoxColumn2
            // 
            this.salaryDataGridViewTextBoxColumn2.DataPropertyName = "Salary";
            this.salaryDataGridViewTextBoxColumn2.HeaderText = "Salary";
            this.salaryDataGridViewTextBoxColumn2.Name = "salaryDataGridViewTextBoxColumn2";
            // 
            // raceBonusDataGridViewTextBoxColumn2
            // 
            this.raceBonusDataGridViewTextBoxColumn2.DataPropertyName = "RaceBonus";
            this.raceBonusDataGridViewTextBoxColumn2.HeaderText = "RaceBonus";
            this.raceBonusDataGridViewTextBoxColumn2.Name = "raceBonusDataGridViewTextBoxColumn2";
            // 
            // championshipBonusDataGridViewTextBoxColumn2
            // 
            this.championshipBonusDataGridViewTextBoxColumn2.DataPropertyName = "ChampionshipBonus";
            this.championshipBonusDataGridViewTextBoxColumn2.HeaderText = "ChampionshipBonus";
            this.championshipBonusDataGridViewTextBoxColumn2.Name = "championshipBonusDataGridViewTextBoxColumn2";
            // 
            // royaltyDataGridViewTextBoxColumn
            // 
            this.royaltyDataGridViewTextBoxColumn.DataPropertyName = "Royalty";
            this.royaltyDataGridViewTextBoxColumn.HeaderText = "Royalty";
            this.royaltyDataGridViewTextBoxColumn.Name = "royaltyDataGridViewTextBoxColumn";
            // 
            // ageDataGridViewTextBoxColumn2
            // 
            this.ageDataGridViewTextBoxColumn2.DataPropertyName = "Age";
            this.ageDataGridViewTextBoxColumn2.HeaderText = "Age";
            this.ageDataGridViewTextBoxColumn2.Name = "ageDataGridViewTextBoxColumn2";
            // 
            // abilityDataGridViewTextBoxColumn
            // 
            this.abilityDataGridViewTextBoxColumn.DataPropertyName = "Ability";
            this.abilityDataGridViewTextBoxColumn.HeaderText = "Ability";
            this.abilityDataGridViewTextBoxColumn.Name = "abilityDataGridViewTextBoxColumn";
            // 
            // GameExecutableEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 513);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameExecutableEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameExecutableEditorForm_FormClosing);
            this.Load += new System.EventHandler(this.GameExecutableEditorForm_Load);
            this.MainTabControl.ResumeLayout(false);
            this.HomeTabPage.ResumeLayout(false);
            this.FilesGroupBox.ResumeLayout(false);
            this.FilesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LanguageDataGridView)).EndInit();
            this.TeamsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TeamsDataGridView)).EndInit();
            this.DriversTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DriversDataGridView)).EndInit();
            this.EnginesTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EnginesDataGridView)).EndInit();
            this.TyresTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TyresDataGridView)).EndInit();
            this.FuelsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FuelsDataGridView)).EndInit();
            this.TracksTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TracksDataGridView)).EndInit();
            this.RacePerformanceTabPage.ResumeLayout(false);
            this.RacePerformanceGroupBox.ResumeLayout(false);
            this.RacePerformanceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox000NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox120NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox070NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox060NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox020NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox040NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox080NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox030NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox090NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox050NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox100NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox010NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChartBox110NumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RacePerformanceChart)).EndInit();
            this.MiscTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TestingMilesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaffSalariesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactoryExpansionCostsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactoryRunningCostsDataGridView)).EndInit();
            this.EngineeringTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UnknownBDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnknownADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EngineeringCostsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StaffEffortsDataGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NonF1DriversDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.identityCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tyreCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenValueCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiveRatingCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiveValueCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleValueCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonF1DriverCollectionBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NonF1ChiefsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nonF1ChiefCollectionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ProgramOpenFileDialog;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage HomeTabPage;
        private System.Windows.Forms.GroupBox FilesGroupBox;
        private System.Windows.Forms.Label LanguageFilePathLabel;
        private System.Windows.Forms.TextBox LanguageFilePathTextBox;
        private System.Windows.Forms.Button BrowseLanguageFileButton;
        private System.Windows.Forms.Label GameExecutablePathLabel;
        private System.Windows.Forms.TextBox GameExecutablePathTextBox;
        private System.Windows.Forms.Button BrowseGameExecutableButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.DataGridView LanguageDataGridView;
        private System.Windows.Forms.BindingSource identityCollectionBindingSource;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TabPage TeamsTabPage;
        private System.Windows.Forms.DataGridView TeamsDataGridView;
        private System.Windows.Forms.BindingSource teamCollectionBindingSource;
        private System.Windows.Forms.TabPage DriversTabPage;
        private System.Windows.Forms.DataGridView DriversDataGridView;
        private System.Windows.Forms.BindingSource driverCollectionBindingSource;
        private System.Windows.Forms.TabPage EnginesTabPage;
        private System.Windows.Forms.DataGridView EnginesDataGridView;
        private System.Windows.Forms.BindingSource engineCollectionBindingSource;
        private System.Windows.Forms.TabPage TyresTabPage;
        private System.Windows.Forms.DataGridView TyresDataGridView;
        private System.Windows.Forms.BindingSource tyreCollectionBindingSource;
        private System.Windows.Forms.TabPage FuelsTabPage;
        private System.Windows.Forms.DataGridView FuelsDataGridView;
        private System.Windows.Forms.BindingSource fuelCollectionBindingSource;
        private System.Windows.Forms.TabPage TracksTabPage;
        private System.Windows.Forms.DataGridView TracksDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn powerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reliabilityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn responseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rigidityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dryHardGripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dryHardResilienceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dryHardStiffnessDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dryHardTemperatureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn drySoftGripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn drySoftResilienceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn drySoftStiffnessDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn drySoftTemperatureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn intermediateGripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn intermediateResilienceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn intermediateStiffnessDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn intermediateTemperatureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wetWeatherGripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wetWeatherResilienceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wetWeatherStiffnessDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wetWeatherTemperatureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn performanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toleranceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn salaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn raceBonusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn championshipBonusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn payRatingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positiveSalaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastChampionshipPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driverRoleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn nationalityDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn careerChampionshipsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn careerRacesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn careerWinsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn careerPointsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn careerFastestLapsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn careerPointsFinishesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn careerPolePositionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn skillDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn overtakingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wetWeatherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn concentrationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn experienceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn staminaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moraleDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage RacePerformanceTabPage;
        private System.Windows.Forms.DataVisualization.Charting.Chart RacePerformanceChart;
        private System.Windows.Forms.NumericUpDown RacePerformanceChartBox020NumericUpDown;
        private System.Windows.Forms.NumericUpDown RacePerformanceChartBox010NumericUpDown;
        private System.Windows.Forms.NumericUpDown RacePerformanceChartBox000NumericUpDown;
        private System.Windows.Forms.NumericUpDown RacePerformanceChartBox080NumericUpDown;
        private System.Windows.Forms.NumericUpDown RacePerformanceChartBox090NumericUpDown;
        private System.Windows.Forms.NumericUpDown RacePerformanceChartBox100NumericUpDown;
        private System.Windows.Forms.NumericUpDown RacePerformanceChartBox110NumericUpDown;
        private System.Windows.Forms.NumericUpDown RacePerformanceChartBox050NumericUpDown;
        private System.Windows.Forms.NumericUpDown RacePerformanceChartBox030NumericUpDown;
        private System.Windows.Forms.NumericUpDown RacePerformanceChartBox040NumericUpDown;
        private System.Windows.Forms.NumericUpDown RacePerformanceChartBox060NumericUpDown;
        private System.Windows.Forms.NumericUpDown RacePerformanceChartBox070NumericUpDown;
        private System.Windows.Forms.NumericUpDown RacePerformanceChartBox120NumericUpDown;
        private System.Windows.Forms.Button RacePerformanceSoftenCurveButton;
        private System.Windows.Forms.Button RacePerformanceCopyCurrentButton;
        private System.Windows.Forms.Button RacePerformanceCopyDefaultButton;
        private System.Windows.Forms.GroupBox RacePerformanceGroupBox;
        private System.Windows.Forms.Button RacePerformanceEditButton;
        private System.Windows.Forms.CheckBox RacePerformanceCurrentCheckBox;
        private System.Windows.Forms.CheckBox RacePerformanceDefaultCheckBox;
        private System.Windows.Forms.CheckBox RacePerformanceProposedCheckBox;
        private System.Windows.Forms.Button RacePerformanceCopyRecommendedButton;
        private System.Windows.Forms.TabPage MiscTabPage;
        private System.Windows.Forms.DataGridView StaffSalariesDataGridView;
        private System.Windows.Forms.DataGridView FactoryExpansionCostsDataGridView;
        private System.Windows.Forms.DataGridView FactoryRunningCostsDataGridView;
        private System.Windows.Forms.BindingSource trackCollectionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn lapsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn designDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn lapRecordDriverDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn lapRecordTeamDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lapRecordTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lapRecordMphDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lapRecordYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn lastRaceDriverDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn lastRaceTeamDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastRaceYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastRaceTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hospitalityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speedDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn surfaceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarmacDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dustDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn overtakingDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn brakingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rainDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heatDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn windDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource tenValueCollectionBindingSource;
        private System.Windows.Forms.BindingSource fiveValueCollectionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn value01DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn value02DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn value03DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn value04DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn value05DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView TestingMilesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn value01DataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn value02DataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn value03DataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn value04DataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn value05DataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn value06DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn value07DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn value08DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn value09DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn value10DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn value01DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn value02DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn value03DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn value04DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn value05DataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource fiveRatingCollectionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn value01DataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn value02DataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn value03DataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn value04DataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn value05DataGridViewTextBoxColumn2;
        private System.Windows.Forms.TabPage EngineeringTabPage;
        private System.Windows.Forms.DataGridView StaffEffortsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn value01DataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn value02DataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn value03DataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn value04DataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn value05DataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView EngineeringCostsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn value01DataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn value02DataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn value03DataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn value04DataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn value05DataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn value06DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn value07DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn value08DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn value09DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn value10DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView UnknownBDataGridView;
        private System.Windows.Forms.DataGridView UnknownADataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource singleValueCollectionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPointsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn firstGpTrackDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstGpYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn winsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearlyBudgetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unknownDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryMapIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationPointerXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationPointerYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn tyreSupplierIdDataGridViewComboBoxColumn;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView NonF1DriversDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn salaryDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn raceBonusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn championshipBonusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nationalityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unknownDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn speedDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn skillDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn overtakingDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn wetWeatherDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn concentrationDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn experienceDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn staminaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn moraleDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource nonF1DriverCollectionBindingSource;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView NonF1ChiefsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn salaryDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn raceBonusDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn championshipBonusDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn royaltyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn abilityDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource nonF1ChiefCollectionBindingSource;
    }
}
