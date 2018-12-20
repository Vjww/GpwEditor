using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipContractTeam01DataRepository : RepositoryBase<SponsorshipContractTeam01DataEntity>
    {
        public SponsorshipContractTeam01DataRepository(List<SponsorshipContractTeam01DataEntity> list) : base(list)
        {
        }
    }
}