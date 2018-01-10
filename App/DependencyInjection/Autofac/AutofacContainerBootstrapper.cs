using System;
using Autofac;

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
            _containerBuilder.RegisterAssemblyTypes(
                AppDomain.CurrentDomain.GetAssemblies()).Where(
                type => type.Namespace != null &&
                     !type.Namespace.StartsWith("App.AutoMapper") &&
                     !type.Namespace.StartsWith("App.DependencyInjection") &&
                     !type.Namespace.StartsWith("App.Outputs") &&
                     (
                        type.Namespace.StartsWith("App") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Presentation") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Application") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Domain") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Infrastructure") ||
                        type.Namespace.StartsWith("App.BaseGameEditor.Data")
                    ))
                .AsImplementedInterfaces();
            return _containerBuilder.Build();
        }
    }
}