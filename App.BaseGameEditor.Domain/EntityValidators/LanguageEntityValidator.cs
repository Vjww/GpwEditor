using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class LanguageEntityValidator : IEntityValidator<LanguageEntity>
    {
        public IEnumerable<string> Validate(LanguageEntity entity)
        {
            var validationMessages = new List<string>();

            // TODO: Add validation for fields

            return validationMessages;
        }
    }
}