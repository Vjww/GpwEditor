using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class F1ChiefMechanicDataExportService
    {
        private readonly IRepository<F1ChiefMechanicDataEntity> _repository;
        private readonly F1ChiefMechanicRepositoryExporter _service;

        public F1ChiefMechanicDataExportService(
            IRepository<F1ChiefMechanicDataEntity> repository,
            F1ChiefMechanicRepositoryExporter service)
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