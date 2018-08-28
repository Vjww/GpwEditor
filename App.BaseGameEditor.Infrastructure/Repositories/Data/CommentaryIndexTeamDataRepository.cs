using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class CommentaryIndexTeamDataRepository : RepositoryBase<CommentaryIndexTeamDataEntity>
    {
        public CommentaryIndexTeamDataRepository(List<CommentaryIndexTeamDataEntity> list) : base(list)
        {
        }
    }
}