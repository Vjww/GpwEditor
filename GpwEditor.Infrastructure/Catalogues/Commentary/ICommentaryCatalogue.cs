using Common.Editor.Data.Catalogues;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Catalogues.Commentary
{
    public interface ICommentaryCatalogue : ICatalogue
    {
        LanguageType Language { get; }
    }
}