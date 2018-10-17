using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class SponsorshipCashEntityValidator : IEntityValidator<SponsorshipCashEntity>
    {
        public IEnumerable<string> Validate(SponsorshipCashEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}