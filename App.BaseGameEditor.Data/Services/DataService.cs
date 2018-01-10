using System;
using App.BaseGameEditor.Data.Enums;
using App.BaseGameEditor.Data.Factories.Repositories;
using App.BaseGameEditor.Data.Repositories;

namespace App.BaseGameEditor.Data.Services
{
    public class DataService : IDataService
    {
        public IBaseGameRepository CarNumbers { get; set; }
        public IBaseGameRepository ChassisHandlings { get; set; }
        public IBaseGameRepository Teams { get; set; }

        public DataService(IBaseGameRepositoryFactory repositoryFactory)
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