using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class CommentaryIndexTeamRepository : RepositoryBase<CommentaryIndexTeamEntity>
    {
        public CommentaryIndexTeamRepository(List<CommentaryIndexTeamEntity> list) : base(list)
        {
        }
    }
}