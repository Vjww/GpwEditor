using System;
using App.WindowsForms.Controllers;

namespace App.WindowsForms.Views
{
    public partial class SettingsEditorForm : EditorForm
    {
        private SettingsEditorController _controller;

        public string GameFolder { get => GameFolderTextBox.Text; set => GameFolderTextBox.Text = value; }
        public string LaunchGame { get => LaunchGameTextBox.Text; set => LaunchGameTextBox.Text = value; }
        public string RegistryKey { get => RegistryKeyTextBox.Text; set => RegistryKeyTextBox.Text = value; }
        public string InstallValue { get => InstallTextBox.Text; set => InstallTextBox.Text = value; }
        public string LanguageValue { get => LanguageTextBox.Text; set => LanguageTextBox.Text = value; }
        public string PathValue { get => PathTextBox.Text; set => PathTextBox.Text = value; }
        public string ValidValue { get => ValidTextBox.Text; set => ValidTextBox.Text = value; }

        public SettingsEditorForm()
        {
            InitializeComponent();
        }

        public void SetController(SettingsEditorController controller)
        {
            _controller = controller;
        }

        private void SettingsEditorForm_Load(object sender, EventArgs e)
        {
            Icon = _controller.GetFormIcon();
            Text = $@"{_controller.GetApplicationName()} - Settings";
            ConvertLinesToRtf(AboutRichTextBox);

            GameFolder = _controller.GetUserGameFolderPath();
            LaunchGame = _controller.GetUserGameLaunchCommand();
            RegistryKey = _controller.GetGameRegistryKey();

            GameFolderDescriptionLabel.Text = string.Format(GameFolderDescriptionLabel.Text, _controller.GetApplicationName());
            LaunchGameDescriptionLabel.Text = string.Format(LaunchGameDescriptionLabel.Text, _controller.GetApplicationName());
            RegistryKeysDescriptionLabel.Text = string.Format(RegistryKeysDescriptionLabel.Text, _controller.GetApplicationName(), _controller.GetGameName(), _controller.GetGameRegistryKey());

            if (_controller.DoGameRegistryKeysExist())
            {
                _controller.UpdateRegistryModelFromRegistryValues();
                RegistryKeysPanel.Show();
            }
            else
            {
                RegistryKeysInstallPanel.Show();
            }
        }

        private void GameFolderChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Prompt user to select game folder and save original/changed selection
                var result = _controller.GetGameFolderPathFromFolderBrowserDialog(ProgramFolderBrowserDialog);
                GameFolder = string.IsNullOrEmpty(result) ? GameFolder : result;
                _controller.SetUserGameFolderPath(GameFolder);
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void LaunchGameChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Prompt user to select game executable and save original/changed selection
                var result = _controller.GetGameExecutablePathFromOpenFileDialog(ProgramOpenFileDialog);
                LaunchGame = string.IsNullOrEmpty(result) ? LaunchGame : result;
                _controller.SetUserGameLaunchCommand(LaunchGame);
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void RegistryKeysInstallButton_Click(object sender, EventArgs e)
        {
            try
            {
                _controller.InstallRegistryKeys();
                _controller.UpdateRegistryModelFromRegistryValues();
                RegistryKeysInstallPanel.Hide();
                RegistryKeysPanel.Show();
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void PathChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_controller.IsRegistryWritable())
                {
                    throw new Exception($"Unable to alter the registry key values due to insufficient permissions.");
                }

                // Prompt user to select game folder and save original/changed selection
                var result = _controller.GetGameFolderPathFromFolderBrowserDialog(ProgramFolderBrowserDialog);
                PathValue = string.IsNullOrEmpty(result) ? PathValue : result;
                _controller.UpdateRegistryValuesFromRegistryModel();
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_controller.IsRegistryWritable())
                {
                    throw new Exception($"Unable to alter the registry key values due to insufficient permissions.");
                }

                _controller.InstallRegistryKeys();
                _controller.UpdateRegistryModelFromRegistryValues();
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }
    }
}