using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data.Lookups
{
    public class TeamDebutGrandPrixLookupDataRepository : RepositoryBase<TeamDebutGrandPrixLookupDataEntity>
    {
        public TeamDebutGrandPrixLookupDataRepository(List<TeamDebutGrandPrixLookupDataEntity> list) : base(list)
        {
        }
    }
}