using System;

namespace App.BaseGameEditor.Application.Services
{
    public class DomainModelImportService
    {
        private readonly CommentaryDomainModelImportService _commentaryDomainModelImportService;
        private readonly TeamDomainModelImportService _teamDomainModelImportService;
        private readonly PersonDomainModelImportService _personDomainModelImportService;
        private readonly SupplierDomainModelImportService _supplierDomainModelImportService;
        private readonly TrackDomainModelImportService _trackDomainModelImportService;
        private readonly PerformanceCurveDomainModelImportService _performanceCurveDomainModelImportService;
        private readonly LookupDomainModelImportService _lookupDomainModelImportService;

        public DomainModelImportService(
            CommentaryDomainModelImportService commentaryDomainModelImportService,
            TeamDomainModelImportService teamDomainModelImportService,
            PersonDomainModelImportService personDomainModelImportService,
            SupplierDomainModelImportService supplierDomainModelImportService,
            TrackDomainModelImportService trackDomainModelImportService,
            PerformanceCurveDomainModelImportService performanceCurveDomainModelImportService,
            LookupDomainModelImportService lookupDomainModelImportService)
        {
            _commentaryDomainModelImportService = commentaryDomainModelImportService ?? throw new ArgumentNullException(nameof(commentaryDomainModelImportService));
            _teamDomainModelImportService = teamDomainModelImportService ?? throw new ArgumentNullException(nameof(teamDomainModelImportService));
            _personDomainModelImportService = personDomainModelImportService ?? throw new ArgumentNullException(nameof(personDomainModelImportService));
            _supplierDomainModelImportService = supplierDomainModelImportService ?? throw new ArgumentNullException(nameof(supplierDomainModelImportService));
            _trackDomainModelImportService = trackDomainModelImportService ?? throw new ArgumentNullException(nameof(trackDomainModelImportService));
            _performanceCurveDomainModelImportService = performanceCurveDomainModelImportService ?? throw new ArgumentNullException(nameof(performanceCurveDomainModelImportService));
            _lookupDomainModelImportService = lookupDomainModelImportService ?? throw new ArgumentNullException(nameof(lookupDomainModelImportService));
        }

        public void Import()
        {
            _commentaryDomainModelImportService.Import();
            _teamDomainModelImportService.Import();
            _personDomainModelImportService.Import();
            _supplierDomainModelImportService.Import();
            _trackDomainModelImportService.Import();
            _performanceCurveDomainModelImportService.Import();
            _lookupDomainModelImportService.Import();
        }
    }
}