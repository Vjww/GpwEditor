using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities.Lookups;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data.Lookups
{
    public class TyreSupplierLookupDataRepository : RepositoryBase<TyreSupplierLookupDataEntity>
    {
        public TyreSupplierLookupDataRepository(List<TyreSupplierLookupDataEntity> list) : base(list)
        {
        }
    }
}