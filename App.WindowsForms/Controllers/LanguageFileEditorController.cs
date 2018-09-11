using System;
using System.Collections.Generic;
using System.Windows.Forms;
using App.LanguageFileEditor.Application.Services.Application;
using App.LanguageFileEditor.Domain.Entities;
using App.Shared.Infrastructure.Services;
using App.WindowsForms.Factories;
using App.WindowsForms.Models;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public class LanguageFileEditorController : ControllerBase
    {
        private LanguageFileEditorForm _view;
        private bool _isImportOccurred;
        private bool _isModified;

        private readonly LanguageFileEditorApplicationService _languageFileEditorApplicationService;
        private readonly FormFactory _formFactory;

        public LanguageFileEditorController(
            LanguageFileEditorApplicationService languageFileEditorApplicationService,
            IMapperService mapperService,
            FormFactory formFactory)
            : base(mapperService)
        {
            _languageFileEditorApplicationService = languageFileEditorApplicationService ?? throw new ArgumentNullException(nameof(languageFileEditorApplicationService));
            _formFactory = formFactory ?? throw new ArgumentNullException(nameof(formFactory));
        }

        public void LoadView()
        {
            _view.SetFormIcon(GetFormIcon());
            _view.SetFormText($"{GetApplicationName()} - Language File Editor");
            _view.SetRichTextBoxRichText(ConvertStringArrayToRichText(_view.GetRichTextBoxLines()));

            // Populate paths with most recently used (MRU) or default
            _view.GameFolderPath = GetGameFolderMruOrDefault();
            _view.GameExecutableFilePath = GetGameExecutableMruOrDefault();
            _view.EnglishLanguageFilePath = GetEnglishLanguageFileMruOrDefault();
            _view.FrenchLanguageFilePath = GetFrenchLanguageFileMruOrDefault();
            _view.GermanLanguageFilePath = GetGermanLanguageFileMruOrDefault();
            _view.EnglishCommentaryFilePath = GetEnglishCommentaryFileMruOrDefault();
            _view.FrenchCommentaryFilePath = GetFrenchCommentaryFileMruOrDefault();
            _view.GermanCommentaryFilePath = GetGermanCommentaryFileMruOrDefault();
        }

        public void Run(Form parentView)
        {
            _view = _formFactory.Create<LanguageFileEditorForm>();
            _view.SetController(this);
            ShowView(parentView, _view);
        }

        public void Import()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _languageFileEditorApplicationService.Import(
                    _view.GameFolderPath,
                    _view.GameExecutableFilePath,
                    _view.EnglishLanguageFilePath,
                    _view.FrenchLanguageFilePath,
                    _view.GermanLanguageFilePath,
                    _view.EnglishCommentaryFilePath,
                    _view.FrenchCommentaryFilePath,
                    _view.GermanCommentaryFilePath);

                UpdateModelsFromService();

                _isImportOccurred = true;
                _isModified = false;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                _view.ShowErrorBox(ex.Message);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            _view.ShowMessageBox("Import complete!");
        }

        public void Export()
        {
            if (!_isImportOccurred)
            {
                _view.ShowMessageBox("Unable to export until a successful import has occurred.", MessageBoxIcon.Error);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                UpdateServiceFromModels();

                _languageFileEditorApplicationService.Export(
                    _view.GameFolderPath,
                    _view.GameExecutableFilePath,
                    _view.EnglishLanguageFilePath,
                    _view.FrenchLanguageFilePath,
                    _view.GermanLanguageFilePath,
                    _view.EnglishCommentaryFilePath,
                    _view.FrenchCommentaryFilePath,
                    _view.GermanCommentaryFilePath);
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                _view.ShowErrorBox(ex.Message);
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            _view.ShowMessageBox("Export complete!");
        }

        private void UpdateModelsFromService()
        {
            _view.Languages = UpdateModelFromService<IEnumerable<LanguageEntity>, IEnumerable<LanguageModel>>(_languageFileEditorApplicationService.DomainModel.Languages.GetLanguages);
        }

        private void UpdateServiceFromModels()
        {
            UpdateServiceFromModel<IEnumerable<LanguageModel>, IEnumerable<LanguageEntity>>(_languageFileEditorApplicationService.DomainModel.Languages.SetLanguages, _view.Languages);
        }

        public bool CloseForm()
        {
            if (CloseFormConfirmation(_view, _isModified, $"Are you sure you wish to close this window?{Environment.NewLine}{Environment.NewLine}Any changes not exported will be lost."))
            {
                return true;
            }

            return false;
        }

        public bool ChangeTab()
        {
            if (_isImportOccurred)
            {
                _isModified = true;
                return true;
            }

            _view.ShowMessageBox("Unable to switch tabs until a successful import has occurred.", MessageBoxIcon.Error);
            return false;
        }

        public void ChangeGameFolder()
        {
            try
            {
                var result = GetGameFolderPathFromFolderBrowserDialog(_view);
                _view.GameFolderPath = string.IsNullOrEmpty(result) ? _view.GameFolderPath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeGameExecutable()
        {
            try
            {
                var result = GetGameExecutablePathFromOpenFileDialog(_view);
                _view.GameExecutableFilePath = string.IsNullOrEmpty(result) ? _view.GameExecutableFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeEnglishLanguageFile()
        {
            try
            {
                var result = GetEnglishLanguageFilePathFromOpenFileDialog(_view);
                _view.EnglishLanguageFilePath = string.IsNullOrEmpty(result) ? _view.EnglishLanguageFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeFrenchLanguageFile()
        {
            try
            {
                var result = GetFrenchLanguageFilePathFromOpenFileDialog(_view);
                _view.FrenchLanguageFilePath = string.IsNullOrEmpty(result) ? _view.FrenchLanguageFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeGermanLanguageFile()
        {
            try
            {
                var result = GetGermanLanguageFilePathFromOpenFileDialog(_view);
                _view.GermanLanguageFilePath = string.IsNullOrEmpty(result) ? _view.GermanLanguageFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeEnglishCommentaryFile()
        {
            try
            {
                var result = GetEnglishCommentaryFilePathFromOpenFileDialog(_view);
                _view.EnglishCommentaryFilePath = string.IsNullOrEmpty(result) ? _view.EnglishCommentaryFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeFrenchCommentaryFile()
        {
            try
            {
                var result = GetFrenchCommentaryFilePathFromOpenFileDialog(_view);
                _view.FrenchCommentaryFilePath = string.IsNullOrEmpty(result) ? _view.FrenchCommentaryFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ChangeGermanCommentaryFile()
        {
            try
            {
                var result = GetGermanCommentaryFilePathFromOpenFileDialog(_view);
                _view.GermanCommentaryFilePath = string.IsNullOrEmpty(result) ? _view.GermanCommentaryFilePath : result;
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        // TODO: Implement
        public void UpdateTeamText()
        {
            try
            {
                // TODO: WIP, review and update the model from the controller
                // TODO: Make a call to update domain, or should happen automatically on export
                _view.ShowMessageBox("Not implemented yet.");

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
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        // TODO: Implement
        public void UpdateTyreCodes()
        {
            try
            {
                // TODO: Make a call to update domain, or should happen automatically on export
                _view.ShowMessageBox("Not implemented yet.");
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        // TODO: Implement
        public void UpdateGameYear()
        {
            try
            {
                // TODO: Make a call to update domain, or should happen automatically on export
                _view.ShowMessageBox("Not implemented yet.");
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }
    }
}