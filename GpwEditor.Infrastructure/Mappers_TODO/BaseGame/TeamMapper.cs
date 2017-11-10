using System;
using Common.Editor.Infrastructure.Mappers;
using GpwEditor.Infrastructure.DataConnections;
using GpwEditor.Infrastructure.DataContexts;
using GpwEditor.Infrastructure.Entities.BaseGame;
using GpwEditor.Infrastructure.Locators.BaseGame;

namespace GpwEditor.Infrastructure.Mappers.BaseGame
{
    public class TeamPopulator : MapperBase<BaseGameDataContext, BaseGameDataConnection, TeamEntity, TeamLocator>
    {
        public override void ImportEntityFromDataSource(BaseGameDataContext dataSource, TeamEntity entity, TeamLocator locator)
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (locator == null) throw new ArgumentNullException(nameof(locator));

            entity.Name.English = ReadStringFromTextResource(dataSource.EnglishLanguageResource, locator.Name);
            entity.Name.French = ReadStringFromTextResource(dataSource.FrenchLanguageResource, locator.Name);
            entity.Name.German = ReadStringFromTextResource(dataSource.GermanLanguageResource, locator.Name);
            entity.LastPosition = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.LastPosition);
            entity.LastPoints = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.LastPoints);
            entity.FirstGpTrack = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.FirstGpTrack);
            entity.FirstGpYear = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.FirstGpYear);
            entity.Wins = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.Wins);
            entity.YearlyBudget = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.YearlyBudget);
            entity.UnknownA = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.UnknownA);
            entity.CountryMapId = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.CountryMapId);
            entity.LocationPointerX = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.LocationPointerX);
            entity.LocationPointerY = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.LocationPointerY);
            entity.TyreSupplierId = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.TyreSupplierId);
        }

        public override void ExportEntityToDataSource(BaseGameDataContext dataSource, TeamEntity entity, TeamLocator locator)
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (locator == null) throw new ArgumentNullException(nameof(locator));

            WriteStringToTextResource(dataSource.EnglishLanguageResource, locator.Name, entity.Name.English);
            WriteStringToTextResource(dataSource.FrenchLanguageResource, locator.Name, entity.Name.French);
            WriteStringToTextResource(dataSource.GermanLanguageResource, locator.Name, entity.Name.German);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.LastPosition, entity.LastPosition);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.LastPoints, entity.LastPoints);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.FirstGpTrack, entity.FirstGpTrack);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.FirstGpYear, entity.FirstGpYear);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.Wins, entity.Wins);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.YearlyBudget, entity.YearlyBudget);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.UnknownA, entity.UnknownA);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.CountryMapId, entity.CountryMapId);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.LocationPointerX, entity.LocationPointerX);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.LocationPointerY, entity.LocationPointerY);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.TyreSupplierId, entity.TyreSupplierId);
        }
    }
}