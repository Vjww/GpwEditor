using System;
using System.IO;
using System.Windows.Forms;
using Data.Collections.Language;
using Data.Database;
using Data.FileConnection;
using GpwEditor.Properties;

namespace GpwEditor
{
    /// <summary>
    /// Enables the user to modify data in the language file.
    /// </summary>
    public partial class LanguageFileEditorForm : Form
    {
        private bool _isFirstRowResult;
        private bool _isModified;

        public LanguageFileEditorForm()
        {
            InitializeComponent();
        }

        private void LanguageFileEditorForm_Load(object sender, EventArgs e)
        {
            // Set icon
            Icon = Resources.icon1;

            // Set form title text
            Text = $"{Settings.Default.ApplicationName} - Language File Editor";

            ConfigureDataGridViewControl();

            // Populate file paths with most recently used (MRU) or default
            var defaultLanguageFileFilePath = Path.Combine(Settings.Default.UserGameFolderPath, Settings.Default.DefaultLanguageFileName);
            LanguageFilePathTextBox.Text =
                string.IsNullOrWhiteSpace(Settings.Default.LanguageEditorMruLanguageFileFilePath)
                    ? defaultLanguageFileFilePath
                    : Settings.Default.LanguageEditorMruLanguageFileFilePath;

            var defaultGameExecutableFilePath = Path.Combine(Settings.Default.UserGameFolderPath, Settings.Default.DefaultExecutableFileName);
            GameExecutablePathTextBox.Text =
                string.IsNullOrWhiteSpace(Settings.Default.LanguageEditorMruGameExecutableFilePath)
                    ? defaultGameExecutableFilePath
                    : Settings.Default.LanguageEditorMruGameExecutableFilePath;
        }

        private void LanguageFileEditorForm_FormClosing(object sender, FormClosingEventArgs e)
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
            Import(LanguageFilePathTextBox.Text);

            // On import, assume user has made modifications to the data
            _isModified = true;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            Export(LanguageFilePathTextBox.Text);
        }

        private void GoToIndexTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        private void GoToIndexButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void FindTextTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Find();
            }
        }

        private void FindTextButton_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void QuickNavigationGroupBox_Enter(object sender, EventArgs e)
        {
            // Bounce focus onto the datagridview control
            LanguageDataGridView.Focus();
        }

        private void QuickNavigationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                // Parse RadioButton.Tag property
                var buttonTag = radioButton.Tag.ToString();
                int navigationId;
                if (!int.TryParse(buttonTag, out navigationId))
                {
                    throw new Exception("Unable to parse RadioButton.Tag property to int.");
                }

                // If magic number
                if (navigationId == -1)
                {
                    MessageBox.Show(
                        "Tyre codes are embedded in the game executable and cannot be changed through the language file." +
                        $"{Environment.NewLine}{Environment.NewLine}Please use the quick update button to patch the game executable with new tyre codes.",
                        "Quick navigation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Navigate back to the top
                    NavigateToRow(0);
                    return;
                }

                // Else navigate to specified index
                NavigateToRow(navigationId);
            }
        }

        private void UpdateTeamTextButton_Click(object sender, EventArgs e)
        {
            // Return if there is no data in the grid
            if (LanguageDataGridView.RowCount <= 0)
            {
                return;
            }

            var dialogResult = MessageBox.Show(
                "Text for short team names and team codes will be generated from the current team names entered in the language file." +
                $"{Environment.NewLine}{Environment.NewLine}However you will still need to manually update the text for the team chassis and end-of-year results." +
                $"{Environment.NewLine}{Environment.NewLine}Do you wish to proceed?",
                Settings.Default.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.Yes)
            {
                // Parse RadioButton.Tag properties
                int teamsFullId;
                if (!int.TryParse(TeamsFullRadioButton.Tag.ToString(), out teamsFullId))
                {
                    throw new Exception("Unable to parse RadioButton.Tag property to int.");
                }
                int teamsShortId;
                if (!int.TryParse(TeamsShortRadioButton.Tag.ToString(), out teamsShortId))
                {
                    throw new Exception("Unable to parse RadioButton.Tag property to int.");
                }
                int teamsCodeAId;
                if (!int.TryParse(TeamsCodeARadioButton.Tag.ToString(), out teamsCodeAId))
                {
                    throw new Exception("Unable to parse RadioButton.Tag property to int.");
                }
                int teamsCodeBId;
                if (!int.TryParse(TeamsCodeBRadioButton.Tag.ToString(), out teamsCodeBId))
                {
                    throw new Exception("Unable to parse RadioButton.Tag property to int.");
                }

                for (var i = 0; i < 11; i++)
                {
                    var teamFull = LanguageDataGridView.Rows[teamsFullId + i].Cells[0].Value.ToString();
                    var teamShort = teamFull.Substring(0, 3);
                    var teamCode = teamFull.Substring(0, 2).ToUpper();

                    LanguageDataGridView.Rows[teamsShortId + i].Cells[0].Value = teamShort;
                    LanguageDataGridView.Rows[teamsCodeAId + i].Cells[0].Value = teamCode;
                    LanguageDataGridView.Rows[teamsCodeBId + i].Cells[0].Value = teamCode;

                    // TODO consider removing, as manual intervention may be easier or another facility
                    //for (int j = 0; j < 12; j++)
                    //{
                    //    index = int.Parse(TeamsResultsRadioButton.Tag as string) + (i * j);
                    //    teamResults = LanguageDataGridView.Rows[index].Cells[0].Value.ToString();
                    //    oldTeamFull = "Arrows";
                    //    teamResults = teamResults.Replace(oldTeamFull, teamFull);
                    //    LanguageDataGridView.Rows[index].Cells[0].Value = teamResults;
                    //}
                }
            }
        }

        private void UpdateTyreCodesButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet.");
        }

        private void UpdateGameYearButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet.");
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfigureDataGridViewControl()
        {
            LanguageDataGridView.TopLeftHeaderCell.Value = "Index";
            LanguageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LanguageDataGridView.RowHeadersWidth = 100;
            LanguageDataGridView.AllowUserToAddRows = false;
            LanguageDataGridView.AllowUserToDeleteRows = false;
            LanguageDataGridView.AllowUserToResizeColumns = false;
            LanguageDataGridView.AllowUserToResizeRows = false;
            LanguageDataGridView.MultiSelect = false;
        }

        private bool ConfirmCloseFormWithUnsavedChanges()
        {
            // Return true if there are no unsaved changes 
            if (!_isModified)
            {
                return true;
            }

            // Prompt user whether to close form with unsaved changes
            var dialogResult = MessageBox.Show(
                    $"Are you sure you wish to close the language file editor?{Environment.NewLine}{Environment.NewLine}Any changes not exported will be lost.",
                    Settings.Default.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            return dialogResult == DialogResult.Yes;
        }

        private void Export(string languageFileFilePath)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Fill database with data from controls and export to file
                var languageDatabase = new LanguageDatabase();
                PopulateRecords(languageDatabase);
                languageDatabase.ExportDataToFile(languageFileFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured. Process aborted.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            MessageBox.Show("Export complete!", Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Find()
        {
            var isSearchValuePopulated = !string.IsNullOrWhiteSpace(FindTextTextBox.Text.Trim());

            // Return if there is no data in the grid or there is no search value to search on
            if ((LanguageDataGridView.RowCount <= 0) || !isSearchValuePopulated)
            {
                FindTextTextBox.Text = string.Empty;
                FindTextTextBox.Focus();
                return;
            }

            var startRow = 0;
            var endRow = LanguageDataGridView.RowCount - 1;
            var selectedRow = LanguageDataGridView.CurrentCell.RowIndex;

            // Get search value to search on
            var searchValue = FindTextTextBox.Text.ToUpper();

            // Loop through records until end of rows
            for (var i = selectedRow; i <= endRow; i++)
            {
                // Get value from cell in current row
                var rowValue = LanguageDataGridView.Rows[i].Cells[0].Value.ToString().ToUpper();

                // If row value contains search value
                if (rowValue.Contains(searchValue))
                {
                    // If first row match
                    if (i == selectedRow)
                    {
                        if (!_isFirstRowResult)
                        {
                            NavigateToRow(i);
                            _isFirstRowResult = true;
                            return;
                        }

                        // If first row as already been matched
                        continue;
                    }
                    else
                    {
                        _isFirstRowResult = true;
                    }

                    // Else any row match
                    NavigateToRow(i);
                    return;
                }
            }

            // Wrap around to start row and continue looping through records
            for (var i = startRow; i < selectedRow; i++)
            {
                // Get value from cell in current row
                var rowValue = LanguageDataGridView.Rows[i].Cells[0].Value.ToString().ToUpper();

                // If row value contains search value
                if (rowValue.Contains(searchValue))
                {
                    NavigateToRow(i);
                    return;
                }
            }

            // No matches
            _isFirstRowResult = false;
            FindTextTextBox.Focus();
        }

        private void Import(string languageFileFilePath)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                // Import from file to database and fill controls with data
                var languageDatabase = new LanguageDatabase();
                languageDatabase.ImportDataFromFile(languageFileFilePath);
                PopulateControls(languageDatabase);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error has occured. Process aborted.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            // Store most recently used (MRU) file paths on successful import
            Settings.Default.LanguageEditorMruLanguageFileFilePath = LanguageFilePathTextBox.Text;
            Settings.Default.LanguageEditorMruGameExecutableFilePath = GameExecutablePathTextBox.Text;

            MessageBox.Show("Import complete!", Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NavigateToRow(int index)
        {
            // If there are rows
            if (LanguageDataGridView.RowCount > 0)
            {
                // And index is valid
                if (index < LanguageDataGridView.RowCount)
                {
                    // Navigate to new index
                    LanguageDataGridView.CurrentCell = LanguageDataGridView.Rows[index].Cells[0];
                    if (index < 5)
                    {
                        LanguageDataGridView.FirstDisplayedScrollingRowIndex = 0;
                    }
                    else
                    {
                        LanguageDataGridView.FirstDisplayedScrollingRowIndex = index - 5;
                    }
                }
            }
        }

        private void PopulateControls(LanguageDatabase languageDatabase)
        {
            // Move data from database into controls
            LanguageDataGridView.DataSource = languageDatabase.LanguageStrings;

            // Format data grid
            var records = (IdentityCollection)LanguageDataGridView.DataSource;
            for (var i = 0; i < LanguageDataGridView.RowCount; i++)
            {
                // Populate row header cell with data value, in place of default numbering
                LanguageDataGridView.Rows[i].HeaderCell.Value = records[i].ResourceId;
            }
            LanguageDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void PopulateRecords(LanguageDatabase languageDatabase)
        {
            // Move data from controls into database
            languageDatabase.LanguageStrings = LanguageDataGridView.DataSource as IdentityCollection;
        }

        private void Search()
        {
            var text = GoToIndexTextBox.Text.Trim();

            // Return if there is no data in the grid
            if (LanguageDataGridView.RowCount <= 0)
            {
                GoToIndexTextBox.Text = string.Empty;
                GoToIndexTextBox.Focus();
                return;
            }

            // Return if unable to parse to integer
            int index;
            if (!int.TryParse(text, out index))
            {
                GoToIndexTextBox.Text = string.Empty;
                GoToIndexTextBox.Focus();
                return;
            }

            // Return if integer not within range
            if ((index < LanguageConnection.FirstLineId) || (index > LanguageConnection.LastLineId))
            {
                GoToIndexTextBox.Text = string.Empty;
                GoToIndexTextBox.Focus();
                return;
            }

            NavigateToRow(index);
            GoToIndexTextBox.Text = string.Empty;
            GoToIndexTextBox.Focus();
        }
    }
}
