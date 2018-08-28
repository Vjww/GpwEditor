using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class ChiefDriverLoyaltyLookupRepository : RepositoryBase<ChiefDriverLoyaltyLookupEntity>
    {
        public ChiefDriverLoyaltyLookupRepository(List<ChiefDriverLoyaltyLookupEntity> list) : base(list)
        {
        }
    }
}