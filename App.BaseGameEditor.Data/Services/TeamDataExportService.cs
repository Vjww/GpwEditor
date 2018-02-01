using System;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class TeamDataExportService
    {
        private readonly TeamRepository _repository;
        private readonly TeamRepositoryExporter _service;

        public TeamDataExportService(
            TeamRepository repository,
            TeamRepositoryExporter service)
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