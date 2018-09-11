using System;
using System.Drawing;
using App.WindowsForms.Controllers;

namespace App.WindowsForms.Views
{
    public sealed partial class MenuForm : EditorForm
    {
        private MenuController _controller;

        public string GameFolderText { get => GameFolderPathTextBox.Text; set => GameFolderPathTextBox.Text = value; }

        public MenuForm()
        {
            InitializeComponent();
        }

        public void SetController(MenuController controller)
        {
            _controller = controller;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            _controller.LoadView();
        }

        private void ConfigureGameButton_Click(object sender, EventArgs e)
        {
            _controller.RunConfigureGame();
        }

        private void GameExecutableEditorButton_Click(object sender, EventArgs e)
        {
            _controller.RunBaseGameEditor();
        }

        private void GameFolderChangeButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeGameFolder();
        }

        private void GameFolderOkButton_Click(object sender, EventArgs e)
        {
            _controller.ConfirmGameFolder();
        }

        private void LanguageFileEditorButton_Click(object sender, EventArgs e)
        {
            _controller.RunLanguageFileEditor();
        }

        private void LaunchGameButton_Click(object sender, EventArgs e)
        {
            _controller.LaunchGame();
        }

        private void SaveGameEditorButton_Click(object sender, EventArgs e)
        {
            _controller.RunSaveGameEditor();
        }

        private void SettingsEditorButton_Click(object sender, EventArgs e)
        {
            _controller.RunSettingsEditor();
        }

        private void TelemetryViewerButton_Click(object sender, EventArgs e)
        {
            _controller.RunTelemetryViewer();
        }

        private void UpgradeGameButton_Click(object sender, EventArgs e)
        {
            _controller.RunUpgradeGame();
        }

        public void FormatGameFolderAdministratorLabelText(string applicationName)
        {
            GameFolderAdministratorLabel.Text = string.Format(GameFolderAdministratorLabel.Text, applicationName);
        }

        public void FormatSettingsEditorButtonText(string applicationName)
        {
            SettingsEditorButton.Text = string.Format(SettingsEditorButton.Text, applicationName);
        }

        public void HideGameFolderPanel()
        {
            GameFolderPanel.Hide();
        }

        public void SetFormLogo(Bitmap image)
        {
            LogoPictureBox.Image = image;
        }

        public void ShowGameFolderPanel()
        {
            GameFolderPanel.Show();
        }

        public void ShowMenuPanel()
        {
            MenuPanel.Show();
        }
    }
}