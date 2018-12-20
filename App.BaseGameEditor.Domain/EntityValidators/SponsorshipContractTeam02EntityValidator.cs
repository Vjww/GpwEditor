using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class SponsorshipContractTeam02EntityValidator : IEntityValidator<SponsorshipContractTeam02Entity>
    {
        public IEnumerable<string> Validate(SponsorshipContractTeam02Entity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}