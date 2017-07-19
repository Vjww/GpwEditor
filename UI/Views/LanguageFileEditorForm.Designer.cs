namespace GpwEditor.Views
{
    partial class LanguageFileEditorForm
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
            this.GoToIndexTextBox = new System.Windows.Forms.TextBox();
            this.LanguageDataGridView = new System.Windows.Forms.DataGridView();
            this.resourceTextDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localResourceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.languageStringCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FindTextTextBox = new System.Windows.Forms.TextBox();
            this.QuickNavigationGroupBox = new System.Windows.Forms.GroupBox();
            this.SponsorsCRadioButton = new System.Windows.Forms.RadioButton();
            this.SponsorsBRadioButton = new System.Windows.Forms.RadioButton();
            this.SponsorsARadioButton = new System.Windows.Forms.RadioButton();
            this.TracksTotalMilesRadioButton = new System.Windows.Forms.RadioButton();
            this.TracksLapMilesRadioButton = new System.Windows.Forms.RadioButton();
            this.TracksTotalKmsRadioButton = new System.Windows.Forms.RadioButton();
            this.TracksLapKmsRadioButton = new System.Windows.Forms.RadioButton();
            this.Year1999BRadioButton = new System.Windows.Forms.RadioButton();
            this.Year1999ARadioButton = new System.Windows.Forms.RadioButton();
            this.Year1998GRadioButton = new System.Windows.Forms.RadioButton();
            this.Year1998FRadioButton = new System.Windows.Forms.RadioButton();
            this.Year1998ERadioButton = new System.Windows.Forms.RadioButton();
            this.Year1998DRadioButton = new System.Windows.Forms.RadioButton();
            this.Year1998CRadioButton = new System.Windows.Forms.RadioButton();
            this.Year1998BRadioButton = new System.Windows.Forms.RadioButton();
            this.Year1998ARadioButton = new System.Windows.Forms.RadioButton();
            this.Year1997BRadioButton = new System.Windows.Forms.RadioButton();
            this.Year1997ARadioButton = new System.Windows.Forms.RadioButton();
            this.FrentzenBRadioButton = new System.Windows.Forms.RadioButton();
            this.FrentzenARadioButton = new System.Windows.Forms.RadioButton();
            this.NationalitiesShortRadioButton = new System.Windows.Forms.RadioButton();
            this.NationalitiesFullRadioButton = new System.Windows.Forms.RadioButton();
            this.NonF1StaffRadioButton = new System.Windows.Forms.RadioButton();
            this.F1StaffRadioButton = new System.Windows.Forms.RadioButton();
            this.FuelCodesRadioButton = new System.Windows.Forms.RadioButton();
            this.TyreCodesRadioButton = new System.Windows.Forms.RadioButton();
            this.EngineCodesRadioButton = new System.Windows.Forms.RadioButton();
            this.FuelSuppliersRadioButton = new System.Windows.Forms.RadioButton();
            this.TyreSuppliersRadioButton = new System.Windows.Forms.RadioButton();
            this.EngineSuppliersRadioButton = new System.Windows.Forms.RadioButton();
            this.CashSponsorsRadioButton = new System.Windows.Forms.RadioButton();
            this.TeamSponsorsRadioButton = new System.Windows.Forms.RadioButton();
            this.TeamsResultsRadioButton = new System.Windows.Forms.RadioButton();
            this.TeamsChassisRadioButton = new System.Windows.Forms.RadioButton();
            this.TeamsCodeBRadioButton = new System.Windows.Forms.RadioButton();
            this.TeamsCodeARadioButton = new System.Windows.Forms.RadioButton();
            this.TeamsShortRadioButton = new System.Windows.Forms.RadioButton();
            this.TeamsFullRadioButton = new System.Windows.Forms.RadioButton();
            this.QuickUpdateGroupBox = new System.Windows.Forms.GroupBox();
            this.UpdateTyreCodesButton = new System.Windows.Forms.Button();
            this.UpdateTeamTextButton = new System.Windows.Forms.Button();
            this.UpdateGameYearButton = new System.Windows.Forms.Button();
            this.FindGroupBox = new System.Windows.Forms.GroupBox();
            this.FindTextButton = new System.Windows.Forms.Button();
            this.GoToIndexButton = new System.Windows.Forms.Button();
            this.FindTextLabel = new System.Windows.Forms.Label();
            this.GoToIndexLabel = new System.Windows.Forms.Label();
            this.FilesGroupBox = new System.Windows.Forms.GroupBox();
            this.BrowseGameExecutableButton = new System.Windows.Forms.Button();
            this.BrowseLanguageFileButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.GameExecutablePathLabel = new System.Windows.Forms.Label();
            this.LanguageFilePathLabel = new System.Windows.Forms.Label();
            this.GameExecutablePathTextBox = new System.Windows.Forms.TextBox();
            this.LanguageFilePathTextBox = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LanguageDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.languageStringCollectionBindingSource)).BeginInit();
            this.QuickNavigationGroupBox.SuspendLayout();
            this.QuickUpdateGroupBox.SuspendLayout();
            this.FindGroupBox.SuspendLayout();
            this.FilesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GoToIndexTextBox
            // 
            this.GoToIndexTextBox.Location = new System.Drawing.Point(76, 19);
            this.GoToIndexTextBox.MaxLength = 4;
            this.GoToIndexTextBox.Name = "GoToIndexTextBox";
            this.GoToIndexTextBox.Size = new System.Drawing.Size(157, 20);
            this.GoToIndexTextBox.TabIndex = 5;
            this.GoToIndexTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GoToIndexTextBox_KeyUp);
            // 
            // LanguageDataGridView
            // 
            this.LanguageDataGridView.AutoGenerateColumns = false;
            this.LanguageDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LanguageDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.resourceTextDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.localResourceIdDataGridViewTextBoxColumn,
            this.resourceIdDataGridViewTextBoxColumn});
            this.LanguageDataGridView.DataSource = this.languageStringCollectionBindingSource;
            this.LanguageDataGridView.Location = new System.Drawing.Point(12, 89);
            this.LanguageDataGridView.Name = "LanguageDataGridView";
            this.LanguageDataGridView.Size = new System.Drawing.Size(434, 460);
            this.LanguageDataGridView.StandardTab = true;
            this.LanguageDataGridView.TabIndex = 9;
            // 
            // resourceTextDataGridViewTextBoxColumn
            // 
            this.resourceTextDataGridViewTextBoxColumn.DataPropertyName = "ResourceText";
            this.resourceTextDataGridViewTextBoxColumn.HeaderText = "Text";
            this.resourceTextDataGridViewTextBoxColumn.Name = "resourceTextDataGridViewTextBoxColumn";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // localResourceIdDataGridViewTextBoxColumn
            // 
            this.localResourceIdDataGridViewTextBoxColumn.DataPropertyName = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn.HeaderText = "LocalResourceId";
            this.localResourceIdDataGridViewTextBoxColumn.Name = "localResourceIdDataGridViewTextBoxColumn";
            this.localResourceIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // resourceIdDataGridViewTextBoxColumn
            // 
            this.resourceIdDataGridViewTextBoxColumn.DataPropertyName = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn.HeaderText = "ResourceId";
            this.resourceIdDataGridViewTextBoxColumn.Name = "resourceIdDataGridViewTextBoxColumn";
            this.resourceIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // languageStringCollectionBindingSource
            // 
            this.languageStringCollectionBindingSource.DataSource = typeof(Data.Collections.Language.IdentityCollection);
            // 
            // FindTextTextBox
            // 
            this.FindTextTextBox.Location = new System.Drawing.Point(76, 45);
            this.FindTextTextBox.MaxLength = 256;
            this.FindTextTextBox.Name = "FindTextTextBox";
            this.FindTextTextBox.Size = new System.Drawing.Size(157, 20);
            this.FindTextTextBox.TabIndex = 7;
            this.FindTextTextBox.TabStop = false;
            this.FindTextTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FindTextTextBox_KeyUp);
            // 
            // QuickNavigationGroupBox
            // 
            this.QuickNavigationGroupBox.Controls.Add(this.SponsorsCRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.SponsorsBRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.SponsorsARadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.TracksTotalMilesRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.TracksLapMilesRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.TracksTotalKmsRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.TracksLapKmsRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.Year1999BRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.Year1999ARadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.Year1998GRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.Year1998FRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.Year1998ERadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.Year1998DRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.Year1998CRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.Year1998BRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.Year1998ARadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.Year1997BRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.Year1997ARadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.FrentzenBRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.FrentzenARadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.NationalitiesShortRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.NationalitiesFullRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.NonF1StaffRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.F1StaffRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.FuelCodesRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.TyreCodesRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.EngineCodesRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.FuelSuppliersRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.TyreSuppliersRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.EngineSuppliersRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.CashSponsorsRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.TeamSponsorsRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.TeamsResultsRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.TeamsChassisRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.TeamsCodeBRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.TeamsCodeARadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.TeamsShortRadioButton);
            this.QuickNavigationGroupBox.Controls.Add(this.TeamsFullRadioButton);
            this.QuickNavigationGroupBox.Location = new System.Drawing.Point(452, 89);
            this.QuickNavigationGroupBox.Name = "QuickNavigationGroupBox";
            this.QuickNavigationGroupBox.Size = new System.Drawing.Size(320, 250);
            this.QuickNavigationGroupBox.TabIndex = 0;
            this.QuickNavigationGroupBox.TabStop = false;
            this.QuickNavigationGroupBox.Text = "Quick Navigation";
            this.QuickNavigationGroupBox.Enter += new System.EventHandler(this.QuickNavigationGroupBox_Enter);
            // 
            // SponsorsCRadioButton
            // 
            this.SponsorsCRadioButton.AutoSize = true;
            this.SponsorsCRadioButton.Location = new System.Drawing.Point(120, 211);
            this.SponsorsCRadioButton.Name = "SponsorsCRadioButton";
            this.SponsorsCRadioButton.Size = new System.Drawing.Size(79, 17);
            this.SponsorsCRadioButton.TabIndex = 55;
            this.SponsorsCRadioButton.Tag = "6842";
            this.SponsorsCRadioButton.Text = "Sponsors C";
            this.SponsorsCRadioButton.UseVisualStyleBackColor = true;
            this.SponsorsCRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // SponsorsBRadioButton
            // 
            this.SponsorsBRadioButton.AutoSize = true;
            this.SponsorsBRadioButton.Location = new System.Drawing.Point(120, 195);
            this.SponsorsBRadioButton.Name = "SponsorsBRadioButton";
            this.SponsorsBRadioButton.Size = new System.Drawing.Size(79, 17);
            this.SponsorsBRadioButton.TabIndex = 54;
            this.SponsorsBRadioButton.Tag = "1817";
            this.SponsorsBRadioButton.Text = "Sponsors B";
            this.SponsorsBRadioButton.UseVisualStyleBackColor = true;
            this.SponsorsBRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // SponsorsARadioButton
            // 
            this.SponsorsARadioButton.AutoSize = true;
            this.SponsorsARadioButton.Location = new System.Drawing.Point(120, 179);
            this.SponsorsARadioButton.Name = "SponsorsARadioButton";
            this.SponsorsARadioButton.Size = new System.Drawing.Size(79, 17);
            this.SponsorsARadioButton.TabIndex = 53;
            this.SponsorsARadioButton.Tag = "1548";
            this.SponsorsARadioButton.Text = "Sponsors A";
            this.SponsorsARadioButton.UseVisualStyleBackColor = true;
            this.SponsorsARadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // TracksTotalMilesRadioButton
            // 
            this.TracksTotalMilesRadioButton.AutoSize = true;
            this.TracksTotalMilesRadioButton.Location = new System.Drawing.Point(120, 131);
            this.TracksTotalMilesRadioButton.Name = "TracksTotalMilesRadioButton";
            this.TracksTotalMilesRadioButton.Size = new System.Drawing.Size(118, 17);
            this.TracksTotalMilesRadioButton.TabIndex = 48;
            this.TracksTotalMilesRadioButton.Tag = "5032";
            this.TracksTotalMilesRadioButton.Text = "Tracks - Total Miles";
            this.TracksTotalMilesRadioButton.UseVisualStyleBackColor = true;
            this.TracksTotalMilesRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // TracksLapMilesRadioButton
            // 
            this.TracksLapMilesRadioButton.AutoSize = true;
            this.TracksLapMilesRadioButton.Location = new System.Drawing.Point(120, 115);
            this.TracksLapMilesRadioButton.Name = "TracksLapMilesRadioButton";
            this.TracksLapMilesRadioButton.Size = new System.Drawing.Size(112, 17);
            this.TracksLapMilesRadioButton.TabIndex = 47;
            this.TracksLapMilesRadioButton.Tag = "5000";
            this.TracksLapMilesRadioButton.Text = "Tracks - Lap Miles";
            this.TracksLapMilesRadioButton.UseVisualStyleBackColor = true;
            this.TracksLapMilesRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // TracksTotalKmsRadioButton
            // 
            this.TracksTotalKmsRadioButton.AutoSize = true;
            this.TracksTotalKmsRadioButton.Location = new System.Drawing.Point(120, 99);
            this.TracksTotalKmsRadioButton.Name = "TracksTotalKmsRadioButton";
            this.TracksTotalKmsRadioButton.Size = new System.Drawing.Size(114, 17);
            this.TracksTotalKmsRadioButton.TabIndex = 46;
            this.TracksTotalKmsRadioButton.Tag = "5048";
            this.TracksTotalKmsRadioButton.Text = "Tracks - Total Kms";
            this.TracksTotalKmsRadioButton.UseVisualStyleBackColor = true;
            this.TracksTotalKmsRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // TracksLapKmsRadioButton
            // 
            this.TracksLapKmsRadioButton.AutoSize = true;
            this.TracksLapKmsRadioButton.Location = new System.Drawing.Point(120, 83);
            this.TracksLapKmsRadioButton.Name = "TracksLapKmsRadioButton";
            this.TracksLapKmsRadioButton.Size = new System.Drawing.Size(108, 17);
            this.TracksLapKmsRadioButton.TabIndex = 45;
            this.TracksLapKmsRadioButton.Tag = "5016";
            this.TracksLapKmsRadioButton.Text = "Tracks - Lap Kms";
            this.TracksLapKmsRadioButton.UseVisualStyleBackColor = true;
            this.TracksLapKmsRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // Year1999BRadioButton
            // 
            this.Year1999BRadioButton.AutoSize = true;
            this.Year1999BRadioButton.Location = new System.Drawing.Point(240, 179);
            this.Year1999BRadioButton.Name = "Year1999BRadioButton";
            this.Year1999BRadioButton.Size = new System.Drawing.Size(59, 17);
            this.Year1999BRadioButton.TabIndex = 59;
            this.Year1999BRadioButton.Tag = "3135";
            this.Year1999BRadioButton.Text = "1999 B";
            this.Year1999BRadioButton.UseVisualStyleBackColor = true;
            this.Year1999BRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // Year1999ARadioButton
            // 
            this.Year1999ARadioButton.AutoSize = true;
            this.Year1999ARadioButton.Location = new System.Drawing.Point(240, 163);
            this.Year1999ARadioButton.Name = "Year1999ARadioButton";
            this.Year1999ARadioButton.Size = new System.Drawing.Size(59, 17);
            this.Year1999ARadioButton.TabIndex = 58;
            this.Year1999ARadioButton.Tag = "3131";
            this.Year1999ARadioButton.Text = "1999 A";
            this.Year1999ARadioButton.UseVisualStyleBackColor = true;
            this.Year1999ARadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // Year1998GRadioButton
            // 
            this.Year1998GRadioButton.AutoSize = true;
            this.Year1998GRadioButton.Location = new System.Drawing.Point(240, 147);
            this.Year1998GRadioButton.Name = "Year1998GRadioButton";
            this.Year1998GRadioButton.Size = new System.Drawing.Size(60, 17);
            this.Year1998GRadioButton.TabIndex = 67;
            this.Year1998GRadioButton.Tag = "6344";
            this.Year1998GRadioButton.Text = "1998 G";
            this.Year1998GRadioButton.UseVisualStyleBackColor = true;
            this.Year1998GRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // Year1998FRadioButton
            // 
            this.Year1998FRadioButton.AutoSize = true;
            this.Year1998FRadioButton.Location = new System.Drawing.Point(240, 131);
            this.Year1998FRadioButton.Name = "Year1998FRadioButton";
            this.Year1998FRadioButton.Size = new System.Drawing.Size(58, 17);
            this.Year1998FRadioButton.TabIndex = 66;
            this.Year1998FRadioButton.Tag = "3133";
            this.Year1998FRadioButton.Text = "1998 F";
            this.Year1998FRadioButton.UseVisualStyleBackColor = true;
            this.Year1998FRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // Year1998ERadioButton
            // 
            this.Year1998ERadioButton.AutoSize = true;
            this.Year1998ERadioButton.Location = new System.Drawing.Point(240, 115);
            this.Year1998ERadioButton.Name = "Year1998ERadioButton";
            this.Year1998ERadioButton.Size = new System.Drawing.Size(59, 17);
            this.Year1998ERadioButton.TabIndex = 65;
            this.Year1998ERadioButton.Tag = "3132";
            this.Year1998ERadioButton.Text = "1998 E";
            this.Year1998ERadioButton.UseVisualStyleBackColor = true;
            this.Year1998ERadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // Year1998DRadioButton
            // 
            this.Year1998DRadioButton.AutoSize = true;
            this.Year1998DRadioButton.Location = new System.Drawing.Point(240, 99);
            this.Year1998DRadioButton.Name = "Year1998DRadioButton";
            this.Year1998DRadioButton.Size = new System.Drawing.Size(60, 17);
            this.Year1998DRadioButton.TabIndex = 64;
            this.Year1998DRadioButton.Tag = "3130";
            this.Year1998DRadioButton.Text = "1998 D";
            this.Year1998DRadioButton.UseVisualStyleBackColor = true;
            this.Year1998DRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // Year1998CRadioButton
            // 
            this.Year1998CRadioButton.AutoSize = true;
            this.Year1998CRadioButton.Location = new System.Drawing.Point(240, 83);
            this.Year1998CRadioButton.Name = "Year1998CRadioButton";
            this.Year1998CRadioButton.Size = new System.Drawing.Size(59, 17);
            this.Year1998CRadioButton.TabIndex = 63;
            this.Year1998CRadioButton.Tag = "3119";
            this.Year1998CRadioButton.Text = "1998 C";
            this.Year1998CRadioButton.UseVisualStyleBackColor = true;
            this.Year1998CRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // Year1998BRadioButton
            // 
            this.Year1998BRadioButton.AutoSize = true;
            this.Year1998BRadioButton.Location = new System.Drawing.Point(240, 67);
            this.Year1998BRadioButton.Name = "Year1998BRadioButton";
            this.Year1998BRadioButton.Size = new System.Drawing.Size(59, 17);
            this.Year1998BRadioButton.TabIndex = 62;
            this.Year1998BRadioButton.Tag = "3104";
            this.Year1998BRadioButton.Text = "1998 B";
            this.Year1998BRadioButton.UseVisualStyleBackColor = true;
            this.Year1998BRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // Year1998ARadioButton
            // 
            this.Year1998ARadioButton.AutoSize = true;
            this.Year1998ARadioButton.Location = new System.Drawing.Point(240, 51);
            this.Year1998ARadioButton.Name = "Year1998ARadioButton";
            this.Year1998ARadioButton.Size = new System.Drawing.Size(59, 17);
            this.Year1998ARadioButton.TabIndex = 61;
            this.Year1998ARadioButton.Tag = "1387";
            this.Year1998ARadioButton.Text = "1998 A";
            this.Year1998ARadioButton.UseVisualStyleBackColor = true;
            this.Year1998ARadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // Year1997BRadioButton
            // 
            this.Year1997BRadioButton.AutoSize = true;
            this.Year1997BRadioButton.Location = new System.Drawing.Point(240, 35);
            this.Year1997BRadioButton.Name = "Year1997BRadioButton";
            this.Year1997BRadioButton.Size = new System.Drawing.Size(59, 17);
            this.Year1997BRadioButton.TabIndex = 57;
            this.Year1997BRadioButton.Tag = "3117";
            this.Year1997BRadioButton.Text = "1997 B";
            this.Year1997BRadioButton.UseVisualStyleBackColor = true;
            this.Year1997BRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // Year1997ARadioButton
            // 
            this.Year1997ARadioButton.AutoSize = true;
            this.Year1997ARadioButton.Location = new System.Drawing.Point(240, 19);
            this.Year1997ARadioButton.Name = "Year1997ARadioButton";
            this.Year1997ARadioButton.Size = new System.Drawing.Size(59, 17);
            this.Year1997ARadioButton.TabIndex = 56;
            this.Year1997ARadioButton.Tag = "3116";
            this.Year1997ARadioButton.Text = "1997 A";
            this.Year1997ARadioButton.UseVisualStyleBackColor = true;
            this.Year1997ARadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // FrentzenBRadioButton
            // 
            this.FrentzenBRadioButton.AutoSize = true;
            this.FrentzenBRadioButton.Location = new System.Drawing.Point(120, 163);
            this.FrentzenBRadioButton.Name = "FrentzenBRadioButton";
            this.FrentzenBRadioButton.Size = new System.Drawing.Size(76, 17);
            this.FrentzenBRadioButton.TabIndex = 52;
            this.FrentzenBRadioButton.Tag = "947";
            this.FrentzenBRadioButton.Text = "Frentzen B";
            this.FrentzenBRadioButton.UseVisualStyleBackColor = true;
            this.FrentzenBRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // FrentzenARadioButton
            // 
            this.FrentzenARadioButton.AutoSize = true;
            this.FrentzenARadioButton.Location = new System.Drawing.Point(120, 147);
            this.FrentzenARadioButton.Name = "FrentzenARadioButton";
            this.FrentzenARadioButton.Size = new System.Drawing.Size(76, 17);
            this.FrentzenARadioButton.TabIndex = 51;
            this.FrentzenARadioButton.Tag = "946";
            this.FrentzenARadioButton.Text = "Frentzen A";
            this.FrentzenARadioButton.UseVisualStyleBackColor = true;
            this.FrentzenARadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // NationalitiesShortRadioButton
            // 
            this.NationalitiesShortRadioButton.AutoSize = true;
            this.NationalitiesShortRadioButton.Location = new System.Drawing.Point(120, 67);
            this.NationalitiesShortRadioButton.Name = "NationalitiesShortRadioButton";
            this.NationalitiesShortRadioButton.Size = new System.Drawing.Size(116, 17);
            this.NationalitiesShortRadioButton.TabIndex = 44;
            this.NationalitiesShortRadioButton.Tag = "5937";
            this.NationalitiesShortRadioButton.Text = "Nationalities - Short";
            this.NationalitiesShortRadioButton.UseVisualStyleBackColor = true;
            this.NationalitiesShortRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // NationalitiesFullRadioButton
            // 
            this.NationalitiesFullRadioButton.AutoSize = true;
            this.NationalitiesFullRadioButton.Location = new System.Drawing.Point(120, 51);
            this.NationalitiesFullRadioButton.Name = "NationalitiesFullRadioButton";
            this.NationalitiesFullRadioButton.Size = new System.Drawing.Size(107, 17);
            this.NationalitiesFullRadioButton.TabIndex = 43;
            this.NationalitiesFullRadioButton.Tag = "5953";
            this.NationalitiesFullRadioButton.Text = "Nationalities - Full";
            this.NationalitiesFullRadioButton.UseVisualStyleBackColor = true;
            this.NationalitiesFullRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // NonF1StaffRadioButton
            // 
            this.NonF1StaffRadioButton.AutoSize = true;
            this.NonF1StaffRadioButton.Location = new System.Drawing.Point(120, 35);
            this.NonF1StaffRadioButton.Name = "NonF1StaffRadioButton";
            this.NonF1StaffRadioButton.Size = new System.Drawing.Size(85, 17);
            this.NonF1StaffRadioButton.TabIndex = 42;
            this.NonF1StaffRadioButton.Tag = "5884";
            this.NonF1StaffRadioButton.Text = "Non-F1 Staff";
            this.NonF1StaffRadioButton.UseVisualStyleBackColor = true;
            this.NonF1StaffRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // F1StaffRadioButton
            // 
            this.F1StaffRadioButton.AutoSize = true;
            this.F1StaffRadioButton.Location = new System.Drawing.Point(120, 19);
            this.F1StaffRadioButton.Name = "F1StaffRadioButton";
            this.F1StaffRadioButton.Size = new System.Drawing.Size(62, 17);
            this.F1StaffRadioButton.TabIndex = 41;
            this.F1StaffRadioButton.Tag = "5796";
            this.F1StaffRadioButton.Text = "F1 Staff";
            this.F1StaffRadioButton.UseVisualStyleBackColor = true;
            this.F1StaffRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // FuelCodesRadioButton
            // 
            this.FuelCodesRadioButton.AutoSize = true;
            this.FuelCodesRadioButton.Location = new System.Drawing.Point(9, 227);
            this.FuelCodesRadioButton.Name = "FuelCodesRadioButton";
            this.FuelCodesRadioButton.Size = new System.Drawing.Size(78, 17);
            this.FuelCodesRadioButton.TabIndex = 38;
            this.FuelCodesRadioButton.Tag = "2349";
            this.FuelCodesRadioButton.Text = "Fuel Codes";
            this.FuelCodesRadioButton.UseVisualStyleBackColor = true;
            this.FuelCodesRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // TyreCodesRadioButton
            // 
            this.TyreCodesRadioButton.AutoSize = true;
            this.TyreCodesRadioButton.Location = new System.Drawing.Point(9, 211);
            this.TyreCodesRadioButton.Name = "TyreCodesRadioButton";
            this.TyreCodesRadioButton.Size = new System.Drawing.Size(79, 17);
            this.TyreCodesRadioButton.TabIndex = 37;
            this.TyreCodesRadioButton.Tag = "-1";
            this.TyreCodesRadioButton.Text = "Tyre Codes";
            this.TyreCodesRadioButton.UseVisualStyleBackColor = true;
            this.TyreCodesRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // EngineCodesRadioButton
            // 
            this.EngineCodesRadioButton.AutoSize = true;
            this.EngineCodesRadioButton.Location = new System.Drawing.Point(9, 195);
            this.EngineCodesRadioButton.Name = "EngineCodesRadioButton";
            this.EngineCodesRadioButton.Size = new System.Drawing.Size(91, 17);
            this.EngineCodesRadioButton.TabIndex = 36;
            this.EngineCodesRadioButton.Tag = "2337";
            this.EngineCodesRadioButton.Text = "Engine Codes";
            this.EngineCodesRadioButton.UseVisualStyleBackColor = true;
            this.EngineCodesRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // FuelSuppliersRadioButton
            // 
            this.FuelSuppliersRadioButton.AutoSize = true;
            this.FuelSuppliersRadioButton.Location = new System.Drawing.Point(9, 179);
            this.FuelSuppliersRadioButton.Name = "FuelSuppliersRadioButton";
            this.FuelSuppliersRadioButton.Size = new System.Drawing.Size(91, 17);
            this.FuelSuppliersRadioButton.TabIndex = 35;
            this.FuelSuppliersRadioButton.Tag = "4894";
            this.FuelSuppliersRadioButton.Text = "Fuel Suppliers";
            this.FuelSuppliersRadioButton.UseVisualStyleBackColor = true;
            this.FuelSuppliersRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // TyreSuppliersRadioButton
            // 
            this.TyreSuppliersRadioButton.AutoSize = true;
            this.TyreSuppliersRadioButton.Location = new System.Drawing.Point(9, 163);
            this.TyreSuppliersRadioButton.Name = "TyreSuppliersRadioButton";
            this.TyreSuppliersRadioButton.Size = new System.Drawing.Size(92, 17);
            this.TyreSuppliersRadioButton.TabIndex = 34;
            this.TyreSuppliersRadioButton.Tag = "4883";
            this.TyreSuppliersRadioButton.Text = "Tyre Suppliers";
            this.TyreSuppliersRadioButton.UseVisualStyleBackColor = true;
            this.TyreSuppliersRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // EngineSuppliersRadioButton
            // 
            this.EngineSuppliersRadioButton.AutoSize = true;
            this.EngineSuppliersRadioButton.Location = new System.Drawing.Point(9, 147);
            this.EngineSuppliersRadioButton.Name = "EngineSuppliersRadioButton";
            this.EngineSuppliersRadioButton.Size = new System.Drawing.Size(104, 17);
            this.EngineSuppliersRadioButton.TabIndex = 33;
            this.EngineSuppliersRadioButton.Tag = "4886";
            this.EngineSuppliersRadioButton.Text = "Engine Suppliers";
            this.EngineSuppliersRadioButton.UseVisualStyleBackColor = true;
            this.EngineSuppliersRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // CashSponsorsRadioButton
            // 
            this.CashSponsorsRadioButton.AutoSize = true;
            this.CashSponsorsRadioButton.Location = new System.Drawing.Point(9, 131);
            this.CashSponsorsRadioButton.Name = "CashSponsorsRadioButton";
            this.CashSponsorsRadioButton.Size = new System.Drawing.Size(96, 17);
            this.CashSponsorsRadioButton.TabIndex = 32;
            this.CashSponsorsRadioButton.Tag = "4903";
            this.CashSponsorsRadioButton.Text = "Cash Sponsors";
            this.CashSponsorsRadioButton.UseVisualStyleBackColor = true;
            this.CashSponsorsRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // TeamSponsorsRadioButton
            // 
            this.TeamSponsorsRadioButton.AutoSize = true;
            this.TeamSponsorsRadioButton.Location = new System.Drawing.Point(9, 115);
            this.TeamSponsorsRadioButton.Name = "TeamSponsorsRadioButton";
            this.TeamSponsorsRadioButton.Size = new System.Drawing.Size(99, 17);
            this.TeamSponsorsRadioButton.TabIndex = 31;
            this.TeamSponsorsRadioButton.Tag = "4876";
            this.TeamSponsorsRadioButton.Text = "Team Sponsors";
            this.TeamSponsorsRadioButton.UseVisualStyleBackColor = true;
            this.TeamSponsorsRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // TeamsResultsRadioButton
            // 
            this.TeamsResultsRadioButton.AutoSize = true;
            this.TeamsResultsRadioButton.Location = new System.Drawing.Point(9, 99);
            this.TeamsResultsRadioButton.Name = "TeamsResultsRadioButton";
            this.TeamsResultsRadioButton.Size = new System.Drawing.Size(101, 17);
            this.TeamsResultsRadioButton.TabIndex = 26;
            this.TeamsResultsRadioButton.Tag = "4366";
            this.TeamsResultsRadioButton.Text = "Teams - Results";
            this.TeamsResultsRadioButton.UseVisualStyleBackColor = true;
            this.TeamsResultsRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // TeamsChassisRadioButton
            // 
            this.TeamsChassisRadioButton.AutoSize = true;
            this.TeamsChassisRadioButton.Location = new System.Drawing.Point(9, 83);
            this.TeamsChassisRadioButton.Name = "TeamsChassisRadioButton";
            this.TeamsChassisRadioButton.Size = new System.Drawing.Size(102, 17);
            this.TeamsChassisRadioButton.TabIndex = 25;
            this.TeamsChassisRadioButton.Tag = "5987";
            this.TeamsChassisRadioButton.Text = "Teams - Chassis";
            this.TeamsChassisRadioButton.UseVisualStyleBackColor = true;
            this.TeamsChassisRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // TeamsCodeBRadioButton
            // 
            this.TeamsCodeBRadioButton.AutoSize = true;
            this.TeamsCodeBRadioButton.Location = new System.Drawing.Point(9, 67);
            this.TeamsCodeBRadioButton.Name = "TeamsCodeBRadioButton";
            this.TeamsCodeBRadioButton.Size = new System.Drawing.Size(101, 17);
            this.TeamsCodeBRadioButton.TabIndex = 24;
            this.TeamsCodeBRadioButton.Tag = "6487";
            this.TeamsCodeBRadioButton.Text = "Teams - Code B";
            this.TeamsCodeBRadioButton.UseVisualStyleBackColor = true;
            this.TeamsCodeBRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // TeamsCodeARadioButton
            // 
            this.TeamsCodeARadioButton.AutoSize = true;
            this.TeamsCodeARadioButton.Location = new System.Drawing.Point(9, 51);
            this.TeamsCodeARadioButton.Name = "TeamsCodeARadioButton";
            this.TeamsCodeARadioButton.Size = new System.Drawing.Size(101, 17);
            this.TeamsCodeARadioButton.TabIndex = 23;
            this.TeamsCodeARadioButton.Tag = "5709";
            this.TeamsCodeARadioButton.Text = "Teams - Code A";
            this.TeamsCodeARadioButton.UseVisualStyleBackColor = true;
            this.TeamsCodeARadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // TeamsShortRadioButton
            // 
            this.TeamsShortRadioButton.AutoSize = true;
            this.TeamsShortRadioButton.Location = new System.Drawing.Point(9, 35);
            this.TeamsShortRadioButton.Name = "TeamsShortRadioButton";
            this.TeamsShortRadioButton.Size = new System.Drawing.Size(91, 17);
            this.TeamsShortRadioButton.TabIndex = 22;
            this.TeamsShortRadioButton.Tag = "6458";
            this.TeamsShortRadioButton.Text = "Teams - Short";
            this.TeamsShortRadioButton.UseVisualStyleBackColor = true;
            this.TeamsShortRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // TeamsFullRadioButton
            // 
            this.TeamsFullRadioButton.AutoSize = true;
            this.TeamsFullRadioButton.Location = new System.Drawing.Point(9, 19);
            this.TeamsFullRadioButton.Name = "TeamsFullRadioButton";
            this.TeamsFullRadioButton.Size = new System.Drawing.Size(82, 17);
            this.TeamsFullRadioButton.TabIndex = 21;
            this.TeamsFullRadioButton.Tag = "5697";
            this.TeamsFullRadioButton.Text = "Teams - Full";
            this.TeamsFullRadioButton.UseVisualStyleBackColor = true;
            this.TeamsFullRadioButton.CheckedChanged += new System.EventHandler(this.QuickNavigationRadioButton_CheckedChanged);
            // 
            // QuickUpdateGroupBox
            // 
            this.QuickUpdateGroupBox.Controls.Add(this.UpdateTyreCodesButton);
            this.QuickUpdateGroupBox.Controls.Add(this.UpdateTeamTextButton);
            this.QuickUpdateGroupBox.Controls.Add(this.UpdateGameYearButton);
            this.QuickUpdateGroupBox.Location = new System.Drawing.Point(452, 345);
            this.QuickUpdateGroupBox.Name = "QuickUpdateGroupBox";
            this.QuickUpdateGroupBox.Size = new System.Drawing.Size(320, 175);
            this.QuickUpdateGroupBox.TabIndex = 0;
            this.QuickUpdateGroupBox.TabStop = false;
            this.QuickUpdateGroupBox.Text = "Quick Update";
            // 
            // UpdateTyreCodesButton
            // 
            this.UpdateTyreCodesButton.Enabled = false;
            this.UpdateTyreCodesButton.Location = new System.Drawing.Point(6, 48);
            this.UpdateTyreCodesButton.Name = "UpdateTyreCodesButton";
            this.UpdateTyreCodesButton.Size = new System.Drawing.Size(308, 23);
            this.UpdateTyreCodesButton.TabIndex = 14;
            this.UpdateTyreCodesButton.Text = "Generate tyre codes from tyre supplier names...";
            this.UpdateTyreCodesButton.UseVisualStyleBackColor = true;
            this.UpdateTyreCodesButton.Click += new System.EventHandler(this.UpdateTyreCodesButton_Click);
            // 
            // UpdateTeamTextButton
            // 
            this.UpdateTeamTextButton.Location = new System.Drawing.Point(6, 19);
            this.UpdateTeamTextButton.Name = "UpdateTeamTextButton";
            this.UpdateTeamTextButton.Size = new System.Drawing.Size(308, 23);
            this.UpdateTeamTextButton.TabIndex = 13;
            this.UpdateTeamTextButton.Text = "Generate short names/codes from team names...";
            this.UpdateTeamTextButton.UseVisualStyleBackColor = true;
            this.UpdateTeamTextButton.Click += new System.EventHandler(this.UpdateTeamTextButton_Click);
            // 
            // UpdateGameYearButton
            // 
            this.UpdateGameYearButton.Enabled = false;
            this.UpdateGameYearButton.Location = new System.Drawing.Point(6, 77);
            this.UpdateGameYearButton.Name = "UpdateGameYearButton";
            this.UpdateGameYearButton.Size = new System.Drawing.Size(308, 23);
            this.UpdateGameYearButton.TabIndex = 15;
            this.UpdateGameYearButton.Text = "Update game year...";
            this.UpdateGameYearButton.UseVisualStyleBackColor = true;
            this.UpdateGameYearButton.Click += new System.EventHandler(this.UpdateGameYearButton_Click);
            // 
            // FindGroupBox
            // 
            this.FindGroupBox.Controls.Add(this.FindTextButton);
            this.FindGroupBox.Controls.Add(this.GoToIndexButton);
            this.FindGroupBox.Controls.Add(this.FindTextLabel);
            this.FindGroupBox.Controls.Add(this.GoToIndexLabel);
            this.FindGroupBox.Controls.Add(this.GoToIndexTextBox);
            this.FindGroupBox.Controls.Add(this.FindTextTextBox);
            this.FindGroupBox.Location = new System.Drawing.Point(452, 12);
            this.FindGroupBox.Name = "FindGroupBox";
            this.FindGroupBox.Size = new System.Drawing.Size(320, 71);
            this.FindGroupBox.TabIndex = 0;
            this.FindGroupBox.TabStop = false;
            this.FindGroupBox.Text = "Find";
            // 
            // FindTextButton
            // 
            this.FindTextButton.Location = new System.Drawing.Point(239, 43);
            this.FindTextButton.Name = "FindTextButton";
            this.FindTextButton.Size = new System.Drawing.Size(75, 23);
            this.FindTextButton.TabIndex = 8;
            this.FindTextButton.Text = "Find";
            this.FindTextButton.UseVisualStyleBackColor = true;
            this.FindTextButton.Click += new System.EventHandler(this.FindTextButton_Click);
            // 
            // GoToIndexButton
            // 
            this.GoToIndexButton.Location = new System.Drawing.Point(239, 17);
            this.GoToIndexButton.Name = "GoToIndexButton";
            this.GoToIndexButton.Size = new System.Drawing.Size(75, 23);
            this.GoToIndexButton.TabIndex = 6;
            this.GoToIndexButton.Text = "Go to";
            this.GoToIndexButton.UseVisualStyleBackColor = true;
            this.GoToIndexButton.Click += new System.EventHandler(this.GoToIndexButton_Click);
            // 
            // FindTextLabel
            // 
            this.FindTextLabel.AutoSize = true;
            this.FindTextLabel.Location = new System.Drawing.Point(20, 48);
            this.FindTextLabel.Name = "FindTextLabel";
            this.FindTextLabel.Size = new System.Drawing.Size(50, 13);
            this.FindTextLabel.TabIndex = 0;
            this.FindTextLabel.Text = "Find text:";
            // 
            // GoToIndexLabel
            // 
            this.GoToIndexLabel.AutoSize = true;
            this.GoToIndexLabel.Location = new System.Drawing.Point(6, 22);
            this.GoToIndexLabel.Name = "GoToIndexLabel";
            this.GoToIndexLabel.Size = new System.Drawing.Size(64, 13);
            this.GoToIndexLabel.TabIndex = 0;
            this.GoToIndexLabel.Text = "Go to index:";
            // 
            // FilesGroupBox
            // 
            this.FilesGroupBox.Controls.Add(this.BrowseGameExecutableButton);
            this.FilesGroupBox.Controls.Add(this.BrowseLanguageFileButton);
            this.FilesGroupBox.Controls.Add(this.ExportButton);
            this.FilesGroupBox.Controls.Add(this.ImportButton);
            this.FilesGroupBox.Controls.Add(this.GameExecutablePathLabel);
            this.FilesGroupBox.Controls.Add(this.LanguageFilePathLabel);
            this.FilesGroupBox.Controls.Add(this.GameExecutablePathTextBox);
            this.FilesGroupBox.Controls.Add(this.LanguageFilePathTextBox);
            this.FilesGroupBox.Location = new System.Drawing.Point(12, 12);
            this.FilesGroupBox.Name = "FilesGroupBox";
            this.FilesGroupBox.Size = new System.Drawing.Size(434, 71);
            this.FilesGroupBox.TabIndex = 0;
            this.FilesGroupBox.TabStop = false;
            this.FilesGroupBox.Text = "Source/Target Files";
            // 
            // BrowseGameExecutableButton
            // 
            this.BrowseGameExecutableButton.Location = new System.Drawing.Point(272, 43);
            this.BrowseGameExecutableButton.Name = "BrowseGameExecutableButton";
            this.BrowseGameExecutableButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseGameExecutableButton.TabIndex = 2;
            this.BrowseGameExecutableButton.Text = "Browse...";
            this.BrowseGameExecutableButton.UseVisualStyleBackColor = true;
            this.BrowseGameExecutableButton.Click += new System.EventHandler(this.BrowseGameExecutableButton_Click);
            // 
            // BrowseLanguageFileButton
            // 
            this.BrowseLanguageFileButton.Location = new System.Drawing.Point(272, 17);
            this.BrowseLanguageFileButton.Name = "BrowseLanguageFileButton";
            this.BrowseLanguageFileButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseLanguageFileButton.TabIndex = 1;
            this.BrowseLanguageFileButton.Text = "Browse...";
            this.BrowseLanguageFileButton.UseVisualStyleBackColor = true;
            this.BrowseLanguageFileButton.Click += new System.EventHandler(this.BrowseLanguageFileButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(353, 43);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 23);
            this.ExportButton.TabIndex = 4;
            this.ExportButton.Text = "Export...";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(353, 17);
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
            this.GameExecutablePathTextBox.Size = new System.Drawing.Size(160, 20);
            this.GameExecutablePathTextBox.TabIndex = 0;
            this.GameExecutablePathTextBox.TabStop = false;
            // 
            // LanguageFilePathTextBox
            // 
            this.LanguageFilePathTextBox.Location = new System.Drawing.Point(106, 19);
            this.LanguageFilePathTextBox.Name = "LanguageFilePathTextBox";
            this.LanguageFilePathTextBox.ReadOnly = true;
            this.LanguageFilePathTextBox.Size = new System.Drawing.Size(160, 20);
            this.LanguageFilePathTextBox.TabIndex = 0;
            this.LanguageFilePathTextBox.TabStop = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(697, 526);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 16;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // LanguageFileEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.FilesGroupBox);
            this.Controls.Add(this.FindGroupBox);
            this.Controls.Add(this.QuickUpdateGroupBox);
            this.Controls.Add(this.QuickNavigationGroupBox);
            this.Controls.Add(this.LanguageDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LanguageFileEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LanguageFileEditorForm_FormClosing);
            this.Load += new System.EventHandler(this.LanguageFileEditorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LanguageDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.languageStringCollectionBindingSource)).EndInit();
            this.QuickNavigationGroupBox.ResumeLayout(false);
            this.QuickNavigationGroupBox.PerformLayout();
            this.QuickUpdateGroupBox.ResumeLayout(false);
            this.FindGroupBox.ResumeLayout(false);
            this.FindGroupBox.PerformLayout();
            this.FilesGroupBox.ResumeLayout(false);
            this.FilesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox FilesGroupBox;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Label LanguageFilePathLabel;
        private System.Windows.Forms.TextBox LanguageFilePathTextBox;
        private System.Windows.Forms.Button BrowseLanguageFileButton;
        private System.Windows.Forms.Label GameExecutablePathLabel;
        private System.Windows.Forms.TextBox GameExecutablePathTextBox;
        private System.Windows.Forms.Button BrowseGameExecutableButton;
        private System.Windows.Forms.DataGridView LanguageDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localResourceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceTextDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource languageStringCollectionBindingSource;
        private System.Windows.Forms.GroupBox FindGroupBox;
        private System.Windows.Forms.Label GoToIndexLabel;
        private System.Windows.Forms.TextBox GoToIndexTextBox;
        private System.Windows.Forms.Button GoToIndexButton;
        private System.Windows.Forms.Label FindTextLabel;
        private System.Windows.Forms.TextBox FindTextTextBox;
        private System.Windows.Forms.Button FindTextButton;
        private System.Windows.Forms.GroupBox QuickNavigationGroupBox;
        private System.Windows.Forms.RadioButton TeamsFullRadioButton;
        private System.Windows.Forms.RadioButton TeamsShortRadioButton;
        private System.Windows.Forms.RadioButton TeamsCodeARadioButton;
        private System.Windows.Forms.RadioButton TeamsCodeBRadioButton;
        private System.Windows.Forms.RadioButton TeamsChassisRadioButton;
        private System.Windows.Forms.RadioButton TeamsResultsRadioButton;
        private System.Windows.Forms.RadioButton TeamSponsorsRadioButton;
        private System.Windows.Forms.RadioButton CashSponsorsRadioButton;
        private System.Windows.Forms.RadioButton EngineSuppliersRadioButton;
        private System.Windows.Forms.RadioButton TyreSuppliersRadioButton;
        private System.Windows.Forms.RadioButton FuelSuppliersRadioButton;
        private System.Windows.Forms.RadioButton EngineCodesRadioButton;
        private System.Windows.Forms.RadioButton TyreCodesRadioButton;
        private System.Windows.Forms.RadioButton FuelCodesRadioButton;
        private System.Windows.Forms.RadioButton F1StaffRadioButton;
        private System.Windows.Forms.RadioButton NonF1StaffRadioButton;
        private System.Windows.Forms.RadioButton NationalitiesFullRadioButton;
        private System.Windows.Forms.RadioButton NationalitiesShortRadioButton;
        private System.Windows.Forms.RadioButton TracksLapKmsRadioButton;
        private System.Windows.Forms.RadioButton TracksTotalKmsRadioButton;
        private System.Windows.Forms.RadioButton TracksLapMilesRadioButton;
        private System.Windows.Forms.RadioButton TracksTotalMilesRadioButton;
        private System.Windows.Forms.RadioButton FrentzenARadioButton;
        private System.Windows.Forms.RadioButton FrentzenBRadioButton;
        private System.Windows.Forms.RadioButton SponsorsARadioButton;
        private System.Windows.Forms.RadioButton SponsorsBRadioButton;
        private System.Windows.Forms.RadioButton SponsorsCRadioButton;
        private System.Windows.Forms.RadioButton Year1997ARadioButton;
        private System.Windows.Forms.RadioButton Year1997BRadioButton;
        private System.Windows.Forms.RadioButton Year1998ARadioButton;
        private System.Windows.Forms.RadioButton Year1998BRadioButton;
        private System.Windows.Forms.RadioButton Year1998CRadioButton;
        private System.Windows.Forms.RadioButton Year1998DRadioButton;
        private System.Windows.Forms.RadioButton Year1998ERadioButton;
        private System.Windows.Forms.RadioButton Year1998FRadioButton;
        private System.Windows.Forms.RadioButton Year1998GRadioButton;
        private System.Windows.Forms.RadioButton Year1999ARadioButton;
        private System.Windows.Forms.RadioButton Year1999BRadioButton;
        private System.Windows.Forms.GroupBox QuickUpdateGroupBox;
        private System.Windows.Forms.Button UpdateTeamTextButton;
        private System.Windows.Forms.Button UpdateTyreCodesButton;
        private System.Windows.Forms.Button UpdateGameYearButton;
        private System.Windows.Forms.Button CloseButton;
    }
}
