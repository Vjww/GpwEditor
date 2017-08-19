using System;
using System.Collections.Generic;
using ConsoleApplication.Entities;

namespace ConsoleApplication.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        T GetById(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        void Set(T item);
        void Set(IEnumerable<T> collection);
    }
}