using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class F1DriverDataExportService
    {
        private readonly IRepository<F1DriverDataEntity> _repository;
        private readonly F1DriverRepositoryExporter _service;

        public F1DriverDataExportService(
            IRepository<F1DriverDataEntity> repository,
            F1DriverRepositoryExporter service)
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