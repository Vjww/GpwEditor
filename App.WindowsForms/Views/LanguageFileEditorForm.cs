using System;
using System.Collections.Generic;
using System.Windows.Forms;
using App.WindowsForms.Controllers;
using App.WindowsForms.Models;

namespace App.WindowsForms.Views
{
    public partial class LanguageFileEditorForm : EditorForm
    {
        private LanguageFileEditorController _controller;
        private bool _isFirstRowResult;

        private const int FirstLineId = 0;
        private const int LastLineId = 7172;

        #region ToolTip Declarations
        private const string ReadOnlyToolTipText = " This field is read only.";

        private const string IdToolTipText = "The id of the language file resource record.";
        private const string IndexToolTipText = "The index of the language file resource record." + ReadOnlyToolTipText;
        private const string EnglishValueToolTipText = "The English value of the language file resource record.";
        private const string FrenchValueToolTipText = "The French value of the language file resource record.";
        private const string GermanValueToolTipText = "The German value of the language file resource record.";
        private const string IsSharedToolTipText = "The value of the language file resource record.";
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
            AddColumnToDataGridView(LanguagesDataGridView, CreateDataGridViewTextBoxColumn("EnglishValue", "English Value", EnglishValueToolTipText));
            AddColumnToDataGridView(LanguagesDataGridView, CreateDataGridViewTextBoxColumn("FrenchValue", "French Value", FrenchValueToolTipText));
            AddColumnToDataGridView(LanguagesDataGridView, CreateDataGridViewTextBoxColumn("GermanValue", "German Value", GermanValueToolTipText));
            AddColumnToDataGridView(LanguagesDataGridView, CreateDataGridViewTextBoxColumn("IsShared", "Is Shared Value", IsSharedToolTipText, false));

            BindDataGridViewToDataSource(LanguagesDataGridView, dataSource);

            ConfigureDataGridView(LanguagesDataGridView, "Index");

            // Additional sizing
            LanguagesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            LanguagesDataGridView.Columns["Index"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            LanguagesDataGridView.Columns["EnglishValue"].Width = 180;
            LanguagesDataGridView.Columns["FrenchValue"].Width = 180;
            LanguagesDataGridView.Columns["GermanValue"].Width = 180;
        }

        private void LanguageFileEditorForm_Load(object sender, EventArgs e)
        {
            _controller.LoadView();
        }

        private void LanguageFileEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_controller.CloseForm(); // Abort event if returns false
        }

        private void LanguageFileEditorTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !_controller.ChangeTab(); // Abort event if returns false
        }

        private void GameFolderPathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeGameFolder();
        }

        private void GameExecutablePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeGameExecutable();
        }

        private void EnglishLanguageFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeEnglishLanguageFile();
        }

        private void FrenchLanguageFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeFrenchLanguageFile();
        }

        private void GermanLanguageFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeGermanLanguageFile();
        }

        private void EnglishCommentaryFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeEnglishCommentaryFile();
        }

        private void FrenchCommentaryFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeFrenchCommentaryFile();
        }

        private void GermanCommentaryFilePathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeGermanCommentaryFile();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            _controller.Import();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            _controller.Export();
        }

        // TODO: Review       
        private void GoToIndexTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search();
            }
        }

        // TODO: Review
        private void GoToIndexButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        // TODO: Review
        private void FindTextTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Find();
            }
        }

        // TODO: Review
        private void FindTextButton_Click(object sender, EventArgs e)
        {
            Find();
        }

        // TODO: Review
        private void QuickNavigationGroupBox_Enter(object sender, EventArgs e)
        {
            // Bounce focus onto the datagridview control
            LanguagesDataGridView.Focus();
        }

        // TODO: Move logic to the controller, as views should not be concerned with logic where possible
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
            _controller.UpdateTeamText();
        }

        private void UpdateTyreCodesButton_Click(object sender, EventArgs e)
        {
            _controller.UpdateTyreCodes();
        }

        private void UpdateGameYearButton_Click(object sender, EventArgs e)
        {
            _controller.UpdateGameYear();
        }

        // TODO: Move logic to the controller, as views should not be concerned with logic where possible
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

        public string[] GetRichTextBoxLines()
        {
            return OverviewRichTextBox.Lines;
        }

        // TODO: Review
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

        // TODO: Move logic to the controller, as views should not be concerned with logic where possible
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

        public void SetRichTextBoxRichText(string text)
        {
            OverviewRichTextBox.Rtf = text;
        }

        // TODO: Move logic to the controller, as views should not be concerned with logic where possible
        private void LanguagesDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // TODO: Need to handle recursive executions of this event, due to manual changing of cell value

            if (!(sender is DataGridView dataGrid)) return;

            var row = dataGrid.Rows[e.RowIndex];
            bool.TryParse(row.Cells["IsShared"].Value.ToString(), out var isSharedValue);

            // Return if value is not shared across languages
            if (!isSharedValue) return;

            // Else update each language with the same value
            var changedValue = row.Cells[e.ColumnIndex].Value;
            row.Cells["EnglishValue"].Value = changedValue;
            row.Cells["FrenchValue"].Value = changedValue;
            row.Cells["GermanValue"].Value = changedValue;
        }
    }
}