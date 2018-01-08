using App.BaseGameEditor.Data.Enums;
using Common.Editor.Data.Catalogues;

namespace App.BaseGameEditor.Data.Catalogues.Language
{
    public interface ILanguageCatalogue : ICatalogue
    {
        LanguageType Language { get; }
    }
}