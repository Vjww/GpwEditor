using System;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;
using GpwEditor.Properties;
using GpwRegistry = GpwEditor.Registry.GpwRegistry;
using GpwRegistryKeys = GpwEditor.Registry.GpwRegistryKeys;

namespace GpwEditor
{
    public partial class RegistryKeysForm : Form
    {
        public RegistryKeysForm()
        {
            InitializeComponent();
        }

        private void RegistryKeysForm_Load(object sender, EventArgs e)
        {
            // Set icon
            Icon = Resources.icon1;

            var registry = new GpwRegistry();

            // If registry keys exist
            if (registry.DoAnyKeysExist())
            {
                // Show values in controls
                var registryKeys = registry.ReadKeys();
                UpdateControlsWithRegistryKeyValues(registryKeys);
                CreateRegistryKeysButton.Enabled = false;
            }

            else
            {
                // Else display advice
                var dialogResult = MessageBox.Show(
                    string.Format(
                        "{0} has detected that the registry keys for {1} are missing.{2}{2}" +
                        "Click the Create Registry Keys button to have {0} create the required registry keys.",
                        Settings.Default.ApplicationName, "Grand Prix World", Environment.NewLine),
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ChangeGameFolderButton.Enabled = false;
            }
        }

        private void UpdateControlsWithRegistryKeyValues(GpwRegistryKeys registryKeys)
        {
            RegistryKeyLocationTextBox.Text = $@"HKEY_LOCAL_MACHINE\{Settings.Default.RegistryKey}";
            InstallTextBox.Text = registryKeys.InstallValue;
            LanguageTextBox.Text = registryKeys.LanguageValue.ToString();
            PathTextBox.Text = registryKeys.PathValue;
            ValidTextBox.Text = registryKeys.ValidValue.ToString();
        }

        private void CreateRegistryKeysButton_Click(object sender, EventArgs e)
        {
            var isRunningAsAdministrator = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

            // If application not running as an administrator, display message and abort
            if (!isRunningAsAdministrator)
            {
                // Display message advising to restart as an administrator
                var dialogResult = MessageBox.Show(
                    string.Format(
                        "{0} must be run with administrative rights to be able to create the registry keys for {1}.{2}{2}" +
                        "Please restart {0} as an administrator and try again.",
                        Settings.Default.ApplicationName, "Grand Prix World", Environment.NewLine),
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                // Create keys
                var registry = new GpwRegistry();
                registry.CreateKeys();

                // Update path with current user game folder path value
                var registryKeys = registry.ReadKeys();
                registryKeys.PathValue = Settings.Default.UserGameFolderPath;
                registry.WriteKeys(registryKeys);

                UpdateControlsWithRegistryKeyValues(registryKeys);
                CreateRegistryKeysButton.Enabled = false;
                ChangeGameFolderButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "{0} has encountered an error while attempting to update the registry.{1}{1}" +
                        "Error: " + ex.Message, Settings.Default.ApplicationName, Environment.NewLine),
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeGameFolderButton_Click(object sender, EventArgs e)
        {
            var isRunningAsAdministrator = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

            // If application not running as an administrator, display message and abort
            if (!isRunningAsAdministrator)
            {
                // Display message advising to restart as an administrator
                var dialogResult = MessageBox.Show(
                    string.Format(
                        "{0} must be run with administrative rights to be able to change the registry keys for {1}.{2}{2}" +
                        "Please restart {0} as an administrator and try again.",
                        Settings.Default.ApplicationName, "Grand Prix World", Environment.NewLine),
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                var registry = new GpwRegistry();

                // If registry keys exist
                if (registry.DoAnyKeysExist())
                {
                    var registryKeys = registry.ReadKeys();

                    // Configure browser dialog where current path is valid
                    if (Directory.Exists(registryKeys.PathValue))
                        GpwFolderBrowserDialog.SelectedPath = registryKeys.PathValue;
                    else
                        GpwFolderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;

                    // Get game folder from user
                    var folderDialogResult = GpwFolderBrowserDialog.ShowDialog();

                    // If user selects a folder
                    if (folderDialogResult == DialogResult.OK)
                    {
                        // Update registry with selected folder
                        registryKeys.PathValue = GpwFolderBrowserDialog.SelectedPath;
                        registry.WriteKeys(registryKeys);

                        // Save selected folder
                        Settings.Default.UserGameFolderPath = GpwFolderBrowserDialog.SelectedPath;
                        Settings.Default.Save();

                        // Update controls
                        PathTextBox.Text = Settings.Default.UserGameFolderPath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "{0} has encountered an error while attempting to update the registry.{1}{1}" +
                        "Error: " + ex.Message, Settings.Default.ApplicationName, Environment.NewLine),
                        Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
