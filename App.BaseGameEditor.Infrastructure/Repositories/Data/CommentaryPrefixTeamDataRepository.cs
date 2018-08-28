using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class CommentaryPrefixTeamDataRepository : RepositoryBase<CommentaryPrefixTeamDataEntity>
    {
        public CommentaryPrefixTeamDataRepository(List<CommentaryPrefixTeamDataEntity> list) : base(list)
        {
        }
    }
}