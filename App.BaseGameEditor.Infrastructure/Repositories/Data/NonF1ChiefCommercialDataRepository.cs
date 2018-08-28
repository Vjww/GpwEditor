using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class NonF1ChiefCommercialDataRepository : RepositoryBase<NonF1ChiefCommercialDataEntity>
    {
        public NonF1ChiefCommercialDataRepository(List<NonF1ChiefCommercialDataEntity> list) : base(list)
        {
        }
    }
}