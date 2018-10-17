using System;

namespace App.BaseGameEditor.Domain.Services
{
    public class DomainModelService
    {
        public ConfigurationDomainService Configurations { get; }
        public CommentaryDomainService Commentaries { get; }
        public TeamDomainService Teams { get; }
        public PersonDomainService Persons { get; }
        public SponsorshipDomainService Sponsorships { get; }
        public TrackDomainService Tracks { get; }
        public PerformanceCurveDomainService PerformanceCurveValues { get; }
        public LookupDomainService Lookups { get; }

        public DomainModelService(
            ConfigurationDomainService configurationDomainService,
            CommentaryDomainService commentaryDomainService,
            TeamDomainService teamDomainService,
            PersonDomainService personDomainService,
            SponsorshipDomainService sponsorshipDomainService,
            TrackDomainService trackDomainService,
            PerformanceCurveDomainService performanceCurveDomainService,
            LookupDomainService lookupDomainService)
        {
            Configurations = configurationDomainService ?? throw new ArgumentNullException(nameof(configurationDomainService));
            Commentaries = commentaryDomainService ?? throw new ArgumentNullException(nameof(commentaryDomainService));
            Teams = teamDomainService ?? throw new ArgumentNullException(nameof(teamDomainService));
            Persons = personDomainService ?? throw new ArgumentNullException(nameof(personDomainService));
            Sponsorships = sponsorshipDomainService ?? throw new ArgumentNullException(nameof(sponsorshipDomainService));
            Tracks = trackDomainService ?? throw new ArgumentNullException(nameof(trackDomainService));
            PerformanceCurveValues = performanceCurveDomainService ?? throw new ArgumentNullException(nameof(performanceCurveDomainService));
            Lookups = lookupDomainService ?? throw new ArgumentNullException(nameof(lookupDomainService));
        }
    }
}