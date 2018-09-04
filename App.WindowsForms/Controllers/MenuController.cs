using System;
using System.Windows.Forms;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public class MenuController
    {
        private readonly MenuForm _view;

        private readonly UpgradeGameController _upgradeGameController;
        private readonly ConfigureGameController _configureGameController;
        private readonly BaseGameEditorController _baseGameEditorController;
        private readonly LanguageFileEditorController _languageFileEditorController;
        private readonly SettingsEditorController _settingsEditorController;

        public MenuController(
            MenuForm view,
            UpgradeGameController upgradeGameController,
            ConfigureGameController configureGameController,
            BaseGameEditorController baseGameEditorController,
            LanguageFileEditorController languageFileEditorController,
            SettingsEditorController settingsEditorController)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _upgradeGameController = upgradeGameController ?? throw new ArgumentNullException(nameof(upgradeGameController));
            _configureGameController = configureGameController ?? throw new ArgumentNullException(nameof(configureGameController));
            _baseGameEditorController = baseGameEditorController ?? throw new ArgumentNullException(nameof(baseGameEditorController));
            _languageFileEditorController = languageFileEditorController ?? throw new ArgumentNullException(nameof(languageFileEditorController));
            _settingsEditorController = settingsEditorController ?? throw new ArgumentNullException(nameof(settingsEditorController));

            _view.SetController(this);
        }

        public void Run()
        {
            Application.Run(_view);
        }

        public void RunUpgradeGame()
        {
            _upgradeGameController.Run(_view);
        }

        public void RunConfigureGame()
        {
            _configureGameController.Run(_view);
        }

        public void RunBaseGameEditor()
        {
            _baseGameEditorController.Run(_view);
        }

        public void RunSaveGameEditor()
        {
            //_saveGameEditorController.Run(_view);
        }

        public void RunLanguageFileEditor()
        {
            _languageFileEditorController.Run(_view);
        }

        public void RunSettingsEditor()
        {
            _settingsEditorController.Run(_view);
        }

        public void RunTelemetryViewer()
        {
            throw new NotImplementedException();
        }

        public bool IsGameFolderAvailableFromWindowsRegistry()
        {
            // TODO: Implement
            return false;
        }

        public string GetGameFolderFromWindowsRegistry()
        {
            // TODO: Implement
            return null;
        }

        public bool IsGameFolderValid(string gameFolder)
        {
            // TODO: Implement
            return false;
        }
    }
}