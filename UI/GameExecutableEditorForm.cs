using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Common.Extensions;
using Data.Collections.Executable.Supplier;
using Data.Collections.Executable.Team;
using Data.Collections.Executable.Track;
using Data.Collections.Generic;
using Data.Collections.Language;
using Data.Databases;
using Data.Entities.Executable.Race;
using Data.Entities.Executable.Supplier;
using Data.Entities.Executable.Team;
using Data.Entities.Executable.Track;
using Data.Entities.Generic;
using Data.Entities.Language;
using Data.FileConnection;
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
        private RacePerformanceCurveChart _racePerformanceCurveChart;
        private bool _isFailedValidationForSwitchingContext;
        private bool _isImportOccured;

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
            SubscribeDataGridViewControlsToGenericEvents();

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
            // TODO remove
            // If any data grids are in edit mode, prevent closure
            //if (IsDataGridViewControlsInEditMode())
            //{
            //    // Abort event
            //    ShowValidationError("Please confirm or reject your change to the selected cell, prior to closing the form.");
            //    e.Cancel = true;
            //    return;
            //}

            // TODO remove
            // If any data grid view controls on the form are in edit mode
            //if (CancelAndEndEditOnDataGridViewControls())
            //{
            //    // Abort event
            //    e.Cancel = true;
            //    return;
            //}

            if (_isFailedValidationForSwitchingContext)
            {
                // Abort event
                e.Cancel = true;
                _isFailedValidationForSwitchingContext = false; // Reset
                return;
            }

            if (!ConfirmCloseFormWithUnsavedChanges())
            {
                // Abort event
                e.Cancel = true;
                return;
            }

            // Save and close form
            Settings.Default.Save();
        }

        private void MainTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_isImportOccured)
            {
                // Abort event
                e.Cancel = true;
                ShowErrorMessageBox("Unable to switch tabs until a successful import has occurred.");
            }

            if (_isFailedValidationForSwitchingContext)
            {
                // Abort event
                e.Cancel = true;
                _isFailedValidationForSwitchingContext = false; // Reset
            }
        }

        private void BrowseLanguageFileButton_Click(object sender, EventArgs e)
        {
            // Prompt user to select file
            ProgramOpenFileDialog.InitialDirectory = Settings.Default.UserGameFolderPath;
            ProgramOpenFileDialog.FileName = null;
            var result = ProgramOpenFileDialog.ShowDialog();

            // Cancel if file was not selected
            if (result != DialogResult.OK)
            {
                return;
            }

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
            {
                return;
            }

            GameExecutablePathTextBox.Text = ProgramOpenFileDialog.FileName;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Import(LanguageFilePathTextBox.Text, GameExecutablePathTextBox.Text);
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (!_isImportOccured)
            {
                ShowErrorMessageBox("Unable to export until a successful import has occurred.");
                return;
            }

            Export(LanguageFilePathTextBox.Text, GameExecutablePathTextBox.Text);
        }

        private static void GenericDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;

            // If column header
            if (e.RowIndex < 0)
            {
                return;
            }

            // If combobox column
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                // Drop down the drop down
                dataGridView.BeginEdit(true);
                ((ComboBox)dataGridView.EditingControl).DroppedDown = true;
            }
        }

        private static void GenericDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void GenericDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            _isFailedValidationForSwitchingContext = false; // Reset

            // Get the type used in the collection that is assigned to the datasource of the datagridview
            // And invoke the named generic method, passing the required parameters to the generic method
            // http://stackoverflow.com/a/325161
            var dataGridView = (DataGridView)sender;
            var listItemType = ListBindingHelper.GetListItemType(dataGridView.DataSource);
            var methodInfo = typeof(GameExecutableEditorForm).GetMethod("ValidateDataGridViewCell", BindingFlags.NonPublic | BindingFlags.Instance);
            var genericMethod = methodInfo.MakeGenericMethod(listItemType);
            genericMethod.Invoke(this, new[] { sender, e });
        }

        private static void GenericDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
            ConfigureDataGridViewControl<NonF1Driver>(NonF1DriversDataGridView, 15);
            ConfigureDataGridViewControl<NonF1Chief>(NonF1ChiefsDataGridView, 16);
            ConfigureDataGridViewControl<Engine>(EnginesDataGridView, 3);
            ConfigureDataGridViewControl<Tyre>(TyresDataGridView, 4);
            ConfigureDataGridViewControl<Fuel>(FuelsDataGridView, 5);
            ConfigureDataGridViewControl<Track>(TracksDataGridView, 6);
            ConfigureDataGridViewControl<FiveValueBase>(FactoryRunningCostsDataGridView, 7, "Running Costs", true);
            ConfigureDataGridViewControl<FiveRatingBase>(FactoryExpansionCostsDataGridView, 8, "Expansion Costs", true);
            ConfigureDataGridViewControl<FiveRatingBase>(StaffEffortsDataGridView, 11, "Staff Efforts", true);
            ConfigureDataGridViewControl<FiveRatingBase>(StaffSalariesDataGridView, 9, "Staff Salaries", true);
            ConfigureDataGridViewControl<TenValueBase>(TestingMilesDataGridView, 10, "Testing Miles", true);
            ConfigureDataGridViewControl<TenValueBase>(EngineeringCostsDataGridView, 12, "Engineering Costs", true);
            ConfigureDataGridViewControl<SingleValueBase>(UnknownADataGridView, 13, "UnknownA", true);
            ConfigureDataGridViewControl<SingleValueBase>(UnknownBDataGridView, 14, "UnknownB", true);
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

            // Make primary column readonly
            dataGridView.Columns[$"resourceTextDataGridViewTextBoxColumn{columnId}"].ReadOnly = true;

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

        private static bool ConfirmCloseFormWithUnsavedChanges()
        {
            // Prompt user whether to close form
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
                _isImportOccured = true;
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
            NonF1DriversDataGridView.DataSource = executableDatabase.NonF1Drivers;
            NonF1ChiefsDataGridView.DataSource = executableDatabase.NonF1Chiefs;
            EnginesDataGridView.DataSource = executableDatabase.Engines;
            TyresDataGridView.DataSource = executableDatabase.Tyres;
            FuelsDataGridView.DataSource = executableDatabase.Fuels;
            TracksDataGridView.DataSource = executableDatabase.Tracks;
            FactoryRunningCostsDataGridView.DataSource = executableDatabase.FactoryRunningCosts;
            FactoryExpansionCostsDataGridView.DataSource = executableDatabase.FactoryExpansionCosts;
            StaffSalariesDataGridView.DataSource = executableDatabase.StaffSalaries;
            StaffEffortsDataGridView.DataSource = executableDatabase.StaffEfforts;
            TestingMilesDataGridView.DataSource = executableDatabase.TestingMiles;
            EngineeringCostsDataGridView.DataSource = executableDatabase.EngineeringCosts;
            UnknownADataGridView.DataSource = executableDatabase.UnknownAEfforts;
            UnknownBDataGridView.DataSource = executableDatabase.UnknownBEfforts;

            // Bind comboboxes to data
            // Hint: Requires the column type to be set at design time to ComboBoxColumn via DataGridView Tasks Wizard > Edit Columns... > ColumnType
            //       Requires a rename at design time of the column's Name property. Change the suffix TextBoxColumn to ComboBoxColumn to reflect the ColumnType.
            BindDataGridViewComboBoxColumn(TeamsDataGridView, "firstGpTrackDataGridViewComboBoxColumn", executableDatabase.FirstGpTrackLookups);
            BindDataGridViewComboBoxColumn(TeamsDataGridView, "tyreSupplierIdDataGridViewComboBoxColumn", executableDatabase.TyreSupplierIdAsSupplierIdLookups);
            BindDataGridViewComboBoxColumn(DriversDataGridView, "nationalityDataGridViewComboBoxColumn", executableDatabase.DriverNationalityLookups);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "designDataGridViewComboBoxColumn", executableDatabase.TrackDesignLookups);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "lapRecordDriverDataGridViewComboBoxColumn", executableDatabase.FastestLapDriverIdAsStaffIdLookups);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "lapRecordTeamDataGridViewComboBoxColumn", executableDatabase.Teams);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "lastRaceDriverDataGridViewComboBoxColumn", executableDatabase.FastestLapDriverIdAsStaffIdLookups);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "lastRaceTeamDataGridViewComboBoxColumn", executableDatabase.Teams);

            // Generate chart
            RacePerformanceDefaultCheckBox.Checked = true; // Reset
            RacePerformanceCurrentCheckBox.Checked = true; // Reset
            RacePerformanceProposedCheckBox.Checked = true; // Reset
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
            executableDatabase.NonF1Drivers = (NonF1DriverCollection)NonF1DriversDataGridView.DataSource;
            executableDatabase.NonF1Chiefs = (NonF1ChiefCollection)NonF1ChiefsDataGridView.DataSource;
            executableDatabase.Engines = (EngineCollection)EnginesDataGridView.DataSource;
            executableDatabase.Tyres = (TyreCollection)TyresDataGridView.DataSource;
            executableDatabase.Fuels = (FuelCollection)FuelsDataGridView.DataSource;
            executableDatabase.Tracks = (TrackCollection)TracksDataGridView.DataSource;

            executableDatabase.StaffEfforts = (FiveRatingCollection)StaffEffortsDataGridView.DataSource;
            executableDatabase.StaffSalaries = (FiveRatingCollection)StaffSalariesDataGridView.DataSource;
            executableDatabase.FactoryRunningCosts = (FiveValueCollection)FactoryRunningCostsDataGridView.DataSource;
            executableDatabase.FactoryExpansionCosts = (FiveRatingCollection)FactoryExpansionCostsDataGridView.DataSource;
            executableDatabase.TestingMiles = (TenValueCollection)TestingMilesDataGridView.DataSource;
            executableDatabase.EngineeringCosts = (TenValueCollection)EngineeringCostsDataGridView.DataSource;
            executableDatabase.UnknownAEfforts = (SingleValueCollection)UnknownADataGridView.DataSource;
            executableDatabase.UnknownBEfforts = (SingleValueCollection)UnknownBDataGridView.DataSource;

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

        private static void ShowErrorMessageBox(string message)
        {
            MessageBox.Show(message, Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SubscribeDataGridViewControlsToGenericEvents()
        {
            // Find all datagridview controls on form and subscribe them to their generic events
            foreach (var control in this.GetAllControlsOfType(typeof(DataGridView)))
            {
                ((DataGridView)control).DataError += GenericDataGridView_DataError;
                ((DataGridView)control).CellEnter += GenericDataGridView_CellEnter;
                ((DataGridView)control).CellLeave += GenericDataGridView_CellLeave;
                ((DataGridView)control).CellValidating += GenericDataGridView_CellValidating;
            }
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
                    var displayAttribute = attribute as DisplayAttribute;
                    if (displayAttribute != null)
                    {
                        // Update header text and tooltip text with attribute text
                        column.HeaderText = displayAttribute.GetName();
                        column.ToolTipText = displayAttribute.GetDescription();
                    }
                }
            }
        }

        // ReSharper disable once UnusedMember.Local
        private void ValidateDataGridViewCell<T>(DataGridView dataGridView, DataGridViewCellValidatingEventArgs e) where T : IIdentity
        {
            // Ignore validation on hidden columns
            if (e.ColumnIndex < 4)
            {
                return;
            }

            // Validate user editable columns
            var row = dataGridView.Rows[e.RowIndex];
            var column = dataGridView.Columns[e.ColumnIndex];
            var cell = row.Cells[e.ColumnIndex];
            var newValue = e.FormattedValue;
            var oldValue = cell.FormattedValue.ToString();

            var properties = typeof(T).GetProperties();
            var property = properties.Single(x => x.Name == column.DataPropertyName);
            var attributes = property.GetCustomAttributes(true);

            // If validating an integer field
            if (property.PropertyType == typeof(int))
            {
                // If combobox column, get value of selected item
                if (column is DataGridViewComboBoxColumn)
                {
                    foreach (var item in (column as DataGridViewComboBoxColumn).Items)
                    {
                        if (((IIdentity)item).ResourceText == newValue.ToString())
                        {
                            newValue = ((IIdentity)item).LocalResourceId;
                            break;
                        }
                    }
                }

                // Validate type
                int intValue;
                if (!int.TryParse(newValue.ToString(), out intValue))
                {
                    e.Cancel = true;
                    dataGridView.CancelEdit();
                    dataGridView.EndEdit();
                    _isFailedValidationForSwitchingContext = true;
                    ShowErrorMessageBox($"Value for {column.HeaderText} must be a whole number.");
                    return;
                }

                // Process attributes
                foreach (var attribute in attributes)
                {
                    // Validate range
                    var rangeAttribute = attribute as RangeAttribute;
                    if (rangeAttribute != null)
                    {
                        if ((intValue < (int)rangeAttribute.Minimum) || (intValue > (int)rangeAttribute.Maximum))
                        {
                            e.Cancel = true;
                            dataGridView.CancelEdit();
                            dataGridView.EndEdit();
                            _isFailedValidationForSwitchingContext = true;
                            ShowErrorMessageBox(rangeAttribute.FormatErrorMessage(column.HeaderText));
                            return;
                        }
                    }
                }

                // If combobox column, commit and end edit now that validation has been cleared
                if (column is DataGridViewComboBoxColumn)
                {
                    dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    dataGridView.EndEdit();
                }
            }
        }
    }
}
