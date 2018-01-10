using System;
using System.Collections.Generic;
using System.Linq;
using Common.Editor.Domain.Models;

namespace Common.Editor.Domain.Repositories
{
    public class RepositoryBase<TModel> : List<TModel>, IRepository<TModel>
        where TModel : class, IModel
    {
        public IEnumerable<TModel> Get()
        {
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return this.AsEnumerable();
        }

        public IEnumerable<TModel> Get(Func<TModel, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return this.Where(predicate).AsEnumerable();
        }

        public TModel GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return this.Single(x => x.Id == id);
        }

        public void Set(IEnumerable<TModel> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            Clear();
            AddRange(items);
            TrimExcess();
        }

        public void SetById(TModel item)
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