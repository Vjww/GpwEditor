using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GpwEditor.Infrastructure.Catalogues.Commentary;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Factories.Catalogues.Languages
{
    public class LanguagePhrasesFactory : ILanguagePhrasesFactory
    {
        private readonly IEnumerable<ILanguagePhrases> _languagePhrases;

        public LanguagePhrasesFactory(IEnumerable<ILanguagePhrases> languagePhrases)
        {
            _languagePhrases = languagePhrases ?? throw new ArgumentNullException(nameof(languagePhrases));
        }

        public ILanguagePhrases Create(LanguageType language)
        {
            if (!Enum.IsDefined(typeof(LanguageType), language))
                throw new InvalidEnumArgumentException(nameof(language), (int)language, typeof(LanguageType));

            var name = $"{language}LanguagePhrases";
            var result = _languagePhrases.SingleOrDefault(x => x.Language == language);

            if (result == null)
            {
                throw new InvalidOperationException($"Unable to resolve '{name}'. Make sure the type is registered with the dependency injection container.");
            }

            return result;
        }
    }
}