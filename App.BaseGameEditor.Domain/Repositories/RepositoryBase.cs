using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Domain.Models;

namespace App.BaseGameEditor.Domain.Repositories
{
    public class RepositoryBase<TModel> : List<TModel>, IRepository<TModel>
        where TModel : class, IModel
    {
        //private readonly IRepositoryExporter _repositoryExporter;
        //private readonly IRepositoryImporter _repositoryImporter;

        //private bool _isRepositoryCapacityInitialised;
        //private int _repositoryCapacity;

        //public int RepositoryCapacity
        //{
        //    get => _repositoryCapacity;
        //    set => SetRepositoryCapacity(value);
        //}

        //protected RepositoryBase(
        //    IRepositoryExporter repositoryExporter,
        //    IRepositoryImporter repositoryImporter)
        //{
        //    _repositoryExporter = repositoryExporter ?? throw new ArgumentNullException(nameof(repositoryExporter));
        //    _repositoryImporter = repositoryImporter ?? throw new ArgumentNullException(nameof(repositoryImporter));
        //}

        //public void Export()
        //{
        //    _repositoryExporter.Export(Get());
        //}

        public TModel GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return this.Single(x => x.Id == id);
        }

        public IEnumerable<TModel> Get()
        {
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return this.ToList();
        }

        public IEnumerable<TModel> Get(Func<TModel, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return this.Where(predicate).AsEnumerable();
        }

        //public void Import()
        //{
        //    var entities = _repositoryImporter.Import(RepositoryCapacity);
        //    Set(entities);
        //}

        public void SetById(TModel item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            for (var i = 0; i < Count; i++)
            {
                if (this[i].Id == item.Id)
                {
                    this[i] = item;
                }
            }
        }

        public void Set(IEnumerable<TModel> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            //if (!_isRepositoryCapacityInitialised) throw new InvalidOperationException($"The {nameof(RepositoryCapacity)} property must first be initialised.");

            //var enumerable = entities as IEntity[] ?? entities.OrderBy(x => x.Id).ToArray();
            //if (enumerable.Count() != RepositoryCapacity) throw new ArgumentOutOfRangeException(nameof(entities));

            Clear();
            //AddRange(enumerable);
            AddRange(entities);
        }

        //private void SetRepositoryCapacity(int repositoryCapacity)
        //{
        //    if (repositoryCapacity <= 0) throw new ArgumentOutOfRangeException(nameof(repositoryCapacity));
        //    if (_isRepositoryCapacityInitialised) throw new InvalidOperationException($"The {nameof(RepositoryCapacity)} property cannot be changed after it has been initialised.");

        //    _repositoryCapacity = repositoryCapacity;
        //    _isRepositoryCapacityInitialised = true;
        //}
    }
}