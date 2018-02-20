using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class NonF1ChiefDesignerEntityValidator : IEntityValidator<NonF1ChiefDesignerEntity>
    {
        public IEnumerable<string> Validate(NonF1ChiefDesignerEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}