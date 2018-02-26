using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Domain.EntityValidators.Lookups
{
    public class TrackFastestLapDriverLookupEntityValidator : IEntityValidator<TrackFastestLapDriverLookupEntity>
    {
        public IEnumerable<string> Validate(TrackFastestLapDriverLookupEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}