using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Domain.EntityValidators.Lookups
{
    public class TrackDriverLookupEntityValidator : IEntityValidator<TrackDriverLookupEntity>
    {
        public IEnumerable<string> Validate(TrackDriverLookupEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}