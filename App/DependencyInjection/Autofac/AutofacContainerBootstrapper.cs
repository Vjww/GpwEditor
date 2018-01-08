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
            _containerBuilder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).Where(x =>
                x.Namespace != null &&
                x.Namespace.StartsWith("GpwEditor.Presentation.Console") &&
                !x.Namespace.StartsWith("GpwEditor.Presentation.Console.DependencyInjection"))
                //x.Namespace.StartsWith("GpwEditor.Application") &&
                //x.Namespace.StartsWith("GpwEditor.Domain") &&
                //x.Namespace.StartsWith("GpwEditor.Infrastructure"));
                .AsImplementedInterfaces();
            return _containerBuilder.Build();
        }
    }
}