using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class SponsorContractEntityValidator : IEntityValidator<SponsorContractEntity>
    {
        public IEnumerable<string> Validate(SponsorContractEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}