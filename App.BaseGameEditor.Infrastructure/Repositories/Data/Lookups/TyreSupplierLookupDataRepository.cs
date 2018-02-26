using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data.Lookups
{
    public class TyreSupplierLookupDataRepository : RepositoryBase<TyreSupplierLookupDataEntity>
    {
        public TyreSupplierLookupDataRepository(List<TyreSupplierLookupDataEntity> list) : base(list)
        {
        }
    }
}