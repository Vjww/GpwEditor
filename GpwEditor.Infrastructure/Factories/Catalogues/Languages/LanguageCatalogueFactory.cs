using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GpwEditor.Infrastructure.Catalogues.Language;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Factories.Catalogues.Languages
{
    public class LanguageCatalogueFactory : ILanguageCatalogueFactory
    {
        private readonly IEnumerable<ILanguageCatalogue> _languageCatalogues;

        public LanguageCatalogueFactory(IEnumerable<ILanguageCatalogue> languageCatalogues)
        {
            _languageCatalogues = languageCatalogues ?? throw new ArgumentNullException(nameof(languageCatalogues));
        }

        public ILanguageCatalogue Create(LanguageType language)
        {
            if (!Enum.IsDefined(typeof(LanguageType), language))
                throw new InvalidEnumArgumentException(nameof(language), (int)language, typeof(LanguageType));

            var name = $"{language}LanguageCatalogue";
            var result = _languageCatalogues.SingleOrDefault(x => x.Language == language);

            if (result == null)
            {
                throw new InvalidOperationException($"Unable to resolve '{name}'. Make sure the type is registered with the dependency injection container.");
            }

            return result;
        }
    }
}