using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Services;
using App.Core.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories
{
    public class RepositoryImportService<TDataEntity> : IRepositoryImportService<TDataEntity>
        where TDataEntity : class, IDataEntity
    {
        private readonly IRepository<TDataEntity> _repository;
        private readonly IDataEntityImportService<TDataEntity> _service;

        public RepositoryImportService(
            IRepository<TDataEntity> repository,
            IDataEntityImportService<TDataEntity> service)
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

            var items = new List<TDataEntity>();
            for (var i = 0; i < itemCount; i++)
            {
                var entity = _service.Import(i);
                items.Add(entity);
            }

            _repository.Set(items);
        }
    }
}