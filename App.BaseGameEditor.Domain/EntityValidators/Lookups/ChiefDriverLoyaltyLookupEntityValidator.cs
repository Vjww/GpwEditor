using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Domain.EntityValidators.Lookups
{
    public class ChiefDriverLoyaltyLookupEntityValidator : IEntityValidator<ChiefDriverLoyaltyLookupEntity>
    {
        public IEnumerable<string> Validate(ChiefDriverLoyaltyLookupEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}