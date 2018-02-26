using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data.Lookups
{
    public class DriverNationalityLookupDataRepository : RepositoryBase<DriverNationalityLookupDataEntity>
    {
        public DriverNationalityLookupDataRepository(List<DriverNationalityLookupDataEntity> list) : base(list)
        {
        }
    }
}