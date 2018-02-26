using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Domain.EntityValidators.Lookups
{
    public class TeamDebutGrandPrixLookupEntityValidator : IEntityValidator<TeamDebutGrandPrixLookupEntity>
    {
        public IEnumerable<string> Validate(TeamDebutGrandPrixLookupEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}