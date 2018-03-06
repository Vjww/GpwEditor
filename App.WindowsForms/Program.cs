using System;
using System.Reflection;
using App.BaseGameEditor.Application.Maps.AutoMapper.Reference;
using App.DependencyInjection.Autofac;
using App.WindowsForms.Controllers;
using App.WindowsForms.Maps.AutoMapper.Reference;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace App.WindowsForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var serviceCollection = new ServiceCollection();

            // AutoMapper: Scan for and register profiles in assemblies
            serviceCollection.AddAutoMapper(
                Assembly.GetAssembly(typeof(ApplicationMaps)),
                Assembly.GetAssembly(typeof(PresentationMaps)));

            // Autofac: http://autofaccn.readthedocs.io/en/latest/integration/netcore.html
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterModule(new AutofacModule());

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);
            var application = serviceProvider.GetService<ApplicationController>();
            application.Run();
        }
    }
}