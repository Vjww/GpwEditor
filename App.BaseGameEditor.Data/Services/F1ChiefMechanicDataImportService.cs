using System;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class F1ChiefMechanicDataImportService
    {
        private const int ItemCount = 11;

        private readonly IRepository<F1ChiefMechanicDataEntity> _repository;
        private readonly F1ChiefMechanicRepositoryImporter _service;

        public F1ChiefMechanicDataImportService(
            IRepository<F1ChiefMechanicDataEntity> repository,
            F1ChiefMechanicRepositoryImporter service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Import()
        {
            var items = _service.Import(ItemCount);
            _repository.Set(items.Cast<F1ChiefMechanicDataEntity>().ToList()); // TODO: Remove cast once unnecessary
        }
    }
}