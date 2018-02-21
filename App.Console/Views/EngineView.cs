using System;
using System.Collections.Generic;
using App.Console.Outputs;
using App.Console.ViewModels;

namespace App.Console.Views
{
    public class EngineView
    {
        private readonly IOutput _output;

        public EngineView(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Display(IEnumerable<EngineViewModel> items)
        {
            _output.WriteLine("Engines");
            _output.WriteLine("-------");
            foreach (var item in items)
            {
                _output.WriteLine($"Name: {item.Name}");
                _output.WriteLine($"Fuel: {item.Fuel}");
                _output.WriteLine($"Heat: {item.Heat}");
                _output.WriteLine($"Power: {item.Power}");
                _output.WriteLine($"Reliability: {item.Reliability}");
                _output.WriteLine($"Response: {item.Response}");
                _output.WriteLine($"Rigidity: {item.Rigidity}");
                _output.WriteLine($"Weight: {item.Weight}");
                _output.WriteLine();
            }
            _output.WriteLine();
        }
    }
}