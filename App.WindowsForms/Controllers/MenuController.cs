using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using App.Core.Services;
using App.Shared.Infrastructure.Services;
using App.WindowsForms.Properties;
using App.WindowsForms.Services;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public class MenuController : ControllerBase
    {
        private readonly MenuForm _view;

        private readonly UpgradeGameController _upgradeGameController;
        private readonly ConfigureGameController _configureGameController;
        private readonly BaseGameEditorController _baseGameEditorController;
        private readonly LanguageFileEditorController _languageFileEditorController;
        private readonly SettingsEditorController _settingsEditorController;
        private readonly RandomService _randomService;
        private readonly GameRegistryKeyService _gameRegistryKeyService;

        public MenuController(
            IMapperService mapperService,
            MenuForm view,
            UpgradeGameController upgradeGameController,
            ConfigureGameController configureGameController,
            BaseGameEditorController baseGameEditorController,
            LanguageFileEditorController languageFileEditorController,
            SettingsEditorController settingsEditorController,
            RandomService randomService,
            GameRegistryKeyService gameRegistryKeyService)
            : base(mapperService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _upgradeGameController = upgradeGameController ?? throw new ArgumentNullException(nameof(upgradeGameController));
            _configureGameController = configureGameController ?? throw new ArgumentNullException(nameof(configureGameController));
            _baseGameEditorController = baseGameEditorController ?? throw new ArgumentNullException(nameof(baseGameEditorController));
            _languageFileEditorController = languageFileEditorController ?? throw new ArgumentNullException(nameof(languageFileEditorController));
            _settingsEditorController = settingsEditorController ?? throw new ArgumentNullException(nameof(settingsEditorController));
            _randomService = randomService ?? throw new ArgumentNullException(nameof(randomService));
            _gameRegistryKeyService = gameRegistryKeyService ?? throw new ArgumentNullException(nameof(gameRegistryKeyService));

            _view.SetController(this);
        }

        public void ChangeGameFolder()
        {
            try
            {
                // Prompt user to select game folder and store original/changed selection
                var result = GetGameFolderPathFromFolderBrowserDialog(_view);
                _view.GameFolderText = string.IsNullOrEmpty(result) ? _view.GameFolderText : result;

                // Update service
                SetUserGameFolderPath(_view.GameFolderText);
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void ConfirmGameFolder()
        {
            try
            {
                // Hide panel if game folder has been set
                if (!string.IsNullOrWhiteSpace(GetUserGameFolderPath()))
                {
                    CloseGameFolderPanel();
                    return;
                }

                _view.ShowMessageBox($"{GetApplicationName()} requires you to select the {GetGameName()} installation folder.{Environment.NewLine}{Environment.NewLine}" +
                                    $"Click OK to browse for the {GetGameName()} installation folder.");

                // Prompt user to select game folder
                var result = GetGameFolderPathFromFolderBrowserDialog(_view);

                // If user does not select a game folder, set to default
                if (string.IsNullOrEmpty(result))
                {
                    // Set game folder to default and show message to advise
                    SetUserGameFolderPath(GetDefaultGameFolderPath());
                    _view.ShowMessageBox($"As you did not select an installation folder for {GetGameName()}, {GetApplicationName()} " +
                                        $"will assume that the game is installed at the following location.{Environment.NewLine}{Environment.NewLine}" +
                                        $"{GetDefaultGameFolderPath()}");
                }
                else
                {
                    // Set game folder to selected folder
                    SetUserGameFolderPath(result);
                }

                // Update other user paths
                SetUserGameLaunchCommand(Path.Combine(GetUserGameFolderPath(), GetDefaultGameExecutableName()));

                CloseGameFolderPanel();
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void LaunchGame()
        {
            try
            {
                var filePath = GetUserGameLaunchCommand();

                if (!File.Exists(filePath))
                {
                    _view.ShowMessageBox($"{GetApplicationName()} was unable to launch the game.{Environment.NewLine}{Environment.NewLine}" +
                                         $"The following game executable file was not found.{Environment.NewLine}{Environment.NewLine}" +
                                         $"{filePath}{Environment.NewLine}{Environment.NewLine}" +
                                         $"You can change the path to the game executable file through the {GetApplicationName()} Settings menu.");
                    return;
                }

                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void LoadView()
        {
            _view.SetFormIcon(GetFormIcon());
            _view.SetFormText($"{GetApplicationName()} v{GetApplicationVersion()}");
            _view.SetFormLogo(GetLogo());

            _view.FormatGameFolderAdministratorLabelText(GetApplicationName());
            _view.FormatSettingsEditorButtonText(GetApplicationName());

            // On initial run
            if (GetInitialRun())
            {
                // Use game folder in registry if available and valid
                if (_gameRegistryKeyService.DoKeysExist())
                {
                    var gameFolder = GetGameFolderFromWindowsRegistry();

                    if (Directory.Exists(gameFolder))
                    {
                        SetUserGameFolderPath(gameFolder);
                        SetUserGameLaunchCommand(Path.Combine(gameFolder, GetDefaultGameExecutableName()));
                    }
                }

                if (Debugger.IsAttached)
                {
                    // Override game folder
                    SetUserGameFolderPath(@"C:\Gpw");
                    SetUserGameLaunchCommand(Path.Combine(GetUserGameFolderPath(), GetDefaultGameExecutableName()));
                }

                SetInitialRun(false);
            }

            _view.GameFolderText = GetUserGameFolderPath();
            _view.ShowGameFolderPanel();
        }

        public void Run()
        {
            Application.Run(_view);
        }

        public void RunBaseGameEditor()
        {
            try
            {
                _baseGameEditorController.Run(_view);
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void RunConfigureGame()
        {
            try
            {
                _configureGameController.Run(_view);
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void RunLanguageFileEditor()
        {
            try
            {
                _languageFileEditorController.Run(_view);
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void RunSaveGameEditor()
        {
            try
            {
                //_saveGameEditorController.Run(_view);

                _view.ShowMessageBox($"The save game editor is not available in this version of {Settings.Default.ApplicationName}.{Environment.NewLine}{Environment.NewLine}" +
                                    $"Please try upgrading to the latest version of {Settings.Default.ApplicationName} " +
                                    $"or search the Internet for the following editors to modify your save games.{Environment.NewLine}{Environment.NewLine}" +
                                    $"Grand Prix World Editor 3.2 (GPWedit32.zip){Environment.NewLine}" +
                                    $"GPW Patch v1.0 (gpwpatch.zip){Environment.NewLine}" +
                                    "GPW Editor Beta (Lexxgpweditor.zip)");
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void RunSettingsEditor()
        {
            try
            {
                _settingsEditorController.Run(_view);
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void RunTelemetryViewer()
        {
            try
            {
                //_telemetryViewerController.Run(_view);

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        public void RunUpgradeGame()
        {
            try
            {
                _upgradeGameController.Run(_view);
            }
            catch (Exception ex)
            {
                _view.ShowErrorBox(ex.Message);
            }
        }

        private void CloseGameFolderPanel()
        {
            _view.HideGameFolderPanel();
            _view.ShowMenuPanel();
        }

        private string GetGameFolderFromWindowsRegistry()
        {
            _gameRegistryKeyService.ReadKeys();
            return _gameRegistryKeyService.PathValue;
        }

        private Bitmap GetLogo()
        {
            var value = _randomService.Next(5);
            switch (value)
            {
                case 0:
                    return Resources.logo1;
                case 1:
                    return Resources.logo2;
                case 2:
                    return Resources.logo3;
                case 3:
                    return Resources.logo4;
                case 4:
                    return Resources.logo5;
                default:
                    return Resources.logo1;
            }
        }
    }
}