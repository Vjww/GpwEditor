using System;
using App.Core.Entities;
using App.Core.Repositories;
using App.Shared.Data.Services;

namespace App.Shared.Infrastructure.Repositories
{
    public class RepositoryExportService<TEntity> : IRepositoryExportService<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IDataEntityExportService<TEntity> _service;

        public RepositoryExportService(
            IRepository<TEntity> repository,
            IDataEntityExportService<TEntity> service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Export()
        {
            var items = _repository.Get();
            foreach (var item in items)
            {
                _service.Export(item);
            }
        }
    }
}