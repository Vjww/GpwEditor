using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class NonF1ChiefMechanicDataRepository : RepositoryBase<NonF1ChiefMechanicDataEntity>
    {
        public NonF1ChiefMechanicDataRepository(List<NonF1ChiefMechanicDataEntity> list) : base(list)
        {
        }
    }
}