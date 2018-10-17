using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipEngineDataRepository : RepositoryBase<SponsorshipEngineDataEntity>
    {
        public SponsorshipEngineDataRepository(List<SponsorshipEngineDataEntity> list) : base(list)
        {
        }
    }
}