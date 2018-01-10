using System;

namespace App.DependencyInjection
{
    public interface IDependencyInjectionContainer : IDisposable
    {
        void DisplayContainerName();
        void DisplayRegistrations();
        T GetInstance<T>();
        void PerformRegistrations();
    }
}