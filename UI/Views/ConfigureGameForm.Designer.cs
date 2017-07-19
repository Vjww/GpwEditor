namespace GpwEditor.Views
{
    partial class ConfigureGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureGameForm));
            this.ConfigureGameTabControl = new System.Windows.Forms.TabControl();
            this.HomeTabPage = new System.Windows.Forms.TabPage();
            this.OverviewGroupBox = new System.Windows.Forms.GroupBox();
            this.OverviewRichTextBox = new System.Windows.Forms.RichTextBox();
            this.FilesGroupBox = new System.Windows.Forms.GroupBox();
            this.GameFolderPathLabel = new System.Windows.Forms.Label();
            this.GameExecutablePathLabel = new System.Windows.Forms.Label();
            this.LanguageFilePathLabel = new System.Windows.Forms.Label();
            this.GameFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.GameExecutablePathTextBox = new System.Windows.Forms.TextBox();
            this.BrowseGameFolderButton = new System.Windows.Forms.Button();
            this.LanguageFilePathTextBox = new System.Windows.Forms.TextBox();
            this.BrowseGameExecutableButton = new System.Windows.Forms.Button();
            this.BrowseLanguageFileButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.CompatibilityTabPage = new System.Windows.Forms.TabPage();
            this.CompatibilityGroupBox = new System.Windows.Forms.GroupBox();
            this.DisableGameCdCheckBox = new System.Windows.Forms.CheckBox();
            this.DisablePitExitPriorityCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableColourModeCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableMemoryResetForRaceSoundsCheckbox = new System.Windows.Forms.CheckBox();
            this.DisableSampleAppCheckBox = new System.Windows.Forms.CheckBox();
            this.GameplayTabPage = new System.Windows.Forms.TabPage();
            this.GameplayGroupBox = new System.Windows.Forms.GroupBox();
            this.DisableYellowFlagPenaltiesCheckBox = new System.Windows.Forms.CheckBox();
            this.EnableCarPerformanceRaceCalcuationCheckbox = new System.Windows.Forms.CheckBox();
            this.EnableCarHandlingDesignCalculationCheckbox = new System.Windows.Forms.CheckBox();
            this.CommentaryTabPage = new System.Windows.Forms.TabPage();
            this.CommentaryGroupBox = new System.Windows.Forms.GroupBox();
            this.CommentaryModifiedRadioButton = new System.Windows.Forms.RadioButton();
            this.CommentaryOriginalRadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemTabPage = new System.Windows.Forms.TabPage();
            this.PointsScoringSystemGroupBox = new System.Windows.Forms.GroupBox();
            this.PointsScoringSystemOption3RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemOption2RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemOption1RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemDefaultRadioButton = new System.Windows.Forms.RadioButton();
            this.ViewportsTabPage = new System.Windows.Forms.TabPage();
            this.ViewportsGroupBox = new System.Windows.Forms.GroupBox();
            this.ConfigureGameTabControl.SuspendLayout();
            this.HomeTabPage.SuspendLayout();
            this.OverviewGroupBox.SuspendLayout();
            this.FilesGroupBox.SuspendLayout();
            this.CompatibilityTabPage.SuspendLayout();
            this.CompatibilityGroupBox.SuspendLayout();
            this.GameplayTabPage.SuspendLayout();
            this.GameplayGroupBox.SuspendLayout();
            this.CommentaryTabPage.SuspendLayout();
            this.CommentaryGroupBox.SuspendLayout();
            this.PointsScoringSystemTabPage.SuspendLayout();
            this.PointsScoringSystemGroupBox.SuspendLayout();
            this.ViewportsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigureGameTabControl
            // 
            this.ConfigureGameTabControl.Controls.Add(this.HomeTabPage);
            this.ConfigureGameTabControl.Controls.Add(this.CompatibilityTabPage);
            this.ConfigureGameTabControl.Controls.Add(this.GameplayTabPage);
            this.ConfigureGameTabControl.Controls.Add(this.CommentaryTabPage);
            this.ConfigureGameTabControl.Controls.Add(this.PointsScoringSystemTabPage);
            this.ConfigureGameTabControl.Controls.Add(this.ViewportsTabPage);
            this.ConfigureGameTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigureGameTabControl.Location = new System.Drawing.Point(3, 3);
            this.ConfigureGameTabControl.Name = "ConfigureGameTabControl";
            this.ConfigureGameTabControl.SelectedIndex = 0;
            this.ConfigureGameTabControl.Size = new System.Drawing.Size(938, 555);
            this.ConfigureGameTabControl.TabIndex = 0;
            // 
            // HomeTabPage
            // 
            this.HomeTabPage.Controls.Add(this.OverviewGroupBox);
            this.HomeTabPage.Controls.Add(this.FilesGroupBox);
            this.HomeTabPage.Location = new System.Drawing.Point(4, 22);
            this.HomeTabPage.Name = "HomeTabPage";
            this.HomeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HomeTabPage.Size = new System.Drawing.Size(930, 529);
            this.HomeTabPage.TabIndex = 0;
            this.HomeTabPage.Text = "Home";
            this.HomeTabPage.UseVisualStyleBackColor = true;
            // 
            // OverviewGroupBox
            // 
            this.OverviewGroupBox.Controls.Add(this.OverviewRichTextBox);
            this.OverviewGroupBox.Location = new System.Drawing.Point(6, 118);
            this.OverviewGroupBox.Name = "OverviewGroupBox";
            this.OverviewGroupBox.Size = new System.Drawing.Size(918, 405);
            this.OverviewGroupBox.TabIndex = 4;
            this.OverviewGroupBox.TabStop = false;
            // 
            // OverviewRichTextBox
            // 
            this.OverviewRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.OverviewRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OverviewRichTextBox.Location = new System.Drawing.Point(6, 19);
            this.OverviewRichTextBox.Name = "OverviewRichTextBox";
            this.OverviewRichTextBox.ReadOnly = true;
            this.OverviewRichTextBox.Size = new System.Drawing.Size(906, 380);
            this.OverviewRichTextBox.TabIndex = 2;
            this.OverviewRichTextBox.Text = resources.GetString("OverviewRichTextBox.Text");
            // 
            // FilesGroupBox
            // 
            this.FilesGroupBox.Controls.Add(this.GameFolderPathLabel);
            this.FilesGroupBox.Controls.Add(this.GameExecutablePathLabel);
            this.FilesGroupBox.Controls.Add(this.LanguageFilePathLabel);
            this.FilesGroupBox.Controls.Add(this.GameFolderPathTextBox);
            this.FilesGroupBox.Controls.Add(this.GameExecutablePathTextBox);
            this.FilesGroupBox.Controls.Add(this.BrowseGameFolderButton);
            this.FilesGroupBox.Controls.Add(this.LanguageFilePathTextBox);
            this.FilesGroupBox.Controls.Add(this.BrowseGameExecutableButton);
            this.FilesGroupBox.Controls.Add(this.BrowseLanguageFileButton);
            this.FilesGroupBox.Controls.Add(this.ExportButton);
            this.FilesGroupBox.Controls.Add(this.ImportButton);
            this.FilesGroupBox.Location = new System.Drawing.Point(6, 6);
            this.FilesGroupBox.Name = "FilesGroupBox";
            this.FilesGroupBox.Size = new System.Drawing.Size(918, 106);
            this.FilesGroupBox.TabIndex = 2;
            this.FilesGroupBox.TabStop = false;
            this.FilesGroupBox.Text = "Files";
            // 
            // GameFolderPathLabel
            // 
            this.GameFolderPathLabel.AutoSize = true;
            this.GameFolderPathLabel.Location = new System.Drawing.Point(30, 24);
            this.GameFolderPathLabel.Name = "GameFolderPathLabel";
            this.GameFolderPathLabel.Size = new System.Drawing.Size(70, 13);
            this.GameFolderPathLabel.TabIndex = 5;
            this.GameFolderPathLabel.Text = "Game Folder:";
            // 
            // GameExecutablePathLabel
            // 
            this.GameExecutablePathLabel.AutoSize = true;
            this.GameExecutablePathLabel.Location = new System.Drawing.Point(6, 53);
            this.GameExecutablePathLabel.Name = "GameExecutablePathLabel";
            this.GameExecutablePathLabel.Size = new System.Drawing.Size(94, 13);
            this.GameExecutablePathLabel.TabIndex = 6;
            this.GameExecutablePathLabel.Text = "Game Executable:";
            // 
            // LanguageFilePathLabel
            // 
            this.LanguageFilePathLabel.AutoSize = true;
            this.LanguageFilePathLabel.Location = new System.Drawing.Point(23, 82);
            this.LanguageFilePathLabel.Name = "LanguageFilePathLabel";
            this.LanguageFilePathLabel.Size = new System.Drawing.Size(77, 13);
            this.LanguageFilePathLabel.TabIndex = 7;
            this.LanguageFilePathLabel.Text = "Language File:";
            // 
            // GameFolderPathTextBox
            // 
            this.GameFolderPathTextBox.Location = new System.Drawing.Point(106, 21);
            this.GameFolderPathTextBox.Name = "GameFolderPathTextBox";
            this.GameFolderPathTextBox.ReadOnly = true;
            this.GameFolderPathTextBox.Size = new System.Drawing.Size(644, 20);
            this.GameFolderPathTextBox.TabIndex = 8;
            this.GameFolderPathTextBox.TabStop = false;
            // 
            // GameExecutablePathTextBox
            // 
            this.GameExecutablePathTextBox.Location = new System.Drawing.Point(106, 50);
            this.GameExecutablePathTextBox.Name = "GameExecutablePathTextBox";
            this.GameExecutablePathTextBox.ReadOnly = true;
            this.GameExecutablePathTextBox.Size = new System.Drawing.Size(644, 20);
            this.GameExecutablePathTextBox.TabIndex = 9;
            this.GameExecutablePathTextBox.TabStop = false;
            // 
            // BrowseGameFolderButton
            // 
            this.BrowseGameFolderButton.Location = new System.Drawing.Point(756, 19);
            this.BrowseGameFolderButton.Name = "BrowseGameFolderButton";
            this.BrowseGameFolderButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseGameFolderButton.TabIndex = 12;
            this.BrowseGameFolderButton.Text = "Browse...";
            this.BrowseGameFolderButton.UseVisualStyleBackColor = true;
            this.BrowseGameFolderButton.Click += new System.EventHandler(this.BrowseGameFolderButton_Click);
            // 
            // LanguageFilePathTextBox
            // 
            this.LanguageFilePathTextBox.Location = new System.Drawing.Point(106, 79);
            this.LanguageFilePathTextBox.Name = "LanguageFilePathTextBox";
            this.LanguageFilePathTextBox.ReadOnly = true;
            this.LanguageFilePathTextBox.Size = new System.Drawing.Size(644, 20);
            this.LanguageFilePathTextBox.TabIndex = 10;
            this.LanguageFilePathTextBox.TabStop = false;
            // 
            // BrowseGameExecutableButton
            // 
            this.BrowseGameExecutableButton.Location = new System.Drawing.Point(756, 48);
            this.BrowseGameExecutableButton.Name = "BrowseGameExecutableButton";
            this.BrowseGameExecutableButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseGameExecutableButton.TabIndex = 13;
            this.BrowseGameExecutableButton.Text = "Browse...";
            this.BrowseGameExecutableButton.UseVisualStyleBackColor = true;
            this.BrowseGameExecutableButton.Click += new System.EventHandler(this.BrowseGameExecutableButton_Click);
            // 
            // BrowseLanguageFileButton
            // 
            this.BrowseLanguageFileButton.Location = new System.Drawing.Point(756, 77);
            this.BrowseLanguageFileButton.Name = "BrowseLanguageFileButton";
            this.BrowseLanguageFileButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseLanguageFileButton.TabIndex = 11;
            this.BrowseLanguageFileButton.Text = "Browse...";
            this.BrowseLanguageFileButton.UseVisualStyleBackColor = true;
            this.BrowseLanguageFileButton.Click += new System.EventHandler(this.BrowseLanguageFileButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(837, 63);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 37);
            this.ExportButton.TabIndex = 4;
            this.ExportButton.Text = "Export...";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(837, 19);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(75, 37);
            this.ImportButton.TabIndex = 3;
            this.ImportButton.Text = "Import...";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // CompatibilityTabPage
            // 
            this.CompatibilityTabPage.Controls.Add(this.CompatibilityGroupBox);
            this.CompatibilityTabPage.Location = new System.Drawing.Point(4, 22);
            this.CompatibilityTabPage.Name = "CompatibilityTabPage";
            this.CompatibilityTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CompatibilityTabPage.Size = new System.Drawing.Size(930, 529);
            this.CompatibilityTabPage.TabIndex = 1;
            this.CompatibilityTabPage.Text = "Compatibility";
            this.CompatibilityTabPage.UseVisualStyleBackColor = true;
            // 
            // CompatibilityGroupBox
            // 
            this.CompatibilityGroupBox.Controls.Add(this.DisableGameCdCheckBox);
            this.CompatibilityGroupBox.Controls.Add(this.DisablePitExitPriorityCheckBox);
            this.CompatibilityGroupBox.Controls.Add(this.DisableColourModeCheckBox);
            this.CompatibilityGroupBox.Controls.Add(this.DisableMemoryResetForRaceSoundsCheckbox);
            this.CompatibilityGroupBox.Controls.Add(this.DisableSampleAppCheckBox);
            this.CompatibilityGroupBox.Location = new System.Drawing.Point(6, 6);
            this.CompatibilityGroupBox.Name = "CompatibilityGroupBox";
            this.CompatibilityGroupBox.Size = new System.Drawing.Size(918, 517);
            this.CompatibilityGroupBox.TabIndex = 9;
            this.CompatibilityGroupBox.TabStop = false;
            this.CompatibilityGroupBox.Text = "Compatibility";
            // 
            // DisableGameCdCheckBox
            // 
            this.DisableGameCdCheckBox.AutoSize = true;
            this.DisableGameCdCheckBox.Location = new System.Drawing.Point(6, 19);
            this.DisableGameCdCheckBox.Name = "DisableGameCdCheckBox";
            this.DisableGameCdCheckBox.Size = new System.Drawing.Size(192, 17);
            this.DisableGameCdCheckBox.TabIndex = 7;
            this.DisableGameCdCheckBox.Text = "Disable check for original game CD";
            this.DisableGameCdCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisablePitExitPriorityCheckBox
            // 
            this.DisablePitExitPriorityCheckBox.AutoSize = true;
            this.DisablePitExitPriorityCheckBox.Enabled = false;
            this.DisablePitExitPriorityCheckBox.Location = new System.Drawing.Point(6, 111);
            this.DisablePitExitPriorityCheckBox.Name = "DisablePitExitPriorityCheckBox";
            this.DisablePitExitPriorityCheckBox.Size = new System.Drawing.Size(291, 17);
            this.DisablePitExitPriorityCheckBox.TabIndex = 8;
            this.DisablePitExitPriorityCheckBox.Text = "Disable pit-exit priority for lower numbered teams (bug fix)";
            this.DisablePitExitPriorityCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableColourModeCheckBox
            // 
            this.DisableColourModeCheckBox.AutoSize = true;
            this.DisableColourModeCheckBox.Location = new System.Drawing.Point(6, 42);
            this.DisableColourModeCheckBox.Name = "DisableColourModeCheckBox";
            this.DisableColourModeCheckBox.Size = new System.Drawing.Size(199, 17);
            this.DisableColourModeCheckBox.TabIndex = 5;
            this.DisableColourModeCheckBox.Text = "Disable check for 16-bit colour mode";
            this.DisableColourModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableMemoryResetForRaceSoundsCheckbox
            // 
            this.DisableMemoryResetForRaceSoundsCheckbox.AutoSize = true;
            this.DisableMemoryResetForRaceSoundsCheckbox.Location = new System.Drawing.Point(6, 88);
            this.DisableMemoryResetForRaceSoundsCheckbox.Name = "DisableMemoryResetForRaceSoundsCheckbox";
            this.DisableMemoryResetForRaceSoundsCheckbox.Size = new System.Drawing.Size(242, 17);
            this.DisableMemoryResetForRaceSoundsCheckbox.TabIndex = 6;
            this.DisableMemoryResetForRaceSoundsCheckbox.Text = "Disable memory reset for race sounds (bug fix)";
            this.DisableMemoryResetForRaceSoundsCheckbox.UseVisualStyleBackColor = true;
            // 
            // DisableSampleAppCheckBox
            // 
            this.DisableSampleAppCheckBox.AutoSize = true;
            this.DisableSampleAppCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DisableSampleAppCheckBox.Location = new System.Drawing.Point(6, 65);
            this.DisableSampleAppCheckBox.Name = "DisableSampleAppCheckBox";
            this.DisableSampleAppCheckBox.Size = new System.Drawing.Size(239, 17);
            this.DisableSampleAppCheckBox.TabIndex = 4;
            this.DisableSampleAppCheckBox.Text = "Disable check for sample app object cleanup";
            this.DisableSampleAppCheckBox.UseVisualStyleBackColor = true;
            // 
            // GameplayTabPage
            // 
            this.GameplayTabPage.Controls.Add(this.GameplayGroupBox);
            this.GameplayTabPage.Location = new System.Drawing.Point(4, 22);
            this.GameplayTabPage.Name = "GameplayTabPage";
            this.GameplayTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GameplayTabPage.Size = new System.Drawing.Size(930, 529);
            this.GameplayTabPage.TabIndex = 2;
            this.GameplayTabPage.Text = "Gameplay";
            this.GameplayTabPage.UseVisualStyleBackColor = true;
            // 
            // GameplayGroupBox
            // 
            this.GameplayGroupBox.Controls.Add(this.DisableYellowFlagPenaltiesCheckBox);
            this.GameplayGroupBox.Controls.Add(this.EnableCarPerformanceRaceCalcuationCheckbox);
            this.GameplayGroupBox.Controls.Add(this.EnableCarHandlingDesignCalculationCheckbox);
            this.GameplayGroupBox.Location = new System.Drawing.Point(6, 6);
            this.GameplayGroupBox.Name = "GameplayGroupBox";
            this.GameplayGroupBox.Size = new System.Drawing.Size(918, 517);
            this.GameplayGroupBox.TabIndex = 6;
            this.GameplayGroupBox.TabStop = false;
            this.GameplayGroupBox.Text = "Gameplay";
            // 
            // DisableYellowFlagPenaltiesCheckBox
            // 
            this.DisableYellowFlagPenaltiesCheckBox.AutoSize = true;
            this.DisableYellowFlagPenaltiesCheckBox.Location = new System.Drawing.Point(6, 19);
            this.DisableYellowFlagPenaltiesCheckBox.Name = "DisableYellowFlagPenaltiesCheckBox";
            this.DisableYellowFlagPenaltiesCheckBox.Size = new System.Drawing.Size(158, 17);
            this.DisableYellowFlagPenaltiesCheckBox.TabIndex = 5;
            this.DisableYellowFlagPenaltiesCheckBox.Text = "Disable yellow flag penalties";
            this.DisableYellowFlagPenaltiesCheckBox.UseVisualStyleBackColor = true;
            // 
            // EnableCarPerformanceRaceCalcuationCheckbox
            // 
            this.EnableCarPerformanceRaceCalcuationCheckbox.AutoSize = true;
            this.EnableCarPerformanceRaceCalcuationCheckbox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EnableCarPerformanceRaceCalcuationCheckbox.Location = new System.Drawing.Point(6, 65);
            this.EnableCarPerformanceRaceCalcuationCheckbox.Name = "EnableCarPerformanceRaceCalcuationCheckbox";
            this.EnableCarPerformanceRaceCalcuationCheckbox.Size = new System.Drawing.Size(225, 17);
            this.EnableCarPerformanceRaceCalcuationCheckbox.TabIndex = 4;
            this.EnableCarPerformanceRaceCalcuationCheckbox.Text = "Upgrade car performance race calculation";
            this.EnableCarPerformanceRaceCalcuationCheckbox.UseVisualStyleBackColor = true;
            // 
            // EnableCarHandlingDesignCalculationCheckbox
            // 
            this.EnableCarHandlingDesignCalculationCheckbox.AutoSize = true;
            this.EnableCarHandlingDesignCalculationCheckbox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EnableCarHandlingDesignCalculationCheckbox.Location = new System.Drawing.Point(6, 42);
            this.EnableCarHandlingDesignCalculationCheckbox.Name = "EnableCarHandlingDesignCalculationCheckbox";
            this.EnableCarHandlingDesignCalculationCheckbox.Size = new System.Drawing.Size(219, 17);
            this.EnableCarHandlingDesignCalculationCheckbox.TabIndex = 3;
            this.EnableCarHandlingDesignCalculationCheckbox.Text = "Upgrade car handling design calculation ";
            this.EnableCarHandlingDesignCalculationCheckbox.UseVisualStyleBackColor = true;
            // 
            // CommentaryTabPage
            // 
            this.CommentaryTabPage.Controls.Add(this.CommentaryGroupBox);
            this.CommentaryTabPage.Location = new System.Drawing.Point(4, 22);
            this.CommentaryTabPage.Name = "CommentaryTabPage";
            this.CommentaryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CommentaryTabPage.Size = new System.Drawing.Size(930, 529);
            this.CommentaryTabPage.TabIndex = 3;
            this.CommentaryTabPage.Text = "Commentary";
            this.CommentaryTabPage.UseVisualStyleBackColor = true;
            // 
            // CommentaryGroupBox
            // 
            this.CommentaryGroupBox.Controls.Add(this.CommentaryModifiedRadioButton);
            this.CommentaryGroupBox.Controls.Add(this.CommentaryOriginalRadioButton);
            this.CommentaryGroupBox.Location = new System.Drawing.Point(6, 6);
            this.CommentaryGroupBox.Name = "CommentaryGroupBox";
            this.CommentaryGroupBox.Size = new System.Drawing.Size(918, 517);
            this.CommentaryGroupBox.TabIndex = 16;
            this.CommentaryGroupBox.TabStop = false;
            this.CommentaryGroupBox.Text = "Commentary";
            // 
            // CommentaryModifiedRadioButton
            // 
            this.CommentaryModifiedRadioButton.AutoSize = true;
            this.CommentaryModifiedRadioButton.Location = new System.Drawing.Point(6, 55);
            this.CommentaryModifiedRadioButton.Name = "CommentaryModifiedRadioButton";
            this.CommentaryModifiedRadioButton.Size = new System.Drawing.Size(592, 17);
            this.CommentaryModifiedRadioButton.TabIndex = 14;
            this.CommentaryModifiedRadioButton.Text = "Use generalised driver and team commentary sounds and texts, with references to n" +
    "ames removed (e.g. P1, In Pits, Out).";
            this.CommentaryModifiedRadioButton.UseVisualStyleBackColor = true;
            // 
            // CommentaryOriginalRadioButton
            // 
            this.CommentaryOriginalRadioButton.AutoSize = true;
            this.CommentaryOriginalRadioButton.Checked = true;
            this.CommentaryOriginalRadioButton.Location = new System.Drawing.Point(6, 19);
            this.CommentaryOriginalRadioButton.Name = "CommentaryOriginalRadioButton";
            this.CommentaryOriginalRadioButton.Size = new System.Drawing.Size(787, 30);
            this.CommentaryOriginalRadioButton.TabIndex = 15;
            this.CommentaryOriginalRadioButton.TabStop = true;
            this.CommentaryOriginalRadioButton.Text = resources.GetString("CommentaryOriginalRadioButton.Text");
            this.CommentaryOriginalRadioButton.UseVisualStyleBackColor = true;
            // 
            // PointsScoringSystemTabPage
            // 
            this.PointsScoringSystemTabPage.Controls.Add(this.PointsScoringSystemGroupBox);
            this.PointsScoringSystemTabPage.Location = new System.Drawing.Point(4, 22);
            this.PointsScoringSystemTabPage.Name = "PointsScoringSystemTabPage";
            this.PointsScoringSystemTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PointsScoringSystemTabPage.Size = new System.Drawing.Size(930, 529);
            this.PointsScoringSystemTabPage.TabIndex = 4;
            this.PointsScoringSystemTabPage.Text = "Points Scoring System";
            this.PointsScoringSystemTabPage.UseVisualStyleBackColor = true;
            // 
            // PointsScoringSystemGroupBox
            // 
            this.PointsScoringSystemGroupBox.Controls.Add(this.PointsScoringSystemOption3RadioButton);
            this.PointsScoringSystemGroupBox.Controls.Add(this.PointsScoringSystemOption2RadioButton);
            this.PointsScoringSystemGroupBox.Controls.Add(this.PointsScoringSystemOption1RadioButton);
            this.PointsScoringSystemGroupBox.Controls.Add(this.PointsScoringSystemDefaultRadioButton);
            this.PointsScoringSystemGroupBox.Location = new System.Drawing.Point(6, 6);
            this.PointsScoringSystemGroupBox.Name = "PointsScoringSystemGroupBox";
            this.PointsScoringSystemGroupBox.Size = new System.Drawing.Size(918, 517);
            this.PointsScoringSystemGroupBox.TabIndex = 2;
            this.PointsScoringSystemGroupBox.TabStop = false;
            this.PointsScoringSystemGroupBox.Text = "Points Scoring System";
            // 
            // PointsScoringSystemOption3RadioButton
            // 
            this.PointsScoringSystemOption3RadioButton.AutoSize = true;
            this.PointsScoringSystemOption3RadioButton.Location = new System.Drawing.Point(6, 88);
            this.PointsScoringSystemOption3RadioButton.Name = "PointsScoringSystemOption3RadioButton";
            this.PointsScoringSystemOption3RadioButton.Size = new System.Drawing.Size(301, 17);
            this.PointsScoringSystemOption3RadioButton.TabIndex = 3;
            this.PointsScoringSystemOption3RadioButton.Text = "Option3 - 25-18-15-12-10-8-6-4-2-1 (top 10 finishers, 2010-)";
            this.PointsScoringSystemOption3RadioButton.UseVisualStyleBackColor = true;
            // 
            // PointsScoringSystemOption2RadioButton
            // 
            this.PointsScoringSystemOption2RadioButton.AutoSize = true;
            this.PointsScoringSystemOption2RadioButton.Location = new System.Drawing.Point(6, 65);
            this.PointsScoringSystemOption2RadioButton.Name = "PointsScoringSystemOption2RadioButton";
            this.PointsScoringSystemOption2RadioButton.Size = new System.Drawing.Size(277, 17);
            this.PointsScoringSystemOption2RadioButton.TabIndex = 2;
            this.PointsScoringSystemOption2RadioButton.Text = "Option2 - 10-8-6-5-4-3-2-1 (top 8 finishers, 2003-2009)";
            this.PointsScoringSystemOption2RadioButton.UseVisualStyleBackColor = true;
            // 
            // PointsScoringSystemOption1RadioButton
            // 
            this.PointsScoringSystemOption1RadioButton.AutoSize = true;
            this.PointsScoringSystemOption1RadioButton.Location = new System.Drawing.Point(6, 42);
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
            this.PointsScoringSystemDefaultRadioButton.Location = new System.Drawing.Point(6, 19);
            this.PointsScoringSystemDefaultRadioButton.Name = "PointsScoringSystemDefaultRadioButton";
            this.PointsScoringSystemDefaultRadioButton.Size = new System.Drawing.Size(256, 17);
            this.PointsScoringSystemDefaultRadioButton.TabIndex = 0;
            this.PointsScoringSystemDefaultRadioButton.TabStop = true;
            this.PointsScoringSystemDefaultRadioButton.Text = "Default - 10-6-4-3-2-1 (top 6 finishers, 1991-2002)";
            this.PointsScoringSystemDefaultRadioButton.UseVisualStyleBackColor = true;
            // 
            // ViewportsTabPage
            // 
            this.ViewportsTabPage.Controls.Add(this.ViewportsGroupBox);
            this.ViewportsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ViewportsTabPage.Name = "ViewportsTabPage";
            this.ViewportsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ViewportsTabPage.Size = new System.Drawing.Size(930, 529);
            this.ViewportsTabPage.TabIndex = 5;
            this.ViewportsTabPage.Text = "Viewports";
            this.ViewportsTabPage.UseVisualStyleBackColor = true;
            // 
            // ViewportsGroupBox
            // 
            this.ViewportsGroupBox.Location = new System.Drawing.Point(6, 6);
            this.ViewportsGroupBox.Name = "ViewportsGroupBox";
            this.ViewportsGroupBox.Size = new System.Drawing.Size(918, 517);
            this.ViewportsGroupBox.TabIndex = 0;
            this.ViewportsGroupBox.TabStop = false;
            this.ViewportsGroupBox.Text = "Viewports";
            // 
            // ConfigureGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 561);
            this.Controls.Add(this.ConfigureGameTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfigureGameForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigureGameForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigureGameForm_Load);
            this.ConfigureGameTabControl.ResumeLayout(false);
            this.HomeTabPage.ResumeLayout(false);
            this.OverviewGroupBox.ResumeLayout(false);
            this.FilesGroupBox.ResumeLayout(false);
            this.FilesGroupBox.PerformLayout();
            this.CompatibilityTabPage.ResumeLayout(false);
            this.CompatibilityGroupBox.ResumeLayout(false);
            this.CompatibilityGroupBox.PerformLayout();
            this.GameplayTabPage.ResumeLayout(false);
            this.GameplayGroupBox.ResumeLayout(false);
            this.GameplayGroupBox.PerformLayout();
            this.CommentaryTabPage.ResumeLayout(false);
            this.CommentaryGroupBox.ResumeLayout(false);
            this.CommentaryGroupBox.PerformLayout();
            this.PointsScoringSystemTabPage.ResumeLayout(false);
            this.PointsScoringSystemGroupBox.ResumeLayout(false);
            this.PointsScoringSystemGroupBox.PerformLayout();
            this.ViewportsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl ConfigureGameTabControl;
        private System.Windows.Forms.TabPage HomeTabPage;
        private System.Windows.Forms.GroupBox FilesGroupBox;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.TabPage CompatibilityTabPage;
        private System.Windows.Forms.CheckBox DisablePitExitPriorityCheckBox;
        private System.Windows.Forms.CheckBox DisableMemoryResetForRaceSoundsCheckbox;
        private System.Windows.Forms.CheckBox DisableGameCdCheckBox;
        private System.Windows.Forms.CheckBox DisableSampleAppCheckBox;
        private System.Windows.Forms.CheckBox DisableColourModeCheckBox;
        private System.Windows.Forms.TabPage GameplayTabPage;
        private System.Windows.Forms.CheckBox DisableYellowFlagPenaltiesCheckBox;
        private System.Windows.Forms.CheckBox EnableCarHandlingDesignCalculationCheckbox;
        private System.Windows.Forms.CheckBox EnableCarPerformanceRaceCalcuationCheckbox;
        private System.Windows.Forms.TabPage CommentaryTabPage;
        private System.Windows.Forms.RadioButton CommentaryOriginalRadioButton;
        private System.Windows.Forms.RadioButton CommentaryModifiedRadioButton;
        private System.Windows.Forms.TabPage PointsScoringSystemTabPage;
        private System.Windows.Forms.Label GameFolderPathLabel;
        private System.Windows.Forms.Label GameExecutablePathLabel;
        private System.Windows.Forms.Label LanguageFilePathLabel;
        private System.Windows.Forms.TextBox GameFolderPathTextBox;
        private System.Windows.Forms.TextBox GameExecutablePathTextBox;
        private System.Windows.Forms.Button BrowseGameFolderButton;
        private System.Windows.Forms.TextBox LanguageFilePathTextBox;
        private System.Windows.Forms.Button BrowseGameExecutableButton;
        private System.Windows.Forms.Button BrowseLanguageFileButton;
        private System.Windows.Forms.GroupBox PointsScoringSystemGroupBox;
        private System.Windows.Forms.RadioButton PointsScoringSystemOption3RadioButton;
        private System.Windows.Forms.RadioButton PointsScoringSystemOption2RadioButton;
        private System.Windows.Forms.RadioButton PointsScoringSystemOption1RadioButton;
        private System.Windows.Forms.RadioButton PointsScoringSystemDefaultRadioButton;
        private System.Windows.Forms.GroupBox CompatibilityGroupBox;
        private System.Windows.Forms.GroupBox GameplayGroupBox;
        private System.Windows.Forms.GroupBox CommentaryGroupBox;
        private System.Windows.Forms.TabPage ViewportsTabPage;
        private System.Windows.Forms.GroupBox ViewportsGroupBox;
        private System.Windows.Forms.GroupBox OverviewGroupBox;
        private System.Windows.Forms.RichTextBox OverviewRichTextBox;
    }
}