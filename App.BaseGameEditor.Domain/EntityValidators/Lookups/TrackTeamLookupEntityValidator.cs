using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators.Lookups
{
    public class TrackTeamLookupEntityValidator : IEntityValidator<TrackTeamLookupEntity>
    {
        public IEnumerable<string> Validate(TrackTeamLookupEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}