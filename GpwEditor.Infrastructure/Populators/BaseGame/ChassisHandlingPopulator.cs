using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.DataSources;
using GpwEditor.Infrastructure.Entities.BaseGame;
using GpwEditor.Infrastructure.Mappers.BaseGame;

namespace GpwEditor.Infrastructure.Populators.BaseGame
{
    public class ChassisHandlingPopulator : PopulatorBase<BaseGameDataSource, BaseGameConnectionStrings, ChassisHandlingEntity, ChassisHandlingMapper>
    {
        public override void ImportEntityFromDataSource(BaseGameDataSource dataSource, ChassisHandlingEntity entity, ChassisHandlingMapper mapper)
        {
            entity.TeamId = entity.Id;
            entity.Value = ReadIntegerFromMemoryStream(dataSource.GameExecutable, mapper.Value);
        }

        public override void ExportEntityToDataSource(BaseGameDataSource dataSource, ChassisHandlingEntity entity, ChassisHandlingMapper mapper)
        {
            WriteIntegerToMemoryStream(dataSource.GameExecutable, mapper.Value, entity.Value);
        }
    }
}