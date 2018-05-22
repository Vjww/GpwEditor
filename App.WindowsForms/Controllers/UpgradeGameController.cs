using System;
using System.IO;
using System.Windows.Forms;
using App.BaseGameEditor.Application.Services;
using App.BaseGameEditor.Infrastructure.Services;
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
            // TODO: if (!FolderExists(gameFolderPath))
            // TODO: if (!VerifyGameFolder(gameFolderPath))

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
    }
}