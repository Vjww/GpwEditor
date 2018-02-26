﻿using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data.Lookups
{
    public class TrackLayoutLookupDataRepository : RepositoryBase<TrackLayoutLookupDataEntity>
    {
        public TrackLayoutLookupDataRepository(List<TrackLayoutLookupDataEntity> list) : base(list)
        {
        }
    }
}