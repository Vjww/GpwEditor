using System;
using Common.Editor.Data.Factories;
using GpwEditor.Infrastructure.Catalogues.Language;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Infrastructure.Factories.BaseGame
{
    // TODO: Is this required?
    public class TeamEntityFactory : IEntityFactory<TeamEntity>
    {
        private readonly LanguageCatalogueValue _languageCatalogueString;

        public TeamEntityFactory(LanguageCatalogueValue languageCatalogueString)
        {
            _languageCatalogueString = languageCatalogueString ?? throw new ArgumentNullException(nameof(languageCatalogueString));
        }

        public TeamEntity Create(int id)
        {
            return new TeamEntity(_languageCatalogueString) { Id = id };
        }
    }
}