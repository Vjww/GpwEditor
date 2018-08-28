using System.Collections.Generic;
using App.LanguageFileEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.LanguageFileEditor.Infrastructure.Repositories.Domain
{
    public class LanguageRepository : RepositoryBase<LanguageEntity>
    {
        public LanguageRepository(List<LanguageEntity> list) : base(list)
        {
        }
    }
}