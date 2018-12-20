using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Data
{
    public class SponsorshipContractTeam06DataRepository : RepositoryBase<SponsorshipContractTeam06DataEntity>
    {
        public SponsorshipContractTeam06DataRepository(List<SponsorshipContractTeam06DataEntity> list) : base(list)
        {
        }
    }
}