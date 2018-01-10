using System;
using System.Collections.Generic;
using App.BaseGameEditor.Presentation.Outputs;
using App.BaseGameEditor.Presentation.ViewModels;

namespace App.BaseGameEditor.Presentation.Views
{
    public class TeamView : IView
    {
        private readonly IOutput _output;

        public TeamView(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Display(IEnumerable<TeamViewModel> teams)
        {
            _output.WriteLine("Teams");
            _output.WriteLine("-----");
            foreach (var team in teams)
            {
                _output.WriteLine($"TeamId: {team.TeamId}");
                _output.WriteLine($"Name: {team.Name}");
                _output.WriteLine($"LastPosition: {team.LastPosition}");
                _output.WriteLine($"LastPoints: {team.LastPoints}");
                _output.WriteLine($"FirstGpTrack: {team.FirstGpTrack}");
                _output.WriteLine($"FirstGpYear: {team.FirstGpYear}");
                _output.WriteLine($"Wins: {team.Wins}");
                _output.WriteLine($"YearlyBudget: {team.YearlyBudget}");
                _output.WriteLine($"CountryMapId: {team.CountryMapId}");
                _output.WriteLine($"Location: {team.LocationPointerX}, {team.LocationPointerY}");
                _output.WriteLine($"TyreSupplierId: {team.TyreSupplierId}");
                _output.WriteLine($"Chassis Handling: {team.ChassisHandling}%");
                _output.WriteLine($"Car Numbers: {team.CarNumberDriver1}, {team.CarNumberDriver2}");
                _output.WriteLine();
            }
            _output.WriteLine("-----");
        }
    }
}