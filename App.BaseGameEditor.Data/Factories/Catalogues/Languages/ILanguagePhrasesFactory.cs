using App.BaseGameEditor.Data.Catalogues.Commentary;
using App.BaseGameEditor.Data.Enums;

namespace App.BaseGameEditor.Data.Factories.Catalogues.Languages
{
    public interface ILanguagePhrasesFactory
    {
        ILanguagePhrases Create(LanguageType language);
    }
}