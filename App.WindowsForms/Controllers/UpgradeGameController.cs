using System;
using System.IO;
using System.Windows.Forms;
using App.BaseGameEditor.Application.Services.Application;
using App.Shared.Infrastructure.Services;
using App.WindowsForms.Factories;
using App.WindowsForms.Properties;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public class UpgradeGameController : ControllerBase
    {
        private UpgradeGameForm _view;

        private readonly UpgradeGameApplicationService _upgradeGameApplicationService;
        private readonly FormFactory _formFactory;

        public UpgradeGameController(
            UpgradeGameApplicationService upgradeGameApplicationService,
            IMapperService mapperService,
            FormFactory formFactory)
            : base(mapperService)
        {
            _upgradeGameApplicationService = upgradeGameApplicationService ?? throw new ArgumentNullException(nameof(upgradeGameApplicationService));
            _formFactory = formFactory ?? throw new ArgumentNullException(nameof(formFactory));
        }

        public void Run(Form parentView)
        {
            _view = _formFactory.Create<UpgradeGameForm>();
            _view.SetController(this);
            ShowView(parentView, _view);
        }

        public void Upgrade()
        {
            // Preliminary validation
            if (!Directory.Exists(_view.GameFolderPath))
            {
                _view.ShowMessageBox("Unable to upgrade as the selected game folder does not exist or is invalid.", MessageBoxIcon.Error);
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Use earlier validated game folder path to build file paths with default file names retreived from project properties
                var gameFolderPath = _view.GameFolderPath;
                var gameExecutableFilePath = Path.Combine(gameFolderPath, Settings.Default.DefaultGameExecutableName);
                var englishLanguageFilePath = Path.Combine(gameFolderPath, Settings.Default.DefaultEnglishLanguageFileName);
                var frenchLanguageFilePath = Path.Combine(gameFolderPath, Settings.Default.DefaultFrenchLanguageFileName);
                var germanLanguageFilePath = Path.Combine(gameFolderPath, Settings.Default.DefaultGermanLanguageFileName);
                var englishCommentaryFilePath = Path.Combine(gameFolderPath, "text", Settings.Default.DefaultEnglishCommentaryFileName);
                var frenchCommentaryFilePath = Path.Combine(gameFolderPath, "textf", Settings.Default.DefaultFrenchCommentaryFileName);
                var germanCommentaryFilePath = Path.Combine(gameFolderPath, "textg", Settings.Default.DefaultGermanCommentaryFileName);

                _upgradeGameApplicationService.Upgrade(
                    gameFolderPath,
                    gameExecutableFilePath,
                    englishLanguageFilePath,
                    frenchLanguageFilePath,
                    germanLanguageFilePath,
                    englishCommentaryFilePath,
                    frenchCommentaryFilePath,
                    germanCommentaryFilePath);
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

            _view.ShowMessageBox("Upgrade complete!");
        }

        public void LoadView()
        {
            _view.SetFormIcon(GetFormIcon());
            _view.SetFormText($"{GetApplicationName()} - Upgrade Game");
            _view.SetRichTextBoxRichText(ConvertStringArrayToRichText(_view.GetRichTextBoxLines()));

            // Populate paths with most recently used (MRU) or default
            _view.GameFolderPath = GetGameFolderMruOrDefault();
        }

        public bool CloseForm()
        {
            if (CloseFormConfirmation(_view, true, "Are you sure you wish to close this window?"))
            {
                return true;
            }

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
    }
}