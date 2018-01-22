using System;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;
using App.BaseGameEditor.Data.RepositoryImporters;

namespace App.BaseGameEditor.Data.Services
{
    public class TeamDataImportService
    {
        private const int ItemCount = 11;

        private readonly TeamRepository _repository;
        private readonly TeamRepositoryImporter _service;

        public TeamDataImportService(
            TeamRepository repository,
            TeamRepositoryImporter service)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public void Import()
        {
            var items = _service.Import(ItemCount);
            _repository.Set(items.Cast<TeamDataEntity>().ToList()); // TODO: Remove cast once unnecessary
        }
    }
}