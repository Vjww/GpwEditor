using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class SponsorshipContractTeam09EntityValidator : IEntityValidator<SponsorshipContractTeam09Entity>
    {
        public IEnumerable<string> Validate(SponsorshipContractTeam09Entity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}