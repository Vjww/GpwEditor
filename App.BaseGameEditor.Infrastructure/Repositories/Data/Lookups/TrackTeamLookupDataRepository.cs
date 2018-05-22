﻿using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities.Lookups;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data.Lookups
{
    public class TrackTeamLookupDataRepository : RepositoryBase<TrackTeamLookupDataEntity>
    {
        public TrackTeamLookupDataRepository(List<TrackTeamLookupDataEntity> list) : base(list)
        {
        }
    }
}