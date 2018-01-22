using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public interface IRepository<TDataEntity>
        where TDataEntity : class, IDataEntity
    {
        IEnumerable<TDataEntity> Get();
        IEnumerable<TDataEntity> Get(Func<TDataEntity, bool> predicate);
        TDataEntity GetById(int id);
        void Set(IEnumerable<TDataEntity> items);
        void SetById(TDataEntity item);
    }
}