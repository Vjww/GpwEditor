using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorDataRepository : RepositoryBase<SponsorDataEntity>
    {
        public SponsorDataRepository(List<SponsorDataEntity> list) : base(list)
        {
        }
    }
}