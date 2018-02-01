using System;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class F1DriverDataExportService
    {
        private readonly F1DriverRepository _repository;
        private readonly F1DriverRepositoryExporter _service;

        public F1DriverDataExportService(
            F1DriverRepository repository,
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