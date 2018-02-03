using System;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class TeamDataImportService
    {
        private const int ItemCount = 11;

        private readonly IRepository<TeamDataEntity> _repository;
        private readonly TeamRepositoryImporter _service;

        public TeamDataImportService(
            IRepository<TeamDataEntity> repository,
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