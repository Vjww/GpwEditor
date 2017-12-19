using System;
using GpwEditor.Presentation.Console.DependencyInjection.Output;
using GpwEditor.Presentation.Console.Models;

namespace GpwEditor.Presentation.Console.Views.BaseGame
{
    public class TeamView : IView
    {
        private readonly IOutput _output;
        private readonly BaseGameModel _model;

        public TeamView(IOutput output, BaseGameModel model)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public void Display()
        {
            _output.WriteLine("Teams");
            _output.WriteLine("-----");
            foreach (var item in _model.Teams)
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
            _output.WriteLine("-----");
        }
    }
}