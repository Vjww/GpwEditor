using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class SponsorshipFuelEntityValidator : IEntityValidator<SponsorshipFuelEntity>
    {
        public IEnumerable<string> Validate(SponsorshipFuelEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}