using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class SponsorshipContractTeam01EntityValidator : IEntityValidator<SponsorshipContractTeam01Entity>
    {
        public IEnumerable<string> Validate(SponsorshipContractTeam01Entity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}