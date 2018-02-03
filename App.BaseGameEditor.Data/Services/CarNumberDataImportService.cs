using System;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class CarNumberDataImportService
    {
        private const int ItemCount = 22;

        private readonly IRepository<CarNumberDataEntity> _repository;
        private readonly CarNumberRepositoryImporter _service;

        public CarNumberDataImportService(
            IRepository<CarNumberDataEntity> repository,
            CarNumberRepositoryImporter service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Import()
        {
            var items = _service.Import(ItemCount);
            _repository.Set(items.Cast<CarNumberDataEntity>().ToList()); // TODO: Remove cast once unnecessary
        }
    }
}