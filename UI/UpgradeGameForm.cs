using System;
using System.IO;
using System.Windows.Forms;
using Data.Database;
using GpwEditor.Properties;

namespace GpwEditor
{
    /// <summary>
    /// Enables the user to modify logic in the game executable.
    /// </summary>
    public partial class UpgradeGameForm : Form
    {
        private bool _isModified;

        public UpgradeGameForm()
        {
            InitializeComponent();
        }

        private void UpgradeGameForm_Load(object sender, EventArgs e)
        {
            // Set icon
            Icon = Resources.icon1;

            // Set form title text
            Text = $"{Settings.Default.ApplicationName} - Upgrade Game";

            // Populate file paths with most recently used (MRU) or default
            var defaultLanguageFileFilePath = Path.Combine(Settings.Default.UserGameFolderPath, Settings.Default.DefaultLanguageFileName);
            LanguageFilePathTextBox.Text =
                string.IsNullOrWhiteSpace(Settings.Default.UpgradeGameMruLanguageFileFilePath)
                    ? defaultLanguageFileFilePath
                    : Settings.Default.UpgradeGameMruLanguageFileFilePath;

            var defaultGameExecutableFilePath = Path.Combine(Settings.Default.UserGameFolderPath, Settings.Default.DefaultExecutableFileName);
            GameExecutablePathTextBox.Text =
                string.IsNullOrWhiteSpace(Settings.Default.UpgradeGameMruGameExecutableFilePath)
                    ? defaultGameExecutableFilePath
                    : Settings.Default.UpgradeGameMruGameExecutableFilePath;

            // Set modified as default
            _isModified = true;
        }

        private void UpgradeGameForm_FormClosing(object sender, FormClosingEventArgs e)
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
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            Export(LanguageFilePathTextBox.Text, GameExecutablePathTextBox.Text);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
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
                    $"Are you sure you wish to close the game upgrader?{Environment.NewLine}{Environment.NewLine}Any upgrades not applied will be lost.",
                    Settings.Default.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            return result == DialogResult.Yes;
        }

        private void Export(string languageFileFilePath, string gameExecutableFilePath)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Fill database with data from controls and export to file
                var upgradeDatabase = new UpgradeDatabase();
                PopulateRecords(upgradeDatabase);
                upgradeDatabase.ExportDataToFile(gameExecutableFilePath, languageFileFilePath);
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
                var upgradeDatabase = new UpgradeDatabase();
                upgradeDatabase.ImportDataFromFile(gameExecutableFilePath, languageFileFilePath);
                PopulateControls(upgradeDatabase);
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
            Settings.Default.UpgradeGameMruLanguageFileFilePath = LanguageFilePathTextBox.Text;
            Settings.Default.UpgradeGameMruGameExecutableFilePath = GameExecutablePathTextBox.Text;

            MessageBox.Show("Import complete!");
        }

        private void PopulateControls(UpgradeDatabase upgradeDatabase)
        {
            // Move data from database into controls
            DisableGameCdCheckBox.Checked = upgradeDatabase.IsGameCdFixApplied;
            DisableColourModeCheckBox.Checked = upgradeDatabase.IsDisplayModeFixApplied;
            DisableSampleAppCheckBox.Checked = upgradeDatabase.IsSampleAppFixApplied;
            DisableGlobalUnlockCheckBox.Checked = upgradeDatabase.IsGlobalUnlockFixApplied;
            DisableYellowFlagPenaltiesCheckBox.Checked = upgradeDatabase.IsYellowFlagFixApplied;
            DisableMemoryResetForRaceSoundsCheckbox.Checked = upgradeDatabase.IsRaceSoundsFixApplied;
            //DisablePitExitPriorityCheckBox.Checked = upgradeDatabase.IsPitExitPriorityFixApplied;
            EnableCarHandlingDesignCalculationCheckbox.Checked = upgradeDatabase.IsCarDesignCalculationUpdateApplied;
            EnableCarPerformanceRaceCalcuationCheckbox.Checked = upgradeDatabase.IsCarHandlingPerformanceFixApplied;

            // TODO what happens when importing from unmodified exe, how to check the Default Radio button below?

            PointsScoringSystemDefaultRadioButton.Checked = upgradeDatabase.IsPointsScoringSystemDefaultApplied;
            PointsScoringSystemOption1RadioButton.Checked = upgradeDatabase.IsPointsScoringSystemOption1Applied;
            PointsScoringSystemOption2RadioButton.Checked = upgradeDatabase.IsPointsScoringSystemOption2Applied;
            PointsScoringSystemOption3RadioButton.Checked = upgradeDatabase.IsPointsScoringSystemOption3Applied;
        }

        private void PopulateRecords(UpgradeDatabase upgradeDatabase)
        {
            // Move data from controls into database
            upgradeDatabase.IsGameCdFixRequired = DisableGameCdCheckBox.Checked;
            upgradeDatabase.IsDisplayModeFixRequired = DisableColourModeCheckBox.Checked;
            upgradeDatabase.IsSampleAppFixRequired = DisableSampleAppCheckBox.Checked;
            upgradeDatabase.IsGlobalUnlockFixRequired = DisableGlobalUnlockCheckBox.Checked;
            upgradeDatabase.IsYellowFlagFixRequired = DisableYellowFlagPenaltiesCheckBox.Checked;
            upgradeDatabase.IsRaceSoundsFixRequired = DisableMemoryResetForRaceSoundsCheckbox.Checked;
            //upgradeDatabase.IsPitExitPriorityFixRequired = DisablePitExitPriorityCheckBox.Checked;
            upgradeDatabase.IsCarDesignCalculationUpdateRequired = EnableCarHandlingDesignCalculationCheckbox.Checked;
            upgradeDatabase.IsCarHandlingPerformanceFixRequired = EnableCarPerformanceRaceCalcuationCheckbox.Checked;

            upgradeDatabase.IsPointsScoringSystemDefaultRequired = PointsScoringSystemDefaultRadioButton.Checked;
            upgradeDatabase.IsPointsScoringSystemOption1Required = PointsScoringSystemOption1RadioButton.Checked;
            upgradeDatabase.IsPointsScoringSystemOption2Required = PointsScoringSystemOption2RadioButton.Checked;
            upgradeDatabase.IsPointsScoringSystemOption3Required = PointsScoringSystemOption3RadioButton.Checked;
        }
    }
}
