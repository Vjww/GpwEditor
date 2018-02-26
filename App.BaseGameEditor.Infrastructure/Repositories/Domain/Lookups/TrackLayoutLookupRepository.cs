using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain.Lookups
{
    public class TrackLayoutLookupRepository : RepositoryBase<TrackLayoutLookupEntity>
    {
        public TrackLayoutLookupRepository(List<TrackLayoutLookupEntity> list) : base(list)
        {
        }
    }
}