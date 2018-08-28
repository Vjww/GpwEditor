using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class CommentaryPrefixDriverRepository : RepositoryBase<CommentaryPrefixDriverEntity>
    {
        public CommentaryPrefixDriverRepository(List<CommentaryPrefixDriverEntity> list) : base(list)
        {
        }
    }
}