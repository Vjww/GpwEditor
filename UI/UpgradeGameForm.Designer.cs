namespace GpwEditor
{
    partial class UpgradeGameForm
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
            this.GameConfigurationGroupBox = new System.Windows.Forms.GroupBox();
            this.DisablePitExitPriorityCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableYellowFlagPenaltiesCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableMemoryResetForRaceSoundsCheckbox = new System.Windows.Forms.CheckBox();
            this.DisableGameCdCheckBox = new System.Windows.Forms.CheckBox();
            this.DisableSampleAppCheckBox = new System.Windows.Forms.CheckBox();
            this.EnableCarPerformanceRaceCalcuationCheckbox = new System.Windows.Forms.CheckBox();
            this.EnableCarHandlingDesignCalculationCheckbox = new System.Windows.Forms.CheckBox();
            this.DisableColourModeCheckBox = new System.Windows.Forms.CheckBox();
            this.PointsScoringSystemGroupBox = new System.Windows.Forms.GroupBox();
            this.PointsScoringSystemOption3RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemOption2RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemOption1RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemDefaultRadioButton = new System.Windows.Forms.RadioButton();
            this.FilesGroupBox = new System.Windows.Forms.GroupBox();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.GameExecutablePathLabel = new System.Windows.Forms.Label();
            this.LanguageFilePathLabel = new System.Windows.Forms.Label();
            this.GameExecutablePathTextBox = new System.Windows.Forms.TextBox();
            this.LanguageFilePathTextBox = new System.Windows.Forms.TextBox();
            this.BrowseGameExecutableButton = new System.Windows.Forms.Button();
            this.BrowseLanguageFileButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ProgramOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.GameConfigurationGroupBox.SuspendLayout();
            this.PointsScoringSystemGroupBox.SuspendLayout();
            this.FilesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameConfigurationGroupBox
            // 
            this.GameConfigurationGroupBox.Controls.Add(this.DisablePitExitPriorityCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableYellowFlagPenaltiesCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableMemoryResetForRaceSoundsCheckbox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableGameCdCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableSampleAppCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.EnableCarPerformanceRaceCalcuationCheckbox);
            this.GameConfigurationGroupBox.Controls.Add(this.EnableCarHandlingDesignCalculationCheckbox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableColourModeCheckBox);
            this.GameConfigurationGroupBox.Location = new System.Drawing.Point(12, 89);
            this.GameConfigurationGroupBox.Name = "GameConfigurationGroupBox";
            this.GameConfigurationGroupBox.Size = new System.Drawing.Size(377, 226);
            this.GameConfigurationGroupBox.TabIndex = 0;
            this.GameConfigurationGroupBox.TabStop = false;
            this.GameConfigurationGroupBox.Text = "Game Configuration";
            // 
            // DisablePitExitPriorityCheckBox
            // 
            this.DisablePitExitPriorityCheckBox.AutoSize = true;
            this.DisablePitExitPriorityCheckBox.Enabled = false;
            this.DisablePitExitPriorityCheckBox.Location = new System.Drawing.Point(6, 157);
            this.DisablePitExitPriorityCheckBox.Name = "DisablePitExitPriorityCheckBox";
            this.DisablePitExitPriorityCheckBox.Size = new System.Drawing.Size(291, 17);
            this.DisablePitExitPriorityCheckBox.TabIndex = 3;
            this.DisablePitExitPriorityCheckBox.Text = "Disable pit-exit priority for lower numbered teams (bug fix)";
            this.DisablePitExitPriorityCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableYellowFlagPenaltiesCheckBox
            // 
            this.DisableYellowFlagPenaltiesCheckBox.AutoSize = true;
            this.DisableYellowFlagPenaltiesCheckBox.Location = new System.Drawing.Point(6, 111);
            this.DisableYellowFlagPenaltiesCheckBox.Name = "DisableYellowFlagPenaltiesCheckBox";
            this.DisableYellowFlagPenaltiesCheckBox.Size = new System.Drawing.Size(198, 17);
            this.DisableYellowFlagPenaltiesCheckBox.TabIndex = 2;
            this.DisableYellowFlagPenaltiesCheckBox.Text = "Disable yellow flag penalties (bug fix)";
            this.DisableYellowFlagPenaltiesCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableMemoryResetForRaceSoundsCheckbox
            // 
            this.DisableMemoryResetForRaceSoundsCheckbox.AutoSize = true;
            this.DisableMemoryResetForRaceSoundsCheckbox.Location = new System.Drawing.Point(6, 134);
            this.DisableMemoryResetForRaceSoundsCheckbox.Name = "DisableMemoryResetForRaceSoundsCheckbox";
            this.DisableMemoryResetForRaceSoundsCheckbox.Size = new System.Drawing.Size(242, 17);
            this.DisableMemoryResetForRaceSoundsCheckbox.TabIndex = 1;
            this.DisableMemoryResetForRaceSoundsCheckbox.Text = "Disable memory reset for race sounds (bug fix)";
            this.DisableMemoryResetForRaceSoundsCheckbox.UseVisualStyleBackColor = true;
            // 
            // DisableGameCdCheckBox
            // 
            this.DisableGameCdCheckBox.AutoSize = true;
            this.DisableGameCdCheckBox.Location = new System.Drawing.Point(6, 19);
            this.DisableGameCdCheckBox.Name = "DisableGameCdCheckBox";
            this.DisableGameCdCheckBox.Size = new System.Drawing.Size(192, 17);
            this.DisableGameCdCheckBox.TabIndex = 1;
            this.DisableGameCdCheckBox.Text = "Disable check for original game CD";
            this.DisableGameCdCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableSampleAppCheckBox
            // 
            this.DisableSampleAppCheckBox.AutoSize = true;
            this.DisableSampleAppCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DisableSampleAppCheckBox.Location = new System.Drawing.Point(6, 65);
            this.DisableSampleAppCheckBox.Name = "DisableSampleAppCheckBox";
            this.DisableSampleAppCheckBox.Size = new System.Drawing.Size(239, 17);
            this.DisableSampleAppCheckBox.TabIndex = 0;
            this.DisableSampleAppCheckBox.Text = "Disable check for sample app object cleanup";
            this.DisableSampleAppCheckBox.UseVisualStyleBackColor = true;
            // 
            // EnableCarPerformanceRaceCalcuationCheckbox
            // 
            this.EnableCarPerformanceRaceCalcuationCheckbox.AutoSize = true;
            this.EnableCarPerformanceRaceCalcuationCheckbox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EnableCarPerformanceRaceCalcuationCheckbox.Location = new System.Drawing.Point(6, 203);
            this.EnableCarPerformanceRaceCalcuationCheckbox.Name = "EnableCarPerformanceRaceCalcuationCheckbox";
            this.EnableCarPerformanceRaceCalcuationCheckbox.Size = new System.Drawing.Size(225, 17);
            this.EnableCarPerformanceRaceCalcuationCheckbox.TabIndex = 0;
            this.EnableCarPerformanceRaceCalcuationCheckbox.Text = "Upgrade car performance race calculation";
            this.EnableCarPerformanceRaceCalcuationCheckbox.UseVisualStyleBackColor = true;
            // 
            // EnableCarHandlingDesignCalculationCheckbox
            // 
            this.EnableCarHandlingDesignCalculationCheckbox.AutoSize = true;
            this.EnableCarHandlingDesignCalculationCheckbox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EnableCarHandlingDesignCalculationCheckbox.Location = new System.Drawing.Point(6, 180);
            this.EnableCarHandlingDesignCalculationCheckbox.Name = "EnableCarHandlingDesignCalculationCheckbox";
            this.EnableCarHandlingDesignCalculationCheckbox.Size = new System.Drawing.Size(219, 17);
            this.EnableCarHandlingDesignCalculationCheckbox.TabIndex = 0;
            this.EnableCarHandlingDesignCalculationCheckbox.Text = "Upgrade car handling design calculation ";
            this.EnableCarHandlingDesignCalculationCheckbox.UseVisualStyleBackColor = true;
            // 
            // DisableColourModeCheckBox
            // 
            this.DisableColourModeCheckBox.AutoSize = true;
            this.DisableColourModeCheckBox.Location = new System.Drawing.Point(6, 42);
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
            this.PointsScoringSystemGroupBox.Location = new System.Drawing.Point(395, 89);
            this.PointsScoringSystemGroupBox.Name = "PointsScoringSystemGroupBox";
            this.PointsScoringSystemGroupBox.Size = new System.Drawing.Size(377, 111);
            this.PointsScoringSystemGroupBox.TabIndex = 0;
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
            // FilesGroupBox
            // 
            this.FilesGroupBox.Controls.Add(this.ExportButton);
            this.FilesGroupBox.Controls.Add(this.ImportButton);
            this.FilesGroupBox.Controls.Add(this.GameExecutablePathLabel);
            this.FilesGroupBox.Controls.Add(this.LanguageFilePathLabel);
            this.FilesGroupBox.Controls.Add(this.GameExecutablePathTextBox);
            this.FilesGroupBox.Controls.Add(this.LanguageFilePathTextBox);
            this.FilesGroupBox.Controls.Add(this.BrowseGameExecutableButton);
            this.FilesGroupBox.Controls.Add(this.BrowseLanguageFileButton);
            this.FilesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.FilesGroupBox.Name = "FilesGroupBox";
            this.FilesGroupBox.Size = new System.Drawing.Size(760, 71);
            this.FilesGroupBox.TabIndex = 0;
            this.FilesGroupBox.TabStop = false;
            this.FilesGroupBox.Text = "Source/Target Files";
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(679, 43);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 4;
            this.ExportButton.Text = "Export...";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(679, 17);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(75, 23);
            this.ImportButton.TabIndex = 3;
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
            this.GameExecutablePathTextBox.Size = new System.Drawing.Size(486, 20);
            this.GameExecutablePathTextBox.TabIndex = 0;
            this.GameExecutablePathTextBox.TabStop = false;
            // 
            // LanguageFilePathTextBox
            // 
            this.LanguageFilePathTextBox.Location = new System.Drawing.Point(106, 19);
            this.LanguageFilePathTextBox.Name = "LanguageFilePathTextBox";
            this.LanguageFilePathTextBox.ReadOnly = true;
            this.LanguageFilePathTextBox.Size = new System.Drawing.Size(486, 20);
            this.LanguageFilePathTextBox.TabIndex = 0;
            this.LanguageFilePathTextBox.TabStop = false;
            // 
            // BrowseGameExecutableButton
            // 
            this.BrowseGameExecutableButton.Location = new System.Drawing.Point(598, 43);
            this.BrowseGameExecutableButton.Name = "BrowseGameExecutableButton";
            this.BrowseGameExecutableButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseGameExecutableButton.TabIndex = 2;
            this.BrowseGameExecutableButton.Text = "Browse...";
            this.BrowseGameExecutableButton.UseVisualStyleBackColor = true;
            this.BrowseGameExecutableButton.Click += new System.EventHandler(this.BrowseGameExecutableButton_Click);
            // 
            // BrowseLanguageFileButton
            // 
            this.BrowseLanguageFileButton.Location = new System.Drawing.Point(598, 17);
            this.BrowseLanguageFileButton.Name = "BrowseLanguageFileButton";
            this.BrowseLanguageFileButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseLanguageFileButton.TabIndex = 1;
            this.BrowseLanguageFileButton.Text = "Browse...";
            this.BrowseLanguageFileButton.UseVisualStyleBackColor = true;
            this.BrowseLanguageFileButton.Click += new System.EventHandler(this.BrowseLanguageFileButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(697, 526);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 24;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // UpgradeGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.FilesGroupBox);
            this.Controls.Add(this.GameConfigurationGroupBox);
            this.Controls.Add(this.PointsScoringSystemGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UpgradeGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpgradeGameForm_FormClosing);
            this.Load += new System.EventHandler(this.UpgradeGameForm_Load);
            this.GameConfigurationGroupBox.ResumeLayout(false);
            this.GameConfigurationGroupBox.PerformLayout();
            this.PointsScoringSystemGroupBox.ResumeLayout(false);
            this.PointsScoringSystemGroupBox.PerformLayout();
            this.FilesGroupBox.ResumeLayout(false);
            this.FilesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.GroupBox FilesGroupBox;
        private System.Windows.Forms.CheckBox EnableCarHandlingDesignCalculationCheckbox;
        private System.Windows.Forms.CheckBox EnableCarPerformanceRaceCalcuationCheckbox;
        private System.Windows.Forms.CheckBox DisableMemoryResetForRaceSoundsCheckbox;
        private System.Windows.Forms.CheckBox DisableSampleAppCheckBox;
        private System.Windows.Forms.Button BrowseGameExecutableButton;
        private System.Windows.Forms.Button BrowseLanguageFileButton;
        private System.Windows.Forms.Label GameExecutablePathLabel;
        private System.Windows.Forms.Label LanguageFilePathLabel;
        private System.Windows.Forms.TextBox GameExecutablePathTextBox;
        private System.Windows.Forms.TextBox LanguageFilePathTextBox;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.OpenFileDialog ProgramOpenFileDialog;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button ImportButton;
    }
}