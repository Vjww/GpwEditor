using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Entities;
using App.Core.Repositories;

namespace App.Shared.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly List<TEntity> _list;

        protected RepositoryBase(List<TEntity> list)
        {
            _list = list;
        }

        public IEnumerable<TEntity> Get()
        {
            if (_list.Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return _list.AsEnumerable();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (_list.Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return _list.Where(predicate).AsEnumerable();
        }

        public TEntity GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (_list.Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return _list.Single(x => x.Id == id);
        }

        public void Set(IEnumerable<TEntity> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            _list.Clear();
            _list.AddRange(items);
            _list.TrimExcess();
        }

        public void SetById(TEntity item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (_list.Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            var index = _list.FindIndex(x => x.Id == item.Id);
            if (index < 0)
            {
                throw new KeyNotFoundException();
            }
            _list[index] = item;
        }
    }
}