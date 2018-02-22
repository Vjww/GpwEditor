using System.Collections.Generic;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.FileResources;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Objects;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace App.DependencyInjection.Tests.Autofac
{
    public class AutofacModule
    {
        [Fact]
        public void AutofacModule_WhenGettingServiceFromServiceProviderOfTypeListOfTeamDataEntity_ExpectNonSingleton()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var serviceCollection = new ServiceCollection();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterModule(new DependencyInjection.Autofac.AutofacModule());

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            var currentInstance = serviceProvider.GetService<List<TeamDataEntity>>();
            var newInstance = serviceProvider.GetService<List<TeamDataEntity>>();

            currentInstance.Should().NotBeNull();
            newInstance.Should().NotBeNull();
            newInstance.Should().NotBeSameAs(currentInstance);
        }

        [Fact]
        public void AutofacModule_WhenGettingServiceFromServiceProviderOfTypeFileResource_ExpectNonSingleton()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var serviceCollection = new ServiceCollection();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterModule(new DependencyInjection.Autofac.AutofacModule());

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            var currentInstance = serviceProvider.GetService<FileResource>();
            var newInstance = serviceProvider.GetService<FileResource>();

            currentInstance.Should().NotBeNull();
            newInstance.Should().NotBeNull();
            newInstance.Should().NotBeSameAs(currentInstance);
        }

        [Fact]
        public void AutofacModule_WhenGettingServiceFromServiceProviderOfTypeLanguageCatalogueValue_ExpectNonSingleton()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var serviceCollection = new ServiceCollection();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterModule(new DependencyInjection.Autofac.AutofacModule());

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            var currentInstance = serviceProvider.GetService<LanguageCatalogueValue>();
            var newInstance = serviceProvider.GetService<LanguageCatalogueValue>();

            currentInstance.Should().NotBeNull();
            newInstance.Should().NotBeNull();
            newInstance.Should().NotBeSameAs(currentInstance);
        }

        [Fact]
        public void AutofacModule_WhenGettingServiceFromServiceProviderOfTypeTeamDataEntity_ExpectNonSingleton()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var serviceCollection = new ServiceCollection();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterModule(new DependencyInjection.Autofac.AutofacModule());

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            var currentInstance = serviceProvider.GetService<TeamDataEntity>();
            var newInstance = serviceProvider.GetService<TeamDataEntity>();

            currentInstance.Should().NotBeNull();
            newInstance.Should().NotBeNull();
            newInstance.Should().NotBeSameAs(currentInstance);
        }

        [Fact]
        public void AutofacModule_WhenGettingServiceFromServiceProviderOfTypeTeamDataLocator_ExpectNonSingleton()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var serviceCollection = new ServiceCollection();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterModule(new DependencyInjection.Autofac.AutofacModule());

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            var currentInstance = serviceProvider.GetService<TeamDataLocator>();
            var newInstance = serviceProvider.GetService<TeamDataLocator>();

            currentInstance.Should().NotBeNull();
            newInstance.Should().NotBeNull();
            newInstance.Should().NotBeSameAs(currentInstance);
        }

        [Fact]
        public void AutofacModule_WhenGettingServiceFromServiceProviderOfTypeTeamEntity_ExpectNonSingleton()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var serviceCollection = new ServiceCollection();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterModule(new DependencyInjection.Autofac.AutofacModule());

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            var currentInstance = serviceProvider.GetService<TeamEntity>();
            var newInstance = serviceProvider.GetService<TeamEntity>();

            currentInstance.Should().NotBeNull();
            newInstance.Should().NotBeNull();
            newInstance.Should().NotBeSameAs(currentInstance);
        }

        [Fact]
        public void AutofacModule_WhenGettingServiceFromServiceProviderOfTypeCarNumbersObject_ExpectNonSingleton()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var serviceCollection = new ServiceCollection();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterModule(new DependencyInjection.Autofac.AutofacModule());

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            var currentInstance = serviceProvider.GetService<CarNumbersObject>();
            var newInstance = serviceProvider.GetService<CarNumbersObject>();

            currentInstance.Should().NotBeNull();
            newInstance.Should().NotBeNull();
            newInstance.Should().NotBeSameAs(currentInstance);
        }
    }
}