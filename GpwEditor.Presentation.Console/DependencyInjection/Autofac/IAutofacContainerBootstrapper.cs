using Autofac;

namespace GpwEditor.Presentation.Console.DependencyInjection.Autofac
{
    public interface IAutofacContainerBootstrapper
    {
        IContainer Register();
    }
}