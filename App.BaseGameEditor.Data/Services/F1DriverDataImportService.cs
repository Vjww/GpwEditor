using System;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class F1DriverDataImportService
    {
        private const int ItemCount = 33;

        private readonly IRepository<F1DriverDataEntity> _repository;
        private readonly F1DriverRepositoryImporter _service;

        public F1DriverDataImportService(
            IRepository<F1DriverDataEntity> repository,
            F1DriverRepositoryImporter service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Import()
        {
            var items = _service.Import(ItemCount);
            _repository.Set(items.Cast<F1DriverDataEntity>().ToList()); // TODO: Remove cast once unnecessary
        }
    }
}