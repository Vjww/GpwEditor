using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class ChassisHandlingDataRepository : RepositoryBase<ChassisHandlingDataEntity>
    {
        public ChassisHandlingDataRepository(List<ChassisHandlingDataEntity> list) : base(list)
        {
        }
    }
}