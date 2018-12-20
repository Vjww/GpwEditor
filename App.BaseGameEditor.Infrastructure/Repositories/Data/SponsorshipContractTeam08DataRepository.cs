using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipContractTeam08DataRepository : RepositoryBase<SponsorshipContractTeam08DataEntity>
    {
        public SponsorshipContractTeam08DataRepository(List<SponsorshipContractTeam08DataEntity> list) : base(list)
        {
        }
    }
}