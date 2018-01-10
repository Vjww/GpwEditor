using App.BaseGameEditor.Data.Entities;
using App.Shared.Data.Catalogues.Language;
using Common.Editor.Data.Factories;

namespace App.BaseGameEditor.Data.Factories.Entities
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