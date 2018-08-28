using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class DriverNationalityLookupRepository : RepositoryBase<DriverNationalityLookupEntity>
    {
        public DriverNationalityLookupRepository(List<DriverNationalityLookupEntity> list) : base(list)
        {
        }
    }
}