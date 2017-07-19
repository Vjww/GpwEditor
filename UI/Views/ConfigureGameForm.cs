using System;
using System.Windows.Forms;
using Data.Databases;
using GpwEditor.Properties;

namespace GpwEditor.Views
{
    public partial class ConfigureGameForm : EditorFormBase
    {
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

            // Hide unused control
            DisablePitExitPriorityCheckBox.Visible = false;
        }

        private void ConfigureGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseFormConfirmation(_isModified,
                $"Are you sure you wish to close this window?{Environment.NewLine}{Environment.NewLine}Any changes not exported will be lost."))
                return;
            e.Cancel = true; // Abort event
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

        private void Export(string gameFolderPath, string gameExecutablePath, string languageFilePath)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Fill database with data from controls and export to file
                var database = new ConfigureGameDatabase();
                PopulateRecords(database);
                database.ExportDataToFile(gameFolderPath, gameExecutablePath, languageFilePath);
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
        }

        private void PopulateRecords(ConfigureGameDatabase database)
        {
            // Move data from controls into database
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
        }
    }
}