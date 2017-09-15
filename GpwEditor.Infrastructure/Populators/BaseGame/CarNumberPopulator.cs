using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.DataSources;
using GpwEditor.Infrastructure.Entities.BaseGame;
using GpwEditor.Infrastructure.Mappers.BaseGame;

namespace GpwEditor.Infrastructure.Populators.BaseGame
{
    public class CarNumberPopulator : PopulatorBase<BaseGameDataSource, BaseGameConnectionStrings, CarNumberEntity, CarNumberMapper>
    {
        public override void ImportEntityFromDataSource(BaseGameDataSource dataSource, CarNumberEntity entity, CarNumberMapper mapper)
        {
            entity.TeamId = entity.Id / 2;
            entity.PositionId = entity.Id % 2;
            entity.ValueA = ReadIntegerFromMemoryStream(dataSource.GameExecutable, mapper.ValueA);
            entity.ValueB = ReadIntegerFromMemoryStream(dataSource.GameExecutable, mapper.ValueB);
        }

        public override void ExportEntityToDataSource(BaseGameDataSource dataSource, CarNumberEntity entity, CarNumberMapper mapper)
        {
            WriteIntegerToMemoryStream(dataSource.GameExecutable, mapper.ValueA, entity.ValueA);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, mapper.ValueB, entity.ValueB);
        }
    }
}