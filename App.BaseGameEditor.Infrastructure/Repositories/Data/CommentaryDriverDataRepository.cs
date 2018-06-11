using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class CommentaryDriverDataRepository : RepositoryBase<CommentaryDriverDataEntity>
    {
        public CommentaryDriverDataRepository(List<CommentaryDriverDataEntity> list) : base(list)
        {
        }
    }
}