using Unity;

namespace GpwEditor.Presentation.Console.DependencyInjection.Unity
{
    public interface IUnityContainerBootstrapper
    {
        IUnityContainer Register();
    }
}