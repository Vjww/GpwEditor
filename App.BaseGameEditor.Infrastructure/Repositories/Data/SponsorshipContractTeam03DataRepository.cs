using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipContractTeam03DataRepository : RepositoryBase<SponsorshipContractTeam03DataEntity>
    {
        public SponsorshipContractTeam03DataRepository(List<SponsorshipContractTeam03DataEntity> list) : base(list)
        {
        }
    }
}