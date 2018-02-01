using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public abstract class RepositoryBase<TDataEntity> : IRepository<TDataEntity>
        where TDataEntity : class, IDataEntity
    {
        private readonly List<TDataEntity> _list;

        protected RepositoryBase(List<TDataEntity> list)
        {
            _list = list;
        }

        public IEnumerable<TDataEntity> Get()
        {
            if (_list.Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return _list.AsEnumerable();
        }

        public IEnumerable<TDataEntity> Get(Func<TDataEntity, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (_list.Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return _list.Where(predicate).AsEnumerable();
        }

        public TDataEntity GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (_list.Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return _list.Single(x => x.Id == id);
        }

        public void Set(IEnumerable<TDataEntity> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            _list.Clear();
            _list.AddRange(items);
            _list.TrimExcess();
        }

        public void SetById(TDataEntity item)
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