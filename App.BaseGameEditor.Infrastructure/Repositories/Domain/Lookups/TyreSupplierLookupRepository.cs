using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class TyreSupplierLookupRepository : RepositoryBase<TyreSupplierLookupEntity>
    {
        public TyreSupplierLookupRepository(List<TyreSupplierLookupEntity> list) : base(list)
        {
        }
    }
}