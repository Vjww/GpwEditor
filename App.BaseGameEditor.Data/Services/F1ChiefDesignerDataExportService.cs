using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class F1ChiefDesignerDataExportService
    {
        private readonly IRepository<F1ChiefDesignerDataEntity> _repository;
        private readonly F1ChiefDesignerRepositoryExporter _service;

        public F1ChiefDesignerDataExportService(
            IRepository<F1ChiefDesignerDataEntity> repository,
            F1ChiefDesignerRepositoryExporter service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Export()
        {
            _service.Export(_repository.Get());
        }
    }
}