using System;

namespace App.BaseGameEditor.Application.Services
{
    public class DomainModelExportService
    {
        private readonly TeamDomainModelExportService _teamDomainModelExportService;
        private readonly PersonDomainModelExportService _personDomainModelExportService;

        public DomainModelExportService(
            TeamDomainModelExportService teamDomainModelExportService,
            PersonDomainModelExportService personDomainModelExportService)
        {
            _teamDomainModelExportService = teamDomainModelExportService ?? throw new ArgumentNullException(nameof(teamDomainModelExportService));
            _personDomainModelExportService = personDomainModelExportService ?? throw new ArgumentNullException(nameof(personDomainModelExportService));
        }

        public void Export()
        {
            _teamDomainModelExportService.Export();
            _personDomainModelExportService.Export();
        }
    }
}