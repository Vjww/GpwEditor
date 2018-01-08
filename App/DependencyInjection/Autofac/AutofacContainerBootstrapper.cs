using System;
using Autofac;

namespace App.DependencyInjection.Autofac
{
    public class AutofacContainerBootstrapper : IAutofacContainerBootstrapper
    {
        private readonly ContainerBuilder _containerBuilder;

        public AutofacContainerBootstrapper(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder ?? throw new ArgumentNullException(nameof(containerBuilder));
        }

        public IContainer Register()
        {
            _containerBuilder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).Where(
                x => x.Namespace != null &&
                     !x.Namespace.StartsWith("App.AutoMapper") &&
                     !x.Namespace.StartsWith("App.DependencyInjection") &&
                     !x.Namespace.StartsWith("App.Output") &&
                     (
                         x.Namespace.StartsWith("App") ||
                         x.Namespace.StartsWith("App.BaseGameEditor.Presentation") ||
                         x.Namespace.StartsWith("App.BaseGameEditor.Application") ||
                         x.Namespace.StartsWith("App.BaseGameEditor.Domain") ||
                         x.Namespace.StartsWith("App.BaseGameEditor.Infrastructure") ||
                         x.Namespace.StartsWith("GpwEditor.Infrastructure") ||
                         x.Namespace.StartsWith("Common.Editor.Data")
                    ))
                .AsImplementedInterfaces();
            return _containerBuilder.Build();
        }
    }
}