using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GpwEditor.Infrastructure.Catalogues;
using GpwEditor.Infrastructure.Catalogues.Language;

namespace GpwEditor.Infrastructure.Factories
{
    public class LanguageCatalogueFactory : ILanguageCatalogueFactory
    {
        private readonly IEnumerable<ILanguageCatalogue> _languageCatalogues;

        public LanguageCatalogueFactory(IEnumerable<ILanguageCatalogue> languageCatalogues)
        {
            _languageCatalogues = languageCatalogues ?? throw new ArgumentNullException(nameof(languageCatalogues));
        }

        public ILanguageCatalogue Create(LanguageEnum language)
        {
            if (!Enum.IsDefined(typeof(LanguageEnum), language))
                throw new InvalidEnumArgumentException(nameof(language), (int)language, typeof(LanguageEnum));

            var languageCatalogueName = $"{language}LanguageCatalogue";
            var languageCatalogue = _languageCatalogues.SingleOrDefault(x => x.Language == language);

            if (languageCatalogue == null)
            {
                throw new InvalidOperationException(
                    $"Unable to resolve '{languageCatalogueName}'. Make sure the type is registered with the dependency injection container.");
            }

            return languageCatalogue;
        }
    }
}