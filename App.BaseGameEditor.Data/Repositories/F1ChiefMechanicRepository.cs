using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class F1ChiefMechanicRepository : RepositoryBase<F1ChiefMechanicDataEntity>
    {
        public F1ChiefMechanicRepository(List<F1ChiefMechanicDataEntity> list) : base(list)
        {
        }
    }
}