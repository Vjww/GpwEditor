using System;
using System.Linq;
using Unity;
using Unity.Container.Registration;

namespace App.DependencyInjection.Unity
{
    public class UnityDependencyInjectionContainer : IDependencyInjectionContainer
    {
        private IUnityContainer _container;
        private readonly UnityContainerBootstrapper _containerBootstrapper;
        private readonly IOutput _output;
        private bool _isContainerBuilt;

        public UnityDependencyInjectionContainer(UnityContainerBootstrapper containerBootstrapper, IOutput output)
        {
            _containerBootstrapper = containerBootstrapper ?? throw new ArgumentNullException(nameof(containerBootstrapper));
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        public void Dispose()
        {
            _container?.Dispose();
        }

        public void BuildContainer()
        {
            _output.WriteLine("Building Unity container...");
            _output.WriteLine();

            _container = _containerBootstrapper.Register();

            _isContainerBuilt = true;
        }

        public void ListRegistrations()
        {
            if (!_isContainerBuilt)
            {
                throw new InvalidOperationException("Container is not built.");
            }

            _output.WriteLine($"# Container has {_container.Registrations.Count()} registrations:");
            _output.WriteLine();

            foreach (var item in _container.Registrations
                .OrderBy(x => x.LifetimeManager.ToString())
                .ThenBy(x => x.MappedToType.Namespace))
            {
                var registration = (ContainerRegistration)item;
                _output.WriteLine(registration.GetMappingAsString());
            }

            _output.WriteLine();
        }

        public T Resolve<T>()
        {
            if (!_isContainerBuilt)
            {
                throw new InvalidOperationException("Container is not built.");
            }

            return _container.Resolve<T>();
        }
    }
}