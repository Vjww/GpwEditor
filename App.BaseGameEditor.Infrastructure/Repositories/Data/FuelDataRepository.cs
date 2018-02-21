﻿using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class FuelDataRepository : RepositoryBase<FuelDataEntity>
    {
        public FuelDataRepository(List<FuelDataEntity> list) : base(list)
        {
        }
    }
}