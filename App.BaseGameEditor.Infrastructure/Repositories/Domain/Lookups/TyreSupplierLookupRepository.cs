using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class TyreSupplierLookupRepository : RepositoryBase<TyreSupplierLookupEntity>
    {
        public TyreSupplierLookupRepository(List<TyreSupplierLookupEntity> list) : base(list)
        {
        }
    }
}