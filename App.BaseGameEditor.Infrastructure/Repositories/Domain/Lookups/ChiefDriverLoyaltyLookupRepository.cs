using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class ChiefDriverLoyaltyLookupRepository : RepositoryBase<ChiefDriverLoyaltyLookupEntity>
    {
        public ChiefDriverLoyaltyLookupRepository(List<ChiefDriverLoyaltyLookupEntity> list) : base(list)
        {
        }
    }
}