using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class TyreEntityValidator : IEntityValidator<TyreEntity>
    {
        public IEnumerable<string> Validate(TyreEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}