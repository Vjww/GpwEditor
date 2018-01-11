using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Entities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class RepositoryBase<TEntity> : List<TEntity>, IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected RepositoryBase()
        {

        }

        public IEnumerable<TEntity> Get()
        {
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return this.AsEnumerable();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return this.Where(predicate).AsEnumerable();
        }

        public TEntity GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return this.Single(x => x.Id == id);
        }

        public void Set(IEnumerable<TEntity> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            Clear();
            AddRange(items);
            TrimExcess();
        }

        public void SetById(TEntity item)
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