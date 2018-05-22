using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.Catalogues.Commentary;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.FileResources;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Infrastructure.Factories;
using App.BaseGameEditor.Infrastructure.Repositories;
using App.Core.Factories;
using Autofac;
using Autofac.Features.ResolveAnything;

namespace App.DependencyInjection.Autofac
{
    // TODO: Review references, as perhaps only core and infrastructure layers should be referenced?
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Note: Factories are registered via dynamic instantiation Func<T>
            // http://autofaccn.readthedocs.io/en/latest/resolve/relationships.html#dynamic-instantiation-func-b

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var isTypeWithinAppNamespaceRange = new Func<Type, bool>(
                type => type.Namespace != null &&
                (
                    type.Namespace.StartsWith("App.BaseGameEditor.Application") ||
                    type.Namespace.StartsWith("App.BaseGameEditor.Data") ||
                    type.Namespace.StartsWith("App.BaseGameEditor.Domain") ||
                    type.Namespace.StartsWith("App.BaseGameEditor.Infrastructure") ||
                    type.Namespace.StartsWith("App.Core")
                ));

            // Register concrete types that implement interface of the same name
            // e.g. Registers Foo as IFoo and Bar as IBar
            builder.RegisterAssemblyTypes(assemblies)
                    .Where(isTypeWithinAppNamespaceRange)
                .AsImplementedInterfaces()
                .SingleInstance();

            // Register concrete types that do not implement interfaces
            // or do not implement an interface of the same name
            builder.RegisterSource(
                new AnyConcreteTypeNotAlreadyRegisteredSource()
                    .WithRegistrationsAs(rb => rb.SingleInstance()));

            // Manual registrations for singletons
            builder.RegisterType<MemoryStreamFactory>().As<IStreamFactory>().SingleInstance();
            builder.RegisterGeneric(typeof(IntegerIdentityFactory<>)).As(typeof(IIntegerIdentityFactory<>)).SingleInstance();
            builder.RegisterGeneric(typeof(RepositoryExportService<>)).As(typeof(IRepositoryExportService<>)).SingleInstance();
            builder.RegisterGeneric(typeof(RepositoryImportService<>)).As(typeof(IRepositoryImportService<>)).SingleInstance();

            // Manual registrations for non-singletons
            builder.RegisterGeneric(typeof(List<>)).InstancePerDependency();
            builder.RegisterType<FileResource>().InstancePerDependency();
            builder.RegisterType<LanguageCatalogueExporter>().InstancePerDependency();
            builder.RegisterType<LanguageCatalogueImporter>().InstancePerDependency();
            builder.RegisterType<CommentaryCatalogueExporter<ILanguagePhrases>>().InstancePerDependency();
            builder.RegisterType<CommentaryCatalogueImporter<ILanguagePhrases>>().InstancePerDependency();
            builder.RegisterType<LanguageCatalogueValue>().InstancePerDependency();

            // Register types in the data layer as instance per dependancy
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => type.Namespace != null &&
                               type.Namespace.StartsWith("App.BaseGameEditor.Data") &&
                               (type.Name.EndsWith("DataEntity") ||
                                type.Name.EndsWith("DataLocator")))
                .InstancePerDependency();

            // Register types in the domain layer as instance per dependancy
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => type.Namespace != null &&
                               type.Namespace.StartsWith("App.BaseGameEditor.Domain") &&
                               (type.Name.EndsWith("Entity")))
                .InstancePerDependency();

            // Register types in the infrastructure layer as instance per dependancy
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => type.Namespace != null &&
                               type.Namespace.StartsWith("App.BaseGameEditor.Infrastructure") &&
                               (type.Name.EndsWith("Object")))
                .InstancePerDependency();
        }
    }
}