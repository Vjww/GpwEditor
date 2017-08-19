using ConsoleApplication.DataSources;
using ConsoleApplication.Entities;
using ConsoleApplication.Mappers;

namespace ConsoleApplication.Populators
{
    public class CarNumberPopulator : PopulatorBase<CarNumberEntity, CarNumberMapper>
    {
        public override void PopulateEntityFromDataSource(IDataSource dataSource, CarNumberEntity entity, CarNumberMapper mapper)
        {
            entity.CarNumberA = ReadIntegerFromMemoryStream(dataSource.GameExecutable, mapper.CarNumberA);
            entity.CarNumberB = ReadIntegerFromMemoryStream(dataSource.GameExecutable, mapper.CarNumberB);
        }

        public override void PopulateDataSourceFromEntity(IDataSource dataSource, CarNumberEntity entity, CarNumberMapper mapper)
        {
            WriteIntegerToMemoryStream(dataSource.GameExecutable, mapper.CarNumberA, entity.CarNumberA);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, mapper.CarNumberB, entity.CarNumberB);
        }
    }
}