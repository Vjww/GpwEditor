using System;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class F1ChiefDesignerDataImportService
    {
        private const int ItemCount = 11;

        private readonly IRepository<F1ChiefDesignerDataEntity> _repository;
        private readonly F1ChiefDesignerRepositoryImporter _service;

        public F1ChiefDesignerDataImportService(
            IRepository<F1ChiefDesignerDataEntity> repository,
            F1ChiefDesignerRepositoryImporter service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Import()
        {
            var items = _service.Import(ItemCount);
            _repository.Set(items.Cast<F1ChiefDesignerDataEntity>().ToList()); // TODO: Remove cast once unnecessary
        }
    }
}