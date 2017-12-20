using GpwEditor.Infrastructure.Catalogues;
using GpwEditor.Infrastructure.Catalogues.Commentary;

namespace GpwEditor.Infrastructure.Factories
{
    public interface ILanguagePhrasesFactory
    {
        ILanguagePhrases Create(LanguageEnum language);
    }
}