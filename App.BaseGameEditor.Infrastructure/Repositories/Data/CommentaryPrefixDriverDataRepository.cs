using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class CommentaryPrefixDriverDataRepository : RepositoryBase<CommentaryPrefixDriverDataEntity>
    {
        public CommentaryPrefixDriverDataRepository(List<CommentaryPrefixDriverDataEntity> list) : base(list)
        {
        }
    }
}