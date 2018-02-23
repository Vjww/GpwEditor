using Common.Editor.Data.Factories;
using GpwEditor.Infrastructure.Catalogues.Language;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Infrastructure.Factories.Entities.BaseGame
{
    public class TeamEntityFactory : IEntityFactory<TeamEntity>
    {
        public TeamEntity Create(int id)
        {
            // TODO: Should instantiate from DI container?
            return new TeamEntity(new LanguageCatalogueValue()) { Id = id };
        }
    }
}