using App.BaseGameEditor.Application.Maps.AutoMapper.Reference;
using App.DependencyInjection.Autofac;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace App.BaseGameEditor.Application.Tests.Fixtures
{
    public class ApplicationMapsFixture : IDisposable
    {
        private readonly AutofacServiceProvider _serviceProvider;

        public ApplicationMapsFixture()
        {
            // Create service collection
            var serviceCollection = new ServiceCollection();

            // Add AutoMapper maps to service collection (using AutoMapper profiles defined in assemblies)
            var assembly = Assembly.GetAssembly(typeof(ApplicationMaps));
            serviceCollection.AddAutoMapper(assembly);

            // Create Autofac dependency injection container
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterModule(new AutofacModule());
            var container = containerBuilder.Build();

            // Create service provider instance
            _serviceProvider = new AutofacServiceProvider(container);
        }

        public T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        public void Dispose()
        {
        }
    }
}
