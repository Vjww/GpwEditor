using System;
using System.Collections.Generic;
using App.Console.Outputs;
using App.Console.ViewModels;

namespace App.Console.Views
{
    public class TeamView
    {
        private readonly IOutput _output;

        public TeamView(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Display(IEnumerable<TeamViewModel> items)
        {
            _output.WriteLine("Teams");
            _output.WriteLine("-----");
            foreach (var item in items)
            {
                _output.WriteLine($"TeamId: {item.TeamId}");
                _output.WriteLine($"Name: {item.Name}");
                _output.WriteLine($"LastPosition: {item.LastPosition}");
                _output.WriteLine($"LastPoints: {item.LastPoints}");
                _output.WriteLine($"FirstGpTrack: {item.FirstGpTrack}");
                _output.WriteLine($"FirstGpYear: {item.FirstGpYear}");
                _output.WriteLine($"Wins: {item.Wins}");
                _output.WriteLine($"YearlyBudget: {item.YearlyBudget}");
                _output.WriteLine($"CountryMapId: {item.CountryMapId}");
                _output.WriteLine($"Location: {item.LocationPointerX}, {item.LocationPointerY}");
                _output.WriteLine($"TyreSupplierId: {item.TyreSupplierId}");
                _output.WriteLine($"Chassis Handling: {item.ChassisHandling}%");
                _output.WriteLine($"Car Numbers: {item.CarNumberDriver1}, {item.CarNumberDriver2}");
                _output.WriteLine();
            }
            _output.WriteLine();
        }
    }
}