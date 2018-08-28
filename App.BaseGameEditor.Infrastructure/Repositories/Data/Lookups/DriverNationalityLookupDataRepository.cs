using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities.Lookups;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data.Lookups
{
    public class DriverNationalityLookupDataRepository : RepositoryBase<DriverNationalityLookupDataEntity>
    {
        public DriverNationalityLookupDataRepository(List<DriverNationalityLookupDataEntity> list) : base(list)
        {
        }
    }
}