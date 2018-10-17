using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class SponsorshipCashRepository : RepositoryBase<SponsorshipCashEntity>
    {
        public SponsorshipCashRepository(List<SponsorshipCashEntity> list) : base(list)
        {
        }
    }
}