using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.DataSources;
using GpwEditor.Infrastructure.Entities.BaseGame;
using GpwEditor.Infrastructure.Populators.BaseGame;
using GpwEditor.Infrastructure.Repositories;
using GpwEditor.Infrastructure.ValueMappers.BaseGame;

namespace GpwEditor.Infrastructure.Databases
{
    public class BaseGameDatabase : DatabaseBase<BaseGameDataSource, BaseGameConnectionStrings>
    {
        public const int CarNumberRecordCount = 22;
        public const int ChassisHandlingRecordCount = 11;
        public const int TeamRecordCount = 11;

        public IRepository<CarNumberEntity> CarNumberRepository { get; set; }
        public IRepository<ChassisHandlingEntity> ChassisHandlingRepository { get; set; }
        public IRepository<TeamEntity> TeamRepository { get; set; }

        public override void Import(BaseGameDataSource dataSource)
        {
            // Import repository data from datasource
            CarNumberRepository = ImportRepositoryFromDataSource<BaseGameDataSource, CarNumberEntity, CarNumberValueMapper, CarNumberPopulator>(dataSource, CarNumberRecordCount);
            ChassisHandlingRepository = ImportRepositoryFromDataSource<BaseGameDataSource, ChassisHandlingEntity, ChassisHandlingValueMapper, ChassisHandlingPopulator>(dataSource, ChassisHandlingRecordCount);
            TeamRepository = ImportRepositoryFromDataSource<BaseGameDataSource, TeamEntity, TeamValueMapper, TeamPopulator>(dataSource, TeamRecordCount);
        }

        public override void Export(BaseGameDataSource dataSource)
        {
            // Export repository data to datasource
            ExportDataSourceFromRepository<BaseGameDataSource, ChassisHandlingEntity, ChassisHandlingValueMapper, ChassisHandlingPopulator>(dataSource, ChassisHandlingRepository, ChassisHandlingRecordCount);
            ExportDataSourceFromRepository<BaseGameDataSource, CarNumberEntity, CarNumberValueMapper, CarNumberPopulator>(dataSource, CarNumberRepository, CarNumberRecordCount);
            ExportDataSourceFromRepository<BaseGameDataSource, TeamEntity, TeamValueMapper, TeamPopulator>(dataSource, TeamRepository, TeamRecordCount);
        }
    }
}