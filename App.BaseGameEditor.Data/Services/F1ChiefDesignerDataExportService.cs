using System;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class F1ChiefDesignerDataExportService
    {
        private readonly F1ChiefDesignerRepository _repository;
        private readonly F1ChiefDesignerRepositoryExporter _service;

        public F1ChiefDesignerDataExportService(
            F1ChiefDesignerRepository repository,
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