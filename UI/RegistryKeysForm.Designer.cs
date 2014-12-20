namespace UI
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
            this.RegistryKeyLocationLabel = new System.Windows.Forms.Label();
            this.RegistryKeyLocationTextBox = new System.Windows.Forms.TextBox();
            this.CurrentRegistryKeyValuesGroupBox = new System.Windows.Forms.GroupBox();
            this.ValidTextBox = new System.Windows.Forms.TextBox();
            this.ValidLabel = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.PathLabel = new System.Windows.Forms.Label();
            this.LanguageTextBox = new System.Windows.Forms.TextBox();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.InstallTextBox = new System.Windows.Forms.TextBox();
            this.InstallLabel = new System.Windows.Forms.Label();
            this.ChangeGameFolderButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.GpwFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.CreateRegistryKeysButton = new System.Windows.Forms.Button();
            this.CurrentRegistryKeyValuesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegistryKeyLocationLabel
            // 
            this.RegistryKeyLocationLabel.AutoSize = true;
            this.RegistryKeyLocationLabel.Location = new System.Drawing.Point(12, 9);
            this.RegistryKeyLocationLabel.Name = "RegistryKeyLocationLabel";
            this.RegistryKeyLocationLabel.Size = new System.Drawing.Size(105, 13);
            this.RegistryKeyLocationLabel.TabIndex = 0;
            this.RegistryKeyLocationLabel.Text = "Registry key location";
            // 
            // RegistryKeyLocationTextBox
            // 
            this.RegistryKeyLocationTextBox.Location = new System.Drawing.Point(15, 25);
            this.RegistryKeyLocationTextBox.Name = "RegistryKeyLocationTextBox";
            this.RegistryKeyLocationTextBox.ReadOnly = true;
            this.RegistryKeyLocationTextBox.Size = new System.Drawing.Size(448, 20);
            this.RegistryKeyLocationTextBox.TabIndex = 1;
            this.RegistryKeyLocationTextBox.TabStop = false;
            // 
            // CurrentRegistryKeyValuesGroupBox
            // 
            this.CurrentRegistryKeyValuesGroupBox.Controls.Add(this.ValidTextBox);
            this.CurrentRegistryKeyValuesGroupBox.Controls.Add(this.ValidLabel);
            this.CurrentRegistryKeyValuesGroupBox.Controls.Add(this.PathTextBox);
            this.CurrentRegistryKeyValuesGroupBox.Controls.Add(this.PathLabel);
            this.CurrentRegistryKeyValuesGroupBox.Controls.Add(this.LanguageTextBox);
            this.CurrentRegistryKeyValuesGroupBox.Controls.Add(this.LanguageLabel);
            this.CurrentRegistryKeyValuesGroupBox.Controls.Add(this.InstallTextBox);
            this.CurrentRegistryKeyValuesGroupBox.Controls.Add(this.InstallLabel);
            this.CurrentRegistryKeyValuesGroupBox.Location = new System.Drawing.Point(15, 51);
            this.CurrentRegistryKeyValuesGroupBox.Name = "CurrentRegistryKeyValuesGroupBox";
            this.CurrentRegistryKeyValuesGroupBox.Size = new System.Drawing.Size(448, 130);
            this.CurrentRegistryKeyValuesGroupBox.TabIndex = 2;
            this.CurrentRegistryKeyValuesGroupBox.TabStop = false;
            this.CurrentRegistryKeyValuesGroupBox.Text = "Current registry key values";
            // 
            // ValidTextBox
            // 
            this.ValidTextBox.Location = new System.Drawing.Point(67, 97);
            this.ValidTextBox.Name = "ValidTextBox";
            this.ValidTextBox.ReadOnly = true;
            this.ValidTextBox.Size = new System.Drawing.Size(375, 20);
            this.ValidTextBox.TabIndex = 10;
            this.ValidTextBox.TabStop = false;
            // 
            // ValidLabel
            // 
            this.ValidLabel.AutoSize = true;
            this.ValidLabel.Location = new System.Drawing.Point(31, 100);
            this.ValidLabel.Name = "ValidLabel";
            this.ValidLabel.Size = new System.Drawing.Size(30, 13);
            this.ValidLabel.TabIndex = 9;
            this.ValidLabel.Text = "Valid";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(67, 71);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(375, 20);
            this.PathTextBox.TabIndex = 8;
            this.PathTextBox.TabStop = false;
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(32, 74);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(29, 13);
            this.PathLabel.TabIndex = 7;
            this.PathLabel.Text = "Path";
            // 
            // LanguageTextBox
            // 
            this.LanguageTextBox.Location = new System.Drawing.Point(67, 45);
            this.LanguageTextBox.Name = "LanguageTextBox";
            this.LanguageTextBox.ReadOnly = true;
            this.LanguageTextBox.Size = new System.Drawing.Size(375, 20);
            this.LanguageTextBox.TabIndex = 6;
            this.LanguageTextBox.TabStop = false;
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.AutoSize = true;
            this.LanguageLabel.Location = new System.Drawing.Point(6, 48);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(55, 13);
            this.LanguageLabel.TabIndex = 5;
            this.LanguageLabel.Text = "Language";
            // 
            // InstallTextBox
            // 
            this.InstallTextBox.Location = new System.Drawing.Point(67, 19);
            this.InstallTextBox.Name = "InstallTextBox";
            this.InstallTextBox.ReadOnly = true;
            this.InstallTextBox.Size = new System.Drawing.Size(375, 20);
            this.InstallTextBox.TabIndex = 4;
            this.InstallTextBox.TabStop = false;
            // 
            // InstallLabel
            // 
            this.InstallLabel.AutoSize = true;
            this.InstallLabel.Location = new System.Drawing.Point(27, 22);
            this.InstallLabel.Name = "InstallLabel";
            this.InstallLabel.Size = new System.Drawing.Size(34, 13);
            this.InstallLabel.TabIndex = 3;
            this.InstallLabel.Text = "Install";
            // 
            // ChangeGameFolderButton
            // 
            this.ChangeGameFolderButton.Location = new System.Drawing.Point(171, 187);
            this.ChangeGameFolderButton.Name = "ChangeGameFolderButton";
            this.ChangeGameFolderButton.Size = new System.Drawing.Size(210, 23);
            this.ChangeGameFolderButton.TabIndex = 12;
            this.ChangeGameFolderButton.Text = "Change path to game folder...";
            this.ChangeGameFolderButton.UseVisualStyleBackColor = true;
            this.ChangeGameFolderButton.Click += new System.EventHandler(this.ChangeGameFolderButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(387, 187);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 13;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // GpwFolderBrowserDialog
            // 
            this.GpwFolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // CreateRegistryKeysButton
            // 
            this.CreateRegistryKeysButton.Location = new System.Drawing.Point(15, 187);
            this.CreateRegistryKeysButton.Name = "CreateRegistryKeysButton";
            this.CreateRegistryKeysButton.Size = new System.Drawing.Size(150, 23);
            this.CreateRegistryKeysButton.TabIndex = 11;
            this.CreateRegistryKeysButton.Text = "Create Registry Keys...";
            this.CreateRegistryKeysButton.UseVisualStyleBackColor = true;
            this.CreateRegistryKeysButton.Click += new System.EventHandler(this.CreateRegistryKeysButton_Click);
            // 
            // RegistryKeysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 218);
            this.Controls.Add(this.ChangeGameFolderButton);
            this.Controls.Add(this.CreateRegistryKeysButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.CurrentRegistryKeyValuesGroupBox);
            this.Controls.Add(this.RegistryKeyLocationTextBox);
            this.Controls.Add(this.RegistryKeyLocationLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RegistryKeysForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grand Prix World Registry Keys";
            this.Load += new System.EventHandler(this.RegistryKeysForm_Load);
            this.CurrentRegistryKeyValuesGroupBox.ResumeLayout(false);
            this.CurrentRegistryKeyValuesGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RegistryKeyLocationLabel;
        private System.Windows.Forms.TextBox RegistryKeyLocationTextBox;
        private System.Windows.Forms.GroupBox CurrentRegistryKeyValuesGroupBox;
        private System.Windows.Forms.Label InstallLabel;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.TextBox InstallTextBox;
        private System.Windows.Forms.TextBox ValidTextBox;
        private System.Windows.Forms.Label ValidLabel;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.TextBox LanguageTextBox;
        private System.Windows.Forms.Button ChangeGameFolderButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.FolderBrowserDialog GpwFolderBrowserDialog;
        private System.Windows.Forms.Button CreateRegistryKeysButton;
    }
}