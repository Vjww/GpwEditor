using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class F1ChiefMechanicDataRepository : DataRepositoryBase<F1ChiefMechanicDataEntity>
    {
        public F1ChiefMechanicDataRepository(List<F1ChiefMechanicDataEntity> list) : base(list)
        {
        }
    }
}