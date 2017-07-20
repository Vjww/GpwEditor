using System;
using System.IO;
using System.Windows.Forms;
using GpwEditor.Properties;

namespace GpwEditor.Views
{
    public partial class EditorForm : Form
    {
        protected EditorForm()
        {
            InitializeComponent();
        }

        protected bool CloseFormConfirmation(bool isModified, string message)
        {
            // Return true if there are no unsaved changes 
            if (!isModified)
            {
                return true;
            }

            // Prompt user whether to close form with unsaved changes
            var result = MessageBox.Show(message, Settings.Default.ApplicationName, MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            return result == DialogResult.Yes;
        }

        protected static void ConvertLinesToRtf(RichTextBox richTextBox)
        {
            var rtfString = string.Empty;
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var item in richTextBox.Lines)
            {
                // Add linebreak after each item
                rtfString += item + @"\line ";
            }
            richTextBox.Rtf = rtfString.TrimEnd(@"\line".ToCharArray());
        }

        protected string GetGameFolderPathFromFolderBrowserDialog()
        {
            // Configure folder browser dialog
            if (Directory.Exists(Settings.Default.MruGameFolderPath))
            {
                ProgramFolderBrowserDialog.SelectedPath = Settings.Default.MruGameFolderPath;
            }
            else
            {
                ProgramFolderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            }

            // Get folder from user
            var dialogResult = ProgramFolderBrowserDialog.ShowDialog();

            // Return if no folder was selected
            if (dialogResult != DialogResult.OK) return null;

            // Save selected folder
            Settings.Default.MruGameFolderPath = ProgramFolderBrowserDialog.SelectedPath;
            Settings.Default.Save();

            return Settings.Default.MruGameFolderPath;
        }

        protected string GetGameExecutablePathFromOpenFileDialog()
        {
            // Configure open file dialog
            ProgramOpenFileDialog.InitialDirectory = Directory.Exists(Settings.Default.MruGameFolderPath)
                ? Settings.Default.MruGameFolderPath
                : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ProgramOpenFileDialog.FileName = null;

            // Get file from user
            var dialogResult = ProgramOpenFileDialog.ShowDialog();

            // Return if no file was selected
            if (dialogResult != DialogResult.OK) return null;

            // Save selected file
            Settings.Default.MruGameExecutablePath = ProgramOpenFileDialog.FileName;
            Settings.Default.Save();

            return Settings.Default.MruGameExecutablePath;
        }

        protected string GetLanguageFilePathFromOpenFileDialog()
        {
            // Configure open file dialog
            ProgramOpenFileDialog.InitialDirectory = Directory.Exists(Settings.Default.MruGameFolderPath)
                ? Settings.Default.MruGameFolderPath
                : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ProgramOpenFileDialog.FileName = null;

            // Get file from user
            var dialogResult = ProgramOpenFileDialog.ShowDialog();

            // Return if no file was selected
            if (dialogResult != DialogResult.OK) return null;

            // Save selected file
            Settings.Default.MruLanguageFilePath = ProgramOpenFileDialog.FileName;
            Settings.Default.Save();

            return Settings.Default.MruLanguageFilePath;
        }

        protected string GetGameFolderMruOrDefault()
        {
            var defaultPath = GetValueOrDefault(Settings.Default.UserGameFolderPath,
                Settings.Default.DefaultGameFolderPath);
            return GetValueOrDefault(Settings.Default.MruGameFolderPath, defaultPath);
        }

        protected string GetGameExecutableMruOrDefault()
        {
            var gameFolderPath = GetGameFolderMruOrDefault();
            var defaultFileName = GetValueOrDefault(Path.GetFileName(Settings.Default.UserGameExecutablePath),
                Settings.Default.DefaultGameExecutableName);
            var defaultFilePath = Path.Combine(gameFolderPath, defaultFileName);
            return GetValueOrDefault(Settings.Default.MruGameExecutablePath, defaultFilePath);
        }

        protected string GetLanguageFileMruOrDefault()
        {
            var gameFolderPath = GetGameFolderMruOrDefault();
            var defaultFileName = GetValueOrDefault(Path.GetFileName(Settings.Default.UserLanguageFilePath),
                Settings.Default.DefaultLanguageFileName);
            var defaultFilePath = Path.Combine(gameFolderPath, defaultFileName);
            return GetValueOrDefault(Settings.Default.MruLanguageFilePath, defaultFilePath);
        }

        protected string GetValueOrDefault(string value, string @default)
        {
            return string.IsNullOrWhiteSpace(value) ? @default : value;
        }

        protected static void ShowMessageBox(string message, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(message, Settings.Default.ApplicationName, MessageBoxButtons.OK, icon);
        }

        protected static void SwitchToForm(Form parentForm, Form childForm)
        {
            childForm.Show(parentForm);
            parentForm.Hide();
            childForm.FormClosing += delegate { parentForm.Show(); };
        }
    }
}