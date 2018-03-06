using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data.Lookups
{
    public class TrackDriverLookupDataRepository : RepositoryBase<TrackDriverLookupDataEntity>
    {
        public TrackDriverLookupDataRepository(List<TrackDriverLookupDataEntity> list) : base(list)
        {
        }
    }
}