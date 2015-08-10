namespace UI
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
            this.EnableCarPerformanceRaceCalcuationCheckbox = new System.Windows.Forms.CheckBox();
            this.EnableCarHandlingDesignCalculationCheckbox = new System.Windows.Forms.CheckBox();
            this.DisableColourModeCheckBox = new System.Windows.Forms.CheckBox();
            this.PointsScoringSystemGroupBox = new System.Windows.Forms.GroupBox();
            this.PointsScoringSystemOption3RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemOption2RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemOption1RadioButton = new System.Windows.Forms.RadioButton();
            this.PointsScoringSystemDefaultRadioButton = new System.Windows.Forms.RadioButton();
            this.UpgradeGroupBox = new System.Windows.Forms.GroupBox();
            this.ExportExecutableFileButton = new System.Windows.Forms.Button();
            this.ExportExecutableFileTextBox = new System.Windows.Forms.TextBox();
            this.UpgradeButton = new System.Windows.Forms.Button();
            this.ExportExecutableFileLabel = new System.Windows.Forms.Label();
            this.ExportLanguageFileButton = new System.Windows.Forms.Button();
            this.ExportLanguageFileTextBox = new System.Windows.Forms.TextBox();
            this.ExportLanguageFileLabel = new System.Windows.Forms.Label();
            this.GameConfigurationGroupBox.SuspendLayout();
            this.PointsScoringSystemGroupBox.SuspendLayout();
            this.UpgradeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameConfigurationGroupBox
            // 
            this.GameConfigurationGroupBox.Controls.Add(this.DisablePitExitPriorityCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableYellowFlagPenaltiesCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableMemoryResetForRaceSoundsCheckbox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableGameCdCheckBox);
            this.GameConfigurationGroupBox.Controls.Add(this.EnableCarPerformanceRaceCalcuationCheckbox);
            this.GameConfigurationGroupBox.Controls.Add(this.EnableCarHandlingDesignCalculationCheckbox);
            this.GameConfigurationGroupBox.Controls.Add(this.DisableColourModeCheckBox);
            this.GameConfigurationGroupBox.Location = new System.Drawing.Point(12, 96);
            this.GameConfigurationGroupBox.Name = "GameConfigurationGroupBox";
            this.GameConfigurationGroupBox.Size = new System.Drawing.Size(344, 181);
            this.GameConfigurationGroupBox.TabIndex = 19;
            this.GameConfigurationGroupBox.TabStop = false;
            this.GameConfigurationGroupBox.Text = "Game Configuration";
            // 
            // DisablePitExitPriorityCheckBox
            // 
            this.DisablePitExitPriorityCheckBox.AutoSize = true;
            this.DisablePitExitPriorityCheckBox.Location = new System.Drawing.Point(6, 111);
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
            this.DisableYellowFlagPenaltiesCheckBox.Location = new System.Drawing.Point(6, 65);
            this.DisableYellowFlagPenaltiesCheckBox.Name = "DisableYellowFlagPenaltiesCheckBox";
            this.DisableYellowFlagPenaltiesCheckBox.Size = new System.Drawing.Size(198, 17);
            this.DisableYellowFlagPenaltiesCheckBox.TabIndex = 2;
            this.DisableYellowFlagPenaltiesCheckBox.Text = "Disable yellow flag penalties (bug fix)";
            this.DisableYellowFlagPenaltiesCheckBox.UseVisualStyleBackColor = true;
            // 
            // DisableMemoryResetForRaceSoundsCheckbox
            // 
            this.DisableMemoryResetForRaceSoundsCheckbox.AutoSize = true;
            this.DisableMemoryResetForRaceSoundsCheckbox.Location = new System.Drawing.Point(6, 88);
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
            this.DisableGameCdCheckBox.Size = new System.Drawing.Size(224, 17);
            this.DisableGameCdCheckBox.TabIndex = 1;
            this.DisableGameCdCheckBox.Text = "Disable check for game CD (allow No-CD)";
            this.DisableGameCdCheckBox.UseVisualStyleBackColor = true;
            // 
            // EnableCarPerformanceRaceCalcuationCheckbox
            // 
            this.EnableCarPerformanceRaceCalcuationCheckbox.AutoSize = true;
            this.EnableCarPerformanceRaceCalcuationCheckbox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EnableCarPerformanceRaceCalcuationCheckbox.Location = new System.Drawing.Point(6, 157);
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
            this.EnableCarHandlingDesignCalculationCheckbox.Location = new System.Drawing.Point(6, 134);
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
            this.PointsScoringSystemGroupBox.Location = new System.Drawing.Point(362, 96);
            this.PointsScoringSystemGroupBox.Name = "PointsScoringSystemGroupBox";
            this.PointsScoringSystemGroupBox.Size = new System.Drawing.Size(322, 128);
            this.PointsScoringSystemGroupBox.TabIndex = 20;
            this.PointsScoringSystemGroupBox.TabStop = false;
            this.PointsScoringSystemGroupBox.Text = "Points Scoring System";
            this.PointsScoringSystemGroupBox.Visible = false;
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
            // UpgradeGroupBox
            // 
            this.UpgradeGroupBox.Controls.Add(this.ExportExecutableFileButton);
            this.UpgradeGroupBox.Controls.Add(this.ExportExecutableFileTextBox);
            this.UpgradeGroupBox.Controls.Add(this.UpgradeButton);
            this.UpgradeGroupBox.Controls.Add(this.ExportExecutableFileLabel);
            this.UpgradeGroupBox.Controls.Add(this.ExportLanguageFileButton);
            this.UpgradeGroupBox.Controls.Add(this.ExportLanguageFileTextBox);
            this.UpgradeGroupBox.Controls.Add(this.ExportLanguageFileLabel);
            this.UpgradeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.UpgradeGroupBox.Name = "UpgradeGroupBox";
            this.UpgradeGroupBox.Size = new System.Drawing.Size(672, 78);
            this.UpgradeGroupBox.TabIndex = 21;
            this.UpgradeGroupBox.TabStop = false;
            this.UpgradeGroupBox.Text = "Upgrade";
            // 
            // ExportExecutableFileButton
            // 
            this.ExportExecutableFileButton.Location = new System.Drawing.Point(502, 43);
            this.ExportExecutableFileButton.Name = "ExportExecutableFileButton";
            this.ExportExecutableFileButton.Size = new System.Drawing.Size(75, 23);
            this.ExportExecutableFileButton.TabIndex = 7;
            this.ExportExecutableFileButton.Text = "Change...";
            this.ExportExecutableFileButton.UseVisualStyleBackColor = true;
            // 
            // ExportExecutableFileTextBox
            // 
            this.ExportExecutableFileTextBox.Location = new System.Drawing.Point(96, 45);
            this.ExportExecutableFileTextBox.Name = "ExportExecutableFileTextBox";
            this.ExportExecutableFileTextBox.Size = new System.Drawing.Size(400, 20);
            this.ExportExecutableFileTextBox.TabIndex = 6;
            // 
            // UpgradeButton
            // 
            this.UpgradeButton.Location = new System.Drawing.Point(583, 17);
            this.UpgradeButton.Name = "UpgradeButton";
            this.UpgradeButton.Size = new System.Drawing.Size(83, 48);
            this.UpgradeButton.TabIndex = 0;
            this.UpgradeButton.Text = "Upgrade";
            this.UpgradeButton.UseVisualStyleBackColor = true;
            this.UpgradeButton.Click += new System.EventHandler(this.UpgradeButton_Click);
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
            // UpgradeGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 464);
            this.Controls.Add(this.UpgradeGroupBox);
            this.Controls.Add(this.GameConfigurationGroupBox);
            this.Controls.Add(this.PointsScoringSystemGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UpgradeGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{0}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpgradeGameForm_FormClosing);
            this.Load += new System.EventHandler(this.UpgradeGameForm_Load);
            this.GameConfigurationGroupBox.ResumeLayout(false);
            this.GameConfigurationGroupBox.PerformLayout();
            this.PointsScoringSystemGroupBox.ResumeLayout(false);
            this.PointsScoringSystemGroupBox.PerformLayout();
            this.UpgradeGroupBox.ResumeLayout(false);
            this.UpgradeGroupBox.PerformLayout();
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
        private System.Windows.Forms.GroupBox UpgradeGroupBox;
        private System.Windows.Forms.Button ExportExecutableFileButton;
        private System.Windows.Forms.TextBox ExportExecutableFileTextBox;
        private System.Windows.Forms.Button UpgradeButton;
        private System.Windows.Forms.Label ExportExecutableFileLabel;
        private System.Windows.Forms.Button ExportLanguageFileButton;
        private System.Windows.Forms.TextBox ExportLanguageFileTextBox;
        private System.Windows.Forms.Label ExportLanguageFileLabel;
        private System.Windows.Forms.CheckBox EnableCarHandlingDesignCalculationCheckbox;
        private System.Windows.Forms.CheckBox EnableCarPerformanceRaceCalcuationCheckbox;
        private System.Windows.Forms.CheckBox DisableMemoryResetForRaceSoundsCheckbox;
    }
}