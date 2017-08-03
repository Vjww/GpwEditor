using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
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

        // ReSharper disable once UnusedMember.Local
        private static void ConfigureDataGridViewControl<T>(DataGridView dataGridView, int columnId, string resourceTextHeaderText, bool fillColumns = false)
        {
            ConfigureDataGridViewControl<T>(dataGridView, columnId, fillColumns);
            dataGridView.Columns[3].HeaderText = resourceTextHeaderText;
        }

        protected static void ConfigureDataGridViewControl<T>(DataGridView dataGridView, int idColumnId, int localResourceIdColumnId, int resourceIdColumnId, int resourceTextColumnId, bool fillColumns = false)
        {
            // Hide columns
            dataGridView.Columns[$"idDataGridViewTextBoxColumn{idColumnId}"].Visible = false;
            dataGridView.Columns[$"localResourceIdDataGridViewTextBoxColumn{localResourceIdColumnId}"].Visible = false;
            dataGridView.Columns[$"resourceIdDataGridViewTextBoxColumn{resourceIdColumnId}"].Visible = false;

            // Freeze primary column (to always show when scrolling horizontally)
            dataGridView.Columns[$"resourceTextDataGridViewTextBoxColumn{resourceTextColumnId}"].Frozen = !fillColumns;

            // Make primary column readonly
            dataGridView.Columns[$"resourceTextDataGridViewTextBoxColumn{resourceTextColumnId}"].ReadOnly = true;

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

        protected static void ConfigureDataGridViewControl<T>(DataGridView dataGridView, int columnId, bool fillColumns = false)
        {
            ConfigureDataGridViewControl<T>(dataGridView, columnId, columnId, columnId, columnId, fillColumns);
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
            var defaultPath = GetValueOrDefaultIfNullOrWhiteSpace(Settings.Default.UserGameFolderPath,
                Settings.Default.DefaultGameFolderPath);
            return GetValueOrDefaultIfNullOrWhiteSpace(Settings.Default.MruGameFolderPath, defaultPath);
        }

        protected string GetGameExecutableMruOrDefault()
        {
            var gameFolderPath = GetGameFolderMruOrDefault();
            var defaultFileName = GetValueOrDefaultIfNullOrWhiteSpace(Path.GetFileName(Settings.Default.UserGameExecutablePath),
                Settings.Default.DefaultGameExecutableName);
            var defaultFilePath = Path.Combine(gameFolderPath, defaultFileName);
            return GetValueOrDefaultIfNullOrWhiteSpace(Settings.Default.MruGameExecutablePath, defaultFilePath);
        }

        protected string GetLanguageFileMruOrDefault()
        {
            var gameFolderPath = GetGameFolderMruOrDefault();
            var defaultFileName = GetValueOrDefaultIfNullOrWhiteSpace(Path.GetFileName(Settings.Default.UserLanguageFilePath),
                Settings.Default.DefaultLanguageFileName);
            var defaultFilePath = Path.Combine(gameFolderPath, defaultFileName);
            return GetValueOrDefaultIfNullOrWhiteSpace(Settings.Default.MruLanguageFilePath, defaultFilePath);
        }

        protected string GetValueOrDefaultIfNullOrWhiteSpace(string value, string @default)
        {
            return string.IsNullOrWhiteSpace(value) ? @default : value;
        }

        protected static void ShowMessageBox(string message, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(message, Settings.Default.ApplicationName, MessageBoxButtons.OK, icon);
        }

        protected static void SwitchToForm(Form parentForm, Form childForm)
        {
            childForm.FormClosing += delegate { parentForm.Show(); };
            childForm.Show(parentForm);
            parentForm.Hide();
        }

        protected static void UpdateDataGridViewColumnHeaders<T>(DataGridView dataGridView)
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

        protected static void UpdateValuesInDataGridViewColumn<T>(DataGridView dataGridView, int columnIndex, IReadOnlyList<T> values)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.Index != columnIndex) continue;

                var counter = 0;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    row.Cells[columnIndex].Value = values[counter];
                    counter++;
                }
            }
        }

        protected static void FileTest(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }

            // TODO: Not a permanent solution, as file could become locked after check.
            if (IsFileLocked(new FileInfo(path)))
            {
                throw new Exception("The file is currently locked by another process.");
            }
        }

        protected static void FolderTest(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException();
            }
        }

        public static bool IsFileLocked(FileInfo fileInfo)
        {
            try
            {
                var filePath = fileInfo.FullName;
                var fs = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                fs.Close();
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}