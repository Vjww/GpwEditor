/*
namespace ExecutableEditor
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.HomeTabPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AutoDetectGameFolderButton = new System.Windows.Forms.Button();
            this.BrowseGameFolderButton = new System.Windows.Forms.Button();
            this.GameFolderTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ExportTextBox = new System.Windows.Forms.TextBox();
            this.ExportDataButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ImportTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ImportDataButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GameConfigurationGroupBox = new System.Windows.Forms.GroupBox();
            this.DisablePitExitPriorityCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableYellowFlagPenaltiesCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableGameCdCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableColourModeCheckBox = new System.Windows.Forms.CheckBox();
            this.PointsScoringSystemGroupBox = new System.Windows.Forms.GroupBox();
            this.PointsScoringSystemOption3RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemOption2RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemOption1RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemDefaultRadioButton = new System.Windows.Forms.RadioButton();
            this.ChassisDesignGroupBox = new System.Windows.Forms.GroupBox();
            this.ChassisDesignNoteLabel = new System.Windows.Forms.Label();
            this.ChassisDesignCalculationFormulaGroupBox = new System.Windows.Forms.GroupBox();
            this.CalculationFormulaOption3RadioButton = new System.Windows.Forms.RadioButton();
            this.CalculationFormulaOption2RadioButton = new System.Windows.Forms.RadioButton();
            this.CalculationFormulaOption1RadioButton = new System.Windows.Forms.RadioButton();
            this.CalculationFormulaDefaultRadioButton = new System.Windows.Forms.RadioButton();
            this.ChassisDesignGameDifficultyGroupBox = new System.Windows.Forms.GroupBox();
            this.GameDifficultyOption2RadioButton = new System.Windows.Forms.RadioButton();
            this.GameDifficultyOption1RadioButton = new System.Windows.Forms.RadioButton();
            this.GameDifficultyDefaultRadioButton = new System.Windows.Forms.RadioButton();
            this.ChassisDesignFormulaVariationGroupBox = new System.Windows.Forms.GroupBox();
            this.FormulaVariationDefaultRadioButton = new System.Windows.Forms.RadioButton();
            this.FormulaVariationOption2RadioButton = new System.Windows.Forms.RadioButton();
            this.FormulaVariationOption1RadioButton = new System.Windows.Forms.RadioButton();
            this.CalculationFormulaOption5RadioButton = new System.Windows.Forms.RadioButton();
            this.TeamsTabPage = new System.Windows.Forms.TabPage();
            this.TeamsDataGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DriversTabPage = new System.Windows.Forms.TabPage();
            this.DriversDataGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EnginesTabPage = new System.Windows.Forms.TabPage();
            this.EnginesDataGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.powerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reliabilityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rigidityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.engineCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TyresTabPage = new System.Windows.Forms.TabPage();
            this.TyresDataGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.FuelsTabPage = new System.Windows.Forms.TabPage();
            this.FuelsDataGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toleranceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuelCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FastestLapsTabPage = new System.Windows.Forms.TabPage();
            this.FastestLapsDataGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driverDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.teamDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ProgramOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MainTabControl.SuspendLayout();
            this.HomeTabPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.GameConfigurationGroupBox.SuspendLayout();
            this.PointsScoringSystemGroupBox.SuspendLayout();
            this.ChassisDesignGroupBox.SuspendLayout();
            this.ChassisDesignCalculationFormulaGroupBox.SuspendLayout();
            this.ChassisDesignGameDifficultyGroupBox.SuspendLayout();
            this.ChassisDesignFormulaVariationGroupBox.SuspendLayout();
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
            this.FastestLapsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FastestLapsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCollectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.HomeTabPage);
            this.MainTabControl.Controls.Add(this.tabPage1);
            this.MainTabControl.Controls.Add(this.TeamsTabPage);
            this.MainTabControl.Controls.Add(this.DriversTabPage);
            this.MainTabControl.Controls.Add(this.EnginesTabPage);
            this.MainTabControl.Controls.Add(this.TyresTabPage);
            this.MainTabControl.Controls.Add(this.FuelsTabPage);
            this.MainTabControl.Controls.Add(this.FastestLapsTabPage);
            this.MainTabControl.Location = new System.Drawing.Point(8, 8);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(696, 496);
            this.MainTabControl.TabIndex = 1;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_SelectedIndexChanged);
            // 
            // HomeTabPage
            // 
            this.HomeTabPage.Controls.Add(this.groupBox4);
            this.HomeTabPage.Controls.Add(this.groupBox3);
            this.HomeTabPage.Controls.Add(this.groupBox2);
            this.HomeTabPage.Controls.Add(this.groupBox1);
            this.HomeTabPage.Location = new System.Drawing.Point(4, 22);
            this.HomeTabPage.Name = "HomeTabPage";
            this.HomeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HomeTabPage.Size = new System.Drawing.Size(688, 470);
            this.HomeTabPage.TabIndex = 0;
            this.HomeTabPage.Text = "Home";
            this.HomeTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AutoDetectGameFolderButton);
            this.groupBox4.Controls.Add(this.BrowseGameFolderButton);
            this.groupBox4.Controls.Add(this.GameFolderTextBox);
            this.groupBox4.Location = new System.Drawing.Point(8, 280);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(672, 56);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Game folder";
            // 
            // AutoDetectGameFolderButton
            // 
            this.AutoDetectGameFolderButton.Location = new System.Drawing.Point(88, 24);
            this.AutoDetectGameFolderButton.Name = "AutoDetectGameFolderButton";
            this.AutoDetectGameFolderButton.Size = new System.Drawing.Size(75, 23);
            this.AutoDetectGameFolderButton.TabIndex = 2;
            this.AutoDetectGameFolderButton.Text = "Auto-detect";
            this.AutoDetectGameFolderButton.UseVisualStyleBackColor = true;
            this.AutoDetectGameFolderButton.Click += new System.EventHandler(this.AutoDetectGameFolderButton_Click);
            // 
            // BrowseGameFolderButton
            // 
            this.BrowseGameFolderButton.Location = new System.Drawing.Point(8, 24);
            this.BrowseGameFolderButton.Name = "BrowseGameFolderButton";
            this.BrowseGameFolderButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseGameFolderButton.TabIndex = 1;
            this.BrowseGameFolderButton.Text = "Browse...";
            this.BrowseGameFolderButton.UseVisualStyleBackColor = true;
            this.BrowseGameFolderButton.Click += new System.EventHandler(this.BrowseGameFolderButton_Click);
            // 
            // GameFolderTextBox
            // 
            this.GameFolderTextBox.Enabled = false;
            this.GameFolderTextBox.Location = new System.Drawing.Point(168, 24);
            this.GameFolderTextBox.Name = "GameFolderTextBox";
            this.GameFolderTextBox.Size = new System.Drawing.Size(496, 20);
            this.GameFolderTextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.richTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(672, 264);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "About";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(656, 240);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ExportTextBox);
            this.groupBox2.Controls.Add(this.ExportDataButton);
            this.groupBox2.Location = new System.Drawing.Point(8, 408);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(672, 56);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export data";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(88, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Exported to:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ExportTextBox
            // 
            this.ExportTextBox.Enabled = false;
            this.ExportTextBox.Location = new System.Drawing.Point(168, 24);
            this.ExportTextBox.Name = "ExportTextBox";
            this.ExportTextBox.Size = new System.Drawing.Size(496, 20);
            this.ExportTextBox.TabIndex = 1;
            // 
            // ExportDataButton
            // 
            this.ExportDataButton.Location = new System.Drawing.Point(8, 24);
            this.ExportDataButton.Name = "ExportDataButton";
            this.ExportDataButton.Size = new System.Drawing.Size(75, 23);
            this.ExportDataButton.TabIndex = 0;
            this.ExportDataButton.Text = "Export...";
            this.ExportDataButton.UseVisualStyleBackColor = true;
            this.ExportDataButton.Click += new System.EventHandler(this.ExportDataButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ImportTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ImportDataButton);
            this.groupBox1.Location = new System.Drawing.Point(8, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import data";
            // 
            // ImportTextBox
            // 
            this.ImportTextBox.Enabled = false;
            this.ImportTextBox.Location = new System.Drawing.Point(168, 24);
            this.ImportTextBox.Name = "ImportTextBox";
            this.ImportTextBox.Size = new System.Drawing.Size(496, 20);
            this.ImportTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(88, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Imported from:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ImportDataButton
            // 
            this.ImportDataButton.Location = new System.Drawing.Point(8, 24);
            this.ImportDataButton.Name = "ImportDataButton";
            this.ImportDataButton.Size = new System.Drawing.Size(75, 23);
            this.ImportDataButton.TabIndex = 0;
            this.ImportDataButton.Text = "Import...";
            this.ImportDataButton.UseVisualStyleBackColor = true;
            this.ImportDataButton.Click += new System.EventHandler(this.ImportDataButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GameConfigurationGroupBox);
            this.tabPage1.Controls.Add(this.PointsScoringSystemGroupBox);
            this.tabPage1.Controls.Add(this.ChassisDesignGroupBox);
            this.tabPage1.Controls.Add(this.CalculationFormulaOption5RadioButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(688, 470);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "Gameplay";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // GameConfigurationGroupBox
            // 
            this.GameConfigurationGroupBox.Controls.Add(this.DisablePitExitPriorityCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableYellowFlagPenaltiesCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableGameCdCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableColourModeCheckBox);
            this.GameConfigurationGroupBox.Location = new System.Drawing.Point(8, 8);
            this.GameConfigurationGroupBox.Name = "GameConfigurationGroupBox";
            this.GameConfigurationGroupBox.Size = new System.Drawing.Size(344, 128);
            this.GameConfigurationGroupBox.TabIndex = 14;
            this.GameConfigurationGroupBox.TabStop = false;
            this.GameConfigurationGroupBox.Text = "Game Configuration";
            // 
            // DisablePitExitPriorityCheckBox
            // 
            this.DisablePitExitPriorityCheckBox.AutoSize = true;
            this.DisablePitExitPriorityCheckBox.Location = new System.Drawing.Point(8, 96);
            this.DisablePitExitPriorityCheckBox.Name = "DisablePitExitPriorityCheckBox";
            this.DisablePitExitPriorityCheckBox.Size = new System.Drawing.Size(326, 17);
            this.DisablePitExitPriorityCheckBox.TabIndex = 3;
            this.DisablePitExitPriorityCheckBox.Text = "Disable pit-exit priority for lower numbered teams (enable bug fix)";
            this.DisablePitExitPriorityCheckBox.UseVisualStyleBackColor = true;
            this.DisablePitExitPriorityCheckBox.Visible = false;
            // 
            // DisableYellowFlagPenaltiesCheckBox
            // 
            this.DisableYellowFlagPenaltiesCheckBox.AutoSize = true;
            this.DisableYellowFlagPenaltiesCheckBox.Location = new System.Drawing.Point(8, 72);
            this.DisableYellowFlagPenaltiesCheckBox.Name = "DisableYellowFlagPenaltiesCheckBox";
            this.DisableYellowFlagPenaltiesCheckBox.Size = new System.Drawing.Size(233, 17);
            this.DisableYellowFlagPenaltiesCheckBox.TabIndex = 2;
            this.DisableYellowFlagPenaltiesCheckBox.Text = "Disable yellow flag penalties (enable bug fix)";
            this.DisableYellowFlagPenaltiesCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableGameCdCheckBox
            // 
            this.DisableGameCdCheckBox.AutoSize = true;
            this.DisableGameCdCheckBox.Location = new System.Drawing.Point(8, 48);
            this.DisableGameCdCheckBox.Name = "DisableGameCdCheckBox";
            this.DisableGameCdCheckBox.Size = new System.Drawing.Size(232, 17);
            this.DisableGameCdCheckBox.TabIndex = 1;
            this.DisableGameCdCheckBox.Text = "Disable check for game CD (enable No-CD)";
            this.DisableGameCdCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableColourModeCheckBox
            // 
            this.DisableColourModeCheckBox.AutoSize = true;
            this.DisableColourModeCheckBox.Location = new System.Drawing.Point(8, 24);
            this.DisableColourModeCheckBox.Name = "DisableColourModeCheckBox";
            this.DisableColourModeCheckBox.Size = new System.Drawing.Size(199, 17);
            this.DisableColourModeCheckBox.TabIndex = 0;
            this.DisableColourModeCheckBox.Text = "Disable check for 16-bit colour mode";
            this.DisableColourModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // PointsScoringSystemGroupBox
            // 
            this.PointsScoringSystemGroupBox.Controls.Add(this.PointsScoringSystemOption3RadioButton);
            this.PointsScoringSystemGroupBox.Controls.Add(this.PointsScoringSystemOption2RadioButton);
            this.PointsScoringSystemGroupBox.Controls.Add(this.PointsScoringSystemOption1RadioButton);
            this.PointsScoringSystemGroupBox.Controls.Add(this.PointsScoringSystemDefaultRadioButton);
            this.PointsScoringSystemGroupBox.Location = new System.Drawing.Point(360, 8);
            this.PointsScoringSystemGroupBox.Name = "PointsScoringSystemGroupBox";
            this.PointsScoringSystemGroupBox.Size = new System.Drawing.Size(320, 128);
            this.PointsScoringSystemGroupBox.TabIndex = 16;
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
            // ChassisDesignGroupBox
            // 
            this.ChassisDesignGroupBox.Controls.Add(this.ChassisDesignNoteLabel);
            this.ChassisDesignGroupBox.Controls.Add(this.ChassisDesignCalculationFormulaGroupBox);
            this.ChassisDesignGroupBox.Controls.Add(this.ChassisDesignGameDifficultyGroupBox);
            this.ChassisDesignGroupBox.Controls.Add(this.ChassisDesignFormulaVariationGroupBox);
            this.ChassisDesignGroupBox.Location = new System.Drawing.Point(8, 144);
            this.ChassisDesignGroupBox.Name = "ChassisDesignGroupBox";
            this.ChassisDesignGroupBox.Size = new System.Drawing.Size(672, 320);
            this.ChassisDesignGroupBox.TabIndex = 15;
            this.ChassisDesignGroupBox.TabStop = false;
            this.ChassisDesignGroupBox.Text = "Chassis Design";
            // 
            // ChassisDesignNoteLabel
            // 
            this.ChassisDesignNoteLabel.Location = new System.Drawing.Point(16, 280);
            this.ChassisDesignNoteLabel.Name = "ChassisDesignNoteLabel";
            this.ChassisDesignNoteLabel.Size = new System.Drawing.Size(640, 32);
            this.ChassisDesignNoteLabel.TabIndex = 13;
            this.ChassisDesignNoteLabel.Text = "Note: Calculation occurs when the player clicks on \"Complete Design\". Calculation" +
    "s for AI teams occur at the beginning of a new season.";
            this.ChassisDesignNoteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChassisDesignCalculationFormulaGroupBox
            // 
            this.ChassisDesignCalculationFormulaGroupBox.Controls.Add(this.CalculationFormulaOption3RadioButton);
            this.ChassisDesignCalculationFormulaGroupBox.Controls.Add(this.CalculationFormulaOption2RadioButton);
            this.ChassisDesignCalculationFormulaGroupBox.Controls.Add(this.CalculationFormulaOption1RadioButton);
            this.ChassisDesignCalculationFormulaGroupBox.Controls.Add(this.CalculationFormulaDefaultRadioButton);
            this.ChassisDesignCalculationFormulaGroupBox.Location = new System.Drawing.Point(16, 24);
            this.ChassisDesignCalculationFormulaGroupBox.Name = "ChassisDesignCalculationFormulaGroupBox";
            this.ChassisDesignCalculationFormulaGroupBox.Size = new System.Drawing.Size(640, 88);
            this.ChassisDesignCalculationFormulaGroupBox.TabIndex = 12;
            this.ChassisDesignCalculationFormulaGroupBox.TabStop = false;
            this.ChassisDesignCalculationFormulaGroupBox.Text = "Calculation Formula";
            // 
            // CalculationFormulaOption3RadioButton
            // 
            this.CalculationFormulaOption3RadioButton.AutoSize = true;
            this.CalculationFormulaOption3RadioButton.Location = new System.Drawing.Point(16, 64);
            this.CalculationFormulaOption3RadioButton.Name = "CalculationFormulaOption3RadioButton";
            this.CalculationFormulaOption3RadioButton.Size = new System.Drawing.Size(427, 17);
            this.CalculationFormulaOption3RadioButton.TabIndex = 13;
            this.CalculationFormulaOption3RadioButton.Text = "Recommended - Use 25% designer/75% engineer skill levels (for player and AI teams" +
    ")";
            this.CalculationFormulaOption3RadioButton.UseVisualStyleBackColor = true;
            // 
            // CalculationFormulaOption2RadioButton
            // 
            this.CalculationFormulaOption2RadioButton.AutoSize = true;
            this.CalculationFormulaOption2RadioButton.Location = new System.Drawing.Point(16, 48);
            this.CalculationFormulaOption2RadioButton.Name = "CalculationFormulaOption2RadioButton";
            this.CalculationFormulaOption2RadioButton.Size = new System.Drawing.Size(301, 17);
            this.CalculationFormulaOption2RadioButton.TabIndex = 10;
            this.CalculationFormulaOption2RadioButton.Text = "Option2 - Use engineer skill levels (for player and AI teams)";
            this.CalculationFormulaOption2RadioButton.UseVisualStyleBackColor = true;
            // 
            // CalculationFormulaOption1RadioButton
            // 
            this.CalculationFormulaOption1RadioButton.AutoSize = true;
            this.CalculationFormulaOption1RadioButton.Location = new System.Drawing.Point(16, 32);
            this.CalculationFormulaOption1RadioButton.Name = "CalculationFormulaOption1RadioButton";
            this.CalculationFormulaOption1RadioButton.Size = new System.Drawing.Size(300, 17);
            this.CalculationFormulaOption1RadioButton.TabIndex = 9;
            this.CalculationFormulaOption1RadioButton.Text = "Option1 - Use designer skill levels (for player and AI teams)";
            this.CalculationFormulaOption1RadioButton.UseVisualStyleBackColor = true;
            // 
            // CalculationFormulaDefaultRadioButton
            // 
            this.CalculationFormulaDefaultRadioButton.AutoSize = true;
            this.CalculationFormulaDefaultRadioButton.Checked = true;
            this.CalculationFormulaDefaultRadioButton.Location = new System.Drawing.Point(16, 16);
            this.CalculationFormulaDefaultRadioButton.Name = "CalculationFormulaDefaultRadioButton";
            this.CalculationFormulaDefaultRadioButton.Size = new System.Drawing.Size(344, 17);
            this.CalculationFormulaDefaultRadioButton.TabIndex = 8;
            this.CalculationFormulaDefaultRadioButton.TabStop = true;
            this.CalculationFormulaDefaultRadioButton.Text = "Default - Use designer skill levels (AI teams use engineer skill levels)";
            this.CalculationFormulaDefaultRadioButton.UseVisualStyleBackColor = true;
            // 
            // ChassisDesignGameDifficultyGroupBox
            // 
            this.ChassisDesignGameDifficultyGroupBox.Controls.Add(this.GameDifficultyOption2RadioButton);
            this.ChassisDesignGameDifficultyGroupBox.Controls.Add(this.GameDifficultyOption1RadioButton);
            this.ChassisDesignGameDifficultyGroupBox.Controls.Add(this.GameDifficultyDefaultRadioButton);
            this.ChassisDesignGameDifficultyGroupBox.Location = new System.Drawing.Point(16, 200);
            this.ChassisDesignGameDifficultyGroupBox.Name = "ChassisDesignGameDifficultyGroupBox";
            this.ChassisDesignGameDifficultyGroupBox.Size = new System.Drawing.Size(640, 72);
            this.ChassisDesignGameDifficultyGroupBox.TabIndex = 11;
            this.ChassisDesignGameDifficultyGroupBox.TabStop = false;
            this.ChassisDesignGameDifficultyGroupBox.Text = "Game Difficulty";
            // 
            // GameDifficultyOption2RadioButton
            // 
            this.GameDifficultyOption2RadioButton.AutoSize = true;
            this.GameDifficultyOption2RadioButton.Location = new System.Drawing.Point(16, 48);
            this.GameDifficultyOption2RadioButton.Name = "GameDifficultyOption2RadioButton";
            this.GameDifficultyOption2RadioButton.Size = new System.Drawing.Size(340, 17);
            this.GameDifficultyOption2RadioButton.TabIndex = 2;
            this.GameDifficultyOption2RadioButton.Text = "Option2 - Reduce chassis handling by 20% on designs (player only)";
            this.GameDifficultyOption2RadioButton.UseVisualStyleBackColor = true;
            // 
            // GameDifficultyOption1RadioButton
            // 
            this.GameDifficultyOption1RadioButton.AutoSize = true;
            this.GameDifficultyOption1RadioButton.Location = new System.Drawing.Point(16, 32);
            this.GameDifficultyOption1RadioButton.Name = "GameDifficultyOption1RadioButton";
            this.GameDifficultyOption1RadioButton.Size = new System.Drawing.Size(340, 17);
            this.GameDifficultyOption1RadioButton.TabIndex = 1;
            this.GameDifficultyOption1RadioButton.Text = "Option1 - Reduce chassis handling by 10% on designs (player only)";
            this.GameDifficultyOption1RadioButton.UseVisualStyleBackColor = true;
            // 
            // GameDifficultyDefaultRadioButton
            // 
            this.GameDifficultyDefaultRadioButton.AutoSize = true;
            this.GameDifficultyDefaultRadioButton.Checked = true;
            this.GameDifficultyDefaultRadioButton.Location = new System.Drawing.Point(16, 16);
            this.GameDifficultyDefaultRadioButton.Name = "GameDifficultyDefaultRadioButton";
            this.GameDifficultyDefaultRadioButton.Size = new System.Drawing.Size(174, 17);
            this.GameDifficultyDefaultRadioButton.TabIndex = 0;
            this.GameDifficultyDefaultRadioButton.TabStop = true;
            this.GameDifficultyDefaultRadioButton.Text = "Default - No change to difficulty";
            this.GameDifficultyDefaultRadioButton.UseVisualStyleBackColor = true;
            // 
            // ChassisDesignFormulaVariationGroupBox
            // 
            this.ChassisDesignFormulaVariationGroupBox.Controls.Add(this.FormulaVariationDefaultRadioButton);
            this.ChassisDesignFormulaVariationGroupBox.Controls.Add(this.FormulaVariationOption2RadioButton);
            this.ChassisDesignFormulaVariationGroupBox.Controls.Add(this.FormulaVariationOption1RadioButton);
            this.ChassisDesignFormulaVariationGroupBox.Location = new System.Drawing.Point(16, 120);
            this.ChassisDesignFormulaVariationGroupBox.Name = "ChassisDesignFormulaVariationGroupBox";
            this.ChassisDesignFormulaVariationGroupBox.Size = new System.Drawing.Size(640, 72);
            this.ChassisDesignFormulaVariationGroupBox.TabIndex = 10;
            this.ChassisDesignFormulaVariationGroupBox.TabStop = false;
            this.ChassisDesignFormulaVariationGroupBox.Text = "Formula Variation";
            // 
            // FormulaVariationDefaultRadioButton
            // 
            this.FormulaVariationDefaultRadioButton.AutoSize = true;
            this.FormulaVariationDefaultRadioButton.Checked = true;
            this.FormulaVariationDefaultRadioButton.Location = new System.Drawing.Point(16, 16);
            this.FormulaVariationDefaultRadioButton.Name = "FormulaVariationDefaultRadioButton";
            this.FormulaVariationDefaultRadioButton.Size = new System.Drawing.Size(323, 17);
            this.FormulaVariationDefaultRadioButton.TabIndex = 8;
            this.FormulaVariationDefaultRadioButton.TabStop = true;
            this.FormulaVariationDefaultRadioButton.Text = "Default - Random variation of +/- 5% on designs (AI teams only)";
            this.FormulaVariationDefaultRadioButton.UseVisualStyleBackColor = true;
            // 
            // FormulaVariationOption2RadioButton
            // 
            this.FormulaVariationOption2RadioButton.AutoSize = true;
            this.FormulaVariationOption2RadioButton.Location = new System.Drawing.Point(16, 48);
            this.FormulaVariationOption2RadioButton.Name = "FormulaVariationOption2RadioButton";
            this.FormulaVariationOption2RadioButton.Size = new System.Drawing.Size(412, 17);
            this.FormulaVariationOption2RadioButton.TabIndex = 7;
            this.FormulaVariationOption2RadioButton.Text = "Recommended - Random variation of +/- 10% on designs (for player and AI teams)";
            this.FormulaVariationOption2RadioButton.UseVisualStyleBackColor = true;
            // 
            // FormulaVariationOption1RadioButton
            // 
            this.FormulaVariationOption1RadioButton.AutoSize = true;
            this.FormulaVariationOption1RadioButton.Location = new System.Drawing.Point(16, 32);
            this.FormulaVariationOption1RadioButton.Name = "FormulaVariationOption1RadioButton";
            this.FormulaVariationOption1RadioButton.Size = new System.Drawing.Size(371, 17);
            this.FormulaVariationOption1RadioButton.TabIndex = 6;
            this.FormulaVariationOption1RadioButton.Text = "Option1 - Random variation of +/- 5% on designs (for player and AI teams)";
            this.FormulaVariationOption1RadioButton.UseVisualStyleBackColor = true;
            // 
            // CalculationFormulaOption5RadioButton
            // 
            this.CalculationFormulaOption5RadioButton.AutoSize = true;
            this.CalculationFormulaOption5RadioButton.Location = new System.Drawing.Point(16, 144);
            this.CalculationFormulaOption5RadioButton.Name = "CalculationFormulaOption5RadioButton";
            this.CalculationFormulaOption5RadioButton.Size = new System.Drawing.Size(427, 17);
            this.CalculationFormulaOption5RadioButton.TabIndex = 17;
            this.CalculationFormulaOption5RadioButton.Text = "Recommended - Use 25% designer/75% engineer skill levels (for player and AI teams" +
    ")";
            this.CalculationFormulaOption5RadioButton.UseVisualStyleBackColor = true;
            // 
            // TeamsTabPage
            // 
            this.TeamsTabPage.Controls.Add(this.TeamsDataGridView);
            this.TeamsTabPage.Location = new System.Drawing.Point(4, 22);
            this.TeamsTabPage.Name = "TeamsTabPage";
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
            this.nameDataGridViewTextBoxColumn});
            this.TeamsDataGridView.DataSource = this.teamCollectionBindingSource;
            this.TeamsDataGridView.Location = new System.Drawing.Point(8, 8);
            this.TeamsDataGridView.Name = "TeamsDataGridView";
            this.TeamsDataGridView.Size = new System.Drawing.Size(672, 456);
            this.TeamsDataGridView.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // teamCollectionBindingSource
            // 
            this.teamCollectionBindingSource.DataSource = typeof(Common.GameObjects.Collections.TeamCollection);
            // 
            // DriversTabPage
            // 
            this.DriversTabPage.Controls.Add(this.DriversDataGridView);
            this.DriversTabPage.Location = new System.Drawing.Point(4, 22);
            this.DriversTabPage.Name = "DriversTabPage";
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
            this.nameDataGridViewTextBoxColumn1});
            this.DriversDataGridView.DataSource = this.driverCollectionBindingSource;
            this.DriversDataGridView.Location = new System.Drawing.Point(8, 8);
            this.DriversDataGridView.Name = "DriversDataGridView";
            this.DriversDataGridView.Size = new System.Drawing.Size(672, 456);
            this.DriversDataGridView.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // driverCollectionBindingSource
            // 
            this.driverCollectionBindingSource.DataSource = typeof(Common.GameObjects.Collections.DriverCollection);
            // 
            // EnginesTabPage
            // 
            this.EnginesTabPage.Controls.Add(this.EnginesDataGridView);
            this.EnginesTabPage.Location = new System.Drawing.Point(4, 22);
            this.EnginesTabPage.Name = "EnginesTabPage";
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
            this.nameDataGridViewTextBoxColumn2,
            this.fuelDataGridViewTextBoxColumn,
            this.heatDataGridViewTextBoxColumn,
            this.powerDataGridViewTextBoxColumn,
            this.reliabilityDataGridViewTextBoxColumn,
            this.responseDataGridViewTextBoxColumn,
            this.rigidityDataGridViewTextBoxColumn,
            this.weightDataGridViewTextBoxColumn});
            this.EnginesDataGridView.DataSource = this.engineCollectionBindingSource;
            this.EnginesDataGridView.Location = new System.Drawing.Point(8, 8);
            this.EnginesDataGridView.Name = "EnginesDataGridView";
            this.EnginesDataGridView.Size = new System.Drawing.Size(672, 456);
            this.EnginesDataGridView.TabIndex = 0;
            this.EnginesDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.EnginesDataGridView_CellValidating);
            // 
            // nameDataGridViewTextBoxColumn2
            // 
            this.nameDataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn2.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn2.Name = "nameDataGridViewTextBoxColumn2";
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
            this.engineCollectionBindingSource.DataSource = typeof(Common.GameObjects.Collections.EngineCollection);
            // 
            // TyresTabPage
            // 
            this.TyresTabPage.Controls.Add(this.TyresDataGridView);
            this.TyresTabPage.Location = new System.Drawing.Point(4, 22);
            this.TyresTabPage.Name = "TyresTabPage";
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
            this.nameDataGridViewTextBoxColumn3,
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
            this.TyresDataGridView.Location = new System.Drawing.Point(8, 8);
            this.TyresDataGridView.Name = "TyresDataGridView";
            this.TyresDataGridView.Size = new System.Drawing.Size(672, 456);
            this.TyresDataGridView.TabIndex = 0;
            this.TyresDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.TyresDataGridView_CellValidating);
            // 
            // nameDataGridViewTextBoxColumn3
            // 
            this.nameDataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn3.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn3.Name = "nameDataGridViewTextBoxColumn3";
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
            this.tyreCollectionBindingSource.DataSource = typeof(Common.GameObjects.Collections.TyreCollection);
            // 
            // FuelsTabPage
            // 
            this.FuelsTabPage.Controls.Add(this.FuelsDataGridView);
            this.FuelsTabPage.Location = new System.Drawing.Point(4, 22);
            this.FuelsTabPage.Name = "FuelsTabPage";
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
            this.nameDataGridViewTextBoxColumn4,
            this.performanceDataGridViewTextBoxColumn,
            this.toleranceDataGridViewTextBoxColumn});
            this.FuelsDataGridView.DataSource = this.fuelCollectionBindingSource;
            this.FuelsDataGridView.Location = new System.Drawing.Point(8, 8);
            this.FuelsDataGridView.Name = "FuelsDataGridView";
            this.FuelsDataGridView.Size = new System.Drawing.Size(672, 456);
            this.FuelsDataGridView.TabIndex = 0;
            this.FuelsDataGridView.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.FuelsDataGridView_CellValidating);
            // 
            // nameDataGridViewTextBoxColumn4
            // 
            this.nameDataGridViewTextBoxColumn4.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn4.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn4.Name = "nameDataGridViewTextBoxColumn4";
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
            this.fuelCollectionBindingSource.DataSource = typeof(Common.GameObjects.Collections.FuelCollection);
            // 
            // FastestLapsTabPage
            // 
            this.FastestLapsTabPage.Controls.Add(this.FastestLapsDataGridView);
            this.FastestLapsTabPage.Location = new System.Drawing.Point(4, 22);
            this.FastestLapsTabPage.Name = "FastestLapsTabPage";
            this.FastestLapsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FastestLapsTabPage.Size = new System.Drawing.Size(688, 470);
            this.FastestLapsTabPage.TabIndex = 6;
            this.FastestLapsTabPage.Text = "Fastest Laps";
            this.FastestLapsTabPage.UseVisualStyleBackColor = true;
            // 
            // FastestLapsDataGridView
            // 
            this.FastestLapsDataGridView.AutoGenerateColumns = false;
            this.FastestLapsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FastestLapsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn5,
            this.driverDataGridViewComboBoxColumn,
            this.teamDataGridViewComboBoxColumn,
            this.yearDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn});
            this.FastestLapsDataGridView.DataSource = this.trackCollectionBindingSource;
            this.FastestLapsDataGridView.Location = new System.Drawing.Point(8, 8);
            this.FastestLapsDataGridView.Name = "FastestLapsDataGridView";
            this.FastestLapsDataGridView.Size = new System.Drawing.Size(672, 456);
            this.FastestLapsDataGridView.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn5
            // 
            this.nameDataGridViewTextBoxColumn5.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn5.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn5.Name = "nameDataGridViewTextBoxColumn5";
            // 
            // driverDataGridViewComboBoxColumn
            // 
            this.driverDataGridViewComboBoxColumn.DataPropertyName = "Driver";
            this.driverDataGridViewComboBoxColumn.HeaderText = "Driver";
            this.driverDataGridViewComboBoxColumn.Name = "driverDataGridViewComboBoxColumn";
            this.driverDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.driverDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // teamDataGridViewComboBoxColumn
            // 
            this.teamDataGridViewComboBoxColumn.DataPropertyName = "Team";
            this.teamDataGridViewComboBoxColumn.HeaderText = "Team";
            this.teamDataGridViewComboBoxColumn.Name = "teamDataGridViewComboBoxColumn";
            this.teamDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.teamDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Year";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "Time";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            // 
            // trackCollectionBindingSource
            // 
            this.trackCollectionBindingSource.DataSource = typeof(Common.GameObjects.Collections.TrackCollection);
            // 
            // FolderBrowserDialog
            // 
            this.FolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 513);
            this.Controls.Add(this.MainTabControl);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{0}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.MainTabControl.ResumeLayout(false);
            this.HomeTabPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.GameConfigurationGroupBox.ResumeLayout(false);
            this.GameConfigurationGroupBox.PerformLayout();
            this.PointsScoringSystemGroupBox.ResumeLayout(false);
            this.PointsScoringSystemGroupBox.PerformLayout();
            this.ChassisDesignGroupBox.ResumeLayout(false);
            this.ChassisDesignCalculationFormulaGroupBox.ResumeLayout(false);
            this.ChassisDesignCalculationFormulaGroupBox.PerformLayout();
            this.ChassisDesignGameDifficultyGroupBox.ResumeLayout(false);
            this.ChassisDesignGameDifficultyGroupBox.PerformLayout();
            this.ChassisDesignFormulaVariationGroupBox.ResumeLayout(false);
            this.ChassisDesignFormulaVariationGroupBox.PerformLayout();
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
            this.FastestLapsTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FastestLapsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCollectionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage HomeTabPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button ImportDataButton;
        private System.Windows.Forms.TextBox ImportTextBox;
        private System.Windows.Forms.Button ExportDataButton;
        private System.Windows.Forms.TextBox ExportTextBox;
        private System.Windows.Forms.Button AutoDetectGameFolderButton;
        private System.Windows.Forms.Button BrowseGameFolderButton;
        private System.Windows.Forms.TextBox GameFolderTextBox;
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
        private System.Windows.Forms.TabPage FastestLapsTabPage;
        private System.Windows.Forms.DataGridView FastestLapsDataGridView;
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
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox GameConfigurationGroupBox;
        private System.Windows.Forms.CheckBox DisablePitExitPriorityCheckBox;
        private System.Windows.Forms.CheckBox DisableYellowFlagPenaltiesCheckBox;
        private System.Windows.Forms.CheckBox DisableGameCdCheckBox;
        private System.Windows.Forms.CheckBox DisableColourModeCheckBox;
        private System.Windows.Forms.GroupBox PointsScoringSystemGroupBox;
        private System.Windows.Forms.RadioButton PointsScoringSystemOption3RadioButton;
        private System.Windows.Forms.RadioButton PointsScoringSystemOption2RadioButton;
        private System.Windows.Forms.RadioButton PointsScoringSystemOption1RadioButton;
        private System.Windows.Forms.RadioButton PointsScoringSystemDefaultRadioButton;
        private System.Windows.Forms.GroupBox ChassisDesignGroupBox;
        private System.Windows.Forms.Label ChassisDesignNoteLabel;
        private System.Windows.Forms.GroupBox ChassisDesignCalculationFormulaGroupBox;
        private System.Windows.Forms.RadioButton CalculationFormulaOption3RadioButton;
        private System.Windows.Forms.RadioButton CalculationFormulaOption2RadioButton;
        private System.Windows.Forms.RadioButton CalculationFormulaOption1RadioButton;
        private System.Windows.Forms.RadioButton CalculationFormulaDefaultRadioButton;
        private System.Windows.Forms.GroupBox ChassisDesignGameDifficultyGroupBox;
        private System.Windows.Forms.RadioButton GameDifficultyOption2RadioButton;
        private System.Windows.Forms.RadioButton GameDifficultyOption1RadioButton;
        private System.Windows.Forms.RadioButton GameDifficultyDefaultRadioButton;
        private System.Windows.Forms.GroupBox ChassisDesignFormulaVariationGroupBox;
        private System.Windows.Forms.RadioButton FormulaVariationDefaultRadioButton;
        private System.Windows.Forms.RadioButton FormulaVariationOption2RadioButton;
        private System.Windows.Forms.RadioButton FormulaVariationOption1RadioButton;
        private System.Windows.Forms.RadioButton CalculationFormulaOption5RadioButton;
    }
}
*/
