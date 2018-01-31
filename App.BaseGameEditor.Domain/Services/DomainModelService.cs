using System;

namespace App.BaseGameEditor.Domain.Services
{
    public class DomainModelService
    {
        public TeamService Teams { get; }
        public PersonService Persons { get; }

        public DomainModelService(
            TeamService teamService,
            PersonService personService)
        {
            Teams = teamService ?? throw new ArgumentNullException(nameof(teamService));
            Persons = personService ?? throw new ArgumentNullException(nameof(personService));
        }
    }
}