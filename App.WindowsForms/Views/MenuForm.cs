using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using App.Core.Services;
using App.WindowsForms.Controllers;
using App.WindowsForms.Properties;

namespace App.WindowsForms.Views
{
    public sealed partial class MenuForm : EditorForm
    {
        private readonly RandomService _randomService;
        private MenuController _controller;

        public MenuForm(RandomService randomService)
        {
            _randomService = randomService ?? throw new ArgumentNullException(nameof(randomService));
            InitializeComponent();
        }

        public void SetController(MenuController controller)
        {
            _controller = controller;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.icon1;
            Text = $"{Settings.Default.ApplicationName} v{GetApplicationVersion()}";
            SetLogo();

            GameFolderAdministratorLabel.Text = string.Format(GameFolderAdministratorLabel.Text, Settings.Default.ApplicationName);
            SettingsEditorButton.Text = string.Format(SettingsEditorButton.Text, Settings.Default.ApplicationName);

            // On initial run
            if (Settings.Default.InitialRun)
            {
                // Use game folder in registry if available and valid
                if (_controller.IsGameFolderAvailableFromWindowsRegistry())
                {
                    var gameFolder = _controller.GetGameFolderFromWindowsRegistry();

                    if (_controller.IsGameFolderValid(gameFolder))
                    {
                        Settings.Default.UserGameFolderPath = gameFolder;
                        Settings.Default.UserGameLaunchCommand = Path.Combine(gameFolder, Settings.Default.DefaultGameExecutableName);
                    }
                }

                if (Debugger.IsAttached)
                {
                    // Override game folder
                    Settings.Default.UserGameFolderPath = @"C:\Gpw";
                    Settings.Default.UserGameLaunchCommand = Path.Combine(Settings.Default.UserGameFolderPath, Settings.Default.DefaultGameExecutableName);
                }

                Settings.Default.InitialRun = false;
                Settings.Default.Save();
            }

            GameFolderPathTextBox.Text = Settings.Default.UserGameFolderPath;
            GameFolderPanel.Show();
        }

        private void UpgradeGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.RunUpgradeGame();
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void ConfigureGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.RunConfigureGame();
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void GameExecutableEditorButton_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.RunBaseGameEditor();
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void LanguageFileEditorButton_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.RunLanguageFileEditor();
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void SaveGameEditorButton_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: _controller.RunSaveGameEditor();

                MessageBox.Show(
                    $"The save game editor is not available in this version of {Settings.Default.ApplicationName}.{Environment.NewLine}{Environment.NewLine}" +
                    $"Please try upgrading to the latest version of {Settings.Default.ApplicationName} " +
                    $"or search the Internet for the following editors to modify your save games.{Environment.NewLine}{Environment.NewLine}" +
                    $"Grand Prix World Editor 3.2 (GPWedit32.zip){Environment.NewLine}" +
                    $"GPW Patch v1.0 (gpwpatch.zip){Environment.NewLine}" +
                    "GPW Editor Beta (Lexxgpweditor.zip)",
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void AnalyseTelemetryButton_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.RunTelemetryViewer();
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void GameFolderChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get game folder from user
                var dialogResult = ProgramFolderBrowserDialog.ShowDialog();

                // Abort if user does not select a game folder
                if (dialogResult != DialogResult.OK)
                {
                    return;
                }

                // Set game folder to selected folder
                Settings.Default.UserGameFolderPath = ProgramFolderBrowserDialog.SelectedPath;
                Settings.Default.Save();

                GameFolderPathTextBox.Text = Settings.Default.UserGameFolderPath;
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void GameFolderOkButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Hide panel if game folder has been set
                if (!string.IsNullOrWhiteSpace(Settings.Default.UserGameFolderPath))
                {
                    GameFolderPanel.Hide();
                    MenuPanel.Show();
                    return;
                }

                // Else prompt the user to select the game folder
                MessageBox.Show(
                    $"{Settings.Default.ApplicationName} requires you to select the {Settings.Default.GameName} installation folder.{Environment.NewLine}{Environment.NewLine}" +
                    $"Click OK to browse for the {Settings.Default.GameName} installation folder.",
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Get game folder from user
                var dialogResult = ProgramFolderBrowserDialog.ShowDialog();

                // If user does not select a game folder
                if (dialogResult != DialogResult.OK)
                {
                    // Set game folder to default and show message to advise
                    Settings.Default.UserGameFolderPath = Settings.Default.DefaultGameFolderPath;
                    MessageBox.Show(
                        $"As you did not select an installation folder for {Settings.Default.GameName}, {Settings.Default.ApplicationName} " +
                        $"will assume that the game is installed at the following location.{Environment.NewLine}{Environment.NewLine}" +
                        $"{Settings.Default.DefaultGameFolderPath}",
                        Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    // Set game folder to selected folder
                    Settings.Default.UserGameFolderPath = ProgramFolderBrowserDialog.SelectedPath;
                }

                // Update other user paths
                Settings.Default.UserGameLaunchCommand = Path.Combine(Settings.Default.UserGameFolderPath, Settings.Default.DefaultGameExecutableName);

                Settings.Default.Save();

                GameFolderPanel.Hide();
                MenuPanel.Show();
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void SettingsEditorButton_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.RunSettingsEditor();
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void LaunchGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                var filePath = Settings.Default.UserGameLaunchCommand;

                if (!File.Exists(filePath))
                {
                    MessageBox.Show(
                        $"{Settings.Default.ApplicationName} was unable to launch the game.{Environment.NewLine}{Environment.NewLine}" +
                        $"The following game executable file was not found.{Environment.NewLine}{Environment.NewLine}" +
                        $"{filePath}{Environment.NewLine}{Environment.NewLine}" +
                        $"You can change the path to the game executable file through the {Settings.Default.ApplicationName} Settings menu.",
                        Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Process.Start(filePath);
                }
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        // TODO: Refer to alternate in ControllerBase
        private static string GetApplicationVersion()
        {
            if (Debugger.IsAttached)
            {
                return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            }

            return System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed
                    ? System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(2)
                    : FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
        }

        private void SetLogo()
        {
            var value = _randomService.Next(5);
            switch (value)
            {
                case 0:
                    LogoPictureBox.Image = Resources.logo1;
                    break;
                case 1:
                    LogoPictureBox.Image = Resources.logo2;
                    break;
                case 2:
                    LogoPictureBox.Image = Resources.logo3;
                    break;
                case 3:
                    LogoPictureBox.Image = Resources.logo4;
                    break;
                case 4:
                    LogoPictureBox.Image = Resources.logo5;
                    break;
                default:
                    LogoPictureBox.Image = Resources.logo1;
                    break;
            }
        }
    }
}