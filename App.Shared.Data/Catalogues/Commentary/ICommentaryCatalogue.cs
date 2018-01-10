using App.Shared.Data.Enums;
using Common.Editor.Data.Catalogues;

namespace App.Shared.Data.Catalogues.Commentary
{
    public interface ICommentaryCatalogue : ICatalogue
    {
        LanguageType Language { get; }
    }
}