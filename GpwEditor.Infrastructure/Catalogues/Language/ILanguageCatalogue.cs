using Common.Editor.Data.Catalogues;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Catalogues.Language
{
    public interface ILanguageCatalogue : ICatalogue
    {
        LanguageType Language { get; }
    }
}