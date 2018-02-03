using System;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class F1ChiefCommercialDataImportService
    {
        private const int ItemCount = 11;

        private readonly IRepository<F1ChiefCommercialDataEntity> _repository;
        private readonly F1ChiefCommercialRepositoryImporter _service;

        public F1ChiefCommercialDataImportService(
            IRepository<F1ChiefCommercialDataEntity> repository,
            F1ChiefCommercialRepositoryImporter service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Import()
        {
            var items = _service.Import(ItemCount);
            _repository.Set(items.Cast<F1ChiefCommercialDataEntity>().ToList()); // TODO: Remove cast once unnecessary
        }
    }
}