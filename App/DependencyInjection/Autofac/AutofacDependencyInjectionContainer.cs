// TODO: Remove?
//using System;
//using System.Linq;
//using Autofac;

//namespace App.DependencyInjection.Autofac
//{
//    public class AutofacDependencyInjectionContainer : IDependencyInjectionContainer
//    {
//        private IContainer _container;
//        private readonly AutofacContainerBootstrapper _containerBootstrapper;
//        private readonly IOutput _output;
//        private bool _isContainerBuilt;

//        public AutofacDependencyInjectionContainer(AutofacContainerBootstrapper containerBootstrapper, IOutput output)
//        {
//            _containerBootstrapper = containerBootstrapper ?? throw new ArgumentNullException(nameof(containerBootstrapper));
//            _output = output ?? throw new ArgumentNullException(nameof(output));
//        }

//        public void Dispose()
//        {
//            _container?.Dispose();
//        }

//        public void BuildContainer()
//        {
//            _output.WriteLine("Building Autofac container...");
//            _output.WriteLine();

//            _container = _containerBootstrapper.Register();

//            _isContainerBuilt = true;
//        }

//        public void ListRegistrations()
//        {
//            if (!_isContainerBuilt)
//            {
//                throw new InvalidOperationException("Container is not built.");
//            }

//            _output.WriteLine($"# Container has {_container.ComponentRegistry.Registrations.Count()} registrations:");
//            _output.WriteLine();

//            foreach (var item in _container.ComponentRegistry.Registrations)
//            {
//                _output.WriteLine($"{item}");
//            }

//            _output.WriteLine();
//        }

//        public T Resolve<T>()
//        {
//            if (!_isContainerBuilt)
//            {
//                throw new InvalidOperationException("Container is not built.");
//            }

//            return _container.Resolve<T>();
//        }
//    }
//}