using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class TrackDriverLookupRepository : RepositoryBase<TrackDriverLookupEntity>
    {
        public TrackDriverLookupRepository(List<TrackDriverLookupEntity> list) : base(list)
        {
        }
    }
}