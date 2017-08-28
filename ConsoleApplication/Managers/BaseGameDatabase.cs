using ConsoleApplication.DataSources;
using ConsoleApplication.Entities.BaseGame;
using ConsoleApplication.Infrastructure;
using ConsoleApplication.Mappers.BaseGame;
using ConsoleApplication.Populators.BaseGame;
using ConsoleApplication.Repositories;

namespace ConsoleApplication.Managers
{
    public class BaseGameDatabase : DatabaseBase<BaseGameDataSource, BaseGameConnectionStrings>
    {
        private const int CarNumberRecordCount = 22;

        public IRepository<CarNumberEntity> CarNumberRepository { get; set; }

        public override void Import(BaseGameDataSource dataSource)
        {
            // Import repository data from datasource
            CarNumberRepository = ImportRepositoryFromDataSource<BaseGameDataSource, CarNumberEntity, CarNumberMapper, CarNumberPopulator>(dataSource, CarNumberRecordCount);
        }

        public override void Export(BaseGameDataSource dataSource)
        {
            // Export repository data to datasource
            ExportDataSourceFromRepository<BaseGameDataSource, CarNumberEntity, CarNumberMapper, CarNumberPopulator>(dataSource, CarNumberRepository, CarNumberRecordCount);
        }
    }
}