using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class F1ChiefDesignerRepository : RepositoryBase<F1ChiefDesignerDataEntity>
    {
        public F1ChiefDesignerRepository(List<F1ChiefDesignerDataEntity> list) : base(list)
        {
        }
    }
}