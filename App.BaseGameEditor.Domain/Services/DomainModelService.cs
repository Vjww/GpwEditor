using System;

namespace App.BaseGameEditor.Domain.Services
{
    public class DomainModelService
    {
        public TeamDomainService Teams { get; }
        public PersonDomainService Persons { get; }
        public SupplierDomainService Suppliers { get; }

        public DomainModelService(
            TeamDomainService teamDomainService,
            PersonDomainService personDomainService,
            SupplierDomainService supplierDomainService)
        {
            Teams = teamDomainService ?? throw new ArgumentNullException(nameof(teamDomainService));
            Persons = personDomainService ?? throw new ArgumentNullException(nameof(personDomainService));
            Suppliers = supplierDomainService ?? throw new ArgumentNullException(nameof(supplierDomainService));
        }
    }
}