using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class F1ChiefMechanicDataRepository : RepositoryBase<F1ChiefMechanicDataEntity>
    {
        public F1ChiefMechanicDataRepository(List<F1ChiefMechanicDataEntity> list) : base(list)
        {
        }
    }
}