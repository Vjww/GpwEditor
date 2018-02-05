using System;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.FileResources;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Factories;
using App.BaseGameEditor.Infrastructure.Maps.Manual;
using App.BaseGameEditor.Infrastructure.Repositories;
using App.BaseGameEditor.Presentation.Outputs;
using App.Core.Factories;
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
                    !type.Namespace.StartsWith("App.DependencyInjection") &&
                    !type.Namespace.StartsWith("App.Outputs") &&
                    (
                        type.Namespace.StartsWith("App") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Presentation") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Application") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Domain") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Infrastructure") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Data") ||
                        type.Namespace.StartsWith("App.Core")
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

            _containerBuilder.RegisterType<FileResource>().InstancePerDependency();
            _containerBuilder.RegisterType<LanguageCatalogueValue>().InstancePerDependency();

            _containerBuilder.RegisterType<TeamEntity>().InstancePerDependency();
            _containerBuilder.RegisterType<F1ChiefCommercialEntity>().InstancePerDependency();
            _containerBuilder.RegisterType<F1ChiefDesignerEntity>().InstancePerDependency();
            _containerBuilder.RegisterType<F1ChiefEngineerEntity>().InstancePerDependency();
            _containerBuilder.RegisterType<F1ChiefMechanicEntity>().InstancePerDependency();
            _containerBuilder.RegisterType<F1DriverEntity>().InstancePerDependency();
            _containerBuilder.RegisterType<CarNumbersObject>().InstancePerDependency();

            _containerBuilder.RegisterType<CarNumberDataEntity>().InstancePerDependency();
            _containerBuilder.RegisterType<ChassisHandlingDataEntity>().InstancePerDependency();
            _containerBuilder.RegisterType<F1ChiefCommercialDataEntity>().InstancePerDependency();
            _containerBuilder.RegisterType<F1ChiefDesignerDataEntity>().InstancePerDependency();
            _containerBuilder.RegisterType<F1ChiefEngineerDataEntity>().InstancePerDependency();
            _containerBuilder.RegisterType<F1ChiefMechanicDataEntity>().InstancePerDependency();
            _containerBuilder.RegisterType<F1DriverDataEntity>().InstancePerDependency();
            _containerBuilder.RegisterType<TeamDataEntity>().InstancePerDependency();

            _containerBuilder.RegisterType<CarNumberDataLocator>().InstancePerDependency();
            _containerBuilder.RegisterType<ChassisHandlingDataLocator>().InstancePerDependency();
            _containerBuilder.RegisterType<F1ChiefCommercialDataLocator>().InstancePerDependency();
            _containerBuilder.RegisterType<F1ChiefDesignerDataLocator>().InstancePerDependency();
            _containerBuilder.RegisterType<F1ChiefEngineerDataLocator>().InstancePerDependency();
            _containerBuilder.RegisterType<F1ChiefMechanicDataLocator>().InstancePerDependency();
            _containerBuilder.RegisterType<F1DriverDataLocator>().InstancePerDependency();
            _containerBuilder.RegisterType<TeamDataLocator>().InstancePerDependency();

            _containerBuilder.RegisterGeneric(typeof(EntityFactory<>)).As(typeof(IEntityFactory<>)).SingleInstance();
            _containerBuilder.RegisterGeneric(typeof(DataLocatorFactory<>)).As(typeof(IDataLocatorFactory<>)).SingleInstance();
            _containerBuilder.RegisterGeneric(typeof(RepositoryExportService<>)).As(typeof(IRepositoryExportService<>)).SingleInstance();
            _containerBuilder.RegisterGeneric(typeof(RepositoryImportService<>)).As(typeof(IRepositoryImportService<>)).SingleInstance();

            //_containerBuilder.RegisterGeneric(typeof(RepositoryExporter<>)).As(typeof(IRepositoryExporter<>)).SingleInstance();
            //_containerBuilder.RegisterGeneric(typeof(AlternativeRepositoryImporter<>)).As(typeof(IAlternativeRepositoryImporter<>)).SingleInstance();

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