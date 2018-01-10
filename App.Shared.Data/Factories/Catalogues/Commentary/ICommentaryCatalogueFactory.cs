using App.Shared.Data.Catalogues.Commentary;
using App.Shared.Data.Enums;

namespace App.Shared.Data.Factories.Catalogues.Commentary
{
    public interface ICommentaryCatalogueFactory
    {
        ICommentaryCatalogue Create(LanguageType language);
    }
}