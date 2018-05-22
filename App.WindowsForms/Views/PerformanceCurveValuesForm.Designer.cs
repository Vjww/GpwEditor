namespace App.WindowsForms.Views
{
    partial class PerformanceCurveValuesForm
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
            this.ValuesGroupBox = new System.Windows.Forms.GroupBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.RequirementsLabel = new System.Windows.Forms.Label();
            this.ValuesTextBox = new System.Windows.Forms.TextBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ValuesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ValuesGroupBox
            // 
            this.ValuesGroupBox.Controls.Add(this.DescriptionLabel);
            this.ValuesGroupBox.Controls.Add(this.RequirementsLabel);
            this.ValuesGroupBox.Controls.Add(this.ValuesTextBox);
            this.ValuesGroupBox.Location = new System.Drawing.Point(13, 13);
            this.ValuesGroupBox.Name = "ValuesGroupBox";
            this.ValuesGroupBox.Size = new System.Drawing.Size(359, 207);
            this.ValuesGroupBox.TabIndex = 0;
            this.ValuesGroupBox.TabStop = false;
            this.ValuesGroupBox.Text = "Performance Curve";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(6, 16);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(312, 13);
            this.DescriptionLabel.TabIndex = 0;
            this.DescriptionLabel.Text = "Replace the 120 values below to update the performance curve.";
            // 
            // RequirementsLabel
            // 
            this.RequirementsLabel.AutoSize = true;
            this.RequirementsLabel.Location = new System.Drawing.Point(6, 29);
            this.RequirementsLabel.Name = "RequirementsLabel";
            this.RequirementsLabel.Size = new System.Drawing.Size(321, 13);
            this.RequirementsLabel.TabIndex = 0;
            this.RequirementsLabel.Text = "Values must be between {0} and {1}, and delimited by a line break.";
            // 
            // ValuesTextBox
            // 
            this.ValuesTextBox.Location = new System.Drawing.Point(6, 45);
            this.ValuesTextBox.Multiline = true;
            this.ValuesTextBox.Name = "ValuesTextBox";
            this.ValuesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ValuesTextBox.Size = new System.Drawing.Size(347, 156);
            this.ValuesTextBox.TabIndex = 0;
            this.ValuesTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ValuesTextBox_KeyDown);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(216, 226);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 2;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(135, 226);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 1;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(297, 226);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // PerformanceCurveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.ValuesGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PerformanceCurveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PerformanceCurveForm_Load);
            this.ValuesGroupBox.ResumeLayout(false);
            this.ValuesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ValuesGroupBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label RequirementsLabel;
        private System.Windows.Forms.TextBox ValuesTextBox;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button CloseButton;
    }
}