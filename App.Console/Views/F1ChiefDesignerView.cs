using System;
using System.Collections.Generic;
using App.Console.Outputs;
using App.Console.ViewModels;

namespace App.Console.Views
{
    public class F1ChiefDesignerView
    {
        private readonly IOutput _output;

        public F1ChiefDesignerView(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Display(IEnumerable<F1ChiefDesignerViewModel> items)
        {
            _output.WriteLine("F1 Chief Designers");
            _output.WriteLine("------------------");
            foreach (var item in items)
            {
                _output.WriteLine($"TeamId: {item.TeamId}");
                _output.WriteLine($"Name: {item.Name}");
                _output.WriteLine($"Ability: {item.Ability}");
                _output.WriteLine($"Age: {item.Age}");
                _output.WriteLine($"Salary: {item.Salary}");
                _output.WriteLine($"RaceBonus: {item.RaceBonus}");
                _output.WriteLine($"ChampionshipBonus: {item.ChampionshipBonus}");
                _output.WriteLine($"DriverLoyalty: {item.DriverLoyalty}");
                _output.WriteLine($"Morale: {item.Morale}");
                _output.WriteLine();
            }
            _output.WriteLine();
        }
    }
}