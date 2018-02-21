using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class FuelEntityValidator : IEntityValidator<FuelEntity>
    {
        public IEnumerable<string> Validate(FuelEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}