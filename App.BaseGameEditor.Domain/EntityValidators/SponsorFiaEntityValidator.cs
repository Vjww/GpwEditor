using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class SponsorFiaEntityValidator : IEntityValidator<SponsorFiaEntity>
    {
        public IEnumerable<string> Validate(SponsorFiaEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}