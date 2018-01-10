using App.BaseGameEditor.Data.Enums;

namespace App.BaseGameEditor.Data.Catalogues.Commentary
{
    public interface ICommentaryCatalogue : ICatalogue
    {
        LanguageType Language { get; }
    }
}