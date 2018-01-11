using System;
using System.Linq;
using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Data.Repositories;
using App.BaseGameEditor.Data.RepositoryImporters;

namespace App.BaseGameEditor.Data.Services
{
    public class ChassisHandlingDataImportService
    {
        private const int ItemCount = 11;

        private readonly ChassisHandlingRepository _repository;
        private readonly ChassisHandlingRepositoryImporter _service;

        public ChassisHandlingDataImportService(
            ChassisHandlingRepository repository,
            ChassisHandlingRepositoryImporter service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Import()
        {
            var items = _service.Import(ItemCount);
            _repository.Set(items.Cast<ChassisHandlingEntity>().ToList()); // TODO: Remove cast once unnecessary
        }
    }
}