using System;

namespace App.BaseGameEditor.Application.Services
{
    public class DomainModelImportService
    {
        private readonly TeamDomainModelImportService _teamDomainModelImportService;
        private readonly PersonDomainModelImportService _personDomainModelImportService;
        private readonly SupplierDomainModelImportService _supplierDomainModelImportService;

        public DomainModelImportService(
            TeamDomainModelImportService teamDomainModelImportService,
            PersonDomainModelImportService personDomainModelImportService,
            SupplierDomainModelImportService supplierDomainModelImportService)
        {
            _teamDomainModelImportService = teamDomainModelImportService ?? throw new ArgumentNullException(nameof(teamDomainModelImportService));
            _personDomainModelImportService = personDomainModelImportService ?? throw new ArgumentNullException(nameof(personDomainModelImportService));
            _supplierDomainModelImportService = supplierDomainModelImportService ?? throw new ArgumentNullException(nameof(supplierDomainModelImportService));
        }

        public void Import()
        {
            _teamDomainModelImportService.Import();
            _personDomainModelImportService.Import();
            _supplierDomainModelImportService.Import();
        }
    }
}