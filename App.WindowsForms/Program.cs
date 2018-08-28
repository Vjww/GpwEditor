using System;
using System.Reflection;
using System.Windows.Forms;
using App.DependencyInjection.Autofac;
using App.WindowsForms.Charts;
using App.WindowsForms.Controllers;
using App.WindowsForms.Views;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceCollection = new ServiceCollection();

            // AutoMapper: Scan for and register profiles in assemblies
            serviceCollection.AddAutoMapper(
                Assembly.GetAssembly(typeof(BaseGameEditor.Application.Maps.AutoMapper.Reference.ApplicationMaps)),
                Assembly.GetAssembly(typeof(LanguageFileEditor.Application.Maps.AutoMapper.Reference.ApplicationMaps)),
                Assembly.GetAssembly(typeof(Maps.AutoMapper.Reference.PresentationMaps)));

            // Autofac: http://autofaccn.readthedocs.io/en/latest/integration/netcore.html
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterModule(new AutofacModule());

            // Register child forms
            containerBuilder.RegisterType<UpgradeGameForm>().InstancePerDependency();
            containerBuilder.RegisterType<ConfigureGameForm>().InstancePerDependency();
            containerBuilder.RegisterType<PerformanceCurveValuesForm>().InstancePerDependency();
            containerBuilder.RegisterType<BaseGameEditorForm>().InstancePerDependency();
            containerBuilder.RegisterType<LanguageFileEditorForm>().InstancePerDependency();

            // Register transients
            containerBuilder.RegisterType<PerformanceCurveChart>().InstancePerDependency();

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);
            var application = serviceProvider.GetService<MenuController>();
            application.Run();
        }
    }
}