using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class CommentaryTeamRepository : RepositoryBase<CommentaryTeamEntity>
    {
        public CommentaryTeamRepository(List<CommentaryTeamEntity> list) : base(list)
        {
        }
    }
}