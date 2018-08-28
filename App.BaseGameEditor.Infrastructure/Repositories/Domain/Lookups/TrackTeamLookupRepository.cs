using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class TrackTeamLookupRepository : RepositoryBase<TrackTeamLookupEntity>
    {
        public TrackTeamLookupRepository(List<TrackTeamLookupEntity> list) : base(list)
        {
        }
    }
}