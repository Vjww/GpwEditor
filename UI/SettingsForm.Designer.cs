namespace UI
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
            this.ApplyAllButton = new System.Windows.Forms.Button();
            this.OffsetValueGeneratorToolButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SwitchIdiomButton
            // 
            this.SwitchIdiomButton.Location = new System.Drawing.Point(8, 38);
            this.SwitchIdiomButton.Name = "SwitchIdiomButton";
            this.SwitchIdiomButton.Size = new System.Drawing.Size(176, 23);
            this.SwitchIdiomButton.TabIndex = 2;
            this.SwitchIdiomButton.Text = "Apply Switch Idiom";
            this.SwitchIdiomButton.UseVisualStyleBackColor = true;
            this.SwitchIdiomButton.Click += new System.EventHandler(this.SwitchIdiomButton_Click);
            // 
            // JumpBypassButton
            // 
            this.JumpBypassButton.Location = new System.Drawing.Point(8, 67);
            this.JumpBypassButton.Name = "JumpBypassButton";
            this.JumpBypassButton.Size = new System.Drawing.Size(176, 23);
            this.JumpBypassButton.TabIndex = 3;
            this.JumpBypassButton.Text = "Apply Jump Bypass";
            this.JumpBypassButton.UseVisualStyleBackColor = true;
            this.JumpBypassButton.Click += new System.EventHandler(this.JumpBypassButton_Click);
            // 
            // CodeShiftButton
            // 
            this.CodeShiftButton.Location = new System.Drawing.Point(8, 96);
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
            this.FilePathTextBox.Location = new System.Drawing.Point(8, 12);
            this.FilePathTextBox.Name = "FilePathTextBox";
            this.FilePathTextBox.Size = new System.Drawing.Size(176, 20);
            this.FilePathTextBox.TabIndex = 1;
            // 
            // ApplyAllButton
            // 
            this.ApplyAllButton.Location = new System.Drawing.Point(8, 154);
            this.ApplyAllButton.Name = "ApplyAllButton";
            this.ApplyAllButton.Size = new System.Drawing.Size(176, 23);
            this.ApplyAllButton.TabIndex = 0;
            this.ApplyAllButton.Text = "Apply all";
            this.ApplyAllButton.UseVisualStyleBackColor = true;
            this.ApplyAllButton.Click += new System.EventHandler(this.ApplyAllButton_Click);
            // 
            // OffsetValueGeneratorToolButton
            // 
            this.OffsetValueGeneratorToolButton.Location = new System.Drawing.Point(8, 125);
            this.OffsetValueGeneratorToolButton.Name = "OffsetValueGeneratorToolButton";
            this.OffsetValueGeneratorToolButton.Size = new System.Drawing.Size(176, 23);
            this.OffsetValueGeneratorToolButton.TabIndex = 4;
            this.OffsetValueGeneratorToolButton.Text = "Offset Value Generator Tool";
            this.OffsetValueGeneratorToolButton.UseVisualStyleBackColor = true;
            this.OffsetValueGeneratorToolButton.Click += new System.EventHandler(this.OffsetValueGeneratorToolButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 186);
            this.Controls.Add(this.ApplyAllButton);
            this.Controls.Add(this.OffsetValueGeneratorToolButton);
            this.Controls.Add(this.CodeShiftButton);
            this.Controls.Add(this.SwitchIdiomButton);
            this.Controls.Add(this.JumpBypassButton);
            this.Controls.Add(this.FilePathTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SwitchIdiomButton;
        private System.Windows.Forms.Button JumpBypassButton;
        private System.Windows.Forms.Button CodeShiftButton;
        private System.Windows.Forms.TextBox FilePathTextBox;
        private System.Windows.Forms.Button ApplyAllButton;
        private System.Windows.Forms.Button OffsetValueGeneratorToolButton;
    }
}