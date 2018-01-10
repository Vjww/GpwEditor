using App.Shared.Data.Catalogues.Language;
using App.Shared.Data.Enums;

namespace App.Shared.Data.Factories.Catalogues.Languages
{
    public interface ILanguageCatalogueFactory
    {
        ILanguageCatalogue Create(LanguageType language);
    }
}