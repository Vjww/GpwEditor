using System;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.BaseGameEditor.Data.FileResources;
using App.BaseGameEditor.Domain.Entities;
using App.DependencyInjection.Autofac;
using App.Output;
using Autofac;
using FluentAssertions;
using Xunit;

namespace App.Tests.DependancyInjection.Autofac
{
    public class AutofacDependencyInjectionContainer
    {
        [Fact]
        public void AutofacDependencyInjectionContainer_WhenInvokingListRegistrationsMethodWhenContainerIsNotBuilt_ExpectException()
        {
            var action = new Action(() =>
            {
                using (var sut = new DependencyInjection.Autofac.AutofacDependencyInjectionContainer(
                    new AutofacContainerBootstrapper(new ContainerBuilder()), new ConsoleOutput())) // TODO: Mock it
                {
                    sut.ListRegistrations();
                }
            });

            action.ShouldThrow<InvalidOperationException>().WithMessage("Container is not built.");
        }

        [Fact]
        public void AutofacDependencyInjectionContainer_WhenInvokingResolveMethodWhenContainerIsNotBuilt_ExpectException()
        {
            var action = new Action(() =>
            {
                using (var sut = new DependencyInjection.Autofac.AutofacDependencyInjectionContainer(
                    new AutofacContainerBootstrapper(new ContainerBuilder()), new ConsoleOutput())) // TODO: Mock it
                {
                    sut.Resolve<object>();
                }
            });

            action.ShouldThrow<InvalidOperationException>().WithMessage("Container is not built.");
        }

        [Fact]
        public void AutofacDependencyInjectionContainer_WhenInvokingResolveMethodWithGenericTypeOfFileResource_ExpectNewInstance()
        {
            using (var sut = new DependencyInjection.Autofac.AutofacDependencyInjectionContainer(
                new AutofacContainerBootstrapper(new ContainerBuilder()), new ConsoleOutput())) // TODO: Mock it
            {
                sut.BuildContainer();

                var currentInstance = sut.Resolve<FileResource>();
                var newInstance = sut.Resolve<FileResource>();

                currentInstance.Should().NotBeNull();
                newInstance.Should().NotBeNull();
                newInstance.Should().NotBeSameAs(currentInstance);
            }
        }

        [Fact]
        public void AutofacDependencyInjectionContainer_WhenInvokingResolveMethodWithGenericTypeOfLanguageCatalogueValue_ExpectNewInstance()
        {
            using (var sut = new DependencyInjection.Autofac.AutofacDependencyInjectionContainer(
                new AutofacContainerBootstrapper(new ContainerBuilder()), new ConsoleOutput())) // TODO: Mock it
            {
                sut.BuildContainer();

                var currentInstance = sut.Resolve<LanguageCatalogueValue>();
                var newInstance = sut.Resolve<LanguageCatalogueValue>();

                currentInstance.Should().NotBeNull();
                newInstance.Should().NotBeNull();
                newInstance.Should().NotBeSameAs(currentInstance);
            }
        }

        [Fact]
        public void AutofacDependencyInjectionContainer_WhenInvokingResolveMethodWithGenericTypeOfTeamEntity_ExpectNewInstance()
        {
            using (var sut = new DependencyInjection.Autofac.AutofacDependencyInjectionContainer(
                new AutofacContainerBootstrapper(new ContainerBuilder()), new ConsoleOutput())) // TODO: Mock it
            {
                sut.BuildContainer();

                var currentInstance = sut.Resolve<TeamEntity>();
                var newInstance = sut.Resolve<TeamEntity>();

                currentInstance.Should().NotBeNull();
                newInstance.Should().NotBeNull();
                newInstance.Should().NotBeSameAs(currentInstance);
            }
        }
    }
}