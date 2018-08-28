using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class NonF1DriverDataRepository : RepositoryBase<NonF1DriverDataEntity>
    {
        public NonF1DriverDataRepository(List<NonF1DriverDataEntity> list) : base(list)
        {
        }
    }
}