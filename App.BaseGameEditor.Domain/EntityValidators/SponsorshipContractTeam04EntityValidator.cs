using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class SponsorshipContractTeam04EntityValidator : IEntityValidator<SponsorshipContractTeam04Entity>
    {
        public IEnumerable<string> Validate(SponsorshipContractTeam04Entity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}