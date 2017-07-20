using System;
using System.Drawing;
using System.Windows.Forms;
using Data.Collections.Language;
using Data.Databases;
using Data.Entities.Executable.Race;
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
            // Configure initial display of performance curve content
            PerformanceCurveChart.Titles.Clear();
            var chartTitle = PerformanceCurveChart.Titles.Add("Performance Curve");
            chartTitle.Font = new Font(chartTitle.Font.FontFamily, chartTitle.Font.SizeInPoints + 10);
            PerformanceCurveControlsGroupBox.Visible = false;
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
            LanguageDataGridView.DataSource = database.LanguageStrings;

            DisableGameCdCheckBox.Checked = database.IsGameCdFixApplied;
            DisableColourModeCheckBox.Checked = database.IsDisplayModeFixApplied;
            DisableSampleAppCheckBox.Checked = database.IsSampleAppFixApplied;
            DisableMemoryResetForRaceSoundsCheckbox.Checked = database.IsRaceSoundsFixApplied;
            // TODO: DisablePitExitPriorityCheckBox.Checked = database.IsPitExitPriorityFixApplied;

            DisableYellowFlagPenaltiesCheckBox.Checked = database.IsYellowFlagFixApplied;
            EnableCarHandlingDesignCalculationCheckbox.Checked = database.IsCarDesignCalculationUpdateApplied;
            EnableCarPerformanceRaceCalcuationCheckbox.Checked = database.IsCarHandlingPerformanceFixApplied;

            CommentaryOriginalRadioButton.Checked = database.IsCommentaryModifiedRequired == false;
            CommentaryModifiedRadioButton.Checked = database.IsCommentaryModifiedRequired;

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
            database.LanguageStrings = (IdentityCollection)LanguageDataGridView.DataSource;

            database.IsGameCdFixRequired = DisableGameCdCheckBox.Checked;
            database.IsDisplayModeFixRequired = DisableColourModeCheckBox.Checked;
            database.IsSampleAppFixRequired = DisableSampleAppCheckBox.Checked;
            database.IsRaceSoundsFixRequired = DisableMemoryResetForRaceSoundsCheckbox.Checked;
            // TODO: database.IsPitExitPriorityFixRequired = DisablePitExitPriorityCheckBox.Checked;

            database.IsYellowFlagFixRequired = DisableYellowFlagPenaltiesCheckBox.Checked;
            database.IsCarDesignCalculationUpdateRequired = EnableCarHandlingDesignCalculationCheckbox.Checked;
            database.IsCarHandlingPerformanceFixRequired = EnableCarPerformanceRaceCalcuationCheckbox.Checked;

            database.IsCommentaryModifiedRequired = CommentaryOriginalRadioButton.Checked == false && CommentaryModifiedRadioButton.Checked;

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