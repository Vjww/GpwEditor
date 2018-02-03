using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class F1DriverDataRepository : DataRepositoryBase<F1DriverDataEntity>
    {
        public F1DriverDataRepository(List<F1DriverDataEntity> list) : base(list)
        {
        }
    }
}