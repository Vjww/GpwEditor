using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class NonF1ChiefMechanicEntityValidator : IEntityValidator<NonF1ChiefMechanicEntity>
    {
        public IEnumerable<string> Validate(NonF1ChiefMechanicEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}