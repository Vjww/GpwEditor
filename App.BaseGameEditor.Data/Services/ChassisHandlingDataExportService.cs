using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class ChassisHandlingDataExportService
    {
        private readonly IRepository<ChassisHandlingDataEntity> _repository;
        private readonly ChassisHandlingRepositoryExporter _service;

        public ChassisHandlingDataExportService(
            IRepository<ChassisHandlingDataEntity> repository,
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