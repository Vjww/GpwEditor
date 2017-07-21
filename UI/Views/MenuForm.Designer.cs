namespace GpwEditor.Views
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
            this.RegistryKeysButton = new System.Windows.Forms.Button();
            this.LanguageFileEditorButton = new System.Windows.Forms.Button();
            this.LaunchGameButton = new System.Windows.Forms.Button();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.MenuToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.UpgradeGameButton = new System.Windows.Forms.Button();
            this.GameFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.ConfigureGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GameExecutableEditorButton
            // 
            this.GameExecutableEditorButton.Location = new System.Drawing.Point(8, 170);
            this.GameExecutableEditorButton.Name = "GameExecutableEditorButton";
            this.GameExecutableEditorButton.Size = new System.Drawing.Size(176, 23);
            this.GameExecutableEditorButton.TabIndex = 1;
            this.GameExecutableEditorButton.Text = "Game Executable Editor";
            this.MenuToolTip.SetToolTip(this.GameExecutableEditorButton, "Use the game executable editor to make changes to a game executable file.");
            this.GameExecutableEditorButton.UseVisualStyleBackColor = true;
            this.GameExecutableEditorButton.Click += new System.EventHandler(this.GameEditorButton_Click);
            // 
            // SaveGameEditorButton
            // 
            this.SaveGameEditorButton.Location = new System.Drawing.Point(200, 170);
            this.SaveGameEditorButton.Name = "SaveGameEditorButton";
            this.SaveGameEditorButton.Size = new System.Drawing.Size(176, 23);
            this.SaveGameEditorButton.TabIndex = 2;
            this.SaveGameEditorButton.Text = "Save Game Editor";
            this.MenuToolTip.SetToolTip(this.SaveGameEditorButton, "Use the save game editor to make changes to a save game file.");
            this.SaveGameEditorButton.UseVisualStyleBackColor = true;
            this.SaveGameEditorButton.Click += new System.EventHandler(this.SaveGameEditorButton_Click);
            // 
            // RegistryKeysButton
            // 
            this.RegistryKeysButton.Location = new System.Drawing.Point(200, 102);
            this.RegistryKeysButton.Name = "RegistryKeysButton";
            this.RegistryKeysButton.Size = new System.Drawing.Size(176, 23);
            this.RegistryKeysButton.TabIndex = 4;
            this.RegistryKeysButton.Text = "Registry Keys";
            this.MenuToolTip.SetToolTip(this.RegistryKeysButton, "Use the registry keys tool to create the registry keys for the game and change th" +
        "e registered location of the game folder.");
            this.RegistryKeysButton.UseVisualStyleBackColor = true;
            this.RegistryKeysButton.Click += new System.EventHandler(this.RegistryKeysButton_Click);
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
            this.LaunchGameButton.TabIndex = 6;
            this.LaunchGameButton.Text = "Launch Game";
            this.MenuToolTip.SetToolTip(this.LaunchGameButton, "Launch the game!");
            this.LaunchGameButton.UseVisualStyleBackColor = true;
            this.LaunchGameButton.Click += new System.EventHandler(this.LaunchGameButton_Click);
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Image = global::GpwEditor.Properties.Resources.logo3;
            this.LogoPictureBox.InitialImage = null;
            this.LogoPictureBox.Location = new System.Drawing.Point(0, 0);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(384, 96);
            this.LogoPictureBox.TabIndex = 3;
            this.LogoPictureBox.TabStop = false;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(200, 136);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(176, 23);
            this.SettingsButton.TabIndex = 5;
            this.SettingsButton.Text = "Settings";
            this.MenuToolTip.SetToolTip(this.SettingsButton, "Change the settings for this application.");
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
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
            this.ConfigureGameButton.TabIndex = 7;
            this.ConfigureGameButton.Text = "Configure Game";
            this.ConfigureGameButton.UseVisualStyleBackColor = true;
            this.ConfigureGameButton.Click += new System.EventHandler(this.ConfigureGameButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 236);
            this.Controls.Add(this.ConfigureGameButton);
            this.Controls.Add(this.LaunchGameButton);
            this.Controls.Add(this.LanguageFileEditorButton);
            this.Controls.Add(this.RegistryKeysButton);
            this.Controls.Add(this.SaveGameEditorButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.UpgradeGameButton);
            this.Controls.Add(this.GameExecutableEditorButton);
            this.Controls.Add(this.LogoPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GameExecutableEditorButton;
        private System.Windows.Forms.Button SaveGameEditorButton;
        private System.Windows.Forms.Button RegistryKeysButton;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Button LanguageFileEditorButton;
        private System.Windows.Forms.Button LaunchGameButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.ToolTip MenuToolTip;
        private System.Windows.Forms.FolderBrowserDialog GameFolderBrowserDialog;
        private System.Windows.Forms.Button UpgradeGameButton;
        private System.Windows.Forms.Button ConfigureGameButton;
    }
}

