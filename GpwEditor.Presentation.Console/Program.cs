using GpwEditor.Application.Services;
using GpwEditor.Presentation.Console.Controllers;

namespace GpwEditor.Presentation.Console
{
    internal class Program
    {
        private const string GameFolder = @"C:\gpw";
        private const string TempFolder = @"C:\temp\gpwtest";

        private static void Main(string[] args)
        {
            var application = new BaseGameService();

            application.Load(
                $@"{GameFolder}",
                $@"{GameFolder}\gpw.exe",
                $@"{GameFolder}\english.txt",
                $@"{GameFolder}\french.txt",
                $@"{GameFolder}\german.txt",
                $@"{GameFolder}\text\comme.txt",
                $@"{GameFolder}\textf\commf.txt",
                $@"{GameFolder}\textg\commg.txt");

            var controller = new BaseGameController();
            controller.Home(application);

            application.Save(
                $@"{TempFolder}",
                $@"{TempFolder}\gpw.exe",
                $@"{TempFolder}\english.txt",
                $@"{TempFolder}\french.txt",
                $@"{TempFolder}\german.txt",
                $@"{TempFolder}\comme.txt",
                $@"{TempFolder}\commf.txt",
                $@"{TempFolder}\commg.txt");

            // Wait
            System.Console.ReadLine();
        }
    }
}