using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class RepositoryBase<TDataEntity> : List<TDataEntity>, IRepository<TDataEntity>
        where TDataEntity : class, IDataEntity
    {
        protected RepositoryBase()
        {

        }

        public IEnumerable<TDataEntity> Get()
        {
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return this.AsEnumerable();
        }

        public IEnumerable<TDataEntity> Get(Func<TDataEntity, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return this.Where(predicate).AsEnumerable();
        }

        public TDataEntity GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return this.Single(x => x.Id == id);
        }

        public void Set(IEnumerable<TDataEntity> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            Clear();
            AddRange(items);
            TrimExcess();
        }

        public void SetById(TDataEntity item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            var index = FindIndex(x => x.Id == item.Id);
            if (index < 0)
            {
                throw new KeyNotFoundException();
            }
            this[index] = item;
        }
    }
}