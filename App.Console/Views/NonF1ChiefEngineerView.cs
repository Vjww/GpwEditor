﻿using System;
using System.Collections.Generic;
using App.Console.Outputs;
using App.Console.ViewModels;

namespace App.Console.Views
{
    public class NonF1ChiefEngineerView
    {
        private readonly IOutput _output;

        public NonF1ChiefEngineerView(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Display(IEnumerable<NonF1ChiefEngineerViewModel> items)
        {
            _output.WriteLine("Non-F1 Chief Engineers");
            _output.WriteLine("----------------------");
            foreach (var item in items)
            {
                _output.WriteLine($"Name: {item.Name}");
                _output.WriteLine($"Ability: {item.Ability}");
                _output.WriteLine($"Age: {item.Age}");
                _output.WriteLine($"Salary: {item.Salary}");
                _output.WriteLine($"RaceBonus: {item.RaceBonus}");
                _output.WriteLine($"ChampionshipBonus: {item.ChampionshipBonus}");
                _output.WriteLine();
            }
            _output.WriteLine();
        }
    }
}