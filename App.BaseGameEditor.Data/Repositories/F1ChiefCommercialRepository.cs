using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class F1ChiefCommercialRepository : RepositoryBase<F1ChiefCommercialDataEntity>
    {
        public F1ChiefCommercialRepository(List<F1ChiefCommercialDataEntity> list) : base(list)
        {
        }
    }
}