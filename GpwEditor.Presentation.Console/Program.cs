using System;
using GpwEditor.Application;
using GpwEditor.Application.DataServices;
using GpwEditor.Presentation.Console.Controllers;
using GpwEditor.Presentation.Console.DependencyInjection.Output;
using GpwEditor.Presentation.Console.DependencyInjection.Unity;

namespace GpwEditor.Presentation.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AutoMapperConfig.RegisterMappings();

            var outputDevice = new ConsoleOutput();

            // TODO: Pick a dependency injection container to match your taste
            //using (var container = new AutofacDependencyInjectionContainer(outputDevice))
            using (var container = new UnityDependencyInjectionContainer(outputDevice))

            {
                container.DisplayContainerName();
                container.PerformRegistrations();
                container.DisplayRegistrations();

                container.GetInstance<Application>().Run();
            }

            // TODO: remove, temp measure
            System.Console.ReadLine();
        }
    }

    public class Application
    {
        private const string GameFolder = @"C:\gpw";
        private const string TempFolder = @"C:\temp\gpwtest";

        private readonly BaseGameController _controller;
        private readonly BaseGameDataService _service;

        public Application(BaseGameController controller, BaseGameDataService service)
        {
            _controller = controller ?? throw new ArgumentNullException(nameof(controller));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Run()
        {
            _service.Load(
                $@"{GameFolder}",
                $@"{GameFolder}\gpw.exe",
                $@"{GameFolder}\english.txt",
                $@"{GameFolder}\french.txt",
                $@"{GameFolder}\german.txt",
                $@"{GameFolder}\text\comme.txt",
                $@"{GameFolder}\textf\commf.txt",
                $@"{GameFolder}\textg\commg.txt");

            _controller.Home();

            _service.Save(
                $@"{TempFolder}",
                $@"{TempFolder}\gpw.exe",
                $@"{TempFolder}\english.txt",
                $@"{TempFolder}\french.txt",
                $@"{TempFolder}\german.txt",
                $@"{TempFolder}\comme.txt",
                $@"{TempFolder}\commf.txt",
                $@"{TempFolder}\commg.txt");
        }
    }
}