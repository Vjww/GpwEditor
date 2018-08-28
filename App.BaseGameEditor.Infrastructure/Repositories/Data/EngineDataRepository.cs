using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class EngineDataRepository : RepositoryBase<EngineDataEntity>
    {
        public EngineDataRepository(List<EngineDataEntity> list) : base(list)
        {
        }
    }
}