using System;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.FileResources;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Maps;
using App.BaseGameEditor.Infrastructure.Services;
using App.BaseGameEditor.Presentation.Outputs;
using App.Services;
using Autofac;
using Autofac.Features.ResolveAnything;

namespace App.DependencyInjection.Autofac
{
    public class AutofacContainerBootstrapper
    {
        private readonly ContainerBuilder _containerBuilder;

        public AutofacContainerBootstrapper(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder ?? throw new ArgumentNullException(nameof(containerBuilder));
        }

        public IContainer Register()
        {
            // Register interface types
            _containerBuilder.RegisterAssemblyTypes(
                AppDomain.CurrentDomain.GetAssemblies()).Where(
                type => type.Namespace != null &&
                    //!type.Namespace.StartsWith("App.DependencyInjection") &&
                    //!type.Namespace.StartsWith("App.ObjectMapping") &&
                    //!type.Namespace.StartsWith("App.ObjectMapping.AutoMapper.Profiles") &&
                    !type.Namespace.StartsWith("App.Outputs") &&
                    (
                        type.Namespace.StartsWith("App") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Presentation") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Application") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Domain") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Infrastructure") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Data")
                    ))
                .AsImplementedInterfaces()
                .SingleInstance();

            // Register concrete types that do not implement interfaces
            _containerBuilder.RegisterSource(
                new AnyConcreteTypeNotAlreadyRegisteredSource()
                .WithRegistrationsAs(rb => rb.SingleInstance()));

            // Register factories via dynamic instantiation Func<T>
            // http://autofaccn.readthedocs.io/en/latest/resolve/relationships.html#dynamic-instantiation-func-b

            // Manual registrations
            _containerBuilder.RegisterType<ConsoleOutput>().As<BaseGameEditor.Presentation.Outputs.IOutput>().SingleInstance();
            _containerBuilder.RegisterType<MemoryStreamFactory>().As<IStreamFactory>().SingleInstance();

            _containerBuilder.RegisterType<FileResource>().InstancePerDependency();              // TODO: Needs test
            _containerBuilder.RegisterType<LanguageCatalogueValue>().InstancePerDependency();    // TODO: Needs test

            _containerBuilder.RegisterType<TeamEntity>().InstancePerDependency();                // TODO: Needs test
            _containerBuilder.RegisterType<CarNumbersObject>().InstancePerDependency();          // TODO: Needs test
            _containerBuilder.RegisterType<CarNumberDataEntity>().InstancePerDependency();       // TODO: Needs test
            _containerBuilder.RegisterType<ChassisHandlingDataEntity>().InstancePerDependency(); // TODO: Needs test
            _containerBuilder.RegisterType<TeamDataEntity>().InstancePerDependency();            // TODO: Needs test

            _containerBuilder.RegisterType<CarNumberDataLocator>().InstancePerDependency();      // TODO: Needs test
            _containerBuilder.RegisterType<ChassisHandlingDataLocator>().InstancePerDependency();// TODO: Needs test
            _containerBuilder.RegisterType<TeamDataLocator>().InstancePerDependency();           // TODO: Needs test

            //_containerBuilder.RegisterType<AutoMapperObjectMapperService>().As<IMapperService>();

            //_containerBuilder.RegisterType<LanguageCatalogueExporter>().As<ICatalogueExporter<LanguageCatalogueItem>>();
            //_containerBuilder.RegisterType<LanguageCatalogueImporter>().As<ICatalogueImporter<LanguageCatalogueItem>>();
            //_containerBuilder.RegisterType<LanguageCatalogueReader>().As<ICatalogueReader<LanguageCatalogueItem>>();
            //_containerBuilder.RegisterType<LanguageCatalogueWriter>().As<ICatalogueWriter<LanguageCatalogueItem>>();
            //_containerBuilder.RegisterType<CommentaryCatalogueExporter<ILanguagePhrases>>().As<ICatalogueExporter<CommentaryCatalogueItem>>();
            //_containerBuilder.RegisterType<CommentaryCatalogueImporter<ILanguagePhrases>>().As<ICatalogueImporter<CommentaryCatalogueItem>>();
            //_containerBuilder.RegisterType<CommentaryCatalogueReader>().As<ICatalogueReader<CommentaryCatalogueItem>>();
            //_containerBuilder.RegisterType<CommentaryCatalogueWriter>().As<ICatalogueWriter<CommentaryCatalogueItem>>();


            return _containerBuilder.Build();
        }
    }
}