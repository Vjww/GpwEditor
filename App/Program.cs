using System;
using App.BaseGameEditor.Infrastructure.Services;
using App.DependencyInjection.Unity;
using App.Output;

namespace App
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var output = new ConsoleOutput();

            // TODO: Pick a dependency injection container to match your taste
            //using (var container = new AutofacDependencyInjectionContainer(output))
            using (var container = new UnityDependencyInjectionContainer(output))
            {
                container.DisplayContainerName();
                container.PerformRegistrations();
                container.DisplayRegistrations();

                var mapperService = container.GetInstance<IMapperService>();
                mapperService.Initialise();

                var application = container.GetInstance<Application>();
                application.Run();
            }

            Console.ReadLine();
        }
    }
}