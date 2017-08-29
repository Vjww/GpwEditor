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
        private const int ChassisHandlingRecordCount = 11;

        public IRepository<CarNumberEntity> CarNumberRepository { get; set; }
        public IRepository<ChassisHandlingEntity> ChassisHandlingRepository { get; set; }

        public override void Import(BaseGameDataSource dataSource)
        {
            // Import repository data from datasource
            CarNumberRepository = ImportRepositoryFromDataSource<BaseGameDataSource, CarNumberEntity, CarNumberMapper, CarNumberPopulator>(dataSource, CarNumberRecordCount);
            ChassisHandlingRepository = ImportRepositoryFromDataSource<BaseGameDataSource, ChassisHandlingEntity, ChassisHandlingMapper, ChassisHandlingPopulator>(dataSource, ChassisHandlingRecordCount);
        }

        public override void Export(BaseGameDataSource dataSource)
        {
            // Export repository data to datasource
            ExportDataSourceFromRepository<BaseGameDataSource, CarNumberEntity, CarNumberMapper, CarNumberPopulator>(dataSource, CarNumberRepository, CarNumberRecordCount);
            ExportDataSourceFromRepository<BaseGameDataSource, ChassisHandlingEntity, ChassisHandlingMapper, ChassisHandlingPopulator>(dataSource, ChassisHandlingRepository, ChassisHandlingRecordCount);
        }
    }
}