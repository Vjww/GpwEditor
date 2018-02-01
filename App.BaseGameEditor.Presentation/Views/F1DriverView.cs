using System;
using System.Collections.Generic;
using App.BaseGameEditor.Presentation.Outputs;
using App.BaseGameEditor.Presentation.ViewModels;

namespace App.BaseGameEditor.Presentation.Views
{
    public class F1DriverView
    {
        private readonly IOutput _output;

        public F1DriverView(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Display(IEnumerable<F1DriverViewModel> items)
        {
            _output.WriteLine("Drivers");
            _output.WriteLine("-------");
            foreach (var item in items)
            {
                _output.WriteLine($"TeamId: {item.TeamId}");
                _output.WriteLine($"Name: {item.Name}");
                _output.WriteLine($"Salary: {item.Salary}");
                _output.WriteLine($"RaceBonus: {item.RaceBonus}");
                _output.WriteLine($"ChampionshipBonus: {item.ChampionshipBonus}");
                _output.WriteLine($"PayRating: {item.PayRating}");
                _output.WriteLine($"PositiveSalary: {item.PositiveSalary}");
                _output.WriteLine($"LastChampionshipPosition: {item.LastChampionshipPosition}");
                _output.WriteLine($"DriverRole: {item.DriverRole}");
                _output.WriteLine($"Age: {item.Age}");
                _output.WriteLine($"Nationality: {item.Nationality}");
                _output.WriteLine($"CommentaryIndex: {item.CommentaryIndex}"); // TODO: Should this be moved to own view model?

                _output.WriteLine($"CareerChampionships: {item.CareerChampionships}");
                _output.WriteLine($"CareerRaces: {item.CareerRaces}");
                _output.WriteLine($"CareerWins: {item.CareerWins}");
                _output.WriteLine($"CareerPoints: {item.CareerPoints}");
                _output.WriteLine($"CareerFastestLaps: {item.CareerFastestLaps}");
                _output.WriteLine($"CareerPointsFinishes: {item.CareerPointsFinishes}");
                _output.WriteLine($"CareerPolePositions: {item.CareerPolePositions}");

                _output.WriteLine($"Speed: {item.Speed}");
                _output.WriteLine($"Skill: {item.Skill}");
                _output.WriteLine($"Overtaking: {item.Overtaking}");
                _output.WriteLine($"WetWeather: {item.WetWeather}");
                _output.WriteLine($"Concentration: {item.Concentration}");
                _output.WriteLine($"Experience: {item.Experience}");
                _output.WriteLine($"Stamina: {item.Stamina}");
                _output.WriteLine($"Morale: {item.Morale}");
                _output.WriteLine();
            }
            _output.WriteLine();
        }
    }
}