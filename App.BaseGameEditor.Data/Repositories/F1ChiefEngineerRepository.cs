using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class F1ChiefEngineerRepository : RepositoryBase<F1ChiefEngineerDataEntity>
    {
        public F1ChiefEngineerRepository(List<F1ChiefEngineerDataEntity> list) : base(list)
        {
        }
    }
}