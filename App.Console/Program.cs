using System.Reflection;
using App.BaseGameEditor.Application.Maps.AutoMapper.Reference;
using App.Console.Maps.AutoMapper.Reference;
using App.Console.Outputs;
using App.DependencyInjection.Autofac;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace App.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            // AutoMapper: 
            // Scan for and register profiles in assemblies
            serviceCollection.AddAutoMapper(
                Assembly.GetAssembly(typeof(ApplicationMaps)),
                Assembly.GetAssembly(typeof(PresentationMaps)));

            // Autofac: http://autofaccn.readthedocs.io/en/latest/integration/netcore.html
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterModule(new AutofacModule());
            containerBuilder.RegisterType<ConsoleOutput>().As<IOutput>().SingleInstance();

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            var application = serviceProvider.GetService<Application>();
            application.Run();

            var _ = System.Console.ReadLine();
        }
    }
}