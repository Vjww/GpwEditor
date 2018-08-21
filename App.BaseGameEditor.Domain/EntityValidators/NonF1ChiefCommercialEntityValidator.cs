using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class NonF1ChiefCommercialEntityValidator : IEntityValidator<NonF1ChiefCommercialEntity>
    {
        public IEnumerable<string> Validate(NonF1ChiefCommercialEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}