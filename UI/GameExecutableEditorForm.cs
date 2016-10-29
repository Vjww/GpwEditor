using System;
using System.IO;
using System.Windows.Forms;
using Data.Collections.Executable.Supplier;
using Data.Collections.Executable.Team;
using Data.Collections.Executable.Track;
using Data.Collections.Language;
using Data.Database;
using GpwEditor.Properties;

namespace GpwEditor
{
    /// <summary>
    /// Enables the user to modify data in the game executable.
    /// </summary>
    public partial class GameExecutableEditorForm : Form
    {
        private bool _isModified;

        public GameExecutableEditorForm()
        {
            InitializeComponent();
        }

        private void GameExecutableEditorForm_Load(object sender, EventArgs e)
        {
            // Set icon
            Icon = Resources.icon1;

            // Set form title text
            Text = $"{Settings.Default.ApplicationName} - Game Executable Editor";

            ConfigureControls();

            // Populate file paths with most recently used (MRU) or default
            var defaultLanguageFileFilePath = Path.Combine(Settings.Default.UserGameFolderPath, Settings.Default.DefaultLanguageFileName);
            LanguageFilePathTextBox.Text =
                string.IsNullOrWhiteSpace(Settings.Default.ExecutableEditorMruLanguageFileFilePath)
                    ? defaultLanguageFileFilePath
                    : Settings.Default.ExecutableEditorMruLanguageFileFilePath;

            var defaultGameExecutableFilePath = Path.Combine(Settings.Default.UserGameFolderPath, Settings.Default.DefaultExecutableFileName);
            GameExecutablePathTextBox.Text =
                string.IsNullOrWhiteSpace(Settings.Default.ExecutableEditorMruGameExecutableFilePath)
                    ? defaultGameExecutableFilePath
                    : Settings.Default.ExecutableEditorMruGameExecutableFilePath;
        }

        private void GameExecutableEditorForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void GameExecutableEditorForm_Resize(object sender, EventArgs e)
        {
            MainTabControl.Width = ClientSize.Width - (MainTabControl.Location.X * 2);
            MainTabControl.Height = ClientSize.Height - (MainTabControl.Location.Y * 2);
        }

        private void BrowseLanguageFileButton_Click(object sender, EventArgs e)
        {
            // Prompt user to select file
            ProgramOpenFileDialog.InitialDirectory = Settings.Default.UserGameFolderPath;
            ProgramOpenFileDialog.FileName = null;
            var result = ProgramOpenFileDialog.ShowDialog();

            // Cancel if file was not selected
            if (result != DialogResult.OK)
                return;

            LanguageFilePathTextBox.Text = ProgramOpenFileDialog.FileName;
        }

        private void BrowseGameExecutableButton_Click(object sender, EventArgs e)
        {
            // Prompt user to select file
            ProgramOpenFileDialog.InitialDirectory = Settings.Default.UserGameFolderPath;
            ProgramOpenFileDialog.FileName = null;
            var result = ProgramOpenFileDialog.ShowDialog();

            // Cancel if file was not selected
            if (result != DialogResult.OK)
                return;

            GameExecutablePathTextBox.Text = ProgramOpenFileDialog.FileName;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Import(LanguageFilePathTextBox.Text, GameExecutablePathTextBox.Text);

            // On import, assume user has made modifications to the data
            _isModified = true;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            Export(LanguageFilePathTextBox.Text, GameExecutablePathTextBox.Text);
        }

        private void EnginesDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            /* TODO Uncomment once unknown defect has been resolved - suspect because values are currently 0 it throws exception.
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
            */
        }

        private void TyresDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            /* TODO Uncomment once unknown defect has been resolved - suspect because values are currently 0 it throws exception.
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
            */
        }

        private void FuelsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            /* TODO Uncomment once unknown defect has been resolved - suspect because values are currently 0 it throws exception.
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
            */
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
                ((ComboBox)TracksDataGridView.EditingControl).DroppedDown = true;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfigureControls()
        {
            ConfigureDataGridViewControl(TeamsDataGridView, "Team", 1);
            ConfigureDataGridViewControl(DriversDataGridView, "Driver", 2);
            ConfigureDataGridViewControl(EnginesDataGridView, "Supplier", 3);
            ConfigureDataGridViewControl(TyresDataGridView, "Supplier", 4);
            ConfigureDataGridViewControl(FuelsDataGridView, "Supplier", 5);
            ConfigureDataGridViewControl(TracksDataGridView, "Track", 6);
        }

        private static void ConfigureDataGridViewControl(DataGridView dataGridView, string headerText, int columnId)
        {
            // Hide columns
            dataGridView.Columns[$"idDataGridViewTextBoxColumn{columnId}"].Visible = false;
            dataGridView.Columns[$"localResourceIdDataGridViewTextBoxColumn{columnId}"].Visible = false;
            dataGridView.Columns[$"resourceIdDataGridViewTextBoxColumn{columnId}"].Visible = false;

            // Rename primary column and configure to always show when scrolling horizontally
            dataGridView.Columns[$"resourceTextDataGridViewTextBoxColumn{columnId}"].HeaderText = headerText;
            dataGridView.Columns[$"resourceTextDataGridViewTextBoxColumn{columnId}"].Frozen = true;

            // Configure grid
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
        }

        private bool ConfirmCloseFormWithUnsavedChanges()
        {
            // Return true if there are no unsaved changes 
            if (!_isModified)
            {
                return true;
            }

            // Prompt user whether to close form with unsaved changes
            var result = MessageBox.Show(
                    $"Are you sure you wish to close the game executable editor?{Environment.NewLine}{Environment.NewLine}Any changes not exported will be lost.",
                    Settings.Default.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            return result == DialogResult.Yes;
        }

        private void BindDataGridViewComboBoxColumn(string dataGridViewComboBoxColumnName, object dataSource)
        {
            var dataGridViewComboBoxColumn = (DataGridViewComboBoxColumn)TracksDataGridView.Columns[dataGridViewComboBoxColumnName];
            dataGridViewComboBoxColumn.DataSource = dataSource;
            dataGridViewComboBoxColumn.DisplayMember = "ResourceText";
            dataGridViewComboBoxColumn.ValueMember = "LocalResourceId";
            dataGridViewComboBoxColumn.ValueType = typeof(string);
        }

        private void Export(string languageFileFilePath, string gameExecutableFilePath)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Fill database with data from controls and export to file
                var executableDatabase = new ExecutableDatabase();
                PopulateRecords(executableDatabase);
                executableDatabase.ExportDataToFile(gameExecutableFilePath, languageFileFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured. Process aborted.{Environment.NewLine}{Environment.NewLine}{ex.Message}");
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            MessageBox.Show("Export complete!");
        }

        private void Import(string languageFileFilePath, string gameExecutableFilePath)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Import from file to database and fill controls with data
                var executableDatabase = new ExecutableDatabase();
                executableDatabase.ImportDataFromFile(gameExecutableFilePath, languageFileFilePath);
                PopulateControls(executableDatabase);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured. Process aborted.{Environment.NewLine}{Environment.NewLine}{ex.Message}");
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            // Store most recently used (MRU) file paths on successful import
            Settings.Default.ExecutableEditorMruLanguageFileFilePath = LanguageFilePathTextBox.Text;
            Settings.Default.ExecutableEditorMruGameExecutableFilePath = GameExecutablePathTextBox.Text;

            MessageBox.Show("Import complete!");
        }

        private void PopulateControls(ExecutableDatabase executableDatabase)
        {
            // Move data from database into controls
            LanguageDataGridView.DataSource = executableDatabase.LanguageStrings;
            TeamsDataGridView.DataSource = executableDatabase.Teams;
            DriversDataGridView.DataSource = executableDatabase.Drivers;
            EnginesDataGridView.DataSource = executableDatabase.Engines;
            TyresDataGridView.DataSource = executableDatabase.Tyres;
            FuelsDataGridView.DataSource = executableDatabase.Fuels;
            TracksDataGridView.DataSource = executableDatabase.Tracks;

            // Bind comboboxes to data
            // Hint: Requires the column type to be set at design time to ComboBoxColumn via DataGridView Tasks Wizard > Edit Columns... > ColumnType
            //       Requires a rename at design time of the column's Name property. Change the suffix TextBoxColumn to ComboBoxColumn to reflect the ColumnType.
            BindDataGridViewComboBoxColumn("lapRecordDriverDataGridViewComboBoxColumn", executableDatabase.DriverIdentities);
            BindDataGridViewComboBoxColumn("lapRecordTeamDataGridViewComboBoxColumn", executableDatabase.Teams);
            BindDataGridViewComboBoxColumn("lastRaceDriverDataGridViewComboBoxColumn", executableDatabase.DriverIdentities);
            BindDataGridViewComboBoxColumn("lastRaceTeamDataGridViewComboBoxColumn", executableDatabase.Teams);
        }

        private void PopulateRecords(ExecutableDatabase executableDatabase)
        {
            // Move data from controls into database
            executableDatabase.LanguageStrings = LanguageDataGridView.DataSource as IdentityCollection;
            executableDatabase.Teams = TeamsDataGridView.DataSource as TeamCollection;
            executableDatabase.Drivers = DriversDataGridView.DataSource as DriverCollection;
            executableDatabase.Engines = EnginesDataGridView.DataSource as EngineCollection;
            executableDatabase.Tyres = TyresDataGridView.DataSource as TyreCollection;
            executableDatabase.Fuels = FuelsDataGridView.DataSource as FuelCollection;
            executableDatabase.Tracks = TracksDataGridView.DataSource as TrackCollection;
        }
    }
}
