﻿using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class F1ChiefDesignerRepository : RepositoryBase<F1ChiefDesignerEntity>
    {
        public F1ChiefDesignerRepository(List<F1ChiefDesignerEntity> list) : base(list)
        {
        }
    }
}