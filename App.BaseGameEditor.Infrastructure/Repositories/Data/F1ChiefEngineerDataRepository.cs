using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class F1ChiefEngineerDataRepository : RepositoryBase<F1ChiefEngineerDataEntity>
    {
        public F1ChiefEngineerDataRepository(List<F1ChiefEngineerDataEntity> list) : base(list)
        {
        }
    }
}