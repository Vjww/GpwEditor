using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class NonF1ChiefEngineerEntityValidator : IEntityValidator<NonF1ChiefEngineerEntity>
    {
        public IEnumerable<string> Validate(NonF1ChiefEngineerEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}