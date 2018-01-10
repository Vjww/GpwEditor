using App.BaseGameEditor.Data.Catalogues.Language;
using App.BaseGameEditor.Data.Entities;

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