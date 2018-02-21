using System;
using System.Collections.Generic;
using App.Console.Outputs;
using App.Console.ViewModels;

namespace App.Console.Views
{
    public class TyreView
    {
        private readonly IOutput _output;

        public TyreView(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Display(IEnumerable<TyreViewModel> items)
        {
            _output.WriteLine("Tyres");
            _output.WriteLine("-----");
            foreach (var item in items)
            {
                _output.WriteLine($"Name: {item.Name}");
                _output.WriteLine($"DryHardGrip: {item.DryHardGrip}");
                _output.WriteLine($"DryHardResilience: {item.DryHardResilience}");
                _output.WriteLine($"DryHardStiffness: {item.DryHardStiffness}");
                _output.WriteLine($"DryHardTemperature: {item.DryHardTemperature}");
                _output.WriteLine($"DrySoftGrip: {item.DrySoftGrip}");
                _output.WriteLine($"DrySoftResilience: {item.DrySoftResilience}");
                _output.WriteLine($"DrySoftStiffness: {item.DrySoftStiffness}");
                _output.WriteLine($"DrySoftTemperature: {item.DrySoftTemperature}");
                _output.WriteLine($"IntermediateGrip: {item.IntermediateGrip}");
                _output.WriteLine($"IntermediateResilience: {item.IntermediateResilience}");
                _output.WriteLine($"IntermediateStiffness: {item.IntermediateStiffness}");
                _output.WriteLine($"IntermediateTemperature: {item.IntermediateTemperature}");
                _output.WriteLine($"WetWeatherGrip: {item.WetWeatherGrip}");
                _output.WriteLine($"WetWeatherResilience: {item.WetWeatherResilience}");
                _output.WriteLine($"WetWeatherStiffness: {item.WetWeatherStiffness}");
                _output.WriteLine($"WetWeatherTemperature: {item.WetWeatherTemperature}");
                _output.WriteLine();
            }
            _output.WriteLine();
        }
    }
}