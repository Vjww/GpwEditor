using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class SponsorshipContractTeam05EntityValidator : IEntityValidator<SponsorshipContractTeam05Entity>
    {
        public IEnumerable<string> Validate(SponsorshipContractTeam05Entity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}