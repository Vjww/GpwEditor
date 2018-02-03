using System;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class ChassisHandlingDataImportService
    {
        private const int ItemCount = 11;

        private readonly IRepository<ChassisHandlingDataEntity> _repository;
        private readonly ChassisHandlingRepositoryImporter _service;

        public ChassisHandlingDataImportService(
            IRepository<ChassisHandlingDataEntity> repository,
            ChassisHandlingRepositoryImporter service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Import()
        {
            var items = _service.Import(ItemCount);
            _repository.Set(items.Cast<ChassisHandlingDataEntity>().ToList()); // TODO: Remove cast once unnecessary
        }
    }
}