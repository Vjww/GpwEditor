﻿using System;
using System.Windows.Forms;
using App.WindowsForms.Controllers;
using App.WindowsForms.Properties;

namespace App.WindowsForms.Views
{
    public partial class UpgradeGameForm : EditorForm
    {
        private UpgradeGameController _controller;
        private bool _isModified;

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
            Icon = Resources.icon1;
            Text = $"{Settings.Default.ApplicationName} - Upgrade Game";
            ConvertLinesToRtf(OverviewRichTextBox);

            // Populate with most recently used (MRU) or default
            GameFolderPath = GetGameFolderMruOrDefault();

            // Set modified as default
            _isModified = true;
        }

        private void UpgradeGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseFormConfirmation(_isModified, "Are you sure you wish to close this window?"))
            {
                return;
            }

            e.Cancel = true; // Abort event
        }

        private void GameFolderPathBrowseButton_Click(object sender, EventArgs e)
        {
            try
            {
                var result = GetGameFolderPathFromFolderBrowserDialog();
                GameFolderPath = string.IsNullOrEmpty(result) ? GameFolderPath : result;
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
        }

        private void UpgradeButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _controller.Upgrade();
            }
            catch (Exception ex)
            {
                ShowErrorBox(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            ShowMessageBox("Upgrade complete!");
        }
    }
}