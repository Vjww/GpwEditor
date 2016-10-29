using Data.Collections.Executable.Supplier;
using Data.Collections.Executable.Team;
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
            this.identityCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.teamCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.driverCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.engineCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tyreCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fuelCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trackCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ProgramOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastPositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastPointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstGpTrackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstGpYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearlyBudgetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unknownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryMapIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tyreSupplierIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.nationalityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.idDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toleranceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lapsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lapRecordMphDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastRaceDriverDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lastRaceTeamDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lastRaceYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastRaceTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lapRecordDriverDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lapRecordTeamDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lapRecordTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lapRecordYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.identityCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tyreCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCollectionBindingSource)).BeginInit();
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
            this.MainTabControl.Location = new System.Drawing.Point(8, 8);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(696, 496);
            this.MainTabControl.TabIndex = 1;
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
            this.CloseButton.TabIndex = 24;
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
            this.FilesGroupBox.TabIndex = 23;
            this.FilesGroupBox.TabStop = false;
            this.FilesGroupBox.Text = "Source/Target Files";
            // 
            // BrowseGameExecutableButton
            // 
            this.BrowseGameExecutableButton.Location = new System.Drawing.Point(514, 43);
            this.BrowseGameExecutableButton.Name = "BrowseGameExecutableButton";
            this.BrowseGameExecutableButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseGameExecutableButton.TabIndex = 6;
            this.BrowseGameExecutableButton.Text = "Browse...";
            this.BrowseGameExecutableButton.UseVisualStyleBackColor = true;
            this.BrowseGameExecutableButton.Click += new System.EventHandler(this.BrowseGameExecutableButton_Click);
            // 
            // BrowseLanguageFileButton
            // 
            this.BrowseLanguageFileButton.Location = new System.Drawing.Point(514, 17);
            this.BrowseLanguageFileButton.Name = "BrowseLanguageFileButton";
            this.BrowseLanguageFileButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseLanguageFileButton.TabIndex = 6;
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
            this.GameExecutablePathLabel.TabIndex = 3;
            this.GameExecutablePathLabel.Text = "Game Executable:";
            // 
            // LanguageFilePathLabel
            // 
            this.LanguageFilePathLabel.AutoSize = true;
            this.LanguageFilePathLabel.Location = new System.Drawing.Point(23, 22);
            this.LanguageFilePathLabel.Name = "LanguageFilePathLabel";
            this.LanguageFilePathLabel.Size = new System.Drawing.Size(77, 13);
            this.LanguageFilePathLabel.TabIndex = 2;
            this.LanguageFilePathLabel.Text = "Language File:";
            // 
            // GameExecutablePathTextBox
            // 
            this.GameExecutablePathTextBox.Location = new System.Drawing.Point(106, 45);
            this.GameExecutablePathTextBox.Name = "GameExecutablePathTextBox";
            this.GameExecutablePathTextBox.ReadOnly = true;
            this.GameExecutablePathTextBox.Size = new System.Drawing.Size(402, 20);
            this.GameExecutablePathTextBox.TabIndex = 1;
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
            this.LanguageDataGridView.TabIndex = 5;
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
            this.firstGpTrackDataGridViewTextBoxColumn,
            this.firstGpYearDataGridViewTextBoxColumn,
            this.winsDataGridViewTextBoxColumn,
            this.yearlyBudgetDataGridViewTextBoxColumn,
            this.unknownDataGridViewTextBoxColumn,
            this.countryMapIdDataGridViewTextBoxColumn,
            this.tyreSupplierIdDataGridViewTextBoxColumn});
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
            this.nationalityDataGridViewTextBoxColumn,
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
            this.EnginesDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.EnginesDataGridView_CellValidating);
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
            this.TyresDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.TyresDataGridView_CellValidating);
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
            this.FuelsDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.FuelsDataGridView_CellValidating);
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
            this.designDataGridViewTextBoxColumn,
            this.lapRecordMphDataGridViewTextBoxColumn,
            this.lastRaceDriverDataGridViewComboBoxColumn,
            this.lastRaceTeamDataGridViewComboBoxColumn,
            this.lastRaceYearDataGridViewTextBoxColumn,
            this.lastRaceTimeDataGridViewTextBoxColumn,
            this.lapRecordDriverDataGridViewComboBoxColumn,
            this.lapRecordTeamDataGridViewComboBoxColumn,
            this.lapRecordTimeDataGridViewTextBoxColumn,
            this.lapRecordYearDataGridViewTextBoxColumn,
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
            this.TracksDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TracksDataGridView_CellClick);
            // 
            // identityCollectionBindingSource
            // 
            this.identityCollectionBindingSource.DataSource = typeof(Data.Collections.Language.IdentityCollection);
            // 
            // teamCollectionBindingSource
            // 
            this.teamCollectionBindingSource.DataSource = typeof(Data.Collections.Executable.Team.TeamCollection);
            // 
            // driverCollectionBindingSource
            // 
            this.driverCollectionBindingSource.DataSource = typeof(Data.Collections.Executable.Team.DriverCollection);
            // 
            // engineCollectionBindingSource
            // 
            this.engineCollectionBindingSource.DataSource = typeof(Data.Collections.Executable.Supplier.EngineCollection);
            // 
            // tyreCollectionBindingSource
            // 
            this.tyreCollectionBindingSource.DataSource = typeof(Data.Collections.Executable.Supplier.TyreCollection);
            // 
            // fuelCollectionBindingSource
            // 
            this.fuelCollectionBindingSource.DataSource = typeof(Data.Collections.Executable.Supplier.FuelCollection);
            // 
            // trackCollectionBindingSource
            // 
            this.trackCollectionBindingSource.DataSource = typeof(Data.Entities.Executable.Track.Track);
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.ShowNewFolderButton = false;
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
            // firstGpTrackDataGridViewTextBoxColumn
            // 
            this.firstGpTrackDataGridViewTextBoxColumn.DataPropertyName = "FirstGpTrack";
            this.firstGpTrackDataGridViewTextBoxColumn.HeaderText = "FirstGpTrack";
            this.firstGpTrackDataGridViewTextBoxColumn.Name = "firstGpTrackDataGridViewTextBoxColumn";
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
            // tyreSupplierIdDataGridViewTextBoxColumn
            // 
            this.tyreSupplierIdDataGridViewTextBoxColumn.DataPropertyName = "TyreSupplierId";
            this.tyreSupplierIdDataGridViewTextBoxColumn.HeaderText = "TyreSupplierId";
            this.tyreSupplierIdDataGridViewTextBoxColumn.Name = "tyreSupplierIdDataGridViewTextBoxColumn";
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
            // nationalityDataGridViewTextBoxColumn
            // 
            this.nationalityDataGridViewTextBoxColumn.DataPropertyName = "Nationality";
            this.nationalityDataGridViewTextBoxColumn.HeaderText = "Nationality";
            this.nationalityDataGridViewTextBoxColumn.Name = "nationalityDataGridViewTextBoxColumn";
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
            // designDataGridViewTextBoxColumn
            // 
            this.designDataGridViewTextBoxColumn.DataPropertyName = "Design";
            this.designDataGridViewTextBoxColumn.HeaderText = "Design";
            this.designDataGridViewTextBoxColumn.Name = "designDataGridViewTextBoxColumn";
            // 
            // lapRecordMphDataGridViewTextBoxColumn
            // 
            this.lapRecordMphDataGridViewTextBoxColumn.DataPropertyName = "LapRecordMph";
            this.lapRecordMphDataGridViewTextBoxColumn.HeaderText = "LapRecordMph";
            this.lapRecordMphDataGridViewTextBoxColumn.Name = "lapRecordMphDataGridViewTextBoxColumn";
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
            // lapRecordYearDataGridViewTextBoxColumn
            // 
            this.lapRecordYearDataGridViewTextBoxColumn.DataPropertyName = "LapRecordYear";
            this.lapRecordYearDataGridViewTextBoxColumn.HeaderText = "LapRecordYear";
            this.lapRecordYearDataGridViewTextBoxColumn.Name = "lapRecordYearDataGridViewTextBoxColumn";
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
            this.Resize += new System.EventHandler(this.GameExecutableEditorForm_Resize);
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
            ((System.ComponentModel.ISupportInitialize)(this.identityCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tyreCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCollectionBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource trackCollectionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPositionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPointsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstGpTrackDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstGpYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn winsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearlyBudgetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unknownDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryMapIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tyreSupplierIdDataGridViewTextBoxColumn;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn nationalityDataGridViewTextBoxColumn;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn lapsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn designDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lapRecordMphDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn lastRaceDriverDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn lastRaceTeamDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastRaceYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastRaceTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn lapRecordDriverDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn lapRecordTeamDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lapRecordTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lapRecordYearDataGridViewTextBoxColumn;
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
    }
}
