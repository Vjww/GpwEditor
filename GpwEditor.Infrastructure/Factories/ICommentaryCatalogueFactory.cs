using GpwEditor.Infrastructure.Catalogues;
using GpwEditor.Infrastructure.Catalogues.Commentary;

namespace GpwEditor.Infrastructure.Factories
{
    public interface ICommentaryCatalogueFactory
    {
        ICommentaryCatalogue Create(LanguageEnum language);
    }
}