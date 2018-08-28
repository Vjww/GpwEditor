using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities.Lookups;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data.Lookups
{
    public class TrackTeamLookupDataRepository : RepositoryBase<TrackTeamLookupDataEntity>
    {
        public TrackTeamLookupDataRepository(List<TrackTeamLookupDataEntity> list) : base(list)
        {
        }
    }
}