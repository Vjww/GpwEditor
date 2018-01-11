using App.BaseGameEditor.Data.Catalogues.Language;
using App.BaseGameEditor.Data.Entities;

namespace App.BaseGameEditor.Data.Factories
{
    public class TeamEntityFactory
    {
        public TeamEntity Create(int id)
        {
            // TODO: Should this be instantiated from a DI Container?
            // TODO: This factory class might need to reside under the composition root
            // TODO: if it is going to resolve from the DI Container, as the domain
            // TODO: should not reference the DI tool.
            // TODO: Alternatively a solution could be implemented by the DI Container.
            // TODO: Refer to http://www.wiktorzychla.com/2016/01/di-factories-and-composition-root.html
            return new TeamEntity(new LanguageCatalogueValue()) { Id = id };
        }
    }
}