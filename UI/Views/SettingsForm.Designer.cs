namespace GpwEditor.Views
{
    partial class SettingsForm
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
            this.SwitchIdiomButton = new System.Windows.Forms.Button();
            this.JumpBypassButton = new System.Windows.Forms.Button();
            this.CodeShiftButton = new System.Windows.Forms.Button();
            this.FilePathTextBox = new System.Windows.Forms.TextBox();
            this.OffsetValueGeneratorToolButton = new System.Windows.Forms.Button();
            this.GlobalUnlockButton = new System.Windows.Forms.Button();
            this.ReconstructFunctionButton = new System.Windows.Forms.Button();
            this.ApplyChangeGroupBox = new System.Windows.Forms.GroupBox();
            this.ApplyAllButton = new System.Windows.Forms.Button();
            this.TrackEditorButton = new System.Windows.Forms.Button();
            this.CreateChangeGroupBox = new System.Windows.Forms.GroupBox();
            this.ApplyChangeGroupBox.SuspendLayout();
            this.CreateChangeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SwitchIdiomButton
            // 
            this.SwitchIdiomButton.Location = new System.Drawing.Point(6, 45);
            this.SwitchIdiomButton.Name = "SwitchIdiomButton";
            this.SwitchIdiomButton.Size = new System.Drawing.Size(176, 23);
            this.SwitchIdiomButton.TabIndex = 2;
            this.SwitchIdiomButton.Text = "Apply Switch Idiom";
            this.SwitchIdiomButton.UseVisualStyleBackColor = true;
            this.SwitchIdiomButton.Click += new System.EventHandler(this.SwitchIdiomButton_Click);
            // 
            // JumpBypassButton
            // 
            this.JumpBypassButton.Location = new System.Drawing.Point(6, 74);
            this.JumpBypassButton.Name = "JumpBypassButton";
            this.JumpBypassButton.Size = new System.Drawing.Size(176, 23);
            this.JumpBypassButton.TabIndex = 3;
            this.JumpBypassButton.Text = "Apply Jump Bypass";
            this.JumpBypassButton.UseVisualStyleBackColor = true;
            this.JumpBypassButton.Click += new System.EventHandler(this.JumpBypassButton_Click);
            // 
            // CodeShiftButton
            // 
            this.CodeShiftButton.Location = new System.Drawing.Point(6, 103);
            this.CodeShiftButton.Name = "CodeShiftButton";
            this.CodeShiftButton.Size = new System.Drawing.Size(176, 23);
            this.CodeShiftButton.TabIndex = 4;
            this.CodeShiftButton.Text = "Apply Code Shift";
            this.CodeShiftButton.UseVisualStyleBackColor = true;
            this.CodeShiftButton.Click += new System.EventHandler(this.CodeShiftButton_Click);
            // 
            // FilePathTextBox
            // 
            this.FilePathTextBox.Enabled = false;
            this.FilePathTextBox.Location = new System.Drawing.Point(6, 19);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(176, 20);
            this.FilePathTextBox.TabIndex = 1;
            // 
            // OffsetValueGeneratorToolButton
            // 
            this.OffsetValueGeneratorToolButton.Location = new System.Drawing.Point(6, 45);
            this.OffsetValueGeneratorToolButton.Name = "OffsetValueGeneratorToolButton";
            this.OffsetValueGeneratorToolButton.Size = new System.Drawing.Size(176, 23);
            this.OffsetValueGeneratorToolButton.TabIndex = 4;
            this.OffsetValueGeneratorToolButton.Text = "Offset Value Generator Tool";
            this.OffsetValueGeneratorToolButton.UseVisualStyleBackColor = true;
            this.OffsetValueGeneratorToolButton.Click += new System.EventHandler(this.OffsetValueGeneratorToolButton_Click);
            // 
            // GlobalUnlockButton
            // 
            this.GlobalUnlockButton.Location = new System.Drawing.Point(6, 132);
            this.GlobalUnlockButton.Name = "GlobalUnlockButton";
            this.GlobalUnlockButton.Size = new System.Drawing.Size(176, 23);
            this.GlobalUnlockButton.TabIndex = 4;
            this.GlobalUnlockButton.Text = "Apply Global Unlock";
            this.GlobalUnlockButton.UseVisualStyleBackColor = true;
            this.GlobalUnlockButton.Click += new System.EventHandler(this.GlobalUnlockButton_Click);
            // 
            // ReconstructFunctionButton
            // 
            this.ReconstructFunctionButton.Location = new System.Drawing.Point(6, 74);
            this.ReconstructFunctionButton.Name = "ReconstructFunctionButton";
            this.ReconstructFunctionButton.Size = new System.Drawing.Size(176, 23);
            this.ReconstructFunctionButton.TabIndex = 4;
            this.ReconstructFunctionButton.Text = "Reconstruct Function";
            this.ReconstructFunctionButton.UseVisualStyleBackColor = true;
            this.ReconstructFunctionButton.Click += new System.EventHandler(this.CutCodeFromFunctionButton_Click);
            // 
            // ApplyChangeGroupBox
            // 
            this.ApplyChangeGroupBox.Controls.Add(this.FilePathTextBox);
            this.ApplyChangeGroupBox.Controls.Add(this.SwitchIdiomButton);
            this.ApplyChangeGroupBox.Controls.Add(this.JumpBypassButton);
            this.ApplyChangeGroupBox.Controls.Add(this.CodeShiftButton);
            this.ApplyChangeGroupBox.Controls.Add(this.ApplyAllButton);
            this.ApplyChangeGroupBox.Controls.Add(this.TrackEditorButton);
            this.ApplyChangeGroupBox.Controls.Add(this.GlobalUnlockButton);
            this.ApplyChangeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ApplyChangeGroupBox.Name = "ApplyChangeGroupBox";
            this.ApplyChangeGroupBox.Size = new System.Drawing.Size(188, 219);
            this.ApplyChangeGroupBox.TabIndex = 5;
            this.ApplyChangeGroupBox.TabStop = false;
            this.ApplyChangeGroupBox.Text = "Apply Change";
            // 
            // ApplyAllButton
            // 
            this.ApplyAllButton.Location = new System.Drawing.Point(6, 190);
            this.ApplyAllButton.Name = "ApplyAllButton";
            this.ApplyAllButton.Size = new System.Drawing.Size(176, 23);
            this.ApplyAllButton.TabIndex = 4;
            this.ApplyAllButton.Text = "Apply All";
            this.ApplyAllButton.UseVisualStyleBackColor = true;
            this.ApplyAllButton.Click += new System.EventHandler(this.ApplyAllButton_Click);
            // 
            // TrackEditorButton
            // 
            this.TrackEditorButton.Location = new System.Drawing.Point(6, 161);
            this.TrackEditorButton.Name = "TrackEditorButton";
            this.TrackEditorButton.Size = new System.Drawing.Size(176, 23);
            this.TrackEditorButton.TabIndex = 4;
            this.TrackEditorButton.Text = "Apply Track Editor";
            this.TrackEditorButton.UseVisualStyleBackColor = true;
            this.TrackEditorButton.Click += new System.EventHandler(this.TrackEditorButton_Click);
            // 
            // CreateChangeGroupBox
            // 
            this.CreateChangeGroupBox.Controls.Add(this.OffsetValueGeneratorToolButton);
            this.CreateChangeGroupBox.Controls.Add(this.ReconstructFunctionButton);
            this.CreateChangeGroupBox.Location = new System.Drawing.Point(206, 12);
            this.CreateChangeGroupBox.Name = "CreateChangeGroupBox";
            this.CreateChangeGroupBox.Size = new System.Drawing.Size(188, 219);
            this.CreateChangeGroupBox.TabIndex = 6;
            this.CreateChangeGroupBox.TabStop = false;
            this.CreateChangeGroupBox.Text = "Create Change";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 241);
            this.Controls.Add(this.CreateChangeGroupBox);
            this.Controls.Add(this.ApplyChangeGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ApplyChangeGroupBox.ResumeLayout(false);
            this.ApplyChangeGroupBox.PerformLayout();
            this.CreateChangeGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SwitchIdiomButton;
        private System.Windows.Forms.Button JumpBypassButton;
        private System.Windows.Forms.Button CodeShiftButton;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Button OffsetValueGeneratorToolButton;
        private System.Windows.Forms.Button GlobalUnlockButton;
        private System.Windows.Forms.Button ReconstructFunctionButton;
        private System.Windows.Forms.GroupBox ApplyChangeGroupBox;
        private System.Windows.Forms.Button ApplyAllButton;
        private System.Windows.Forms.GroupBox CreateChangeGroupBox;
        private System.Windows.Forms.Button TrackEditorButton;
    }
}