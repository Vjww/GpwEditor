using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class DriverRoleLookupRepository : RepositoryBase<DriverRoleLookupEntity>
    {
        public DriverRoleLookupRepository(List<DriverRoleLookupEntity> list) : base(list)
        {
        }
    }
}