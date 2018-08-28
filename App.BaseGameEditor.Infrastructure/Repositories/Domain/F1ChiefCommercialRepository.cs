using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class F1ChiefCommercialRepository : RepositoryBase<F1ChiefCommercialEntity>
    {
        public F1ChiefCommercialRepository(List<F1ChiefCommercialEntity> list) : base(list)
        {
        }
    }
}