using System;
using Common.Editor.Data.DataContexts;
using GpwEditor.Infrastructure.Enums;
using GpwEditor.Infrastructure.Factories.Repositories;
using GpwEditor.Infrastructure.Repositories.BaseGame;

namespace GpwEditor.Infrastructure.DataContexts
{
    public class BaseGameDataContext : IDataContext
    {
        public IBaseGameRepository CarNumbers { get; set; }
        public IBaseGameRepository ChassisHandlings { get; set; }
        public IBaseGameRepository Teams { get; set; }

        public BaseGameDataContext(IBaseGameRepositoryFactory repositoryFactory)
        {
            if (repositoryFactory == null) throw new ArgumentNullException(nameof(repositoryFactory));

            CarNumbers = repositoryFactory.Create(BaseGameRepositoryType.CarNumber);
            ChassisHandlings = repositoryFactory.Create(BaseGameRepositoryType.ChassisHandling);
            Teams = repositoryFactory.Create(BaseGameRepositoryType.Team);
        }

        public void Export()
        {
            CarNumbers.Export();
            ChassisHandlings.Export();
            Teams.Export();
        }

        public void Import()
        {
            CarNumbers.Import();
            ChassisHandlings.Import();
            Teams.Import();
        }
    }
}