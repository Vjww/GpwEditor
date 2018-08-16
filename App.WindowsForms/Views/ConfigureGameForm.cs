using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using App.BaseGameEditor.Domain.Entities;
using App.WindowsForms.Charts;
using App.WindowsForms.Controllers;
using App.WindowsForms.Enums;
using App.WindowsForms.Factories;
using App.WindowsForms.Models;
using App.WindowsForms.Properties;

//using Data;
//using Data.Collections.Language;
//using Data.Databases;
//using Data.Entities.Commentary;
//using Data.Entities.Executable.Race;
//using Data.Entities.Generic;

namespace App.WindowsForms.Views
{
    public partial class ConfigureGameForm : EditorForm
    {
        private ConfigureGameController _controller;
        private readonly PerformanceCurveChart _performanceCurveChart;
        private bool _isImportOccurred;
        private bool _isModified;

        #region ToolTip Declarations
        private const string ReadOnlyToolTipText = " This field is read only.";

        private const string CommentaryIndicesDriverIdToolTipText = "The id of the driver commentary index record.";
        private const string CommentaryIndicesDriverNameToolTipText = "The name of the driver." + ReadOnlyToolTipText;
        private const string CommentaryIndicesDriverCommentaryIndexToolTipText = "The index of the commentary transcript to use for the driver.";

        private const string CommentaryIndicesTeamIdToolTipText = "The id of the team commentary index record.";
        private const string CommentaryIndicesTeamNameToolTipText = "The name of the team." + ReadOnlyToolTipText;
        private const string CommentaryIndicesTeamCommentaryIndexToolTipText = "The index of the commentary transcript to use for the team.";

        private const string CommentaryPrefixesDriverIdToolTipText = "The id of the commentary prefix driver record.";
        private const string CommentaryPrefixesDriverCommentaryIndexToolTipText = "The index of the commentary transcript." + ReadOnlyToolTipText;
        private const string CommentaryPrefixesDriverFileNamePrefixToolTipText = "The prefix used to build the filename of the sound file associated with the commentary index.";

        private const string CommentaryPrefixesTeamIdToolTipText = "The id of the commentary prefix team record.";
        private const string CommentaryPrefixesTeamCommentaryIndexToolTipText = "The index of the commentary transcript." + ReadOnlyToolTipText;
        private const string CommentaryPrefixesTeamFileNamePrefixToolTipText = "The prefix used to build the filename of the sound file associated with the commentary index.";

        private const string CommentaryFileIdToolTipText = "The id of the commentary file record.";
        private const string CommentaryFileFileNameToolTipText = "The file name of the commentary sound." + ReadOnlyToolTipText;
        #endregion

        public string GameFolderPath { get => GameFolderPathTextBox.Text; set => GameFolderPathTextBox.Text = value; }
        public string GameExecutableFilePath { get => GameExecutablePathTextBox.Text; set => GameExecutablePathTextBox.Text = value; }
        public string EnglishLanguageFilePath { get => EnglishLanguageFilePathTextBox.Text; set => EnglishLanguageFilePathTextBox.Text = value; }
        public string FrenchLanguageFilePath { get => FrenchLanguageFilePathTextBox.Text; set => FrenchLanguageFilePathTextBox.Text = value; }
        public string GermanLanguageFilePath { get => GermanLanguageFilePathTextBox.Text; set => GermanLanguageFilePathTextBox.Text = value; }
        public string EnglishCommentaryFilePath { get => EnglishCommentaryFilePathTextBox.Text; set => EnglishCommentaryFilePathTextBox.Text = value; }
        public string FrenchCommentaryFilePath { get => FrenchCommentaryFilePathTextBox.Text; set => FrenchCommentaryFilePathTextBox.Text = value; }
        public string GermanCommentaryFilePath { get => GermanCommentaryFilePathTextBox.Text; set => GermanCommentaryFilePathTextBox.Text = value; }

        public bool DisableGameCd { get => DisableGameCdCheckBox.Checked; set => DisableGameCdCheckBox.Checked = value; }
        public bool DisableColourMode { get => DisableColourModeCheckBox.Checked; set => DisableColourModeCheckBox.Checked = value; }
        public bool DisableSampleApp { get => DisableSampleAppCheckBox.Checked; set => DisableSampleAppCheckBox.Checked = value; }
        public bool DisableMemoryResetForRaceSounds { get => DisableMemoryResetForRaceSoundsCheckBox.Checked; set => DisableMemoryResetForRaceSoundsCheckBox.Checked = value; }
        public bool DisablePitExitPriority { get => DisablePitExitPriorityCheckBox.Checked; set => DisablePitExitPriorityCheckBox.Checked = value; }
        public bool DisableYellowFlagPenalties { get => DisableYellowFlagPenaltiesCheckBox.Checked; set => DisableYellowFlagPenaltiesCheckBox.Checked = value; }
        public bool EnableCarHandlingDesignCalculation { get => EnableCarHandlingDesignCalculationCheckBox.Checked; set => EnableCarHandlingDesignCalculationCheckBox.Checked = value; }
        public bool EnableCarPerformanceRaceCalcuation { get => EnableCarPerformanceRaceCalcuationCheckBox.Checked; set => EnableCarPerformanceRaceCalcuationCheckBox.Checked = value; }
        public bool PointsScoringSystemDefault { get => PointsScoringSystemDefaultRadioButton.Checked; set => PointsScoringSystemDefaultRadioButton.Checked = value; }
        public bool PointsScoringSystemOption1 { get => PointsScoringSystemOption1RadioButton.Checked; set => PointsScoringSystemOption1RadioButton.Checked = value; }
        public bool PointsScoringSystemOption2 { get => PointsScoringSystemOption2RadioButton.Checked; set => PointsScoringSystemOption2RadioButton.Checked = value; }
        public bool PointsScoringSystemOption3 { get => PointsScoringSystemOption3RadioButton.Checked; set => PointsScoringSystemOption3RadioButton.Checked = value; }

        public IEnumerable<CommentaryIndexDriverModel> CommentaryIndexDrivers
        {
            get => (IEnumerable<CommentaryIndexDriverModel>)CommentaryIndicesDriverDataGridView.DataSource;
            set => BuildCommentaryIndicesDriverDataGridView(value);
        }

        public IEnumerable<CommentaryIndexTeamModel> CommentaryIndexTeams
        {
            get => (IEnumerable<CommentaryIndexTeamModel>)CommentaryIndicesTeamDataGridView.DataSource;
            set => BuildCommentaryIndicesTeamDataGridView(value);
        }

        public IEnumerable<CommentaryPrefixDriverModel> CommentaryPrefixDrivers
        {
            get => (IEnumerable<CommentaryPrefixDriverModel>)CommentaryPrefixesDriverDataGridView.DataSource;
            set => BuildCommentaryPrefixesDriverDataGridView(value);
        }

        public IEnumerable<CommentaryPrefixTeamModel> CommentaryPrefixTeams
        {
            get => (IEnumerable<CommentaryPrefixTeamModel>)CommentaryPrefixesTeamDataGridView.DataSource;
            set => BuildCommentaryPrefixesTeamDataGridView(value);
        }

        public IEnumerable<CommentaryFileModel> CommentaryFiles
        {
            get => (IEnumerable<CommentaryFileModel>)CommentaryFilesDataGridView.DataSource;
            set => BuildCommentaryFilesDataGridView(value);
        }

        public IEnumerable<PerformanceCurveModel> PerformanceCurves
        {
            get => ConvertPerformanceCurveArrayToDataSource();
            set => BuildPerformanceCurveChart(value);
        }

        public ConfigureGameForm(PerformanceCurveChart performanceCurveChart)
        {
            _performanceCurveChart = performanceCurveChart;

            InitializeComponent();
        }

        public void SetController(ConfigureGameController controller)
        {
            _controller = controller;
        }

        private void BuildCommentaryIndicesDriverDataGridView(IEnumerable<CommentaryIndexDriverModel> dataSource)
        {
            ResetDataGridView(CommentaryIndicesDriverDataGridView);

            AddColumnToDataGridView(CommentaryIndicesDriverDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", CommentaryIndicesDriverIdToolTipText, false));
            AddColumnToDataGridView(CommentaryIndicesDriverDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", CommentaryIndicesDriverNameToolTipText, true, true));
            AddColumnToDataGridView(CommentaryIndicesDriverDataGridView, CreateDataGridViewTextBoxColumn("CommentaryIndex", "Commentary Index", CommentaryIndicesDriverCommentaryIndexToolTipText));

            BindDataGridViewToDataSource(CommentaryIndicesDriverDataGridView, dataSource);

            ConfigureDataGridView(CommentaryIndicesDriverDataGridView, "Name");
        }

        private void BuildCommentaryIndicesTeamDataGridView(IEnumerable<CommentaryIndexTeamModel> dataSource)
        {
            ResetDataGridView(CommentaryIndicesTeamDataGridView);

            AddColumnToDataGridView(CommentaryIndicesTeamDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", CommentaryIndicesTeamIdToolTipText, false));
            AddColumnToDataGridView(CommentaryIndicesTeamDataGridView, CreateDataGridViewTextBoxColumn("Name", "Name", CommentaryIndicesTeamNameToolTipText, true, true));
            AddColumnToDataGridView(CommentaryIndicesTeamDataGridView, CreateDataGridViewTextBoxColumn("CommentaryIndex", "Commentary Index", CommentaryIndicesTeamCommentaryIndexToolTipText));

            BindDataGridViewToDataSource(CommentaryIndicesTeamDataGridView, dataSource);

            ConfigureDataGridView(CommentaryIndicesTeamDataGridView, "Name");
        }

        private void BuildCommentaryPrefixesDriverDataGridView(IEnumerable<CommentaryPrefixDriverModel> dataSource)
        {
            ResetDataGridView(CommentaryPrefixesDriverDataGridView);

            AddColumnToDataGridView(CommentaryPrefixesDriverDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", CommentaryPrefixesDriverIdToolTipText, false));
            AddColumnToDataGridView(CommentaryPrefixesDriverDataGridView, CreateDataGridViewTextBoxColumn("CommentaryIndex", "Commentary Index", CommentaryPrefixesDriverCommentaryIndexToolTipText, true, true));
            AddColumnToDataGridView(CommentaryPrefixesDriverDataGridView, CreateDataGridViewTextBoxColumn("FileNamePrefix", "Filename Prefix", CommentaryPrefixesDriverFileNamePrefixToolTipText));

            BindDataGridViewToDataSource(CommentaryPrefixesDriverDataGridView, dataSource);

            ConfigureDataGridView(CommentaryPrefixesDriverDataGridView, "CommentaryIndex");
        }

        private void BuildCommentaryPrefixesTeamDataGridView(IEnumerable<CommentaryPrefixTeamModel> dataSource)
        {
            ResetDataGridView(CommentaryPrefixesTeamDataGridView);

            AddColumnToDataGridView(CommentaryPrefixesTeamDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", CommentaryPrefixesTeamIdToolTipText, false));
            AddColumnToDataGridView(CommentaryPrefixesTeamDataGridView, CreateDataGridViewTextBoxColumn("CommentaryIndex", "Commentary Index", CommentaryPrefixesTeamCommentaryIndexToolTipText, true, true));
            AddColumnToDataGridView(CommentaryPrefixesTeamDataGridView, CreateDataGridViewTextBoxColumn("FileNamePrefix", "Filename Prefix", CommentaryPrefixesTeamFileNamePrefixToolTipText));

            BindDataGridViewToDataSource(CommentaryPrefixesTeamDataGridView, dataSource);

            ConfigureDataGridView(CommentaryPrefixesTeamDataGridView, "CommentaryIndex");
        }

        private void BuildCommentaryFilesDataGridView(IEnumerable<CommentaryFileModel> dataSource)
        {
            ResetDataGridView(CommentaryFilesDataGridView);

            AddColumnToDataGridView(CommentaryFilesDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", CommentaryFileIdToolTipText, false));
            AddColumnToDataGridView(CommentaryFilesDataGridView, CreateDataGridViewTextBoxColumn("FileName", "Filename", CommentaryFileFileNameToolTipText, true, true));

            BindDataGridViewToDataSource(CommentaryFilesDataGridView, dataSource);

            ConfigureDataGridView(CommentaryFilesDataGridView, "FileName");
        }

        private void BuildPerformanceCurveChart(IEnumerable<PerformanceCurveModel> dataSource)
        {
            var currentSeriesValues = ConvertPerformanceCurveDataSourceToArray(dataSource);

            PerformanceCurveDefaultCheckBox.Checked = true; // Reset
            PerformanceCurveCurrentCheckBox.Checked = true; // Reset
            PerformanceCurveProposedCheckBox.Checked = true; // Reset
            _performanceCurveChart.GenerateChart();
            _performanceCurveChart.SetCurrentSeries(currentSeriesValues);
            _performanceCurveChart.SetProposedSeriesToCurrentSeries();
            PerformanceCurveControlsGroupBox.Visible = true;
        }

        private static int[] ConvertPerformanceCurveDataSourceToArray(IEnumerable<PerformanceCurveModel> dataSource)
        {
            var performanceCurveValues = dataSource.ToList();
            var result = new int[performanceCurveValues.Count];
            var counter = 0;
            foreach (var item in performanceCurveValues)
            {
                result[counter] = item.Value;
                counter++;
            }

            return result;
        }

        private IEnumerable<PerformanceCurveModel> ConvertPerformanceCurveArrayToDataSource()
        {
            var result = new List<PerformanceCurveModel>();

            var counter = 0;
            foreach (var item in _performanceCurveChart.GetProposedSeries())
            {
                result.Add(new PerformanceCurveModel { Id = counter, Value = item });
                counter++;
            }

            return result;
        }

        private void ConfigureGameForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.icon1;
            Text = $"{Settings.Default.ApplicationName} - Configure Game";
            ConvertLinesToRtf(OverviewRichTextBox);

            // Populate paths with most recently used (MRU) or default
            GameFolderPath = GetGameFolderMruOrDefault();
            GameExecutableFilePath = GetGameExecutableMruOrDefault();
            EnglishLanguageFilePath = GetEnglishLanguageFileMruOrDefault();
            FrenchLanguageFilePath = GetFrenchLanguageFileMruOrDefault();
            GermanLanguageFilePath = GetGermanLanguageFileMruOrDefault();
            EnglishCommentaryFilePath = GetEnglishCommentaryFileMruOrDefault();
            FrenchCommentaryFilePath = GetFrenchCommentaryFileMruOrDefault();
            GermanCommentaryFilePath = GetGermanCommentaryFileMruOrDefault();

            // Set modified as default
            _isModified = true;

            GenerateTooltips();
            _performanceCurveChart.SetChart(PerformanceCurveChart);
            DisablePitExitPriorityCheckBox.Visible = false;

            InitialisePerformanceCurve(); // TODO: May become redundant once grids are manually built

#if DEBUG
            LanguageDataGridView.Visible = true; // TODO: Grid might become redundant now due to new domain model?
            CommentaryResourcesDataGridView.Visible = true; // TODO: Grid might become redundant now due to new domain model?
#endif
        }

        private void ConfigureGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseFormConfirmation(_isModified, $"Are you sure you wish to close this window?{Environment.NewLine}{Environment.NewLine}Any changes not exported will be lost."))
            {
                return;
            }

            e.Cancel = true; // Abort event
        }

        private void ConfigureGameTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_isImportOccurred)
            {
                e.Cancel = true; // Abort event
                ShowMessageBox("Unable to switch tabs until a successful import has occurred.", MessageBoxIcon.Error);
            }
        }

        private void GameFolderPathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetGameFolderPathFromFolderBrowserDialog();
            GameFolderPath = string.IsNullOrEmpty(result) ? GameFolderPath : result;
        }

        private void GameExecutablePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetGameExecutablePathFromOpenFileDialog();
            GameExecutableFilePath = string.IsNullOrEmpty(result) ? GameExecutableFilePath : result;
        }

        private void EnglishLanguageFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetEnglishLanguageFilePathFromOpenFileDialog();
            EnglishLanguageFilePath = string.IsNullOrEmpty(result) ? EnglishLanguageFilePath : result;
        }

        private void FrenchLanguageFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetFrenchLanguageFilePathFromOpenFileDialog();
            FrenchLanguageFilePath = string.IsNullOrEmpty(result) ? FrenchLanguageFilePath : result;
        }

        private void GermanLanguageFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetGermanLanguageFilePathFromOpenFileDialog();
            GermanLanguageFilePath = string.IsNullOrEmpty(result) ? GermanLanguageFilePath : result;
        }

        private void EnglishCommentaryFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetEnglishCommentaryFilePathFromOpenFileDialog();
            EnglishCommentaryFilePath = string.IsNullOrEmpty(result) ? EnglishCommentaryFilePath : result;
        }

        private void FrenchCommentaryFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetFrenchCommentaryFilePathFromOpenFileDialog();
            FrenchCommentaryFilePath = string.IsNullOrEmpty(result) ? FrenchCommentaryFilePath : result;
        }

        private void GermanCommentaryFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetGermanCommentaryFilePathFromOpenFileDialog();
            GermanCommentaryFilePath = string.IsNullOrEmpty(result) ? GermanCommentaryFilePath : result;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (!_isImportOccurred)
            {
                ShowMessageBox("Unable to export until a successful import has occurred.", MessageBoxIcon.Error);
                return;
            }

            Export();
        }

        private void CommentaryIndicesDefaultButton_Click(object sender, EventArgs e)
        {
            _controller.UpdateCommentaryModelWithDriverIndicesFromOriginalValues(); // TODO: Separate buttons?
            _controller.UpdateCommentaryModelWithTeamIndicesFromOriginalValues();   // TODO: Separate buttons?
        }

        private void CommentaryDriversDefaultButton_Click(object sender, EventArgs e)
        {
            _controller.UpdateCommentaryModelWithDriverPrefixesFromOriginalValues();
        }

        private void CommentaryDriversAnonymousButton_Click(object sender, EventArgs e)
        {
            _controller.UpdateCommentaryModelWithDriverPrefixesFromAnonymousValues();
        }

        private void CommentaryTeamsDefaultButton_Click(object sender, EventArgs e)
        {
            _controller.UpdateCommentaryModelWithTeamPrefixesFromOriginalValues();
        }

        private void CommentaryTeamsAnonymousButton_Click(object sender, EventArgs e)
        {
            _controller.UpdateCommentaryModelWithTeamPrefixesFromAnonymousValues();
        }

        // TODO: Review below methods

        private void PerformanceCurveNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            var numericUpDownControl = (NumericUpDown)sender;

            // Get position in curve to change
            var position = int.Parse(numericUpDownControl.Tag.ToString());

            // Determine change in direction
            if (numericUpDownControl.Value > 0)
            {
                _performanceCurveChart.AdjustCurve(position, NumericUpDownDirectionType.Up);
            }
            else if (numericUpDownControl.Value < 0)
            {
                _performanceCurveChart.AdjustCurve(position, NumericUpDownDirectionType.Down);
            }

            // Reset control
            numericUpDownControl.ValueChanged -= PerformanceCurveNumericUpDown_ValueChanged;
            numericUpDownControl.Value = 0;
            numericUpDownControl.ValueChanged += PerformanceCurveNumericUpDown_ValueChanged;
        }

        private void PerformanceCurveEditButton_Click(object sender, EventArgs e)
        {
            _controller.RunEditPerformanceCurveForm();
        }

        private void PerformanceCurveSoftenCurveButton_Click(object sender, EventArgs e)
        {
            _performanceCurveChart.SoftenCurve();
        }

        private void PerformanceCurveCopyDefaultButton_Click(object sender, EventArgs e)
        {
            _performanceCurveChart.ResetCurveToDefault();
        }

        private void PerformanceCurveCopyCurrentButton_Click(object sender, EventArgs e)
        {
            _performanceCurveChart.ResetCurveToCurrent();
        }

        private void PerformanceCurveCopyRecommendedButton_Click(object sender, EventArgs e)
        {
            _performanceCurveChart.ResetCurveToRecommended();
        }

        private void PerformanceCurveDefaultCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If has been unchecked
            if (!PerformanceCurveDefaultCheckBox.Checked)
            {
                // And at least one other is checked
                if (PerformanceCurveCurrentCheckBox.Checked || PerformanceCurveProposedCheckBox.Checked)
                {
                    _performanceCurveChart.ToggleDefaultSeries();
                    return;
                }

                // Else prevent uncheck by checking (and prevent event from firing)
                PerformanceCurveDefaultCheckBox.CheckedChanged -= PerformanceCurveDefaultCheckBox_CheckedChanged;
                PerformanceCurveDefaultCheckBox.Checked = true;
                PerformanceCurveDefaultCheckBox.CheckedChanged += PerformanceCurveDefaultCheckBox_CheckedChanged;
                return;
            }

            _performanceCurveChart.ToggleDefaultSeries();
        }

        private void PerformanceCurveCurrentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If has been unchecked
            if (!PerformanceCurveCurrentCheckBox.Checked)
            {
                // And at least one other is checked
                if (PerformanceCurveDefaultCheckBox.Checked || PerformanceCurveProposedCheckBox.Checked)
                {
                    _performanceCurveChart.ToggleCurrentSeries();
                    return;
                }

                // Else prevent uncheck by checking (and prevent event from firing)
                PerformanceCurveCurrentCheckBox.CheckedChanged -= PerformanceCurveCurrentCheckBox_CheckedChanged;
                PerformanceCurveCurrentCheckBox.Checked = true;
                PerformanceCurveCurrentCheckBox.CheckedChanged += PerformanceCurveCurrentCheckBox_CheckedChanged;
                return;
            }

            _performanceCurveChart.ToggleCurrentSeries();
        }

        private void PerformanceCurveProposedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If has been unchecked
            if (!PerformanceCurveProposedCheckBox.Checked)
            {
                // And at least one other is checked
                if (PerformanceCurveDefaultCheckBox.Checked || PerformanceCurveCurrentCheckBox.Checked)
                {
                    _performanceCurveChart.ToggleProposedSeries();
                    return;
                }

                // Else prevent uncheck by checking (and prevent event from firing)
                PerformanceCurveProposedCheckBox.CheckedChanged -= PerformanceCurveProposedCheckBox_CheckedChanged;
                PerformanceCurveProposedCheckBox.Checked = true;
                PerformanceCurveProposedCheckBox.CheckedChanged += PerformanceCurveProposedCheckBox_CheckedChanged;
                return;
            }

            _performanceCurveChart.ToggleProposedSeries();
        }

        private void Export()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                /* TODO: This block is all old code that can likely be removed, could use code as reference
                    // Fill database with data from controls and export to file
                    var database = new ConfigureGameDatabase();
                    PopulateRecords(database);
                    database.ExportDataToFile(gameFolderPath, gameExecutablePath, languageFilePath);
                    
                    // Update chart
                    _performanceCurveChart.SetCurrentSeriesToProposedSeries(); // Note: implemented below
                */

                _controller.Export();

                // Update chart
                _performanceCurveChart.SetCurrentSeriesToProposedSeries();
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

            ShowMessageBox("Export complete!");
        }

        private void GenerateTooltips()
        {
            var toolTip = new ToolTip();

            // Peformance Curve controls
            toolTip.SetToolTip(PerformanceCurveDefaultCheckBox, $"Show/Hide the curve that represents the performance levels defined in v1.01b of {Settings.Default.GameName}.");
            toolTip.SetToolTip(PerformanceCurveCurrentCheckBox, $"Show/Hide the curve that is currently applied in the imported {Settings.Default.DefaultGameExecutableName} game executable file.");
            toolTip.SetToolTip(PerformanceCurveProposedCheckBox, $"Show/Hide the curve that is proposed for export to a {Settings.Default.DefaultGameExecutableName} game executable file.");
            toolTip.SetToolTip(PerformanceCurveEditButton, "Opens a window to access and edit the raw data that makes up the Proposed curve.");
            toolTip.SetToolTip(PerformanceCurveSoftenCurveButton, "Softens the peaks and troughs of the Proposed curve using a simple moving average formula.");
            toolTip.SetToolTip(PerformanceCurveCopyDefaultButton, $"Copies the curve that represents the performance levels defined in v1.01b of {Settings.Default.GameName}.");
            toolTip.SetToolTip(PerformanceCurveCopyCurrentButton, $"Copies the curve that is currently applied in the imported {Settings.Default.DefaultGameExecutableName} game executable file.");
            toolTip.SetToolTip(PerformanceCurveCopyRecommendedButton, $"Copies the curve that is recommended for use by the {Settings.Default.GameName} gaming community.");
        }

        private void Import()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                /* TODO: This block is all old code that can likely be removed, could use code as reference
                    // Import from file to database and fill controls with data
                    var database = new ConfigureGameDatabase();
                    database.ImportDataFromFile(gameFolderPath, gameExecutablePath, languageFilePath);
                    PopulateControls(database);
                    _isImportOccurred = true;
                */

                _controller.Import();
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

        private void InitialisePerformanceCurve()
        {
            // Configure initial display of performance curve content
            PerformanceCurveChart.Titles.Clear();
            var chartTitle = PerformanceCurveChart.Titles.Add("Performance Curve");
            chartTitle.Font = new Font(chartTitle.Font.FontFamily, chartTitle.Font.SizeInPoints + 10);
            PerformanceCurveControlsGroupBox.Visible = false;
        }

        /* TODO: A dead method now as datasources are assigned by controller instead, could use code as reference
        private void PopulateControls(ConfigureGameDatabase database)
        {
            // Move data from database into controls
            LanguageDataGridView.DataSource = database.LanguageResources;
            CommentaryResourcesDataGridView.DataSource = database.CommentaryResources;
            
            DisableGameCdCheckBox.Checked = database.IsGameCdFixApplied;
            DisableColourModeCheckBox.Checked = database.IsDisplayModeFixApplied;
            DisableSampleAppCheckBox.Checked = database.IsSampleAppFixApplied;
            DisableMemoryResetForRaceSoundsCheckbox.Checked = database.IsRaceSoundsFixApplied;
            // TODO: DisablePitExitPriorityCheckBox.Checked = database.IsPitExitPriorityFixApplied;
            
            DisableYellowFlagPenaltiesCheckBox.Checked = database.IsYellowFlagFixApplied;
            EnableCarHandlingDesignCalculationCheckbox.Checked = database.IsCarDesignCalculationUpdateApplied;
            EnableCarPerformanceRaceCalcuationCheckbox.Checked = database.IsCarHandlingPerformanceFixApplied;
            
            CommentaryIndicesDriverDataGridView.DataSource = database.CommentaryIndicesDriver;
            CommentaryIndicesTeamDataGridView.DataSource = database.CommentaryIndicesTeam;
            CommentaryPrefixesDriverDataGridView.DataSource = database.CommentaryResourcesDriverPrefixes;
            CommentaryPrefixesTeamDataGridView.DataSource = database.CommentaryResourcesTeamPrefixes;
            CommentaryFilesDataGridView.DataSource = database.CommentaryResourcesWavSoundFiles;
            
            PointsScoringSystemDefaultRadioButton.Checked = database.IsPointsScoringSystemDefaultApplied;
            PointsScoringSystemOption1RadioButton.Checked = database.IsPointsScoringSystemOption1Applied;
            PointsScoringSystemOption2RadioButton.Checked = database.IsPointsScoringSystemOption2Applied;
            PointsScoringSystemOption3RadioButton.Checked = database.IsPointsScoringSystemOption3Applied;
            
            // Generate chart
            PerformanceCurveDefaultCheckBox.Checked = true; // Reset
            PerformanceCurveCurrentCheckBox.Checked = true; // Reset
            PerformanceCurveProposedCheckBox.Checked = true; // Reset
            _performanceCurveChart.GenerateChart();
            _performanceCurveChart.SetCurrentSeries(database.PerformanceCurve.Values);
            _performanceCurveChart.SetProposedSeriesToCurrentSeries();
            PerformanceCurveControlsGroupBox.Visible = true;
        }
        */

        private void PopulateRecords()
        // TODO: private void PopulateRecords(ConfigureGameDatabase database)
        {
            // TODO: // Move data from controls into database
            // TODO: database.LanguageResources = (IdentityCollection)LanguageDataGridView.DataSource;
            // TODO: database.CommentaryResources = (Collection<CommentaryResource>)CommentaryResourcesDataGridView.DataSource;
            // TODO: 
            // TODO: database.IsGameCdFixRequired = DisableGameCdCheckBox.Checked;
            // TODO: database.IsDisplayModeFixRequired = DisableColourModeCheckBox.Checked;
            // TODO: database.IsSampleAppFixRequired = DisableSampleAppCheckBox.Checked;
            // TODO: database.IsRaceSoundsFixRequired = DisableMemoryResetForRaceSoundsCheckbox.Checked;
            // TODO: // TODO: database.IsPitExitPriorityFixRequired = DisablePitExitPriorityCheckBox.Checked;
            // TODO: 
            // TODO: database.IsYellowFlagFixRequired = DisableYellowFlagPenaltiesCheckBox.Checked;
            // TODO: database.IsCarDesignCalculationUpdateRequired = EnableCarHandlingDesignCalculationCheckbox.Checked;
            // TODO: database.IsCarHandlingPerformanceFixRequired = EnableCarPerformanceRaceCalcuationCheckbox.Checked;
            // TODO: 
            // TODO: database.CommentaryIndicesDriver = (Collection<CommentaryDriverIndex>)CommentaryIndicesDriverDataGridView.DataSource;
            // TODO: database.CommentaryIndicesTeam = (Collection<CommentaryTeamIndex>)CommentaryIndicesTeamDataGridView.DataSource;
            // TODO: database.CommentaryResourcesDriverPrefixes = (Collection<CommentaryResource>)CommentaryPrefixesDriverDataGridView.DataSource;
            // TODO: database.CommentaryResourcesTeamPrefixes = (Collection<CommentaryResource>)CommentaryPrefixesTeamDataGridView.DataSource;
            // TODO: 
            // TODO: database.IsPointsScoringSystemDefaultRequired = PointsScoringSystemDefaultRadioButton.Checked;
            // TODO: database.IsPointsScoringSystemOption1Required = PointsScoringSystemOption1RadioButton.Checked;
            // TODO: database.IsPointsScoringSystemOption2Required = PointsScoringSystemOption2RadioButton.Checked;
            // TODO: database.IsPointsScoringSystemOption3Required = PointsScoringSystemOption3RadioButton.Checked;
            // TODO: 
            // TODO: database.PerformanceCurve = new PerformanceCurve
            // TODO: {
            // TODO:     Values = _performanceCurveChart.GetProposedSeries()
            // TODO: };
        }

        public void UpdateCommentaryIndicesDriverModelWithUpdatedCommentaryIndexValues(IEnumerable<CommentaryIndexDriverModel> indices)
        {
            if (indices == null) throw new ArgumentNullException(nameof(indices));

            var indicesModel = indices.ToList();
            var values = new int[indicesModel.Count];

            for (var i = 0; i < indicesModel.Count; i++)
            {
                values[i] = indicesModel.Single(x => x.Id == i).CommentaryIndex;
            }

            UpdateValuesInDataGridViewColumn(CommentaryIndicesDriverDataGridView, "CommentaryIndex", values);
        }

        public void UpdateCommentaryPrefixesDriverModelWithUpdatedFileNamePrefixValues(IEnumerable<CommentaryPrefixDriverModel> prefixes)
        {
            if (prefixes == null) throw new ArgumentNullException(nameof(prefixes));

            var prefixesModel = prefixes.ToList();
            var values = new string[prefixesModel.Count];

            for (var i = 0; i < prefixesModel.Count; i++)
            {
                values[i] = prefixesModel.Single(x => x.Id == i).FileNamePrefix;
            }

            UpdateValuesInDataGridViewColumn(CommentaryPrefixesDriverDataGridView, "FileNamePrefix", values);
        }

        public void UpdateCommentaryIndicesTeamModelWithUpdatedCommentaryIndexValues(IEnumerable<CommentaryIndexTeamModel> indices)
        {
            if (indices == null) throw new ArgumentNullException(nameof(indices));

            var indicesModel = indices.ToList();
            var values = new int[indicesModel.Count];

            for (var i = 0; i < indicesModel.Count; i++)
            {
                values[i] = indicesModel.Single(x => x.Id == i).CommentaryIndex;
            }

            UpdateValuesInDataGridViewColumn(CommentaryIndicesTeamDataGridView, "CommentaryIndex", values);
        }

        public void UpdateCommentaryPrefixesTeamModelWithUpdatedFileNamePrefixValues(IEnumerable<CommentaryPrefixTeamModel> prefixes)
        {
            if (prefixes == null) throw new ArgumentNullException(nameof(prefixes));

            var prefixesModel = prefixes.ToList();
            var values = new string[prefixesModel.Count];

            for (var i = 0; i < prefixesModel.Count; i++)
            {
                values[i] = prefixesModel.Single(x => x.Id == i).FileNamePrefix;
            }

            UpdateValuesInDataGridViewColumn(CommentaryPrefixesTeamDataGridView, "FileNamePrefix", values);
        }

        public IEnumerable<int> GetProposedSeriesValuesFromPerformanceCurveChart()
        {
            return _performanceCurveChart.GetProposedSeries();
        }

        public void UpdatePerformanceCurveChartWithHiddenSeriesValues(int[] values)
        {
            _performanceCurveChart.SetHiddenSeries(values);
        }
    }
}