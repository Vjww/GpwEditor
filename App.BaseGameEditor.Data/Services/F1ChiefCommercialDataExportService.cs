using System;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class F1ChiefCommercialDataExportService
    {
        private readonly F1ChiefCommercialRepository _repository;
        private readonly F1ChiefCommercialRepositoryExporter _service;

        public F1ChiefCommercialDataExportService(
            F1ChiefCommercialRepository repository,
            F1ChiefCommercialRepositoryExporter service)
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