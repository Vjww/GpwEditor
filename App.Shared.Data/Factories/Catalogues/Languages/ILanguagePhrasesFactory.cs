using App.Shared.Data.Catalogues.Commentary;
using App.Shared.Data.Enums;

namespace App.Shared.Data.Factories.Catalogues.Languages
{
    public interface ILanguagePhrasesFactory
    {
        ILanguagePhrases Create(LanguageType language);
    }
}