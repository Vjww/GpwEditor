using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ConsoleApplication.Entities;

namespace ConsoleApplication.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly Collection<T> _collection;

        public Repository(Collection<T> collection)
        {
            _collection = collection;
        }

        public T GetById(int id)
        {
            return _collection.Single(x => x.Id == id);
        }

        public IEnumerable<T> Get()
        {
            return _collection;
        }

        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return _collection.Where(predicate).AsEnumerable();
        }

        public void Set(T item)
        {
            for (var i = 0; i < _collection.Count; i++)
            {
                if (_collection[i].Id == item.Id)
                {
                    _collection[i] = item;
                }
            }
        }

        public void Set(IEnumerable<T> collection)
        {
            var array = collection as T[] ?? collection.OrderBy(x => x.Id).ToArray();

            if (_collection.Count != array.Length)
            {
                throw new Exception("The number of items in the source collection does not match the number of items in the destination collection.");
            }

            for (var i = 0; i < _collection.Count; i++)
            {
                _collection[i] = array[i];
            }
        }
    }
}