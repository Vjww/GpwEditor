using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data.Lookups
{
    public class TrackFastestLapDriverLookupDataRepository : RepositoryBase<TrackFastestLapDriverLookupDataEntity>
    {
        public TrackFastestLapDriverLookupDataRepository(List<TrackFastestLapDriverLookupDataEntity> list) : base(list)
        {
        }
    }
}