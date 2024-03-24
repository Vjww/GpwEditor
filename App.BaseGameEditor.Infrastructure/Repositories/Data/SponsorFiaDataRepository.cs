using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorFiaDataRepository : RepositoryBase<SponsorFiaDataEntity>
    {
        public SponsorFiaDataRepository(List<SponsorFiaDataEntity> list) : base(list)
        {
        }
    }
}