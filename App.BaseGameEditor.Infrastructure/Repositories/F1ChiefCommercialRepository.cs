using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories
{
    public class F1ChiefCommercialRepository : RepositoryBase<F1ChiefCommercialEntity>, IF1ChiefCommercialRepository
    {
        public F1ChiefCommercialRepository(List<F1ChiefCommercialEntity> list) : base(list)
        {
        }
    }
}