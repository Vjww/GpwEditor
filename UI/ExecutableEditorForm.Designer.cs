using Data.Collections.Executable.Supplier;
using Data.Collections.Executable.Team;
using Data.Collections.Language;
using Data.Entities.Executable.Track;

namespace GpwEditor
{
    partial class ExecutableEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecutableEditorForm));
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.HomeTabPage = new System.Windows.Forms.TabPage();
            this.ExportGroupBox = new System.Windows.Forms.GroupBox();
            this.ExportExecutableFileButton = new System.Windows.Forms.Button();
            this.ExportExecutableFileTextBox = new System.Windows.Forms.TextBox();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ExportExecutableFileLabel = new System.Windows.Forms.Label();
            this.ExportLanguageFileButton = new System.Windows.Forms.Button();
            this.ExportLanguageFileTextBox = new System.Windows.Forms.TextBox();
            this.ExportLanguageFileLabel = new System.Windows.Forms.Label();
            this.ImportGroupBox = new System.Windows.Forms.GroupBox();
            this.ImportExecutableFileButton = new System.Windows.Forms.Button();
            this.ImportExecutableFileTextBox = new System.Windows.Forms.TextBox();
            this.ImportButton = new System.Windows.Forms.Button();
            this.ImportExecutableFileLabel = new System.Windows.Forms.Label();
            this.ImportLanguageFileButton = new System.Windows.Forms.Button();
            this.ImportLanguageFileTextBox = new System.Windows.Forms.TextBox();
            this.ImportLanguageFileLabel = new System.Windows.Forms.Label();
            this.InstructionsGroupBox = new System.Windows.Forms.GroupBox();
            this.InstructionsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.StringTableGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identityCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TeamsTabPage = new System.Windows.Forms.TabPage();
            this.TeamsDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastPositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastPointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstGpTrackDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstGpYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.winsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearlyBudgetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unknownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryMapIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tyreSupplierIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DriversTabPage = new System.Windows.Forms.TabPage();
            this.DriversDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.driverCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EnginesTabPage = new System.Windows.Forms.TabPage();
            this.EnginesDataGridView = new System.Windows.Forms.DataGridView();
            this.engineCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TyresTabPage = new System.Windows.Forms.TabPage();
            this.TyresDataGridView = new System.Windows.Forms.DataGridView();
            this.tyreCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FuelsTabPage = new System.Windows.Forms.TabPage();
            this.FuelsDataGridView = new System.Windows.Forms.DataGridView();
            this.fuelCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TracksTabPage = new System.Windows.Forms.TabPage();
            this.TracksDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceTextDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lapsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unknown1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unknown2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.unknown3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lastRaceYearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastRaceTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lapRecordDriverDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.lapRecordTeamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
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
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.windDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ProgramOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.EnhancementsTabPage = new System.Windows.Forms.TabPage();
            this.GameConfigurationGroupBox = new System.Windows.Forms.GroupBox();
            this.DisablePitExitPriorityCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableMemoryResetForRaceSoundsCheckbox = new System.Windows.Forms.CheckBox();
            this.DisableGameCdCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableGlobalUnlockCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableSampleAppCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableColourModeCheckBox = new System.Windows.Forms.CheckBox();
            this.PointsScoringSystemGroupBox = new System.Windows.Forms.GroupBox();
            this.PointsScoringSystemOption3RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemOption2RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemOption1RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemDefaultRadioButton = new System.Windows.Forms.RadioButton();
            this.GameEnhancementsGroupBox = new System.Windows.Forms.GroupBox();
            this.DisableYellowFlagPenaltiesCheckBox = new System.Windows.Forms.CheckBox();
            this.EnableCarPerformanceRaceCalcuationCheckbox = new System.Windows.Forms.CheckBox();
            this.EnableCarHandlingDesignCalculationCheckbox = new System.Windows.Forms.CheckBox();
            this.MainTabControl.SuspendLayout();
            this.HomeTabPage.SuspendLayout();
            this.ExportGroupBox.SuspendLayout();
            this.ImportGroupBox.SuspendLayout();
            this.InstructionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StringTableGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.identityCollectionBindingSource)).BeginInit();
            this.TeamsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamCollectionBindingSource)).BeginInit();
            this.DriversTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DriversDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverCollectionBindingSource)).BeginInit();
            this.EnginesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnginesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineCollectionBindingSource)).BeginInit();
            this.TyresTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TyresDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tyreCollectionBindingSource)).BeginInit();
            this.FuelsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FuelsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelCollectionBindingSource)).BeginInit();
            this.TracksTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TracksDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCollectionBindingSource)).BeginInit();
            this.EnhancementsTabPage.SuspendLayout();
            this.GameConfigurationGroupBox.SuspendLayout();
            this.PointsScoringSystemGroupBox.SuspendLayout();
            this.GameEnhancementsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.HomeTabPage);
            this.MainTabControl.Controls.Add(this.EnhancementsTabPage);
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
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_SelectedIndexChanged);
            // 
            // HomeTabPage
            // 
            this.HomeTabPage.Controls.Add(this.ExportGroupBox);
            this.HomeTabPage.Controls.Add(this.ImportGroupBox);
            this.HomeTabPage.Controls.Add(this.InstructionsGroupBox);
            this.HomeTabPage.Controls.Add(this.StringTableGridView);
            this.HomeTabPage.Location = new System.Drawing.Point(4, 22);
            this.HomeTabPage.Name = "HomeTabPage";
            this.HomeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HomeTabPage.Size = new System.Drawing.Size(688, 470);
            this.HomeTabPage.TabIndex = 0;
            this.HomeTabPage.Text = "Home";
            this.HomeTabPage.UseVisualStyleBackColor = true;
            // 
            // ExportGroupBox
            // 
            this.ExportGroupBox.Controls.Add(this.ExportExecutableFileButton);
            this.ExportGroupBox.Controls.Add(this.ExportExecutableFileTextBox);
            this.ExportGroupBox.Controls.Add(this.ExportButton);
            this.ExportGroupBox.Controls.Add(this.ExportExecutableFileLabel);
            this.ExportGroupBox.Controls.Add(this.ExportLanguageFileButton);
            this.ExportGroupBox.Controls.Add(this.ExportLanguageFileTextBox);
            this.ExportGroupBox.Controls.Add(this.ExportLanguageFileLabel);
            this.ExportGroupBox.Location = new System.Drawing.Point(8, 198);
            this.ExportGroupBox.Name = "ExportGroupBox";
            this.ExportGroupBox.Size = new System.Drawing.Size(672, 78);
            this.ExportGroupBox.TabIndex = 4;
            this.ExportGroupBox.TabStop = false;
            this.ExportGroupBox.Text = "Export";
            // 
            // ExportExecutableFileButton
            // 
            this.ExportExecutableFileButton.Location = new System.Drawing.Point(502, 43);
            this.ExportExecutableFileButton.Name = "ExportExecutableFileButton";
            this.ExportExecutableFileButton.Size = new System.Drawing.Size(75, 23);
            this.ExportExecutableFileButton.TabIndex = 7;
            this.ExportExecutableFileButton.Text = "Change...";
            this.ExportExecutableFileButton.UseVisualStyleBackColor = true;
            this.ExportExecutableFileButton.Click += new System.EventHandler(this.ExportExecutableFileButton_Click);
            // 
            // ExportExecutableFileTextBox
            // 
            this.ExportExecutableFileTextBox.Location = new System.Drawing.Point(96, 45);
            this.ExportExecutableFileTextBox.Name = "ExportExecutableFileTextBox";
            this.ExportExecutableFileTextBox.Size = new System.Drawing.Size(400, 20);
            this.ExportExecutableFileTextBox.TabIndex = 6;
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(583, 17);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(83, 48);
            this.ExportButton.TabIndex = 0;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportDataButton_Click);
            // 
            // ExportExecutableFileLabel
            // 
            this.ExportExecutableFileLabel.AutoSize = true;
            this.ExportExecutableFileLabel.Location = new System.Drawing.Point(11, 48);
            this.ExportExecutableFileLabel.Name = "ExportExecutableFileLabel";
            this.ExportExecutableFileLabel.Size = new System.Drawing.Size(79, 13);
            this.ExportExecutableFileLabel.TabIndex = 5;
            this.ExportExecutableFileLabel.Text = "Executable File";
            // 
            // ExportLanguageFileButton
            // 
            this.ExportLanguageFileButton.Location = new System.Drawing.Point(502, 17);
            this.ExportLanguageFileButton.Name = "ExportLanguageFileButton";
            this.ExportLanguageFileButton.Size = new System.Drawing.Size(75, 23);
            this.ExportLanguageFileButton.TabIndex = 4;
            this.ExportLanguageFileButton.Text = "Change...";
            this.ExportLanguageFileButton.UseVisualStyleBackColor = true;
            this.ExportLanguageFileButton.Click += new System.EventHandler(this.ExportLanguageFileButton_Click);
            // 
            // ExportLanguageFileTextBox
            // 
            this.ExportLanguageFileTextBox.Location = new System.Drawing.Point(96, 19);
            this.ExportLanguageFileTextBox.Name = "ExportLanguageFileTextBox";
            this.ExportLanguageFileTextBox.Size = new System.Drawing.Size(400, 20);
            this.ExportLanguageFileTextBox.TabIndex = 3;
            // 
            // ExportLanguageFileLabel
            // 
            this.ExportLanguageFileLabel.AutoSize = true;
            this.ExportLanguageFileLabel.Location = new System.Drawing.Point(16, 22);
            this.ExportLanguageFileLabel.Name = "ExportLanguageFileLabel";
            this.ExportLanguageFileLabel.Size = new System.Drawing.Size(74, 13);
            this.ExportLanguageFileLabel.TabIndex = 2;
            this.ExportLanguageFileLabel.Text = "Language File";
            // 
            // ImportGroupBox
            // 
            this.ImportGroupBox.Controls.Add(this.ImportExecutableFileButton);
            this.ImportGroupBox.Controls.Add(this.ImportExecutableFileTextBox);
            this.ImportGroupBox.Controls.Add(this.ImportButton);
            this.ImportGroupBox.Controls.Add(this.ImportExecutableFileLabel);
            this.ImportGroupBox.Controls.Add(this.ImportLanguageFileButton);
            this.ImportGroupBox.Controls.Add(this.ImportLanguageFileTextBox);
            this.ImportGroupBox.Controls.Add(this.ImportLanguageFileLabel);
            this.ImportGroupBox.Location = new System.Drawing.Point(8, 114);
            this.ImportGroupBox.Name = "ImportGroupBox";
            this.ImportGroupBox.Size = new System.Drawing.Size(672, 78);
            this.ImportGroupBox.TabIndex = 4;
            this.ImportGroupBox.TabStop = false;
            this.ImportGroupBox.Text = "Import";
            // 
            // ImportExecutableFileButton
            // 
            this.ImportExecutableFileButton.Location = new System.Drawing.Point(502, 43);
            this.ImportExecutableFileButton.Name = "ImportExecutableFileButton";
            this.ImportExecutableFileButton.Size = new System.Drawing.Size(75, 23);
            this.ImportExecutableFileButton.TabIndex = 7;
            this.ImportExecutableFileButton.Text = "Change...";
            this.ImportExecutableFileButton.UseVisualStyleBackColor = true;
            this.ImportExecutableFileButton.Click += new System.EventHandler(this.ImportExecutableFileButton_Click);
            // 
            // ImportExecutableFileTextBox
            // 
            this.ImportExecutableFileTextBox.Location = new System.Drawing.Point(96, 45);
            this.ImportExecutableFileTextBox.Name = "ImportExecutableFileTextBox";
            this.ImportExecutableFileTextBox.Size = new System.Drawing.Size(400, 20);
            this.ImportExecutableFileTextBox.TabIndex = 6;
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(583, 17);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(83, 48);
            this.ImportButton.TabIndex = 0;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportDataButton_Click);
            // 
            // ImportExecutableFileLabel
            // 
            this.ImportExecutableFileLabel.AutoSize = true;
            this.ImportExecutableFileLabel.Location = new System.Drawing.Point(11, 48);
            this.ImportExecutableFileLabel.Name = "ImportExecutableFileLabel";
            this.ImportExecutableFileLabel.Size = new System.Drawing.Size(79, 13);
            this.ImportExecutableFileLabel.TabIndex = 5;
            this.ImportExecutableFileLabel.Text = "Executable File";
            // 
            // ImportLanguageFileButton
            // 
            this.ImportLanguageFileButton.Location = new System.Drawing.Point(502, 17);
            this.ImportLanguageFileButton.Name = "ImportLanguageFileButton";
            this.ImportLanguageFileButton.Size = new System.Drawing.Size(75, 23);
            this.ImportLanguageFileButton.TabIndex = 4;
            this.ImportLanguageFileButton.Text = "Change...";
            this.ImportLanguageFileButton.UseVisualStyleBackColor = true;
            this.ImportLanguageFileButton.Click += new System.EventHandler(this.ImportLanguageFileButton_Click);
            // 
            // ImportLanguageFileTextBox
            // 
            this.ImportLanguageFileTextBox.Location = new System.Drawing.Point(96, 19);
            this.ImportLanguageFileTextBox.Name = "ImportLanguageFileTextBox";
            this.ImportLanguageFileTextBox.Size = new System.Drawing.Size(400, 20);
            this.ImportLanguageFileTextBox.TabIndex = 3;
            // 
            // ImportLanguageFileLabel
            // 
            this.ImportLanguageFileLabel.AutoSize = true;
            this.ImportLanguageFileLabel.Location = new System.Drawing.Point(16, 22);
            this.ImportLanguageFileLabel.Name = "ImportLanguageFileLabel";
            this.ImportLanguageFileLabel.Size = new System.Drawing.Size(74, 13);
            this.ImportLanguageFileLabel.TabIndex = 2;
            this.ImportLanguageFileLabel.Text = "Language File";
            // 
            // InstructionsGroupBox
            // 
            this.InstructionsGroupBox.Controls.Add(this.InstructionsRichTextBox);
            this.InstructionsGroupBox.Location = new System.Drawing.Point(8, 8);
            this.InstructionsGroupBox.Name = "InstructionsGroupBox";
            this.InstructionsGroupBox.Size = new System.Drawing.Size(672, 100);
            this.InstructionsGroupBox.TabIndex = 3;
            this.InstructionsGroupBox.TabStop = false;
            this.InstructionsGroupBox.Text = "Instructions";
            // 
            // InstructionsRichTextBox
            // 
            this.InstructionsRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.InstructionsRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InstructionsRichTextBox.Location = new System.Drawing.Point(6, 20);
            this.InstructionsRichTextBox.Name = "InstructionsRichTextBox";
            this.InstructionsRichTextBox.ReadOnly = true;
            this.InstructionsRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.InstructionsRichTextBox.ShowSelectionMargin = true;
            this.InstructionsRichTextBox.Size = new System.Drawing.Size(660, 74);
            this.InstructionsRichTextBox.TabIndex = 0;
            this.InstructionsRichTextBox.Text = resources.GetString("InstructionsRichTextBox.Text");
            // 
            // StringTableGridView
            // 
            this.StringTableGridView.AutoGenerateColumns = false;
            this.StringTableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StringTableGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.localResourceIdDataGridViewTextBoxColumn1,
            this.resourceIdDataGridViewTextBoxColumn1,
            this.resourceTextDataGridViewTextBoxColumn1});
            this.StringTableGridView.DataSource = this.identityCollectionBindingSource;
            this.StringTableGridView.Location = new System.Drawing.Point(8, 416);
            this.StringTableGridView.Name = "StringTableGridView";
            this.StringTableGridView.Size = new System.Drawing.Size(672, 47);
            this.StringTableGridView.TabIndex = 5;
            this.StringTableGridView.Visible = false;
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
            // identityCollectionBindingSource
            // 
            this.identityCollectionBindingSource.DataSource = typeof(IdentityCollection);
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
            this.idDataGridViewTextBoxColumn3,
            this.localResourceIdDataGridViewTextBoxColumn3,
            this.resourceIdDataGridViewTextBoxColumn3,
            this.resourceTextDataGridViewTextBoxColumn3,
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
            // idDataGridViewTextBoxColumn3
            // 
            this.idDataGridViewTextBoxColumn3.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn3.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn3.Name = "idDataGridViewTextBoxColumn3";
            this.idDataGridViewTextBoxColumn3.Visible = false;
            // 
            // localResourceIdDataGridViewTextBoxColumn3
            // 
            this.localResourceIdDataGridViewTextBoxColumn3.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn3.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn3.Name = "localResourceIdDataGridViewTextBoxColumn3";
            this.localResourceIdDataGridViewTextBoxColumn3.Visible = false;
            // 
            // resourceIdDataGridViewTextBoxColumn3
            // 
            this.resourceIdDataGridViewTextBoxColumn3.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn3.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn3.Name = "resourceIdDataGridViewTextBoxColumn3";
            this.resourceIdDataGridViewTextBoxColumn3.Visible = false;
            // 
            // resourceTextDataGridViewTextBoxColumn3
            // 
            this.resourceTextDataGridViewTextBoxColumn3.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn3.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn3.Name = "resourceTextDataGridViewTextBoxColumn3";
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
            // teamCollectionBindingSource
            // 
            this.teamCollectionBindingSource.DataSource = typeof(TeamCollection);
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
            this.idDataGridViewTextBoxColumn,
            this.localResourceIdDataGridViewTextBoxColumn,
            this.resourceIdDataGridViewTextBoxColumn,
            this.resourceTextDataGridViewTextBoxColumn,
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
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // localResourceIdDataGridViewTextBoxColumn
            // 
            this.localResourceIdDataGridViewTextBoxColumn.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn.Name = "localResourceIdDataGridViewTextBoxColumn";
            this.localResourceIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // resourceIdDataGridViewTextBoxColumn
            // 
            this.resourceIdDataGridViewTextBoxColumn.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn.Name = "resourceIdDataGridViewTextBoxColumn";
            this.resourceIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // resourceTextDataGridViewTextBoxColumn
            // 
            this.resourceTextDataGridViewTextBoxColumn.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn.Name = "resourceTextDataGridViewTextBoxColumn";
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
            // driverCollectionBindingSource
            // 
            this.driverCollectionBindingSource.DataSource = typeof(DriverCollection);
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
            this.EnginesDataGridView.DataSource = this.engineCollectionBindingSource;
            this.EnginesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnginesDataGridView.Location = new System.Drawing.Point(3, 3);
            this.EnginesDataGridView.Name = "EnginesDataGridView";
            this.EnginesDataGridView.Size = new System.Drawing.Size(682, 464);
            this.EnginesDataGridView.TabIndex = 0;
            this.EnginesDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.EnginesDataGridView_CellValidating);
            // 
            // engineCollectionBindingSource
            // 
            this.engineCollectionBindingSource.DataSource = typeof(EngineCollection);
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
            this.TyresDataGridView.DataSource = this.tyreCollectionBindingSource;
            this.TyresDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TyresDataGridView.Location = new System.Drawing.Point(3, 3);
            this.TyresDataGridView.Name = "TyresDataGridView";
            this.TyresDataGridView.Size = new System.Drawing.Size(682, 464);
            this.TyresDataGridView.TabIndex = 0;
            this.TyresDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.TyresDataGridView_CellValidating);
            // 
            // tyreCollectionBindingSource
            // 
            this.tyreCollectionBindingSource.DataSource = typeof(TyreCollection);
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
            this.FuelsDataGridView.DataSource = this.fuelCollectionBindingSource;
            this.FuelsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FuelsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.FuelsDataGridView.Name = "FuelsDataGridView";
            this.FuelsDataGridView.Size = new System.Drawing.Size(682, 464);
            this.FuelsDataGridView.TabIndex = 0;
            this.FuelsDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.FuelsDataGridView_CellValidating);
            // 
            // fuelCollectionBindingSource
            // 
            this.fuelCollectionBindingSource.DataSource = typeof(FuelCollection);
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
            this.idDataGridViewTextBoxColumn2,
            this.localResourceIdDataGridViewTextBoxColumn2,
            this.resourceIdDataGridViewTextBoxColumn2,
            this.resourceTextDataGridViewTextBoxColumn2,
            this.lapsDataGridViewTextBoxColumn,
            this.designDataGridViewTextBoxColumn,
            this.unknown1DataGridViewTextBoxColumn,
            this.unknown2DataGridViewTextBoxColumn,
            this.unknown3DataGridViewTextBoxColumn,
            this.lastRaceYearDataGridViewTextBoxColumn,
            this.lastRaceTimeDataGridViewTextBoxColumn,
            this.lapRecordDriverDataGridViewTextBoxColumn,
            this.lapRecordTeamDataGridViewTextBoxColumn,
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
            this.dataGridViewTextBoxColumn2,
            this.windDataGridViewTextBoxColumn});
            this.TracksDataGridView.DataSource = this.trackCollectionBindingSource;
            this.TracksDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TracksDataGridView.Location = new System.Drawing.Point(3, 3);
            this.TracksDataGridView.Name = "TracksDataGridView";
            this.TracksDataGridView.Size = new System.Drawing.Size(682, 464);
            this.TracksDataGridView.TabIndex = 0;
            this.TracksDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TracksDataGridView_CellClick);
            // 
            // idDataGridViewTextBoxColumn2
            // 
            this.idDataGridViewTextBoxColumn2.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn2.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn2.Name = "idDataGridViewTextBoxColumn2";
            this.idDataGridViewTextBoxColumn2.Visible = false;
            // 
            // localResourceIdDataGridViewTextBoxColumn2
            // 
            this.localResourceIdDataGridViewTextBoxColumn2.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn2.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn2.Name = "localResourceIdDataGridViewTextBoxColumn2";
            this.localResourceIdDataGridViewTextBoxColumn2.Visible = false;
            // 
            // resourceIdDataGridViewTextBoxColumn2
            // 
            this.resourceIdDataGridViewTextBoxColumn2.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn2.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn2.Name = "resourceIdDataGridViewTextBoxColumn2";
            this.resourceIdDataGridViewTextBoxColumn2.Visible = false;
            // 
            // resourceTextDataGridViewTextBoxColumn2
            // 
            this.resourceTextDataGridViewTextBoxColumn2.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn2.HeaderText = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn2.Name = "resourceTextDataGridViewTextBoxColumn2";
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
            // unknown1DataGridViewTextBoxColumn
            // 
            this.unknown1DataGridViewTextBoxColumn.DataPropertyName = "Unknown1";
            this.unknown1DataGridViewTextBoxColumn.HeaderText = "Unknown1";
            this.unknown1DataGridViewTextBoxColumn.Name = "unknown1DataGridViewTextBoxColumn";
            // 
            // unknown2DataGridViewTextBoxColumn
            // 
            this.unknown2DataGridViewTextBoxColumn.DataPropertyName = "Unknown2";
            this.unknown2DataGridViewTextBoxColumn.HeaderText = "Unknown2";
            this.unknown2DataGridViewTextBoxColumn.Name = "unknown2DataGridViewTextBoxColumn";
            this.unknown2DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.unknown2DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // unknown3DataGridViewTextBoxColumn
            // 
            this.unknown3DataGridViewTextBoxColumn.DataPropertyName = "Unknown3";
            this.unknown3DataGridViewTextBoxColumn.HeaderText = "Unknown3";
            this.unknown3DataGridViewTextBoxColumn.Name = "unknown3DataGridViewTextBoxColumn";
            this.unknown3DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.unknown3DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // lapRecordDriverDataGridViewTextBoxColumn
            // 
            this.lapRecordDriverDataGridViewTextBoxColumn.DataPropertyName = "LapRecordDriver";
            this.lapRecordDriverDataGridViewTextBoxColumn.HeaderText = "LapRecordDriver";
            this.lapRecordDriverDataGridViewTextBoxColumn.Name = "lapRecordDriverDataGridViewTextBoxColumn";
            this.lapRecordDriverDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lapRecordDriverDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lapRecordTeamDataGridViewTextBoxColumn
            // 
            this.lapRecordTeamDataGridViewTextBoxColumn.DataPropertyName = "LapRecordTeam";
            this.lapRecordTeamDataGridViewTextBoxColumn.HeaderText = "LapRecordTeam";
            this.lapRecordTeamDataGridViewTextBoxColumn.Name = "lapRecordTeamDataGridViewTextBoxColumn";
            this.lapRecordTeamDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lapRecordTeamDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Heat";
            this.dataGridViewTextBoxColumn2.HeaderText = "Heat";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // windDataGridViewTextBoxColumn
            // 
            this.windDataGridViewTextBoxColumn.DataPropertyName = "Wind";
            this.windDataGridViewTextBoxColumn.HeaderText = "Wind";
            this.windDataGridViewTextBoxColumn.Name = "windDataGridViewTextBoxColumn";
            // 
            // trackCollectionBindingSource
            // 
            this.trackCollectionBindingSource.DataSource = typeof(Track);
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // EnhancementsTabPage
            // 
            this.EnhancementsTabPage.Controls.Add(this.GameEnhancementsGroupBox);
            this.EnhancementsTabPage.Controls.Add(this.GameConfigurationGroupBox);
            this.EnhancementsTabPage.Controls.Add(this.PointsScoringSystemGroupBox);
            this.EnhancementsTabPage.Location = new System.Drawing.Point(4, 22);
            this.EnhancementsTabPage.Name = "EnhancementsTabPage";
            this.EnhancementsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.EnhancementsTabPage.Size = new System.Drawing.Size(688, 470);
            this.EnhancementsTabPage.TabIndex = 7;
            this.EnhancementsTabPage.Text = "Enhancements";
            this.EnhancementsTabPage.UseVisualStyleBackColor = true;
            // 
            // GameConfigurationGroupBox
            // 
            this.GameConfigurationGroupBox.Controls.Add(this.DisablePitExitPriorityCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableMemoryResetForRaceSoundsCheckbox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableGameCdCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableGlobalUnlockCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableSampleAppCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableColourModeCheckBox);
            this.GameConfigurationGroupBox.Location = new System.Drawing.Point(8, 8);
            this.GameConfigurationGroupBox.Name = "GameConfigurationGroupBox";
            this.GameConfigurationGroupBox.Size = new System.Drawing.Size(332, 232);
            this.GameConfigurationGroupBox.TabIndex = 0;
            this.GameConfigurationGroupBox.TabStop = false;
            this.GameConfigurationGroupBox.Text = "Game Configuration";
            // 
            // DisablePitExitPriorityCheckBox
            // 
            this.DisablePitExitPriorityCheckBox.AutoSize = true;
            this.DisablePitExitPriorityCheckBox.Location = new System.Drawing.Point(8, 144);
            this.DisablePitExitPriorityCheckBox.Name = "DisablePitExitPriorityCheckBox";
            this.DisablePitExitPriorityCheckBox.Size = new System.Drawing.Size(310, 17);
            this.DisablePitExitPriorityCheckBox.TabIndex = 5;
            this.DisablePitExitPriorityCheckBox.Text = "Prevent lower numbered teams from being held in the pitlane";
            this.DisablePitExitPriorityCheckBox.UseVisualStyleBackColor = true;
            this.DisablePitExitPriorityCheckBox.Visible = false;
            // 
            // DisableMemoryResetForRaceSoundsCheckbox
            // 
            this.DisableMemoryResetForRaceSoundsCheckbox.AutoSize = true;
            this.DisableMemoryResetForRaceSoundsCheckbox.Location = new System.Drawing.Point(8, 120);
            this.DisableMemoryResetForRaceSoundsCheckbox.Name = "DisableMemoryResetForRaceSoundsCheckbox";
            this.DisableMemoryResetForRaceSoundsCheckbox.Size = new System.Drawing.Size(294, 17);
            this.DisableMemoryResetForRaceSoundsCheckbox.TabIndex = 4;
            this.DisableMemoryResetForRaceSoundsCheckbox.Text = "Prevent crash to desktop when race sounds are enabled";
            this.DisableMemoryResetForRaceSoundsCheckbox.UseVisualStyleBackColor = true;
            // 
            // DisableGameCdCheckBox
            // 
            this.DisableGameCdCheckBox.AutoSize = true;
            this.DisableGameCdCheckBox.Location = new System.Drawing.Point(8, 24);
            this.DisableGameCdCheckBox.Name = "DisableGameCdCheckBox";
            this.DisableGameCdCheckBox.Size = new System.Drawing.Size(194, 17);
            this.DisableGameCdCheckBox.TabIndex = 0;
            this.DisableGameCdCheckBox.Text = "Prevent check for original game CD";
            this.DisableGameCdCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableGlobalUnlockCheckBox
            // 
            this.DisableGlobalUnlockCheckBox.AutoSize = true;
            this.DisableGlobalUnlockCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DisableGlobalUnlockCheckBox.Location = new System.Drawing.Point(8, 96);
            this.DisableGlobalUnlockCheckBox.Name = "DisableGlobalUnlockCheckBox";
            this.DisableGlobalUnlockCheckBox.Size = new System.Drawing.Size(230, 17);
            this.DisableGlobalUnlockCheckBox.TabIndex = 3;
            this.DisableGlobalUnlockCheckBox.Text = "Prevent freezing on startup at gold FIA logo";
            this.DisableGlobalUnlockCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableSampleAppCheckBox
            // 
            this.DisableSampleAppCheckBox.AutoSize = true;
            this.DisableSampleAppCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DisableSampleAppCheckBox.Location = new System.Drawing.Point(8, 72);
            this.DisableSampleAppCheckBox.Name = "DisableSampleAppCheckBox";
            this.DisableSampleAppCheckBox.Size = new System.Drawing.Size(241, 17);
            this.DisableSampleAppCheckBox.TabIndex = 2;
            this.DisableSampleAppCheckBox.Text = "Prevent check for sample app object cleanup";
            this.DisableSampleAppCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableColourModeCheckBox
            // 
            this.DisableColourModeCheckBox.AutoSize = true;
            this.DisableColourModeCheckBox.Location = new System.Drawing.Point(8, 48);
            this.DisableColourModeCheckBox.Name = "DisableColourModeCheckBox";
            this.DisableColourModeCheckBox.Size = new System.Drawing.Size(201, 17);
            this.DisableColourModeCheckBox.TabIndex = 1;
            this.DisableColourModeCheckBox.Text = "Prevent check for 16-bit colour mode";
            this.DisableColourModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // PointsScoringSystemGroupBox
            // 
            this.PointsScoringSystemGroupBox.Controls.Add(this.PointsScoringSystemOption3RadioButton);
            this.PointsScoringSystemGroupBox.Controls.Add(this.PointsScoringSystemOption2RadioButton);
            this.PointsScoringSystemGroupBox.Controls.Add(this.PointsScoringSystemOption1RadioButton);
            this.PointsScoringSystemGroupBox.Controls.Add(this.PointsScoringSystemDefaultRadioButton);
            this.PointsScoringSystemGroupBox.Location = new System.Drawing.Point(350, 112);
            this.PointsScoringSystemGroupBox.Name = "PointsScoringSystemGroupBox";
            this.PointsScoringSystemGroupBox.Size = new System.Drawing.Size(332, 128);
            this.PointsScoringSystemGroupBox.TabIndex = 3;
            this.PointsScoringSystemGroupBox.TabStop = false;
            this.PointsScoringSystemGroupBox.Text = "Points Scoring System";
            // 
            // PointsScoringSystemOption3RadioButton
            // 
            this.PointsScoringSystemOption3RadioButton.AutoSize = true;
            this.PointsScoringSystemOption3RadioButton.Location = new System.Drawing.Point(8, 96);
            this.PointsScoringSystemOption3RadioButton.Name = "PointsScoringSystemOption3RadioButton";
            this.PointsScoringSystemOption3RadioButton.Size = new System.Drawing.Size(301, 17);
            this.PointsScoringSystemOption3RadioButton.TabIndex = 3;
            this.PointsScoringSystemOption3RadioButton.Text = "Option3 - 25-18-15-12-10-8-6-4-2-1 (top 10 finishers, 2010-)";
            this.PointsScoringSystemOption3RadioButton.UseVisualStyleBackColor = true;
            // 
            // PointsScoringSystemOption2RadioButton
            // 
            this.PointsScoringSystemOption2RadioButton.AutoSize = true;
            this.PointsScoringSystemOption2RadioButton.Location = new System.Drawing.Point(8, 72);
            this.PointsScoringSystemOption2RadioButton.Name = "PointsScoringSystemOption2RadioButton";
            this.PointsScoringSystemOption2RadioButton.Size = new System.Drawing.Size(277, 17);
            this.PointsScoringSystemOption2RadioButton.TabIndex = 2;
            this.PointsScoringSystemOption2RadioButton.Text = "Option2 - 10-8-6-5-4-3-2-1 (top 8 finishers, 2003-2009)";
            this.PointsScoringSystemOption2RadioButton.UseVisualStyleBackColor = true;
            // 
            // PointsScoringSystemOption1RadioButton
            // 
            this.PointsScoringSystemOption1RadioButton.AutoSize = true;
            this.PointsScoringSystemOption1RadioButton.Location = new System.Drawing.Point(8, 48);
            this.PointsScoringSystemOption1RadioButton.Name = "PointsScoringSystemOption1RadioButton";
            this.PointsScoringSystemOption1RadioButton.Size = new System.Drawing.Size(253, 17);
            this.PointsScoringSystemOption1RadioButton.TabIndex = 1;
            this.PointsScoringSystemOption1RadioButton.Text = "Option1 - 9-6-4-3-2-1 (top 6 finishers, 1981-1990)";
            this.PointsScoringSystemOption1RadioButton.UseVisualStyleBackColor = true;
            // 
            // PointsScoringSystemDefaultRadioButton
            // 
            this.PointsScoringSystemDefaultRadioButton.AutoSize = true;
            this.PointsScoringSystemDefaultRadioButton.Checked = true;
            this.PointsScoringSystemDefaultRadioButton.Location = new System.Drawing.Point(8, 24);
            this.PointsScoringSystemDefaultRadioButton.Name = "PointsScoringSystemDefaultRadioButton";
            this.PointsScoringSystemDefaultRadioButton.Size = new System.Drawing.Size(256, 17);
            this.PointsScoringSystemDefaultRadioButton.TabIndex = 0;
            this.PointsScoringSystemDefaultRadioButton.TabStop = true;
            this.PointsScoringSystemDefaultRadioButton.Text = "Default - 10-6-4-3-2-1 (top 6 finishers, 1991-2002)";
            this.PointsScoringSystemDefaultRadioButton.UseVisualStyleBackColor = true;
            // 
            // GameEnhancementsGroupBox
            // 
            this.GameEnhancementsGroupBox.Controls.Add(this.DisableYellowFlagPenaltiesCheckBox);
            this.GameEnhancementsGroupBox.Controls.Add(this.EnableCarPerformanceRaceCalcuationCheckbox);
            this.GameEnhancementsGroupBox.Controls.Add(this.EnableCarHandlingDesignCalculationCheckbox);
            this.GameEnhancementsGroupBox.Location = new System.Drawing.Point(350, 8);
            this.GameEnhancementsGroupBox.Name = "GameEnhancementsGroupBox";
            this.GameEnhancementsGroupBox.Size = new System.Drawing.Size(332, 96);
            this.GameEnhancementsGroupBox.TabIndex = 1;
            this.GameEnhancementsGroupBox.TabStop = false;
            this.GameEnhancementsGroupBox.Text = "Game Enhancements";
            // 
            // DisableYellowFlagPenaltiesCheckBox
            // 
            this.DisableYellowFlagPenaltiesCheckBox.AutoSize = true;
            this.DisableYellowFlagPenaltiesCheckBox.Location = new System.Drawing.Point(8, 24);
            this.DisableYellowFlagPenaltiesCheckBox.Name = "DisableYellowFlagPenaltiesCheckBox";
            this.DisableYellowFlagPenaltiesCheckBox.Size = new System.Drawing.Size(218, 17);
            this.DisableYellowFlagPenaltiesCheckBox.TabIndex = 0;
            this.DisableYellowFlagPenaltiesCheckBox.Text = "Disable penalties for ignoring yellow flags";
            this.DisableYellowFlagPenaltiesCheckBox.UseVisualStyleBackColor = true;
            // 
            // EnableCarPerformanceRaceCalcuationCheckbox
            // 
            this.EnableCarPerformanceRaceCalcuationCheckbox.AutoSize = true;
            this.EnableCarPerformanceRaceCalcuationCheckbox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EnableCarPerformanceRaceCalcuationCheckbox.Location = new System.Drawing.Point(8, 72);
            this.EnableCarPerformanceRaceCalcuationCheckbox.Name = "EnableCarPerformanceRaceCalcuationCheckbox";
            this.EnableCarPerformanceRaceCalcuationCheckbox.Size = new System.Drawing.Size(255, 17);
            this.EnableCarPerformanceRaceCalcuationCheckbox.TabIndex = 2;
            this.EnableCarPerformanceRaceCalcuationCheckbox.Text = "Use alternative car performance race calculation";
            this.EnableCarPerformanceRaceCalcuationCheckbox.UseVisualStyleBackColor = true;
            // 
            // EnableCarHandlingDesignCalculationCheckbox
            // 
            this.EnableCarHandlingDesignCalculationCheckbox.AutoSize = true;
            this.EnableCarHandlingDesignCalculationCheckbox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EnableCarHandlingDesignCalculationCheckbox.Location = new System.Drawing.Point(8, 48);
            this.EnableCarHandlingDesignCalculationCheckbox.Name = "EnableCarHandlingDesignCalculationCheckbox";
            this.EnableCarHandlingDesignCalculationCheckbox.Size = new System.Drawing.Size(249, 17);
            this.EnableCarHandlingDesignCalculationCheckbox.TabIndex = 1;
            this.EnableCarHandlingDesignCalculationCheckbox.Text = "Use alternative car handling design calculation ";
            this.EnableCarHandlingDesignCalculationCheckbox.UseVisualStyleBackColor = true;
            // 
            // ExecutableEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 513);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ExecutableEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{0}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.ExecutableEditorForm_Resize);
            this.MainTabControl.ResumeLayout(false);
            this.HomeTabPage.ResumeLayout(false);
            this.ExportGroupBox.ResumeLayout(false);
            this.ExportGroupBox.PerformLayout();
            this.ImportGroupBox.ResumeLayout(false);
            this.ImportGroupBox.PerformLayout();
            this.InstructionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StringTableGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.identityCollectionBindingSource)).EndInit();
            this.TeamsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TeamsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamCollectionBindingSource)).EndInit();
            this.DriversTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DriversDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.driverCollectionBindingSource)).EndInit();
            this.EnginesTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EnginesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.engineCollectionBindingSource)).EndInit();
            this.TyresTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TyresDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tyreCollectionBindingSource)).EndInit();
            this.FuelsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FuelsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fuelCollectionBindingSource)).EndInit();
            this.TracksTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TracksDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCollectionBindingSource)).EndInit();
            this.EnhancementsTabPage.ResumeLayout(false);
            this.GameConfigurationGroupBox.ResumeLayout(false);
            this.GameConfigurationGroupBox.PerformLayout();
            this.PointsScoringSystemGroupBox.ResumeLayout(false);
            this.PointsScoringSystemGroupBox.PerformLayout();
            this.GameEnhancementsGroupBox.ResumeLayout(false);
            this.GameEnhancementsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage HomeTabPage;
        private System.Windows.Forms.GroupBox InstructionsGroupBox;
        private System.Windows.Forms.GroupBox ImportGroupBox;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.OpenFileDialog ProgramOpenFileDialog;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn powerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reliabilityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn responseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rigidityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn3;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn performanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toleranceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn driverDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn teamDataGridViewComboBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource identityCollectionBindingSource;
        private System.Windows.Forms.DataGridView StringTableGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button ImportExecutableFileButton;
        private System.Windows.Forms.TextBox ImportExecutableFileTextBox;
        private System.Windows.Forms.Label ImportExecutableFileLabel;
        private System.Windows.Forms.Button ImportLanguageFileButton;
        private System.Windows.Forms.TextBox ImportLanguageFileTextBox;
        private System.Windows.Forms.Label ImportLanguageFileLabel;
        private System.Windows.Forms.GroupBox ExportGroupBox;
        private System.Windows.Forms.Button ExportExecutableFileButton;
        private System.Windows.Forms.TextBox ExportExecutableFileTextBox;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Label ExportExecutableFileLabel;
        private System.Windows.Forms.Button ExportLanguageFileButton;
        private System.Windows.Forms.TextBox ExportLanguageFileTextBox;
        private System.Windows.Forms.Label ExportLanguageFileLabel;
        private System.Windows.Forms.RichTextBox InstructionsRichTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn lapsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn designDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unknown1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn unknown2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn unknown3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastRaceYearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastRaceTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn lapRecordDriverDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn lapRecordTeamDataGridViewTextBoxColumn;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn windDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage EnhancementsTabPage;
        private System.Windows.Forms.GroupBox GameEnhancementsGroupBox;
        private System.Windows.Forms.CheckBox DisableYellowFlagPenaltiesCheckBox;
        private System.Windows.Forms.CheckBox EnableCarPerformanceRaceCalcuationCheckbox;
        private System.Windows.Forms.CheckBox EnableCarHandlingDesignCalculationCheckbox;
        private System.Windows.Forms.GroupBox GameConfigurationGroupBox;
        private System.Windows.Forms.CheckBox DisablePitExitPriorityCheckBox;
        private System.Windows.Forms.CheckBox DisableMemoryResetForRaceSoundsCheckbox;
        private System.Windows.Forms.CheckBox DisableGameCdCheckBox;
        private System.Windows.Forms.CheckBox DisableGlobalUnlockCheckBox;
        private System.Windows.Forms.CheckBox DisableSampleAppCheckBox;
        private System.Windows.Forms.CheckBox DisableColourModeCheckBox;
        private System.Windows.Forms.GroupBox PointsScoringSystemGroupBox;
        private System.Windows.Forms.RadioButton PointsScoringSystemOption3RadioButton;
        private System.Windows.Forms.RadioButton PointsScoringSystemOption2RadioButton;
        private System.Windows.Forms.RadioButton PointsScoringSystemOption1RadioButton;
        private System.Windows.Forms.RadioButton PointsScoringSystemDefaultRadioButton;
    }
}
