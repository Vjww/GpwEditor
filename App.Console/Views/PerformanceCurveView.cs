using System;
using System.Collections.Generic;
using App.Console.Outputs;
using App.Console.ViewModels;

namespace App.Console.Views
{
    public class PerformanceCurveView
    {
        private readonly IOutput _output;

        public PerformanceCurveView(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Display(IEnumerable<PerformanceCurveViewModel> items)
        {
            _output.WriteLine("Performance Curve Values");
            _output.WriteLine("------------------------");
            var counter = 0;
            foreach (var item in items)
            {
                _output.WriteLine($"Value {counter+1, 3}: {item.Value, 5}");

                counter++;
            }
            _output.WriteLine();
        }
    }
}