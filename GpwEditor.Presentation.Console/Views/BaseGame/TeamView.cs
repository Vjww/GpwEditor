using GpwEditor.Presentation.Console.Models;

namespace GpwEditor.Presentation.Console.Views.BaseGame
{
    public class TeamView
    {
        public void Display(BaseGameModel model)
        {
            System.Console.WriteLine("Teams");
            System.Console.WriteLine("-----");
            foreach (var item in model.Teams)
            {
                System.Console.WriteLine($"TeamId: {item.TeamId}");
                System.Console.WriteLine($"Name: {item.Name}");
                System.Console.WriteLine($"LastPosition: {item.LastPosition}");
                System.Console.WriteLine($"LastPoints: {item.LastPoints}");
                System.Console.WriteLine($"FirstGpTrack: {item.FirstGpTrack}");
                System.Console.WriteLine($"FirstGpYear: {item.FirstGpYear}");
                System.Console.WriteLine($"Wins: {item.Wins}");
                System.Console.WriteLine($"YearlyBudget: {item.YearlyBudget}");
                System.Console.WriteLine($"CountryMapId: {item.CountryMapId}");
                System.Console.WriteLine($"Location: {item.LocationPointerX}, {item.LocationPointerY}");
                System.Console.WriteLine($"TyreSupplierId: {item.TyreSupplierId}");
                System.Console.WriteLine($"Chassis Handling: {item.ChassisHandling}%");
                System.Console.WriteLine($"Car Numbers: {item.CarNumberDriver1}, {item.CarNumberDriver2}");
                System.Console.WriteLine();
            }
            System.Console.WriteLine("-----");

        }
    }
}