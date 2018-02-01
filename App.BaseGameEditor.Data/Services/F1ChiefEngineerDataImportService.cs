using System;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class F1ChiefEngineerDataImportService
    {
        private const int ItemCount = 11;

        private readonly F1ChiefEngineerRepository _repository;
        private readonly F1ChiefEngineerRepositoryImporter _service;

        public F1ChiefEngineerDataImportService(
            F1ChiefEngineerRepository repository,
            F1ChiefEngineerRepositoryImporter service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Import()
        {
            var items = _service.Import(ItemCount);
            _repository.Set(items.Cast<F1ChiefEngineerDataEntity>().ToList()); // TODO: Remove cast once unnecessary
        }
    }
}