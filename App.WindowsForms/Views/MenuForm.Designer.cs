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
            this.components = new System.ComponentModel.Container();
            this.GameExecutableEditorButton = new System.Windows.Forms.Button();
            this.SaveGameEditorButton = new System.Windows.Forms.Button();
            this.GameFolderButton = new System.Windows.Forms.Button();
            this.LanguageFileEditorButton = new System.Windows.Forms.Button();
            this.LaunchGameButton = new System.Windows.Forms.Button();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.EditorSettingsButton = new System.Windows.Forms.Button();
            this.MenuToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.UpgradeGameButton = new System.Windows.Forms.Button();
            this.GameFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ConfigureGameButton = new System.Windows.Forms.Button();
            this.GameFolderPanel = new System.Windows.Forms.Panel();
            this.GameFolderAdministratorLabel = new System.Windows.Forms.Label();
            this.GameFolderPathLabel = new System.Windows.Forms.Label();
            this.GameFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.GameFolderChangeButton = new System.Windows.Forms.Button();
            this.GameFolderOkButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.GameFolderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameExecutableEditorButton
            // 
            this.GameExecutableEditorButton.Location = new System.Drawing.Point(8, 170);
            this.GameExecutableEditorButton.Name = "GameExecutableEditorButton";
            this.GameExecutableEditorButton.Size = new System.Drawing.Size(176, 23);
            this.GameExecutableEditorButton.TabIndex = 2;
            this.GameExecutableEditorButton.Text = "Game Executable Editor";
            this.MenuToolTip.SetToolTip(this.GameExecutableEditorButton, "Use the game executable editor to make changes to a game executable file.");
            this.GameExecutableEditorButton.UseVisualStyleBackColor = true;
            this.GameExecutableEditorButton.Click += new System.EventHandler(this.GameExecutableEditorButton_Click);
            // 
            // SaveGameEditorButton
            // 
            this.SaveGameEditorButton.Location = new System.Drawing.Point(200, 170);
            this.SaveGameEditorButton.Name = "SaveGameEditorButton";
            this.SaveGameEditorButton.Size = new System.Drawing.Size(176, 23);
            this.SaveGameEditorButton.TabIndex = 6;
            this.SaveGameEditorButton.Text = "Save Game Editor";
            this.MenuToolTip.SetToolTip(this.SaveGameEditorButton, "Use the save game editor to make changes to a save game file.");
            this.SaveGameEditorButton.UseVisualStyleBackColor = true;
            this.SaveGameEditorButton.Click += new System.EventHandler(this.SaveGameEditorButton_Click);
            // 
            // GameFolderButton
            // 
            this.GameFolderButton.Location = new System.Drawing.Point(200, 102);
            this.GameFolderButton.Name = "GameFolderButton";
            this.GameFolderButton.Size = new System.Drawing.Size(176, 23);
            this.GameFolderButton.TabIndex = 4;
            this.GameFolderButton.Text = "Current Game Folder";
            this.MenuToolTip.SetToolTip(this.GameFolderButton, "Use the registry keys tool to create the registry keys for the game and change th" +
        "e registered location of the game folder.");
            this.GameFolderButton.UseVisualStyleBackColor = true;
            this.GameFolderButton.Click += new System.EventHandler(this.GameFolderButton_Click);
            // 
            // LanguageFileEditorButton
            // 
            this.LanguageFileEditorButton.Location = new System.Drawing.Point(8, 204);
            this.LanguageFileEditorButton.Name = "LanguageFileEditorButton";
            this.LanguageFileEditorButton.Size = new System.Drawing.Size(176, 23);
            this.LanguageFileEditorButton.TabIndex = 3;
            this.LanguageFileEditorButton.Text = "Language File Editor";
            this.MenuToolTip.SetToolTip(this.LanguageFileEditorButton, "Use the language file editor to make changes to a language file.");
            this.LanguageFileEditorButton.UseVisualStyleBackColor = true;
            this.LanguageFileEditorButton.Click += new System.EventHandler(this.LanguageFileEditorButton_Click);
            // 
            // LaunchGameButton
            // 
            this.LaunchGameButton.Location = new System.Drawing.Point(200, 204);
            this.LaunchGameButton.Name = "LaunchGameButton";
            this.LaunchGameButton.Size = new System.Drawing.Size(176, 23);
            this.LaunchGameButton.TabIndex = 7;
            this.LaunchGameButton.Text = "Launch Game";
            this.MenuToolTip.SetToolTip(this.LaunchGameButton, "Launch the game!");
            this.LaunchGameButton.UseVisualStyleBackColor = true;
            this.LaunchGameButton.Click += new System.EventHandler(this.LaunchGameButton_Click);
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
            // EditorSettingsButton
            // 
            this.EditorSettingsButton.Location = new System.Drawing.Point(200, 136);
            this.EditorSettingsButton.Name = "EditorSettingsButton";
            this.EditorSettingsButton.Size = new System.Drawing.Size(176, 23);
            this.EditorSettingsButton.TabIndex = 5;
            this.EditorSettingsButton.Text = "Editor Settings";
            this.MenuToolTip.SetToolTip(this.EditorSettingsButton, "Change the settings for this application.");
            this.EditorSettingsButton.UseVisualStyleBackColor = true;
            this.EditorSettingsButton.Click += new System.EventHandler(this.EditorSettingsButton_Click);
            // 
            // UpgradeGameButton
            // 
            this.UpgradeGameButton.Location = new System.Drawing.Point(8, 102);
            this.UpgradeGameButton.Name = "UpgradeGameButton";
            this.UpgradeGameButton.Size = new System.Drawing.Size(176, 23);
            this.UpgradeGameButton.TabIndex = 0;
            this.UpgradeGameButton.Text = "Upgrade Game";
            this.MenuToolTip.SetToolTip(this.UpgradeGameButton, "Use the game upgrader to make changes to a game executable file.");
            this.UpgradeGameButton.UseVisualStyleBackColor = true;
            this.UpgradeGameButton.Click += new System.EventHandler(this.UpgradeGameButton_Click);
            // 
            // GameFolderBrowserDialog
            // 
            this.GameFolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // ConfigureGameButton
            // 
            this.ConfigureGameButton.Location = new System.Drawing.Point(8, 136);
            this.ConfigureGameButton.Name = "ConfigureGameButton";
            this.ConfigureGameButton.Size = new System.Drawing.Size(176, 23);
            this.ConfigureGameButton.TabIndex = 1;
            this.ConfigureGameButton.Text = "Configure Game";
            this.ConfigureGameButton.UseVisualStyleBackColor = true;
            this.ConfigureGameButton.Click += new System.EventHandler(this.ConfigureGameButton_Click);
            // 
            // GameFolderPanel
            // 
            this.GameFolderPanel.Controls.Add(this.GameFolderAdministratorLabel);
            this.GameFolderPanel.Controls.Add(this.GameFolderPathLabel);
            this.GameFolderPanel.Controls.Add(this.GameFolderPathTextBox);
            this.GameFolderPanel.Controls.Add(this.GameFolderChangeButton);
            this.GameFolderPanel.Controls.Add(this.GameFolderOkButton);
            this.GameFolderPanel.Location = new System.Drawing.Point(0, 96);
            this.GameFolderPanel.Name = "GameFolderPanel";
            this.GameFolderPanel.Size = new System.Drawing.Size(384, 140);
            this.GameFolderPanel.TabIndex = 8;
            this.GameFolderPanel.Visible = false;
            // 
            // GameFolderAdministratorLabel
            // 
            this.GameFolderAdministratorLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.GameFolderAdministratorLabel.Location = new System.Drawing.Point(12, 100);
            this.GameFolderAdministratorLabel.Name = "GameFolderAdministratorLabel";
            this.GameFolderAdministratorLabel.Size = new System.Drawing.Size(360, 31);
            this.GameFolderAdministratorLabel.TabIndex = 5;
            this.GameFolderAdministratorLabel.Text = "If your game folder requires administrative privileges to modify content, please " +
    "close this window and rerun {0} as an administrator.";
            this.GameFolderAdministratorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.GameFolderPathTextBox.TabIndex = 4;
            // 
            // GameFolderChangeButton
            // 
            this.GameFolderChangeButton.Location = new System.Drawing.Point(216, 68);
            this.GameFolderChangeButton.Name = "GameFolderChangeButton";
            this.GameFolderChangeButton.Size = new System.Drawing.Size(75, 23);
            this.GameFolderChangeButton.TabIndex = 2;
            this.GameFolderChangeButton.Text = "Change...";
            this.GameFolderChangeButton.UseVisualStyleBackColor = true;
            this.GameFolderChangeButton.Click += new System.EventHandler(this.GameFolderChangeButton_Click);
            // 
            // GameFolderOkButton
            // 
            this.GameFolderOkButton.Location = new System.Drawing.Point(297, 68);
            this.GameFolderOkButton.Name = "GameFolderOkButton";
            this.GameFolderOkButton.Size = new System.Drawing.Size(75, 23);
            this.GameFolderOkButton.TabIndex = 3;
            this.GameFolderOkButton.Text = "OK";
            this.GameFolderOkButton.UseVisualStyleBackColor = true;
            this.GameFolderOkButton.Click += new System.EventHandler(this.GameFolderOkButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 236);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.GameFolderPanel);
            this.Controls.Add(this.UpgradeGameButton);
            this.Controls.Add(this.ConfigureGameButton);
            this.Controls.Add(this.GameExecutableEditorButton);
            this.Controls.Add(this.LanguageFileEditorButton);
            this.Controls.Add(this.GameFolderButton);
            this.Controls.Add(this.EditorSettingsButton);
            this.Controls.Add(this.SaveGameEditorButton);
            this.Controls.Add(this.LaunchGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.GameFolderPanel.ResumeLayout(false);
            this.GameFolderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GameExecutableEditorButton;
        private System.Windows.Forms.Button SaveGameEditorButton;
        private System.Windows.Forms.Button GameFolderButton;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Button LanguageFileEditorButton;
        private System.Windows.Forms.Button LaunchGameButton;
        private System.Windows.Forms.Button EditorSettingsButton;
        private System.Windows.Forms.ToolTip MenuToolTip;
        private System.Windows.Forms.FolderBrowserDialog GameFolderBrowserDialog;
        private System.Windows.Forms.Button UpgradeGameButton;
        private System.Windows.Forms.Button ConfigureGameButton;
        private System.Windows.Forms.Panel GameFolderPanel;
        private System.Windows.Forms.TextBox GameFolderPathTextBox;
        private System.Windows.Forms.Button GameFolderOkButton;
        private System.Windows.Forms.Button GameFolderChangeButton;
        private System.Windows.Forms.Label GameFolderPathLabel;
        private System.Windows.Forms.Label GameFolderAdministratorLabel;
    }
}