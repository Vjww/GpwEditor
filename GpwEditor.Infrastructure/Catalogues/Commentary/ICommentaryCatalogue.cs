using Common.Editor.Data.Catalogues;

namespace GpwEditor.Infrastructure.Catalogues.Commentary
{
    public interface ICommentaryCatalogue : ICatalogue
    {
        LanguageEnum Language { get; }
    }
}