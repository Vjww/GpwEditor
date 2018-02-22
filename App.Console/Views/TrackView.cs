using System;
using System.Collections.Generic;
using App.Console.Outputs;
using App.Console.ViewModels;

namespace App.Console.Views
{
    public class TrackView
    {
        private readonly IOutput _output;

        public TrackView(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Display(IEnumerable<TrackViewModel> items)
        {
            _output.WriteLine("Tracks");
            _output.WriteLine("-------");
            foreach (var item in items)
            {
                _output.WriteLine($"Name: {item.Name}");
                _output.WriteLine($"Laps: {item.Laps}");
                _output.WriteLine($"Design: {item.Design}");
                _output.WriteLine($"LapRecordDriver: {item.LapRecordDriver}");
                _output.WriteLine($"LapRecordTeam: {item.LapRecordTeam}");
                _output.WriteLine($"LapRecordTime: {item.LapRecordTime}");
                _output.WriteLine($"LapRecordMph: {item.LapRecordMph}");
                _output.WriteLine($"LapRecordYear: {item.LapRecordYear}");
                _output.WriteLine($"LastRaceDriver: {item.LastRaceDriver}");
                _output.WriteLine($"LastRaceTeam: {item.LastRaceTeam}");
                _output.WriteLine($"LastRaceYear: {item.LastRaceYear}");
                _output.WriteLine($"LastRaceTime: {item.LastRaceTime}");
                _output.WriteLine($"Hospitality: {item.Hospitality}");
                _output.WriteLine($"Speed: {item.Speed}");
                _output.WriteLine($"Grip: {item.Grip}");
                _output.WriteLine($"Surface: {item.Surface}");
                _output.WriteLine($"Tarmac: {item.Tarmac}");
                _output.WriteLine($"Dust: {item.Dust}");
                _output.WriteLine($"Overtaking: {item.Overtaking}");
                _output.WriteLine($"Braking: {item.Braking}");
                _output.WriteLine($"Rain: {item.Rain}");
                _output.WriteLine($"Heat: {item.Heat}");
                _output.WriteLine($"Wind: {item.Wind}");
                _output.WriteLine();
            }
            _output.WriteLine();
        }
    }
}