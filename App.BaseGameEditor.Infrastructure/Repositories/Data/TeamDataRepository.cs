using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class TeamDataRepository : RepositoryBase<TeamDataEntity>
    {
        public TeamDataRepository(List<TeamDataEntity> list) : base(list)
        {
        }
    }
}