using System;
using System.Collections.Generic;
using App.Core.Identities;

namespace App.Core.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class, IIntegerIdentity
    {
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity GetById(int id);
        void Set(IEnumerable<TEntity> items);
        void SetById(TEntity item);
    }
}