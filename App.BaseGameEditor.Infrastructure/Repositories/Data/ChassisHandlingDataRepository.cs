using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class ChassisHandlingDataRepository : DataRepositoryBase<ChassisHandlingDataEntity>
    {
        public ChassisHandlingDataRepository(List<ChassisHandlingDataEntity> list) : base(list)
        {
        }
    }
}