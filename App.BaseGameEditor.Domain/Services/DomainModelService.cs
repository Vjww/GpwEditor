using System;

namespace App.BaseGameEditor.Domain.Services
{
    public class DomainModelService
    {
        public ConfigurationDomainService Configurations { get; }
        public LanguageDomainService Languages { get; }
        public CommentaryDomainService Commentaries { get; }
        public TeamDomainService Teams { get; }
        public PersonDomainService Persons { get; }
        public SupplierDomainService Suppliers { get; }
        public TrackDomainService Tracks { get; }
        public PerformanceCurveDomainService PerformanceCurveValues { get; }
        public LookupDomainService Lookups { get; }

        public DomainModelService(
            ConfigurationDomainService configurationDomainService,
            LanguageDomainService languageDomainService,
            CommentaryDomainService commentaryDomainService,
            TeamDomainService teamDomainService,
            PersonDomainService personDomainService,
            SupplierDomainService supplierDomainService,
            TrackDomainService trackDomainService,
            PerformanceCurveDomainService performanceCurveDomainService,
            LookupDomainService lookupDomainService)
        {
            Configurations = configurationDomainService ?? throw new ArgumentNullException(nameof(configurationDomainService));
            Languages = languageDomainService ?? throw new ArgumentNullException(nameof(languageDomainService));
            Commentaries = commentaryDomainService ?? throw new ArgumentNullException(nameof(commentaryDomainService));
            Teams = teamDomainService ?? throw new ArgumentNullException(nameof(teamDomainService));
            Persons = personDomainService ?? throw new ArgumentNullException(nameof(personDomainService));
            Suppliers = supplierDomainService ?? throw new ArgumentNullException(nameof(supplierDomainService));
            Tracks = trackDomainService ?? throw new ArgumentNullException(nameof(trackDomainService));
            PerformanceCurveValues = performanceCurveDomainService ?? throw new ArgumentNullException(nameof(performanceCurveDomainService));
            Lookups = lookupDomainService ?? throw new ArgumentNullException(nameof(lookupDomainService));
        }
    }
}