using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using GpwEditor.Enums;

namespace GpwEditor
{
    public class RacePerformanceCurveChart
    {
        private readonly Chart _chart;
        private readonly int[] _defaultCurve =
        {
             506,  570,  634,  698,  762,  826,  890,  954, 1018, 1082, 1146, 1274, 1402, 1530, 1658, 1786, 1914, 2042,
            2170, 2298, 2426, 2554, 2682, 2810, 2938, 3066, 3194, 3322, 3450, 3578, 3706, 3962, 4218, 4474, 4730, 4986,
            5242, 5498, 5754, 6010, 6266, 6394, 6522, 6650, 6778, 6906, 7034, 7162, 7290, 7418, 7546, 7610, 7674, 7738,
            7802, 7866, 7930, 7994, 8058, 8122, 8186, 8218, 8250, 8282, 8314, 8346, 8378, 8410, 8442, 8474, 8506, 8522,
            8538, 8554, 8570, 8586, 8602, 8618, 8634, 8650, 8658, 8666, 8674, 8682, 8690, 8698, 8706, 8714, 8722, 8730,
            8734, 8738, 8742, 8746, 8750, 8754, 8758, 8762, 8766, 8770, 8772, 8774, 8776, 8778, 8780, 8782, 8784, 8786,
            8788, 8790, 8791, 8792, 8793, 8794, 8795, 8796, 8797, 8798, 8799, 8800
        };

        private readonly int[] _recommendedCurve =
        {
             506,  538,  571,  641,  717,  801,  895,  996, 1104, 1217, 1333, 1452, 1572, 1692, 1813, 1933, 2053, 2173,
            2292, 2410, 2528, 2645, 2761, 2876, 2991, 3105, 3218, 3331, 3443, 3554, 3665, 3776, 3887, 3997, 4107, 4217,
            4327, 4437, 4547, 4657, 4767, 4877, 4987, 5097, 5207, 5316, 5425, 5534, 5643, 5750, 5858, 5964, 6070, 6175,
            6279, 6382, 6483, 6583, 6682, 6779, 6875, 6969, 7061, 7150, 7238, 7322, 7404, 7483, 7559, 7631, 7699, 7763,
            7823, 7878, 7929, 7976, 8019, 8058, 8094, 8128, 8159, 8188, 8216, 8243, 8269, 8294, 8318, 8342, 8365, 8387,
            8408, 8428, 8447, 8465, 8482, 8498, 8513, 8527, 8540, 8552, 8564, 8575, 8586, 8597, 8607, 8618, 8628, 8638,
            8649, 8659, 8669, 8680, 8691, 8703, 8716, 8730, 8744, 8759, 8773, 8786
        };
        private readonly double[] _bellCurveMultiplier =
        {
            0.025, 0.05, 0.075, 0.1, 0.125, 0.15, 0.175, 0.2, 0.275, 0.35, 0.425, 0.5, 0.575, 0.65, 0.725, 0.8, 0.825, 0.85, 0.875, 0.9, 0.925, 0.95, 0.975, 1,
            0.975, 0.95, 0.925, 0.9, 0.875, 0.85, 0.825, 0.8, 0.725, 0.65, 0.575, 0.5, 0.425, 0.35, 0.275, 0.2, 0.175, 0.15, 0.125, 0.1, 0.075, 0.05, 0.025
        };
        private const int MovingAverageRange = 3; // Min = 3
        private const int SofteningWeight = 10;
        public const int YAxisLowerBound = 506;
        public const int YAxisUpperBound = 8800;

        public RacePerformanceCurveChart(Chart chart)
        {
            _chart = chart;
        }

        public void AdjustCurve(int position, NumericUpDownDirectionType direction)
        {
            // Configure
            const int changeFullSize = 47;               // Spread of values affected
            const int changeSideSize = 23;               // Number of values either side of centre
            const int changeMagnitude = 100;             // The change in size of the peak/trough from the centre
            var lowerIndex = position - changeSideSize;  // Lower index
            var higherIndex = position + changeSideSize; // Higher index

            // Calculate changes to apply to curve
            var curveValues = GenerateCurve(changeMagnitude, changeFullSize);

            // Apply change in curve to hidden series
            var hiddenSeries = _chart.Series.FindByName("Hidden");
            for (var i = lowerIndex; i < higherIndex; i++)
            {
                if ((i >= 0) && (i < 120))
                {
                    switch (direction)
                    {
                        case NumericUpDownDirectionType.Up:
                            hiddenSeries.Points[i].YValues[0] += curveValues[i - lowerIndex];
                            break;
                        case NumericUpDownDirectionType.Down:
                            hiddenSeries.Points[i].YValues[0] -= curveValues[i - lowerIndex];
                            break;
                    }

                    // Ensure value is kept within bounds
                    hiddenSeries.Points[i].YValues[0] = CorrectValueIfOutsideBounds(hiddenSeries.Points[i].YValues[0]);
                }
            }

            GenerateProposedSeriesFromHiddenSeries();
        }

        public int[] GetProposedSeries()
        {
            var values = new int[120];
            var proposedSeries = _chart.Series.FindByName("Proposed");
            CopyPoints(proposedSeries, values);
            return values;
        }

        public void GenerateChart()
        {
            // Clear and create new chart area
            _chart.ChartAreas.Clear();
            var chartArea = _chart.ChartAreas.Add(null);

            // Clear and create new legend
            _chart.Legends.Clear();
            var legend = _chart.Legends.Add(null);
            legend.LegendStyle = LegendStyle.Row;
            legend.Position.Auto = true;
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;

            // Clear and create new series
            _chart.Series.Clear();
            var defaultSeries = _chart.Series.Add("Default");
            defaultSeries.ChartType = SeriesChartType.Line;
            var currentSeries = _chart.Series.Add("Current");
            currentSeries.ChartType = SeriesChartType.Line;
            var proposedSeries = _chart.Series.Add("Proposed");
            proposedSeries.ChartType = SeriesChartType.Line;
            var hiddenSeries = _chart.Series.Add("Hidden");
            hiddenSeries.ChartType = SeriesChartType.Line;
            hiddenSeries.Enabled = false;

            // Create labels
            // Known defect when closing bracket is drawn in a vertical orientation at small font size
            // http://support2.dundas.com/forum/tm.aspx?m=8114
            _chart.Titles.Clear();
            var chartTitle = _chart.Titles.Add("Race Performance Curve");
            chartTitle.Font = new Font(chartTitle.Font.FontFamily, chartTitle.Font.SizeInPoints + 10);
            chartArea.AxisX.Title = "Chassis Handling Rating + Engine Power Rating (0-120)";
            chartArea.AxisX.TitleFont = new Font(chartArea.AxisX.TitleFont.FontFamily, chartArea.AxisX.TitleFont.SizeInPoints + 2);
            chartArea.AxisX.Interval = 10;
            chartArea.AxisY.Title = $"Race Performance ({YAxisLowerBound}-{YAxisUpperBound})";
            chartArea.AxisY.TitleFont = new Font(chartArea.AxisY.TitleFont.FontFamily, chartArea.AxisY.TitleFont.SizeInPoints + 2);
            chartArea.AxisY.Interval = 1000;

            // Populate series with data
            CopyPoints(_defaultCurve, defaultSeries);
            CopyPoints(_defaultCurve, currentSeries);
            CopyPoints(_defaultCurve, hiddenSeries);
            GenerateProposedSeriesFromHiddenSeries(true);

            // Resolves a defect when invoking SoftenCurve first time
            // Seems to start drawing softened points from x = 20
            // After softening, reset curve back to current to eliminate first time defect
            SoftenCurve();
            ResetCurveToCurrent();
        }

        public int[] GenerateCurve(int changeMagnitude, int changeFullSize)
        {
            // Return array containing a bell shaped curve based on the change magnitude
            var result = new int[changeFullSize];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = (int)Math.Round(changeMagnitude * _bellCurveMultiplier[i]);
            }
            return result;
        }

        public void ResetCurveToDefault()
        {
            var hiddenSeries = _chart.Series.FindByName("Hidden");
            CopyPoints(_defaultCurve, hiddenSeries);
            GenerateProposedSeriesFromHiddenSeries(true);
        }

        public void ResetCurveToCurrent()
        {
            var hiddenSeries = _chart.Series.FindByName("Hidden");
            var currentSeries = _chart.Series.FindByName("Current");
            CopyPoints(currentSeries, hiddenSeries);
            GenerateProposedSeriesFromHiddenSeries(true);
        }

        public void ResetCurveToRecommended()
        {
            var hiddenSeries = _chart.Series.FindByName("Hidden");
            CopyPoints(_recommendedCurve, hiddenSeries);
            GenerateProposedSeriesFromHiddenSeries(true);
        }

        public void SetCurrentSeries(int[] values)
        {
            var currentSeries = _chart.Series.FindByName("Current");
            CopyPoints(values, currentSeries);
        }

        public void SetCurrentSeriesToProposedSeries()
        {
            var currentSeries = _chart.Series.FindByName("Current");
            var proposedSeries = _chart.Series.FindByName("Proposed");
            CopyPoints(proposedSeries, currentSeries);
        }

        public void SetHiddenSeries(int[] values)
        {
            var hiddenSeries = _chart.Series.FindByName("Hidden");
            var i = 0;
            foreach (var point in hiddenSeries.Points)
            {
                // Ensure values are kept within bounds and set
                point.YValues[0] = CorrectValueIfOutsideBounds(values[i]);
                i++;
            }
            GenerateProposedSeriesFromHiddenSeries(true);
        }

        public void SetProposedSeriesToCurrentSeries()
        {
            var currentSeries = _chart.Series.FindByName("Current");
            var hiddenSeries = _chart.Series.FindByName("Hidden");
            CopyPoints(currentSeries, hiddenSeries);
            GenerateProposedSeriesFromHiddenSeries(true);
        }

        public void SoftenCurve()
        {
            var hiddenSeries = _chart.Series.FindByName("Hidden");

            // Loop while keeping start and end points the same
            for (var i = 0; i < SofteningWeight; i++)
            {
                // Get first and last points
                var firstPoint = hiddenSeries.Points[0].YValues[0];
                var lastPoint = hiddenSeries.Points[hiddenSeries.Points.Count - 1].YValues[0];

                // Soften (this has the effect of shifting points one position to the right)
                _chart.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, MovingAverageRange.ToString(), $"{hiddenSeries.Name}:Y", $"{hiddenSeries.Name}:Y");

                // Shift all points back one on the x-axis
                for (var j = 0; j < hiddenSeries.Points.Count - 1; j++)
                {
                    hiddenSeries.Points[j].YValues[0] = hiddenSeries.Points[j + 1].YValues[0];
                }

                // Restore first and last points to retain the shape at the ends
                hiddenSeries.Points[0].YValues[0] = firstPoint;
                hiddenSeries.Points[hiddenSeries.Points.Count - 1].YValues[0] = lastPoint;

                // Ensure softened curve is kept within bounds
                foreach (var point in hiddenSeries.Points)
                {
                    point.YValues[0] = CorrectValueIfOutsideBounds(point.YValues[0]);
                }
            }

            GenerateProposedSeriesFromHiddenSeries();
        }

        public void ToggleCurrentSeries()
        {
            var currentSeries = _chart.Series.FindByName("Current");
            currentSeries.Enabled = !currentSeries.Enabled;
        }

        public void ToggleDefaultSeries()
        {
            var defaultSeries = _chart.Series.FindByName("Default");
            defaultSeries.Enabled = !defaultSeries.Enabled;
        }

        public void ToggleProposedSeries()
        {
            var proposedSeries = _chart.Series.FindByName("Proposed");
            proposedSeries.Enabled = !proposedSeries.Enabled;
        }

        private static double CorrectValueIfOutsideBounds(double value)
        {
            var result = value;
            if (value < YAxisLowerBound)
            {
                result = YAxisLowerBound;
            }
            else if (value > YAxisUpperBound)
            {
                result = YAxisUpperBound;
            }
            return result;
        }

        private static void CopyPoints(IEnumerable<int> source, Series destination)
        {
            destination.Points.Clear();
            foreach (var point in source)
            {
                destination.Points.Add(point);
            }
        }

        private static void CopyPoints(Series source, IList<int> destination)
        {
            var i = 0;
            foreach (var point in source.Points)
            {
                destination[i] = (int)point.YValues[0];
                i++;
            }
        }

        private static void CopyPoints(Series source, Series destination)
        {
            destination.Points.Clear();
            foreach (var point in source.Points)
            {
                destination.Points.Add(point.YValues[0]);
            }
        }

        private void GenerateProposedSeriesFromHiddenSeries(bool asIdentical = false)
        {
            var hiddenSeries = _chart.Series.FindByName("Hidden");
            var proposedSeries = _chart.Series.FindByName("Proposed");

            if (asIdentical)
            {
                CopyPoints(hiddenSeries, proposedSeries);
                _chart.Refresh();
                return;
            }

            // Calculate softened curve using moving average formula against hidden series
            // https://msdn.microsoft.com/en-us/library/dd456699(v=vs.110).aspx

            // Use hidden series as source, proposed series as destination, start from first point
            _chart.DataManipulator.IsStartFromFirst = true;
            _chart.DataManipulator.FinancialFormula(FinancialFormula.MovingAverage, MovingAverageRange.ToString(), $"{hiddenSeries.Name}:Y", $"{proposedSeries.Name}:Y");

            // Ensure softened curve is kept within bounds
            foreach (var point in proposedSeries.Points)
            {
                point.YValues[0] = CorrectValueIfOutsideBounds(point.YValues[0]);
            }

            _chart.Refresh();
        }
    }
}
