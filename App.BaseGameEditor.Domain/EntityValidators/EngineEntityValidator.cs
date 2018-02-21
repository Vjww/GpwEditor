using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Domain.EntityValidators
{
    public class EngineEntityValidator : IEntityValidator<EngineEntity>
    {
        public IEnumerable<string> Validate(EngineEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}