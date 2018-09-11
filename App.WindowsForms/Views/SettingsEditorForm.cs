using System;
using App.WindowsForms.Controllers;

namespace App.WindowsForms.Views
{
    public partial class SettingsEditorForm : EditorForm
    {
        private SettingsEditorController _controller;

        public string GameFolderText { get => GameFolderTextBox.Text; set => GameFolderTextBox.Text = value; }
        public string LaunchGameText { get => LaunchGameTextBox.Text; set => LaunchGameTextBox.Text = value; }
        public string RegistryKeyText { get => RegistryKeyTextBox.Text; set => RegistryKeyTextBox.Text = value; }
        public string RegistryInstallValueText { get => InstallTextBox.Text; set => InstallTextBox.Text = value; }
        public string RegistryLanguageValueText { get => LanguageTextBox.Text; set => LanguageTextBox.Text = value; }
        public string RegistryPathValueText { get => PathTextBox.Text; set => PathTextBox.Text = value; }
        public string RegistryValidValueText { get => ValidTextBox.Text; set => ValidTextBox.Text = value; }

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
            _controller.LoadView();
        }

        private void GameFolderChangeButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeGameFolder();
        }

        private void LaunchGameChangeButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeLaunchGame();
        }

        private void PathChangeButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeRegistryGameFolder();
        }

        private void RegistryKeysInstallButton_Click(object sender, EventArgs e)
        {
            _controller.InstallRegistryKeys();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            _controller.ResetRegistryKeys();
        }

        public void FormatGameFolderDescriptionLabelText(string applicationName)
        {
            GameFolderDescriptionLabel.Text = string.Format(GameFolderDescriptionLabel.Text, applicationName);
        }

        public void FormatLaunchGameDescriptionLabelText(string applicationName)
        {
            LaunchGameDescriptionLabel.Text = string.Format(LaunchGameDescriptionLabel.Text, applicationName);
        }

        public void FormatRegistryKeysDescriptionLabelText(string applicationName, string gameName, string gameRegistryKey)
        {
            RegistryKeysDescriptionLabel.Text = string.Format(RegistryKeysDescriptionLabel.Text, applicationName, gameName, gameRegistryKey);
        }

        public string[] GetRichTextBoxLines()
        {
            return AboutRichTextBox.Lines;
        }

        public void HideRegistryKeysInstallPanel()
        {
            RegistryKeysInstallPanel.Hide();
        }

        public void ShowRegistryKeysInstallPanel()
        {
            RegistryKeysInstallPanel.Show();
        }

        public void ShowRegistryKeysPanel()
        {
            RegistryKeysPanel.Show();
        }

        public void SetRichTextBoxRichText(string text)
        {
            AboutRichTextBox.Rtf = text;
        }
    }
}