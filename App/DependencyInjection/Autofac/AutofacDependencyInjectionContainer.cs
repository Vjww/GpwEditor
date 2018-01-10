using System;
using System.Linq;
using Autofac;

namespace App.DependencyInjection.Autofac
{
    public class AutofacDependencyInjectionContainer : IDependencyInjectionContainer
    {
        private const string ContainerName = "Autofac";
        private IContainer _container;
        private readonly IOutput _output;
        private readonly AutofacContainerBootstrapper _containerBootstrapper;

        public AutofacDependencyInjectionContainer(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _containerBootstrapper = new AutofacContainerBootstrapper(new ContainerBuilder());
        }

        public void Dispose()
        {
            _container?.Dispose();
        }

        public void DisplayContainerName()
        {
            _output.WriteLine($"# This dependency injection container is powered by {ContainerName}.");
            _output.WriteLine();
        }

        public void DisplayRegistrations()
        {
            _output.WriteLine($"# Container has {_container.ComponentRegistry.Registrations.Count()} registrations:");
            _output.WriteLine();

            foreach (var item in _container.ComponentRegistry.Registrations)
            {
                //var registration = (ContainerRegistration)item;
                //_output.WriteLine(registration.GetMappingAsString());
                //_output.WriteLine($"{item.Activator} | {item.Services}");
                _output.WriteLine($"{item}");
                _output.WriteLine();
            }

            _output.WriteLine();
        }

        public T GetInstance<T>()
        {
            return _container.Resolve<T>();
        }

        public void PerformRegistrations()
        {
            _output.WriteLine("# Performing registrations...");
            _output.WriteLine();

            _container = _containerBootstrapper.Register();
        }
    }
}