using System;
using System.Linq;
using App.BaseGameEditor.Infrastructure.Services;
using App.DependencyInjection.Autofac;
using App.Outputs;
using Autofac;
using AutoMapper;

namespace App
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            // TODO: Remove?
            //using (var container = new AutofacDependencyInjectionContainer(
            //    new AutofacContainerBootstrapper(new ContainerBuilder()),
            //    new ConsoleOutput()))
            //{
            //    container.BuildContainer();

            //    //container.ListRegistrations();

            //    var mapperService = container.Resolve<IMapperService>();
            //    mapperService.Initialise();

            //    var application = container.Resolve<Application>();
            //    application.Run();
            //}

            // TODO: dotnet console app? https://stackoverflow.com/a/48364023//

            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacModule());
            // TODO: Register any presentation-specific types here
            var container = builder.Build();
            var mapper = container.Resolve<IMapperService>();
            var application = container.Resolve<Application>();
            application.Run();

            Console.ReadLine();
        }
    }
}