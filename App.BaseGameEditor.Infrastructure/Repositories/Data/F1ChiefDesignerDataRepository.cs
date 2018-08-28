using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class F1ChiefDesignerDataRepository : RepositoryBase<F1ChiefDesignerDataEntity>
    {
        public F1ChiefDesignerDataRepository(List<F1ChiefDesignerDataEntity> list) : base(list)
        {
        }
    }
}