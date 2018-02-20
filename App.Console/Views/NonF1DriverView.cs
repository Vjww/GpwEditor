using System;
using System.Collections.Generic;
using App.Console.Outputs;
using App.Console.ViewModels;

namespace App.Console.Views
{
    public class NonF1DriverView
    {
        private readonly IOutput _output;

        public NonF1DriverView(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Display(IEnumerable<NonF1DriverViewModel> items)
        {
            _output.WriteLine("Non-F1 Drivers");
            _output.WriteLine("--------------");
            foreach (var item in items)
            {
                _output.WriteLine($"Name: {item.Name}");
                _output.WriteLine($"Salary: {item.Salary}");
                _output.WriteLine($"RaceBonus: {item.RaceBonus}");
                _output.WriteLine($"ChampionshipBonus: {item.ChampionshipBonus}");
                _output.WriteLine($"Age: {item.Age}");
                _output.WriteLine($"Nationality: {item.Nationality}");
                _output.WriteLine($"UnknownA: {item.UnknownA}");

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