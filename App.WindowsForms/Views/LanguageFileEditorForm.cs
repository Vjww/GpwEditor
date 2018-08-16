using System;
using System.Collections.Generic;
using System.Windows.Forms;
using App.WindowsForms.Controllers;
using App.WindowsForms.Models;
using App.WindowsForms.Properties;

namespace App.WindowsForms.Views
{
    public partial class LanguageFileEditorForm : EditorForm
    {
        private LanguageFileEditorController _controller;
        private bool _isFirstRowResult;
        private bool _isImportOccurred;

        private const int FirstLineId = 0;
        private const int LastLineId = 7172;

        #region ToolTip Declarations
        private const string ReadOnlyToolTipText = " This field is read only.";

        private const string IdToolTipText = "The id of the language file resource record.";
        private const string IndexToolTipText = "The index of the language file resource record." + ReadOnlyToolTipText;
        private const string ValueToolTipText = "The value of the language file resource record.";
        #endregion

        public string GameFolderPath { get => GameFolderPathTextBox.Text; set => GameFolderPathTextBox.Text = value; }
        public string GameExecutableFilePath { get => GameExecutablePathTextBox.Text; set => GameExecutablePathTextBox.Text = value; }
        public string EnglishLanguageFilePath { get => EnglishLanguageFilePathTextBox.Text; set => EnglishLanguageFilePathTextBox.Text = value; }
        public string FrenchLanguageFilePath { get => FrenchLanguageFilePathTextBox.Text; set => FrenchLanguageFilePathTextBox.Text = value; }
        public string GermanLanguageFilePath { get => GermanLanguageFilePathTextBox.Text; set => GermanLanguageFilePathTextBox.Text = value; }
        public string EnglishCommentaryFilePath { get => EnglishCommentaryFilePathTextBox.Text; set => EnglishCommentaryFilePathTextBox.Text = value; }
        public string FrenchCommentaryFilePath { get => FrenchCommentaryFilePathTextBox.Text; set => FrenchCommentaryFilePathTextBox.Text = value; }
        public string GermanCommentaryFilePath { get => GermanCommentaryFilePathTextBox.Text; set => GermanCommentaryFilePathTextBox.Text = value; }

        public IEnumerable<LanguageModel> Languages
        {
            get => (IEnumerable<LanguageModel>)LanguagesDataGridView.DataSource;
            set => BuildResourcesDataGridView(value);
        }

        public LanguageFileEditorForm()
        {
            InitializeComponent();
        }

        public void SetController(LanguageFileEditorController controller)
        {
            _controller = controller;
        }

        private void BuildResourcesDataGridView(IEnumerable<LanguageModel> dataSource)
        {
            ResetDataGridView(LanguagesDataGridView);

            AddColumnToDataGridView(LanguagesDataGridView, CreateDataGridViewTextBoxColumn("Id", "Id", IdToolTipText, false));
            AddColumnToDataGridView(LanguagesDataGridView, CreateDataGridViewTextBoxColumn("Index", "Index", IndexToolTipText, true, true));
            AddColumnToDataGridView(LanguagesDataGridView, CreateDataGridViewTextBoxColumn("EnglishValue", "English Value", ValueToolTipText));
            AddColumnToDataGridView(LanguagesDataGridView, CreateDataGridViewTextBoxColumn("FrenchValue", "French Value", ValueToolTipText));
            AddColumnToDataGridView(LanguagesDataGridView, CreateDataGridViewTextBoxColumn("GermanValue", "German Value", ValueToolTipText));

            BindDataGridViewToDataSource(LanguagesDataGridView, dataSource);

            ConfigureDataGridView(LanguagesDataGridView, "Index");
        }

        private void LanguageFileEditorForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.icon1;
            Text = $"{Settings.Default.ApplicationName} - Language File Editor";
            ConvertLinesToRtf(OverviewRichTextBox);

            // Populate paths with most recently used (MRU) or default
            GameFolderPath = GetGameFolderMruOrDefault();
            GameExecutableFilePath = GetGameExecutableMruOrDefault();
            EnglishLanguageFilePath = GetEnglishLanguageFileMruOrDefault();
            FrenchLanguageFilePath = GetFrenchLanguageFileMruOrDefault();
            GermanLanguageFilePath = GetGermanLanguageFileMruOrDefault();
            EnglishCommentaryFilePath = GetEnglishCommentaryFileMruOrDefault();
            FrenchCommentaryFilePath = GetFrenchCommentaryFileMruOrDefault();
            GermanCommentaryFilePath = GetGermanCommentaryFileMruOrDefault();
        }

        private void LanguageFileEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseFormConfirmation(true, $"Are you sure you wish to close this window?{Environment.NewLine}{Environment.NewLine}Any changes not exported will be lost."))
            {
                return;
            }

            e.Cancel = true; // Abort event
        }

        private void LanguageFileEditorTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_isImportOccurred)
            {
                e.Cancel = true; // Abort event
                ShowMessageBox("Unable to switch tabs until a successful import has occurred.", MessageBoxIcon.Error);
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Import();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            if (!_isImportOccurred)
            {
                ShowMessageBox("Unable to export until a successful import has occurred.", MessageBoxIcon.Error);
                return;
            }

            Export();
        }

        private void GameFolderPathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetGameFolderPathFromFolderBrowserDialog();
            GameFolderPath = string.IsNullOrEmpty(result) ? GameFolderPath : result;
        }

        private void GameExecutablePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetGameExecutablePathFromOpenFileDialog();
            GameExecutableFilePath = string.IsNullOrEmpty(result) ? GameExecutableFilePath : result;
        }

        private void EnglishLanguageFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetEnglishLanguageFilePathFromOpenFileDialog();
            EnglishLanguageFilePath = string.IsNullOrEmpty(result) ? EnglishLanguageFilePath : result;
        }

        private void FrenchLanguageFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetFrenchLanguageFilePathFromOpenFileDialog();
            FrenchLanguageFilePath = string.IsNullOrEmpty(result) ? FrenchLanguageFilePath : result;
        }

        private void GermanLanguageFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetGermanLanguageFilePathFromOpenFileDialog();
            GermanLanguageFilePath = string.IsNullOrEmpty(result) ? GermanLanguageFilePath : result;
        }

        private void EnglishCommentaryFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetEnglishCommentaryFilePathFromOpenFileDialog();
            EnglishCommentaryFilePath = string.IsNullOrEmpty(result) ? EnglishCommentaryFilePath : result;
        }

        private void FrenchCommentaryFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetFrenchCommentaryFilePathFromOpenFileDialog();
            FrenchCommentaryFilePath = string.IsNullOrEmpty(result) ? FrenchCommentaryFilePath : result;
        }

        private void GermanCommentaryFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            var result = GetGermanCommentaryFilePathFromOpenFileDialog();
            GermanCommentaryFilePath = string.IsNullOrEmpty(result) ? GermanCommentaryFilePath : result;
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
            LanguagesDataGridView.Focus();
        }

        private void QuickNavigationRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                // Parse RadioButton.Tag property
                var buttonTag = radioButton.Tag.ToString();
                if (!int.TryParse(buttonTag, out var navigationId))
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
            ShowMessageBox("Not implemented yet.");

            // TODO: Review and move logic to controller where necessary
            // TODO: e.g. _controller.UpdateTeamText() which in return updates model

            /* 
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
                    var teamFull = LanguageDataGridView.Rows[teamsFullId + i].Cells[2].Value.ToString();
                    var teamShort = teamFull.Substring(0, 3);
                    var teamCode = teamFull.Substring(0, 2).ToUpper();

                    LanguageDataGridView.Rows[teamsShortId + i].Cells[2].Value = teamShort;
                    LanguageDataGridView.Rows[teamsCodeAId + i].Cells[2].Value = teamCode;
                    LanguageDataGridView.Rows[teamsCodeBId + i].Cells[2].Value = teamCode;

                    // TODO consider removing, as manual intervention may be easier or another facility
                    //for (int j = 0; j < 12; j++)
                    //{
                    //    index = int.Parse(TeamsResultsRadioButton.Tag as string) + (i * j);
                    //    teamResults = LanguageDataGridView.Rows[index].Cells[2].Value.ToString();
                    //    oldTeamFull = "Arrows";
                    //    teamResults = teamResults.Replace(oldTeamFull, teamFull);
                    //    LanguageDataGridView.Rows[index].Cells[2].Value = teamResults;
                    //}
                }
            }
            */
        }

        private void UpdateTyreCodesButton_Click(object sender, EventArgs e)
        {
            ShowMessageBox("Not implemented yet.");

            // TODO: Make a call to the controller to update domain, or should happen automatically on export
            // TODO: e.g. _controller.UpdateTyreCodes() which in return updates model
        }

        private void UpdateGameYearButton_Click(object sender, EventArgs e)
        {
            ShowMessageBox("Not implemented yet.");

            // TODO: Make a call to the controller to update domain, or should happen automatically on export
            // TODO: e.g. _controller.UpdateTyreCodes() which in return updates model
        }

        private void Export()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                _controller.Export();
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

        private void Import()
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                _controller.Import();
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

        private void Find()
        {
            var isSearchValuePopulated = !string.IsNullOrWhiteSpace(FindTextTextBox.Text.Trim());

            // Return if there is no data in the grid or there is no search value to search on
            if (LanguagesDataGridView.RowCount <= 0 || !isSearchValuePopulated)
            {
                FindTextTextBox.Text = string.Empty;
                FindTextTextBox.Focus();
                return;
            }

            const int startRow = 0;
            var endRow = LanguagesDataGridView.RowCount - 1;
            var selectedRow = LanguagesDataGridView.CurrentCell.RowIndex;

            // Get search value to search on
            var searchValue = FindTextTextBox.Text.ToUpper();

            // Loop through records until end of rows
            for (var i = selectedRow; i <= endRow; i++)
            {
                // Get value from cell in current row
                var rowValue = LanguagesDataGridView.Rows[i].Cells[2].Value.ToString().ToUpper();

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
                var rowValue = LanguagesDataGridView.Rows[i].Cells[2].Value.ToString().ToUpper();

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

        private void NavigateToRow(int index)
        {
            // If there are rows
            if (LanguagesDataGridView.RowCount > 0)
            {
                // And index is valid
                if (index < LanguagesDataGridView.RowCount)
                {
                    // Navigate to new index
                    LanguagesDataGridView.CurrentCell = LanguagesDataGridView.Rows[index].Cells[2];
                    if (index < 5)
                    {
                        LanguagesDataGridView.FirstDisplayedScrollingRowIndex = 0;
                    }
                    else
                    {
                        LanguagesDataGridView.FirstDisplayedScrollingRowIndex = index - 5;
                    }
                }
            }
        }

        private void Search()
        {
            var text = GoToIndexTextBox.Text.Trim();

            // Return if there is no data in the grid
            if (LanguagesDataGridView.RowCount <= 0)
            {
                GoToIndexTextBox.Text = string.Empty;
                GoToIndexTextBox.Focus();
                return;
            }

            // Return if unable to parse to integer
            if (!int.TryParse(text, out var index))
            {
                GoToIndexTextBox.Text = string.Empty;
                GoToIndexTextBox.Focus();
                return;
            }

            // Return if integer not within range
            if (index < FirstLineId || index > LastLineId)
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