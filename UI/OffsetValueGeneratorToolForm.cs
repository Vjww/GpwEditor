﻿using System;
using System.Collections;
using System.Windows.Forms;

namespace UI
{
    public partial class OffsetValueGeneratorToolForm : Form
    {
        public OffsetValueGeneratorToolForm()
        {
            InitializeComponent();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            var arrayList = new ArrayList();

            foreach (var line in InputTextBox.Lines)
            {
                // Extract input values
                var lineValues = line.Split(",".ToCharArray(), 2);
                var offset = Convert.ToInt32(lineValues[0], 16);
                var value = Convert.ToInt32(lineValues[1]);

                // Generate output
                var output = "0x" + BitConverter.ToString(BitConverter.GetBytes(offset)) + "-" + BitConverter.ToString(BitConverter.GetBytes(value)) + ",";
                output = output.Replace("-", ", 0x");

                // Add to output
                arrayList.Add(output);
            }

            var outputLines = new string[arrayList.Count];
            for (var i = 0; i < arrayList.Count; i++)
            {
                outputLines[i] = (string)arrayList[i];
            }

            OutputTextBox.Lines = outputLines;
        }
    }
}
