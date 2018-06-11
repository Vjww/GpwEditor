using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class CommentaryTeamDataRepository : RepositoryBase<CommentaryTeamDataEntity>
    {
        public CommentaryTeamDataRepository(List<CommentaryTeamDataEntity> list) : base(list)
        {
        }
    }
}