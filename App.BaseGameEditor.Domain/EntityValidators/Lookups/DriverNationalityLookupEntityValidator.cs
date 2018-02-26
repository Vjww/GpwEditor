using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Domain.EntityValidators.Lookups
{
    public class DriverNationalityLookupEntityValidator : IEntityValidator<DriverNationalityLookupEntity>
    {
        public IEnumerable<string> Validate(DriverNationalityLookupEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}