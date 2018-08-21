using System;
using App.LanguageFileEditor.Application.Services.DomainModel;

namespace App.LanguageFileEditor.Application.Services
{
    public class LanguageFileEditorDomainModelImportService
    {
        private readonly LanguageDomainModelImportService _languageDomainModelImportService;

        public LanguageFileEditorDomainModelImportService(
            LanguageDomainModelImportService languageDomainModelImportService)
        {
            _languageDomainModelImportService = languageDomainModelImportService ?? throw new ArgumentNullException(nameof(languageDomainModelImportService));
        }

        public void Import()
        {
            _languageDomainModelImportService.Import();
        }
    }
}