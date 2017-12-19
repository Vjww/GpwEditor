using System;
using System.Collections.Generic;
using Common.Editor.Data.DataContexts;
using Common.Editor.Data.Entities;
using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Infrastructure.DataContexts
{
    public class BaseGameDataContext : IDataContext
    {
        private readonly IList<IRepository<IEntity>> _repositories;
        private readonly IDataContextExporter _dataContextExporter;
        private readonly IDataContextImporter _dataContextImporter;

        public IRepository<CarNumberEntity> CarNumbers { get; set; }
        public IRepository<ChassisHandlingEntity> ChassisHandlings { get; set; }
        public IRepository<TeamEntity> Teams { get; set; }

        public BaseGameDataContext(
            IDataContextExporter dataContextExporter,
            IDataContextImporter dataContextImporter,
            IRepository<CarNumberEntity> carNumbers,
            IRepository<ChassisHandlingEntity> chassisHandlings,
            IRepository<TeamEntity> teams)
        {
            _repositories = new List<IRepository<IEntity>>();
            _dataContextExporter = dataContextExporter ?? throw new ArgumentNullException(nameof(dataContextExporter));
            _dataContextImporter = dataContextImporter ?? throw new ArgumentNullException(nameof(dataContextImporter));
            CarNumbers = carNumbers ?? throw new ArgumentNullException(nameof(carNumbers));
            ChassisHandlings = chassisHandlings ?? throw new ArgumentNullException(nameof(chassisHandlings));
            Teams = teams ?? throw new ArgumentNullException(nameof(teams));
        }

        public void Export()
        {
            _dataContextExporter.Export(_repositories);
        }

        public void Import()
        {
            _repositories.Clear();

            // Set the capacity of each repository
            CarNumbers.Capacity = 22;
            ChassisHandlings.Capacity = 11;
            Teams.Capacity = 11;

            // Add each repository to the repository collection
            _repositories.Add((IRepository<IEntity>)CarNumbers);
            _repositories.Add((IRepository<IEntity>)ChassisHandlings);
            _repositories.Add((IRepository<IEntity>)Teams);

            _dataContextImporter.Import(_repositories);
        }
    }
}