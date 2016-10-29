/*
using System;
using System.IO;
using System.Windows.Forms;
using Common.GameObjects.Collections;
using Common.Validation;
using Microsoft.Win32;

namespace ExecutableEditor
{
    /// <summary>
    /// The primary form for this project.
    /// Overlapping panels are used to show/hide overlapping controls.
    /// 
    /// Tip: Use Document Outline in design mode (View menu > Document Outline)
    /// to order panels to manipulate form controls. Move the required panel
    /// towards the top of the container to move it in front of other panels.
    /// </summary>
    public partial class MainForm : Form
    {
        // flag for any changes to the form since the last export
        private bool IsModified = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // set form title text
            Text = String.Format(Text, Common.Properties.Settings.Default.ApplicationName) +
                " - Game Editor";

            FormatControls();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // if game folder is not specified, attempt to auto detect
            if ((String.IsNullOrEmpty(Common.Properties.Settings.Default.GpwGameFolderPath.Trim()))
                || (!Directory.Exists(Common.Properties.Settings.Default.GpwGameFolderPath)))
            {
                AutoDetectGameFolder();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ExitProgram())
            {
                // stay in program
                e.Cancel = true;
                return;
            }

            // else exit
            Properties.Settings.Default.Save();
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // when switching tabs, assume that the user has modified the data since the last export
            IsModified = true;
        }

        private void BrowseGameFolderButton_Click(object sender, EventArgs e)
        {
            BrowseGameFolder();
        }

        private void AutoDetectGameFolderButton_Click(object sender, EventArgs e)
        {
            AutoDetectGameFolder();
        }

        private void ImportDataButton_Click(object sender, EventArgs e)
        {
            ImportData();
        }

        private void ExportDataButton_Click(object sender, EventArgs e)
        {
            ExportData();
        }

        private bool ExitProgram()
        {
            // show prompt if data on the form has been changed
            if (IsModified)
            {
                // confirm whether to exit the application
                DialogResult result = MessageBox.Show(
                    "Are you sure you wish to exit the application?" +
                    Environment.NewLine + Environment.NewLine +
                    "Any changes that have not been saved will be lost.",
                    "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                return result == DialogResult.Yes ? true : false;
            }

            // else
            return true;
        }

        private void BrowseGameFolder()
        {
            string defaultFolderPath = FolderBrowserDialog.SelectedPath;

            if (Directory.Exists(GameFolderTextBox.Text))
            {
                FolderBrowserDialog.SelectedPath = GameFolderTextBox.Text;
            }

            // get user to select a folder
            DialogResult folderResult = FolderBrowserDialog.ShowDialog();

            // return if no folder selected
            if (folderResult != DialogResult.OK)
            {
                return;
            }

            // else get selected folder
            GameFolderTextBox.Text = FolderBrowserDialog.SelectedPath;
            Common.Properties.Settings.Default.GpwGameFolderPath = FolderBrowserDialog.SelectedPath;

            // restore default selected path
            FolderBrowserDialog.SelectedPath = defaultFolderPath;
        }

        private void AutoDetectGameFolder()
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(Common.Properties.Settings.Default.RegistryKey, false);

                // if key does not exist
                if (rk == null)
                {
                    MessageBox.Show(
                        "Unable to find the registry subkey to auto-detect the game folder." +
                        Environment.NewLine + Environment.NewLine +
                        "Please select the game folder manually using the Browse button.",
                        "Auto-detect failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                String value = (String)rk.GetValue(Common.Properties.Settings.Default.RegistrySubKey);

                // if the name/value pair does not exit
                if (value == null)
                {
                    MessageBox.Show(
                        "Unable to find the registry key to auto-detect the game folder." +
                        Environment.NewLine + Environment.NewLine +
                        "Please select the game folder manually using the Browse button.",
                        "Auto-detect failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                GameFolderTextBox.Text = value;
                Common.Properties.Settings.Default.GpwGameFolderPath = value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error has occured while attempting to auto-detect the game folder." +
                    Environment.NewLine + Environment.NewLine +
                    "Please select the game folder manually using the Browse button." +
                    Environment.NewLine + Environment.NewLine +
                    ex.Message,
                    "Auto-detect failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportData()
        {
#if !DEBUG
            // prompt user to select file
            DialogResult result;

            ProgramOpenFileDialog.InitialDirectory = Properties.Settings.Default.GpwGameFolderPath;
            ProgramOpenFileDialog.FileName = null;
            result = ProgramOpenFileDialog.ShowDialog();

            // cancel if file was not selected
            if (result != DialogResult.OK)
                return;

            string filePath = Path.GetDirectoryName(ProgramOpenFileDialog.FileName);
            string selectedGpwExecutableFilePath = ProgramOpenFileDialog.FileName;
            string selectedGpwLanguageFilePath = Path.Combine(filePath, Common.Properties.Settings.Default.GpwLanguageFileName);
            Properties.Settings.Default.GpwExecutableFilePath = selectedGpwExecutableFilePath;
            Properties.Settings.Default.GpwLanguageFilePath = selectedGpwLanguageFilePath;
#else
            // bypass file select in debug mode
            string filePath = GameFolderTextBox.Text;
            Common.Properties.Settings.Default.GpwExecutableFilePath = Path.Combine(filePath, "gpwxp.exe");
            Common.Properties.Settings.Default.GpwLanguageFilePath = Path.Combine(filePath, Common.Properties.Settings.Default.GpwLanguageFileName);
#endif
            // abort if required files are missing
            if ((!File.Exists(Common.Properties.Settings.Default.GpwExecutableFilePath)) ||
                (!File.Exists(Common.Properties.Settings.Default.GpwLanguageFilePath)))
            {
                MessageBox.Show(
                    "Unable to import data from files. Operation aborted." +
                    Environment.NewLine + Environment.NewLine +
                    "Unable to locate one or both of the following files." +
                    Environment.NewLine + Environment.NewLine +
                    Common.Properties.Settings.Default.GpwExecutableFilePath + Environment.NewLine +
                    Common.Properties.Settings.Default.GpwLanguageFilePath,
                    "Import failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // import data and populate form controls
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ExecutableData data = new ExecutableData();
                data.Import();
                PopulateControls(data);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            // import complete
            ExportTextBox.Text = String.Empty;
            ImportTextBox.Text = Common.Properties.Settings.Default.GpwExecutableFilePath;
            MessageBox.Show("Import complete!");
        }

        private void ExportData()
        {
#if !DEBUG
            // prompt user to select file
            DialogResult result;

            ProgramOpenFileDialog.InitialDirectory = Properties.Settings.Default.GpwGameFolderPath;
            ProgramOpenFileDialog.FileName = null;
            result = ProgramOpenFileDialog.ShowDialog();

            // cancel if file was not selected
            if (result != DialogResult.OK)
                return;

            string filePath = Path.GetDirectoryName(ProgramOpenFileDialog.FileName);
            string selectedGpwExecutableFilePath = ProgramOpenFileDialog.FileName;
            string selectedGpwLanguageFilePath = Path.Combine(filePath, Common.Properties.Settings.Default.GpwLanguageFileName);
            Properties.Settings.Default.GpwExecutableFilePath = selectedGpwExecutableFilePath;
            Properties.Settings.Default.GpwLanguageFilePath = selectedGpwLanguageFilePath;
#else
            // bypass file select in debug mode
            string filePath = GameFolderTextBox.Text;
            Common.Properties.Settings.Default.GpwExecutableFilePath = Path.Combine(filePath, "gpwxp.exe");
            Common.Properties.Settings.Default.GpwLanguageFilePath = Path.Combine(filePath, Common.Properties.Settings.Default.GpwLanguageFileName);
#endif
            // abort if required files are missing
            if ((!File.Exists(Common.Properties.Settings.Default.GpwExecutableFilePath)) ||
                (!File.Exists(Common.Properties.Settings.Default.GpwLanguageFilePath)))
            {
                MessageBox.Show(
                    "Unable to export data to files. Operation aborted." +
                    Environment.NewLine + Environment.NewLine +
                    "Unable to locate one or both of the following files." +
                    Environment.NewLine + Environment.NewLine +
                    Common.Properties.Settings.Default.GpwExecutableFilePath + Environment.NewLine +
                    Common.Properties.Settings.Default.GpwLanguageFilePath,
                    "Export failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // populate records and export data
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ExecutableData data = new ExecutableData();
                PopulateRecords(data);
                data.Export();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            // export complete
            ExportTextBox.Text = Common.Properties.Settings.Default.GpwExecutableFilePath;
            MessageBox.Show("Export complete!");

            IsModified = false;
        }

        private void ConfigureDataGridViewControl(DataGridView control)
        {
            control.Columns[0].FillWeight = 200;
            control.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            control.AllowUserToAddRows = false;
            control.AllowUserToDeleteRows = false;
            control.AllowUserToResizeColumns = false;
            control.AllowUserToResizeRows = false;
            control.MultiSelect = false;
            control.RowHeadersVisible = false;
        }

        private void FormatControls()
        {
            // format data grids
            foreach (var page in MainTabControl.TabPages)
            {
                foreach (var item in (page as TabPage).Controls)
                {
                    if (item is DataGridView)
                        ConfigureDataGridViewControl(item as DataGridView);
                }
            }

            // format read-only columns in data grids
            EnginesDataGridView.Columns[0].ReadOnly = true;
            EnginesDataGridView.Columns[0].HeaderText = String.Format(
                "{0} (read-only)", EnginesDataGridView.Columns[0].HeaderText);
            TyresDataGridView.Columns[0].ReadOnly = true;
            TyresDataGridView.Columns[0].HeaderText = String.Format(
                "{0} (read-only)", TyresDataGridView.Columns[0].HeaderText);
            FuelsDataGridView.Columns[0].ReadOnly = true;
            FuelsDataGridView.Columns[0].HeaderText = String.Format(
                "{0} (read-only)", FuelsDataGridView.Columns[0].HeaderText);
            FastestLapsDataGridView.Columns[0].ReadOnly = true;
            FastestLapsDataGridView.Columns[0].HeaderText = String.Format(
                "{0} (read-only)", FastestLapsDataGridView.Columns[0].HeaderText);
        }

        private void PopulateControls(ExecutableData data)
        {
            // populate teams
            TeamsDataGridView.DataSource = data.Teams;

            // populate drivers
            DriversDataGridView.DataSource = data.Drivers;

            // populate engines
            EnginesDataGridView.DataSource = data.Engines;

            // populate tyres
            TyresDataGridView.DataSource = data.Tyres;

            // populate fuels
            FuelsDataGridView.DataSource = data.Fuels;

            // populate fastest laps
            FastestLapsDataGridView.DataSource = data.Tracks;
            FastestLapsDataGridView.Columns["nameDataGridViewTextBoxColumn5"].FillWeight = 150;
            FastestLapsDataGridView.Columns["driverDataGridViewComboBoxColumn"].FillWeight = 150;
            // bind combobox column
            DataGridViewComboBoxColumn flCol1 =
                FastestLapsDataGridView.Columns["driverDataGridViewComboBoxColumn"] as DataGridViewComboBoxColumn;
            flCol1.DataSource = data.Drivers;
            flCol1.DisplayMember = "Name";
            flCol1.ValueMember = "NameId";
            flCol1.ValueType = typeof(string);
            // bind combobox column
            DataGridViewComboBoxColumn flCol2 =
                FastestLapsDataGridView.Columns["teamDataGridViewComboBoxColumn"] as DataGridViewComboBoxColumn;
            flCol2.DataSource = data.Teams;
            flCol2.DisplayMember = "Name";
            flCol2.ValueMember = "NameId";
            flCol2.ValueType = typeof(string);
        }

        private void PopulateRecords(ExecutableData data)
        {
            // populate teams
            data.Teams = TeamsDataGridView.DataSource as TeamCollection;

            // populate drivers
            data.Drivers = DriversDataGridView.DataSource as DriverCollection;

            // populate engines
            data.Engines = EnginesDataGridView.DataSource as EngineCollection;

            // populate tyres
            data.Tyres = TyresDataGridView.DataSource as TyreCollection;

            // populate fuels
            data.Fuels = FuelsDataGridView.DataSource as FuelCollection;

            // populate fastest laps
            data.Tracks = FastestLapsDataGridView.DataSource as TrackCollection;
        }

        private void EnginesDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // for these columns
            if (e.ColumnIndex == 0)
            {
                // show message if validation determines that cell is empty
                if (String.IsNullOrEmpty(e.FormattedValue.ToString().Trim()))
                {
                    string headerText = EnginesDataGridView.Columns[e.ColumnIndex].HeaderText.ToLower();
                    MessageBox.Show(String.Format("Please enter a value in the {0} column.", headerText));
                    e.Cancel = true;
                }
            }

            // else for all other columns
            else
            {
                int min = 1;
                int max = 10;

                // show message if validation determines that cell is not a valid integer rating value
                if (!DataValidation.ValidateValueAsInteger(e.FormattedValue.ToString(), min, max))
                {
                    string headerText = EnginesDataGridView.Columns[e.ColumnIndex].HeaderText.ToLower();
                    MessageBox.Show(String.Format("Please enter a value for {0} between {1} and {2}.", headerText, min, max));
                    e.Cancel = true;
                }
            }
        }

        private void TyresDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // for these columns
            if (e.ColumnIndex == 0)
            {
                // show message if validation determines that cell is empty
                if (String.IsNullOrEmpty(e.FormattedValue.ToString().Trim()))
                {
                    string headerText = TyresDataGridView.Columns[e.ColumnIndex].HeaderText.ToLower();
                    MessageBox.Show(String.Format("Please enter a value in the {0} column.", headerText));
                    e.Cancel = true;
                }
            }

            // else for all other columns
            else
            {
                int min = 1;
                int max = 10;

                // show message if validation determines that cell is not a valid integer rating value
                if (!DataValidation.ValidateValueAsInteger(e.FormattedValue.ToString(), min, max))
                {
                    string headerText = TyresDataGridView.Columns[e.ColumnIndex].HeaderText.ToLower();
                    MessageBox.Show(String.Format("Please enter a value for {0} between {1} and {2}.", headerText, min, max));
                    e.Cancel = true;
                }
            }
        }

        private void FuelsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // for these columns
            if (e.ColumnIndex == 0)
            {
                // show message if validation determines that cell is empty
                if (String.IsNullOrEmpty(e.FormattedValue.ToString().Trim()))
                {
                    string headerText = FuelsDataGridView.Columns[e.ColumnIndex].HeaderText.ToLower();
                    MessageBox.Show(String.Format("Please enter a value in the {0} column.", headerText));
                    e.Cancel = true;
                }
            }

            // else for all other columns
            else
            {
                int min = 1;
                int max = 10;

                // show message if validation determines that cell is not a valid integer rating value
                if (!DataValidation.ValidateValueAsInteger(e.FormattedValue.ToString(), min, max))
                {
                    string headerText = FuelsDataGridView.Columns[e.ColumnIndex].HeaderText.ToLower();
                    MessageBox.Show(String.Format("Please enter a value for {0} between {1} and {2}.", headerText, min, max));
                    e.Cancel = true;
                }
            }
        }
    }
}
*/
