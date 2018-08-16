using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class LanguageDataRepository : RepositoryBase<LanguageDataEntity>
    {
        public LanguageDataRepository(List<LanguageDataEntity> list) : base(list)
        {
        }
    }
}