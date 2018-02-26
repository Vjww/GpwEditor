using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Domain.EntityValidators.Lookups
{
    public class TrackLayoutLookupEntityValidator : IEntityValidator<TrackLayoutLookupEntity>
    {
        public IEnumerable<string> Validate(TrackLayoutLookupEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}