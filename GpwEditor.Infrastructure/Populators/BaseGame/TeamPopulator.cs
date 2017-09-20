using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.DataSources;
using GpwEditor.Infrastructure.Entities.BaseGame;
using GpwEditor.Infrastructure.ValueMappers.BaseGame;

namespace GpwEditor.Infrastructure.Populators.BaseGame
{
    public class TeamPopulator : PopulatorBase<BaseGameDataSource, BaseGameConnectionStrings, TeamEntity, TeamValueMapper>
    {
        public override void ImportEntityFromDataSource(BaseGameDataSource dataSource, TeamEntity entity, TeamValueMapper valueMapper)
        {
            entity.Name.English = ReadStringFromTextResource(dataSource.EnglishLanguageResource, valueMapper.Name);
            entity.Name.French = ReadStringFromTextResource(dataSource.FrenchLanguageResource, valueMapper.Name);
            entity.Name.German = ReadStringFromTextResource(dataSource.GermanLanguageResource, valueMapper.Name);
            entity.LastPosition = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.LastPosition);
            entity.LastPoints = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.LastPoints);
            entity.FirstGpTrack = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.FirstGpTrack);
            entity.FirstGpYear = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.FirstGpYear);
            entity.Wins = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.Wins);
            entity.YearlyBudget = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.YearlyBudget);
            entity.UnknownA = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.UnknownA);
            entity.CountryMapId = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.CountryMapId);
            entity.LocationPointerX = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.LocationPointerX);
            entity.LocationPointerY = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.LocationPointerY);
            entity.TyreSupplierId = ReadIntegerFromMemoryStream(dataSource.GameExecutable, valueMapper.TyreSupplierId);
        }

        public override void ExportEntityToDataSource(BaseGameDataSource dataSource, TeamEntity entity, TeamValueMapper valueMapper)
        {
            WriteStringToTextResource(dataSource.EnglishLanguageResource, valueMapper.Name, entity.Name.English);
            WriteStringToTextResource(dataSource.FrenchLanguageResource, valueMapper.Name, entity.Name.French);
            WriteStringToTextResource(dataSource.GermanLanguageResource, valueMapper.Name, entity.Name.German);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.LastPosition, entity.LastPosition);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.LastPoints, entity.LastPoints);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.FirstGpTrack, entity.FirstGpTrack);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.FirstGpYear, entity.FirstGpYear);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.Wins, entity.Wins);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.YearlyBudget, entity.YearlyBudget);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.UnknownA, entity.UnknownA);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.CountryMapId, entity.CountryMapId);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.LocationPointerX, entity.LocationPointerX);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.LocationPointerY, entity.LocationPointerY);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, valueMapper.TyreSupplierId, entity.TyreSupplierId);
        }
    }
}