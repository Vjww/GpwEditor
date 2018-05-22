﻿namespace App.WindowsForms.Views
{
    partial class EditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProgramOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ProgramFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // ProgramFolderBrowserDialog
            // 
            this.ProgramFolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // EditorFormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "EditorFormBase";
            this.Text = "EditorFormBase";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.OpenFileDialog ProgramOpenFileDialog;
        protected System.Windows.Forms.FolderBrowserDialog ProgramFolderBrowserDialog;
    }
}