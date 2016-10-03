namespace GpwEditor
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
            this.GameEditorButton = new System.Windows.Forms.Button();
            this.SaveGameEditorButton = new System.Windows.Forms.Button();
            this.RegistryKeysButton = new System.Windows.Forms.Button();
            this.LanguageFileEditorButton = new System.Windows.Forms.Button();
            this.LaunchGameButton = new System.Windows.Forms.Button();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.MenuToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.GameFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.UpgradeGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GameEditorButton
            // 
            this.GameEditorButton.Location = new System.Drawing.Point(8, 136);
            this.GameEditorButton.Name = "GameEditorButton";
            this.GameEditorButton.Size = new System.Drawing.Size(176, 23);
            this.GameEditorButton.TabIndex = 0;
            this.GameEditorButton.Text = "Game Editor";
            this.MenuToolTip.SetToolTip(this.GameEditorButton, "Use the game editor to make changes to the game executable file.");
            this.GameEditorButton.UseVisualStyleBackColor = true;
            this.GameEditorButton.Click += new System.EventHandler(this.GameEditorButton_Click);
            // 
            // SaveGameEditorButton
            // 
            this.SaveGameEditorButton.Enabled = false;
            this.SaveGameEditorButton.Location = new System.Drawing.Point(8, 168);
            this.SaveGameEditorButton.Name = "SaveGameEditorButton";
            this.SaveGameEditorButton.Size = new System.Drawing.Size(176, 23);
            this.SaveGameEditorButton.TabIndex = 1;
            this.SaveGameEditorButton.Text = "Save Game Editor";
            this.MenuToolTip.SetToolTip(this.SaveGameEditorButton, "Use the save game editor to make changes to a save game file.");
            this.SaveGameEditorButton.UseVisualStyleBackColor = true;
            this.SaveGameEditorButton.Click += new System.EventHandler(this.SaveGameEditorButton_Click);
            // 
            // RegistryKeysButton
            // 
            this.RegistryKeysButton.Location = new System.Drawing.Point(200, 104);
            this.RegistryKeysButton.Name = "RegistryKeysButton";
            this.RegistryKeysButton.Size = new System.Drawing.Size(176, 23);
            this.RegistryKeysButton.TabIndex = 3;
            this.RegistryKeysButton.Text = "Registry Keys";
            this.MenuToolTip.SetToolTip(this.RegistryKeysButton, "Use the registry keys tool to create the registry keys for the game and change th" +
        "e location of the game folder.");
            this.RegistryKeysButton.UseVisualStyleBackColor = true;
            this.RegistryKeysButton.Click += new System.EventHandler(this.RegistryKeysButton_Click);
            // 
            // LanguageFileEditorButton
            // 
            this.LanguageFileEditorButton.Enabled = false;
            this.LanguageFileEditorButton.Location = new System.Drawing.Point(8, 200);
            this.LanguageFileEditorButton.Name = "LanguageFileEditorButton";
            this.LanguageFileEditorButton.Size = new System.Drawing.Size(176, 23);
            this.LanguageFileEditorButton.TabIndex = 2;
            this.LanguageFileEditorButton.Text = "Language File Editor";
            this.MenuToolTip.SetToolTip(this.LanguageFileEditorButton, "Use the language file editor to make changes to a language file.");
            this.LanguageFileEditorButton.UseVisualStyleBackColor = true;
            this.LanguageFileEditorButton.Click += new System.EventHandler(this.LanguageFileEditorButton_Click);
            // 
            // LaunchGameButton
            // 
            this.LaunchGameButton.Location = new System.Drawing.Point(200, 168);
            this.LaunchGameButton.Name = "LaunchGameButton";
            this.LaunchGameButton.Size = new System.Drawing.Size(176, 23);
            this.LaunchGameButton.TabIndex = 5;
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
            this.SettingsButton.TabIndex = 4;
            this.SettingsButton.Text = "Settings";
            this.MenuToolTip.SetToolTip(this.SettingsButton, "Use the hacking tools to alter code inside the game executable.");
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // GameFolderBrowserDialog
            // 
            this.GameFolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // UpgradeGameButton
            // 
            this.UpgradeGameButton.Location = new System.Drawing.Point(8, 104);
            this.UpgradeGameButton.Name = "UpgradeGameButton";
            this.UpgradeGameButton.Size = new System.Drawing.Size(176, 23);
            this.UpgradeGameButton.TabIndex = 0;
            this.UpgradeGameButton.Text = "Upgrade Game";
            this.UpgradeGameButton.UseVisualStyleBackColor = true;
            this.UpgradeGameButton.Click += new System.EventHandler(this.UpgradeGameButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 236);
            this.Controls.Add(this.LaunchGameButton);
            this.Controls.Add(this.LanguageFileEditorButton);
            this.Controls.Add(this.RegistryKeysButton);
            this.Controls.Add(this.SaveGameEditorButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.UpgradeGameButton);
            this.Controls.Add(this.GameEditorButton);
            this.Controls.Add(this.LogoPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{0}";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GameEditorButton;
        private System.Windows.Forms.Button SaveGameEditorButton;
        private System.Windows.Forms.Button RegistryKeysButton;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Button LanguageFileEditorButton;
        private System.Windows.Forms.Button LaunchGameButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.ToolTip MenuToolTip;
        private System.Windows.Forms.FolderBrowserDialog GameFolderBrowserDialog;
        private System.Windows.Forms.Button UpgradeGameButton;
    }
}

