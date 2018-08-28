using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class TeamDebutGrandPrixLookupRepository : RepositoryBase<TeamDebutGrandPrixLookupEntity>
    {
        public TeamDebutGrandPrixLookupRepository(List<TeamDebutGrandPrixLookupEntity> list) : base(list)
        {
        }
    }
}