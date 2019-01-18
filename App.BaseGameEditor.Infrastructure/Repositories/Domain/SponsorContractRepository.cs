using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class SponsorContractRepository : RepositoryBase<SponsorContractEntity>
    {
        public SponsorContractRepository(List<SponsorContractEntity> list) : base(list)
        {
        }
    }
}