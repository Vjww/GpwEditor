using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators.Lookups
{
    public class SponsorNameLookupEntityValidator : IEntityValidator<SponsorNameLookupEntity>
    {
        public IEnumerable<string> Validate(SponsorNameLookupEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}