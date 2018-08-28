using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class F1DriverDataRepository : RepositoryBase<F1DriverDataEntity>
    {
        public F1DriverDataRepository(List<F1DriverDataEntity> list) : base(list)
        {
        }
    }
}