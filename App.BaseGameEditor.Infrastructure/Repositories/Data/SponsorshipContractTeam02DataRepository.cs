using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipContractTeam02DataRepository : RepositoryBase<SponsorshipContractTeam02DataEntity>
    {
        public SponsorshipContractTeam02DataRepository(List<SponsorshipContractTeam02DataEntity> list) : base(list)
        {
        }
    }
}