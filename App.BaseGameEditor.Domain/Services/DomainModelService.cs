using System;

namespace App.BaseGameEditor.Domain.Services
{
    public class DomainModelService
    {
        public TeamDomainService Teams { get; }
        public PersonDomainService Persons { get; }

        public DomainModelService(
            TeamDomainService teamDomainService,
            PersonDomainService personDomainService)
        {
            Teams = teamDomainService ?? throw new ArgumentNullException(nameof(teamDomainService));
            Persons = personDomainService ?? throw new ArgumentNullException(nameof(personDomainService));
        }
    }
}