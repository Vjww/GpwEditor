namespace App.WindowsForms.Views
{
    sealed partial class MenuForm
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
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.UpgradeGameButton = new System.Windows.Forms.Button();
            this.GameExecutableEditorButton = new System.Windows.Forms.Button();
            this.LanguageFileEditorButton = new System.Windows.Forms.Button();
            this.TelemetryViewerButton = new System.Windows.Forms.Button();
            this.SettingsEditorButton = new System.Windows.Forms.Button();
            this.SaveGameEditorButton = new System.Windows.Forms.Button();
            this.LaunchGameButton = new System.Windows.Forms.Button();
            this.GameFolderPanel = new System.Windows.Forms.Panel();
            this.GameFolderPathLabel = new System.Windows.Forms.Label();
            this.GameFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.GameFolderChangeButton = new System.Windows.Forms.Button();
            this.GameFolderOkButton = new System.Windows.Forms.Button();
            this.GameFolderAdministratorLabel = new System.Windows.Forms.Label();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.ConfigureGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.GameFolderPanel.SuspendLayout();
            this.MenuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Image = global::App.WindowsForms.Properties.Resources.logo3;
            this.LogoPictureBox.InitialImage = null;
            this.LogoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(384, 96);
            this.LogoPictureBox.TabIndex = 3;
            this.LogoPictureBox.TabStop = false;
            // 
            // UpgradeGameButton
            // 
            this.UpgradeGameButton.Location = new System.Drawing.Point(8, 8);
            this.UpgradeGameButton.Name = "UpgradeGameButton";
            this.UpgradeGameButton.Size = new System.Drawing.Size(176, 23);
            this.UpgradeGameButton.TabIndex = 0;
            this.UpgradeGameButton.Text = "Upgrade Game";
            this.UpgradeGameButton.UseVisualStyleBackColor = true;
            this.UpgradeGameButton.Click += new System.EventHandler(this.UpgradeGameButton_Click);
            // 
            // GameExecutableEditorButton
            // 
            this.GameExecutableEditorButton.Location = new System.Drawing.Point(8, 76);
            this.GameExecutableEditorButton.Name = "GameExecutableEditorButton";
            this.GameExecutableEditorButton.Size = new System.Drawing.Size(176, 23);
            this.GameExecutableEditorButton.TabIndex = 2;
            this.GameExecutableEditorButton.Text = "Game Executable Editor";
            this.GameExecutableEditorButton.UseVisualStyleBackColor = true;
            this.GameExecutableEditorButton.Click += new System.EventHandler(this.GameExecutableEditorButton_Click);
            // 
            // LanguageFileEditorButton
            // 
            this.LanguageFileEditorButton.Location = new System.Drawing.Point(8, 110);
            this.LanguageFileEditorButton.Name = "LanguageFileEditorButton";
            this.LanguageFileEditorButton.Size = new System.Drawing.Size(176, 23);
            this.LanguageFileEditorButton.TabIndex = 3;
            this.LanguageFileEditorButton.Text = "Language File Editor";
            this.LanguageFileEditorButton.UseVisualStyleBackColor = true;
            this.LanguageFileEditorButton.Click += new System.EventHandler(this.LanguageFileEditorButton_Click);
            // 
            // TelemetryViewerButton
            // 
            this.TelemetryViewerButton.Location = new System.Drawing.Point(200, 42);
            this.TelemetryViewerButton.Name = "TelemetryViewerButton";
            this.TelemetryViewerButton.Size = new System.Drawing.Size(176, 23);
            this.TelemetryViewerButton.TabIndex = 5;
            this.TelemetryViewerButton.Text = "Telemetry Viewer";
            this.TelemetryViewerButton.UseVisualStyleBackColor = true;
            this.TelemetryViewerButton.Visible = false;
            this.TelemetryViewerButton.Click += new System.EventHandler(this.AnalyseTelemetryButton_Click);
            // 
            // SettingsEditorButton
            // 
            this.SettingsEditorButton.Location = new System.Drawing.Point(200, 8);
            this.SettingsEditorButton.Name = "SettingsEditorButton";
            this.SettingsEditorButton.Size = new System.Drawing.Size(176, 23);
            this.SettingsEditorButton.TabIndex = 4;
            this.SettingsEditorButton.Text = "{0} Settings";
            this.SettingsEditorButton.UseVisualStyleBackColor = true;
            this.SettingsEditorButton.Click += new System.EventHandler(this.SettingsEditorButton_Click);
            // 
            // SaveGameEditorButton
            // 
            this.SaveGameEditorButton.Location = new System.Drawing.Point(200, 76);
            this.SaveGameEditorButton.Name = "SaveGameEditorButton";
            this.SaveGameEditorButton.Size = new System.Drawing.Size(176, 23);
            this.SaveGameEditorButton.TabIndex = 6;
            this.SaveGameEditorButton.Text = "Save Game Editor";
            this.SaveGameEditorButton.UseVisualStyleBackColor = true;
            this.SaveGameEditorButton.Click += new System.EventHandler(this.SaveGameEditorButton_Click);
            // 
            // LaunchGameButton
            // 
            this.LaunchGameButton.Location = new System.Drawing.Point(200, 110);
            this.LaunchGameButton.Name = "LaunchGameButton";
            this.LaunchGameButton.Size = new System.Drawing.Size(176, 23);
            this.LaunchGameButton.TabIndex = 7;
            this.LaunchGameButton.Text = "Launch Game";
            this.LaunchGameButton.UseVisualStyleBackColor = true;
            this.LaunchGameButton.Click += new System.EventHandler(this.LaunchGameButton_Click);
            // 
            // GameFolderPanel
            // 
            this.GameFolderPanel.Controls.Add(this.GameFolderPathLabel);
            this.GameFolderPanel.Controls.Add(this.GameFolderPathTextBox);
            this.GameFolderPanel.Controls.Add(this.GameFolderChangeButton);
            this.GameFolderPanel.Controls.Add(this.GameFolderOkButton);
            this.GameFolderPanel.Controls.Add(this.GameFolderAdministratorLabel);
            this.GameFolderPanel.Location = new System.Drawing.Point(0, 96);
            this.GameFolderPanel.Name = "GameFolderPanel";
            this.GameFolderPanel.Size = new System.Drawing.Size(384, 140);
            this.GameFolderPanel.TabIndex = 0;
            this.GameFolderPanel.Visible = false;
            // 
            // GameFolderPathLabel
            // 
            this.GameFolderPathLabel.AutoSize = true;
            this.GameFolderPathLabel.Location = new System.Drawing.Point(12, 26);
            this.GameFolderPathLabel.Name = "GameFolderPathLabel";
            this.GameFolderPathLabel.Size = new System.Drawing.Size(107, 13);
            this.GameFolderPathLabel.TabIndex = 0;
            this.GameFolderPathLabel.Text = "Current Game Folder:";
            // 
            // GameFolderPathTextBox
            // 
            this.GameFolderPathTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.GameFolderPathTextBox.Location = new System.Drawing.Point(15, 42);
            this.GameFolderPathTextBox.Name = "GameFolderPathTextBox";
            this.GameFolderPathTextBox.ReadOnly = true;
            this.GameFolderPathTextBox.Size = new System.Drawing.Size(357, 20);
            this.GameFolderPathTextBox.TabIndex = 0;
            this.GameFolderPathTextBox.TabStop = false;
            // 
            // GameFolderChangeButton
            // 
            this.GameFolderChangeButton.Location = new System.Drawing.Point(216, 68);
            this.GameFolderChangeButton.Name = "GameFolderChangeButton";
            this.GameFolderChangeButton.Size = new System.Drawing.Size(75, 23);
            this.GameFolderChangeButton.TabIndex = 1;
            this.GameFolderChangeButton.Text = "Change...";
            this.GameFolderChangeButton.UseVisualStyleBackColor = true;
            this.GameFolderChangeButton.Click += new System.EventHandler(this.GameFolderChangeButton_Click);
            // 
            // GameFolderOkButton
            // 
            this.GameFolderOkButton.Location = new System.Drawing.Point(297, 68);
            this.GameFolderOkButton.Name = "GameFolderOkButton";
            this.GameFolderOkButton.Size = new System.Drawing.Size(75, 23);
            this.GameFolderOkButton.TabIndex = 0;
            this.GameFolderOkButton.Text = "OK";
            this.GameFolderOkButton.UseVisualStyleBackColor = true;
            this.GameFolderOkButton.Click += new System.EventHandler(this.GameFolderOkButton_Click);
            // 
            // GameFolderAdministratorLabel
            // 
            this.GameFolderAdministratorLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.GameFolderAdministratorLabel.Location = new System.Drawing.Point(12, 100);
            this.GameFolderAdministratorLabel.Name = "GameFolderAdministratorLabel";
            this.GameFolderAdministratorLabel.Size = new System.Drawing.Size(360, 31);
            this.GameFolderAdministratorLabel.TabIndex = 0;
            this.GameFolderAdministratorLabel.Text = "If your current game folder requires administrator rights to modify content, plea" +
    "se close {0} and rerun as an administrator.";
            this.GameFolderAdministratorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.UpgradeGameButton);
            this.MenuPanel.Controls.Add(this.ConfigureGameButton);
            this.MenuPanel.Controls.Add(this.GameExecutableEditorButton);
            this.MenuPanel.Controls.Add(this.LanguageFileEditorButton);
            this.MenuPanel.Controls.Add(this.SettingsEditorButton);
            this.MenuPanel.Controls.Add(this.TelemetryViewerButton);
            this.MenuPanel.Controls.Add(this.SaveGameEditorButton);
            this.MenuPanel.Controls.Add(this.LaunchGameButton);
            this.MenuPanel.Location = new System.Drawing.Point(0, 96);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(384, 140);
            this.MenuPanel.TabIndex = 0;
            this.MenuPanel.Visible = false;
            // 
            // ConfigureGameButton
            // 
            this.ConfigureGameButton.Location = new System.Drawing.Point(8, 42);
            this.ConfigureGameButton.Name = "ConfigureGameButton";
            this.ConfigureGameButton.Size = new System.Drawing.Size(176, 23);
            this.ConfigureGameButton.TabIndex = 1;
            this.ConfigureGameButton.Text = "Configure Game";
            this.ConfigureGameButton.UseVisualStyleBackColor = true;
            this.ConfigureGameButton.Click += new System.EventHandler(this.ConfigureGameButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 236);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.GameFolderPanel);
            this.Controls.Add(this.MenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.GameFolderPanel.ResumeLayout(false);
            this.GameFolderPanel.PerformLayout();
            this.MenuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Panel GameFolderPanel;
        private System.Windows.Forms.TextBox GameFolderPathTextBox;
        private System.Windows.Forms.Button GameFolderOkButton;
        private System.Windows.Forms.Button GameFolderChangeButton;
        private System.Windows.Forms.Label GameFolderPathLabel;
        private System.Windows.Forms.Label GameFolderAdministratorLabel;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button UpgradeGameButton;
        private System.Windows.Forms.Button ConfigureGameButton;
        private System.Windows.Forms.Button GameExecutableEditorButton;
        private System.Windows.Forms.Button LanguageFileEditorButton;
        private System.Windows.Forms.Button TelemetryViewerButton;
        private System.Windows.Forms.Button SettingsEditorButton;
        private System.Windows.Forms.Button SaveGameEditorButton;
        private System.Windows.Forms.Button LaunchGameButton;
    }
}