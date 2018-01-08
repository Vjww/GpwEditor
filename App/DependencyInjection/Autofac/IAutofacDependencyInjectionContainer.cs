using System;

namespace App.DependencyInjection.Autofac
{
    public interface IAutofacDependencyInjectionContainer : IDisposable
    {
        void DisplayContainerName();
        void DisplayRegistrations();
        T GetInstance<T>();
        void PerformRegistrations();
    }
}