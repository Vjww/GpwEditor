using System;
using App.AutoMapper;
using App.DependencyInjection.Unity;
using App.Output;

namespace App
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var outputDevice = new ConsoleOutput();

            AutoMapperConfig.RegisterMappings();

            // TODO: Pick a dependency injection container to match your taste
            //using (var container = new AutofacDependencyInjectionContainer(outputDevice))
            using (var container = new UnityDependencyInjectionContainer(outputDevice))
            {
                container.DisplayContainerName();
                container.PerformRegistrations();
                container.DisplayRegistrations();

                container.GetInstance<Application>().Run();
            }

            Console.ReadLine();
        }
    }
}