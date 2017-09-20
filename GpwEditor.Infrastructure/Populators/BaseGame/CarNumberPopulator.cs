using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.DataSources;
using GpwEditor.Infrastructure.Entities.BaseGame;
using GpwEditor.Infrastructure.ValueMappers.BaseGame;

namespace GpwEditor.Infrastructure.Populators.BaseGame
{
    public class CarNumberPopulator : PopulatorBase<BaseGameDataSource, BaseGameConnectionStrings, CarNumberEntity, CarNumberValueMapper>
    {
        public override void ImportEntityFromDataSource(BaseGameDataSource dataSource, CarNumberEntity entity, CarNumberValueMapper valueMapper)
        {
            entity.TeamId = entity.Id / 2;
            entity.PositionId = entity.Id % 2;
            entity.ValueA = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.ValueA);
            entity.ValueB = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.ValueB);
        }

        public override void ExportEntityToDataSource(BaseGameDataSource dataSource, CarNumberEntity entity, CarNumberValueMapper valueMapper)
        {
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.ValueA, entity.ValueA);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.ValueB, entity.ValueB);
        }
    }
}