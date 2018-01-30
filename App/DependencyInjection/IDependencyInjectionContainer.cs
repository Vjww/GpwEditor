using System;

namespace App.DependencyInjection
{
    public interface IDependencyInjectionContainer : IDisposable
    {
        void BuildContainer();
        void ListRegistrations();
        T Resolve<T>();
    }
}