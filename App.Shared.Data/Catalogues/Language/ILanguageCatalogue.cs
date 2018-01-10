using App.Shared.Data.Enums;
using Common.Editor.Data.Catalogues;

namespace App.Shared.Data.Catalogues.Language
{
    public interface ILanguageCatalogue : ICatalogue
    {
        LanguageType Language { get; }
    }
}