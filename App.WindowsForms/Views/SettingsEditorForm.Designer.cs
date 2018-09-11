namespace App.WindowsForms.Views
{
    partial class SettingsEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsEditorForm));
            this.SettingsEditorTabControl = new System.Windows.Forms.TabControl();
            this.GameFolderTabPage = new System.Windows.Forms.TabPage();
            this.GameFolderGroupBox = new System.Windows.Forms.GroupBox();
            this.GameFolderDescriptionLabel = new System.Windows.Forms.Label();
            this.GameFolderLabel = new System.Windows.Forms.Label();
            this.GameFolderTextBox = new System.Windows.Forms.TextBox();
            this.GameFolderChangeButton = new System.Windows.Forms.Button();
            this.LaunchGameTabPage = new System.Windows.Forms.TabPage();
            this.LaunchGameGroupBox = new System.Windows.Forms.GroupBox();
            this.LaunchGameDescriptionLabel = new System.Windows.Forms.Label();
            this.LaunchGameLabel = new System.Windows.Forms.Label();
            this.LaunchGameTextBox = new System.Windows.Forms.TextBox();
            this.LaunchGameChangeButton = new System.Windows.Forms.Button();
            this.RegistryKeysTabPage = new System.Windows.Forms.TabPage();
            this.RegistryKeysGroupBox = new System.Windows.Forms.GroupBox();
            this.RegistryKeysPanel = new System.Windows.Forms.Panel();
            this.RegistryKeyLabel = new System.Windows.Forms.Label();
            this.RegistryKeyTextBox = new System.Windows.Forms.TextBox();
            this.InstallLabel = new System.Windows.Forms.Label();
            this.InstallTextBox = new System.Windows.Forms.TextBox();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.LanguageTextBox = new System.Windows.Forms.TextBox();
            this.PathLabel = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.ValidLabel = new System.Windows.Forms.Label();
            this.ValidTextBox = new System.Windows.Forms.TextBox();
            this.ResetButton = new System.Windows.Forms.Button();
            this.PathChangeButton = new System.Windows.Forms.Button();
            this.RegistryKeysAlternateKeyLabel = new System.Windows.Forms.Label();
            this.RegistryKeysInstallPanel = new System.Windows.Forms.Panel();
            this.RegistryKeysDescriptionLabel = new System.Windows.Forms.Label();
            this.RegistryKeysInstallButton = new System.Windows.Forms.Button();
            this.RegistryKeysInstallAlternateKeyLabel = new System.Windows.Forms.Label();
            this.AboutTabPage = new System.Windows.Forms.TabPage();
            this.AboutGroupBox = new System.Windows.Forms.GroupBox();
            this.AboutRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SettingsEditorTabControl.SuspendLayout();
            this.GameFolderTabPage.SuspendLayout();
            this.GameFolderGroupBox.SuspendLayout();
            this.LaunchGameTabPage.SuspendLayout();
            this.LaunchGameGroupBox.SuspendLayout();
            this.RegistryKeysTabPage.SuspendLayout();
            this.RegistryKeysGroupBox.SuspendLayout();
            this.RegistryKeysPanel.SuspendLayout();
            this.RegistryKeysInstallPanel.SuspendLayout();
            this.AboutTabPage.SuspendLayout();
            this.AboutGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsEditorTabControl
            // 
            this.SettingsEditorTabControl.Controls.Add(this.GameFolderTabPage);
            this.SettingsEditorTabControl.Controls.Add(this.LaunchGameTabPage);
            this.SettingsEditorTabControl.Controls.Add(this.RegistryKeysTabPage);
            this.SettingsEditorTabControl.Controls.Add(this.AboutTabPage);
            this.SettingsEditorTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsEditorTabControl.Location = new System.Drawing.Point(3, 3);
            this.SettingsEditorTabControl.Name = "SettingsEditorTabControl";
            this.SettingsEditorTabControl.SelectedIndex = 0;
            this.SettingsEditorTabControl.Size = new System.Drawing.Size(458, 255);
            this.SettingsEditorTabControl.TabIndex = 0;
            // 
            // GameFolderTabPage
            // 
            this.GameFolderTabPage.Controls.Add(this.GameFolderGroupBox);
            this.GameFolderTabPage.Location = new System.Drawing.Point(4, 22);
            this.GameFolderTabPage.Name = "GameFolderTabPage";
            this.GameFolderTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GameFolderTabPage.Size = new System.Drawing.Size(450, 229);
            this.GameFolderTabPage.TabIndex = 0;
            this.GameFolderTabPage.Text = "Game Folder";
            this.GameFolderTabPage.UseVisualStyleBackColor = true;
            // 
            // GameFolderGroupBox
            // 
            this.GameFolderGroupBox.Controls.Add(this.GameFolderDescriptionLabel);
            this.GameFolderGroupBox.Controls.Add(this.GameFolderLabel);
            this.GameFolderGroupBox.Controls.Add(this.GameFolderTextBox);
            this.GameFolderGroupBox.Controls.Add(this.GameFolderChangeButton);
            this.GameFolderGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameFolderGroupBox.Location = new System.Drawing.Point(3, 3);
            this.GameFolderGroupBox.Name = "GameFolderGroupBox";
            this.GameFolderGroupBox.Size = new System.Drawing.Size(444, 223);
            this.GameFolderGroupBox.TabIndex = 0;
            this.GameFolderGroupBox.TabStop = false;
            // 
            // GameFolderDescriptionLabel
            // 
            this.GameFolderDescriptionLabel.AutoSize = true;
            this.GameFolderDescriptionLabel.Location = new System.Drawing.Point(6, 16);
            this.GameFolderDescriptionLabel.Name = "GameFolderDescriptionLabel";
            this.GameFolderDescriptionLabel.Size = new System.Drawing.Size(267, 13);
            this.GameFolderDescriptionLabel.TabIndex = 0;
            this.GameFolderDescriptionLabel.Text = "Configure the game folder used by {0} to edit the game.";
            // 
            // GameFolderLabel
            // 
            this.GameFolderLabel.AutoSize = true;
            this.GameFolderLabel.Location = new System.Drawing.Point(42, 79);
            this.GameFolderLabel.Name = "GameFolderLabel";
            this.GameFolderLabel.Size = new System.Drawing.Size(70, 13);
            this.GameFolderLabel.TabIndex = 0;
            this.GameFolderLabel.Text = "Game Folder:";
            // 
            // GameFolderTextBox
            // 
            this.GameFolderTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.GameFolderTextBox.Location = new System.Drawing.Point(45, 95);
            this.GameFolderTextBox.Name = "GameFolderTextBox";
            this.GameFolderTextBox.ReadOnly = true;
            this.GameFolderTextBox.Size = new System.Drawing.Size(357, 20);
            this.GameFolderTextBox.TabIndex = 0;
            this.GameFolderTextBox.TabStop = false;
            // 
            // GameFolderChangeButton
            // 
            this.GameFolderChangeButton.Location = new System.Drawing.Point(327, 121);
            this.GameFolderChangeButton.Name = "GameFolderChangeButton";
            this.GameFolderChangeButton.Size = new System.Drawing.Size(75, 23);
            this.GameFolderChangeButton.TabIndex = 0;
            this.GameFolderChangeButton.Text = "Change...";
            this.GameFolderChangeButton.UseVisualStyleBackColor = true;
            this.GameFolderChangeButton.Click += new System.EventHandler(this.GameFolderChangeButton_Click);
            // 
            // LaunchGameTabPage
            // 
            this.LaunchGameTabPage.Controls.Add(this.LaunchGameGroupBox);
            this.LaunchGameTabPage.Location = new System.Drawing.Point(4, 22);
            this.LaunchGameTabPage.Name = "LaunchGameTabPage";
            this.LaunchGameTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LaunchGameTabPage.Size = new System.Drawing.Size(450, 229);
            this.LaunchGameTabPage.TabIndex = 1;
            this.LaunchGameTabPage.Text = "Launch Game";
            this.LaunchGameTabPage.UseVisualStyleBackColor = true;
            // 
            // LaunchGameGroupBox
            // 
            this.LaunchGameGroupBox.Controls.Add(this.LaunchGameDescriptionLabel);
            this.LaunchGameGroupBox.Controls.Add(this.LaunchGameLabel);
            this.LaunchGameGroupBox.Controls.Add(this.LaunchGameTextBox);
            this.LaunchGameGroupBox.Controls.Add(this.LaunchGameChangeButton);
            this.LaunchGameGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LaunchGameGroupBox.Location = new System.Drawing.Point(3, 3);
            this.LaunchGameGroupBox.Name = "LaunchGameGroupBox";
            this.LaunchGameGroupBox.Size = new System.Drawing.Size(444, 223);
            this.LaunchGameGroupBox.TabIndex = 0;
            this.LaunchGameGroupBox.TabStop = false;
            // 
            // LaunchGameDescriptionLabel
            // 
            this.LaunchGameDescriptionLabel.AutoSize = true;
            this.LaunchGameDescriptionLabel.Location = new System.Drawing.Point(6, 16);
            this.LaunchGameDescriptionLabel.Name = "LaunchGameDescriptionLabel";
            this.LaunchGameDescriptionLabel.Size = new System.Drawing.Size(308, 13);
            this.LaunchGameDescriptionLabel.TabIndex = 0;
            this.LaunchGameDescriptionLabel.Text = "Configure the game executable used by {0} to launch the game.";
            // 
            // LaunchGameLabel
            // 
            this.LaunchGameLabel.AutoSize = true;
            this.LaunchGameLabel.Location = new System.Drawing.Point(42, 79);
            this.LaunchGameLabel.Name = "LaunchGameLabel";
            this.LaunchGameLabel.Size = new System.Drawing.Size(94, 13);
            this.LaunchGameLabel.TabIndex = 0;
            this.LaunchGameLabel.Text = "Game Executable:";
            // 
            // LaunchGameTextBox
            // 
            this.LaunchGameTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.LaunchGameTextBox.Location = new System.Drawing.Point(45, 95);
            this.LaunchGameTextBox.Name = "LaunchGameTextBox";
            this.LaunchGameTextBox.ReadOnly = true;
            this.LaunchGameTextBox.Size = new System.Drawing.Size(357, 20);
            this.LaunchGameTextBox.TabIndex = 0;
            this.LaunchGameTextBox.TabStop = false;
            // 
            // LaunchGameChangeButton
            // 
            this.LaunchGameChangeButton.Location = new System.Drawing.Point(327, 121);
            this.LaunchGameChangeButton.Name = "LaunchGameChangeButton";
            this.LaunchGameChangeButton.Size = new System.Drawing.Size(75, 23);
            this.LaunchGameChangeButton.TabIndex = 0;
            this.LaunchGameChangeButton.Text = "Change...";
            this.LaunchGameChangeButton.UseVisualStyleBackColor = true;
            this.LaunchGameChangeButton.Click += new System.EventHandler(this.LaunchGameChangeButton_Click);
            // 
            // RegistryKeysTabPage
            // 
            this.RegistryKeysTabPage.Controls.Add(this.RegistryKeysGroupBox);
            this.RegistryKeysTabPage.Location = new System.Drawing.Point(4, 22);
            this.RegistryKeysTabPage.Name = "RegistryKeysTabPage";
            this.RegistryKeysTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.RegistryKeysTabPage.Size = new System.Drawing.Size(450, 229);
            this.RegistryKeysTabPage.TabIndex = 2;
            this.RegistryKeysTabPage.Text = "Registry Keys";
            this.RegistryKeysTabPage.UseVisualStyleBackColor = true;
            // 
            // RegistryKeysGroupBox
            // 
            this.RegistryKeysGroupBox.Controls.Add(this.RegistryKeysPanel);
            this.RegistryKeysGroupBox.Controls.Add(this.RegistryKeysInstallPanel);
            this.RegistryKeysGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegistryKeysGroupBox.Location = new System.Drawing.Point(3, 3);
            this.RegistryKeysGroupBox.Name = "RegistryKeysGroupBox";
            this.RegistryKeysGroupBox.Size = new System.Drawing.Size(444, 223);
            this.RegistryKeysGroupBox.TabIndex = 0;
            this.RegistryKeysGroupBox.TabStop = false;
            // 
            // RegistryKeysPanel
            // 
            this.RegistryKeysPanel.Controls.Add(this.RegistryKeyLabel);
            this.RegistryKeysPanel.Controls.Add(this.RegistryKeyTextBox);
            this.RegistryKeysPanel.Controls.Add(this.InstallLabel);
            this.RegistryKeysPanel.Controls.Add(this.InstallTextBox);
            this.RegistryKeysPanel.Controls.Add(this.LanguageLabel);
            this.RegistryKeysPanel.Controls.Add(this.LanguageTextBox);
            this.RegistryKeysPanel.Controls.Add(this.PathLabel);
            this.RegistryKeysPanel.Controls.Add(this.PathTextBox);
            this.RegistryKeysPanel.Controls.Add(this.ValidLabel);
            this.RegistryKeysPanel.Controls.Add(this.ValidTextBox);
            this.RegistryKeysPanel.Controls.Add(this.ResetButton);
            this.RegistryKeysPanel.Controls.Add(this.PathChangeButton);
            this.RegistryKeysPanel.Controls.Add(this.RegistryKeysAlternateKeyLabel);
            this.RegistryKeysPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegistryKeysPanel.Location = new System.Drawing.Point(3, 16);
            this.RegistryKeysPanel.Name = "RegistryKeysPanel";
            this.RegistryKeysPanel.Size = new System.Drawing.Size(438, 204);
            this.RegistryKeysPanel.TabIndex = 0;
            this.RegistryKeysPanel.Visible = false;
            // 
            // RegistryKeyLabel
            // 
            this.RegistryKeyLabel.AutoSize = true;
            this.RegistryKeyLabel.Location = new System.Drawing.Point(13, 3);
            this.RegistryKeyLabel.Name = "RegistryKeyLabel";
            this.RegistryKeyLabel.Size = new System.Drawing.Size(69, 13);
            this.RegistryKeyLabel.TabIndex = 0;
            this.RegistryKeyLabel.Text = "Registry Key:";
            // 
            // RegistryKeyTextBox
            // 
            this.RegistryKeyTextBox.Location = new System.Drawing.Point(16, 19);
            this.RegistryKeyTextBox.Name = "RegistryKeyTextBox";
            this.RegistryKeyTextBox.ReadOnly = true;
            this.RegistryKeyTextBox.Size = new System.Drawing.Size(400, 20);
            this.RegistryKeyTextBox.TabIndex = 0;
            this.RegistryKeyTextBox.TabStop = false;
            // 
            // InstallLabel
            // 
            this.InstallLabel.AutoSize = true;
            this.InstallLabel.Location = new System.Drawing.Point(73, 48);
            this.InstallLabel.Name = "InstallLabel";
            this.InstallLabel.Size = new System.Drawing.Size(37, 13);
            this.InstallLabel.TabIndex = 0;
            this.InstallLabel.Text = "Install:";
            // 
            // InstallTextBox
            // 
            this.InstallTextBox.Location = new System.Drawing.Point(116, 45);
            this.InstallTextBox.Name = "InstallTextBox";
            this.InstallTextBox.ReadOnly = true;
            this.InstallTextBox.Size = new System.Drawing.Size(300, 20);
            this.InstallTextBox.TabIndex = 0;
            this.InstallTextBox.TabStop = false;
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.AutoSize = true;
            this.LanguageLabel.Location = new System.Drawing.Point(52, 74);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(58, 13);
            this.LanguageLabel.TabIndex = 0;
            this.LanguageLabel.Text = "Language:";
            // 
            // LanguageTextBox
            // 
            this.LanguageTextBox.Location = new System.Drawing.Point(116, 71);
            this.LanguageTextBox.Name = "LanguageTextBox";
            this.LanguageTextBox.ReadOnly = true;
            this.LanguageTextBox.Size = new System.Drawing.Size(300, 20);
            this.LanguageTextBox.TabIndex = 0;
            this.LanguageTextBox.TabStop = false;
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(78, 100);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(32, 13);
            this.PathLabel.TabIndex = 0;
            this.PathLabel.Text = "Path:";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(116, 97);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(300, 20);
            this.PathTextBox.TabIndex = 0;
            this.PathTextBox.TabStop = false;
            // 
            // ValidLabel
            // 
            this.ValidLabel.AutoSize = true;
            this.ValidLabel.Location = new System.Drawing.Point(77, 129);
            this.ValidLabel.Name = "ValidLabel";
            this.ValidLabel.Size = new System.Drawing.Size(33, 13);
            this.ValidLabel.TabIndex = 0;
            this.ValidLabel.Text = "Valid:";
            // 
            // ValidTextBox
            // 
            this.ValidTextBox.Location = new System.Drawing.Point(116, 126);
            this.ValidTextBox.Name = "ValidTextBox";
            this.ValidTextBox.ReadOnly = true;
            this.ValidTextBox.Size = new System.Drawing.Size(300, 20);
            this.ValidTextBox.TabIndex = 0;
            this.ValidTextBox.TabStop = false;
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(16, 152);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(197, 23);
            this.ResetButton.TabIndex = 1;
            this.ResetButton.Text = "Reset all subkeys to default values";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // PathChangeButton
            // 
            this.PathChangeButton.Location = new System.Drawing.Point(219, 152);
            this.PathChangeButton.Name = "PathChangeButton";
            this.PathChangeButton.Size = new System.Drawing.Size(197, 23);
            this.PathChangeButton.TabIndex = 0;
            this.PathChangeButton.Text = "Change Path to use game folder...";
            this.PathChangeButton.UseVisualStyleBackColor = true;
            this.PathChangeButton.Click += new System.EventHandler(this.PathChangeButton_Click);
            // 
            // RegistryKeysAlternateKeyLabel
            // 
            this.RegistryKeysAlternateKeyLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RegistryKeysAlternateKeyLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.RegistryKeysAlternateKeyLabel.Location = new System.Drawing.Point(3, 191);
            this.RegistryKeysAlternateKeyLabel.Name = "RegistryKeysAlternateKeyLabel";
            this.RegistryKeysAlternateKeyLabel.Size = new System.Drawing.Size(432, 13);
            this.RegistryKeysAlternateKeyLabel.TabIndex = 0;
            this.RegistryKeysAlternateKeyLabel.Text = "Key may also appear under HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node";
            this.RegistryKeysAlternateKeyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RegistryKeysInstallPanel
            // 
            this.RegistryKeysInstallPanel.Controls.Add(this.RegistryKeysDescriptionLabel);
            this.RegistryKeysInstallPanel.Controls.Add(this.RegistryKeysInstallButton);
            this.RegistryKeysInstallPanel.Controls.Add(this.RegistryKeysInstallAlternateKeyLabel);
            this.RegistryKeysInstallPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegistryKeysInstallPanel.Location = new System.Drawing.Point(3, 16);
            this.RegistryKeysInstallPanel.Margin = new System.Windows.Forms.Padding(0);
            this.RegistryKeysInstallPanel.Name = "RegistryKeysInstallPanel";
            this.RegistryKeysInstallPanel.Size = new System.Drawing.Size(438, 204);
            this.RegistryKeysInstallPanel.TabIndex = 0;
            this.RegistryKeysInstallPanel.Visible = false;
            // 
            // RegistryKeysDescriptionLabel
            // 
            this.RegistryKeysDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegistryKeysDescriptionLabel.Location = new System.Drawing.Point(3, 3);
            this.RegistryKeysDescriptionLabel.Margin = new System.Windows.Forms.Padding(3);
            this.RegistryKeysDescriptionLabel.Name = "RegistryKeysDescriptionLabel";
            this.RegistryKeysDescriptionLabel.Size = new System.Drawing.Size(432, 121);
            this.RegistryKeysDescriptionLabel.TabIndex = 0;
            this.RegistryKeysDescriptionLabel.Text = resources.GetString("RegistryKeysDescriptionLabel.Text");
            // 
            // RegistryKeysInstallButton
            // 
            this.RegistryKeysInstallButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegistryKeysInstallButton.Location = new System.Drawing.Point(119, 149);
            this.RegistryKeysInstallButton.Name = "RegistryKeysInstallButton";
            this.RegistryKeysInstallButton.Size = new System.Drawing.Size(200, 23);
            this.RegistryKeysInstallButton.TabIndex = 0;
            this.RegistryKeysInstallButton.Text = "Install Registry Keys";
            this.RegistryKeysInstallButton.UseVisualStyleBackColor = true;
            this.RegistryKeysInstallButton.Click += new System.EventHandler(this.RegistryKeysInstallButton_Click);
            // 
            // RegistryKeysInstallAlternateKeyLabel
            // 
            this.RegistryKeysInstallAlternateKeyLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RegistryKeysInstallAlternateKeyLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.RegistryKeysInstallAlternateKeyLabel.Location = new System.Drawing.Point(3, 191);
            this.RegistryKeysInstallAlternateKeyLabel.Name = "RegistryKeysInstallAlternateKeyLabel";
            this.RegistryKeysInstallAlternateKeyLabel.Size = new System.Drawing.Size(432, 13);
            this.RegistryKeysInstallAlternateKeyLabel.TabIndex = 0;
            this.RegistryKeysInstallAlternateKeyLabel.Text = "Key may also appear under HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node";
            this.RegistryKeysInstallAlternateKeyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AboutTabPage
            // 
            this.AboutTabPage.Controls.Add(this.AboutGroupBox);
            this.AboutTabPage.Location = new System.Drawing.Point(4, 22);
            this.AboutTabPage.Name = "AboutTabPage";
            this.AboutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AboutTabPage.Size = new System.Drawing.Size(450, 229);
            this.AboutTabPage.TabIndex = 3;
            this.AboutTabPage.Text = "About";
            this.AboutTabPage.UseVisualStyleBackColor = true;
            // 
            // AboutGroupBox
            // 
            this.AboutGroupBox.Controls.Add(this.AboutRichTextBox);
            this.AboutGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutGroupBox.Location = new System.Drawing.Point(3, 3);
            this.AboutGroupBox.Name = "AboutGroupBox";
            this.AboutGroupBox.Size = new System.Drawing.Size(444, 223);
            this.AboutGroupBox.TabIndex = 0;
            this.AboutGroupBox.TabStop = false;
            // 
            // AboutRichTextBox
            // 
            this.AboutRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.AboutRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AboutRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AboutRichTextBox.Location = new System.Drawing.Point(3, 16);
            this.AboutRichTextBox.Name = "AboutRichTextBox";
            this.AboutRichTextBox.ReadOnly = true;
            this.AboutRichTextBox.Size = new System.Drawing.Size(438, 204);
            this.AboutRichTextBox.TabIndex = 0;
            this.AboutRichTextBox.TabStop = false;
            this.AboutRichTextBox.Text = resources.GetString("AboutRichTextBox.Text");
            // 
            // SettingsEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 261);
            this.Controls.Add(this.SettingsEditorTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsEditorForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SettingsEditorForm_Load);
            this.SettingsEditorTabControl.ResumeLayout(false);
            this.GameFolderTabPage.ResumeLayout(false);
            this.GameFolderGroupBox.ResumeLayout(false);
            this.GameFolderGroupBox.PerformLayout();
            this.LaunchGameTabPage.ResumeLayout(false);
            this.LaunchGameGroupBox.ResumeLayout(false);
            this.LaunchGameGroupBox.PerformLayout();
            this.RegistryKeysTabPage.ResumeLayout(false);
            this.RegistryKeysGroupBox.ResumeLayout(false);
            this.RegistryKeysPanel.ResumeLayout(false);
            this.RegistryKeysPanel.PerformLayout();
            this.RegistryKeysInstallPanel.ResumeLayout(false);
            this.AboutTabPage.ResumeLayout(false);
            this.AboutGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl SettingsEditorTabControl;
        private System.Windows.Forms.TabPage GameFolderTabPage;
        private System.Windows.Forms.TabPage LaunchGameTabPage;
        private System.Windows.Forms.GroupBox GameFolderGroupBox;
        private System.Windows.Forms.GroupBox LaunchGameGroupBox;
        private System.Windows.Forms.TabPage RegistryKeysTabPage;
        private System.Windows.Forms.GroupBox RegistryKeysGroupBox;
        private System.Windows.Forms.Label GameFolderLabel;
        private System.Windows.Forms.TextBox GameFolderTextBox;
        private System.Windows.Forms.Button GameFolderChangeButton;
        private System.Windows.Forms.Label LaunchGameLabel;
        private System.Windows.Forms.TextBox LaunchGameTextBox;
        private System.Windows.Forms.Button LaunchGameChangeButton;
        private System.Windows.Forms.Label GameFolderDescriptionLabel;
        private System.Windows.Forms.Label LaunchGameDescriptionLabel;
        private System.Windows.Forms.Panel RegistryKeysPanel;
        private System.Windows.Forms.Label RegistryKeyLabel;
        private System.Windows.Forms.TextBox RegistryKeyTextBox;
        private System.Windows.Forms.Label InstallLabel;
        private System.Windows.Forms.TextBox InstallTextBox;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.TextBox LanguageTextBox;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label ValidLabel;
        private System.Windows.Forms.TextBox ValidTextBox;
        private System.Windows.Forms.Button PathChangeButton;
        private System.Windows.Forms.Panel RegistryKeysInstallPanel;
        private System.Windows.Forms.Button RegistryKeysInstallButton;
        private System.Windows.Forms.Label RegistryKeysDescriptionLabel;
        private System.Windows.Forms.Label RegistryKeysInstallAlternateKeyLabel;
        private System.Windows.Forms.Label RegistryKeysAlternateKeyLabel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.TabPage AboutTabPage;
        private System.Windows.Forms.RichTextBox AboutRichTextBox;
        private System.Windows.Forms.GroupBox AboutGroupBox;
    }
}