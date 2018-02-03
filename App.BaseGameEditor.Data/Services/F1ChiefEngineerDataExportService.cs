using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class F1ChiefEngineerDataExportService
    {
        private readonly IRepository<F1ChiefEngineerDataEntity> _repository;
        private readonly F1ChiefEngineerRepositoryExporter _service;

        public F1ChiefEngineerDataExportService(
            IRepository<F1ChiefEngineerDataEntity> repository,
            F1ChiefEngineerRepositoryExporter service)
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