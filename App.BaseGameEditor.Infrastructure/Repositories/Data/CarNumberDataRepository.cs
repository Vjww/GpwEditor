using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class CarNumberDataRepository : RepositoryBase<CarNumberDataEntity>
    {
        public CarNumberDataRepository(List<CarNumberDataEntity> list) : base(list)
        {
        }
    }
}