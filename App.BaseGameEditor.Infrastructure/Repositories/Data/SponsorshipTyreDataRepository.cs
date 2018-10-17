using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipTyreDataRepository : RepositoryBase<SponsorshipTyreDataEntity>
    {
        public SponsorshipTyreDataRepository(List<SponsorshipTyreDataEntity> list) : base(list)
        {
        }
    }
}