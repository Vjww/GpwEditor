using ConsoleApplication.DataSources;
using ConsoleApplication.Entities.BaseGame;
using ConsoleApplication.Infrastructure;
using ConsoleApplication.Mappers.BaseGame;

namespace ConsoleApplication.Populators.BaseGame
{
    public class CarNumberPopulator : PopulatorBase<BaseGameDataSource, BaseGameConnectionStrings, CarNumberEntity, CarNumberMapper>
    {
        public override void ImportEntityFromDataSource(BaseGameDataSource dataSource, CarNumberEntity entity, CarNumberMapper mapper)
        {
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