using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class TyreDataRepository : RepositoryBase<TyreDataEntity>
    {
        public TyreDataRepository(List<TyreDataEntity> list) : base(list)
        {
        }
    }
}