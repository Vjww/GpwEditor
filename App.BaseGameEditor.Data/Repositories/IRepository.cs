using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.Entities;

namespace App.BaseGameEditor.Data.Repositories
{
    public interface IRepository
    {
        int RepositoryCapacity { get; set; }
        void Export();
        IEntity GetById(int id);
        IEnumerable<IEntity> Get();
        IEnumerable<IEntity> Get(Func<IEntity, bool> predicate);
        void Import();
        void SetById(IEntity item);
        void Set(IEnumerable<IEntity> entities);
    }
}