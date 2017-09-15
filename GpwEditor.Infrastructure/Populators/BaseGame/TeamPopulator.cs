using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.DataSources;
using GpwEditor.Infrastructure.Entities.BaseGame;
using GpwEditor.Infrastructure.Mappers.BaseGame;

namespace GpwEditor.Infrastructure.Populators.BaseGame
{
    public class TeamPopulator : PopulatorBase<BaseGameDataSource, BaseGameConnectionStrings, TeamEntity, TeamMapper>
    {
        public override void ImportEntityFromDataSource(BaseGameDataSource dataSource, TeamEntity entity, TeamMapper mapper)
        {
            entity.Name = dataSource.EnglishLanguageResource.Read(mapper.Name);
        }

        public override void ExportEntityToDataSource(BaseGameDataSource dataSource, TeamEntity entity, TeamMapper mapper)
        {
            dataSource.EnglishLanguageResource.Write(mapper.Name, entity.Name);
        }
    }
}