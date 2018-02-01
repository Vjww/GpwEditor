﻿using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class CarNumberRepository : RepositoryBase<CarNumberDataEntity>
    {
        public CarNumberRepository(List<CarNumberDataEntity> list) : base(list)
        {
        }
    }
}