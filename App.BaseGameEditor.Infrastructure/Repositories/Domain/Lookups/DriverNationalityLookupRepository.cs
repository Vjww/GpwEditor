using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class DriverNationalityLookupRepository : RepositoryBase<DriverNationalityLookupEntity>
    {
        public DriverNationalityLookupRepository(List<DriverNationalityLookupEntity> list) : base(list)
        {
        }
    }
}