using System;

namespace App.BaseGameEditor.Application.Services
{
    public class DomainModelExportService
    {
        private readonly TeamDomainModelExportService _teamDomainModelExportService;

        public DomainModelExportService(TeamDomainModelExportService teamDomainModelExportService)
        {
            _teamDomainModelExportService = teamDomainModelExportService ?? throw new ArgumentNullException(nameof(teamDomainModelExportService));
        }

        public void Export()
        {
            _teamDomainModelExportService.Export();
        }
    }
}