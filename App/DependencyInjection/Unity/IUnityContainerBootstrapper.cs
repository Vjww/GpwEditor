using Unity;

namespace App.DependencyInjection.Unity
{
    public interface IUnityContainerBootstrapper
    {
        IUnityContainer Register();
    }
}