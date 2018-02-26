using System;

namespace App.BaseGameEditor.Domain.Services
{
    public class DomainModelService
    {
        public TeamDomainService Teams { get; }
        public PersonDomainService Persons { get; }
        public SupplierDomainService Suppliers { get; }
        public TrackDomainService Tracks { get; }
        public PerformanceCurveDomainService PerformanceCurveValues { get; }
        public LookupDomainService Lookups { get; }

        public DomainModelService(
            TeamDomainService teamDomainService,
            PersonDomainService personDomainService,
            SupplierDomainService supplierDomainService,
            TrackDomainService trackDomainService,
            PerformanceCurveDomainService performanceCurveDomainService,
            LookupDomainService lookupDomainService)
        {
            Teams = teamDomainService ?? throw new ArgumentNullException(nameof(teamDomainService));
            Persons = personDomainService ?? throw new ArgumentNullException(nameof(personDomainService));
            Suppliers = supplierDomainService ?? throw new ArgumentNullException(nameof(supplierDomainService));
            Tracks = trackDomainService ?? throw new ArgumentNullException(nameof(trackDomainService));
            PerformanceCurveValues = performanceCurveDomainService ?? throw new ArgumentNullException(nameof(performanceCurveDomainService));
            Lookups = lookupDomainService ?? throw new ArgumentNullException(nameof(lookupDomainService));
        }
    }
}