using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class F1ChiefDesignerDataRepository : DataRepositoryBase<F1ChiefDesignerDataEntity>
    {
        public F1ChiefDesignerDataRepository(List<F1ChiefDesignerDataEntity> list) : base(list)
        {
        }
    }
}