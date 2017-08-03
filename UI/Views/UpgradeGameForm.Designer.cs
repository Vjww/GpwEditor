namespace GpwEditor.Views
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpgradeGameForm));
            this.FilesGroupBox = new System.Windows.Forms.GroupBox();
            this.GameFolderPathLabel = new System.Windows.Forms.Label();
            this.GameFolderPathTextBox = new System.Windows.Forms.TextBox();
            this.BrowseGameFolderButton = new System.Windows.Forms.Button();
            this.UpgradeButton = new System.Windows.Forms.Button();
            this.OverviewGroupBox = new System.Windows.Forms.GroupBox();
            this.OverviewRichTextBox = new System.Windows.Forms.RichTextBox();
            this.UpgradeTabControl = new System.Windows.Forms.TabControl();
            this.HomeTabPage = new System.Windows.Forms.TabPage();
            this.FilesGroupBox.SuspendLayout();
            this.OverviewGroupBox.SuspendLayout();
            this.UpgradeTabControl.SuspendLayout();
            this.HomeTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilesGroupBox
            // 
            this.FilesGroupBox.Controls.Add(this.GameFolderPathLabel);
            this.FilesGroupBox.Controls.Add(this.GameFolderPathTextBox);
            this.FilesGroupBox.Controls.Add(this.BrowseGameFolderButton);
            this.FilesGroupBox.Controls.Add(this.UpgradeButton);
            this.FilesGroupBox.Location = new System.Drawing.Point(6, 6);
            this.FilesGroupBox.Name = "FilesGroupBox";
            this.FilesGroupBox.Size = new System.Drawing.Size(918, 48);
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
            this.GameFolderPathLabel.TabIndex = 14;
            this.GameFolderPathLabel.Text = "Game Folder:";
            // 
            // GameFolderPathTextBox
            // 
            this.GameFolderPathTextBox.Location = new System.Drawing.Point(106, 21);
            this.GameFolderPathTextBox.Name = "GameFolderPathTextBox";
            this.GameFolderPathTextBox.ReadOnly = true;
            this.GameFolderPathTextBox.Size = new System.Drawing.Size(644, 20);
            this.GameFolderPathTextBox.TabIndex = 17;
            this.GameFolderPathTextBox.TabStop = false;
            // 
            // BrowseGameFolderButton
            // 
            this.BrowseGameFolderButton.Location = new System.Drawing.Point(756, 19);
            this.BrowseGameFolderButton.Name = "BrowseGameFolderButton";
            this.BrowseGameFolderButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseGameFolderButton.TabIndex = 21;
            this.BrowseGameFolderButton.Text = "Browse...";
            this.BrowseGameFolderButton.UseVisualStyleBackColor = true;
            this.BrowseGameFolderButton.Click += new System.EventHandler(this.BrowseGameFolderButton_Click);
            // 
            // UpgradeButton
            // 
            this.UpgradeButton.Location = new System.Drawing.Point(837, 19);
            this.UpgradeButton.Name = "UpgradeButton";
            this.UpgradeButton.Size = new System.Drawing.Size(75, 23);
            this.UpgradeButton.TabIndex = 3;
            this.UpgradeButton.Text = "Upgrade";
            this.UpgradeButton.UseVisualStyleBackColor = true;
            this.UpgradeButton.Click += new System.EventHandler(this.UpgradeButton_Click);
            // 
            // OverviewGroupBox
            // 
            this.OverviewGroupBox.Controls.Add(this.OverviewRichTextBox);
            this.OverviewGroupBox.Location = new System.Drawing.Point(6, 60);
            this.OverviewGroupBox.Name = "OverviewGroupBox";
            this.OverviewGroupBox.Size = new System.Drawing.Size(918, 463);
            this.OverviewGroupBox.TabIndex = 3;
            this.OverviewGroupBox.TabStop = false;
            // 
            // OverviewRichTextBox
            // 
            this.OverviewRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.OverviewRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OverviewRichTextBox.Location = new System.Drawing.Point(6, 19);
            this.OverviewRichTextBox.Name = "OverviewRichTextBox";
            this.OverviewRichTextBox.ReadOnly = true;
            this.OverviewRichTextBox.Size = new System.Drawing.Size(906, 438);
            this.OverviewRichTextBox.TabIndex = 2;
            this.OverviewRichTextBox.Text = resources.GetString("OverviewRichTextBox.Text");
            // 
            // UpgradeTabControl
            // 
            this.UpgradeTabControl.Controls.Add(this.HomeTabPage);
            this.UpgradeTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpgradeTabControl.Location = new System.Drawing.Point(3, 3);
            this.UpgradeTabControl.Name = "UpgradeTabControl";
            this.UpgradeTabControl.SelectedIndex = 0;
            this.UpgradeTabControl.Size = new System.Drawing.Size(938, 555);
            this.UpgradeTabControl.TabIndex = 0;
            // 
            // HomeTabPage
            // 
            this.HomeTabPage.Controls.Add(this.FilesGroupBox);
            this.HomeTabPage.Controls.Add(this.OverviewGroupBox);
            this.HomeTabPage.Location = new System.Drawing.Point(4, 22);
            this.HomeTabPage.Name = "HomeTabPage";
            this.HomeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HomeTabPage.Size = new System.Drawing.Size(930, 529);
            this.HomeTabPage.TabIndex = 0;
            this.HomeTabPage.Text = "Home";
            this.HomeTabPage.UseVisualStyleBackColor = true;
            // 
            // UpgradeGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 561);
            this.Controls.Add(this.UpgradeTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UpgradeGameForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpgradeGameForm_FormClosing);
            this.Load += new System.EventHandler(this.UpgradeGameForm_Load);
            this.FilesGroupBox.ResumeLayout(false);
            this.FilesGroupBox.PerformLayout();
            this.OverviewGroupBox.ResumeLayout(false);
            this.UpgradeTabControl.ResumeLayout(false);
            this.HomeTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox FilesGroupBox;
        private System.Windows.Forms.Button UpgradeButton;
        private System.Windows.Forms.GroupBox OverviewGroupBox;
        private System.Windows.Forms.RichTextBox OverviewRichTextBox;
        private System.Windows.Forms.Label GameFolderPathLabel;
        private System.Windows.Forms.TextBox GameFolderPathTextBox;
        private System.Windows.Forms.Button BrowseGameFolderButton;
        private System.Windows.Forms.TabControl UpgradeTabControl;
        private System.Windows.Forms.TabPage HomeTabPage;
    }
}