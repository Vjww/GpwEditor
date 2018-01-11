using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using App.BaseGameEditor.Data.Catalogues.Language;
using App.BaseGameEditor.Data.Enums;

namespace App.BaseGameEditor.Data.Factories
{
    public class LanguageCatalogueFactory
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