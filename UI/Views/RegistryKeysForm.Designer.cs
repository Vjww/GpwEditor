namespace GpwEditor.Views
{
    partial class RegistryKeysForm
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
            this.RegistryKeyLabel = new System.Windows.Forms.Label();
            this.RegistryKeyLocationTextBox = new System.Windows.Forms.TextBox();
            this.ValidTextBox = new System.Windows.Forms.TextBox();
            this.ValidLabel = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.PathLabel = new System.Windows.Forms.Label();
            this.LanguageTextBox = new System.Windows.Forms.TextBox();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.InstallTextBox = new System.Windows.Forms.TextBox();
            this.InstallLabel = new System.Windows.Forms.Label();
            this.ChangeGameFolderButton = new System.Windows.Forms.Button();
            this.GpwFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.CreateRegistryKeysButton = new System.Windows.Forms.Button();
            this.RegistryKeysGroupBox = new System.Windows.Forms.GroupBox();
            this.RegistryKeysGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegistryKeyLabel
            // 
            this.RegistryKeyLabel.AutoSize = true;
            this.RegistryKeyLabel.Location = new System.Drawing.Point(6, 16);
            this.RegistryKeyLabel.Name = "RegistryKeyLabel";
            this.RegistryKeyLabel.Size = new System.Drawing.Size(66, 13);
            this.RegistryKeyLabel.TabIndex = 0;
            this.RegistryKeyLabel.Text = "Registry Key";
            // 
            // RegistryKeyLocationTextBox
            // 
            this.RegistryKeyLocationTextBox.Location = new System.Drawing.Point(9, 32);
            this.RegistryKeyLocationTextBox.Name = "RegistryKeyLocationTextBox";
            this.RegistryKeyLocationTextBox.ReadOnly = true;
            this.RegistryKeyLocationTextBox.Size = new System.Drawing.Size(403, 20);
            this.RegistryKeyLocationTextBox.TabIndex = 1;
            this.RegistryKeyLocationTextBox.TabStop = false;
            // 
            // ValidTextBox
            // 
            this.ValidTextBox.Location = new System.Drawing.Point(106, 136);
            this.ValidTextBox.Name = "ValidTextBox";
            this.ValidTextBox.ReadOnly = true;
            this.ValidTextBox.Size = new System.Drawing.Size(306, 20);
            this.ValidTextBox.TabIndex = 10;
            this.ValidTextBox.TabStop = false;
            // 
            // ValidLabel
            // 
            this.ValidLabel.AutoSize = true;
            this.ValidLabel.Location = new System.Drawing.Point(70, 139);
            this.ValidLabel.Name = "ValidLabel";
            this.ValidLabel.Size = new System.Drawing.Size(30, 13);
            this.ValidLabel.TabIndex = 9;
            this.ValidLabel.Text = "Valid";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(106, 110);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(306, 20);
            this.PathTextBox.TabIndex = 8;
            this.PathTextBox.TabStop = false;
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(71, 113);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(29, 13);
            this.PathLabel.TabIndex = 7;
            this.PathLabel.Text = "Path";
            // 
            // LanguageTextBox
            // 
            this.LanguageTextBox.Location = new System.Drawing.Point(106, 84);
            this.LanguageTextBox.Name = "LanguageTextBox";
            this.LanguageTextBox.ReadOnly = true;
            this.LanguageTextBox.Size = new System.Drawing.Size(306, 20);
            this.LanguageTextBox.TabIndex = 6;
            this.LanguageTextBox.TabStop = false;
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.AutoSize = true;
            this.LanguageLabel.Location = new System.Drawing.Point(45, 87);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(55, 13);
            this.LanguageLabel.TabIndex = 5;
            this.LanguageLabel.Text = "Language";
            // 
            // InstallTextBox
            // 
            this.InstallTextBox.Location = new System.Drawing.Point(106, 58);
            this.InstallTextBox.Name = "InstallTextBox";
            this.InstallTextBox.ReadOnly = true;
            this.InstallTextBox.Size = new System.Drawing.Size(306, 20);
            this.InstallTextBox.TabIndex = 4;
            this.InstallTextBox.TabStop = false;
            // 
            // InstallLabel
            // 
            this.InstallLabel.AutoSize = true;
            this.InstallLabel.Location = new System.Drawing.Point(66, 61);
            this.InstallLabel.Name = "InstallLabel";
            this.InstallLabel.Size = new System.Drawing.Size(34, 13);
            this.InstallLabel.TabIndex = 3;
            this.InstallLabel.Text = "Install";
            // 
            // ChangeGameFolderButton
            // 
            this.ChangeGameFolderButton.Location = new System.Drawing.Point(212, 162);
            this.ChangeGameFolderButton.Name = "ChangeGameFolderButton";
            this.ChangeGameFolderButton.Size = new System.Drawing.Size(200, 23);
            this.ChangeGameFolderButton.TabIndex = 12;
            this.ChangeGameFolderButton.Text = "Change path to game folder...";
            this.ChangeGameFolderButton.UseVisualStyleBackColor = true;
            this.ChangeGameFolderButton.Click += new System.EventHandler(this.ChangeGameFolderButton_Click);
            // 
            // GpwFolderBrowserDialog
            // 
            this.GpwFolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // CreateRegistryKeysButton
            // 
            this.CreateRegistryKeysButton.Location = new System.Drawing.Point(6, 162);
            this.CreateRegistryKeysButton.Name = "CreateRegistryKeysButton";
            this.CreateRegistryKeysButton.Size = new System.Drawing.Size(200, 23);
            this.CreateRegistryKeysButton.TabIndex = 11;
            this.CreateRegistryKeysButton.Text = "Create Registry Keys...";
            this.CreateRegistryKeysButton.UseVisualStyleBackColor = true;
            this.CreateRegistryKeysButton.Click += new System.EventHandler(this.CreateRegistryKeysButton_Click);
            // 
            // RegistryKeysGroupBox
            // 
            this.RegistryKeysGroupBox.Controls.Add(this.ValidTextBox);
            this.RegistryKeysGroupBox.Controls.Add(this.RegistryKeyLabel);
            this.RegistryKeysGroupBox.Controls.Add(this.ValidLabel);
            this.RegistryKeysGroupBox.Controls.Add(this.ChangeGameFolderButton);
            this.RegistryKeysGroupBox.Controls.Add(this.PathTextBox);
            this.RegistryKeysGroupBox.Controls.Add(this.RegistryKeyLocationTextBox);
            this.RegistryKeysGroupBox.Controls.Add(this.PathLabel);
            this.RegistryKeysGroupBox.Controls.Add(this.CreateRegistryKeysButton);
            this.RegistryKeysGroupBox.Controls.Add(this.LanguageTextBox);
            this.RegistryKeysGroupBox.Controls.Add(this.LanguageLabel);
            this.RegistryKeysGroupBox.Controls.Add(this.InstallTextBox);
            this.RegistryKeysGroupBox.Controls.Add(this.InstallLabel);
            this.RegistryKeysGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegistryKeysGroupBox.Location = new System.Drawing.Point(3, 3);
            this.RegistryKeysGroupBox.Name = "RegistryKeysGroupBox";
            this.RegistryKeysGroupBox.Size = new System.Drawing.Size(418, 191);
            this.RegistryKeysGroupBox.TabIndex = 14;
            this.RegistryKeysGroupBox.TabStop = false;
            // 
            // RegistryKeysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 197);
            this.Controls.Add(this.RegistryKeysGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RegistryKeysForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.RegistryKeysForm_Load);
            this.RegistryKeysGroupBox.ResumeLayout(false);
            this.RegistryKeysGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label RegistryKeyLabel;
        private System.Windows.Forms.TextBox RegistryKeyLocationTextBox;
        private System.Windows.Forms.Label InstallLabel;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.TextBox InstallTextBox;
        private System.Windows.Forms.TextBox ValidTextBox;
        private System.Windows.Forms.Label ValidLabel;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.TextBox LanguageTextBox;
        private System.Windows.Forms.Button ChangeGameFolderButton;
        private System.Windows.Forms.FolderBrowserDialog GpwFolderBrowserDialog;
        private System.Windows.Forms.Button CreateRegistryKeysButton;
        private System.Windows.Forms.GroupBox RegistryKeysGroupBox;
    }
}