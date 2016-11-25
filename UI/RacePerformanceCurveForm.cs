using System;
using System.Windows.Forms;
using GpwEditor.Properties;

namespace GpwEditor
{
    public partial class RacePerformanceCurveForm : Form
    {
        private readonly RacePerformanceCurveChart _racePerformanceCurveChart;

        public RacePerformanceCurveForm(RacePerformanceCurveChart racePerformanceCurveChart)
        {
            _racePerformanceCurveChart = racePerformanceCurveChart;

            InitializeComponent();
        }

        private void RacePerformanceCurveForm_Load(object sender, EventArgs e)
        {
            // Set icon
            Icon = Resources.icon1;

            // Set form title text
            Text = $"{Settings.Default.ApplicationName} - Race Performance Curve";

            // Update label with lower and upper bound values
            RequirementsLabel.Text = string.Format(RequirementsLabel.Text, RacePerformanceCurveChart.YAxisLowerBound, RacePerformanceCurveChart.YAxisUpperBound);

            GetValues();
        }

        private void ValuesTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Enable Select All shortcut key functionality in MultiLine TextBox
            // http://stackoverflow.com/a/15915059
            if (e.KeyData == (Keys.Control | Keys.A))
            {
                ((TextBox)sender).SelectAll();
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            GetValues();
            ValuesTextBox.Focus();
            ValuesTextBox.SelectAll();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            // If validation fails
            if (!ValidateValues())
            {
                MessageBox.Show(
                    $"An error has occured.{Environment.NewLine}{Environment.NewLine}" +
                    "Please check there are exactly 120 integer values and try again.",
                    Settings.Default.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                ValuesTextBox.Focus();
                ValuesTextBox.SelectAll();
                return;
            }

            // Else
            SetValues();
            Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetValues()
        {
            // Clear
            ValuesTextBox.Clear();

            // Get values
            var proposedValues = _racePerformanceCurveChart.GetProposedSeries();

            // Populate textbox
            foreach (var proposedValue in proposedValues)
            {
                ValuesTextBox.Text += proposedValue + Environment.NewLine;
            }
        }

        private void SetValues()
        {
            // Extract values from textbox
            var stringValues = ValuesTextBox.Text.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var values = new int[120];
            for (var i = 0; i < values.Length; i++)
            {
                var value = int.Parse(stringValues[i]);
                values[i] = value;
            }

            // Set values
            _racePerformanceCurveChart.SetHiddenSeries(values);
        }

        private bool ValidateValues()
        {
            // Confirm there are 120 values
            var stringValues = ValuesTextBox.Text.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var isCorrectLength = stringValues.Length == 120;

            // If correct length, validate values
            var isValidValues = false;
            if (isCorrectLength)
            {
                isValidValues = true;

                // Confirm each value is an integer
                var values = new int[120];
                for (var i = 0; i < values.Length; i++)
                {
                    int testValue;
                    isValidValues = int.TryParse(stringValues[i], out testValue);
                    if (!isValidValues)
                    {
                        break;
                    }
                }
            }

            // If validation failed, show error
            if (!isCorrectLength || !isValidValues)
            {
                return false;
            }

            return true;
        }
    }
}
