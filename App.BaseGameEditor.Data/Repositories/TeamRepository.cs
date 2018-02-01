using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class TeamRepository : RepositoryBase<TeamDataEntity>
    {
        public TeamRepository(List<TeamDataEntity> list) : base(list)
        {
        }
    }
}