using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Data.Collections.Language;
using Data.Databases;
using Data.Entities.Commentary;
using Data.Entities.Executable.Race;
using Data.Entities.Generic;
using GpwEditor.Enums;
using GpwEditor.Properties;

namespace GpwEditor.Views
{
    public partial class ConfigureGameForm : EditorForm
    {
        private PerformanceCurveChart _performanceCurveChart;
        private bool _isImportOccurred;
        private bool _isModified;

        public ConfigureGameForm()
        {
            InitializeComponent();
        }

        private void ConfigureGameForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.icon1;
            Text = $"{Settings.Default.ApplicationName} - Configure Game";
            ConvertLinesToRtf(OverviewRichTextBox);

            // Populate with most recently used (MRU) or default
            GameFolderPathTextBox.Text = GetGameFolderMruOrDefault();
            GameExecutablePathTextBox.Text = GetGameExecutableMruOrDefault();
            LanguageFilePathTextBox.Text = GetLanguageFileMruOrDefault();

            // Set modified as default
            _isModified = true;

            DisablePitExitPriorityCheckBox.Visible = false;
            _performanceCurveChart = new PerformanceCurveChart(PerformanceCurveChart);
            ConfigureControls();
            GenerateTooltips();

#if DEBUG
            LanguageDataGridView.Visible = true;
            CommentaryResourcesDataGridView.Visible = true;
#endif
        }

        private void ConfigureGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseFormConfirmation(_isModified,
                $"Are you sure you wish to close this window?{Environment.NewLine}{Environment.NewLine}Any changes not exported will be lost."))
                return;
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

        private void BrowseGameFolderButton_Click(object sender, EventArgs e)
        {
            var result = GetGameFolderPathFromFolderBrowserDialog();
            GameFolderPathTextBox.Text = string.IsNullOrEmpty(result) ? GameFolderPathTextBox.Text : result;
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
            Import(GameFolderPathTextBox.Text, GameExecutablePathTextBox.Text, LanguageFilePathTextBox.Text);
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (!_isImportOccurred)
            {
                ShowMessageBox("Unable to export until a successful import has occurred.", MessageBoxIcon.Error);
                return;
            }

            Export(GameFolderPathTextBox.Text, GameExecutablePathTextBox.Text, LanguageFilePathTextBox.Text);
        }

        private void CommentaryIndicesDefaultButton_Click(object sender, EventArgs e)
        {
            var driverValues = new[]
            {
                67,
                68,
                69,
                70,
                71,
                72,
                73,
                74,
                75,
                76,
                77,
                78,
                79,
                80,
                81,
                82,
                83,
                84,
                85,
                86,
                87,
                88,
                89,
                90,
                91,
                92,
                93,
                94,
                95,
                96,
                97,
                98,
                99,
                100,
                101,
                102,
                103,
                104,
                105,
                106,
                107,
                107,
                107,
                107
            };

            UpdateValuesInDataGridViewColumn(CommentaryIndicesDriverDataGridView, 4, driverValues);

            var teamValues = new[]
            {
                231,
                232,
                233,
                234,
                235,
                236,
                237,
                238,
                239,
                240,
                241
            };

            UpdateValuesInDataGridViewColumn(CommentaryIndicesTeamDataGridView, 4, teamValues);
        }

        private void CommentaryDriversDefaultButton_Click(object sender, EventArgs e)
        {
            var values = new[]
            {
                "NEWH",
                "FREN",
                "TOY",
                "SCHU",
                "IRV",
                "BAD",
                "FIS",
                "WURZ",
                "ANON",
                "HAK",
                "COUL",
                "ZON",
                "HIL",
                "RALF",
                "ANON",
                "PAN",
                "TRU",
                "SAR",
                "ALES",
                "HERB",
                "MULL",
                "DIN",
                "SAL",
                "COL",
                "BARI",
                "MAG",
                "ANON",
                "TAK",
                "ROS",
                "MONT",
                "NAK",
                "TUER",
                "RED",
                "ELL",
                "MAR",
                "RAIM",
                "TAN",
                "EBE",
                "PAT",
                "FELL",
                "LAUR"//,
                //"EIS",
                //"WILL",
                //"MOR"
            };

            UpdateValuesInDataGridViewColumn(CommentaryPrefixesDriverDataGridView, 2, values);
        }

        private void CommentaryDriversGenericButton_Click(object sender, EventArgs e)
        {
            var values = new string[41];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = "ANON";
            }

            UpdateValuesInDataGridViewColumn(CommentaryPrefixesDriverDataGridView, 2, values);
        }

        private void CommentaryTeamsDefaultButton_Click(object sender, EventArgs e)
        {
            var values = new[]
            {
                "WIL",
                "FER",
                "BEN",
                "MCL",
                "JOR",
                "PRO",
                "SAU",
                "ARR",
                "STEW",
                "TYR",
                "MIN",
            };
            UpdateValuesInDataGridViewColumn(CommentaryPrefixesTeamDataGridView, 2, values);
        }

        private void CommentaryTeamsGenericButton_Click(object sender, EventArgs e)
        {
            var values = new string[11];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = "ANON";
            }
            UpdateValuesInDataGridViewColumn(CommentaryPrefixesTeamDataGridView, 2, values);
        }

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
            // Hide parent form and show child form
            SwitchToForm(this, new PerformanceCurveValuesForm(_performanceCurveChart));
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

        private void ConfigureControls()
        {
            ConfigureCommentaryIndicesDriverDataGridView();
            ConfigureCommentaryIndicesTeamDataGridView();
            ConfigureCommentaryDriversDataGridView();
            ConfigureCommentaryTeamsDataGridView();
            ConfigureCommentaryFilesDataGridView();

            // Configure initial display of performance curve content
            PerformanceCurveChart.Titles.Clear();
            var chartTitle = PerformanceCurveChart.Titles.Add("Performance Curve");
            chartTitle.Font = new Font(chartTitle.Font.FontFamily, chartTitle.Font.SizeInPoints + 10);
            PerformanceCurveControlsGroupBox.Visible = false;
        }

        private void ConfigureCommentaryIndicesDriverDataGridView()
        {
            const bool fillColumns = false;
            CommentaryIndicesDriverDataGridView.Columns["idDataGridViewTextBoxColumn2"].Visible = false;
            CommentaryIndicesDriverDataGridView.Columns["localResourceIdDataGridViewTextBoxColumn1"].Visible = false;
            CommentaryIndicesDriverDataGridView.Columns["resourceIdDataGridViewTextBoxColumn1"].Visible = false;
            CommentaryIndicesDriverDataGridView.Columns["resourceTextDataGridViewTextBoxColumn1"].Frozen = !fillColumns;
            CommentaryIndicesDriverDataGridView.Columns["resourceTextDataGridViewTextBoxColumn1"].ReadOnly = true;

            // Rename column headers and populate column tooltips using model attributes
            UpdateDataGridViewColumnHeaders<CommentaryDriverIndex>(CommentaryIndicesDriverDataGridView);

            // Configure grid
            CommentaryIndicesDriverDataGridView.AutoSizeColumnsMode = fillColumns ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.AllCells;
            CommentaryIndicesDriverDataGridView.AllowUserToAddRows = false;
            CommentaryIndicesDriverDataGridView.AllowUserToDeleteRows = false;
            CommentaryIndicesDriverDataGridView.AllowUserToResizeRows = false;
            CommentaryIndicesDriverDataGridView.MultiSelect = false;
            CommentaryIndicesDriverDataGridView.RowHeadersVisible = false;
        }

        private void ConfigureCommentaryIndicesTeamDataGridView()
        {
            const bool fillColumns = false;
            CommentaryIndicesTeamDataGridView.Columns["idDataGridViewTextBoxColumn5"].Visible = false;
            CommentaryIndicesTeamDataGridView.Columns["localResourceIdDataGridViewTextBoxColumn2"].Visible = false;
            CommentaryIndicesTeamDataGridView.Columns["resourceIdDataGridViewTextBoxColumn2"].Visible = false;
            CommentaryIndicesTeamDataGridView.Columns["resourceTextDataGridViewTextBoxColumn2"].Frozen = !fillColumns;
            CommentaryIndicesTeamDataGridView.Columns["resourceTextDataGridViewTextBoxColumn2"].ReadOnly = true;

            // Rename column headers and populate column tooltips using model attributes
            UpdateDataGridViewColumnHeaders<CommentaryTeamIndex>(CommentaryIndicesTeamDataGridView);

            // Configure grid
            CommentaryIndicesTeamDataGridView.AutoSizeColumnsMode = fillColumns ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.AllCells;
            CommentaryIndicesTeamDataGridView.AllowUserToAddRows = false;
            CommentaryIndicesTeamDataGridView.AllowUserToDeleteRows = false;
            CommentaryIndicesTeamDataGridView.AllowUserToResizeRows = false;
            CommentaryIndicesTeamDataGridView.MultiSelect = false;
            CommentaryIndicesTeamDataGridView.RowHeadersVisible = false;
        }

        private void ConfigureCommentaryDriversDataGridView()
        {
            const bool fillColumns = false;
            var dataGrid = CommentaryPrefixesDriverDataGridView;
            dataGrid.Columns["fileNameDataGridViewTextBoxColumn1"].Visible = false;
            dataGrid.Columns["fileNameSuffixDataGridViewTextBoxColumn1"].Visible = false;
            dataGrid.Columns["transcriptDataGridViewTextBoxColumn1"].Visible = false;
            dataGrid.Columns["transcriptPrefixDataGridViewTextBoxColumn1"].Visible = false;
            dataGrid.Columns["transcriptSuffixDataGridViewTextBoxColumn1"].Visible = false;
            dataGrid.Columns["idDataGridViewTextBoxColumn3"].Frozen = !fillColumns;
            dataGrid.Columns["idDataGridViewTextBoxColumn3"].ReadOnly = true;

            // Rename column headers and populate column tooltips using model attributes
            UpdateDataGridViewColumnHeaders<CommentaryResource>(dataGrid);

            // Configure grid
            dataGrid.AutoSizeColumnsMode = fillColumns ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.MultiSelect = false;
            dataGrid.RowHeadersVisible = false;
        }

        private void ConfigureCommentaryTeamsDataGridView()
        {
            const bool fillColumns = false;
            var dataGrid = CommentaryPrefixesTeamDataGridView;
            dataGrid.Columns["fileNameDataGridViewTextBoxColumn2"].Visible = false;
            dataGrid.Columns["fileNameSuffixDataGridViewTextBoxColumn2"].Visible = false;
            dataGrid.Columns["transcriptDataGridViewTextBoxColumn2"].Visible = false;
            dataGrid.Columns["transcriptPrefixDataGridViewTextBoxColumn2"].Visible = false;
            dataGrid.Columns["transcriptSuffixDataGridViewTextBoxColumn2"].Visible = false;
            dataGrid.Columns["idDataGridViewTextBoxColumn4"].Frozen = !fillColumns;
            dataGrid.Columns["idDataGridViewTextBoxColumn4"].ReadOnly = true;

            // Rename column headers and populate column tooltips using model attributes
            UpdateDataGridViewColumnHeaders<CommentaryResource>(dataGrid);

            // Configure grid
            dataGrid.AutoSizeColumnsMode = fillColumns ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.MultiSelect = false;
            dataGrid.RowHeadersVisible = false;
        }

        private void ConfigureCommentaryFilesDataGridView()
        {
            const bool fillColumns = false;
            var dataGrid = CommentaryFilesDataGridView;
            dataGrid.Columns["valueDataGridViewTextBoxColumn"].Frozen = !fillColumns;
            dataGrid.Columns["valueDataGridViewTextBoxColumn"].ReadOnly = true;

            // Rename column headers and populate column tooltips using model attributes
            UpdateDataGridViewColumnHeaders<StringValue>(dataGrid);

            // Configure grid
            dataGrid.AutoSizeColumnsMode = fillColumns ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.MultiSelect = false;
            dataGrid.RowHeadersVisible = false;
        }

        private void Export(string gameFolderPath, string gameExecutablePath, string languageFilePath)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Fill database with data from controls and export to file
                var database = new ConfigureGameDatabase();
                PopulateRecords(database);
                database.ExportDataToFile(gameFolderPath, gameExecutablePath, languageFilePath);

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

        private void Import(string gameFolderPath, string gameExecutablePath, string languageFilePath)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Import from file to database and fill controls with data
                var database = new ConfigureGameDatabase();
                database.ImportDataFromFile(gameFolderPath, gameExecutablePath, languageFilePath);
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

        private void PopulateRecords(ConfigureGameDatabase database)
        {
            // Move data from controls into database
            database.LanguageResources = (IdentityCollection)LanguageDataGridView.DataSource;
            database.CommentaryResources = (Collection<CommentaryResource>)CommentaryResourcesDataGridView.DataSource;

            database.IsGameCdFixRequired = DisableGameCdCheckBox.Checked;
            database.IsDisplayModeFixRequired = DisableColourModeCheckBox.Checked;
            database.IsSampleAppFixRequired = DisableSampleAppCheckBox.Checked;
            database.IsRaceSoundsFixRequired = DisableMemoryResetForRaceSoundsCheckbox.Checked;
            // TODO: database.IsPitExitPriorityFixRequired = DisablePitExitPriorityCheckBox.Checked;

            database.IsYellowFlagFixRequired = DisableYellowFlagPenaltiesCheckBox.Checked;
            database.IsCarDesignCalculationUpdateRequired = EnableCarHandlingDesignCalculationCheckbox.Checked;
            database.IsCarHandlingPerformanceFixRequired = EnableCarPerformanceRaceCalcuationCheckbox.Checked;

            database.CommentaryIndicesDriver = (Collection<CommentaryDriverIndex>)CommentaryIndicesDriverDataGridView.DataSource;
            database.CommentaryIndicesTeam = (Collection<CommentaryTeamIndex>)CommentaryIndicesTeamDataGridView.DataSource;
            database.CommentaryResourcesDriverPrefixes = (Collection<CommentaryResource>)CommentaryPrefixesDriverDataGridView.DataSource;
            database.CommentaryResourcesTeamPrefixes = (Collection<CommentaryResource>)CommentaryPrefixesTeamDataGridView.DataSource;

            database.IsPointsScoringSystemDefaultRequired = PointsScoringSystemDefaultRadioButton.Checked;
            database.IsPointsScoringSystemOption1Required = PointsScoringSystemOption1RadioButton.Checked;
            database.IsPointsScoringSystemOption2Required = PointsScoringSystemOption2RadioButton.Checked;
            database.IsPointsScoringSystemOption3Required = PointsScoringSystemOption3RadioButton.Checked;

            database.PerformanceCurve = new PerformanceCurve
            {
                Values = _performanceCurveChart.GetProposedSeries()
            };
        }
    }
}