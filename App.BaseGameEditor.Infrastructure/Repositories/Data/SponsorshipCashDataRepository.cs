using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipCashDataRepository : RepositoryBase<SponsorshipCashDataEntity>
    {
        public SponsorshipCashDataRepository(List<SponsorshipCashDataEntity> list) : base(list)
        {
        }
    }
}