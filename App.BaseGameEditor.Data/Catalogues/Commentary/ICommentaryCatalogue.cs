using App.BaseGameEditor.Data.Enums;
using Common.Editor.Data.Catalogues;

namespace App.BaseGameEditor.Data.Catalogues.Commentary
{
    public interface ICommentaryCatalogue : ICatalogue
    {
        LanguageType Language { get; }
    }
}