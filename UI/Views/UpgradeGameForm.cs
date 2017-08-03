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
            GameExecutablePathTextBox.Text = GetGameExecutableMruOrDefault();
            LanguageFilePathTextBox.Text = GetLanguageFileMruOrDefault();

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

        private void UpgradeButton_Click(object sender, EventArgs e)
        {
            Upgrade(GameFolderPathTextBox.Text, GameExecutablePathTextBox.Text, LanguageFilePathTextBox.Text);
        }

        private static void Upgrade(string gameFolderPath, string gameExecutablePath, string languageFilePath)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                FolderTest(gameFolderPath);
                FileTest(gameExecutablePath);
                FileTest(languageFilePath);

                var database = new UpgradeGameDatabase();
                database.Upgrade(gameFolderPath, gameExecutablePath, languageFilePath);
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