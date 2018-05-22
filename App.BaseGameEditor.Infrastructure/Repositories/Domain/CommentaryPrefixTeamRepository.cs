using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class CommentaryPrefixTeamRepository : RepositoryBase<CommentaryPrefixTeamEntity>
    {
        public CommentaryPrefixTeamRepository(List<CommentaryPrefixTeamEntity> list) : base(list)
        {
        }
    }
}