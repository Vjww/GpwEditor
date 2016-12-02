using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Data.Collections.Executable.Supplier;
using Data.Collections.Executable.Team;
using Data.Collections.Executable.Track;
using Data.Collections.Language;
using Data.Database;
using Data.Entities.EntityTypes;
using Data.Entities.Executable.Race;
using Data.Entities.Executable.Supplier;
using Data.Entities.Executable.Team;
using Data.Entities.Executable.Track;
using GpwEditor.Enums;
using GpwEditor.Properties;
using Cursor = System.Windows.Forms.Cursor;

namespace GpwEditor
{
    /// <summary>
    /// Enables the user to modify data in the game executable.
    /// </summary>
    public partial class GameExecutableEditorForm : Form
    {
        private bool _isModified;

        private RacePerformanceCurveChart _racePerformanceCurveChart;

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
            GenerateTooltips();

            // Create and map to chart
            _racePerformanceCurveChart = new RacePerformanceCurveChart(RacePerformanceChart);

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

        private void TeamsDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // TODO
        }

        private void DriversDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // TODO
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
                if ((!e.FormattedValue.ToString().IsInteger()) &&
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
                if ((!e.FormattedValue.ToString().IsInteger()) &&
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
                if ((!e.FormattedValue.ToString().IsInteger()) &&
                    (!Convert.ToInt32(e.FormattedValue).ValidateAsOneToTenStepOne()))
                {
                    var headerText = FuelsDataGridView.Columns[e.ColumnIndex].HeaderText;
                    MessageBox.Show($"Please enter a value for {headerText} of {1}-{10}.");
                    e.Cancel = true;
                }
            }
            */
        }

        private void TracksDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // TODO
        }

        private void GenericDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If column header
            if (e.RowIndex < 0)
            {
                return;
            }

            // If combobox column
            if (((DataGridView)sender).Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                // Drop down
                ((DataGridView)sender).BeginEdit(true);
                ((ComboBox)((DataGridView)sender).EditingControl).DroppedDown = true;
            }
        }

        private void GenericDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Handle error that occurs after viewing the datagridview with imported data, having previously viewed the datagridview with no data
            // https://refactoringself.com/2012/09/26/datagridview-formattingexception-dataerror-and-preferredsize-auto-sizing-issue/
            if (e.Context == (DataGridViewDataErrorContexts.Formatting | DataGridViewDataErrorContexts.PreferredSize))
            {
                e.Cancel = true;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RacePerformanceNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var numericUpDownControl = (NumericUpDown)sender;

            // Get position in curve to change
            var position = int.Parse(numericUpDownControl.Tag.ToString());

            // Determine change in direction
            if (numericUpDownControl.Value > 0)
            {
                _racePerformanceCurveChart.AdjustCurve(position, NumericUpDownDirectionType.Up);
            }
            else if (numericUpDownControl.Value < 0)
            {
                _racePerformanceCurveChart.AdjustCurve(position, NumericUpDownDirectionType.Down);
            }

            // Reset control
            numericUpDownControl.ValueChanged -= RacePerformanceNumericUpDown_ValueChanged;
            numericUpDownControl.Value = 0;
            numericUpDownControl.ValueChanged += RacePerformanceNumericUpDown_ValueChanged;
        }

        private void RacePerformanceEditButton_Click(object sender, EventArgs e)
        {
            // Hide parent form and show child form
            SwitchToForm(this, new RacePerformanceCurveForm(_racePerformanceCurveChart));
        }

        private void RacePerformanceSoftenCurveButton_Click(object sender, EventArgs e)
        {
            _racePerformanceCurveChart.SoftenCurve();
        }

        private void RacePerformanceCopyDefaultButton_Click(object sender, EventArgs e)
        {
            _racePerformanceCurveChart.ResetCurveToDefault();
        }

        private void RacePerformanceCopyCurrentButton_Click(object sender, EventArgs e)
        {
            _racePerformanceCurveChart.ResetCurveToCurrent();
        }

        private void RacePerformanceCopyRecommendedButton_Click(object sender, EventArgs e)
        {
            _racePerformanceCurveChart.ResetCurveToRecommended();
        }

        private void RacePerformanceDefaultCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If has been unchecked
            if (!RacePerformanceDefaultCheckBox.Checked)
            {
                // And at least one other is checked
                if (RacePerformanceCurrentCheckBox.Checked || RacePerformanceProposedCheckBox.Checked)
                {
                    _racePerformanceCurveChart.ToggleDefaultSeries();
                    return;
                }

                // Else prevent uncheck by checking (and prevent event from firing)
                RacePerformanceDefaultCheckBox.CheckedChanged -= RacePerformanceDefaultCheckBox_CheckedChanged;
                RacePerformanceDefaultCheckBox.Checked = true;
                RacePerformanceDefaultCheckBox.CheckedChanged += RacePerformanceDefaultCheckBox_CheckedChanged;
                return;
            }

            _racePerformanceCurveChart.ToggleDefaultSeries();
        }

        private void RacePerformanceCurrentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If has been unchecked
            if (!RacePerformanceCurrentCheckBox.Checked)
            {
                // And at least one other is checked
                if (RacePerformanceDefaultCheckBox.Checked || RacePerformanceProposedCheckBox.Checked)
                {
                    _racePerformanceCurveChart.ToggleCurrentSeries();
                    return;
                }

                // Else prevent uncheck by checking (and prevent event from firing)
                RacePerformanceCurrentCheckBox.CheckedChanged -= RacePerformanceCurrentCheckBox_CheckedChanged;
                RacePerformanceCurrentCheckBox.Checked = true;
                RacePerformanceCurrentCheckBox.CheckedChanged += RacePerformanceCurrentCheckBox_CheckedChanged;
                return;
            }

            _racePerformanceCurveChart.ToggleCurrentSeries();
        }

        private void RacePerformanceProposedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If has been unchecked
            if (!RacePerformanceProposedCheckBox.Checked)
            {
                // And at least one other is checked
                if (RacePerformanceDefaultCheckBox.Checked || RacePerformanceCurrentCheckBox.Checked)
                {
                    _racePerformanceCurveChart.ToggleProposedSeries();
                    return;
                }

                // Else prevent uncheck by checking (and prevent event from firing)
                RacePerformanceProposedCheckBox.CheckedChanged -= RacePerformanceProposedCheckBox_CheckedChanged;
                RacePerformanceProposedCheckBox.Checked = true;
                RacePerformanceProposedCheckBox.CheckedChanged += RacePerformanceProposedCheckBox_CheckedChanged;
                return;
            }

            _racePerformanceCurveChart.ToggleProposedSeries();
        }

        private static void BindDataGridViewComboBoxColumn(DataGridView dataGridView, string dataGridViewComboBoxColumnName, object dataSource)
        {
            var dataGridViewComboBoxColumn = (DataGridViewComboBoxColumn)dataGridView.Columns[dataGridViewComboBoxColumnName];
            dataGridViewComboBoxColumn.DataSource = dataSource;
            dataGridViewComboBoxColumn.DisplayMember = "ResourceText";
            dataGridViewComboBoxColumn.ValueMember = "LocalResourceId";
            dataGridViewComboBoxColumn.ValueType = typeof(int);
        }

        private void ConfigureControls()
        {
            // Configure initial display of content on RacePerformanceTabPage
            RacePerformanceChart.Titles.Clear();
            var chartTitle = RacePerformanceChart.Titles.Add("Race Performance Curve");
            chartTitle.Font = new Font(chartTitle.Font.FontFamily, chartTitle.Font.SizeInPoints + 10);
            RacePerformanceGroupBox.Visible = false;

            // Configure data grid view controls
            ConfigureDataGridViewControl<Team>(TeamsDataGridView, 1);
            ConfigureDataGridViewControl<Driver>(DriversDataGridView, 2);
            ConfigureDataGridViewControl<Engine>(EnginesDataGridView, 3);
            ConfigureDataGridViewControl<Tyre>(TyresDataGridView, 4);
            ConfigureDataGridViewControl<Fuel>(FuelsDataGridView, 5);
            ConfigureDataGridViewControl<Track>(TracksDataGridView, 6);
            ConfigureDataGridViewControl<FiveValueBase>(FactoryRunningCostsDataGridView, 7, "Running Costs", true);
            ConfigureDataGridViewControl<FiveRatingBase>(FactoryExpansionCostsDataGridView, 8, "Expansion Costs", true);
            ConfigureDataGridViewControl<FiveValueBase>(StaffSalariesDataGridView, 9, "Staff Salaries", true);
            ConfigureDataGridViewControl<TenValueBase>(TestingMilesDataGridView, 10, "Testing Miles", true);
        }

        private static void ConfigureDataGridViewControl<T>(DataGridView dataGridView, int columnId, string resourceTextHeaderText, bool fillColumns = false)
        {
            ConfigureDataGridViewControl<T>(dataGridView, columnId, fillColumns);
            dataGridView.Columns[3].HeaderText = resourceTextHeaderText;
        }

        private static void ConfigureDataGridViewControl<T>(DataGridView dataGridView, int columnId, bool fillColumns = false)
        {
            // Hide columns
            dataGridView.Columns[$"idDataGridViewTextBoxColumn{columnId}"].Visible = false;
            dataGridView.Columns[$"localResourceIdDataGridViewTextBoxColumn{columnId}"].Visible = false;
            dataGridView.Columns[$"resourceIdDataGridViewTextBoxColumn{columnId}"].Visible = false;

            // Freeze primary column (to always show when scrolling horizontally)
            dataGridView.Columns[$"resourceTextDataGridViewTextBoxColumn{columnId}"].Frozen = !fillColumns;

            // Rename column headers and populate column tooltips using model attributes
            UpdateDataGridViewColumnHeaders<T>(dataGridView);

            // Configure grid
            dataGridView.AutoSizeColumnsMode = fillColumns ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.AllCells;
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
            var dialogResult = MessageBox.Show(
                    $"Are you sure you wish to close the game executable editor?{Environment.NewLine}{Environment.NewLine}Any changes not exported will be lost.",
                    Settings.Default.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            return dialogResult == DialogResult.Yes;
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
                MessageBox.Show($"An error has occured. Process aborted.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            // Update chart
            _racePerformanceCurveChart.SetCurrentSeriesToProposedSeries();

            MessageBox.Show("Export complete!", Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GenerateTooltips()
        {
            var toolTip = new ToolTip();

            // Race Peformance Controls
            toolTip.SetToolTip(RacePerformanceDefaultCheckBox, $"Show/Hide the curve that represents the performance levels defined in v1.01b of {Settings.Default.GameName}.");
            toolTip.SetToolTip(RacePerformanceCurrentCheckBox, $"Show/Hide the curve that is currently applied in the imported {Settings.Default.DefaultExecutableFileName} game executable file.");
            toolTip.SetToolTip(RacePerformanceProposedCheckBox, $"Show/Hide the curve that is proposed for export to a {Settings.Default.DefaultExecutableFileName} game executable file.");
            toolTip.SetToolTip(RacePerformanceEditButton, "Opens a window to access and edit the raw data that makes up the Proposed curve.");
            toolTip.SetToolTip(RacePerformanceSoftenCurveButton, "Softens the peaks and troughs of the Proposed curve using a simple moving average formula.");
            toolTip.SetToolTip(RacePerformanceCopyDefaultButton, $"Copies the curve that represents the performance levels defined in v1.01b of {Settings.Default.GameName}.");
            toolTip.SetToolTip(RacePerformanceCopyCurrentButton, $"Copies the curve that is currently applied in the imported {Settings.Default.DefaultExecutableFileName} game executable file.");
            toolTip.SetToolTip(RacePerformanceCopyRecommendedButton, $"Copies the curve that is recommended for use by the {Settings.Default.GameName} gaming community.");
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
                MessageBox.Show($"An error has occured. Process aborted.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            // Store most recently used (MRU) file paths on successful import
            Settings.Default.ExecutableEditorMruLanguageFileFilePath = LanguageFilePathTextBox.Text;
            Settings.Default.ExecutableEditorMruGameExecutableFilePath = GameExecutablePathTextBox.Text;

            MessageBox.Show("Import complete!", Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            FactoryRunningCostsDataGridView.DataSource = executableDatabase.FactoryRunningCosts;
            FactoryExpansionCostsDataGridView.DataSource = executableDatabase.FactoryExpansionCosts;
            StaffSalariesDataGridView.DataSource = executableDatabase.StaffSalaries;
            TestingMilesDataGridView.DataSource = executableDatabase.TestingMiles;

            // Bind comboboxes to data
            // Hint: Requires the column type to be set at design time to ComboBoxColumn via DataGridView Tasks Wizard > Edit Columns... > ColumnType
            //       Requires a rename at design time of the column's Name property. Change the suffix TextBoxColumn to ComboBoxColumn to reflect the ColumnType.
            BindDataGridViewComboBoxColumn(TeamsDataGridView, "firstGpTrackDataGridViewComboBoxColumn", executableDatabase.TeamFirstGpTrackIdentities);
            BindDataGridViewComboBoxColumn(TeamsDataGridView, "tyreSupplierIdDataGridViewComboBoxColumn", executableDatabase.TeamTyreSupplierIdIdentities);
            BindDataGridViewComboBoxColumn(DriversDataGridView, "nationalityDataGridViewComboBoxColumn", executableDatabase.DriverNationalityIdIdentities);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "designDataGridViewComboBoxColumn", executableDatabase.TrackDesignIdentities);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "lapRecordDriverDataGridViewComboBoxColumn", executableDatabase.DriverIdentities);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "lapRecordTeamDataGridViewComboBoxColumn", executableDatabase.Teams);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "lastRaceDriverDataGridViewComboBoxColumn", executableDatabase.DriverIdentities);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "lastRaceTeamDataGridViewComboBoxColumn", executableDatabase.Teams);

            // Generate chart
            _racePerformanceCurveChart.GenerateChart();
            _racePerformanceCurveChart.SetCurrentSeries(executableDatabase.RacePerformance.Values);
            _racePerformanceCurveChart.SetProposedSeriesToCurrentSeries();
            RacePerformanceGroupBox.Visible = true;
        }

        private void PopulateRecords(ExecutableDatabase executableDatabase)
        {
            // Move data from controls into database
            executableDatabase.LanguageStrings = (IdentityCollection)LanguageDataGridView.DataSource;
            executableDatabase.Teams = (TeamCollection)TeamsDataGridView.DataSource;
            executableDatabase.Drivers = (DriverCollection)DriversDataGridView.DataSource;
            executableDatabase.Engines = (EngineCollection)EnginesDataGridView.DataSource;
            executableDatabase.Tyres = (TyreCollection)TyresDataGridView.DataSource;
            executableDatabase.Fuels = (FuelCollection)FuelsDataGridView.DataSource;
            executableDatabase.Tracks = (TrackCollection)TracksDataGridView.DataSource;

            executableDatabase.StaffSalaries = (FiveValueCollection)StaffSalariesDataGridView.DataSource;
            executableDatabase.FactoryRunningCosts = (FiveValueCollection)FactoryRunningCostsDataGridView.DataSource;
            executableDatabase.FactoryExpansionCosts = (FiveRatingCollection)FactoryExpansionCostsDataGridView.DataSource;
            executableDatabase.TestingMiles = (TenValueCollection)TestingMilesDataGridView.DataSource;

            executableDatabase.RacePerformance = new RacePerformance
            {
                Values = _racePerformanceCurveChart.GetProposedSeries()
            };
        }

        private static void SwitchToForm(Form parentForm, Form childForm)
        {
            childForm.Show(parentForm);
            parentForm.Hide();
            childForm.FormClosing += delegate { parentForm.Show(); };
        }

        private static void UpdateDataGridViewColumnHeaders<T>(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                var properties = typeof(T).GetProperties();
                var property = properties.Single(x => x.Name == column.DataPropertyName);
                var attributes = property.GetCustomAttributes(true);
                foreach (var attribute in attributes)
                {
                    var displayAttribute = (DisplayAttribute)attribute;
                    if (displayAttribute != null)
                    {
                        // Update header text and tooltip text with attribute text
                        column.HeaderText = displayAttribute.GetName();
                        column.ToolTipText = displayAttribute.GetDescription();
                    }
                }
            }
        }
    }
}
