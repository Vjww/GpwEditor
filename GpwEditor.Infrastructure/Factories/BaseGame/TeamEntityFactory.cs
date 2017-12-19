using System;
using Common.Editor.Data.Factories;
using GpwEditor.Infrastructure.Catalogues.Language;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Infrastructure.Factories.BaseGame
{
    public class TeamEntityFactory : IEntityFactory<TeamEntity>
    {
        private readonly LanguageCatalogueString _languageCatalogueString;

        public TeamEntityFactory(LanguageCatalogueString languageCatalogueString)
        {
            _languageCatalogueString = languageCatalogueString ?? throw new ArgumentNullException(nameof(languageCatalogueString));
        }

        public TeamEntity Create(int id)
        {
            return new TeamEntity(_languageCatalogueString) { Id = id };
        }
    }
}