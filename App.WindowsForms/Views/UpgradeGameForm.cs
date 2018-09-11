using System;
using System.Windows.Forms;
using App.WindowsForms.Controllers;

namespace App.WindowsForms.Views
{
    public partial class UpgradeGameForm : EditorForm
    {
        private UpgradeGameController _controller;

        public string GameFolderPath { get => GameFolderPathTextBox.Text; set => GameFolderPathTextBox.Text = value; }

        public UpgradeGameForm()
        {
            InitializeComponent();
        }

        public void SetController(UpgradeGameController controller)
        {
            _controller = controller;
        }

        private void UpgradeGameForm_Load(object sender, EventArgs e)
        {
            _controller.LoadView();
        }

        private void UpgradeGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !_controller.CloseForm(); // Abort event if returns false
        }

        private void GameFolderPathBrowseButton_Click(object sender, EventArgs e)
        {
            _controller.ChangeGameFolder();
        }

        private void UpgradeButton_Click(object sender, EventArgs e)
        {
            _controller.Upgrade();
        }

        public string[] GetRichTextBoxLines()
        {
            return OverviewRichTextBox.Lines;
        }

        public void SetRichTextBoxRichText(string text)
        {
            OverviewRichTextBox.Rtf = text;
        }
    }
}