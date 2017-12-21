using GpwEditor.Infrastructure.Catalogues.Language;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Factories.Catalogues.Languages
{
    public interface ILanguageCatalogueFactory
    {
        ILanguageCatalogue Create(LanguageType language);
    }
}