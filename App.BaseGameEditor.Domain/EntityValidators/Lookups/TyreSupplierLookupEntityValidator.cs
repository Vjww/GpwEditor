using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Domain.EntityValidators.Lookups
{
    public class TyreSupplierLookupEntityValidator : IEntityValidator<TyreSupplierLookupEntity>
    {
        public IEnumerable<string> Validate(TyreSupplierLookupEntity entity)
        {
            var validationMessages = new List<string>();

            return validationMessages;
        }
    }
}