using ConsoleApplication.DataSources;
using ConsoleApplication.Entities.BaseGame;
using ConsoleApplication.Infrastructure;
using ConsoleApplication.Mappers.BaseGame;

namespace ConsoleApplication.Populators.BaseGame
{
    public class ChassisHandlingPopulator : PopulatorBase<BaseGameDataSource, BaseGameConnectionStrings, ChassisHandlingEntity, ChassisHandlingMapper>
    {
        public override void ImportEntityFromDataSource(BaseGameDataSource dataSource, ChassisHandlingEntity entity, ChassisHandlingMapper mapper)
        {
            entity.Value = ReadIntegerFromMemoryStream(dataSource.GameExecutable, mapper.Value);
        }

        public override void ExportEntityToDataSource(BaseGameDataSource dataSource, ChassisHandlingEntity entity, ChassisHandlingMapper mapper)
        {
            WriteIntegerToMemoryStream(dataSource.GameExecutable, mapper.Value, entity.Value);
        }
    }
}