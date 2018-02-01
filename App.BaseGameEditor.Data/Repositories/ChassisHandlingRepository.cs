using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class ChassisHandlingRepository : RepositoryBase<ChassisHandlingDataEntity>
    {
        public ChassisHandlingRepository(List<ChassisHandlingDataEntity> list) : base(list)
        {
        }
    }
}