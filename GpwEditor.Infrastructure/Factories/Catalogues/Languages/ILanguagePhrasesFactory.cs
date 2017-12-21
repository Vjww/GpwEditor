using GpwEditor.Infrastructure.Catalogues.Commentary;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Factories.Catalogues.Languages
{
    public interface ILanguagePhrasesFactory
    {
        ILanguagePhrases Create(LanguageType language);
    }
}