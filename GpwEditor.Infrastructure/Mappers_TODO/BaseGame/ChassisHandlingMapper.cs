using System;
using Common.Editor.Infrastructure.Mappers;
using GpwEditor.Infrastructure.DataConnections;
using GpwEditor.Infrastructure.DataContexts;
using GpwEditor.Infrastructure.Entities.BaseGame;
using GpwEditor.Infrastructure.Locators.BaseGame;

namespace GpwEditor.Infrastructure.Mappers.BaseGame
{
    public class ChassisHandlingPopulator : MapperBase<BaseGameDataContext, BaseGameDataConnection, ChassisHandlingEntity, ChassisHandlingLocator>
    {
        public override void ImportEntityFromDataSource(BaseGameDataContext dataSource, ChassisHandlingEntity entity, ChassisHandlingLocator locator)
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (locator == null) throw new ArgumentNullException(nameof(locator));

            entity.TeamId = entity.Id;
            entity.Value = ReadIntegerFromMemoryStream(dataSource.GameExecutable, locator.Value);
        }

        public override void ExportEntityToDataSource(BaseGameDataContext dataSource, ChassisHandlingEntity entity, ChassisHandlingLocator locator)
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (locator == null) throw new ArgumentNullException(nameof(locator));

            WriteIntegerToMemoryStream(dataSource.GameExecutable, locator.Value, entity.Value);
        }
    }
}