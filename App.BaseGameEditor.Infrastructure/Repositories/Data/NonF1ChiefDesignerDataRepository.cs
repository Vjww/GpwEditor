using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class NonF1ChiefDesignerDataRepository : RepositoryBase<NonF1ChiefDesignerDataEntity>
    {
        public NonF1ChiefDesignerDataRepository(List<NonF1ChiefDesignerDataEntity> list) : base(list)
        {
        }
    }
}