using System;
using App.LanguageFileEditor.Application.Services.DomainModel;

namespace App.LanguageFileEditor.Application.Services
{
    public class LanguageFileEditorDomainModelExportService
    {
        private readonly LanguageDomainModelExportService _languageDomainModelExportService;

        public LanguageFileEditorDomainModelExportService(
            LanguageDomainModelExportService languageDomainModelExportService)
        {
            _languageDomainModelExportService = languageDomainModelExportService ?? throw new ArgumentNullException(nameof(languageDomainModelExportService));
        }

        public void Export()
        {
            _languageDomainModelExportService.Export();
        }
    }
}