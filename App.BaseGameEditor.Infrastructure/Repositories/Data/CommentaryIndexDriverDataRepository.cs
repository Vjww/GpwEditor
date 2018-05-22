using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class CommentaryIndexDriverDataRepository : RepositoryBase<CommentaryIndexDriverDataEntity>
    {
        public CommentaryIndexDriverDataRepository(List<CommentaryIndexDriverDataEntity> list) : base(list)
        {
        }
    }
}