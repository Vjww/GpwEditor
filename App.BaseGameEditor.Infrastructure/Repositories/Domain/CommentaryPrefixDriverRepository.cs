using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class CommentaryPrefixDriverRepository : RepositoryBase<CommentaryPrefixDriverEntity>
    {
        public CommentaryPrefixDriverRepository(List<CommentaryPrefixDriverEntity> list) : base(list)
        {
        }
    }
}