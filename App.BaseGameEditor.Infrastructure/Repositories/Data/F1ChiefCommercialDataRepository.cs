using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class F1ChiefCommercialDataRepository : RepositoryBase<F1ChiefCommercialDataEntity>
    {
        public F1ChiefCommercialDataRepository(List<F1ChiefCommercialDataEntity> list) : base(list)
        {
        }
    }
}