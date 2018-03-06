using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Domain.EntityValidators.Lookups
{
    public class DriverRoleLookupEntityValidator : IEntityValidator<DriverRoleLookupEntity>
    {
        public IEnumerable<string> Validate(DriverRoleLookupEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}