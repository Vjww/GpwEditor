using System;
using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity GetById(int id);
        void Set(IEnumerable<TEntity> items);
        void SetById(TEntity item);
    }
}