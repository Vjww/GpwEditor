using System;
using System.Linq;
using Autofac;
using GpwEditor.Presentation.Console.DependencyInjection.Output;

namespace GpwEditor.Presentation.Console.DependencyInjection.Autofac
{
    public class AutofacDependencyInjectionContainer : IAutofacDependencyInjectionContainer
    {
        private const string ContainerName = "Autofac";
        private IContainer _container;
        private readonly IOutput _outputDevice;
        private readonly IAutofacContainerBootstrapper _containerBootstrapper;

        public AutofacDependencyInjectionContainer(IOutput outputDevice)
        {
            _outputDevice = outputDevice ?? throw new ArgumentNullException(nameof(outputDevice));
            _containerBootstrapper = new AutofacContainerBootstrapper(new ContainerBuilder());
        }

        public void Dispose()
        {
            _container?.Dispose();
        }

        public void DisplayContainerName()
        {
            _outputDevice.WriteLine($"# This dependency injection container is powered by {ContainerName}.");
            _outputDevice.WriteLine();
        }

        public void DisplayRegistrations()
        {
            _outputDevice.WriteLine($"# Container has {_container.ComponentRegistry.Registrations.Count()} registrations:");
            _outputDevice.WriteLine();

            foreach (var item in _container.ComponentRegistry.Registrations)
            {
                //var registration = (ContainerRegistration)item;
                //_outputDevice.WriteLine(registration.GetMappingAsString());
                //_outputDevice.WriteLine($"{item.Activator} | {item.Services}");
                _outputDevice.WriteLine($"{item}");
                _outputDevice.WriteLine();
            }

            _outputDevice.WriteLine();
        }

        public T GetApplicationInstance<T>()
        {
            return _container.Resolve<T>();
        }

        public void PerformRegistrations()
        {
            _outputDevice.WriteLine("# Performing registrations...");
            _outputDevice.WriteLine();

            _container = _containerBootstrapper.Register();
        }
    }
}