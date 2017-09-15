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
                System.Console.WriteLine($"Car Numbers: {item.CarNumberDriver1}, {item.CarNumberDriver2}");
                System.Console.WriteLine($"Chassis Handling: {item.ChassisHandling}%");
                System.Console.WriteLine();
            }
            System.Console.WriteLine("-----");
        }
    }
}