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

        public MenuController(
            MenuForm view,
            UpgradeGameController upgradeGameController,
            ConfigureGameController configureGameController,
            BaseGameEditorController baseGameEditorController)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _upgradeGameController = upgradeGameController ?? throw new ArgumentNullException(nameof(upgradeGameController));
            _configureGameController = configureGameController ?? throw new ArgumentNullException(nameof(configureGameController));
            _baseGameEditorController = baseGameEditorController ?? throw new ArgumentNullException(nameof(baseGameEditorController));

            _view.SetController(this);
        }

        public void Run()
        {
            Application.Run(_view);
        }

        public void RunUpgradeGame()
        {
            EnsureConfiguredGameFolder();
            _upgradeGameController.Run(_view);
        }

        public void RunConfigureGame()
        {
            EnsureConfiguredGameFolder();
            _configureGameController.Run(_view);
        }

        public void RunBaseGameEditor()
        {
            EnsureConfiguredGameFolder();
            _baseGameEditorController.Run(_view);
        }

        public void RunSaveGameEditor()
        {
            //EnsureConfiguredGameFolder();
            //_saveGameController.Run(_view);
        }

        public void RunLanguageFileEditor()
        {
            //EnsureConfiguredGameFolder();
            //_languageFileController.Run(_view);
        }

        public void RunRegistryKeysEditor()
        {
            //EnsureConfiguredGameFolder();
            //_registryKeysController.Run(_view);
        }

        private void EnsureConfiguredGameFolder()
        {
            // TODO: // If game folder has not been set
            // TODO: if (string.IsNullOrWhiteSpace(Settings.Default.UserGameFolderPath))
            // TODO: {
            // TODO:     ConfigureGameFolder();
            // TODO:     return;
            // TODO: }
        }
    }
}