using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class CommentaryIndexDriverRepository : RepositoryBase<CommentaryIndexDriverEntity>
    {
        public CommentaryIndexDriverRepository(List<CommentaryIndexDriverEntity> list) : base(list)
        {
        }
    }
}