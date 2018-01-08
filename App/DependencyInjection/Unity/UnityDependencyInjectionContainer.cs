using System;
using System.Linq;
using App.Output;
using Unity;
using Unity.Container.Registration;

namespace App.DependencyInjection.Unity
{
    public class UnityDependencyInjectionContainer : IUnityDependencyInjectionContainer
    {
        private const string ContainerName = "Unity";
        private IUnityContainer _container;
        private readonly IOutput _output;
        private readonly IUnityContainerBootstrapper _containerBootstrapper;

        public UnityDependencyInjectionContainer(IOutput output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _containerBootstrapper = new UnityContainerBootstrapper(new UnityContainer());
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
            if (_container == null)
            {
                _output.WriteLine("# Container is null. Please perform registrations before displaying them.");
                return;
            }

            _output.WriteLine($"# Container has {_container.Registrations.Count()} registrations:");
            _output.WriteLine();

            foreach (var item in _container.Registrations
                .OrderBy(x => x.LifetimeManager.ToString())
                .ThenBy(x => x.MappedToType.Namespace))
            {
                var registration = (ContainerRegistration)item;
                _output.WriteLine(registration.GetMappingAsString());

                //_output.WriteLine($"{item.Name}");
                //_output.WriteLine($"{item.RegisteredType}");
                //_output.WriteLine($"{item.MappedToType}");
                //_output.WriteLine($"{item.LifetimeManager}");
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