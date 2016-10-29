using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using GpwEditor.Properties;

namespace GpwEditor
{
    public sealed partial class MenuForm : Form
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
            // Set icon
            Icon = Resources.icon1;

            // Set form title text
            Text = $"{Settings.Default.ApplicationName} v{GetApplicationVersion()}";

            SelectRandomLogo();

            // On initial run
            if (Settings.Default.InitialRun)
            {
                //
            }

            // If game folder has not been set
            if (string.IsNullOrWhiteSpace(Settings.Default.UserGameFolderPath))
            {
                // http://stackoverflow.com/a/218740
                Invoke((MethodInvoker) ConfigureGameFolder); // TODO test, intent to show form before dialog
                //ConfigureGameFolder(); // TODO remove
            }

            Settings.Default.InitialRun = false;
            Settings.Default.Save();
        }

        private void UpgradeGameButton_Click(object sender, EventArgs e)
        {
            // Hide parent form and show child form
            SwitchToForm(this, new UpgradeGameForm());
        }

        private void GameEditorButton_Click(object sender, EventArgs e)
        {
            // Hide parent form and show child form
            SwitchToForm(this, new GameExecutableEditorForm());
        }

        private void SaveGameEditorButton_Click(object sender, EventArgs e)
        {
            // Hide parent form and show child form
            //SwitchToForm(this, new SaveGameEditorForm());
        }

        private void LanguageFileEditorButton_Click(object sender, EventArgs e)
        {
            // Hide parent form and show child form
            SwitchToForm(this, new LanguageFileEditorForm());
        }

        private void RegistryKeysButton_Click(object sender, EventArgs e)
        {
            // Hide parent form and show child form
            SwitchToForm(this, new RegistryKeysForm());
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            // Hide parent form and show child form
            SwitchToForm(this, new SettingsForm());
        }

        private void LaunchGameButton_Click(object sender, EventArgs e)
        {
            var filePath = Settings.Default.UserExecutableFilePath;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                filePath = Path.Combine(Settings.Default.UserGameFolderPath, Settings.Default.DefaultExecutableFileName);
            }

            if (!File.Exists(filePath))
            {
                MessageBox.Show(
                    string.Format(
                        "{0} was unable to launch the game. The following game file was not found.{1}{1}" + filePath +
                        "{1}{1}" + "You can change the path to the game file through the {0} settings menu.",
                        Settings.Default.ApplicationName, Environment.NewLine), Settings.Default.ApplicationName,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string.Format("{0} requires you to select the {1} installation folder.{2}{2}Click OK to browse for the {1} installation folder.",
                        Settings.Default.ApplicationName, Settings.Default.GameName, Environment.NewLine),
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Get game folder from user
                var folderDialogResult = GameFolderBrowserDialog.ShowDialog();

                // If user does not select an installation folder
                if (folderDialogResult != DialogResult.OK)
                {
                    // Set installation folder to default and show message to advise
                    Settings.Default.UserGameFolderPath = Settings.Default.DefaultGameFolderPath;
                    MessageBox.Show(
                        string.Format("As you did not select an installation folder for {1}, {0} will assume that the game is installed at the following location.{2}{2}{3}",
                            Settings.Default.ApplicationName, Settings.Default.GameName, Environment.NewLine, Settings.Default.DefaultGameFolderPath),
                        Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    string.Format(
                        "{0} has encountered an error while attempting to configure the game folder.{1}{1}" + "Error: {2}{1}{1}To resolve this error, try running {0} as an administrator.",
                        Settings.Default.ApplicationName, Environment.NewLine, ex.Message),
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectRandomLogo()
        {
            var rand = new Random();
            var value = rand.Next(5);
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

        private static void SwitchToForm(Form parentForm, Form childForm)
        {
            childForm.Show(parentForm);
            parentForm.Hide();
            childForm.FormClosing += delegate { parentForm.Show(); };

            // TODO Old logic below for the above, possibly required to swallow exception to close parentForm?
            //try
            //{
            //    childForm.Show(parentForm);
            //    parentForm.Hide();
            //    childForm.FormClosing += delegate { parentForm.Show(); };
            //}
            //catch (Exception)
            //{
            //    parentForm.Close();
            //}
        }
    }
}
