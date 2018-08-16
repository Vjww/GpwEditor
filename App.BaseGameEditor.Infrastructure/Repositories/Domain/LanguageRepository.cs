using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class LanguageRepository : RepositoryBase<LanguageEntity>
    {
        public LanguageRepository(List<LanguageEntity> list) : base(list)
        {
        }
    }
}