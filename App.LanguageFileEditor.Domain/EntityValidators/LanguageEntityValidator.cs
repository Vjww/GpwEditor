using System.Collections.Generic;
using App.LanguageFileEditor.Domain.Entities;
using App.Shared.Domain.EntityValidators;

namespace App.LanguageFileEditor.Domain.EntityValidators
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