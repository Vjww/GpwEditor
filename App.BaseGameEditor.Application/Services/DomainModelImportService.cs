using System;

namespace App.BaseGameEditor.Application.Services
{
    public class DomainModelImportService
    {
        private readonly TeamDomainModelImportService _teamDomainModelImportService;

        public DomainModelImportService(TeamDomainModelImportService teamDomainModelImportService)
        {
            _teamDomainModelImportService = teamDomainModelImportService ?? throw new ArgumentNullException(nameof(teamDomainModelImportService));
        }

        public void Import()
        {
            _teamDomainModelImportService.Import();
        }
    }
}