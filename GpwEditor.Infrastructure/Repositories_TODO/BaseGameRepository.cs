using Common.Editor.Infrastructure;
using Common.Editor.Infrastructure.DataSets;
using Common.Editor.Infrastructure.Repositories;

namespace GpwEditor.Infrastructure.Repositories
{
    public class BaseGameRepository : RepositoryBase
    {
        private readonly IDataSet _carNumberDataSet;
        private readonly IDataSet _chassisHandlingDataSet;
        private readonly IDataSet _teamDataSet;

        // TODO: review for removal
        //private const int CarNumberRecordCount = 22;
        //private const int ChassisHandlingRecordCount = 11;
        //private const int TeamRecordCount = 11;

        public BaseGameRepository(
            IDataSet carNumberDataSet,
            IDataSet chassisHandlingDataSet,
            IDataSet teamDataSet
            )
        {
            _carNumberDataSet = carNumberDataSet;
            _chassisHandlingDataSet = chassisHandlingDataSet;
            _teamDataSet = teamDataSet;

            // TODO: review for expansion
            //_carNumberDataSet.Size = 22;
            //_chassisHandlingDataSet.Size = 11;
            //_teamDataSet.Size = 11;
        }

        // TODO: review below for removal
        //public override void Import(BaseGameDataContext dataSource)
        //{
        //    if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));

        //    CarNumberRepository = ImportRepositoryFromDataSource<BaseGameDataContext, CarNumberEntity, CarNumberLocator, CarNumberPopulator>(dataSource, CarNumberRecordCount);
        //    ChassisHandlingRepository = ImportRepositoryFromDataSource<BaseGameDataContext, ChassisHandlingEntity, ChassisHandlingLocator, ChassisHandlingPopulator>(dataSource, ChassisHandlingRecordCount);
        //    TeamRepository = ImportRepositoryFromDataSource<BaseGameDataContext, TeamEntity, TeamLocator, TeamPopulator>(dataSource, TeamRecordCount);
        //}

        // TODO: review below for removal
        //public override void Export(BaseGameDataContext dataSource)
        //{
        //    if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));

        //    ExportDataSourceFromRepository<BaseGameDataContext, ChassisHandlingEntity, ChassisHandlingLocator, ChassisHandlingPopulator>(dataSource, ChassisHandlingRepository, ChassisHandlingRecordCount);
        //    ExportDataSourceFromRepository<BaseGameDataContext, CarNumberEntity, CarNumberLocator, CarNumberPopulator>(dataSource, CarNumberRepository, CarNumberRecordCount);
        //    ExportDataSourceFromRepository<BaseGameDataContext, TeamEntity, TeamLocator, TeamPopulator>(dataSource, TeamRepository, TeamRecordCount);
        //}
    }
}