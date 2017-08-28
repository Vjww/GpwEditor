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
            entity.CarNumberA = ReadIntegerFromMemoryStream(dataSource.GameExecutable, mapper.CarNumberA);
            entity.CarNumberB = ReadIntegerFromMemoryStream(dataSource.GameExecutable, mapper.CarNumberB);
        }

        public override void ExportEntityToDataSource(BaseGameDataSource dataSource, CarNumberEntity entity, CarNumberMapper mapper)
        {
            WriteIntegerToMemoryStream(dataSource.GameExecutable, mapper.CarNumberA, entity.CarNumberA);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, mapper.CarNumberB, entity.CarNumberB);
        }
    }
}