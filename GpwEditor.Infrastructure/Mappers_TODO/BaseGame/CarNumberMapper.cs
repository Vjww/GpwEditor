using System;
using Common.Editor.Infrastructure.Mappers;
using GpwEditor.Infrastructure.DataConnections;
using GpwEditor.Infrastructure.DataContexts;
using GpwEditor.Infrastructure.Entities.BaseGame;
using GpwEditor.Infrastructure.Locators.BaseGame;

namespace GpwEditor.Infrastructure.Mappers.BaseGame
{
    public class CarNumberPopulator : MapperBase<BaseGameDataContext, BaseGameDataConnection, CarNumberEntity, CarNumberLocator>
    {
        public override void ImportEntityFromDataSource(BaseGameDataContext dataSource, CarNumberEntity entity, CarNumberLocator locator)
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (locator == null) throw new ArgumentNullException(nameof(locator));

            entity.TeamId = entity.Id / 2;
            entity.PositionId = entity.Id % 2;
            entity.ValueA = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.ValueA);
            entity.ValueB = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.ValueB);
        }

        public override void ExportEntityToDataSource(BaseGameDataContext dataSource, CarNumberEntity entity, CarNumberLocator locator)
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (locator == null) throw new ArgumentNullException(nameof(locator));

            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.ValueA, entity.ValueA);
            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.ValueB, entity.ValueB);
        }
    }
}