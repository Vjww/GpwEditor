using System;
using App.BaseGameEditor.Infrastructure.Services;
using App.DependencyInjection.Autofac;
using App.Output;
using Autofac;

namespace App
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            using (var container = new AutofacDependencyInjectionContainer(
                new AutofacContainerBootstrapper(new ContainerBuilder()),
                new ConsoleOutput()))
            {
                container.BuildContainer();

                container.ListRegistrations();

                var mapperService = container.Resolve<IMapperService>();
                mapperService.Initialise();

                var application = container.Resolve<Application>();
                application.Run();
            }

            Console.ReadLine();
        }
    }
}