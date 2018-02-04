using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Services;
using App.Core.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories
{
    public class RepositoryExportService<TDataEntity> : IRepositoryExportService<TDataEntity>
        where TDataEntity : class, IDataEntity
    {
        private readonly IRepository<TDataEntity> _repository;
        private readonly IDataEntityExportService<TDataEntity> _service;

        public RepositoryExportService(
            IRepository<TDataEntity> repository,
            IDataEntityExportService<TDataEntity> service)
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