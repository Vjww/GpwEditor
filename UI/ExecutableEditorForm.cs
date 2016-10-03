using System;
using System.IO;
using System.Windows.Forms;
using Core.Collections;
using Core.Collections.Executable.Supplier;
using Core.Collections.Executable.Team;
using Core.Collections.Executable.Track;
using Core.Extensions;
using Data.Database.Executable;
using GpwEditor.Properties;

namespace GpwEditor
{
    /// <summary>
    /// Enables the user to modify data and logic in the game executable.
    /// Multiple controls appear on multiple tabs via a tab control.
    /// 
    /// Tip: Use Document Outline in design mode (View menu > Document Outline)
    /// to order controls within their containers. Move controls towards the
    /// top of the container to display them in front of other controls.
    /// </summary>
    public partial class ExecutableEditorForm : Form
    {
        private bool _isModified;

        public ExecutableEditorForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set icon
            Icon = Resources.icon1;

            // Set form title text
            Text = string.Format(Text, Settings.Default.ApplicationName) + " - Game Editor";

            // Retreive default paths
            var defaultExecutableFilePath = Path.Combine(Settings.Default.UserGameFolderPath,
                Settings.Default.DefaultExecutableFileName);
            var defaultLanguageFilePath = Path.Combine(Settings.Default.UserGameFolderPath,
                Settings.Default.DefaultLanguageFileName);

            // Set default or last used import and export paths
            ImportExecutableFileTextBox.Text = string.IsNullOrWhiteSpace(Settings.Default.ImportExecutableFilePath)
                ? defaultExecutableFilePath
                : Settings.Default.ImportExecutableFilePath;
            ImportLanguageFileTextBox.Text = string.IsNullOrWhiteSpace(Settings.Default.ImportLanguageFilePath)
                ? defaultLanguageFilePath
                : Settings.Default.ImportLanguageFilePath;
            ExportExecutableFileTextBox.Text = string.IsNullOrWhiteSpace(Settings.Default.ExportExecutableFilePath)
                ? defaultExecutableFilePath
                : Settings.Default.ExportExecutableFilePath;
            ExportLanguageFileTextBox.Text = string.IsNullOrWhiteSpace(Settings.Default.ExportLanguageFilePath)
                ? defaultLanguageFilePath
                : Settings.Default.ExportLanguageFilePath;

            FormatControls();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmCloseFormWithUnsavedChanges())
            {
                // Abort event
                e.Cancel = true;
                return;
            }

            // Save and close form
            Settings.Default.Save();
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // On switching tabs, assume user has made modifications to the data
            _isModified = true;
        }

        private void ImportLanguageFileButton_Click(object sender, EventArgs e)
        {
            // Show dialog
            // Update textbox

            //// Prompt user to select file
            //ProgramOpenFileDialog.InitialDirectory = Settings.Default.DefaultGameFolderPath;
            //ProgramOpenFileDialog.FileName = null;
            //var result = ProgramOpenFileDialog.ShowDialog();

            //// Cancel if file was not selected
            //if (result != DialogResult.OK)
            //    return;

            //var filePath = Path.GetDirectoryName(ProgramOpenFileDialog.FileName);
            //var selectedGpwExecutableFilePath = ProgramOpenFileDialog.FileName;
            //var selectedGpwLanguageFilePath = ProgramOpenFileDialog.FileName;
        }

        private void ImportExecutableFileButton_Click(object sender, EventArgs e)
        {
            // Show dialog
            // Update textbox
        }

        private void ImportDataButton_Click(object sender, EventArgs e)
        {
            ImportData();
        }

        private void ExportLanguageFileButton_Click(object sender, EventArgs e)
        {
            // Show dialog
            // Update textbox

            //// Prompt user to select file
            //ProgramOpenFileDialog.InitialDirectory = Settings.Default.DefaultGameFolderPath;
            //ProgramOpenFileDialog.FileName = null;
            //var result = ProgramOpenFileDialog.ShowDialog();

            //// Cancel if file was not selected
            //if (result != DialogResult.OK)
            //    return;

            //var filePath = Path.GetDirectoryName(ProgramOpenFileDialog.FileName);
            //var selectedGpwExecutableFilePath = ProgramOpenFileDialog.FileName;
            //var selectedGpwLanguageFilePath = ProgramOpenFileDialog.FileName;
        }

        private void ExportExecutableFileButton_Click(object sender, EventArgs e)
        {
            // Show dialog
            // Update textbox
        }

        private void ExportDataButton_Click(object sender, EventArgs e)
        {
            ExportData();
        }

        private void EnginesDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // If the cell is in the following column indices
            if (e.ColumnIndex == 0)
            {
                // Show message if validation determines that cell is empty
                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    var headerText = EnginesDataGridView.Columns[e.ColumnIndex].HeaderText;
                    MessageBox.Show($"Please enter a value in the {headerText} column.");
                    e.Cancel = true;
                }
            }

            else
            {
                // Show message if validation determines that cell is not a valid integer rating value
                if ((!e.FormattedValue.ToString().ValidateAsInteger()) &&
                    (!Convert.ToInt32(e.FormattedValue).ValidateAsOneToTenStepOne()))
                {
                    var headerText = EnginesDataGridView.Columns[e.ColumnIndex].HeaderText;
                    MessageBox.Show($"Please enter a value for {headerText} of {1}-{10}.");
                    e.Cancel = true;
                }
            }
        }

        private void TyresDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // If the cell is in the following column indices
            if (e.ColumnIndex == 0)
            {
                // Show message if validation determines that cell is empty
                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    var headerText = TyresDataGridView.Columns[e.ColumnIndex].HeaderText;
                    MessageBox.Show($"Please enter a value in the {headerText} column.");
                    e.Cancel = true;
                }
            }

            else
            {
                // Show message if validation determines that cell is not a valid integer rating value
                if ((!e.FormattedValue.ToString().ValidateAsInteger()) &&
                    (!Convert.ToInt32(e.FormattedValue).ValidateAsOneToTenStepOne()))
                {
                    var headerText = TyresDataGridView.Columns[e.ColumnIndex].HeaderText;
                    MessageBox.Show($"Please enter a value for {headerText} of {1}-{10}.");
                    e.Cancel = true;
                }
            }
        }

        private void FuelsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // If the cell is in the following column indices
            if (e.ColumnIndex == 0)
            {
                // Show message if validation determines that cell is empty
                if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
                {
                    var headerText = FuelsDataGridView.Columns[e.ColumnIndex].HeaderText;
                    MessageBox.Show($"Please enter a value in the {headerText} column.");
                    e.Cancel = true;
                }
            }

            else
            {
                // Show message if validation determines that cell is not a valid integer rating value
                if ((!e.FormattedValue.ToString().ValidateAsInteger()) &&
                    (!Convert.ToInt32(e.FormattedValue).ValidateAsOneToTenStepOne()))
                {
                    var headerText = FuelsDataGridView.Columns[e.ColumnIndex].HeaderText;
                    MessageBox.Show($"Please enter a value for {headerText} of {1}-{10}.");
                    e.Cancel = true;
                }
            }
        }

        private bool ConfirmCloseFormWithUnsavedChanges()
        {
            // Return true if there are no unsaved changes 
            if (!_isModified)
                return true;

            // Prompt user whether to close form with unsaved changes
            DialogResult result =
                MessageBox.Show(
                    string.Format(
                        "Are you sure you wish to close the editor?{0}{0}Any changes not exported will be lost.",
                        Environment.NewLine), Settings.Default.ApplicationName, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            return result == DialogResult.Yes;
        }

        private void ImportData()
        {
            // Cancel import if required files are missing
            if ((!File.Exists(ImportExecutableFileTextBox.Text)) ||
                (!File.Exists(ImportLanguageFileTextBox.Text)))
            {
                MessageBox.Show(
                    string.Format(
                        "Unable to import data from files. Import cancelled.{0}{0}Unable to locate one or both of the following files.{0}{0}{1}{0}{2}",
                        Environment.NewLine, ImportExecutableFileTextBox.Text, ImportLanguageFileTextBox.Text),
                    "Import failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Import from file and populate controls
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var data = new ExecutableDatabase();
                data.ImportDataFromFile(ImportExecutableFileTextBox.Text, ImportLanguageFileTextBox.Text);
                PopulateControls(data);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            // Store file paths following successful import
            Settings.Default.ImportExecutableFilePath = ImportExecutableFileTextBox.Text;
            Settings.Default.ImportLanguageFilePath = ImportLanguageFileTextBox.Text;

            MessageBox.Show("Import complete!");
        }

        private void ExportData()
        {
            // Cancel export if required files are missing
            if ((!File.Exists(ExportExecutableFileTextBox.Text)) ||
                (!File.Exists(ExportLanguageFileTextBox.Text)))
            {
                MessageBox.Show(
                    string.Format(
                        "Unable to export data to files. Export cancelled.{0}{0}Unable to locate one or both of the following files.{0}{0}{1}{0}{2}",
                        Environment.NewLine, ExportExecutableFileTextBox.Text, ExportLanguageFileTextBox.Text),
                    "Export failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Populate records and export to file
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var data = new ExecutableDatabase();
                PopulateRecords(data);
                data.ExportDataToFile(ExportExecutableFileTextBox.Text, ExportLanguageFileTextBox.Text);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            // Store file paths following successful export
            Settings.Default.ExportExecutableFilePath = ExportExecutableFileTextBox.Text;
            Settings.Default.ExportLanguageFilePath = ExportLanguageFileTextBox.Text;

            MessageBox.Show("Export complete!");

            _isModified = false;
        }

        private void ConfigureDataGridViewControl(DataGridView control)
        {
            control.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            control.AllowUserToAddRows = false;
            control.AllowUserToDeleteRows = false;
            control.AllowUserToResizeRows = false;
            control.MultiSelect = false;
            control.RowHeadersVisible = false;
        }

        private void FormatControls()
        {
            ConfigureDataGridViewControl(TeamsDataGridView);
            TeamsDataGridView.Columns[3].HeaderText = "Team";
            ConfigureDataGridViewControl(DriversDataGridView);
            DriversDataGridView.Columns[3].HeaderText = "Driver";
            ConfigureDataGridViewControl(TracksDataGridView);
            TracksDataGridView.Columns[3].HeaderText = "Track";
        }

        private void PopulateControls(ExecutableDatabase data)
        {
            // Update controls to reflect applied enhancement units
            DisableColourModeCheckBox.Checked = data.IsDisplayModeFixApplied;
            // TODO DisableSampleAppTestCheckBox.Checked = data.IsSampleAppFixApplied;
            DisableYellowFlagPenaltiesCheckBox.Checked = data.IsYellowFlagFixApplied;

            // Move data from collections into grids
            StringTableGridView.DataSource = data.StringTable;
            TeamsDataGridView.DataSource = data.Teams;
            DriversDataGridView.DataSource = data.Drivers;
            EnginesDataGridView.DataSource = data.Engines;
            TyresDataGridView.DataSource = data.Tyres;
            FuelsDataGridView.DataSource = data.Fuels;
            TracksDataGridView.DataSource = data.Tracks;

            // Bind comboboxes
            var lapRecordDriverColumn =
                TracksDataGridView.Columns["lapRecordDriverDataGridViewTextBoxColumn"] as DataGridViewComboBoxColumn;
            lapRecordDriverColumn.DataSource = data.DriverIdentities;
            lapRecordDriverColumn.DisplayMember = "ResourceText";
            lapRecordDriverColumn.ValueMember = "LocalResourceId";
            lapRecordDriverColumn.ValueType = typeof(string);

            var lapRecordTeamColumn =
                TracksDataGridView.Columns["lapRecordTeamDataGridViewTextBoxColumn"] as DataGridViewComboBoxColumn;
            lapRecordTeamColumn.DataSource = data.Teams;
            lapRecordTeamColumn.DisplayMember = "ResourceText";
            lapRecordTeamColumn.ValueMember = "LocalResourceId";
            lapRecordTeamColumn.ValueType = typeof(string);

            var unknown2TeamColumn =
                TracksDataGridView.Columns["unknown2DataGridViewTextBoxColumn"] as DataGridViewComboBoxColumn;
            unknown2TeamColumn.DataSource = data.DriverIdentities;
            unknown2TeamColumn.DisplayMember = "ResourceText";
            unknown2TeamColumn.ValueMember = "LocalResourceId";
            unknown2TeamColumn.ValueType = typeof(string);

            var unknown3TeamColumn =
                TracksDataGridView.Columns["unknown3DataGridViewTextBoxColumn"] as DataGridViewComboBoxColumn;
            unknown3TeamColumn.DataSource = data.Teams;
            unknown3TeamColumn.DisplayMember = "ResourceText";
            unknown3TeamColumn.ValueMember = "LocalResourceId";
            unknown3TeamColumn.ValueType = typeof(string);
        }

        private void PopulateRecords(ExecutableDatabase data)
        {
            // Indicate whether enhancement unit is to be applied
            data.IsDisplayModeFixRequired = DisableColourModeCheckBox.Checked;
            data.IsYellowFlagFixRequired = DisableYellowFlagPenaltiesCheckBox.Checked;

            // Move data from grids into collections
            data.StringTable = StringTableGridView.DataSource as IdentityCollection;
            data.Teams = TeamsDataGridView.DataSource as TeamCollection;
            data.Drivers = DriversDataGridView.DataSource as DriverCollection;
            data.Engines = EnginesDataGridView.DataSource as EngineCollection;
            data.Tyres = TyresDataGridView.DataSource as TyreCollection;
            data.Fuels = FuelsDataGridView.DataSource as FuelCollection;
            data.Tracks = TracksDataGridView.DataSource as TrackCollection;
        }

        private void ExecutableEditorForm_Resize(object sender, EventArgs e)
        {
            MainTabControl.Width = ClientSize.Width - (MainTabControl.Location.X * 2);
            MainTabControl.Height = ClientSize.Height - (MainTabControl.Location.Y * 2);
        }

        private void TracksDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If column header
            if (e.RowIndex < 0)
            {
                return;
            }

            // If combobox column
            if (TracksDataGridView.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                // Drop down
                TracksDataGridView.BeginEdit(true);
                (TracksDataGridView.EditingControl as ComboBox).DroppedDown = true;
            }
        }
    }
}
