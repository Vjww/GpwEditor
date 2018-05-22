using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class CommentaryPrefixTeamDataRepository : RepositoryBase<CommentaryPrefixTeamDataEntity>
    {
        public CommentaryPrefixTeamDataRepository(List<CommentaryPrefixTeamDataEntity> list) : base(list)
        {
        }
    }
}