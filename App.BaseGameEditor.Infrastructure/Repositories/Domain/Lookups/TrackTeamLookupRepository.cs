using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class TrackTeamLookupRepository : RepositoryBase<TrackTeamLookupEntity>
    {
        public TrackTeamLookupRepository(List<TrackTeamLookupEntity> list) : base(list)
        {
        }
    }
}