using Common.Editor.Data.Catalogues;

namespace GpwEditor.Infrastructure.Catalogues.Language
{
    public interface ILanguageCatalogue : ICatalogue
    {
        LanguageEnum Language { get; }
    }
}