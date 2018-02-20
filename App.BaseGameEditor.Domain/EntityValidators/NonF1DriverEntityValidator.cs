using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class NonF1DriverEntityValidator : IEntityValidator<NonF1DriverEntity>
    {
        public IEnumerable<string> Validate(NonF1DriverEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}