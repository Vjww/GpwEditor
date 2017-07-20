using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Common.Extensions;
using Data.Collections.Language;
using Data.Databases;
using Data.Entities.Executable.Race;
using Data.Entities.Executable.Supplier;
using Data.Entities.Executable.Team;
using Data.Entities.Executable.Track;
using Data.Entities.Language;
using GpwEditor.Properties;
using Cursor = System.Windows.Forms.Cursor;

namespace GpwEditor.Views
{
    public partial class GameExecutableEditorForm : EditorForm
    {
        private bool _isFailedValidationForSwitchingContext;
        private bool _isImportOccurred;

        public GameExecutableEditorForm()
        {
            InitializeComponent();
        }

        private void GameExecutableEditorForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.icon1;
            Text = $"{Settings.Default.ApplicationName} - Game Executable Editor";
            ConvertLinesToRtf(OverviewRichTextBox);

            // Populate with most recently used (MRU) or default
            GameExecutablePathTextBox.Text = GetGameExecutableMruOrDefault();
            LanguageFilePathTextBox.Text = GetLanguageFileMruOrDefault();

            ConfigureControls();
            SubscribeDataGridViewControlsToGenericEvents();
        }

        private void GameExecutableEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isFailedValidationForSwitchingContext)
            {
                e.Cancel = true; // Abort event
                _isFailedValidationForSwitchingContext = false; // Reset
                return;
            }

            if (CloseFormConfirmation(true,
                $"Are you sure you wish to close the game executable editor?{Environment.NewLine}{Environment.NewLine}Any changes not exported will be lost."))
                return;
            e.Cancel = true; // Abort event
        }

        private void MainTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_isImportOccurred)
            {
                e.Cancel = true; // Abort event
                ShowMessageBox("Unable to switch tabs until a successful import has occurred.", MessageBoxIcon.Error);
            }

            if (_isFailedValidationForSwitchingContext)
            {
                e.Cancel = true; // Abort event
                _isFailedValidationForSwitchingContext = false; // Reset
            }
        }

        private void BrowseGameExecutableButton_Click(object sender, EventArgs e)
        {
            var result = GetGameExecutablePathFromOpenFileDialog();
            GameExecutablePathTextBox.Text = string.IsNullOrEmpty(result) ? GameExecutablePathTextBox.Text : result;
        }

        private void BrowseLanguageFileButton_Click(object sender, EventArgs e)
        {
            var result = GetLanguageFilePathFromOpenFileDialog();
            LanguageFilePathTextBox.Text = string.IsNullOrEmpty(result) ? LanguageFilePathTextBox.Text : result;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Import(GameExecutablePathTextBox.Text, LanguageFilePathTextBox.Text);
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (!_isImportOccurred)
            {
                ShowMessageBox("Unable to export until a successful import has occurred.", MessageBoxIcon.Error);
                return;
            }

            Export(GameExecutablePathTextBox.Text, LanguageFilePathTextBox.Text);
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
            // Configure data grid view controls
            ConfigureDataGridViewControl<Team>(TeamsDataGridView, 1);
            ConfigureDataGridViewControl<F1ChiefCommercial>(ChiefsF1CommerceDataGridView, 2);
            ConfigureDataGridViewControl<F1ChiefDesigner>(ChiefsF1DesignerDataGridView, 3);
            ConfigureDataGridViewControl<F1ChiefEngineer>(ChiefsF1EngineerDataGridView, 4);
            ConfigureDataGridViewControl<F1ChiefMechanic>(ChiefsF1MechanicDataGridView, 5);
            ConfigureDataGridViewControl<NonF1ChiefCommercial>(ChiefsNonF1CommerceDataGridView, 6);
            ConfigureDataGridViewControl<NonF1ChiefDesigner>(ChiefsNonF1DesignerDataGridView, 7);
            ConfigureDataGridViewControl<NonF1ChiefEngineer>(ChiefsNonF1EngineerDataGridView, 8);
            ConfigureDataGridViewControl<NonF1ChiefMechanic>(ChiefsNonF1MechanicDataGridView, 9);
            ConfigureDataGridViewControl<F1Driver>(DriversF1DataGridView, 10);
            ConfigureDataGridViewControl<NonF1Driver>(DriversNonF1DataGridView, 11);
            ConfigureDataGridViewControl<Engine>(SuppliersEnginesDataGridView, 12);
            ConfigureDataGridViewControl<Tyre>(SuppliersTyresDataGridView, 13);
            ConfigureDataGridViewControl<Fuel>(SuppliersFuelsDataGridView, 14);
            ConfigureDataGridViewControl<Track>(TracksDataGridView, 15);
            ConfigureDataGridViewControl<ChassisHandling>(ChassisHandlingDataGridView, 16);
            //TODO ConfigureDataGridViewControl<FiveValueBase>(FactoryRunningCostsDataGridView, 0, "Running Costs", true);
            //TODO ConfigureDataGridViewControl<FiveRatingBase>(FactoryExpansionCostsDataGridView, 0, "Expansion Costs", true);
            //TODO ConfigureDataGridViewControl<FiveRatingBase>(StaffEffortsDataGridView, 0, "Staff Efforts", true);
            //TODO ConfigureDataGridViewControl<FiveRatingBase>(StaffSalariesDataGridView, 0, "Staff Salaries", true);
            //TODO ConfigureDataGridViewControl<TenValueBase>(TestingMilesDataGridView, 0, "Testing Miles", true);
            //TODO ConfigureDataGridViewControl<TenValueBase>(EngineeringCostsDataGridView, 0, "Engineering Costs", true);
            //TODO ConfigureDataGridViewControl<SingleValueBase>(UnknownADataGridView, 0, "UnknownA", true);
            //TODO ConfigureDataGridViewControl<SingleValueBase>(UnknownBDataGridView, 0, "UnknownB", true);
        }

        // ReSharper disable once UnusedMember.Local
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

        private void Export(string gameExecutablePath, string languageFilePath)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Fill database with data from controls and export to file
                var database = new ExecutableDatabase();
                PopulateRecords(database);
                database.ExportDataToFile(gameExecutablePath, languageFilePath);
            }
            catch (Exception ex)
            {
                ShowMessageBox(
                    $"An error has occured. Process aborted.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
                    MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            MessageBox.Show("Export complete!", Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Import(string gameExecutablePath, string languageFilePath)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Import from file to database and fill controls with data
                var database = new ExecutableDatabase();
                database.ImportDataFromFile(gameExecutablePath, languageFilePath);
                PopulateControls(database);
                _isImportOccurred = true;
            }
            catch (Exception ex)
            {
                ShowMessageBox(
                    $"An error has occured. Process aborted.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
                    MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            ShowMessageBox("Import complete!");
        }

        private void PopulateControls(ExecutableDatabase database)
        {
            // Move data from database into controls
            LanguageDataGridView.DataSource = database.LanguageStrings;
            TeamsDataGridView.DataSource = database.Teams;
            ChiefsF1CommerceDataGridView.DataSource = database.F1ChiefCommercials;
            ChiefsF1DesignerDataGridView.DataSource = database.F1ChiefDesigners;
            ChiefsF1EngineerDataGridView.DataSource = database.F1ChiefEngineers;
            ChiefsF1MechanicDataGridView.DataSource = database.F1ChiefMechanics;
            ChiefsNonF1CommerceDataGridView.DataSource = database.NonF1ChiefCommercials;
            ChiefsNonF1DesignerDataGridView.DataSource = database.NonF1ChiefDesigners;
            ChiefsNonF1EngineerDataGridView.DataSource = database.NonF1ChiefEngineers;
            ChiefsNonF1MechanicDataGridView.DataSource = database.NonF1ChiefMechanics;
            DriversF1DataGridView.DataSource = database.F1Drivers;
            DriversNonF1DataGridView.DataSource = database.NonF1Drivers;
            SuppliersEnginesDataGridView.DataSource = database.Engines;
            SuppliersTyresDataGridView.DataSource = database.Tyres;
            SuppliersFuelsDataGridView.DataSource = database.Fuels;
            TracksDataGridView.DataSource = database.Tracks;
            ChassisHandlingDataGridView.DataSource = database.ChassisHandlings;
            //TODO FactoryRunningCostsDataGridView.DataSource = database.FactoryRunningCosts;
            //TODO FactoryExpansionCostsDataGridView.DataSource = database.FactoryExpansionCosts;
            //TODO StaffSalariesDataGridView.DataSource = database.StaffSalaries;
            //TODO StaffEffortsDataGridView.DataSource = database.StaffEfforts;
            //TODO TestingMilesDataGridView.DataSource = database.TestingMiles;
            //TODO EngineeringCostsDataGridView.DataSource = database.EngineeringCosts;
            //TODO UnknownADataGridView.DataSource = database.UnknownAEfforts;
            //TODO UnknownBDataGridView.DataSource = database.UnknownBEfforts;

            // Bind comboboxes to data
            // Hint: Requires the column type to be set at design time to ComboBoxColumn via DataGridView Tasks Wizard > Edit Columns... > ColumnType
            //       Requires a rename at design time of the column's Name property. Change the suffix TextBoxColumn to ComboBoxColumn to reflect the ColumnType.
            BindDataGridViewComboBoxColumn(TeamsDataGridView, "firstGpTrackDataGridViewComboBoxColumn", database.FirstGpTrackLookups);
            BindDataGridViewComboBoxColumn(TeamsDataGridView, "tyreSupplierIdDataGridViewComboBoxColumn", database.TyreSupplierIdAsSupplierIdLookups);
            BindDataGridViewComboBoxColumn(ChiefsF1DesignerDataGridView, "driverLoyaltyDataGridViewComboBoxColumn", database.DriverLoyaltyDriverIdAsStaffIdLookups);
            BindDataGridViewComboBoxColumn(ChiefsF1EngineerDataGridView, "driverLoyaltyDataGridViewComboBoxColumn1", database.DriverLoyaltyDriverIdAsStaffIdLookups);
            BindDataGridViewComboBoxColumn(ChiefsF1MechanicDataGridView, "driverLoyaltyDataGridViewComboBoxColumn2", database.DriverLoyaltyDriverIdAsStaffIdLookups);
            BindDataGridViewComboBoxColumn(DriversF1DataGridView, "nationalityDataGridViewComboBoxColumn", database.DriverNationalityLookups);
            BindDataGridViewComboBoxColumn(DriversNonF1DataGridView, "nationalityDataGridViewComboBoxColumn1", database.DriverNationalityLookups);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "designDataGridViewComboBoxColumn", database.TrackDesignLookups);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "lapRecordDriverDataGridViewComboBoxColumn", database.FastestLapDriverIdAsStaffIdLookups);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "lapRecordTeamDataGridViewComboBoxColumn", database.Teams);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "lastRaceDriverDataGridViewComboBoxColumn", database.FastestLapDriverIdAsStaffIdLookups);
            BindDataGridViewComboBoxColumn(TracksDataGridView, "lastRaceTeamDataGridViewComboBoxColumn", database.Teams);
        }

        private void PopulateRecords(ExecutableDatabase database)
        {
            // Move data from controls into database
            database.LanguageStrings = (IdentityCollection)LanguageDataGridView.DataSource;
            database.Teams = (Collection<Team>)TeamsDataGridView.DataSource;
            database.F1ChiefCommercials = (Collection<F1ChiefCommercial>)ChiefsF1CommerceDataGridView.DataSource;
            database.F1ChiefDesigners = (Collection<F1ChiefDesigner>)ChiefsF1DesignerDataGridView.DataSource;
            database.F1ChiefEngineers = (Collection<F1ChiefEngineer>)ChiefsF1EngineerDataGridView.DataSource;
            database.F1ChiefMechanics = (Collection<F1ChiefMechanic>)ChiefsF1MechanicDataGridView.DataSource;
            database.NonF1ChiefCommercials = (Collection<NonF1ChiefCommercial>)ChiefsNonF1CommerceDataGridView.DataSource;
            database.NonF1ChiefDesigners = (Collection<NonF1ChiefDesigner>)ChiefsNonF1DesignerDataGridView.DataSource;
            database.NonF1ChiefEngineers = (Collection<NonF1ChiefEngineer>)ChiefsNonF1EngineerDataGridView.DataSource;
            database.NonF1ChiefMechanics = (Collection<NonF1ChiefMechanic>)ChiefsNonF1MechanicDataGridView.DataSource;
            database.F1Drivers = (Collection<F1Driver>)DriversF1DataGridView.DataSource;
            database.NonF1Drivers = (Collection<NonF1Driver>)DriversNonF1DataGridView.DataSource;
            database.Engines = (Collection<Engine>)SuppliersEnginesDataGridView.DataSource;
            database.Tyres = (Collection<Tyre>)SuppliersTyresDataGridView.DataSource;
            database.Fuels = (Collection<Fuel>)SuppliersFuelsDataGridView.DataSource;
            database.Tracks = (Collection<Track>)TracksDataGridView.DataSource;
            database.ChassisHandlings = (Collection<ChassisHandling>)ChassisHandlingDataGridView.DataSource;
            // TODO database.StaffEfforts = (FiveRatingCollection)StaffEffortsDataGridView.DataSource;
            // TODO database.StaffSalaries = (FiveRatingCollection)StaffSalariesDataGridView.DataSource;
            // TODO database.FactoryRunningCosts = (FiveValueCollection)FactoryRunningCostsDataGridView.DataSource;
            // TODO database.FactoryExpansionCosts = (FiveRatingCollection)FactoryExpansionCostsDataGridView.DataSource;
            // TODO database.TestingMiles = (TenValueCollection)TestingMilesDataGridView.DataSource;
            // TODO database.EngineeringCosts = (TenValueCollection)EngineeringCostsDataGridView.DataSource;
            // TODO database.UnknownAEfforts = (SingleValueCollection)UnknownADataGridView.DataSource;
            // TODO database.UnknownBEfforts = (SingleValueCollection)UnknownBDataGridView.DataSource;
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
                    ShowMessageBox($"Value for {column.HeaderText} must be a whole number.", MessageBoxIcon.Error);
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
                            ShowMessageBox(rangeAttribute.FormatErrorMessage(column.HeaderText), MessageBoxIcon.Error);
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