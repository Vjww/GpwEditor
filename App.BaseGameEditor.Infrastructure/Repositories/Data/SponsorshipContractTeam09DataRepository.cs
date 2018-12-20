using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipContractTeam09DataRepository : RepositoryBase<SponsorshipContractTeam09DataEntity>
    {
        public SponsorshipContractTeam09DataRepository(List<SponsorshipContractTeam09DataEntity> list) : base(list)
        {
        }
    }
}