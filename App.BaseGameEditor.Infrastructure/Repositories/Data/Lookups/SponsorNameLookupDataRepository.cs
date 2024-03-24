using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities.Lookups;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data.Lookups
{
    public class SponsorNameLookupDataRepository : RepositoryBase<SponsorNameLookupDataEntity>
    {
        public SponsorNameLookupDataRepository(List<SponsorNameLookupDataEntity> list) : base(list)
        {
        }
    }
}