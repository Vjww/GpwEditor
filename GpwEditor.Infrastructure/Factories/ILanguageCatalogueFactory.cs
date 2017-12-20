using GpwEditor.Infrastructure.Catalogues;
using GpwEditor.Infrastructure.Catalogues.Language;

namespace GpwEditor.Infrastructure.Factories
{
    public interface ILanguageCatalogueFactory
    {
        ILanguageCatalogue Create(LanguageEnum language);
    }
}