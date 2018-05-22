using System;

namespace App.BaseGameEditor.Application.Services
{
    public class DomainModelExportService
    {
        private readonly CommentaryDomainModelExportService _commentaryDomainModelExportService;
        private readonly TeamDomainModelExportService _teamDomainModelExportService;
        private readonly PersonDomainModelExportService _personDomainModelExportService;
        private readonly SupplierDomainModelExportService _supplierDomainModelExportService;
        private readonly TrackDomainModelExportService _trackDomainModelExportService;
        private readonly PerformanceCurveDomainModelExportService _performanceCurveDomainModelExportService;

        public DomainModelExportService(
            CommentaryDomainModelExportService commentaryDomainModelExportService,
            TeamDomainModelExportService teamDomainModelExportService,
            PersonDomainModelExportService personDomainModelExportService,
            SupplierDomainModelExportService supplierDomainModelExportService,
            TrackDomainModelExportService trackDomainModelExportService,
            PerformanceCurveDomainModelExportService performanceCurveDomainModelExportService)
        {
            _commentaryDomainModelExportService = commentaryDomainModelExportService ?? throw new ArgumentNullException(nameof(commentaryDomainModelExportService));
            _teamDomainModelExportService = teamDomainModelExportService ?? throw new ArgumentNullException(nameof(teamDomainModelExportService));
            _personDomainModelExportService = personDomainModelExportService ?? throw new ArgumentNullException(nameof(personDomainModelExportService));
            _supplierDomainModelExportService = supplierDomainModelExportService ?? throw new ArgumentNullException(nameof(supplierDomainModelExportService));
            _trackDomainModelExportService = trackDomainModelExportService ?? throw new ArgumentNullException(nameof(trackDomainModelExportService));
            _performanceCurveDomainModelExportService = performanceCurveDomainModelExportService ?? throw new ArgumentNullException(nameof(performanceCurveDomainModelExportService));
        }

        public void Export()
        {
            _commentaryDomainModelExportService.Export();
            _teamDomainModelExportService.Export();
            _personDomainModelExportService.Export();
            _supplierDomainModelExportService.Export();
            _trackDomainModelExportService.Export();
            _performanceCurveDomainModelExportService.Export();
        }
    }
}