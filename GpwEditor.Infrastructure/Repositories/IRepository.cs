using System;
using System.Collections.Generic;
using GpwEditor.Infrastructure.Entities;

namespace GpwEditor.Infrastructure.Repositories
{
    public interface IRepository<T>
        where T : class, IEntity
    {
        T GetById(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        void SetById(T item);
        void Set(IEnumerable<T> list);
    }
}