using Core.Properties;
using Core.Registry;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using UI.Properties;

namespace UI
{
    public sealed partial class MenuForm : Form
    {
        private bool hasCreatedRegistryKeysOnInitialRun;

        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            // Set icon
            Icon = Resources.icon1;

#if (!DEBUG)
            {
                // Set form title text
                Text = string.Format("{0} v{1}",
                    Settings.Default.ApplicationName,
                    FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion);
            }
#else
            {
                // Set form title text
                Text =
                    $"{Settings.Default.ApplicationName} v{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion}";
            }
#endif

            SelectRandomLogo();

            // On initial run
            if (Settings.Default.InitialRun)
            {
                CreateRegistryKeys();
            }

            // If game folder has not been set
            if (string.IsNullOrWhiteSpace(Settings.Default.UserGameFolderPath))
            {
                ConfigureGameFolder();
            }

            Settings.Default.InitialRun = false;
            Settings.Default.Save();
        }


        private void UpgradeGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Hide parent form and show child form
                var parentForm = this;
                var childForm = new UpgradeGameForm();
                childForm.Show(parentForm);
                parentForm.Hide();
                childForm.FormClosing += delegate { parentForm.Show(); };
            }
            catch (Exception)
            {
                Close();
            }
        }

        private void GameEditorButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Hide parent form and show child form
                var parentForm = this;
                var childForm = new ExecutableEditorForm();
                childForm.Show(parentForm);
                parentForm.Hide();
                childForm.FormClosing += delegate { parentForm.Show(); };
            }
            catch (Exception)
            {
                Close();
            }
        }

        private void SaveGameEditorButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Hide parent form and show child form
            //    var parentForm = this;
            //    var childForm = new SaveGameEditorForm();
            //    childForm.Show(parentForm);
            //    parentForm.Hide();
            //    childForm.FormClosing += delegate { parentForm.Show(); };
            //}
            //catch (Exception)
            //{
            //    Close();
            //}
        }

        private void LanguageFileEditorButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    // Hide parent form and show child form
            //    var parentForm = this;
            //    var childForm = new LanguageFileEditorForm();
            //    childForm.Show(parentForm);
            //    parentForm.Hide();
            //    childForm.FormClosing += delegate { parentForm.Show(); };
            //}
            //catch (Exception)
            //{
            //    Close();
            //}
        }

        private void RegistryKeysButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Hide parent form and show child form
                var parentForm = this;
                var childForm = new RegistryKeysForm();
                childForm.Show(parentForm);
                parentForm.Hide();
                childForm.FormClosing += delegate { parentForm.Show(); };
            }
            catch (Exception)
            {
                Close();
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Hide parent form and show child form
                var parentForm = this;
                var childForm = new SettingsForm();
                childForm.Show(parentForm);
                parentForm.Hide();
                childForm.FormClosing += delegate { parentForm.Show(); };
            }
            catch (Exception)
            {
                Close();
            }
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

        private void CreateRegistryKeys()
        {
            // Return if registry keys exist
            var registry = new GpwRegistry();
            if (registry.DoAnyKeysExist()) return;

            // Prompt user whether to create registry keys
            var dialogResult = MessageBox.Show(
                string.Format(
                    "{0} has detected that the registry keys for {1} are missing.{2}{2}" +
                    "Do you want {0} to create the required registry keys?",
                    Settings.Default.ApplicationName, "Grand Prix World", Environment.NewLine),
                Settings.Default.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            var doCreateRegistryKeys = (dialogResult == DialogResult.Yes);

            // If user accepts
            if (doCreateRegistryKeys)
            {
                registry.CreateKeys();

                if (Settings.Default.InitialRun)
                {
                    hasCreatedRegistryKeysOnInitialRun = true;
                }
            }
        }

        private void ConfigureGameFolder()
        {
            try
            {
                var registry = new GpwRegistry();

                // Get game folder from registry if possible
                if ((!hasCreatedRegistryKeysOnInitialRun) && (registry.DoAnyKeysExist()))
                {
                    var registryKeys = registry.ReadKeys();
                
                    // Populate game folder
                    Settings.Default.UserGameFolderPath = registryKeys.PathValue;
                    Settings.Default.Save();
                
                    // Advise the user the game folder was auto detected
                    if (Settings.Default.InitialRun)
                    {
                        MessageBox.Show(
                            string.Format(
                                "{0} has detected that {1} is installed at the following location.{2}{2}" +
                                Settings.Default.UserGameFolderPath + "{2}{2}" +
                                "You can change the {1} installation folder in the {0} Registry Keys menu.{2}{2}",
                                Settings.Default.ApplicationName, "Grand Prix World", Environment.NewLine),
                            Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                
                    return;
                }

                // Else prompt the user to select the game folder
                MessageBox.Show(
                    string.Format(
                        "{0} requires you to select the {1} installation folder.{2}{2}" +
                        "Click OK to browse for the {1} installation folder.",
                        Settings.Default.ApplicationName, "Grand Prix World", Environment.NewLine),
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Get game folder from user
                var folderDialogResult = GpwFolderBrowserDialog.ShowDialog();

                // If user does not select an installation folder
                if (folderDialogResult != DialogResult.OK)
                {
                    // Set installation folder to default and show message to advise
                    Settings.Default.UserGameFolderPath = Settings.Default.DefaultGameFolderPath;
                    MessageBox.Show(
                        string.Format(
                            "As you did not select an installation folder for {1}, {0} will assume that the game is installed at the following location.{2}{2}" +
                            Settings.Default.DefaultGameFolderPath,
                            Settings.Default.ApplicationName, "Grand Prix World", Environment.NewLine),
                        Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    Settings.Default.UserGameFolderPath = GpwFolderBrowserDialog.SelectedPath;
                }

                // Save selected game installation folder
                Settings.Default.Save();

                // Update registry with selected game installation folder
                if (registry.DoAnyKeysExist())
                {
                    var registryKeys = registry.ReadKeys();
                    registryKeys.PathValue = Settings.Default.UserGameFolderPath;
                    registry.WriteKeys(registryKeys);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "{0} has encountered an error while attempting to configure the game folder.{1}{1}" + "Error: " +
                        ex.Message + "{1}{1}" + "To resolve this error, try running {0} as an administrator.{1}{1}.",
                        Settings.Default.ApplicationName, Environment.NewLine), Settings.Default.ApplicationName,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
