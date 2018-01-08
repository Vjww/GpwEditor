using Autofac;

namespace App.DependencyInjection.Autofac
{
    public interface IAutofacContainerBootstrapper
    {
        IContainer Register();
    }
}