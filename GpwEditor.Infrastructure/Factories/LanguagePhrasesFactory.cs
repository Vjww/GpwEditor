using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GpwEditor.Infrastructure.Catalogues;
using GpwEditor.Infrastructure.Catalogues.Commentary;

namespace GpwEditor.Infrastructure.Factories
{
    public class LanguagePhrasesFactory : ILanguagePhrasesFactory
    {
        private readonly IEnumerable<ILanguagePhrases> _languagePhrases;

        public LanguagePhrasesFactory(IEnumerable<ILanguagePhrases> languagePhrases)
        {
            _languagePhrases = languagePhrases ?? throw new ArgumentNullException(nameof(languagePhrases));
        }

        public ILanguagePhrases Create(LanguageEnum language)
        {
            if (!Enum.IsDefined(typeof(LanguageEnum), language))
                throw new InvalidEnumArgumentException(nameof(language), (int)language, typeof(LanguageEnum));

            var languagePhrasesName = $"{language}LanguagePhrases";
            var languagePhrases = _languagePhrases.SingleOrDefault(x => x.Language == language);

            if (languagePhrases == null)
            {
                throw new InvalidOperationException(
                    $"Unable to resolve '{languagePhrasesName}'. Make sure the type is registered with the dependency injection container.");
            }

            return languagePhrases;
        }
    }
}