using System;

namespace GpwEditor.Presentation.Console.DependencyInjection.Autofac
{
    public interface IAutofacDependencyInjectionContainer : IDisposable
    {
        void DisplayContainerName();
        void DisplayRegistrations();
        T GetApplicationInstance<T>();
        void PerformRegistrations();
    }
}