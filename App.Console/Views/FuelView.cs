using System;
using System.Collections.Generic;
using App.Console.Outputs;
using App.Console.ViewModels;

namespace App.Console.Views
{
    public class FuelView
    {
        private readonly IOutput _output;

        public FuelView(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Display(IEnumerable<FuelViewModel> items)
        {
            _output.WriteLine("Fuels");
            _output.WriteLine("-----");
            foreach (var item in items)
            {
                _output.WriteLine($"Name: {item.Name}");
                _output.WriteLine($"Performance: {item.Performance}");
                _output.WriteLine($"Tolerance: {item.Tolerance}");
                _output.WriteLine();
            }
            _output.WriteLine();
        }
    }
}