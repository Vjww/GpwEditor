using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class SponsorshipTeamEntityValidator : IEntityValidator<SponsorshipTeamEntity>
    {
        public IEnumerable<string> Validate(SponsorshipTeamEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}