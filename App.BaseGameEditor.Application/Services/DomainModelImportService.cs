using System;
using App.BaseGameEditor.Application.Services.DomainModel;

namespace App.BaseGameEditor.Application.Services
{
    public class DomainModelImportService
    {
        private readonly CommentaryDomainModelImportService _commentaryDomainModelImportService;
        private readonly TeamDomainModelImportService _teamDomainModelImportService;
        private readonly PersonDomainModelImportService _personDomainModelImportService;
        private readonly SponsorDomainModelImportService _sponsorDomainModelImportService;
        private readonly TrackDomainModelImportService _trackDomainModelImportService;
        private readonly PerformanceCurveDomainModelImportService _performanceCurveDomainModelImportService;
        private readonly LookupDomainModelImportService _lookupDomainModelImportService;

        public DomainModelImportService(
            CommentaryDomainModelImportService commentaryDomainModelImportService,
            TeamDomainModelImportService teamDomainModelImportService,
            PersonDomainModelImportService personDomainModelImportService,
            SponsorDomainModelImportService sponsorDomainModelImportService,
            TrackDomainModelImportService trackDomainModelImportService,
            PerformanceCurveDomainModelImportService performanceCurveDomainModelImportService,
            LookupDomainModelImportService lookupDomainModelImportService)
        {
            _commentaryDomainModelImportService = commentaryDomainModelImportService ?? throw new ArgumentNullException(nameof(commentaryDomainModelImportService));
            _teamDomainModelImportService = teamDomainModelImportService ?? throw new ArgumentNullException(nameof(teamDomainModelImportService));
            _personDomainModelImportService = personDomainModelImportService ?? throw new ArgumentNullException(nameof(personDomainModelImportService));
            _sponsorDomainModelImportService = sponsorDomainModelImportService ?? throw new ArgumentNullException(nameof(sponsorDomainModelImportService));
            _trackDomainModelImportService = trackDomainModelImportService ?? throw new ArgumentNullException(nameof(trackDomainModelImportService));
            _performanceCurveDomainModelImportService = performanceCurveDomainModelImportService ?? throw new ArgumentNullException(nameof(performanceCurveDomainModelImportService));
            _lookupDomainModelImportService = lookupDomainModelImportService ?? throw new ArgumentNullException(nameof(lookupDomainModelImportService));
        }

        public void Import()
        {
            _commentaryDomainModelImportService.Import();
            _teamDomainModelImportService.Import();
            _personDomainModelImportService.Import();
            _sponsorDomainModelImportService.Import();
            _trackDomainModelImportService.Import();
            _performanceCurveDomainModelImportService.Import();
            _lookupDomainModelImportService.Import();
        }
    }
}