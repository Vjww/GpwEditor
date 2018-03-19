using System;
using System.Windows.Forms;
using App.WindowsForms.Views;

namespace App.WindowsForms.Controllers
{
    public class MenuController
    {
        private readonly MenuForm _menuView;
        private readonly BaseGameController _baseGameController;

        public MenuController(
            MenuForm menuView,
            BaseGameController baseGameController)
        {
            _menuView = menuView ?? throw new ArgumentNullException(nameof(menuView));
            _baseGameController = baseGameController ?? throw new ArgumentNullException(nameof(baseGameController));

            _menuView.SetController(this);
        }

        public void Run()
        {
            Application.Run(_menuView);
        }

        public void RunUpgradeGame()
        {
            //EnsureConfiguredGameFolder();
            //_upgradeGameController.Run(_menuView);
        }

        public void RunBaseGameEditor()
        {
            EnsureConfiguredGameFolder();
            _baseGameController.Run(_menuView);
        }

        public void RunSaveGameEditor()
        {
            //EnsureConfiguredGameFolder();
            //_saveGameController.Run(_menuView);
        }

        public void RunLanguageFileEditor()
        {
            //EnsureConfiguredGameFolder();
            //_languageFileController.Run(_menuView);
        }

        public void RunConfigureGame()
        {
            //EnsureConfiguredGameFolder();
            //_configureGameController.Run(_menuView);
        }

        public void RunRegistryKeysEditor()
        {
            //EnsureConfiguredGameFolder();
            //_registryKeysController.Run(_menuView);
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