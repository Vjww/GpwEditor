using GpwEditor.Infrastructure.Catalogues.Commentary;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Factories.Catalogues.Commentary
{
    public interface ICommentaryCatalogueFactory
    {
        ICommentaryCatalogue Create(LanguageType language);
    }
}