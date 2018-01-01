using System;
using System.Linq;
using GpwEditor.Presentation.Console.DependencyInjection.Output;
using Unity;
using Unity.Container.Registration;

namespace GpwEditor.Presentation.Console.DependencyInjection.Unity
{
    public class UnityDependencyInjectionContainer : IUnityDependencyInjectionContainer
    {
        private const string ContainerName = "Unity";
        private IUnityContainer _container;
        private readonly IOutput _outputDevice;
        private readonly IUnityContainerBootstrapper _containerBootstrapper;

        public UnityDependencyInjectionContainer(IOutput outputDevice)
        {
            _outputDevice = outputDevice ?? throw new ArgumentNullException(nameof(outputDevice));
            _containerBootstrapper = new UnityContainerBootstrapper(new UnityContainer());
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
            if (_container == null)
            {
                _outputDevice.WriteLine("# Container is null. Please perform registrations before displaying them.");
                return;
            }

            _outputDevice.WriteLine($"# Container has {_container.Registrations.Count()} registrations:");
            _outputDevice.WriteLine();

            foreach (var item in _container.Registrations)
            {
                var registration = (ContainerRegistration)item;
                _outputDevice.WriteLine(registration.GetMappingAsString());

                //_outputDevice.WriteLine($"{item.Name}");
                //_outputDevice.WriteLine($"{item.RegisteredType}");
                //_outputDevice.WriteLine($"{item.MappedToType}");
                //_outputDevice.WriteLine($"{item.LifetimeManager}");
            }

            _outputDevice.WriteLine();
        }

        public T GetInstance<T>()
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