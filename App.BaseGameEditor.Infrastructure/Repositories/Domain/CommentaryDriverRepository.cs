using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class CommentaryDriverRepository : RepositoryBase<CommentaryDriverEntity>
    {
        public CommentaryDriverRepository(List<CommentaryDriverEntity> list) : base(list)
        {
        }
    }
}