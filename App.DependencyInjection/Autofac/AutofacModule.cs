using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.DataLocators;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Data.FileResources;
using App.BaseGameEditor.Data.Services;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Factories;
using App.BaseGameEditor.Infrastructure.Repositories;
using App.Core.Factories;
using App.ObjectMapping.Objects;
using App.ObjectMapping.Services;
using Autofac;
using Autofac.Features.ResolveAnything;

namespace App.DependencyInjection.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register interface types
            builder.RegisterAssemblyTypes(
                    AppDomain.CurrentDomain.GetAssemblies()).Where(
                    type => type.Namespace != null &&
                            (
                                type.Namespace.StartsWith("App.BaseGameEditor.Application") ||
                                type.Namespace.StartsWith("App.BaseGameEditor.Data") ||
                                type.Namespace.StartsWith("App.BaseGameEditor.Domain") ||
                                type.Namespace.StartsWith("App.BaseGameEditor.Infrastructure") ||
                                type.Namespace.StartsWith("App.Core") ||
                                type.Namespace.StartsWith("App.ObjectMapping")
                            ))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<AutoMapperMapperService>().As<IMapperService>().SingleInstance();

            // Register concrete types that do not implement interfaces
            builder.RegisterSource(
                new AnyConcreteTypeNotAlreadyRegisteredSource()
                    .WithRegistrationsAs(rb => rb.SingleInstance()));

            // Register factories via dynamic instantiation Func<T>
            // http://autofaccn.readthedocs.io/en/latest/resolve/relationships.html#dynamic-instantiation-func-b

            // Manual registrations
            builder.RegisterType<MemoryStreamFactory>().As<IStreamFactory>().SingleInstance();

            builder.RegisterType<FileResource>().InstancePerDependency();
            builder.RegisterType<LanguageCatalogueValue>().InstancePerDependency();

            // TODO: Register by convention? i.e. all concrete types in namespace ending in Entity
            builder.RegisterType<TeamEntity>().InstancePerDependency();
            builder.RegisterType<F1ChiefCommercialEntity>().InstancePerDependency();
            builder.RegisterType<F1ChiefDesignerEntity>().InstancePerDependency();
            builder.RegisterType<F1ChiefEngineerEntity>().InstancePerDependency();
            builder.RegisterType<F1ChiefMechanicEntity>().InstancePerDependency();
            builder.RegisterType<F1DriverEntity>().InstancePerDependency();
            builder.RegisterType<CarNumbersObject>().InstancePerDependency();

            // TODO: Register by convention? i.e. all concrete types in namespace ending in DataEntity
            builder.RegisterType<CarNumberDataEntity>().InstancePerDependency();
            builder.RegisterType<ChassisHandlingDataEntity>().InstancePerDependency();
            builder.RegisterType<F1ChiefCommercialDataEntity>().InstancePerDependency();
            builder.RegisterType<F1ChiefDesignerDataEntity>().InstancePerDependency();
            builder.RegisterType<F1ChiefEngineerDataEntity>().InstancePerDependency();
            builder.RegisterType<F1ChiefMechanicDataEntity>().InstancePerDependency();
            builder.RegisterType<F1DriverDataEntity>().InstancePerDependency();
            builder.RegisterType<TeamDataEntity>().InstancePerDependency();

            // TODO: Register by convention? i.e. all concrete types in namespace ending in DataLocator
            builder.RegisterType<CarNumberDataLocator>().InstancePerDependency();
            builder.RegisterType<ChassisHandlingDataLocator>().InstancePerDependency();
            builder.RegisterType<F1ChiefCommercialDataLocator>().InstancePerDependency();
            builder.RegisterType<F1ChiefDesignerDataLocator>().InstancePerDependency();
            builder.RegisterType<F1ChiefEngineerDataLocator>().InstancePerDependency();
            builder.RegisterType<F1ChiefMechanicDataLocator>().InstancePerDependency();
            builder.RegisterType<F1DriverDataLocator>().InstancePerDependency();
            builder.RegisterType<TeamDataLocator>().InstancePerDependency();

            builder.RegisterGeneric(typeof(List<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(IntegerIdentityFactory<>)).As(typeof(IIntegerIdentityFactory<>)).SingleInstance();
            builder.RegisterGeneric(typeof(RepositoryExportService<>)).As(typeof(IRepositoryExportService<>)).SingleInstance();
            builder.RegisterGeneric(typeof(RepositoryImportService<>)).As(typeof(IRepositoryImportService<>)).SingleInstance();
        }
    }
}