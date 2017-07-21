using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using GpwEditor.Properties;

namespace GpwEditor.Views
{
    public sealed partial class MenuForm : EditorForm
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private static string GetApplicationVersion()
        {
#if (!DEBUG)
            {
                return System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed
                    ? System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(2)
                    : FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
            }
#else
            {
                return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            }
#endif
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.icon1;
            Text = $"{Settings.Default.ApplicationName} v{GetApplicationVersion()}";
            SetLogo();

            // On initial run
            if (Settings.Default.InitialRun)
            {
                //
            }

#if DEBUG
            Settings.Default.UserGameFolderPath = @"C:\Gpw";
#endif

            Settings.Default.InitialRun = false;
            Settings.Default.Save();
        }

        private void UpgradeGameButton_Click(object sender, EventArgs e)
        {
            SwitchContext(new UpgradeGameForm());
        }

        private void ConfigureGameButton_Click(object sender, EventArgs e)
        {
            SwitchContext(new ConfigureGameForm());
        }

        private void GameEditorButton_Click(object sender, EventArgs e)
        {
            SwitchContext(new GameExecutableEditorForm());
        }

        private void SaveGameEditorButton_Click(object sender, EventArgs e)
        {
            //SwitchContext(new SaveGameEditorForm());

            MessageBox.Show(
                $"The save game editor is not available in this version of {Settings.Default.ApplicationName}.{Environment.NewLine}{Environment.NewLine}" +
                $"Please try upgrading to the latest version of {Settings.Default.ApplicationName} " +
                $"or search the Internet for the following editors to modify your save games.{Environment.NewLine}{Environment.NewLine}" +
                $"Grand Prix World Editor 3.2 (GPWedit32.zip){Environment.NewLine}" +
                $"GPW Patch v1.0 (gpwpatch.zip){Environment.NewLine}" +
                "GPW Editor Beta (Lexxgpweditor.zip)",
                Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LanguageFileEditorButton_Click(object sender, EventArgs e)
        {
            SwitchContext(new LanguageFileEditorForm());
        }

        private void RegistryKeysButton_Click(object sender, EventArgs e)
        {
            SwitchContext(new RegistryKeysForm());
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SwitchContext(new SettingsForm());
        }

        private void LaunchGameButton_Click(object sender, EventArgs e)
        {
            var filePath = Settings.Default.UserGameExecutablePath;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = Path.Combine(Settings.Default.UserGameFolderPath, Settings.Default.DefaultGameExecutableName);
            }

            if (!File.Exists(filePath))
            {
                MessageBox.Show(
                    $"{Settings.Default.ApplicationName} was unable to launch the game. The following game executable file was not found.{Environment.NewLine}{Environment.NewLine}" +
                    $"{filePath}{Environment.NewLine}{Environment.NewLine}" +
                    $"You can change the path to the game executable file through the {Settings.Default.ApplicationName} Settings menu.",
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                Process.Start(filePath);
            }
        }

        private void ConfigureGameFolder()
        {
            try
            {
                // Prompt the user to select the game folder
                MessageBox.Show(
                    $"{Settings.Default.ApplicationName} requires you to select the {Settings.Default.GameName} installation folder.{Environment.NewLine}{Environment.NewLine}" +
                    $"Click OK to browse for the {Settings.Default.GameName} installation folder.",
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Get game folder from user
                var dialogResult = GameFolderBrowserDialog.ShowDialog();

                // If user does not select an installation folder
                if (dialogResult != DialogResult.OK)
                {
                    // Set installation folder to default and show message to advise
                    Settings.Default.UserGameFolderPath = Settings.Default.DefaultGameFolderPath;
                    MessageBox.Show(
                        $"As you did not select an installation folder for {Settings.Default.GameName}, {Settings.Default.ApplicationName} will assume that the game is installed at the following location.{Environment.NewLine}{Environment.NewLine}" +
                        $"{Settings.Default.DefaultGameFolderPath}",
                        Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    Settings.Default.UserGameFolderPath = GameFolderBrowserDialog.SelectedPath;
                }

                // Save selected game installation folder
                Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"{Settings.Default.ApplicationName} has encountered an error while attempting to configure the game folder.{Environment.NewLine}{Environment.NewLine}" +
                    $"Error: {ex.Message}{Environment.NewLine}{Environment.NewLine}" +
                    $"To resolve this error, try running {Settings.Default.ApplicationName} as an administrator.",
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SwitchContext(Form form)
        {
            // If game folder has not been set
            if (string.IsNullOrWhiteSpace(Settings.Default.UserGameFolderPath))
            {
                ConfigureGameFolder();
                return;
            }
            SwitchToForm(this, form);
        }

        private void SetLogo()
        {
            var random = new Random();
            var value = random.Next(5);
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