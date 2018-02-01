using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class F1DriverRepository : RepositoryBase<F1DriverDataEntity>
    {
        public F1DriverRepository(List<F1DriverDataEntity> list) : base(list)
        {
        }
    }
}