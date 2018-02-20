﻿using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class NonF1ChiefCommercialRepository : RepositoryBase<NonF1ChiefCommercialEntity>
    {
        public NonF1ChiefCommercialRepository(List<NonF1ChiefCommercialEntity> list) : base(list)
        {
        }
    }
}