using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities.Lookups;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data.Lookups
{
    public class DriverRoleLookupDataRepository : RepositoryBase<DriverRoleLookupDataEntity>
    {
        public DriverRoleLookupDataRepository(List<DriverRoleLookupDataEntity> list) : base(list)
        {
        }
    }
}