using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.DataSources;
using GpwEditor.Infrastructure.Entities.BaseGame;
using GpwEditor.Infrastructure.ValueMappers.BaseGame;

namespace GpwEditor.Infrastructure.Populators.BaseGame
{
    public class ChassisHandlingPopulator : PopulatorBase<BaseGameDataSource, BaseGameConnectionStrings, ChassisHandlingEntity, ChassisHandlingValueMapper>
    {
        public override void ImportEntityFromDataSource(BaseGameDataSource dataSource, ChassisHandlingEntity entity, ChassisHandlingValueMapper valueMapper)
        {
            entity.TeamId = entity.Id;
            entity.Value = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.Value);
        }

        public override void ExportEntityToDataSource(BaseGameDataSource dataSource, ChassisHandlingEntity entity, ChassisHandlingValueMapper valueMapper)
        {
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.Value, entity.Value);
        }
    }
}