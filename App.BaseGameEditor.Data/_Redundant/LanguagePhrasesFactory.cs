//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using App.BaseGameEditor.Data.Catalogues.Commentary;
//using App.BaseGameEditor.Data.Enums;

//namespace App.BaseGameEditor.Data.Factories
//{
//    public class LanguagePhrasesFactory
//    {
//        private readonly IEnumerable<ILanguagePhrases> _languagePhrases;

//        public LanguagePhrasesFactory(IEnumerable<ILanguagePhrases> languagePhrases)
//        {
//            _languagePhrases = languagePhrases ?? throw new ArgumentNullException(nameof(languagePhrases));
//        }

//        public ILanguagePhrases Create(LanguageType language)
//        {
//            if (!Enum.IsDefined(typeof(LanguageType), language))
//                throw new InvalidEnumArgumentException(nameof(language), (int)language, typeof(LanguageType));

//            var name = $"{language}LanguagePhrases";
//            var result = _languagePhrases.SingleOrDefault(x => x.Language == language);

//            if (result == null)
//            {
//                throw new InvalidOperationException($"Unable to resolve '{name}'. Make sure the type is registered with the dependency injection container.");
//            }

//            return result;
//        }
//    }
//}