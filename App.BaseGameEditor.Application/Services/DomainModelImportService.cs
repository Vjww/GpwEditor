using System;

namespace App.BaseGameEditor.Application.Services
{
    public class DomainModelImportService
    {
        private readonly TeamDomainModelImportService _teamDomainModelImportService;
        private readonly PersonDomainModelImportService _personDomainModelImportService;

        public DomainModelImportService(
            TeamDomainModelImportService teamDomainModelImportService,
            PersonDomainModelImportService personDomainModelImportService)
        {
            _teamDomainModelImportService = teamDomainModelImportService ?? throw new ArgumentNullException(nameof(teamDomainModelImportService));
            _personDomainModelImportService = personDomainModelImportService ?? throw new ArgumentNullException(nameof(personDomainModelImportService));
        }

        public void Import()
        {
            _teamDomainModelImportService.Import();
            _personDomainModelImportService.Import();
        }
    }
}