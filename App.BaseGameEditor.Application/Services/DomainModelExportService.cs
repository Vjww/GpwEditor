using System;

namespace App.BaseGameEditor.Application.Services
{
    public class DomainModelExportService
    {
        private readonly TeamDomainModelExportService _teamDomainModelExportService;
        private readonly PersonDomainModelExportService _personDomainModelExportService;
        private readonly SupplierDomainModelExportService _supplierDomainModelExportService;
        private readonly TrackDomainModelExportService _trackDomainModelExportService;

        public DomainModelExportService(
            TeamDomainModelExportService teamDomainModelExportService,
            PersonDomainModelExportService personDomainModelExportService,
            SupplierDomainModelExportService supplierDomainModelExportService,
            TrackDomainModelExportService trackDomainModelExportService)
        {
            _teamDomainModelExportService = teamDomainModelExportService ?? throw new ArgumentNullException(nameof(teamDomainModelExportService));
            _personDomainModelExportService = personDomainModelExportService ?? throw new ArgumentNullException(nameof(personDomainModelExportService));
            _supplierDomainModelExportService = supplierDomainModelExportService ?? throw new ArgumentNullException(nameof(supplierDomainModelExportService));
            _trackDomainModelExportService = trackDomainModelExportService ?? throw new ArgumentNullException(nameof(trackDomainModelExportService));
        }

        public void Export()
        {
            _teamDomainModelExportService.Export();
            _personDomainModelExportService.Export();
            _supplierDomainModelExportService.Export();
            _trackDomainModelExportService.Export();
        }
    }
}