using System.Collections.Generic;
using App.LanguageFileEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.LanguageFileEditor.Infrastructure.Repositories.Data
{
    public class LanguageDataRepository : RepositoryBase<LanguageDataEntity>
    {
        public LanguageDataRepository(List<LanguageDataEntity> list) : base(list)
        {
        }
    }
}