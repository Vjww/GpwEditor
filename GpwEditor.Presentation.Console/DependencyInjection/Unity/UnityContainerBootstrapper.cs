using System.Linq;
using Unity;
using Unity.RegistrationByConvention;

namespace GpwEditor.Presentation.Console.DependencyInjection.Unity
{
    public class UnityContainerBootstrapper : IUnityContainerBootstrapper
    {
        private readonly IUnityContainer _container;

        public UnityContainerBootstrapper(IUnityContainer container)
        {
            _container = container;
        }

        public IUnityContainer Register()
        {
            return _container.RegisterTypes(
                AllClasses.FromLoadedAssemblies().Where(x =>
                    x.Namespace != null &&
                    x.Namespace.StartsWith("GpwEditor.Presentation.Console") &&
                    !x.Namespace.StartsWith("GpwEditor.Presentation.Console.DependencyInjection")),// &&
                    //x.Namespace.StartsWith("GpwEditor.Application") &&
                    //x.Namespace.StartsWith("GpwEditor.Domain") &&
                    //x.Namespace.StartsWith("GpwEditor.Infrastructure")),
                WithMappings.FromMatchingInterface,
                WithName.TypeName,
                WithLifetime.ContainerControlled);
        }
    }
}