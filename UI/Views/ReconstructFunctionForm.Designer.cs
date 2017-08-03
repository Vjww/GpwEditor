namespace GpwEditor.Views
{
    partial class ReconstructFunctionForm
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
            this.InputLabel = new System.Windows.Forms.Label();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.ReconstructedFunctionOutputTextBox = new System.Windows.Forms.TextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.InputGroupBox = new System.Windows.Forms.GroupBox();
            this.RelocationFunctionAddressLabel = new System.Windows.Forms.Label();
            this.CutToAddressLabel = new System.Windows.Forms.Label();
            this.RelocationFunctionAddressTextBox = new System.Windows.Forms.TextBox();
            this.CutToAddressTextBox = new System.Windows.Forms.TextBox();
            this.CutFromAddressLabel = new System.Windows.Forms.Label();
            this.CutFromAddressTextBox = new System.Windows.Forms.TextBox();
            this.OutputGroupBox = new System.Windows.Forms.GroupBox();
            this.RelocatedFunctionOutputTextBox = new System.Windows.Forms.TextBox();
            this.RawOutputCheckBox = new System.Windows.Forms.CheckBox();
            this.InputGroupBox.SuspendLayout();
            this.OutputGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputLabel
            // 
            this.InputLabel.AutoSize = true;
            this.InputLabel.Location = new System.Drawing.Point(3, 54);
            this.InputLabel.Name = "InputLabel";
            this.InputLabel.Size = new System.Drawing.Size(519, 13);
            this.InputLabel.TabIndex = 0;
            this.InputLabel.Text = "Input - paste disassembled function directly from IDA into this area (formatted t" +
    "o twelve opcode bytes per line)";
            // 
            // InputTextBox
            // 
            this.InputTextBox.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputTextBox.Location = new System.Drawing.Point(6, 70);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.InputTextBox.Size = new System.Drawing.Size(676, 151);
            this.InputTextBox.TabIndex = 1;
            this.InputTextBox.WordWrap = false;
            this.InputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputTextBox_KeyDown);
            // 
            // OutputLabel
            // 
            this.OutputLabel.AutoSize = true;
            this.OutputLabel.Location = new System.Drawing.Point(3, 22);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(282, 13);
            this.OutputLabel.TabIndex = 2;
            this.OutputLabel.Text = "Output - copy bytes for use in hex editing or code patching";
            // 
            // ReconstructedFunctionOutputTextBox
            // 
            this.ReconstructedFunctionOutputTextBox.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReconstructedFunctionOutputTextBox.Location = new System.Drawing.Point(6, 38);
            this.ReconstructedFunctionOutputTextBox.Multiline = true;
            this.ReconstructedFunctionOutputTextBox.Name = "ReconstructedFunctionOutputTextBox";
            this.ReconstructedFunctionOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ReconstructedFunctionOutputTextBox.Size = new System.Drawing.Size(676, 95);
            this.ReconstructedFunctionOutputTextBox.TabIndex = 3;
            this.ReconstructedFunctionOutputTextBox.WordWrap = false;
            this.ReconstructedFunctionOutputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OutputTextBox_KeyDown);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(625, 478);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateButton.TabIndex = 3;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // InputGroupBox
            // 
            this.InputGroupBox.Controls.Add(this.RelocationFunctionAddressLabel);
            this.InputGroupBox.Controls.Add(this.CutToAddressLabel);
            this.InputGroupBox.Controls.Add(this.RelocationFunctionAddressTextBox);
            this.InputGroupBox.Controls.Add(this.CutToAddressTextBox);
            this.InputGroupBox.Controls.Add(this.CutFromAddressLabel);
            this.InputGroupBox.Controls.Add(this.CutFromAddressTextBox);
            this.InputGroupBox.Controls.Add(this.InputLabel);
            this.InputGroupBox.Controls.Add(this.InputTextBox);
            this.InputGroupBox.Location = new System.Drawing.Point(12, 12);
            this.InputGroupBox.Name = "InputGroupBox";
            this.InputGroupBox.Size = new System.Drawing.Size(688, 227);
            this.InputGroupBox.TabIndex = 4;
            this.InputGroupBox.TabStop = false;
            // 
            // RelocationFunctionAddressLabel
            // 
            this.RelocationFunctionAddressLabel.AutoSize = true;
            this.RelocationFunctionAddressLabel.Location = new System.Drawing.Point(434, 22);
            this.RelocationFunctionAddressLabel.Name = "RelocationFunctionAddressLabel";
            this.RelocationFunctionAddressLabel.Size = new System.Drawing.Size(142, 13);
            this.RelocationFunctionAddressLabel.TabIndex = 3;
            this.RelocationFunctionAddressLabel.Text = "Relocation function address:";
            // 
            // CutToAddressLabel
            // 
            this.CutToAddressLabel.AutoSize = true;
            this.CutToAddressLabel.Location = new System.Drawing.Point(244, 22);
            this.CutToAddressLabel.Name = "CutToAddressLabel";
            this.CutToAddressLabel.Size = new System.Drawing.Size(78, 13);
            this.CutToAddressLabel.TabIndex = 3;
            this.CutToAddressLabel.Text = "Cut to address:";
            // 
            // RelocationFunctionAddressTextBox
            // 
            this.RelocationFunctionAddressTextBox.Location = new System.Drawing.Point(582, 19);
            this.RelocationFunctionAddressTextBox.Name = "RelocationFunctionAddressTextBox";
            this.RelocationFunctionAddressTextBox.Size = new System.Drawing.Size(100, 20);
            this.RelocationFunctionAddressTextBox.TabIndex = 2;
            // 
            // CutToAddressTextBox
            // 
            this.CutToAddressTextBox.Location = new System.Drawing.Point(328, 19);
            this.CutToAddressTextBox.Name = "CutToAddressTextBox";
            this.CutToAddressTextBox.Size = new System.Drawing.Size(100, 20);
            this.CutToAddressTextBox.TabIndex = 2;
            // 
            // CutFromAddressLabel
            // 
            this.CutFromAddressLabel.AutoSize = true;
            this.CutFromAddressLabel.Location = new System.Drawing.Point(43, 22);
            this.CutFromAddressLabel.Name = "CutFromAddressLabel";
            this.CutFromAddressLabel.Size = new System.Drawing.Size(89, 13);
            this.CutFromAddressLabel.TabIndex = 3;
            this.CutFromAddressLabel.Text = "Cut from address:";
            // 
            // CutFromAddressTextBox
            // 
            this.CutFromAddressTextBox.Location = new System.Drawing.Point(138, 19);
            this.CutFromAddressTextBox.Name = "CutFromAddressTextBox";
            this.CutFromAddressTextBox.Size = new System.Drawing.Size(100, 20);
            this.CutFromAddressTextBox.TabIndex = 2;
            // 
            // OutputGroupBox
            // 
            this.OutputGroupBox.Controls.Add(this.RelocatedFunctionOutputTextBox);
            this.OutputGroupBox.Controls.Add(this.ReconstructedFunctionOutputTextBox);
            this.OutputGroupBox.Controls.Add(this.OutputLabel);
            this.OutputGroupBox.Location = new System.Drawing.Point(12, 245);
            this.OutputGroupBox.Name = "OutputGroupBox";
            this.OutputGroupBox.Size = new System.Drawing.Size(688, 227);
            this.OutputGroupBox.TabIndex = 5;
            this.OutputGroupBox.TabStop = false;
            // 
            // RelocatedFunctionOutputTextBox
            // 
            this.RelocatedFunctionOutputTextBox.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RelocatedFunctionOutputTextBox.Location = new System.Drawing.Point(6, 139);
            this.RelocatedFunctionOutputTextBox.Multiline = true;
            this.RelocatedFunctionOutputTextBox.Name = "RelocatedFunctionOutputTextBox";
            this.RelocatedFunctionOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.RelocatedFunctionOutputTextBox.Size = new System.Drawing.Size(676, 82);
            this.RelocatedFunctionOutputTextBox.TabIndex = 3;
            this.RelocatedFunctionOutputTextBox.WordWrap = false;
            this.RelocatedFunctionOutputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OutputTextBox_KeyDown);
            // 
            // RawOutputCheckBox
            // 
            this.RawOutputCheckBox.AutoSize = true;
            this.RawOutputCheckBox.Location = new System.Drawing.Point(18, 482);
            this.RawOutputCheckBox.Name = "RawOutputCheckBox";
            this.RawOutputCheckBox.Size = new System.Drawing.Size(175, 17);
            this.RawOutputCheckBox.TabIndex = 6;
            this.RawOutputCheckBox.Text = "Display output as raw hex bytes";
            this.RawOutputCheckBox.UseVisualStyleBackColor = true;
            // 
            // ReconstructFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 513);
            this.Controls.Add(this.RawOutputCheckBox);
            this.Controls.Add(this.OutputGroupBox);
            this.Controls.Add(this.InputGroupBox);
            this.Controls.Add(this.GenerateButton);
            this.Name = "ReconstructFunctionForm";
            this.Load += new System.EventHandler(this.ReconstructFunctionForm_Load);
            this.InputGroupBox.ResumeLayout(false);
            this.InputGroupBox.PerformLayout();
            this.OutputGroupBox.ResumeLayout(false);
            this.OutputGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputLabel;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.TextBox ReconstructedFunctionOutputTextBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.GroupBox InputGroupBox;
        private System.Windows.Forms.Label CutFromAddressLabel;
        private System.Windows.Forms.TextBox CutFromAddressTextBox;
        private System.Windows.Forms.Label CutToAddressLabel;
        private System.Windows.Forms.TextBox CutToAddressTextBox;
        private System.Windows.Forms.Label RelocationFunctionAddressLabel;
        private System.Windows.Forms.TextBox RelocationFunctionAddressTextBox;
        private System.Windows.Forms.GroupBox OutputGroupBox;
        private System.Windows.Forms.CheckBox RawOutputCheckBox;
        private System.Windows.Forms.TextBox RelocatedFunctionOutputTextBox;
    }
}