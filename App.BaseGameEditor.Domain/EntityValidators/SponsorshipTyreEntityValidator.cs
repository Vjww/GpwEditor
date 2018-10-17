using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class SponsorshipTyreEntityValidator : IEntityValidator<SponsorshipTyreEntity>
    {
        public IEnumerable<string> Validate(SponsorshipTyreEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}