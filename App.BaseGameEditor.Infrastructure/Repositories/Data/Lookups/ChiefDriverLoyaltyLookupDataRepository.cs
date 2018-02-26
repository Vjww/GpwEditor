using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data.Lookups
{
    public class ChiefDriverLoyaltyLookupDataRepository : RepositoryBase<ChiefDriverLoyaltyLookupDataEntity>
    {
        public ChiefDriverLoyaltyLookupDataRepository(List<ChiefDriverLoyaltyLookupDataEntity> list) : base(list)
        {
        }
    }
}