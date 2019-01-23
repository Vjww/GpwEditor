using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class SponsorNameLookupRepository : RepositoryBase<SponsorNameLookupEntity>
    {
        public SponsorNameLookupRepository(List<SponsorNameLookupEntity> list) : base(list)
        {
        }
    }
}