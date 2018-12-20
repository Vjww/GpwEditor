using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class SponsorshipContractTeam10EntityValidator : IEntityValidator<SponsorshipContractTeam10Entity>
    {
        public IEnumerable<string> Validate(SponsorshipContractTeam10Entity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}