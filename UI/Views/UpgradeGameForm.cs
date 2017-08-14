using System;
using System.IO;
using System.Windows.Forms;
using Data.Databases;
using GpwEditor.Properties;

namespace GpwEditor.Views
{
    public partial class UpgradeGameForm : EditorForm
    {
        private bool _isModified;

        public UpgradeGameForm()
        {
            InitializeComponent();
        }

        private void UpgradeGameForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.icon1;
            Text = $"{Settings.Default.ApplicationName} - Upgrade Game";
            ConvertLinesToRtf(OverviewRichTextBox);

            // Populate with most recently used (MRU) or default
            GameFolderPathTextBox.Text = GetGameFolderMruOrDefault();

            // Set modified as default
            _isModified = true;
        }

        private void UpgradeGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseFormConfirmation(_isModified, "Are you sure you wish to close this window?")) return;
            e.Cancel = true; // Abort event
        }

        private void BrowseGameFolderButton_Click(object sender, EventArgs e)
        {
            var result = GetGameFolderPathFromFolderBrowserDialog();
            GameFolderPathTextBox.Text = string.IsNullOrEmpty(result) ? GameFolderPathTextBox.Text : result;
        }

        private void UpgradeButton_Click(object sender, EventArgs e)
        {
            var gameFolderPath = GameFolderPathTextBox.Text;
            var gameExecutablePath = Path.Combine(gameFolderPath, Settings.Default.DefaultGameExecutableName);
            var englishLanguageFilePath = Path.Combine(gameFolderPath, Settings.Default.DefaultEnglishLanguageFileName);
            var frenchLanguageFilePath = Path.Combine(gameFolderPath, Settings.Default.DefaultFrenchLanguageFileName);
            var germanLanguageFilePath = Path.Combine(gameFolderPath, Settings.Default.DefaultGermanLanguageFileName);
            Upgrade(gameFolderPath, gameExecutablePath, englishLanguageFilePath, frenchLanguageFilePath, germanLanguageFilePath);
        }

        private static void Upgrade(string gameFolderPath, string gameExecutablePath, string englishLanguageFilePath, string frenchLanguageFilePath, string germanLanguageFilePath)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                FolderExists(gameFolderPath);

                var database = new UpgradeGameDatabase();
                database.Upgrade(gameFolderPath, gameExecutablePath, englishLanguageFilePath, frenchLanguageFilePath, germanLanguageFilePath);
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

            ShowMessageBox("Upgrade complete!");
        }
    }
}