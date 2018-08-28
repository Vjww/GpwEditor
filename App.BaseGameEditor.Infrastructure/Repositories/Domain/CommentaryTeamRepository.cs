using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class CommentaryTeamRepository : RepositoryBase<CommentaryTeamEntity>
    {
        public CommentaryTeamRepository(List<CommentaryTeamEntity> list) : base(list)
        {
        }
    }
}