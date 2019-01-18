﻿using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorContractDataRepository : RepositoryBase<SponsorContractDataEntity>
    {
        public SponsorContractDataRepository(List<SponsorContractDataEntity> list) : base(list)
        {
        }
    }
}