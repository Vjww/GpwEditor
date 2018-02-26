using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class TrackFastestLapDriverLookupRepository : RepositoryBase<TrackFastestLapDriverLookupEntity>
    {
        public TrackFastestLapDriverLookupRepository(List<TrackFastestLapDriverLookupEntity> list) : base(list)
        {
        }
    }
}