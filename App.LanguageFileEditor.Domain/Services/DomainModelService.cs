using System;

namespace App.LanguageFileEditor.Domain.Services
{
    public class DomainModelService
    {
        public LanguageDomainService Languages { get; }

        public DomainModelService(LanguageDomainService languageDomainService)
        {
            Languages = languageDomainService ?? throw new ArgumentNullException(nameof(languageDomainService));
        }
    }
}