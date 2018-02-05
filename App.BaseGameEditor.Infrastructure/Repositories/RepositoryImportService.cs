using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.Services;
using App.Core.Entities;
using App.Core.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories
{
    public class RepositoryImportService<TEntity> : IRepositoryImportService<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IDataEntityImportService<TEntity> _service;

        public RepositoryImportService(
            IRepository<TEntity> repository,
            IDataEntityImportService<TEntity> service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Import(int itemCount)
        {
            if (itemCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(itemCount));
            }

            var items = new List<TEntity>();
            for (var i = 0; i < itemCount; i++)
            {
                var entity = _service.Import(i);
                items.Add(entity);
            }

            _repository.Set(items);
        }
    }
}