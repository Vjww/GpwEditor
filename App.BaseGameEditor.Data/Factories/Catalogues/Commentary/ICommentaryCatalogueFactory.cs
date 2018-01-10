using App.BaseGameEditor.Data.Catalogues.Commentary;
using App.BaseGameEditor.Data.Enums;

namespace App.BaseGameEditor.Data.Factories.Catalogues.Commentary
{
    public interface ICommentaryCatalogueFactory
    {
        ICommentaryCatalogue Create(LanguageType language);
    }
}