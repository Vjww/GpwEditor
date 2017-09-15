using System;
using System.Collections.Generic;
using System.Linq;
using GpwEditor.Infrastructure.Entities;

namespace GpwEditor.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class, IEntity
    {
        private readonly List<T> _list;

        public Repository(List<T> list)
        {
            _list = list;
        }

        public T GetById(int id)
        {
            return _list.Single(x => x.Id == id);
        }

        public IEnumerable<T> Get()
        {
            return _list;
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _list.Where(predicate).AsEnumerable();
        }

        public void SetById(T item)
        {
            for (var i = 0; i < _list.Count; i++)
            {
                if (_list[i].Id == item.Id)
                {
                    _list[i] = item;
                }
            }
        }

        public void Set(IEnumerable<T> list)
        {
            var array = list as T[] ?? list.OrderBy(x => x.Id).ToArray();

            if (_list.Count != array.Length)
            {
                throw new Exception("The number of items in the source list does not match the number of items in the destination list.");
            }

            for (var i = 0; i < _list.Count; i++)
            {
                _list[i] = array[i];
            }
        }
    }
}