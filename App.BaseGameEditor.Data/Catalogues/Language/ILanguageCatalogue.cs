using App.BaseGameEditor.Data.Enums;

namespace App.BaseGameEditor.Data.Catalogues.Language
{
    public interface ILanguageCatalogue : ICatalogue
    {
        LanguageType Language { get; }
    }
}