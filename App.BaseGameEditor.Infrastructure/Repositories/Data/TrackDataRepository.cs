using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class TrackDataRepository : RepositoryBase<TrackDataEntity>
    {
        public TrackDataRepository(List<TrackDataEntity> list) : base(list)
        {
        }
    }
}