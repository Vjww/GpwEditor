using System;
using App.BaseGameEditor.Data.Repositories;
using App.BaseGameEditor.Data.RepositoryExporters;

namespace App.BaseGameEditor.Data.Services
{
    public class ChassisHandlingDataExportService
    {
        private readonly ChassisHandlingRepository _repository;
        private readonly ChassisHandlingRepositoryExporter _service;

        public ChassisHandlingDataExportService(
            ChassisHandlingRepository repository,
            ChassisHandlingRepositoryExporter service)
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