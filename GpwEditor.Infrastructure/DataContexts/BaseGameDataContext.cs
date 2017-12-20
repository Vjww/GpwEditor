using System;
using System.Collections.Generic;
using Common.Editor.Data.DataContexts;
using Common.Editor.Data.Entities;
using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.Factories.BaseGame;
using GpwEditor.Infrastructure.Repositories.BaseGame;

namespace GpwEditor.Infrastructure.DataContexts
{
    public class BaseGameDataContext : IDataContext
    {
        private readonly IList<IBaseGameRepository<IEntity>> _repositories;
        private readonly IDataContextExporter _dataContextExporter;
        private readonly IDataContextImporter _dataContextImporter;

        public IBaseGameRepository<IEntity> CarNumbers { get; set; }
        public IBaseGameRepository<IEntity> ChassisHandlings { get; set; }
        public IBaseGameRepository<IEntity> Teams { get; set; }

        public BaseGameDataContext(
            IDataContextExporter dataContextExporter,
            IDataContextImporter dataContextImporter,
            IBaseGameRepositoryFactory repositoryFactory)
        {
            _dataContextExporter = dataContextExporter ?? throw new ArgumentNullException(nameof(dataContextExporter));
            _dataContextImporter = dataContextImporter ?? throw new ArgumentNullException(nameof(dataContextImporter));
            if (repositoryFactory == null) throw new ArgumentNullException(nameof(repositoryFactory));

            _repositories = new List<IBaseGameRepository<IEntity>>();

            CarNumbers = repositoryFactory.Create(BaseGameRepositoryEnum.CarNumber);
            ChassisHandlings = repositoryFactory.Create(BaseGameRepositoryEnum.ChassisHandling);
            Teams = repositoryFactory.Create(BaseGameRepositoryEnum.Team);
        }

        public void Export()
        {
            _dataContextExporter.Export((IList<IRepository<IEntity>>)_repositories);
        }

        public void Import()
        {
            _repositories.Clear();

            // Set the capacity of each repository
            CarNumbers.Capacity = 22;
            ChassisHandlings.Capacity = 11;
            Teams.Capacity = 11;

            // Add each repository to the repository collection
            _repositories.Add(CarNumbers);
            _repositories.Add(ChassisHandlings);
            _repositories.Add(Teams);

            _dataContextImporter.Import((IList<IRepository<IEntity>>)_repositories);
        }
    }
}