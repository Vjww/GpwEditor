using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using App.Core.Entities;
using App.Core.Entities.Lookups;
using App.WindowsForms.Properties;

namespace App.WindowsForms.Views
{
    public partial class EditorForm : Form
    {
        private const int MaxDropDownItems = 20;

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

        /* LEGACY CODE
        // ReSharper disable once UnusedMember.Local
        private static void ConfigureDataGridViewControl<T>(DataGridView dataGridView, int columnId, string resourceTextHeaderText, bool fillColumns = false)
        {
            ConfigureDataGridViewControl<T>(dataGridView, columnId, fillColumns);
            dataGridView.Columns[3].HeaderText = resourceTextHeaderText;
        }
        */

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
            var result = GetFilePathFromOpenFileDialog();

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruGameExecutablePath = result;
            Settings.Default.Save();

            return result;
        }

        protected string GetEnglishLanguageFilePathFromOpenFileDialog()
        {
            var result = GetFilePathFromOpenFileDialog();

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruEnglishLanguageFilePath = result;
            Settings.Default.Save();

            return result;
        }

        protected string GetFrenchLanguageFilePathFromOpenFileDialog()
        {
            var result = GetFilePathFromOpenFileDialog();

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruFrenchLanguageFilePath = result;
            Settings.Default.Save();

            return result;
        }

        protected string GetGermanLanguageFilePathFromOpenFileDialog()
        {
            var result = GetFilePathFromOpenFileDialog();

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruGermanLanguageFilePath = result;
            Settings.Default.Save();

            return result;
        }

        protected string GetEnglishCommentaryFilePathFromOpenFileDialog()
        {
            var result = GetFilePathFromOpenFileDialog();

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruEnglishCommentaryFilePath = result;
            Settings.Default.Save();

            return result;
        }

        protected string GetFrenchCommentaryFilePathFromOpenFileDialog()
        {
            var result = GetFilePathFromOpenFileDialog();

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruFrenchCommentaryFilePath = result;
            Settings.Default.Save();

            return result;
        }

        protected string GetGermanCommentaryFilePathFromOpenFileDialog()
        {
            var result = GetFilePathFromOpenFileDialog();

            if (string.IsNullOrEmpty(result)) return null;

            Settings.Default.MruGermanCommentaryFilePath = result;
            Settings.Default.Save();

            return result;
        }

        private string GetFilePathFromOpenFileDialog()
        {
            // Configure open file dialog
            ProgramOpenFileDialog.InitialDirectory = Directory.Exists(Settings.Default.MruGameFolderPath)
                ? Settings.Default.MruGameFolderPath
                : Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ProgramOpenFileDialog.FileName = null;

            // Get file from user
            var dialogResult = ProgramOpenFileDialog.ShowDialog();

            // Return null if no file was selected, else return filename of selected file
            return dialogResult != DialogResult.OK ? null : ProgramOpenFileDialog.FileName;
        }

        protected string GetGameFolderMruOrDefault()
        {
            var defaultPath = GetValueOrDefaultIfNullOrWhiteSpace(Settings.Default.UserGameFolderPath, Settings.Default.DefaultGameFolderPath);
            return GetValueOrDefaultIfNullOrWhiteSpace(Settings.Default.MruGameFolderPath, defaultPath);
        }

        protected string GetGameExecutableMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultGameExecutableName, Settings.Default.MruGameExecutablePath);
        }

        protected string GetEnglishLanguageFileMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultEnglishLanguageFileName, Settings.Default.MruEnglishLanguageFilePath);
        }

        protected string GetFrenchLanguageFileMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultFrenchLanguageFileName, Settings.Default.MruFrenchLanguageFilePath);
        }

        protected string GetGermanLanguageFileMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultGermanLanguageFileName, Settings.Default.MruGermanLanguageFilePath);
        }

        protected string GetEnglishCommentaryFileMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultEnglishCommentaryFileName, "text", Settings.Default.MruEnglishCommentaryFilePath);
        }

        protected string GetFrenchCommentaryFileMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultFrenchCommentaryFileName, "textf", Settings.Default.MruFrenchCommentaryFilePath);
        }

        protected string GetGermanCommentaryFileMruOrDefault()
        {
            return GetFileMruOrDefault(Settings.Default.DefaultGermanCommentaryFileName, "textg", Settings.Default.MruGermanCommentaryFilePath);
        }

        private string GetFileMruOrDefault(string defaultFileName, string mruFilePath)
        {
            var gameFolderPath = GetGameFolderMruOrDefault();
            var defaultFilePath = Path.Combine(gameFolderPath, defaultFileName);
            return GetValueOrDefaultIfNullOrWhiteSpace(mruFilePath, defaultFilePath);
        }

        private string GetFileMruOrDefault(string defaultFileName, string defaultSubFolder, string mruFilePath)
        {
            var gameFolderPath = GetGameFolderMruOrDefault();
            var defaultFilePath = Path.Combine(gameFolderPath, defaultSubFolder, defaultFileName);
            return GetValueOrDefaultIfNullOrWhiteSpace(mruFilePath, defaultFilePath);
        }

        protected string GetValueOrDefaultIfNullOrWhiteSpace(string value, string @default)
        {
            return string.IsNullOrWhiteSpace(value) ? @default : value;
        }

        protected static void ShowErrorBox(Exception ex)
        {
            MessageBox.Show(
                $"{Settings.Default.ApplicationName} has encountered an error.{Environment.NewLine}{Environment.NewLine}" +
                $"Error: {ex.Message}{Environment.NewLine}{Environment.NewLine}" +
                $"To resolve this error, try running {Settings.Default.ApplicationName} as an administrator.",
                Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected static void ShowMessageBox(string message, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(message, Settings.Default.ApplicationName, MessageBoxButtons.OK, icon);
        }

        // TODO: remove
        //protected static void SwitchToForm(Form parentForm, Form childForm)
        //{
        //    childForm.FormClosing += delegate { parentForm.Show(); };
        //    childForm.Show(parentForm);
        //    parentForm.Hide();
        //}

        protected static void UpdateDataGridViewColumnHeaders<T>(DataGridView dataGridView)
        {
            //foreach (DataGridViewColumn column in dataGridView.Columns)
            //{
            //    var properties = typeof(T).GetProperties();
            //    var property = properties.Single(x => x.Name == column.DataPropertyName);
            //    var attributes = property.GetCustomAttributes(true);
            //    foreach (var attribute in attributes)
            //    {
            //        var displayAttribute = attribute as DisplayAttribute;
            //        if (displayAttribute != null)
            //        {
            //            // Update header text and tooltip text with attribute text
            //            column.HeaderText = displayAttribute.GetName();
            //            column.ToolTipText = displayAttribute.GetDescription();
            //        }
            //    }
            //}
        }

        protected static void UpdateValuesInDataGridViewColumn<T>(DataGridView dataGridView, string columnName, IReadOnlyList<T> values)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (!column.Name.Equals(columnName, StringComparison.Ordinal)) continue;

                var counter = 0;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    row.Cells[columnName].Value = values[counter];
                    counter++;
                }
            }
        }

        protected static void FileExists(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
        }

        protected static void FolderExists(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException();
            }
        }

        protected static bool IsFileLocked(FileInfo fileInfo)
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

        /********************************** TODO: NEW CODE BELOW ******/

        public static void AddColumnToDataGridView(DataGridView dataGridView, DataGridViewColumn dataGridViewColumn)
        {
            dataGridView.Columns.Add(dataGridViewColumn);
        }

        public static void ResetDataGridView(DataGridView dataGridView, bool fillColumns = false)
        {
            if (dataGridView == null) throw new ArgumentNullException(nameof(dataGridView));

            // Resolves defect with hidden columns becoming unhidden on grid recreation
            // https://stackoverflow.com/a/38168418
            dataGridView.DataSource = null;

            dataGridView.AutoGenerateColumns = false;
            dataGridView.Columns.Clear();
        }

        public static void ConfigureDataGridView(DataGridView dataGridView, string primaryColumnName, bool fillColumns = false)
        {
            if (dataGridView == null) throw new ArgumentNullException(nameof(dataGridView));
            if (primaryColumnName == null) throw new ArgumentNullException(nameof(primaryColumnName));

            // Freeze primary column (to always remain visible when scrolling horizontally)
            var primaryColumn = dataGridView.Columns[primaryColumnName];
            if (primaryColumn != null)
            {
                primaryColumn.Frozen = !fillColumns;
            }
            else
            {
                throw new IndexOutOfRangeException(nameof(primaryColumnName));
            }

            // Configure grid
            dataGridView.AutoSizeColumnsMode = fillColumns ? DataGridViewAutoSizeColumnsMode.Fill : DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
        }

        public static DataGridViewTextBoxColumn CreateDataGridViewTextBoxColumn(string propertyName, string displayText, string toolTipText, bool visible = true, bool readOnly = false)
        {
            var dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn
            {
                Name = propertyName,
                DataPropertyName = propertyName,
                HeaderText = displayText,
                ToolTipText = toolTipText,
                ReadOnly = readOnly,
                Visible = visible
            };

            return dataGridViewTextBoxColumn;
        }

        public static DataGridViewComboBoxColumn CreateDataGridViewComboBoxColumn(string propertyName, string displayText, string toolTipText)
        {
            var dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn
            {
                Name = propertyName,
                DataPropertyName = propertyName,
                HeaderText = displayText,
                ToolTipText = toolTipText,
                MaxDropDownItems = MaxDropDownItems,
                FlatStyle = FlatStyle.Flat
            };

            return dataGridViewComboBoxColumn;
        }

        public static void BindDataGridViewToDataSource(DataGridView dataGridView, IEnumerable<IEntity> dataSource)
        {
            dataGridView.DataSource = dataSource;
        }

        public static void BindDataGridViewComboBoxColumnToDataSource(DataGridViewComboBoxColumn dataGridViewComboBoxColumn, IEnumerable<ILookup> dataSource)
        {
            dataGridViewComboBoxColumn.DataSource = dataSource;
            dataGridViewComboBoxColumn.ValueMember = "Value";
            dataGridViewComboBoxColumn.DisplayMember = "Description";
        }
    }
}