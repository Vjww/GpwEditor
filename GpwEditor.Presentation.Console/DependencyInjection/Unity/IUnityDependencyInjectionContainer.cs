using System;

namespace GpwEditor.Presentation.Console.DependencyInjection.Unity
{
    public interface IUnityDependencyInjectionContainer : IDisposable
    {
        void DisplayContainerName();
        void DisplayRegistrations();
        T GetInstance<T>();
        void PerformRegistrations();
    }
}